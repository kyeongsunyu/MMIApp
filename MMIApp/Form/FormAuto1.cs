using Mapping;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace MMI
{
    public enum eMapState : int
    {
        EMPTY = 0,
        EXIST = 1,
    }
    public enum eMapTarget : int
    {
        FLIPY1 = 0,
        FLIPY2,
        PALLETY1,
        PALLETY2,
        GOOD_TRAY1,
        GOOD_TRAY2,
        REWORK_TRAY,
        NG_TRAY,
    };

    public enum MapState : int
    {
        EMPTY = 0,
        EXIST = 1,
        GOOD = 2,
        REWORK = 3,
        NG = 4,
    }
    

    public partial class FormAuto1 : Form
    {
        private FormMain frmMain = null;

        public readonly Stopwatch swRun = new Stopwatch();
        public readonly Stopwatch swStop = new Stopwatch();

        public TimeSpan tsRun = new TimeSpan();
        public TimeSpan tsStop = new TimeSpan();


        //
        //

        public FormAuto1()
        {
            InitializeComponent();
        }
        public FormAuto1(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            swRun.Reset();
            swStop.Reset();
        }
        private void FormAuto1_Shown(object sender, EventArgs e)
        {
            lblTargetUPH.Text = MmiGV.iTragetUPH.ToString();
        }

        private void btnInit_Click(object sender, EventArgs e)
        {

            if (!MmiGV.bFormHomeShow)
            {
                MmiGV.bFormHomeShow = true;
                Form_Home frm_Home = new Form_Home();

                frm_Home.TopMost = true;
                frm_Home.TopLevel = true;

                frm_Home.Show();
            }
        }

        private void spTabLaser_DoubleClick(object sender, EventArgs e)
        {
            MmiGV.frmMain.frm_Laser.CheckDocking();
        }

        private void btnLOTInput_Click(object sender, EventArgs e)
        {
            if (MmiGV.frmMain.frm_LotInput.Display())
            {
                lblLotID.Text = MmiGV.LotInfo.strLotID;
                lblLotCount.Text = MmiGV.LotInfo.LotCnt.ToString();

                //SeqGV.LotInfo = MmiGV.LotInfo;
                MmiGV.pShMem.WLotInfo.strLotID = MmiGV.LotInfo.strLotID;
                MmiGV.pShMem.WLotInfo.nLotCount = MmiGV.LotInfo.LotCnt;
                MmiGV.pShMem.SetLotInfo();

            }
        }

        private void tmRun_Tick(object sender, EventArgs e)
        {
            if (DateTime.Now.ToString("HHmmss") == "000000")
            {
                swRun.Reset();
                swStop.Reset();
            }

            if (swRun.IsRunning)
            {
                tsRun = swRun.Elapsed;
                lblRunningTime.Text = $"{tsRun.Hours:D2}:{tsRun.Minutes:D2}:{tsRun.Seconds:D2}";
            }
            if (swStop.IsRunning)
            {
                tsStop = swStop.Elapsed;
                lblStopTime.Text = $"{tsStop.Hours:D2}:{tsStop.Minutes:D2}:{tsStop.Seconds:D2}";
            }

        }

        private void btnTargetUPH_Click(object sender, EventArgs e)
        {
            CIniHelper iniHelper = new CIniHelper("MachineConfig.ini");

            if (frmMain.frm_NumPad.Display())
            {
                int uData = (int)frmMain.frm_NumPad.GetValue();
                if (uData >= 1)
                {
                    lblTargetUPH.Text = uData.ToString();
                    MmiGV.iTragetUPH = uData;
                    iniHelper.WriteInteger("TARGET UPH", uData, "UPH");
                }
                else
                {
                    MmiGV.frmMain.frm_Msg.ShowMessage("You shold input 0 over.");
                }
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {


        }

        private void btnSeqOperation(object sender, EventArgs e)
        {
            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog != null);

            DevComponents.DotNetBar.ButtonX p_Button = sender as DevComponents.DotNetBar.ButtonX;

            uint tag = Convert.ToUInt32(p_Button.Tag);
            if (MmiGV.pShMem.GetDM(2) == 0)
            {
                MmiGV.pShMem.SetDM(2, tag);
                MMILog.AddMMILog(p_Button.Text + " Clicked");
            }
        }

        #region SCAN TRIGGER

        // The panel takes the four recipe numbers and hands them to SEQ, which
        // owns every derived value. Nothing here recomputes a speed or a line
        // count: SEQ works them out from the recipe and reports them back, and a
        // second answer computed here could only disagree with the one the
        // machine actually runs.
        //
        // The five inputs are typed straight into their text boxes. Editing any
        // of them drops the computed rows, which are stale the moment an input
        // moves, and takes START away again until the recipe is re-sent.
        //
        // Speed is entered and the line rate is computed, not the other way
        // round: speed is what the machine is commanded to do and what the tact
        // time is argued about in, while the line rate is what falls out of it
        // and the pitch. The camera is then set from a number nobody had to
        // work out by hand.

        // The axis the trigger runs on. Single scan axis for now; when a second
        // one appears this becomes a selection rather than a constant.
        private const uint ScanTriggerAxis = 0;

        // CThreadMain runs about nineteen MemPort round trips per pass and holds
        // the comm mutex almost continuously. MemPort gives up after waiting a
        // second for it, so one attempt from a button press can come back empty
        // while SEQ is answering perfectly well. Try a few times before calling
        // it a dead link.
        private const int ScanTriggerTries = 3;

        // Mirrors SCANTRIGGER_PULSE_MAX_DUTY and SCANTRIGGER_PULSE_MIN_US in
        // SEQ04_ScanTrigger.cpp. SEQ owns the decision; this side only explains
        // it, so if the two ever drift the result is a wrong explanation rather
        // than a wrong refusal.
        private const double ScanTriggerPulseMaxDuty = 0.4;
        private const double ScanTriggerPulseMinUs   = 1.0;

        // The scan geometry lives in the motor index table, not here: the motor
        // screen names and edits these four, and 50 and above are MOTOR_COMMON
        // rows, so they belong to the machine rather than to one device. SET
        // writes the scan speed into them and reads the positions back from SEQ.
        //
        //   50 SCAN START / 51 SCAN TRIGGER START / 52 SCAN TRIGGER END / 53 SCAN END
        private const int ScanTriggerIdxFirst = 50;
        private const int ScanTriggerIdxLast  = 53;

        // Set while a recipe has been accepted or a cycle is running. Read by
        // CThreadMain, which does the polling: every other shared memory read in
        // this program goes through that thread, and MemPort takes a mutex the
        // thread holds almost continuously, so a UI timer asking for the same
        // mutex loses the race most of the time and reports a link that is fine
        // as broken.
        public volatile bool bScanTriggerWatch = false;

        // MainRecipeLoad runs on the recipe loading thread and CThreadMain runs on
        // its own, but WinForms only lets the thread that created a control touch
        // it. Guard the entry points rather than trusting every caller to marshal:
        // one that forgot took the program down during start-up, on the first
        // label this panel writes.
        //
        // Before the handle exists there is no cross-thread rule to break and
        // BeginInvoke would throw, so in that case the caller carries on and
        // writes the controls directly.
        private bool ScanTriggerToUiThread(MethodInvoker work)
        {
            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(work);
                return true;
            }
            return false;
        }

        // Called once the recipe is in memory - at start from MainRecipeLoad, and
        // again whenever the device changes. Fills the panel only; it does not
        // send anything to SEQ. SET stays a deliberate act, so the operator sees
        // the verdict against the machine as it is right now rather than having
        // a recipe pushed in behind them at start-up.
        public void LoadScanTriggerFromRecipe()
        {
            if (ScanTriggerToUiThread(LoadScanTriggerFromRecipe)) return;

            CRcpMaterial rcp = CRecipeCtl.CurMaterialRcp;
            if (rcp == null) return;

            txtScanTrigPitch.Text = rcp.ScanPixelRes.ToString("F2");
            txtScanTrigSpeed.Text = rcp.ScanSpeed.ToString("F2");
            txtScanTrigPulse.Text = rcp.ScanPulseWidth.ToString("F2");

            // Setting the text fires TextChanged, which does this too. Doing it
            // here as well keeps the state right without depending on that.
            bScanTriggerWatch = false;
            btnScanTrigStart.Enabled = false;
            ClearScanTriggerDisplay();
            lblScanTrigResult.Text = "-";
        }

        private void ScanTriggerInput_TextChanged(object sender, EventArgs e)
        {
            bScanTriggerWatch = false;
            btnScanTrigStart.Enabled = false;
            ClearScanTriggerDisplay();
            lblScanTrigResult.Text = "-";
        }

        private bool TryReadScanTriggerRecipe(out double dPitch, out double dSpeed,
                                              out double dPulseUs)
        {
            dPitch = dSpeed = dPulseUs = 0.0;

            if (!double.TryParse(txtScanTrigPitch.Text, out dPitch))   return false;
            if (!double.TryParse(txtScanTrigSpeed.Text, out dSpeed))   return false;
            if (!double.TryParse(txtScanTrigPulse.Text, out dPulseUs)) return false;

            return true;
        }

        // The scan speed, into motor index table entries 50..53, so the motor
        // screen shows what the scan will actually run at and the operator can
        // see it next to the positions it belongs with.
        //
        // CMD_WRITE_MOTORDATA replaces the whole hundred entry array, so sending
        // this side's own copy would overwrite anything SEQ holds that this copy
        // does not know about. Read SEQ's array back first and change only the
        // four, which is the difference between writing four numbers and
        // rewriting the table.
        private bool WriteScanSpeedToMotorTable(double dSpeedMmS)
        {
            int nAxis = (int)ScanTriggerAxis;
            if (MmiGV.pShMem == null) return false;
            if (!MmiGV.pShMem.GetMotorData(nAxis)) return false;

            double dRate  = MmiGV.mtConfigData[nAxis].uPulseRate;
            double dPulses = dSpeedMmS * dRate;

            for (int i = 0; i < 100; i++)
            {
                MmiGV.pShMem.WMotorData.uPos[i] = MmiGV.pShMem.RMotorData[nAxis].uPos[i];
                MmiGV.pShMem.WMotorData.uVel[i] = MmiGV.pShMem.RMotorData[nAxis].uVel[i];
            }
            for (int i = ScanTriggerIdxFirst; i <= ScanTriggerIdxLast; i++)
            {
                MmiGV.pShMem.WMotorData.uVel[i] = dPulses;

                // The motor screen reads these, and SaveMotorSettingData writes
                // them to MOTOR_COMMON, so keep all three copies in step.
                MmiGV.mtSettingData[nAxis].dSpeedArray[i] = dSpeedMmS;
                MmiGV.mtData[nAxis].iSpeedArray[i]        = dPulses;
            }

            MmiGV.pShMem.WMotorData.uAxisNo = nAxis;
            if (!MmiGV.pShMem.SetMotorData()) return false;

            // MOTOR_COMMON row i holds array entry i + 50.
            for (int i = ScanTriggerIdxFirst; i <= ScanTriggerIdxLast; i++)
            {
                // InvariantCulture: a locale with a comma decimal separator
                // writes "198,9" and SQLite rejects the statement in silence.
                string strSQL = "UPDATE MOTOR_COMMON SET SPD"
                              + string.Format("{0:D2}", nAxis + 1) + "="
                              + "'" + dSpeedMmS.ToString(CultureInfo.InvariantCulture) + "'"
                              + " WHERE IDX=" + (i - 50).ToString(CultureInfo.InvariantCulture);
                SQLiteDB.Execute(strSQL);
            }
            return true;
        }

        // Everything SEQ owns. The result row is not touched here: it carries the
        // outcome of the last action and the caller writes it straight after.
        private void ClearScanTriggerDisplay()
        {
            txtScanTrigStart.Text       = "-";
            txtScanTrigEnd.Text         = "-";
            lblScanTrigRate.Text        = "-";
            lblScanTrigLines.Text       = "-";
            lblScanTrigTime.Text        = "-";
            lblScanTrigMotionStart.Text = "-";
            lblScanTrigMotionEnd.Text   = "-";
            lblScanTrigCounts.Text      = "-";
            lblScanTrigState.Text       = "-";
        }

        // The panel reads mm, mm, um, mm/s and us because that is how the
        // operator thinks about a scan. Pixel Res is the along-scan resolution -
        // one line per that much travel - and it has to match the cross-scan
        // resolution or the image comes out stretched. The pulse width is
        // whatever the camera datasheet asks for. The shared memory recipe is mm
        // and mm/s throughout, with the pulse width left in us.
        private bool SendScanTriggerRecipe(double dPitchUm, double dSpeed,
                                           double dPulseUs)
        {
            MmiGV.pShMem.WScanTriggerRecipe.uAxisNo       = ScanTriggerAxis;
            MmiGV.pShMem.WScanTriggerRecipe.dPitch        = dPitchUm / 1000.0;
            MmiGV.pShMem.WScanTriggerRecipe.dSpeed        = dSpeed;
            MmiGV.pShMem.WScanTriggerRecipe.dPulseWidthUS = dPulseUs;

            // Reserved in the struct and unused until an approach profile exists.
            MmiGV.pShMem.WScanTriggerRecipe.dAccel     = 0.0;
            MmiGV.pShMem.WScanTriggerRecipe.dDecel     = 0.0;
            MmiGV.pShMem.WScanTriggerRecipe.nDirection = 0;

            return MmiGV.pShMem.SetScanTriggerRecipe();
        }

        private static string ScanTriggerValidateText(int nCode)
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
                default: return nCode.ToString();
            }
        }

        private static string ScanTriggerStateText(int nState)
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
                case 9: return "OUT TEST";
                default: return nState.ToString();
            }
        }

        // Reads shared memory, so it blocks; only a button press calls it.
        // Returns the validate code, or -1 when the display could not be read.
        private int RefreshScanTriggerDisplay()
        {
            if (MmiGV.pShMem == null) return -1;
            if (!MmiGV.pShMem.GetScanTriggerDisplay()) return -1;

            RenderScanTriggerDisplay();
            return MmiGV.pShMem.RScanTriggerDisplay.nValidateCode;
        }

        // Paints whatever CSharedMemory last read. Touches no shared memory, so
        // the comm thread can drive it through Invoke. UI thread only.
        public void RenderScanTriggerDisplay()
        {
            if (ScanTriggerToUiThread(RenderScanTriggerDisplay)) return;

            if (MmiGV.pShMem == null) return;

            SharedMemDll.SCANTRIGGER_DISPLAY d = MmiGV.pShMem.RScanTriggerDisplay;

            // kHz on screen, Hz on the wire - a 16K scan runs in the tens of
            // thousands and reads better with the exponent taken out.
            lblScanTrigRate.Text = (d.dLineRate / 1000.0).ToString("F3");
            lblScanTrigTime.Text = d.dScanTime.ToString("F2");
            lblScanTrigState.Text = ScanTriggerStateText(d.nState);

            // All four come from the motor index table, so they are shown, not
            // typed. Motion is 50..53 and the trigger block 51..52, which is the
            // run-up and run-out that keep the ramps out of the block.
            txtScanTrigStart.Text = d.dTrigStart.ToString("F3");
            txtScanTrigEnd.Text   = d.dTrigEnd.ToString("F3");
            lblScanTrigMotionStart.Text = d.dMotionStart.ToString("F3");
            lblScanTrigMotionEnd.Text   = d.dMotionEnd.ToString("F3");

            // Before a run there is only the expected count; once the counter has
            // been read back, show what actually came out against it.
            lblScanTrigLines.Text = (d.nTriggerCount >= 0)
                ? d.nTriggerCount.ToString() + " / " + d.nLineCount.ToString()
                : d.nLineCount.ToString();

            // A pitch that is not a whole number of encoder counts is the one
            // thing the operator can fix by changing a number, so mark it.
            lblScanTrigCounts.Text = d.dPitchCounts.ToString("F2")
                                   + (d.bPitchIsInteger ? "" : " !");

            // The cycle has settled, so stop following it and leave the last
            // reading on screen.
            if (d.nState == 7 || d.nState == 8)          // DONE, ABORTED
            {
                bScanTriggerWatch = false;
                lblScanTrigResult.Text = (d.nState == 7) ? "DONE" : "ABORTED";
            }
        }

        // Called by the comm thread after several reads in a row have failed.
        public void ScanTriggerLinkLost()
        {
            if (ScanTriggerToUiThread(ScanTriggerLinkLost)) return;

            bScanTriggerWatch = false;
            btnScanTrigStart.Enabled = false;
            lblScanTrigResult.Text = "NO LINK";
        }

        private void btnScanTrigSet_Click(object sender, EventArgs e)
        {
            double dPitch, dSpeed, dPulseUs;

            bScanTriggerWatch = false;
            btnScanTrigStart.Enabled = false;

            if (!TryReadScanTriggerRecipe(out dPitch, out dSpeed, out dPulseUs))
            {
                ClearScanTriggerDisplay();
                lblScanTrigResult.Text = "BAD NUMBER";
                return;
            }

            // Only the checks that need no machine knowledge. Everything else -
            // whether the pitch is a whole number of encoder counts, whether the
            // speed fits the axis, whether the axis is homed - is SEQ's to judge.
            if (dPitch <= 0.0 || dSpeed <= 0.0 || dPulseUs <= 0.0)
            {
                ClearScanTriggerDisplay();
                lblScanTrigResult.Text = "BAD RANGE";
                return;
            }

            // Persist before sending. The refusals SEQ can still raise - not homed,
            // no counter, speed beyond the axis - are machine states, not bad
            // numbers, and the operator should not lose what they typed to one.
            CRecipeCtl.CurMaterialRcp.ScanPixelRes  = dPitch;
            CRecipeCtl.CurMaterialRcp.ScanSpeed     = dSpeed;
            CRecipeCtl.CurMaterialRcp.ScanPulseWidth = dPulseUs;
            CRecipeCtl.CurMaterialRcp.SaveScanTrigger();

            if (MmiGV.pShMem == null)
            {
                ClearScanTriggerDisplay();
                lblScanTrigResult.Text = "NO LINK";
                return;
            }

            // The speed goes into the motor index table before the recipe goes
            // to SEQ, because the positions the recipe is judged against are in
            // that same table and the two should not disagree even briefly.
            if (!WriteScanSpeedToMotorTable(dSpeed))
            {
                ClearScanTriggerDisplay();
                lblScanTrigResult.Text = "NO LINK";
                return;
            }

            // Writing the same recipe twice is harmless, so the whole pair is
            // what gets retried rather than each half separately.
            int nCode = -1;
            for (int k = 0; k < ScanTriggerTries && nCode < 0; k++)
            {
                if (SendScanTriggerRecipe(dPitch, dSpeed, dPulseUs))
                {
                    nCode = RefreshScanTriggerDisplay();
                }
            }

            if (nCode < 0)
            {
                ClearScanTriggerDisplay();
                lblScanTrigResult.Text = "NO LINK";
                return;
            }

            lblScanTrigResult.Text = ScanTriggerValidateText(nCode);

            // "PULSE W" in a 150 pixel cell says which number is wrong and
            // nothing else. The operator can only fix it knowing what it is
            // being measured against, so say so.
            if (nCode == 11) ShowScanTriggerPulseWidthRefusal(dPulseUs);

            // SEQ accepted it, so the cycle can be started and the state row is
            // worth following from here on.
            btnScanTrigStart.Enabled = (nCode == 0);
            bScanTriggerWatch = true;
        }

        private void btnScanTrigStart_Click(object sender, EventArgs e)
        {
            if (MmiGV.pShMem == null)
            {
                lblScanTrigResult.Text = "NO LINK";
                return;
            }

            bool bSent = false;
            for (int k = 0; k < ScanTriggerTries && !bSent; k++)
            {
                bSent = MmiGV.pShMem.SetScanTriggerStart();
            }

            bScanTriggerWatch = bSent;
            lblScanTrigResult.Text = bSent ? "START" : "NO LINK";

            // A second press while the cycle runs only earns a refusal from SEQ
            // and a SEND COMMAND ERROR in its log. SET turns this back on.
            if (bSent) btnScanTrigStart.Enabled = false;
        }

        private void btnScanTrigStop_Click(object sender, EventArgs e)
        {
            if (MmiGV.pShMem == null)
            {
                lblScanTrigResult.Text = "NO LINK";
                return;
            }

            bool bSent = false;
            for (int k = 0; k < ScanTriggerTries && !bSent; k++)
            {
                bSent = MmiGV.pShMem.SetScanTriggerStop();
            }

            bScanTriggerWatch = bSent;
            lblScanTrigResult.Text = bSent ? "STOP" : "NO LINK";
        }

        // SEQ refuses a pulse width under 1 us and one over 40 % of the line
        // period, and reports one code for both. The line period is what decides
        // which, and it came back in the display, so work out which bound was
        // crossed here rather than leaving the operator to.
        private void ShowScanTriggerPulseWidthRefusal(double dPulseUs)
        {
            if (MmiGV.pShMem == null) return;

            double dRateHz = MmiGV.pShMem.RScanTriggerDisplay.dLineRate;
            if (dRateHz <= 0.0) return;

            double dPeriodUs = 1000000.0 / dRateHz;
            double dMaxUs    = dPeriodUs * ScanTriggerPulseMaxDuty;

            string strMsg;
            if (dPulseUs > dMaxUs)
            {
                strMsg = "펄스폭이 듀티 40%를 넘었습니다.\n\n"
                       + "라인 주기 : " + dPeriodUs.ToString("F1") + " us  ("
                       + (dRateHz / 1000.0).ToString("F3") + " kHz)\n"
                       + "허용 최대 : " + dMaxUs.ToString("F1") + " us\n"
                       + "입력 값     : " + dPulseUs.ToString("F2") + " us  (듀티 "
                       + (dPulseUs / dPeriodUs * 100.0).ToString("F0") + " %)";
            }
            else
            {
                strMsg = "펄스폭이 최소값 " + ScanTriggerPulseMinUs.ToString("F0")
                       + " us 보다 좁습니다.\n\n"
                       + "입력 값 : " + dPulseUs.ToString("F2") + " us";
            }

            MessageBox.Show(strMsg, "SCAN TRIGGER",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Commissioning aid. SEQ drives the trigger output pin directly for a
        // few seconds so it can be probed on CON1; nothing moves and no recipe
        // is needed, which is why this does not go through SET first.
        private void btnScanTrigTest_Click(object sender, EventArgs e)
        {
            if (MmiGV.pShMem == null)
            {
                lblScanTrigResult.Text = "NO LINK";
                return;
            }

            bool bSent = false;
            for (int k = 0; k < ScanTriggerTries && !bSent; k++)
            {
                bSent = MmiGV.pShMem.SetScanTriggerTest();
            }

            // Follow it the same way a scan is followed, so the state row shows
            // OUT TEST and the count row counts the pulses as they go out.
            bScanTriggerWatch = bSent;
            lblScanTrigResult.Text = bSent ? "OUT TEST" : "NO LINK";
        }

        #endregion
    }
}
