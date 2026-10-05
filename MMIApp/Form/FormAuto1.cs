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

            CPopup.Get<Form_Home>().TopMost = true;
            CPopup.Show<Form_Home>();
        }

        // Double clicking the tab strip pops the laser panel out of the tab,
        // as double clicking its tab did before.
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

            ShowEquipmentState();
        }

        // One of RUN / STOP / ALARM is lit at a time. Alarm wins over the other
        // two: a machine that stopped on an alarm is in alarm, not stopped.
        private void ShowEquipmentState()
        {
            bool bAlarm = MmiGV.iErrorCode > 0;
            bool bRun = !bAlarm && swRun.IsRunning;
            bool bStop = !bAlarm && !bRun;

            PaintStateChip(lblStateRun, bRun, HmiTheme.Normal);
            PaintStateChip(lblStateStop, bStop, HmiTheme.Warning);
            PaintStateChip(lblStateAlarm, bAlarm, HmiTheme.Alarm);
        }

        private static void PaintStateChip(Label chip, bool bOn, Color onColor)
        {
            chip.BackColor = bOn ? onColor : HmiTheme.Control;
            chip.ForeColor = bOn ? (onColor == HmiTheme.Warning ? HmiTheme.TopBar : Color.White) : HmiTheme.TextMuted;
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

        private void btnSeqOperation(object sender, EventArgs e)
        {
            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog != null);

            HmiButton p_Button = sender as HmiButton;

            uint tag = Convert.ToUInt32(p_Button.Tag);
            if (MmiGV.pShMem.GetDM(2) == 0)
            {
                MmiGV.pShMem.SetDM(2, tag);
                MMILog.AddMMILog(p_Button.Text + " Clicked");
            }
        }
    }
}
