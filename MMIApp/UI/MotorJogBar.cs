using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MMI
{
    // The motor strip and jog bar that the TRIGGER screen carries, as a control
    // a screen can simply drop on: the axis's state, servo, home and alarm
    // reset along the top, and a jog row under it.
    //
    // It is here so that a screen where the operator watches something happen -
    // the camera image on VISION - can nudge the stage and clear an alarm
    // without leaving what it is watching.
    //
    // It drives the axis with the same SEQ commands the Motor screen uses
    // (SetServoOnOff, SetServoHome, SetServoAlarmClear, SetMotorVelocityMove,
    // SetMotorRelativeMove, SetMotorStop). The host screen is what reads the
    // status: it calls GetMotorStatus(Axis) on its own poll and hands the
    // result to Render().
    //
    // Nothing here moves the axis while the machine runs, and the jog buttons
    // do nothing until JOG ENABLE is on. A host with a reason of its own to
    // hold the axis still - VISION while a scan is armed - says so through
    // ExtraBlockReason. A continuous jog stops when the button is let go,
    // left, or the screen is closed.
    public partial class MotorJogBar : UserControl
    {
        // cbAxis lists the axes in use; this is the axis behind each item.
        private readonly List<int> axisOfItem = new List<int>();

        private int nAxis = 0;
        private int nPreferredAxis = 0;
        private bool bFilled = false;

        private bool bJogEnabled = false;
        private bool bJogContinuous = false;   // JOG: move while held; STEP: one step per press
        private bool bJogMoving = false;
        private int iStepTagLast = -1;

        public MotorJogBar()
        {
            InitializeComponent();

            SetJogEnabled(false);
            SetJogMode(false);
            lblStep.Text = "0.000";
            CLanguage.Changed += (s, e) => ShowModeHint();
        }

        #region HOST INTERFACE

        // The axis the strip is showing. The host polls SEQ for this one.
        public int Axis
        {
            get { return nAxis; }
        }

        // The axis to select when the list is first filled; the Motor screen's
        // numbering, so 0 is axis 01.
        public int PreferredAxis
        {
            get { return nPreferredAxis; }
            set
            {
                nPreferredAxis = value;
                if (!bFilled) nAxis = value;
                else SelectAxis(value);
            }
        }

        // A reason of the host's own why the axis must be left alone, or null.
        // Checked after the machine-running test, before anything moves.
        public Func<string> ExtraBlockReason { get; set; }

        // Where a line about what was asked for goes, beyond the strip's own
        // result label. Optional.
        public Action<string> Logger { get; set; }

        // Called by the host's poll with the result of GetMotorStatus(Axis).
        public void Render(bool bRead)
        {
            if (IsHandleCreated && InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(() => Render(bRead)));
                return;
            }

            SharedMemDll.MotorStatus st = (MmiGV.pShMem != null) ? MmiGV.pShMem.RMTStatus : null;
            if (!bRead || st == null)
            {
                lblCurIdx.Text = "-";
                lblCurPos.Text = "-";
                lblNextIdx.Text = "-";
                lblNextPos.Text = "-";
                foreach (Label c in new[] { lblStsMinusLimit, lblStsPlusLimit, lblStsOrg, lblStsHome, lblStsMoving, lblStsAlarm })
                {
                    Chip(c, false, HmiTheme.Control);
                }
                btnServo.Checked = false;
                return;
            }

            double dRate = PulseRate(nAxis);
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

        // Leaving the screen ends a jog and switches jogging off again, so that
        // coming back cannot carry on a move nobody is watching.
        public void Release()
        {
            StopJog();
            SetJogEnabled(false);
        }

        #endregion HOST INTERFACE

        #region SETUP

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (DesignMode) return;
            FillAxisList();
        }

        // The axes marked in use in MTCFG, as the Motor screen lists them.
        private void FillAxisList()
        {
            cbAxis.Items.Clear();
            axisOfItem.Clear();

            try
            {
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
            }
            catch (Exception)
            {
                // No database yet: the strip still works on the preferred axis.
            }

            if (axisOfItem.Count == 0)
            {
                cbAxis.Items.Add(string.Format("{0:D2}", nPreferredAxis + 1));
                axisOfItem.Add(nPreferredAxis);
            }
            bFilled = true;
            SelectAxis(nPreferredAxis);
        }

        private void SelectAxis(int nWanted)
        {
            int nItem = axisOfItem.IndexOf(nWanted);
            cbAxis.SelectedIndex = (nItem >= 0) ? nItem : 0;
        }

        private void cbAxis_SelectedIndexChanged(object sender, EventArgs e)
        {
            StopJog();
            int nItem = cbAxis.SelectedIndex;
            if (nItem < 0 || nItem >= axisOfItem.Count) return;
            nAxis = axisOfItem[nItem];
            Render(false);
        }

        private string AxisText()
        {
            return Convert.ToString(cbAxis.SelectedItem);
        }

        #endregion SETUP

        #region STATUS

        private static void Chip(Label chip, bool bOn, Color on)
        {
            chip.BackColor = bOn ? on : HmiTheme.Control;
            chip.ForeColor = bOn ? Color.White : HmiTheme.TextMuted;
        }

        private static double PulseRate(int nAxisNo)
        {
            if (nAxisNo < 0 || nAxisNo >= MmiGV.mtConfigData.Length) return 1.0;
            uint uRate = MmiGV.mtConfigData[nAxisNo].uPulseRate;
            return (uRate == 0) ? 1.0 : uRate;
        }

        #endregion STATUS

        #region SERVO / HOME / ALARM

        // True, with the reason on the jog row, when the axis must be left alone.
        private bool MotionBlocked()
        {
            string strWhy = null;
            if (MmiGV.pShMem == null) strWhy = "SEQ is not connected.";
            else if (MmiGV.dmData.DMValue[1] == 1) strWhy = "Not while the machine runs.";
            else if (ExtraBlockReason != null) strWhy = ExtraBlockReason();

            if (string.IsNullOrEmpty(strWhy)) return false;
            lblJogResult.Text = CLanguage.Text(strWhy);
            lblJogResult.ForeColor = HmiTheme.Warning;
            return true;
        }

        private void ShowMotorResult(string strText)
        {
            lblJogResult.Text = strText;
            lblJogResult.ForeColor = HmiTheme.TextMuted;
            if (Logger != null) Logger(strText);
        }

        private void btnServo_Click(object sender, EventArgs e)
        {
            if (MotionBlocked()) return;
            MmiGV.pShMem.SetServoOnOff(nAxis);
            ShowMotorResult(AxisText() + ": servo " + (btnServo.Checked ? "off" : "on") + " requested");
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            if (MotionBlocked()) return;
            if (MmiGV.frmMain == null || MmiGV.frmMain.frm_Msg == null) return;
            if (!MmiGV.frmMain.frm_Msg.Display(CLanguage.Format("Home {0}?\r\nThe axis moves to its origin.", AxisText()))) return;

            StopJog();
            MmiGV.pShMem.SetServoHome(nAxis);
            ShowMotorResult(AxisText() + ": home started");
        }

        private void btnAlarmReset_Click(object sender, EventArgs e)
        {
            if (MmiGV.pShMem == null || MmiGV.dmData.DMValue[1] == 1) return;
            MmiGV.pShMem.SetServoAlarmClear(nAxis);
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
        //
        // The range is 0.001 .. 10 mm, a decade finer than the Motor screen's
        // 0.01 .. 100. At 0.789 um a pixel, focusing and alignment happen in
        // microns, and 0.001 mm is the smallest step that means anything;
        // 100 mm at the other end was a stage traverse, not a jog.
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
            double dUnit = Math.Pow(10, iTag - 3);       // tag 0..4 -> 0.001 .. 10
            double dStep;
            double.TryParse(lblStep.Text, out dStep);
            int iKey = (iTag + 1) * nSign;                // +0.01 and -0.01 count as different buttons
            if (iStepTagLast != iKey) dStep = (nSign > 0) ? 0.0 : 10 * dUnit;

            dStep += nSign * dUnit;
            if (dStep > 9 * dUnit + 1e-9) dStep = dUnit;
            if (dStep < dUnit - 1e-9) dStep = 9 * dUnit;

            lblStep.Text = dStep.ToString("F3");
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
                MmiGV.pShMem.SetMotorVelocityMove(nAxis, iDir, uVel);
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
            // A step finer than the axis itself rounds to no pulses at all, and
            // sending that starts a zero length move: the stage does not budge
            // and nothing says why. At 500 pulses/mm, which some axes are,
            // that is every press of 0.001. Say what the axis can do instead.
            double dRate = PulseRate(nAxis);
            int nPulses = (int)Math.Round(dStep * dRate);
            if (nPulses == 0)
            {
                lblJogResult.Text = CLanguage.Format("{0:F3} mm is finer than this axis can move ({1:F3} mm per pulse).",
                                                     dStep, 1.0 / dRate);
                lblJogResult.ForeColor = HmiTheme.Warning;
                return;
            }
            if (iDir == 0) nPulses = -nPulses;
            MmiGV.pShMem.SetMotorRelativeMove(nAxis, nPulses, uVel);
            ShowMotorResult(string.Format("{0}: step {1}{2:F3} mm", AxisText(), iDir == 0 ? "-" : "+", dStep));
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
            if (MmiGV.pShMem != null) MmiGV.pShMem.SetMotorStop(nAxis);
            lblJogResult.Text = AxisText() + "  " + CLanguage.Text("stopped");
            lblJogResult.ForeColor = HmiTheme.TextMuted;
        }

        #endregion JOG
    }
}
