using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Channels;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;
using static MMI.MmiGV;

namespace MMI
{
    public partial class FormMain : Form
    {
        #region FORM_DEFINE
        public Form_Language    frm_Language;

        public FormAutoView     frmAutoView;
        public FormManualView   frmManualView;
        public FormMotorView    frmMotorView;
        public FormDataView     frmDataView;
        public FormMonitorView  frmMonitorView;
        public FormAlarmView    frmAlarmView;
        public FormLogView      frmLogView;
       
        public FormCalView      frmCalView;
        public FormCalibration  frmCalib;


        public FormAutoMenu     frmAutoMenu;
        public FormAuto1        frmAuto1;
        public FormAuto2        frmAuto2;

        public FormManualMenu   frmManualMenu;
        public FormManualList   frmManualList;
        public FormManualOP     frmManualOP;

        public FormMotorMenu    frmMotorMenu;
        public FormMotorSetting frmMotorSetting;

        public FormDataMenu     frmDataMenu;
        public FormDataRecipe   frmDataRecipe;
        public FormDataSysParam frmDataSysParam;
        public FormDataOption   frmDataOption;
        public FormDataLampBuzzer frmDataLampBuzzer;
        public FormDataUserRegist frmDataUserRegist;
        public FormDataMotorCFG frmDataMotorCFG;

        public FormMonitorMenu  frmMonitorMenu;
        public FormMonitorIO    frmMonitorIO;
        public FormMonitorBitDM frmMonitorBitDM;

        public FormAlarmMenu    frmAlarmMenu;
        public FormAlarmList    frmAlarmList;

        public FormLogMenu      frmLogMenu;
        public FormLog          frmLog;
        public FormLogError     frmLogError;
        public FormLogMTBA      frmLogMTBA;
        #endregion FORM_DEFINE

        #region SUB_FORM_DEFINE
        public Form_NumAdd      frm_NumAdd;
        public Form_NumPad      frm_NumPad;
        public Form_DataCopy    frm_DataCopy;
        public Form_MotorCalc   frm_MotorCalc;
        public Form_TenKey      frm_TenKey;
        public Form_PM          frm_PM;
        public Form_PWD         frm_PWD;
        public Form_UserLogIn   frm_UserLogIn;
        public Form_Msg         frm_Msg;
        public Form_SystemInit  frm_SystemInit;
        public Form_Laser       frm_Laser;
        public Form_LotInput    frm_LotInput;
        public FormLogHistory   frmLogHistory;
        #endregion SUB_FORM


        private DevComponents.DotNetBar.ButtonX p_Button = null;
        private DevComponents.DotNetBar.ButtonX p_bfButton = null;

        bool bIsShowConsole = false;

        private int ibfButtonTag = 1;
        private int iSeqLinkCount = 0;
        private int iSetSeqLinkCount = 2;
        //private int m_iLampStatus = 0;
        //private int m_iRunning = 0;
        //private int m_iDeviceNo = 0;
        private bool bSeqLinked = false;

        DateTime dtUserLevelStartTime;
        DateTime dtStartConsoleShow;

        private CFileLog FileLog = CFileLog.GetInstance;

        public UDP_Server udp_server = new UDP_Server();
        enum eSCR:int
        {
            SCREEN_AUTO1 = 11,
            SCREEN_AUTO2 = 12,

            SCREEN_MANUAL_LIST = 21,
            SCREEN_MANUAL_OP = 22,

            SCREEN_MOTOR_SETTING = 31,

            SCREEN_DATA = 41,
            SCREEN_SYSTEM_PARAM = 42,
            SCREEN_USE_SKIP = 43,
            SCREEN_LAMP_BUZZER = 44,
            SCREEN_USER_REGIST = 45,
            SCREEN_MOTOR_CFG = 46,

            SCREEN_IO = 51,
            SCREEN_DM_BIT = 52,

            SCREEN_ALARM = 61,
        }
        public FormMain()
        {
            InitializeComponent();

            MmiGV.frmMain = this;

            this.Text = "MMIApp";
            FormInitialize();
        }

        private void FormInitialize()
        {
            #region FORM_LANGUAGE
            //frm_Language = new Form_Language(this);
            //frm_Language.ShowDialog();
            #endregion FORM_LANGUAGE

            #region FORM_MAIN_STATUS
            //frmMainStatus = new FormMainStatus(this);
            //frmMainStatus.StartPosition = FormStartPosition.Manual;
            //frmMainStatus.Location = new Point(0, 0);
            //frmMainStatus.TopLevel = false;
            //this.Controls.Add(frmMainStatus);
            //frmMainStatus.BringToFront();
            //frmMainStatus.Show();
            #endregion FORM_MAIN_STATUS

            #region FORM_MAIN_MENU
            //frmMainMenu = new FormMainMenu(this);
            //frmMainMenu.StartPosition = FormStartPosition.Manual;
            //frmMainMenu.Location = new Point(0, 1480);
            //frmMainMenu.TopLevel = false;
            //this.Controls.Add(frmMainMenu);
            //frmMainMenu.Show();
            #endregion FORM_MAIN_MENU

            #region FORM_AUTO_VIEW
            frmAutoView = new FormAutoView(this);
            frmAutoView.StartPosition = FormStartPosition.Manual;
            frmAutoView.Location = new Point(0, 100);
            frmAutoView.TopLevel = false;
            this.Controls.Add(frmAutoView);
            frmAutoView.Show();
            #endregion FORM_AUTO_VIEW

            #region FORM_MANUAL_VIEW
            frmManualView = new FormManualView(this);
            frmManualView.StartPosition = FormStartPosition.Manual;
            frmManualView.Location = new Point(0, 100);
            frmManualView.TopLevel = false;
            this.Controls.Add(frmManualView);
            #endregion FORM_MANUAL_VIEW

            #region FORM_MOTOR_VIEW
            frmMotorView = new FormMotorView(this);
            frmMotorView.StartPosition = FormStartPosition.Manual;
            frmMotorView.Location = new Point(0, 100);
            frmMotorView.TopLevel = false;
            this.Controls.Add(frmMotorView);
            #endregion FORM_MOTOR_VIEW

            #region FORM_DATA_VIEW
            frmDataView = new FormDataView(this);
            frmDataView.StartPosition = FormStartPosition.Manual;
            frmDataView.Location = new Point(0, 100);
            frmDataView.TopLevel = false;
            this.Controls.Add(frmDataView);
            #endregion FORM_DATA_VIEW

            #region FORM_MONITOR_VIEW
            frmMonitorView = new FormMonitorView(this);
            frmMonitorView.StartPosition = FormStartPosition.Manual;
            frmMonitorView.Location = new Point(0, 100);
            frmMonitorView.TopLevel = false;
            this.Controls.Add(frmMonitorView);
            #endregion FORM_MONITOR_VIEW

            #region FORM_ALARM_VIEW
            frmAlarmView = new FormAlarmView(this);
            frmAlarmView.StartPosition = FormStartPosition.Manual;
            frmAlarmView.Location = new Point(0, 100);
            frmAlarmView.TopLevel = false;
            this.Controls.Add(frmAlarmView);
            #endregion FORM_ALARM_VIEW


            frmCalView = new FormCalView(this);
            frmCalView.StartPosition = FormStartPosition.Manual;
            frmCalView.Location = new Point(0, 100);
            frmCalView.TopLevel = false;
            this.Controls.Add(frmCalView);


            #region FORM_LOG_VIEW
            frmLogView = new FormLogView(this);
            frmLogView.StartPosition = FormStartPosition.Manual;
            frmLogView.Location = new Point(0, 100);
            frmLogView.TopLevel = false;
            this.Controls.Add(frmLogView);
            #endregion FORM_LOG_VIEW

            #region FORM_AUTO_MENU
            frmAutoMenu = new FormAutoMenu(this);
            frmAutoMenu.StartPosition = FormStartPosition.Manual;
            frmAutoMenu.Location = new Point(1480, 0);
            frmAutoMenu.TopLevel = false;
            frmAutoView.Controls.Add(frmAutoMenu);
            frmAutoMenu.Show();
            #endregion FORM_AUTO_MENU

            #region FORM_AUTO1
            frmAuto1 = new FormAuto1(this);
            frmAuto1.StartPosition = FormStartPosition.Manual;
            frmAuto1.Location = new Point(0, 0);
            frmAuto1.TopLevel = false;
            frmAutoView.Controls.Add(frmAuto1);
            frmAuto1.BringToFront();
            frmAuto1.Show();
            #endregion FORM_AUTO1

            #region FORM_AUTO2
            frmAuto2 = new FormAuto2(this);
            frmAuto2.StartPosition = FormStartPosition.Manual;
            frmAuto2.Location = new Point(0, 0);
            frmAuto2.TopLevel = false;
            frmAutoView.Controls.Add(frmAuto2);
            //frmAuto2.BringToFront();
            frmAuto2.Show();
            #endregion FORM_AUTO2

            #region FORM_MANUAL_MENU
            frmManualMenu = new FormManualMenu(this);
            frmManualMenu.StartPosition = FormStartPosition.Manual;
            frmManualMenu.Location = new Point(1480, 0);//(1160, 0)
            frmManualMenu.TopLevel = false;
            frmManualView.Controls.Add(frmManualMenu);
            frmManualMenu.Show();
            #endregion FORM_MANUAL_MENU

            #region FORM_MANUAL_LIST
            frmManualList = new FormManualList(this);
            frmManualList.StartPosition = FormStartPosition.Manual;
            frmManualList.Location = new Point(0, 0);
            frmManualList.TopLevel = false;
            frmManualView.Controls.Add(frmManualList);
            frmManualList.BringToFront();
            frmManualList.Show();
            #endregion FORM_MANUAL_LIST

            #region FORM_MANUAL_OP
            frmManualOP = new FormManualOP(this);
            frmManualOP.StartPosition = FormStartPosition.Manual;
            frmManualOP.Location = new Point(0, 0);
            frmManualOP.TopLevel = false;
            frmManualView.Controls.Add(frmManualOP);
            frmManualOP.Show();
            #endregion FORM_MANUAL_OP

            #region FORM_MOTORL_MENU
            frmMotorMenu = new FormMotorMenu(this);
            frmMotorMenu.StartPosition = FormStartPosition.Manual;
            frmMotorMenu.Location = new Point(1480, 0);
            frmMotorMenu.TopLevel = false;
            frmMotorView.Controls.Add(frmMotorMenu);
            frmMotorMenu.Show();
            #endregion FORM_MOTORL_MENU

            #region FORM_MOTOR_SETTING
            frmMotorSetting = new FormMotorSetting(this);
            frmMotorSetting.StartPosition = FormStartPosition.Manual;
            frmMotorSetting.Location = new Point(0, 0);
            frmMotorSetting.TopLevel = false;
            frmMotorView.Controls.Add(frmMotorSetting);
            frmMotorSetting.BringToFront();
            frmMotorSetting.Show();
            #endregion FORM_MOTOR_SETTING

            #region FORM_DATA_MENU
            frmDataMenu = new FormDataMenu(this);
            frmDataMenu.StartPosition = FormStartPosition.Manual;
            //frmDataMenu.Location = new Point(1160, 0);

            frmDataMenu.Location = new Point(1480, 0);
            frmDataMenu.TopLevel = false;
            frmDataView.Controls.Add(frmDataMenu);
            frmDataMenu.Show();
            #endregion FORM_DATA_MENU

            #region FORM_DATA_RECIPE
            frmDataRecipe = new FormDataRecipe(this);
            frmDataRecipe.StartPosition = FormStartPosition.Manual;
            frmDataRecipe.Location = new Point(0, 0);
            frmDataRecipe.TopLevel = false;
            frmDataView.Controls.Add(frmDataRecipe);
            frmDataRecipe.BringToFront();
            frmDataRecipe.Show();
            #endregion FORM_DATA_RECIPE

            #region FORM_DATA_SYSTEM_PARAM
            frmDataSysParam = new FormDataSysParam(this);
            frmDataSysParam.StartPosition = FormStartPosition.Manual;
            frmDataSysParam.Location = new Point(0, 0);
            frmDataSysParam.TopLevel = false;
            frmDataView.Controls.Add(frmDataSysParam);
            frmDataSysParam.Show();
            #endregion FORM_DATA_SYSTEM_PARAM

            #region FORM_DATA_OPTION
            frmDataOption = new FormDataOption(this);
            frmDataOption.StartPosition = FormStartPosition.Manual;
            frmDataOption.Location = new Point(0, 0);
            frmDataOption.TopLevel = false;
            frmDataView.Controls.Add(frmDataOption);
            frmDataOption.Show();
            #endregion FORM_DATA_OPTION

            #region FORM_DATA_LAMP_BUZZER
            frmDataLampBuzzer = new FormDataLampBuzzer(this);
            frmDataLampBuzzer.StartPosition = FormStartPosition.Manual;
            frmDataLampBuzzer.Location = new Point(0, 0);
            frmDataLampBuzzer.TopLevel = false;
            frmDataView.Controls.Add(frmDataLampBuzzer);
            frmDataLampBuzzer.Show();
            #endregion FORM_DATA_LAMP_BUZZER

            #region FORM_DATA_USER_REGIST
            frmDataUserRegist = new FormDataUserRegist(this);
            frmDataUserRegist.StartPosition = FormStartPosition.Manual;
            frmDataUserRegist.Location = new Point(0, 0);
            frmDataUserRegist.TopLevel = false;
            frmDataView.Controls.Add(frmDataUserRegist);
            frmDataUserRegist.Show();
            #endregion FORM_DATA_USER_REGIST

            #region FORM_DATA_MOTOR_CONFIG
            frmDataMotorCFG = new FormDataMotorCFG(this);
            frmDataMotorCFG.StartPosition = FormStartPosition.Manual;
            frmDataMotorCFG.Location = new Point(0, 0);
            frmDataMotorCFG.TopLevel = false;
            frmDataView.Controls.Add(frmDataMotorCFG);
            frmDataMotorCFG.Show();
            #endregion FORM_DATA_MOTOR_CONFIG

            #region FORM_MONITOR_MENU
            frmMonitorMenu = new FormMonitorMenu(this);
            frmMonitorMenu.StartPosition = FormStartPosition.Manual;
            frmMonitorMenu.Location = new Point(1480, 0);  //(1160, 0)
            frmMonitorMenu.TopLevel = false;
            frmMonitorView.Controls.Add(frmMonitorMenu);
            frmMonitorMenu.Show();
            #endregion FORM_MONITOR_MENU

            #region FORM_MONITOR_IO
            frmMonitorIO = new FormMonitorIO(this);
            frmMonitorIO.StartPosition = FormStartPosition.Manual;
            frmMonitorIO.Location = new Point(0, 0);
            frmMonitorIO.TopLevel = false;
            frmMonitorView.Controls.Add(frmMonitorIO);
            frmMonitorIO.BringToFront();
            frmMonitorIO.Show();
            #endregion FORM_MONITOR_IO

            #region FORM_MONITOR_BIT_DM
            frmMonitorBitDM = new FormMonitorBitDM(this);
            frmMonitorBitDM.StartPosition = FormStartPosition.Manual;
            frmMonitorBitDM.Location = new Point(0, 0);
            frmMonitorBitDM.TopLevel = false;
            frmMonitorView.Controls.Add(frmMonitorBitDM);
            frmMonitorBitDM.Show();
            #endregion FORM_MONITOR_BIT_DM

            #region FORM_ALARM_MENU
            frmAlarmMenu = new FormAlarmMenu(this);
            frmAlarmMenu.StartPosition = FormStartPosition.Manual;
            frmAlarmMenu.Location = new Point(1480, 0);
            frmAlarmMenu.TopLevel = false;
            frmAlarmView.Controls.Add(frmAlarmMenu);
            frmAlarmMenu.Show();
            #endregion FORM_ALARM_MENU

            #region FORM_ALARM_LIST
            frmAlarmList = new FormAlarmList(this);
            frmAlarmList.StartPosition = FormStartPosition.Manual;
            frmAlarmList.Location = new Point(0, 0);
            frmAlarmList.TopLevel = false;
            frmAlarmView.Controls.Add(frmAlarmList);
            frmAlarmList.BringToFront();
            frmAlarmList.Show();
            #endregion FORM_ALARM_LIST

            #region FORM_LOG_MENU
            frmLogMenu = new FormLogMenu(this);
            frmLogMenu.StartPosition = FormStartPosition.Manual;
            frmLogMenu.Location = new Point(1480, 0); //(1160, 0)
            frmLogMenu.TopLevel = false;
            frmLogView.Controls.Add(frmLogMenu);
            frmLogMenu.Show();
            #endregion FORM_LOG_MENU

            #region FORM_LOG
            frmLog = new FormLog(this);
            frmLog.StartPosition = FormStartPosition.Manual;
            frmLog.Location = new Point(0, 0);
            frmLog.TopLevel = false;
            frmLogView.Controls.Add(frmLog);
            frmLog.BringToFront();
            frmLog.Show();
            #endregion FORM_LOG

            #region FORM_LOG_ERROR
            frmLogError = new FormLogError(this);
            frmLogError.StartPosition = FormStartPosition.Manual;
            frmLogError.Location = new Point(0, 0);
            frmLogError.TopLevel = false;
            frmLogView.Controls.Add(frmLogError);
            frmLogError.Show();
            #endregion FORM_LOG_ERROR

            #region FORM_LOG_MTBA_MTBF
            frmLogMTBA = new FormLogMTBA(this);
            frmLogMTBA.StartPosition = FormStartPosition.Manual;
            frmLogMTBA.Location = new Point(0, 0);
            frmLogMTBA.TopLevel = false;
            frmLogView.Controls.Add(frmLogMTBA);
            frmLogMTBA.Show();
            #endregion FORM_LOG_MTBA_MTBF


            frmCalib = new FormCalibration(this);
            frmCalib.StartPosition = FormStartPosition.Manual;
            frmCalib.Location = new Point(0, 0);
            frmCalib.TopLevel = false;
            frmCalView.Controls.Add(frmCalib);
            frmCalib.BringToFront();
            frmCalib.Show();




            #region SUB_FORM
            frm_NumAdd = new Form_NumAdd(this);
            frm_NumPad      = new Form_NumPad(this);
            frm_DataCopy    = new Form_DataCopy(this);
            frm_MotorCalc   = new Form_MotorCalc(this);
            frm_PM          = new Form_PM(this);

            frm_PWD         = new Form_PWD(this);
            frm_PWD.TopMost = true;
            frm_PWD.TopLevel = true;

            frm_UserLogIn = new Form_UserLogIn(this);
            frm_Msg = new Form_Msg(this);
            frm_SystemInit = new Form_SystemInit(this);

            frm_Laser = new Form_Laser();
            frm_Laser.TopLevel = false;
            frm_Laser.Visible = true;
            frm_Laser.Parent = frmAuto1.tcComm;

            frm_LotInput = new Form_LotInput();
            frm_LotInput.TopMost = true;
            frm_LotInput.TopLevel = true;

            frmLogHistory = new FormLogHistory(this);

            #endregion SUB_FORM

            #region FORM_VIEW_POINT_INIT
            MmiGV.ViewMainForm = frmAutoView;
            MmiGV.bfViewMainForm = frmAutoView;

            MmiGV.ViewAutoForm = frmAuto1;
            MmiGV.bfViewAutoForm = frmAuto1;

            MmiGV.ViewManualForm = frmManualList;
            MmiGV.bfViewManualForm = frmManualList;

            MmiGV.ViewMotorForm = frmMotorSetting;
            MmiGV.bfViewMotorForm = frmMotorSetting;

            MmiGV.ViewDataForm = frmDataRecipe;
            MmiGV.bfViewDataForm = frmDataRecipe;

            MmiGV.ViewMonitorForm = frmMonitorIO;
            MmiGV.bfViewMonitorForm = frmMonitorIO;

            MmiGV.ViewAlarmForm = frmAlarmList;
            MmiGV.bfViewAlarmForm = frmAlarmList;

            MmiGV.ViewLogForm = frmLog;
            MmiGV.bfViewLogForm = frmLog;
            #endregion FORM_VIEW_POINT_INIT


            p_bfButton = btnMenuAuto;
            btnMenuAuto.Checked = true;

            //SetMenuButtonEnable((int)MmiGV.eUserLevel.USER_LEVEL_NONE);
            //UILanguageUpdate();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SQLiteDB.Open();

            // Before anything reads the DEVICE table: machines built before the
            // scan trigger have no columns for it.
            CRcpMaterial.EnsureScanTriggerColumns();

            CRecipeCtl.SetMainForm(this);
            //add by chs
            CRecipeCtl.MainRecipeLoad();

            OpenConfigFile();
            //DisplayCurDevice();
            //FileLog.LOG_TRACE("Machine Start...");

            MmiGV.bProgramExit = false;


            //frm_SystemInit.SystemInitialize();

            CThread.ThreadMain = new Thread(() => { CThreadMain.ExecuteMainThred(); });
            CThread.CreateThread(CThread.ThreadMain, ThreadPriority.Normal);

            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog!=null);

            CThread.ThreadMMILogMsg = new Thread(() => { MMILog.ExcuteMMILogMsg(); });
            CThread.CreateThread(CThread.ThreadMMILogMsg, ThreadPriority.Normal);

            //Thread thdUDPServer = new Thread(new ThreadStart(UDPServerSeqLogThread));
            //thdUDPServer.Start();

            udp_server.StartAsServer("127.0.0.1", "9999");
        }

        public void DisplayCurDevice()
        {
            string strDevice;
            strDevice = " [" + string.Format("{0:D3}", MmiGV.iDevNo) + "]";
            strDevice += MmiGV.strCurrentDevName;
            lblDevice.Text = strDevice;
        }

        private void FormMain_Shown(object sender, EventArgs e)
        {
            

        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            string strSQL;

            e.Cancel = true;
            if (frm_PWD.GetPassWord(MmiGV.iScreenNo))
            {
                SaveDM();
                SaveUseSkip();

                strSQL = $"UPDATE TRACKING SET DTIME = {MmiGV.tmDownTime.Elapsed}";
                strSQL += $", EMARK = NULL";
                strSQL += $" WHERE EMARK ='**'";
                SQLiteDB.Execute(strSQL);

                MmiGV.bProgramExit = true;
                MmiGV.pShMem.SetExitProgram();

                Thread.Sleep(2000);
                //if (CThread.ThreadMain != null)
                //{
                //    CThread.ThreadMain.Abort();
                //}

                //if(CThread.ThreadMMILogMsg!=null)
                //{
                //    CThread.ThreadMMILogMsg.Abort();
                //}

                e.Cancel = false;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            //MmiGV.bProgramExit = true;
            SQLiteDB.Close();

            //SEQ_EXIT seq_exit = new SEQ_EXIT()
            //{
            //    bExit = true,
            //};

            //WIN32Helper.SendCopyData(WIN32Helper.WM_COPYDATA, seq_exit);
        }

        private void showHideConsoleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (bIsShowConsole == false)
            {
                ConsoleHelper.ShowConsole();
                bIsShowConsole = true;
                timerConsole.Enabled = true;
                dtStartConsoleShow = DateTime.Now;
            }
            else
            {
                ConsoleHelper.HideConsole();
                bIsShowConsole = false;
                timerConsole.Enabled = false;
            }
        }
        private void timerConsole_Tick(object sender, EventArgs e)
        {
            TimeSpan tsDiff2 = DateTime.Now - dtStartConsoleShow;
            if (tsDiff2.TotalMinutes > 20)
            {
                ConsoleHelper.HideConsole();
                bIsShowConsole = false;
                timerConsole.Enabled = false;
            }
        }

        private void btnMenuClick(object sender, EventArgs e)
        {
            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog!=null);

            p_Button = sender as DevComponents.DotNetBar.ButtonX;

            if (ibfButtonTag == Convert.ToInt16(p_Button.Tag))
                return;

            MmiGV.bfViewMainForm.Visible = false;

            int nTag = Convert.ToInt16(p_Button.Tag);
            switch (nTag)
            {
                case (int)MmiGV.eSCRNO.AUTO_VIEW:
                    MmiGV.ViewMainForm = frmAutoView;
                    break;
                case (int)MmiGV.eSCRNO.MANUAL_VIEW:
                    MmiGV.ViewMainForm = frmManualView;
                    break;
                case (int)MmiGV.eSCRNO.MOTOR_VIEW:
                    MmiGV.ViewMainForm = frmMotorView;
                    break;
                case (int)MmiGV.eSCRNO.DATA_VIEW:
                    MmiGV.ViewMainForm = frmDataView;
                    break;
                case (int)MmiGV.eSCRNO.MONITOR_VIEW:
                    MmiGV.ViewMainForm = frmMonitorView;
                    break;
                case (int)MmiGV.eSCRNO.ALARM_VIEW:
                    MmiGV.ViewMainForm = frmAlarmView;
                    break;
                case (int)MmiGV.eSCRNO.LOG_VIEW:
                    MmiGV.ViewMainForm = frmLogView;
                    break;
                case (int)MmiGV.eSCRNO.CALIB:
                    frmCalView.Controls.Clear();
                    frmCalib.Load3Point();
                    frmCalView.Controls.Add(frmCalib);
                    MmiGV.ViewMainForm = frmCalView;
                    break;
            }

            MmiGV.ViewMainForm.Visible = true;
            MmiGV.bfViewMainForm = MmiGV.ViewMainForm;

            p_bfButton.Checked = false;
            p_Button.Checked = true;
            p_bfButton = p_Button;
            ibfButtonTag = nTag;

            frmMotorSetting.bTenkeyJogMode = false;
            frmMotorSetting.btnTenkeyJog.Checked = false;
            MmiGV.pShMem.SetTenKeyJog(MmiGV.iCurrAxis, frmMotorSetting.bTenkeyJogMode);

            #region SCREEN_NO
            if (MmiGV.ViewMainForm == frmAutoView)
            {
                if (MmiGV.ViewAutoForm == frmAuto1)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.AUTO1;
                    MMILog.AddMMILog("Change Screen : AUTO1");
                }
                else if (MmiGV.ViewAutoForm == frmAuto2)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.AUTO2;
                    MMILog.AddMMILog("Change Screen : AUTO2");
                }
            }
            else if (MmiGV.ViewMainForm == frmManualView)
            {
                if (MmiGV.ViewManualForm == frmManualList)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.MANUAL_LIST;
                    MMILog.AddMMILog("Change Screen : MANUAL_LIST");
                }
                else if (MmiGV.ViewManualForm == frmManualOP)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.MANUAL_OP;
                    MMILog.AddMMILog("Change Screen : MANUAL_OP");
                }
            }
            else if (MmiGV.ViewMainForm == frmMotorView)
            {
                if (MmiGV.ViewMotorForm == frmMotorSetting)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.MOTOR_SETTING;
                    MMILog.AddMMILog("Change Screen : MOTOR_SETTING");
                }
            }
            else if (MmiGV.ViewMainForm == frmDataView)
            {
                if (MmiGV.ViewDataForm == frmDataRecipe)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_RECIPE;
                    MMILog.AddMMILog("Change Screen : DATA_RECIPE");
                }
                else if (MmiGV.ViewDataForm == frmDataSysParam)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_SYSTEMPARAM;
                    MMILog.AddMMILog("Change Screen : DATA_SYSTEMPARAM");
                }
                else if (MmiGV.ViewDataForm == frmDataOption)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_OPTION;
                    MMILog.AddMMILog("Change Screen : DATA_OPTION");
                }
                else if (MmiGV.ViewDataForm == frmDataLampBuzzer)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_LAMPBUZZER;
                    MMILog.AddMMILog("Change Screen : DATA_LAMPBUZZER");
                }
                else if (MmiGV.ViewDataForm == frmDataUserRegist)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_USERREGIST;
                    MMILog.AddMMILog("Change Screen : DATA_USERREGIST");
                }
                else if (MmiGV.ViewDataForm == frmDataMotorCFG)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_MOTOR_CONFIG;
                    MMILog.AddMMILog("Change Screen : DATA_MOTOR_CONFIG");
                }
            }
            else if (MmiGV.ViewMainForm == frmMonitorView)
            {
                if (MmiGV.ViewMonitorForm == frmMonitorIO)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.MONITOR_IO;
                    MMILog.AddMMILog("Change Screen : MONITOR_IO");
                }
                else if (MmiGV.ViewMonitorForm == frmMonitorBitDM)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.MONITOR_DMBIT;
                    MMILog.AddMMILog("Change Screen : MONITOR_DMBIT");
                }
            }
            else if (MmiGV.ViewMainForm == frmAlarmView)
            {
                if (MmiGV.ViewAlarmForm == frmAlarmList)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.ALARM_LIST;
                    MMILog.AddMMILog("Change Screen : ALARM_LIST");
                }
            }
            else if (MmiGV.ViewMainForm == frmLogView)
            {
                if (MmiGV.ViewLogForm == frmLog)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.LOG;
                    MMILog.AddMMILog("Change Screen : LOG");
                }
                else if (MmiGV.ViewLogForm == frmLogError)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.LOG_ERROR;
                    MMILog.AddMMILog("Change Screen : LOG_ERROR");
                }
                else if (MmiGV.ViewLogForm == frmLogMTBA)
                {
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.LOG_MTBAMTBF;
                    MMILog.AddMMILog("Change Screen : LOG_MTBAMTBF");
                }
            }
            MmiGV.pShMem.SetDM(7, (uint)MmiGV.iScreenNo);
            #endregion SCREEN_NO
        }

        private void SetMenuButtonEnable(int iLevel)
        {
            switch (iLevel)
            {
                case (int)MmiGV.eUserLevel.USER_LEVEL_NONE:
                    btnMenuAuto.Enabled = true;
                    btnMenuManual.Enabled = false;
                    btnMenuMotor.Enabled = false;
                    btnMenuData.Enabled = false;
                    btnMenuMonitor.Enabled = false;
                    btnMenuAlarm.Enabled = false;
                    btnMenuLog.Enabled = false;
                    btnTenKey.Enabled = false;

                    //TimerUserLevel.Enabled = true;
                    break;
                case (int)MmiGV.eUserLevel.USER_LEVEL_OPERATOR:
                    btnMenuAuto.Enabled = true;
                    btnMenuManual.Enabled = false;
                    btnMenuMotor.Enabled = false;

                    btnMenuData.Enabled = true;
                    frmDataMenu.btnMenuRecipe.Enabled = true;
                    frmDataMenu.btnMenuSysParam.Enabled = false;
                    frmDataMenu.btnOption.Enabled = false;
                    frmDataMenu.btnMenuLampBuzzer.Enabled = false;
                    frmDataMenu.btnMenuUserRegist.Enabled = false;
                    frmDataMenu.btnMenuMTCFG.Enabled = false;

                    btnMenuMonitor.Enabled = true;
                    btnMenuAlarm.Enabled = true;
                    btnMenuLog.Enabled = true;
                    btnTenKey.Enabled = true;

                    TimerUserLevel.Enabled = true;
                    break;
                case (int)MmiGV.eUserLevel.USER_LEVEL_MAINTENANCE:
                    btnMenuAuto.Enabled = true;
                    btnMenuManual.Enabled = true;
                    btnMenuMotor.Enabled = false;

                    btnMenuData.Enabled = true;
                    frmDataMenu.btnMenuRecipe.Enabled = true;
                    frmDataMenu.btnMenuSysParam.Enabled = false;
                    frmDataMenu.btnOption.Enabled = false;
                    frmDataMenu.btnMenuLampBuzzer.Enabled = false;
                    frmDataMenu.btnMenuUserRegist.Enabled = false;
                    frmDataMenu.btnMenuMTCFG.Enabled = false;

                    btnMenuMonitor.Enabled = true;
                    btnMenuAlarm.Enabled = true;
                    btnMenuLog.Enabled = true;
                    btnTenKey.Enabled = true;

                    TimerUserLevel.Enabled = true;
                    break;
                case (int)MmiGV.eUserLevel.USER_LEVEL_ENGINEER:
                    btnMenuAuto.Enabled = true;
                    btnMenuManual.Enabled = true;
                    btnMenuMotor.Enabled = true;

                    frmDataMenu.btnMenuRecipe.Enabled = true;
                    frmDataMenu.btnMenuSysParam.Enabled = true;
                    frmDataMenu.btnOption.Enabled = true;
                    frmDataMenu.btnMenuLampBuzzer.Enabled = true;
                    frmDataMenu.btnMenuUserRegist.Enabled = true;
                    frmDataMenu.btnMenuMTCFG.Enabled = true;

                    btnMenuMonitor.Enabled = true;
                    btnMenuAlarm.Enabled = true;
                    btnMenuLog.Enabled = true;
                    btnTenKey.Enabled = true;

                    TimerUserLevel.Enabled = true;
                    break;
                case (int)MmiGV.eUserLevel.USER_LEVEL_MASTER:
                    btnMenuAuto.Enabled = true;
                    btnMenuManual.Enabled = true;
                    btnMenuMotor.Enabled = true;

                    frmDataMenu.btnMenuRecipe.Enabled = true;
                    frmDataMenu.btnMenuSysParam.Enabled = true;
                    frmDataMenu.btnOption.Enabled = true;
                    frmDataMenu.btnMenuLampBuzzer.Enabled = true;
                    frmDataMenu.btnMenuUserRegist.Enabled = true;
                    frmDataMenu.btnMenuMTCFG.Enabled = true;

                    btnMenuMonitor.Enabled = true;
                    btnMenuAlarm.Enabled = true;
                    btnMenuLog.Enabled = true;
                    btnTenKey.Enabled = true;

                    TimerUserLevel.Enabled = true;
                    break;
            }
        }

        private void btnTenKey_Click(object sender, EventArgs e)
        {
            frm_TenKey = new Form_TenKey(this);

            frm_TenKey.DISPLAY();
        }

       
        private void btnUserLogIn_Click(object sender, EventArgs e)
        {
            if (btnUserLogIn.Checked)
            {
                btnUserLogIn.Checked = false;
                btnUserLogIn.Text = "LOG IN";
                lblUserName.Text = "NO USER";

                SetMenuButtonEnable((int)MmiGV.eUserLevel.USER_LEVEL_NONE);
                TimerUserLevel.Enabled = false;

                MmiGV.pShMem.WUserInfo.strUserName = MmiGV.UserInfo.strUserName = "NO_USER";
                MmiGV.pShMem.SetUserInfo();

                //USER_INFO user_info = new USER_INFO()
                //{
                //    strUserName = MmiGV.UserInfo.strUserName,
                //};
                //WIN32Helper.SendCopyData(WIN32Helper.WM_USER_LOG_OUT_REQ, user_info);

            }
            else
            {
                if (frm_UserLogIn.DISPLAY((int)MmiGV.eFormShowMode.MODAL))
                {
                    btnUserLogIn.Checked = true;
                    btnUserLogIn.Text = "LOG OUT";
                    lblUserName.Text = MmiGV.UserInfo.strUserName;

                    dtUserLevelStartTime = DateTime.Now;
                    SetMenuButtonEnable(MmiGV.UserInfo.iUserLevel);

                    MmiGV.pShMem.WUserInfo.strUserName = MmiGV.UserInfo.strUserName;
                    MmiGV.pShMem.SetUserInfo();

                    //USER_INFO user_info = new USER_INFO()
                    //{
                    //    strUserName = MmiGV.UserInfo.strUserName,
                    //};
                    //WIN32Helper.SendCopyData(WIN32Helper.WM_USER_LOG_IN_REQ, user_info);

                }
            }
        }

        private void btnPM_Click(object sender, EventArgs e)
        {
            frm_PM.ShowDialog();
        }

        void OpenConfigFile()
        {
            CIniHelper iniHelper = new CIniHelper("MachineConfig.ini");

            if (!iniHelper.KeyExists("MASTER ENGINEER", "PASSWORD")){
                iniHelper.WriteInteger("MASTER ENGINEER", 0, "PASSWORD");
            }
            else
            {
                int iPassword = iniHelper.ReadInteger("MASTER ENGINEER", "PASSWORD");
                if (iPassword == 4888)
                {
                    MmiGV.bPasswordSkip = true;
                }
            }

            if (!iniHelper.KeyExists("MAX REC", "MTBA/MTBF"))
            {
                iniHelper.WriteInteger("MAX REC", 500000, "MTBA/MTBF");
                MmiGV.iMTBAMaxRec = 500000;
            }
            else
            {
                MmiGV.iMTBAMaxRec = iniHelper.ReadInteger("MAX REC", "MTBA/MTBF");
            }
            if (MmiGV.iMTBAMaxRec > 999999)
            {
                MmiGV.iMTBAMaxRec = 999999;
            }

            if (!iniHelper.KeyExists("DELETE REC", "MTBA/MTBF"))
            {
                iniHelper.WriteInteger("DELETE REC", 300000, "MTBA/MTBF");
                MmiGV.iMTBADeleteRec = 300000;
            }
            else
            {
                MmiGV.iMTBADeleteRec = iniHelper.ReadInteger("DELETE REC", "MTBA/MTBF");
            }
            if (MmiGV.iMTBADeleteRec > (MmiGV.iMTBAMaxRec / 2))
            {
                MmiGV.iMTBADeleteRec = (MmiGV.iMTBAMaxRec / 2) - 1;
            }

            if (!iniHelper.KeyExists("TimeOut", "USER LEVEL"))
            {
                iniHelper.WriteInteger("TimeOut", 10, "USER LEVEL");
                MmiGV.iUserLevelTimeOut = 10;
            }
            else
            {
                MmiGV.iUserLevelTimeOut = iniHelper.ReadInteger("TimeOut", "USER LEVEL");
            }

            if (!iniHelper.KeyExists("TARGET UPH", "UPH"))
            {
                iniHelper.WriteInteger("TARGET UPH", 1, "UPH");
                MmiGV.iTragetUPH = 1;
            }
            else
            {
                MmiGV.iTragetUPH = iniHelper.ReadInteger("TARGET UPH", "UPH");
            }
        }

        private void UILanguageUpdate()
        {
            btnMenuAuto.Text = MmiGV.m_dicUICaption[(int)MmiGV.eCAPTION_NAME.CAPTION_MAIN_MENU_AUTO];
        }

        private void btnLanguageSET_Click(object sender, EventArgs e)
        {
            frm_Language = new Form_Language(this);
            frm_Language.ShowDialog();

            UILanguageUpdate();
        }


        private void btnRESET_Click(object sender, EventArgs e)
        {
            //frm_Msg.ShowMessage("test");

            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog != null);

            DevComponents.DotNetBar.ButtonX p_Button = sender as DevComponents.DotNetBar.ButtonX;

            MmiGV.pShMem.SetTenKey(0);
            MMILog.AddMMILog(p_Button.Text + " Clicked");
        }

        private void TimerUserLevel_Tick(object sender, EventArgs e)
        {
            TimeSpan tsDiff = DateTime.Now - dtUserLevelStartTime;

            lblUserTime.Text = "USER\n" + tsDiff.ToString(@"hh\:mm\:ss");
            //if (tsDiff.TotalMinutes > MmiGV.iUserLevelTimeOut)
            //{
            //    TimerUserLevel.Enabled = false;
            //    lblUserName.Text = "NO USER";
            //    lblUserTime.Text = "USER\n" + "00:00:00";

            //    MmiGV.UserInfo.strUserName = "nouser";
            //    MmiGV.UserInfo.strUserPassword = "";
            //    MmiGV.UserInfo.iUserLevel = (int)MmiGV.eUserLevel.USER_LEVEL_NONE;
            //    SetMenuButtonEnable((int)MmiGV.eUserLevel.USER_LEVEL_NONE);
            //}
        }

        private void TimerSeqLink_Tick(object sender, EventArgs e)
        {
            IntPtr targetWindowHandle = WIN32Helper.FindWindow(null, "SEQApp");

            if (targetWindowHandle != IntPtr.Zero)
            {
                if (iSeqLinkCount > iSetSeqLinkCount)
                {
                    btnSEQLink.ImageIndex = 1;
                    bSeqLinked = false;
                }

                WIN32Helper.SendPostMessage(WIN32Helper.WM_APP_LINK_REQ, (uint)WIN32Helper.eMessageTarget.SEQ_MODULE);
                iSeqLinkCount++;
            }
            else
            {
                bSeqLinked = false;
                btnSEQLink.ImageIndex = 1;
            }
        }

        protected override void WndProc(ref Message message)
        {
            switch (message.Msg)
            {
                case var value when value == WIN32Helper.WM_COPYDATA:
                    WIN32Helper.COPYDATASTRUCT cp = (WIN32Helper.COPYDATASTRUCT)Marshal.PtrToStructure(message.LParam, typeof(WIN32Helper.COPYDATASTRUCT));
                    if(cp.dwData == WIN32Helper.WM_SEQ_TO_MMI_NOTIFY)
                    {
                        SEQ_NOTIFY_MSG notify_msg = (SEQ_NOTIFY_MSG)Marshal.PtrToStructure(cp.lpData, typeof(SEQ_NOTIFY_MSG));
                        frm_Msg.ShowMessage(notify_msg.strMsg);
                    }
                    //if (cp.dwData == WIN32helper.WM_LINK_TEST_REQ)
                    //{
                    //    //CSHARP_TEST test = (CSHARP_TEST)Marshal.PtrToStructure(cp.lpData, typeof(CSHARP_TEST));
                    //    //int size = Marshal.SizeOf(test);
                    //    //listView1.Items.Add(test.strLotID);
                    //    //listView1.Items.Add(test.nLotCount.ToString());
                    //    //WIN32helper.SendPostMessage(WIN32helper.WM_LINK_TEST_RSP, (uint)WIN32helper.eMessageTarget.MMI_MODULE);
                    //}
                    break;
                case var value when value == WIN32Helper.WM_APP_LINK_RSP:
                    iSeqLinkCount = 0;
                    bSeqLinked = true;
                    btnSEQLink.ImageIndex = 0;
                    break;
                default:

                    break;

            }

            base.WndProc(ref message);
        }

        public void UDPServerSeqLogThread()
        {
            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog != null);

            UdpClient udpClient = new UdpClient(9999);

            while (true)
            {
                IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIpEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                MMILog.AddSEQLog(returnData);
                //Console.WriteLine($"{returnData}");
            }
        }

        public void SaveDM()
        {
            string strSQL1 = "";
            string strSQL2 = "";

            strSQL1 = "SELECT * FROM DATAMEM ORDER BY IDX ASC";
            bool bVal;

            if (SQLiteDB.Select(strSQL1, ref SQLiteDB.ReaderDM))
            {
                while (SQLiteDB.ReaderDM.Read())
                {
                    int iIdx = int.TryParse(SQLiteDB.ReaderDM["IDX"].ToString(), out iIdx) ? iIdx : 0;
                    bVal = (SQLiteDB.ReaderDM["DMSAVE"].ToString() == "1") ? true : false;
                    if (bVal)
                    {
                        strSQL2 = "UPDATE DATAMEM SET ";
                        strSQL2 += "DMVALUE= ";
                        strSQL2 += MmiGV.dmData.DMValue[iIdx].ToString();
                        strSQL2 += " WHERE IDX=" + iIdx.ToString();
                        if (SQLiteDB.Execute(strSQL2))
                        {
                            // MessageBox.Show("저장되었습니다");
                        }
                    }
                }
            }
            SQLiteDB.ReaderDM.Close();
        }

        void SaveUseSkip()
        {
            string strSQL = "";

            strSQL = "UPDATE USESKIP SET ";
            strSQL += " USESKIP1 =" + MmiGV.pShMem.GetDM(16).ToString() + ",";
            strSQL += " USESKIP2 =" + MmiGV.pShMem.GetDM(17).ToString();
            strSQL += " WHERE IDX =1";

            if (SQLiteDB.Execute(strSQL))
            {
                // MessageBox.show("저장되었습니다");
            }
        }

        private void pictureEMO_Click(object sender, EventArgs e)
        {
            MmiGV.pShMem.SetEStop();
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {
            MmiGV.pShMem.SetBuzzerOff();
        }
    }
}
