using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MMI
{
    // The motor part of the TRIGGER screen: the scan axis's state, servo,
    // home and alarm reset along the top, and a jog card, so a scan can be set
    // up and checked without going over to the Motor screen.
    //
    // It drives the axis with the same SEQ commands the Motor screen uses
    // (SetServoOnOff, SetServoHome, SetServoAlarmClear, SetMotorVelocityMove,
    // SetMotorRelativeMove, SetMotorStop). CThreadMain reads the status of
    // nMotorAxis with the rest of this screen and paints it through
    // RenderMotorStatus().
    //
    // Nothing here moves the axis while the machine runs or a scan cycle is
    // under way, and the jog buttons do nothing until JOG ENABLE is on. A
    // continuous jog stops when the button is let go, left, or the screen
    // is closed.
    public partial class FormScanTrigger
    {
        // The axis the scan runs on (FormAuto1.ScanTriggerAxis).
        private const int ScanAxis = 0;

        // Scan cycle states in which the axis is free: IDLE, DONE, ABORTED.
        private static readonly int[] ScanStatesAxisFree = { 0, 7, 8 };

        // cbAxis lists the axes in use; this is the axis behind each item.
        private readonly List<int> axisOfItem = new List<int>();

        // Read by CThreadMain to poll the axis shown here.
        public volatile int nMotorAxis = ScanAxis;

        private bool bJogEnabled = false;
        private bool bJogContinuous = false;   // JOG: move while held; STEP: one step per press
        private bool bJogMoving = false;
        private int iStepTagLast = -1;

        #region SETUP

        private void InitMotor()
        {
            FillAxisList();
            SetJogEnabled(false);
            SetJogMode(false);
            lblStep.Text = "0.00";
            CLanguage.Changed += (s, e) => ShowModeHint();
        }

        // The axes marked in use in MTCFG, as the Motor screen lists them.
        private void FillAxisList()
        {
            cbAxis.Items.Clear();
            axisOfItem.Clear();

            if (SQLiteDB.Select("SELECT * FROM MTCFG", ref SQLiteDB.ReaderMotorCFG))
            {
                for (int iAxis = 0; iAxis < 60 && SQLiteDB.ReaderMotorCFG.Read(); iAxis++)
                {
                    bool bUse = Convert.ToString(SQLiteDB.ReaderMotorCFG["USESKIP"]) == "True";
                    if (!bUse) continue;
                    cbAxis.Items.Add(string.Format("{0:D2} : {1}", iAxis + 1, SQLiteDB.ReaderMotorCFG["ITEM"]));
                    axisOfItem.Add(iAxis);
                }
            }
            if (SQLiteDB.ReaderMotorCFG != null) SQLiteDB.ReaderMotorCFG.Close();

            if (axisOfItem.Count == 0)
            {
                cbAxis.Items.Add(string.Format("{0:D2}", ScanAxis + 1));
                axisOfItem.Add(ScanAxis);
            }
            int nItem = axisOfItem.IndexOf(ScanAxis);
            cbAxis.SelectedIndex = (nItem >= 0) ? nItem : 0;
        }

        private void cbAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopJog();
            int nItem = cbAxis.SelectedIndex;
            if (nItem < 0 || nItem >= axisOfItem.Count) return;
            nMotorAxis = axisOfItem[nItem];
            RenderMotorStatus(false);
        }

        private string AxisText()
        {
            return Convert.ToString(cbAxis.SelectedItem);
        }

        // Closing the screen ends a jog and switches jogging off again.
        private void MotorVisibleChanged()
        {
            if (Visible) return;
            StopJog();
            SetJogEnabled(false);
        }

        #endregion SETUP

        #region STATUS

        // Called by CThreadMain after GetMotorStatus(nMotorAxis).
        public void RenderMotorStatus(bool bRead)
        {
            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => RenderMotorStatus(bRead)));
                return;
            }

            SharedMemDll.MotorStatus st = (MmiGV.pShMem != null) ? MmiGV.pShMem.RMTStatus : null;
            if (!bRead || st == null)
            {
                lblCurIdx.Text = "-";
                lblCurPos.Text = "-";
                lblNextIdx.Text = "-";
                lblNextPos.Text = "-";
                foreach (Label chip in new[] { lblStsMinusLimit, lblStsPlusLimit, lblStsOrg, lblStsHome, lblStsMoving, lblStsAlarm })
                {
                    Chip(chip, false, HmiTheme.Control);
                }
                btnServo.Checked = false;
                return;
            }

            double dRate = PulseRate(nMotorAxis);
            lblCurIdx.Text = st.CurrentIndex.ToString();
            lblCurPos.Text = (st.CurrentPosition / dRate).ToString("0.000");
            lblNextIdx.Text = st.NextIndex.ToString();
            lblNextPos.Text = (st.NextPosition / dRate).ToString("0.000");

            Chip(lblStsMinusLimit, st.CCW, HmiTheme.Alarm);
            Chip(lblStsPlusLimit, st.CW, HmiTheme.Alarm);
            Chip(lblStsOrg, st.Org, HmiTheme.Warning);
            Chip(lblStsHome, st.HOME, HmiTheme.Normal);
            Chip(lblStsMoving, st.Busy, HmiTheme.Accent);
            Chip(lblStsAlarm, st.ALM, HmiTheme.Alarm);
            btnServo.Checked = st.SVON;
        }

        private static void Chip(Label chip, bool bOn, Color on)
        {
            chip.BackColor = bOn ? on : HmiTheme.Control;
            chip.ForeColor = bOn ? Color.White : HmiTheme.TextMuted;
        }

        private static double PulseRate(int nAxis)
        {
            if (nAxis < 0 || nAxis >= MmiGV.mtConfigData.Length) return 1.0;
            uint uRate = MmiGV.mtConfigData[nAxis].uPulseRate;
            return (uRate == 0) ? 1.0 : uRate;
        }

        #endregion STATUS

        #region SERVO / HOME / ALARM

        // True, with the reason on the jog card, when the axis must be left alone.
        private bool MotionBlocked()
        {
            string strWhy = null;
            if (MmiGV.pShMem == null) strWhy = "SEQ is not connected.";
            else if (MmiGV.dmData.DMValue[1] == 1) strWhy = "Not while the machine runs.";
            else if (nLastState >= 0 && Array.IndexOf(ScanStatesAxisFree, nLastState) < 0)
                strWhy = "Not while a scan cycle runs.";

            if (strWhy == null) return false;
            lblJogResult.Text = CLanguage.Text(strWhy)
                              + (strWhy.StartsWith("Not while a scan") ? "  (" + StateText(nLastState) + ")" : "");
            lblJogResult.ForeColor = HmiTheme.Warning;
            return true;
        }

        private void ShowMotorResult(string strText)
        {
            lblJogResult.Text = strText;
            lblJogResult.ForeColor = HmiTheme.TextMuted;
            AddLog(strText);
        }

        private void btnServo_Click(object sender, EventArgs e)
        {
            if (MotionBlocked()) return;
            MmiGV.pShMem.SetServoOnOff(nMotorAxis);
            ShowMotorResult(AxisText() + ": servo " + (btnServo.Checked ? "off" : "on") + " requested");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (MotionBlocked()) return;
            if (!frmMain.frm_Msg.Display(CLanguage.Format("Home {0}?\r\nThe axis moves to its origin.", AxisText()))) return;

            StopJog();
            MmiGV.pShMem.SetServoHome(nMotorAxis);
            ShowMotorResult(AxisText() + ": home started");
        }

        private void btnAlarmReset_Click(object sender, EventArgs e)
        {
            if (MmiGV.pShMem == null || MmiGV.dmData.DMValue[1] == 1) return;
            MmiGV.pShMem.SetServoAlarmClear(nMotorAxis);
            ShowMotorResult(AxisText() + ": alarm reset requested");
        }

        #endregion SERVO / HOME / ALARM

        #region JOG

        private void SetJogEnabled(bool bOn)
        {
            bJogEnabled = bOn;
            btnJogEnable.Checked = bOn;
            foreach (Control c in pnlJog.Controls)
            {
                if (c == btnJogEnable || c is Label) continue;
                c.Enabled = bOn;
            }
        }

        private void SetJogMode(bool bContinuous)
        {
            bJogContinuous = bContinuous;
            btnModeJog.Checked = bContinuous;
            btnModeStep.Checked = !bContinuous;
            ShowModeHint();
        }

        private void ShowModeHint()
        {
            lblModeHint.Text = CLanguage.Text(bJogContinuous
                ? "JOG: moves while + / - is held."
                : "STEP: one step per press of + / -.");
        }

        private void btnJogEnable_Click(object sender, EventArgs e)
        {
            if (!bJogEnabled && MotionBlocked()) return;
            StopJog();
            SetJogEnabled(!bJogEnabled);
            lblJogResult.Text = "";
        }

        private void btnModeStep_Click(object sender, EventArgs e)
        {
            StopJog();
            SetJogMode(false);
        }

        private void btnModeJog_Click(object sender, EventArgs e)
        {
            StopJog();
            SetJogMode(true);
        }

        // The step buttons count up the way the Motor screen's do: repeated
        // presses of +1.0 go 1, 2 ... 9 and back to 1; another button starts
        // from its own first value.
        private void btnStepPlus_Click(object sender, EventArgs e)
        {
            ChangeStep(Convert.ToInt32(((Control)sender).Tag), +1);
        }

        private void btnStepMinus_Click(object sender, EventArgs e)
        {
            ChangeStep(Convert.ToInt32(((Control)sender).Tag), -1);
        }

        private void ChangeStep(int iTag, int nSign)
        {
            double dUnit = Math.Pow(10, iTag - 2);       // tag 0..4 -> 0.01 .. 100
            double dStep;
            double.TryParse(lblStep.Text, out dStep);
            int iKey = (iTag + 1) * nSign;                // +0.01 and -0.01 count as different buttons
            if (iStepTagLast != iKey) dStep = (nSign > 0) ? 0.0 : 10 * dUnit;

            dStep += nSign * dUnit;
            if (dStep > 9 * dUnit + 1e-9) dStep = dUnit;
            if (dStep < dUnit - 1e-9) dStep = 9 * dUnit;

            lblStep.Text = dStep.ToString("F2");
            iStepTagLast = iKey;
        }

        private void txtJogVel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)Keys.Back)) e.Handled = true;
        }

        private uint JogVelocity()
        {
            uint uVel;
            if (!uint.TryParse(txtJogVel.Text, out uVel) || uVel == 0) uVel = 10;
            txtJogVel.Text = uVel.ToString();
            return uVel;
        }

        private void btnJogMove_MouseDown(object sender, MouseEventArgs e)
        {
            if (!bJogEnabled || MotionBlocked()) return;

            int iDir = Convert.ToInt32(((Control)sender).Tag);   // 0 = -, 1 = +
            uint uVel = JogVelocity();

            if (bJogContinuous)
            {
                MmiGV.pShMem.SetMotorVelocityMove(nMotorAxis, iDir, uVel);
                bJogMoving = true;
                lblJogResult.Text = AxisText() + (iDir == 0 ? "  jog -" : "  jog +");
                lblJogResult.ForeColor = HmiTheme.Accent;
                return;
            }

            double dStep;
            if (!double.TryParse(lblStep.Text, out dStep) || dStep <= 0)
            {
                lblJogResult.Text = CLanguage.Text("Choose a step first.");
                lblJogResult.ForeColor = HmiTheme.Warning;
                return;
            }
            int nPulses = (int)Math.Round(dStep * PulseRate(nMotorAxis)) * (iDir == 0 ? -1 : 1);
            MmiGV.pShMem.SetMotorRelativeMove(nMotorAxis, nPulses, uVel);
            ShowMotorResult(string.Format("{0}: step {1}{2:F2} mm", AxisText(), iDir == 0 ? "-" : "+", dStep));
        }

        private void btnJogMove_MouseUp(object sender, MouseEventArgs e)
        {
            StopJog();
        }

        private void btnJogMove_MouseLeave(object sender, EventArgs e)
        {
            StopJog();
        }

        private void StopJog()
        {
            if (!bJogMoving) return;
            bJogMoving = false;
            if (MmiGV.pShMem != null) MmiGV.pShMem.SetMotorStop(nMotorAxis);
            lblJogResult.Text = AxisText() + "  " + CLanguage.Text("stopped");
            lblJogResult.ForeColor = HmiTheme.TextMuted;
        }

        #endregion JOG
    }
}
