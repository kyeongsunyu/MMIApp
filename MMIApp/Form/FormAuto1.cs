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

        // The panel is laid out and its inputs are collected here, but nothing is
        // sent to SEQ yet: the shared memory DLL that carries the recipe has
        // been extended in source and still has to be rebuilt and dropped into
        // C:\WORK\DLL. SendScanTriggerRecipe() is the one place those calls go.
        //
        // The computed rows - speed, line count, scan time, pitch in encoder
        // counts - and the state row stay empty until then. Every one of them is SEQ's to work out
        // from the recipe, and working them out a second time here would give the
        // operator two answers that can disagree.
        //
        // The four inputs are typed straight into their text boxes. Editing any of
        // them drops the computed rows, which are stale the moment an input moves.

        private void ScanTriggerInput_TextChanged(object sender, EventArgs e)
        {
            ClearScanTriggerDisplay();
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
            lblScanTrigSpeed.Text  = "-";
            lblScanTrigLines.Text  = "-";
            lblScanTrigTime.Text   = "-";
            lblScanTrigCounts.Text = "-";
            lblScanTrigState.Text  = "-";
        }

        private void SendScanTriggerRecipe(double dStart, double dEnd,
                                           double dPitch, double dRate)
        {
            // Once SharedMemDll carries the recipe:
            //
            //   MmiGV.pShMem.WScanTriggerRecipe.uAxisNo    = 0;
            //   MmiGV.pShMem.WScanTriggerRecipe.dTrigStart = dStart;
            //   MmiGV.pShMem.WScanTriggerRecipe.dTrigEnd   = dEnd;
            //   MmiGV.pShMem.WScanTriggerRecipe.dPitch     = dPitch;
            //   MmiGV.pShMem.WScanTriggerRecipe.dLineRate  = dRate;
            //   MmiGV.pShMem.SetScanTriggerRecipe();
            //   MmiGV.pShMem.GetScanTriggerDisplay();
            //
            // then fill the computed rows from RScanTriggerDisplay and enable
            // START only when nValidateCode is 0.
        }

        private void btnScanTrigSet_Click(object sender, EventArgs e)
        {
            double dStart, dEnd, dPitch, dRate;

            if (!TryReadScanTriggerRecipe(out dStart, out dEnd, out dPitch, out dRate))
            {
                ClearScanTriggerDisplay();
                lblScanTrigResult.Text = "BAD NUMBER";
                return;
            }

            // Only the checks that need no machine knowledge. Everything else -
            // whether the pitch is a whole number of encoder counts, whether the
            // speed fits the axis - is SEQ's to judge.
            if (dEnd <= dStart || dPitch <= 0.0 || dRate <= 0.0)
            {
                ClearScanTriggerDisplay();
                lblScanTrigResult.Text = "BAD RANGE";
                return;
            }

            SendScanTriggerRecipe(dStart, dEnd, dPitch, dRate);
            lblScanTrigResult.Text = "NO DLL";
        }

        private void btnScanTrigStart_Click(object sender, EventArgs e)
        {
            // MmiGV.pShMem.SetScanTriggerStart();
            lblScanTrigResult.Text = "NO DLL";
        }

        private void btnScanTrigStop_Click(object sender, EventArgs e)
        {
            // MmiGV.pShMem.SetScanTriggerStop();
            lblScanTrigResult.Text = "NO DLL";
        }

        #endregion
    }
}
