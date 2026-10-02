using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Windows.Forms;

namespace MMI
{
    // SCAN TRIGGER engineer screen (Auto > TRIGGER, screen 12, engineer level).
    //
    // The Auto screen keeps the recipe, SET and START: that is where an
    // operator runs a scan and where the recipe checks already live, and a
    // second copy of them here could only drift from the first. This screen
    // is for what sits under the recipe:
    //
    //   Scan Cycle          what SEQ judged the recipe to be, and where the
    //                       cycle is - with OUTPUT TEST and STOP
    //   Scan Geometry       motor index 50..53 to scale, with the encoder on it
    //   Live Counter        the counter channel as the board reports it
    //   Counter H/W Config  the board settings SEQ runs the trigger with
    //   Trigger Log         what was done here, and what SEQ answered
    //
    // Reads go through CThreadMain, like every other shared memory read in
    // the program, and arrive here through RenderFromSeq(). Writes are button
    // presses and go straight out, a few times over because MemPort gives up
    // on a busy mutex.
    public partial class FormScanTrigger : Form
    {
        private FormMain frmMain = null;

        private const int ScanTriggerTries = 3;

        // SCANTRIGGER_HWCFG_RESULT in SharedMemBase.h.
        private const int HwCfgOk    = 0;
        private const int HwCfgBusy  = 1;
        private const int HwCfgRange = 2;

        // SCANTRIGGER_CNTCLR_MODE in SharedMemBase.h.
        private const int CntClrTriggerCount = 0;
        private const int CntClrEncToAxis    = 1;

        private const string IniSection = "SCAN TRIGGER HW";

        // Set while this screen is on display; CThreadMain polls only then.
        public volatile bool bWatch = false;

        // The settings boxes are being filled from SEQ, not typed.
        private bool bFillingHwCfg = false;

        private int nLastState = -1;
        private int nLastValidate = -1;

        public FormScanTrigger()
        {
            InitializeComponent();
        }

        public FormScanTrigger(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormScanTrigger_Load(object sender, EventArgs e)
        {
            FillHwCfg(LoadSavedHwCfg() ?? DefaultHwCfg());
            lblHwCfgResult.Text = "Showing the saved settings. READ shows what SEQ is using.";
            InitMotor();
        }

        private void FormScanTrigger_VisibleChanged(object sender, EventArgs e)
        {
            bWatch = Visible;
            if (Visible)
            {
                nLastState = -1;
                nLastValidate = -1;
            }
            MotorVisibleChanged();
        }

        // Keeps the clock on the log honest when nothing else is changing.
        private void tmView_Tick(object sender, EventArgs e)
        {
        }

        #region READ FROM SEQ

        // Called by CThreadMain after it has read the display and the counter.
        // Paints only; touches no shared memory.
        public void RenderFromSeq(bool bDisplayRead, bool bCounterRead)
        {
            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => RenderFromSeq(bDisplayRead, bCounterRead)));
                return;
            }
            if (MmiGV.pShMem == null) return;

            if (bDisplayRead) RenderDisplay(MmiGV.pShMem.RScanTriggerDisplay);
            if (bCounterRead) RenderCounter(MmiGV.pShMem.RScanTriggerCounter);
            if (!bDisplayRead && !bCounterRead)
            {
                lblCounterResult.Text = "No answer from SEQ.";
            }
            pnlGeometryView.Invalidate();
        }

        private void RenderDisplay(SharedMemDll.SCANTRIGGER_DISPLAY d)
        {
            lblMode.Text = (d.nTriggerMode == 1) ? "TIMER" : "PERIODIC";
            lblLineRate.Text = (d.dLineRate / 1000.0).ToString("F3");
            lblLines.Text = d.nLineCount.ToString("N0");
            lblScanTime.Text = d.dScanTime.ToString("F2");
            lblPitchCounts.Text = d.dPitchCounts.ToString("F2") + (d.bPitchIsInteger ? "" : "  !");
            lblValidate.Text = ValidateText(d.nValidateCode);
            lblValidate.ForeColor = (d.nValidateCode == 0) ? HmiTheme.Normal : HmiTheme.Alarm;

            PaintCycleState(d.nState);

            if (d.nState != nLastState && nLastState >= 0)
            {
                AddLog("state " + StateText(nLastState) + " -> " + StateText(d.nState));
            }
            if (d.nValidateCode != nLastValidate && nLastValidate >= 0)
            {
                AddLog("validate " + ValidateText(d.nValidateCode));
            }
            nLastState = d.nState;
            nLastValidate = d.nValidateCode;
        }

        private void RenderCounter(SharedMemDll.SCANTRIGGER_COUNTER c)
        {
            if (!c.bRead)
            {
                lblEncPos.Text = "-";
                lblEncCount.Text = "-";
                lblCounterResult.Text = "The board did not answer the position read.";
            }
            else
            {
                lblEncPos.Text = c.dEncPosMM.ToString("F4");
                lblEncCount.Text = c.dEncCount.ToString("F0");
            }

            int nLines = (MmiGV.pShMem != null) ? MmiGV.pShMem.RScanTriggerDisplay.nLineCount : 0;
            if (c.nTriggerCount < 0)
            {
                lblTrigCount.Text = "n/a";
                pnlProgressFill.Width = 0;
                lblProgress.Text = "-";
            }
            else
            {
                lblTrigCount.Text = c.nTriggerCount.ToString("N0")
                                  + (nLines > 0 ? " / " + nLines.ToString("N0") : "");
                int nPermille = (nLines > 0) ? (int)Math.Min(1000L, (long)c.nTriggerCount * 1000L / nLines) : 0;
                pnlProgressFill.Width = pnlProgressTrack.Width * Math.Max(0, Math.Min(1000, nPermille)) / 1000;
                lblProgress.Text = (nPermille / 10.0).ToString("F1") + " %";
            }

            lblOutput.Text = (c.nOutput < 0) ? "unknown" : (c.nOutput == 1 ? "HIGH" : "low");
            lblOutput.ForeColor = (c.nOutput == 1) ? HmiTheme.Normal : HmiTheme.Text;
            lblArmCount.Text = c.dArmCount.ToString("F0");
            lblBlock.Text = c.dBlockLowerCnt.ToString("F0") + "  ->  " + c.dBlockUpperCnt.ToString("F0");

            // Running backwards from the arm point is what aborts a scan. Show
            // how far, against the limit the settings give, so an abort can be
            // seen coming rather than read about afterwards.
            double dBehind = c.bRead ? Math.Max(0.0, c.dArmCount - c.dEncCount) : 0.0;
            double dLimit;
            double.TryParse(txtWrongWay.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out dLimit);
            lblWrongWay.Text = dBehind.ToString("F0") + " / " + dLimit.ToString("F0");
            lblWrongWay.ForeColor = (dLimit > 0 && dBehind > dLimit * 0.5) ? HmiTheme.Warning : HmiTheme.Text;

            m_dEncPosMM = c.bRead ? c.dEncPosMM : double.NaN;
        }

        // Called when several reads in a row have failed.
        public void LinkLost()
        {
            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(LinkLost));
                return;
            }
            lblCounterResult.Text = "POLL LOST - SEQ stopped answering.";
            m_dEncPosMM = double.NaN;
            pnlGeometryView.Invalidate();
        }

        private void PaintCycleState(int nState)
        {
            foreach (Control c in pnlCycle.Controls)
            {
                Label chip = c as Label;
                if (chip == null || chip.Tag == null) continue;
                int nNo;
                if (!int.TryParse(chip.Tag.ToString(), out nNo)) continue;

                bool bOn = (nNo == nState);
                Color on = (nNo == 8) ? HmiTheme.Alarm : (nNo == 7 ? HmiTheme.Normal : HmiTheme.Accent);
                chip.BackColor = bOn ? on : HmiTheme.Control;
                chip.ForeColor = bOn ? Color.White : HmiTheme.TextMuted;
            }
        }

        private static string StateText(int nState)
        {
            switch (nState)
            {
                case 0: return "IDLE";
                case 1: return "GOTO START";
                case 2: return "WAIT START";
                case 3: return "ARM";
                case 4: return "RUN";
                case 5: return "WAIT END";
                case 6: return "DISARM";
                case 7: return "DONE";
                case 8: return "ABORTED";
                case 9: return "OUTPUT TEST";
                case 10: return "RETURN";
                case 11: return "WAIT RETURN";
                default: return nState.ToString();
            }
        }

        // SCANTRIGGER_VALIDATE in SharedMemBase.h.
        private static string ValidateText(int nCode)
        {
            switch (nCode)
            {
                case 0:  return "OK";
                case 1:  return "AXIS";
                case 2:  return "RANGE";
                case 3:  return "PITCH";
                case 4:  return "SPEED";
                case 5:  return "PITCH FRAC";
                case 6:  return "SPEED MAX";
                case 7:  return "LINE COUNT";
                case 8:  return "NO COUNTER";
                case 9:  return "PULSE RATE";
                case 10: return "NOT HOMED";
                case 11: return "PULSE W";
                case 12: return "IDX 50-53";
                case 13: return "LINE RATE";
                case 14: return "AXIS MOVING";
                default: return nCode.ToString();
            }
        }

        #endregion READ FROM SEQ

        #region SCAN GEOMETRY

        private double m_dEncPosMM = double.NaN;

        // Indices 50..53 to scale along the axis, the trigger block shaded,
        // and the encoder where the board says it is. Positions come from the
        // motor table, which is what SEQ judges the recipe against.
        private void pnlGeometryView_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle area = pnlGeometryView.ClientRectangle;

            double[] adPos = ScanPositionsMM();
            if (adPos == null)
            {
                TextRenderer.DrawText(g, "Motor index 50 - 53 are not loaded.", HmiTheme.FontBody, area,
                    HmiTheme.TextMuted, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }

            double dMin = adPos[0], dMax = adPos[3];
            if (!double.IsNaN(m_dEncPosMM))
            {
                dMin = Math.Min(dMin, m_dEncPosMM);
                dMax = Math.Max(dMax, m_dEncPosMM);
            }
            if (dMax - dMin < 1e-6) dMax = dMin + 1.0;

            int left = 40, right = area.Width - 40;
            int axisY = area.Height / 2 + 10;
            Func<double, float> X = mm => (float)(left + (mm - dMin) / (dMax - dMin) * (right - left));

            using (SolidBrush block = new SolidBrush(Color.FromArgb(60, HmiTheme.Accent)))
            using (Pen blockEdge = new Pen(HmiTheme.Accent, 2))
            {
                RectangleF r = new RectangleF(X(adPos[1]), axisY - 22, X(adPos[2]) - X(adPos[1]), 44);
                g.FillRectangle(block, r);
                g.DrawRectangle(blockEdge, r.X, r.Y, r.Width, r.Height);
            }
            using (Pen axis = new Pen(HmiTheme.TextMuted, 2))
            {
                g.DrawLine(axis, left - 20, axisY, right + 20, axisY);
            }

            string[] names = { "50 Scan Start", "51 Trig Start", "52 Trig End", "53 Scan End" };
            for (int i = 0; i < 4; i++)
            {
                float x = X(adPos[i]);
                bool bBlock = (i == 1 || i == 2);
                using (Pen tick = new Pen(bBlock ? HmiTheme.Accent : HmiTheme.TextMuted, 2))
                {
                    g.DrawLine(tick, x, axisY - 30, x, axisY + 30);
                }
                bool bAbove = (i % 2 == 1);
                Rectangle tr = new Rectangle((int)x - 80, bAbove ? axisY - 74 : axisY + 34, 160, 40);
                TextRenderer.DrawText(g, names[i] + "\n" + adPos[i].ToString("F3"), HmiTheme.FontSmall, tr,
                    bBlock ? HmiTheme.Text : HmiTheme.TextMuted,
                    TextFormatFlags.HorizontalCenter | (bAbove ? TextFormatFlags.Bottom : TextFormatFlags.Top));
            }

            if (!double.IsNaN(m_dEncPosMM))
            {
                float x = X(m_dEncPosMM);
                using (SolidBrush mark = new SolidBrush(HmiTheme.Alarm))
                using (Pen line = new Pen(HmiTheme.Alarm, 2))
                {
                    g.DrawLine(line, x, axisY - 26, x, axisY + 26);
                    g.FillPolygon(mark, new[] { new PointF(x - 7, axisY - 38), new PointF(x + 7, axisY - 38), new PointF(x, axisY - 26) });
                }
            }
        }

        private static double[] ScanPositionsMM()
        {
            if (MmiGV.mtSettingData == null) return null;
            double[] adPos = MmiGV.mtSettingData[0].dPosArray;
            if (adPos == null || adPos.Length <= 53) return null;
            return new[] { adPos[50], adPos[51], adPos[52], adPos[53] };
        }

        #endregion SCAN GEOMETRY

        #region CYCLE BUTTONS

        private void btnOutputTest_Click(object sender, EventArgs e)
        {
            bool bSent = Retry(() => MmiGV.pShMem.SetScanTriggerTest());
            AddLog(bSent ? "OUTPUT TEST sent" : "OUTPUT TEST - NO LINK");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bool bSent = Retry(() => MmiGV.pShMem.SetScanTriggerStop());
            AddLog(bSent ? "STOP sent" : "STOP - NO LINK");
        }

        private void btnOpenRecipe_Click(object sender, EventArgs e)
        {
            frmMain.ShowScreen((int)MmiGV.eSCRNO.AUTO1, true);
        }

        #endregion CYCLE BUTTONS

        #region COUNTER BUTTONS

        private void btnTrigCountClear_Click(object sender, EventArgs e)
        {
            SendCntClr(CntClrTriggerCount, "TRIGGER COUNT CLEAR");
        }

        private void btnEncToAxis_Click(object sender, EventArgs e)
        {
            SendCntClr(CntClrEncToAxis, "ENCODER = AXIS POSITION");
        }

        private void SendCntClr(int nMode, string strWhat)
        {
            if (MmiGV.pShMem == null)
            {
                lblCounterResult.Text = strWhat + " - NO LINK";
                return;
            }
            bool bSent = Retry(() => MmiGV.pShMem.SetScanTriggerCntClr(nMode));
            string strResult = !bSent ? "NO LINK" : ResultText(MmiGV.pShMem.nScanTriggerCntClrResult);
            lblCounterResult.Text = strWhat + " - " + strResult;
            AddLog(strWhat + " - " + strResult);
        }

        #endregion COUNTER BUTTONS

        #region COUNTER H/W CONFIG

        // The values SEQ was commissioned with; SCANTRIGGER_DEFAULT_* in
        // SEQ04_ScanTrigger.cpp. DEFAULTS fills the boxes with these and WRITE
        // still has to be pressed.
        private static SharedMemDll.SCANTRIGGER_HWCFG DefaultHwCfg()
        {
            SharedMemDll.SCANTRIGGER_HWCFG c = new SharedMemDll.SCANTRIGGER_HWCFG();
            c.nChannel = 0;
            c.uEncoderInput = 0;
            c.uOutPortMask = 0x1;
            c.dEncUnitMM = 0.001;
            c.bEncReverse = true;
            c.uTriggerLevel = 1;
            c.uDirectionCheck = 1;
            c.dWrongWayCounts = 200.0;
            return c;
        }

        private void FillHwCfg(SharedMemDll.SCANTRIGGER_HWCFG c)
        {
            bFillingHwCfg = true;
            try
            {
                cbChannel.SelectedIndex = Clamp(c.nChannel, 0, cbChannel.Items.Count - 1);
                cbEncInput.SelectedIndex = Clamp((int)c.uEncoderInput, 0, cbEncInput.Items.Count - 1);
                cbLevel.SelectedIndex = Clamp((int)c.uTriggerLevel, 0, cbLevel.Items.Count - 1);
                cbDirection.SelectedIndex = Clamp((int)c.uDirectionCheck, 0, cbDirection.Items.Count - 1);
                chkOut0.Checked = (c.uOutPortMask & 0x1) != 0;
                chkOut1.Checked = (c.uOutPortMask & 0x2) != 0;
                chkOut2.Checked = (c.uOutPortMask & 0x4) != 0;
                chkOut3.Checked = (c.uOutPortMask & 0x8) != 0;
                txtEncUnit.Text = c.dEncUnitMM.ToString("0.######", CultureInfo.InvariantCulture);
                chkEncReverse.Checked = c.bEncReverse;
                txtWrongWay.Text = c.dWrongWayCounts.ToString("0", CultureInfo.InvariantCulture);
            }
            finally
            {
                bFillingHwCfg = false;
            }
        }

        // Null when a box will not parse; the message says which.
        private SharedMemDll.SCANTRIGGER_HWCFG ReadHwCfgBoxes(out string strBad)
        {
            strBad = null;
            SharedMemDll.SCANTRIGGER_HWCFG c = new SharedMemDll.SCANTRIGGER_HWCFG();
            c.nChannel = cbChannel.SelectedIndex;
            c.uEncoderInput = (uint)Math.Max(0, cbEncInput.SelectedIndex);
            c.uTriggerLevel = (uint)Math.Max(0, cbLevel.SelectedIndex);
            c.uDirectionCheck = (uint)Math.Max(0, cbDirection.SelectedIndex);
            c.uOutPortMask = (chkOut0.Checked ? 0x1u : 0u) | (chkOut1.Checked ? 0x2u : 0u)
                           | (chkOut2.Checked ? 0x4u : 0u) | (chkOut3.Checked ? 0x8u : 0u);
            c.bEncReverse = chkEncReverse.Checked;

            if (!double.TryParse(txtEncUnit.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out c.dEncUnitMM)
                || c.dEncUnitMM <= 0.0)
            {
                strBad = "Unit per count has to be a number above zero.";
                return null;
            }
            if (!double.TryParse(txtWrongWay.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out c.dWrongWayCounts)
                || c.dWrongWayCounts < 0.0)
            {
                strBad = "Wrong way limit has to be zero or more counts.";
                return null;
            }
            if (c.uOutPortMask == 0)
            {
                strBad = "Pick at least one trigger output.";
                return null;
            }
            return c;
        }

        private void HwCfgInput_Changed(object sender, EventArgs e)
        {
            if (bFillingHwCfg) return;
            lblHwCfgResult.ForeColor = HmiTheme.Warning;
            lblHwCfgResult.Text = "Changed here - WRITE to send it to SEQ.";
        }

        private void btnHwRead_Click(object sender, EventArgs e)
        {
            if (MmiGV.pShMem == null || !Retry(() => MmiGV.pShMem.GetScanTriggerHwCfg()))
            {
                ShowHwCfgResult("NO LINK", false);
                return;
            }
            FillHwCfg(MmiGV.pShMem.RScanTriggerHwCfg);
            ShowHwCfgResult("Showing what SEQ is using.", true);
            AddLog("READ settings: " + Describe(MmiGV.pShMem.RScanTriggerHwCfg));
        }

        // Sends the boxes, then checks SEQ's answer against them: a write that
        // came back with different values did not land, whatever the round
        // trip said.
        private void btnHwWrite_Click(object sender, EventArgs e)
        {
            string strBad;
            SharedMemDll.SCANTRIGGER_HWCFG c = ReadHwCfgBoxes(out strBad);
            if (c == null)
            {
                ShowHwCfgResult(strBad, false);
                return;
            }

            string strMsg = "Write these counter settings to SEQ?\n\n" + Describe(c)
                          + "\n\nThey change how every scan counts and triggers.";
            if (MessageBox.Show(strMsg, "SCAN TRIGGER", MessageBoxButtons.OKCancel,
                                MessageBoxIcon.Warning) != DialogResult.OK)
            {
                return;
            }

            int nResult;
            if (!WriteHwCfg(c, out nResult))
            {
                ShowHwCfgResult(nResult < 0 ? "NO LINK" : "SET FAILED - SEQ holds different values", false);
                AddLog("WRITE settings - " + (nResult < 0 ? "NO LINK" : "SET FAILED"));
                return;
            }
            if (nResult != HwCfgOk)
            {
                FillHwCfg(MmiGV.pShMem.RScanTriggerHwCfg);
                ShowHwCfgResult("Refused: " + ResultText(nResult) + ". Showing what SEQ kept.", false);
                AddLog("WRITE settings refused: " + ResultText(nResult));
                return;
            }

            SaveHwCfg(c);
            ShowHwCfgResult("Written and confirmed. SET the recipe again before the next scan.", true);
            AddLog("WRITE settings: " + Describe(c));
        }

        private void btnHwDefaults_Click(object sender, EventArgs e)
        {
            FillHwCfg(DefaultHwCfg());
            lblHwCfgResult.ForeColor = HmiTheme.Warning;
            lblHwCfgResult.Text = "Commissioned values filled in - WRITE to send them.";
        }

        // nResult is -1 when SEQ never answered. True when SEQ's answer is
        // the settings that were sent (or a refusal, which is in nResult).
        private static bool WriteHwCfg(SharedMemDll.SCANTRIGGER_HWCFG c, out int nResult)
        {
            nResult = -1;
            if (MmiGV.pShMem == null) return false;

            SharedMemDll.SCANTRIGGER_HWCFG w = MmiGV.pShMem.WScanTriggerHwCfg;
            w.nChannel = c.nChannel;
            w.uEncoderInput = c.uEncoderInput;
            w.uOutPortMask = c.uOutPortMask;
            w.dEncUnitMM = c.dEncUnitMM;
            w.bEncReverse = c.bEncReverse;
            w.uTriggerLevel = c.uTriggerLevel;
            w.uDirectionCheck = c.uDirectionCheck;
            w.dWrongWayCounts = c.dWrongWayCounts;

            for (int k = 0; k < ScanTriggerTries; k++)
            {
                if (!MmiGV.pShMem.SetScanTriggerHwCfg()) continue;

                SharedMemDll.SCANTRIGGER_HWCFG r = MmiGV.pShMem.RScanTriggerHwCfg;
                nResult = r.nResult;
                if (nResult != HwCfgOk) return true;
                if (SameHwCfg(r, c)) return true;
            }
            return false;
        }

        private static bool SameHwCfg(SharedMemDll.SCANTRIGGER_HWCFG a, SharedMemDll.SCANTRIGGER_HWCFG b)
        {
            return a.nChannel == b.nChannel
                && a.uEncoderInput == b.uEncoderInput
                && a.uOutPortMask == b.uOutPortMask
                && Math.Abs(a.dEncUnitMM - b.dEncUnitMM) < 1e-9
                && a.bEncReverse == b.bEncReverse
                && a.uTriggerLevel == b.uTriggerLevel
                && a.uDirectionCheck == b.uDirectionCheck
                && Math.Abs(a.dWrongWayCounts - b.dWrongWayCounts) < 0.5;
        }

        private void ShowHwCfgResult(string strText, bool bGood)
        {
            lblHwCfgResult.ForeColor = bGood ? HmiTheme.Normal : HmiTheme.Alarm;
            lblHwCfgResult.Text = strText;
        }

        private static string Describe(SharedMemDll.SCANTRIGGER_HWCFG c)
        {
            return string.Format(CultureInfo.InvariantCulture,
                "CH {0}, ENC {1}, OUT 0x{2:X}, {3:0.######} mm/count, {4}, level {5}, {6}, wrong way {7:0}",
                c.nChannel, c.uEncoderInput, c.uOutPortMask, c.dEncUnitMM,
                c.bEncReverse ? "reversed" : "normal", c.uTriggerLevel == 1 ? "HIGH" : "LOW",
                c.uDirectionCheck == 0 ? "both" : (c.uDirectionCheck == 1 ? "up only" : "down only"),
                c.dWrongWayCounts);
        }

        private static string ResultText(int nResult)
        {
            switch (nResult)
            {
                case HwCfgOk:    return "OK";
                case HwCfgBusy:  return "BUSY (a scan or output test is running)";
                case HwCfgRange: return "OUT OF RANGE";
                default:         return nResult.ToString();
            }
        }

        #endregion COUNTER H/W CONFIG

        #region SAVED SETTINGS

        // The settings live in MachineConfig.ini once a write has been
        // confirmed. SEQ does not keep them - it starts on its commissioned
        // values - so SendSavedHwCfgToSeq() puts them back each time SEQ is
        // initialised.
        private static SharedMemDll.SCANTRIGGER_HWCFG LoadSavedHwCfg()
        {
            CIniHelper ini = new CIniHelper("MachineConfig.ini");
            if (!ini.KeyExists("CHANNEL", IniSection)) return null;

            SharedMemDll.SCANTRIGGER_HWCFG c = DefaultHwCfg();
            c.nChannel = ini.ReadInteger("CHANNEL", IniSection);
            c.uEncoderInput = (uint)Math.Max(0, ini.ReadInteger("ENCODER INPUT", IniSection));
            c.uOutPortMask = (uint)Math.Max(0, ini.ReadInteger("OUTPORT MASK", IniSection));
            c.bEncReverse = ini.ReadInteger("ENCODER REVERSE", IniSection) != 0;
            c.uTriggerLevel = (uint)Math.Max(0, ini.ReadInteger("TRIGGER LEVEL", IniSection));
            c.uDirectionCheck = (uint)Math.Max(0, ini.ReadInteger("DIRECTION CHECK", IniSection));
            double d;
            if (double.TryParse(ini.ReadString("UNIT MM", IniSection), NumberStyles.Float, CultureInfo.InvariantCulture, out d))
                c.dEncUnitMM = d;
            if (double.TryParse(ini.ReadString("WRONG WAY COUNTS", IniSection), NumberStyles.Float, CultureInfo.InvariantCulture, out d))
                c.dWrongWayCounts = d;
            return c;
        }

        private static void SaveHwCfg(SharedMemDll.SCANTRIGGER_HWCFG c)
        {
            CIniHelper ini = new CIniHelper("MachineConfig.ini");
            ini.WriteInteger("CHANNEL", c.nChannel, IniSection);
            ini.WriteInteger("ENCODER INPUT", (int)c.uEncoderInput, IniSection);
            ini.WriteInteger("OUTPORT MASK", (int)c.uOutPortMask, IniSection);
            ini.WriteString("UNIT MM", c.dEncUnitMM.ToString("R", CultureInfo.InvariantCulture), IniSection);
            ini.WriteInteger("ENCODER REVERSE", c.bEncReverse ? 1 : 0, IniSection);
            ini.WriteInteger("TRIGGER LEVEL", (int)c.uTriggerLevel, IniSection);
            ini.WriteInteger("DIRECTION CHECK", (int)c.uDirectionCheck, IniSection);
            ini.WriteString("WRONG WAY COUNTS", c.dWrongWayCounts.ToString("R", CultureInfo.InvariantCulture), IniSection);
        }

        // Called from system initialisation. A machine that never had its
        // settings changed has nothing saved and runs on SEQ's own values.
        public static void SendSavedHwCfgToSeq()
        {
            SharedMemDll.SCANTRIGGER_HWCFG c = LoadSavedHwCfg();
            if (c == null) return;

            int nResult;
            bool bOk = WriteHwCfg(c, out nResult);
            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            MMILog.AddMMILog("Scan trigger settings sent to SEQ: "
                + (bOk && nResult == HwCfgOk ? "confirmed" : (nResult < 0 ? "no answer" : "refused " + nResult)));
        }

        #endregion SAVED SETTINGS

        #region LOG

        private void AddLog(string strText)
        {
            string strLine = DateTime.Now.ToString("HH:mm:ss") + "  " + strText;
            lstLog.Items.Insert(0, strLine);
            while (lstLog.Items.Count > 500) lstLog.Items.RemoveAt(lstLog.Items.Count - 1);

            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            MMILog.AddMMILog("[SCAN TRIGGER] " + strText);
        }

        private void btnLogClear_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
        }

        #endregion LOG

        private static bool Retry(Func<bool> send)
        {
            if (MmiGV.pShMem == null) return false;
            for (int k = 0; k < ScanTriggerTries; k++)
            {
                if (send()) return true;
            }
            return false;
        }

        private static int Clamp(int v, int lo, int hi)
        {
            return Math.Max(lo, Math.Min(hi, v));
        }
    }
}
