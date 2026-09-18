using Mapping;
using System;
using System.Diagnostics;
using System.Drawing;
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
        // The four inputs are typed straight into their text boxes. Editing any
        // of them drops the computed rows, which are stale the moment an input
        // moves, and takes START away again until the recipe is re-sent.

        // The axis the trigger runs on. Single scan axis for now; when a second
        // one appears this becomes a selection rather than a constant.
        private const uint ScanTriggerAxis = 0;

        // CThreadMain runs about nineteen MemPort round trips per pass and holds
        // the comm mutex almost continuously. MemPort gives up after waiting a
        // second for it, so one attempt from a button press can come back empty
        // while SEQ is answering perfectly well. Try a few times before calling
        // it a dead link.
        private const int ScanTriggerTries = 3;

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

            txtScanTrigStart.Text = rcp.ScanStart.ToString("F3");
            txtScanTrigEnd.Text   = rcp.ScanEnd.ToString("F3");
            txtScanTrigPitch.Text = rcp.ScanPixelRes.ToString("F2");
            txtScanTrigRate.Text  = rcp.ScanLineRate.ToString("F4");

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

        private bool TryReadScanTriggerRecipe(out double dStart, out double dEnd,
                                              out double dPitch, out double dRate)
        {
            dStart = dEnd = dPitch = dRate = 0.0;

            if (!double.TryParse(txtScanTrigStart.Text, out dStart)) return false;
            if (!double.TryParse(txtScanTrigEnd.Text,   out dEnd))   return false;
            if (!double.TryParse(txtScanTrigPitch.Text, out dPitch)) return false;
            if (!double.TryParse(txtScanTrigRate.Text,  out dRate))  return false;

            return true;
        }

        // Everything SEQ owns. The result row is not touched here: it carries the
        // outcome of the last action and the caller writes it straight after.
        private void ClearScanTriggerDisplay()
        {
            lblScanTrigSpeed.Text       = "-";
            lblScanTrigLines.Text       = "-";
            lblScanTrigTime.Text        = "-";
            lblScanTrigMotionStart.Text = "-";
            lblScanTrigMotionEnd.Text   = "-";
            lblScanTrigCounts.Text      = "-";
            lblScanTrigState.Text       = "-";
        }

        // The panel reads mm, mm, um and kHz because that is how the operator
        // thinks about a scan. Pixel Res is the along-scan resolution - one line
        // per that much travel - and it has to match the cross-scan resolution
        // or the image comes out stretched. The shared memory recipe is mm and
        // Hz throughout.
        private bool SendScanTriggerRecipe(double dStart, double dEnd,
                                           double dPitchUm, double dRateKHz)
        {
            MmiGV.pShMem.WScanTriggerRecipe.uAxisNo    = ScanTriggerAxis;
            MmiGV.pShMem.WScanTriggerRecipe.dTrigStart = dStart;
            MmiGV.pShMem.WScanTriggerRecipe.dTrigEnd   = dEnd;
            MmiGV.pShMem.WScanTriggerRecipe.dPitch     = dPitchUm  / 1000.0;
            MmiGV.pShMem.WScanTriggerRecipe.dLineRate  = dRateKHz  * 1000.0;

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
                case 4:  return "LINE RATE";
                case 5:  return "PITCH FRAC";
                case 6:  return "SPEED";
                case 7:  return "LINE COUNT";
                case 8:  return "NO COUNTER";
                case 9:  return "PULSE RATE";
                case 10: return "NOT HOMED";
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

            lblScanTrigSpeed.Text = d.dSpeed.ToString("F2");
            lblScanTrigTime.Text  = d.dScanTime.ToString("F2");
            lblScanTrigState.Text = ScanTriggerStateText(d.nState);

            // Where the axis actually starts and stops, which is outside the
            // trigger block by however much the ramps need.
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
            double dStart, dEnd, dPitch, dRate;

            bScanTriggerWatch = false;
            btnScanTrigStart.Enabled = false;

            if (!TryReadScanTriggerRecipe(out dStart, out dEnd, out dPitch, out dRate))
            {
                ClearScanTriggerDisplay();
                lblScanTrigResult.Text = "BAD NUMBER";
                return;
            }

            // Only the checks that need no machine knowledge. Everything else -
            // whether the pitch is a whole number of encoder counts, whether the
            // speed fits the axis, whether the axis is homed - is SEQ's to judge.
            if (dEnd <= dStart || dPitch <= 0.0 || dRate <= 0.0)
            {
                ClearScanTriggerDisplay();
                lblScanTrigResult.Text = "BAD RANGE";
                return;
            }

            // Persist before sending. The refusals SEQ can still raise - not homed,
            // no counter, speed beyond the axis - are machine states, not bad
            // numbers, and the operator should not lose what they typed to one.
            CRecipeCtl.CurMaterialRcp.ScanStart    = dStart;
            CRecipeCtl.CurMaterialRcp.ScanEnd      = dEnd;
            CRecipeCtl.CurMaterialRcp.ScanPixelRes = dPitch;
            CRecipeCtl.CurMaterialRcp.ScanLineRate = dRate;
            CRecipeCtl.CurMaterialRcp.SaveScanTrigger();

            if (MmiGV.pShMem == null)
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
                if (SendScanTriggerRecipe(dStart, dEnd, dPitch, dRate))
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
