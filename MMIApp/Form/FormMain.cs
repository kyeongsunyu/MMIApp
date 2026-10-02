using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace MMI
{
    // L11 main frame.
    //
    //   top bar      machine, device, SEQ / peripheral / SECS-GEM links, user,
    //                and the frame-wide commands (EMO, reset, buzzer, ten key)
    //   alarm banner the current alarm, always in the same place
    //   rail         one entry per screen group
    //   sub menu     the screens inside the selected group, shown only when
    //                the group has more than one
    //   content      the screen itself
    //
    // Every screen is a Form parented into pnlContent with TopLevel off, and
    // the frame switches between them. The screen number written to DM 7 and
    // read by CThreadMain is the same number the old menu forms used, so the
    // polling side did not have to change.
    public partial class FormMain : Form
    {
        #region FORM_DEFINE
        public Form_Language    frm_Language;

        public FormAuto1        frmAuto1;
        public FormAuto2        frmAuto2;

        public FormManualList   frmManualList;
        public FormManualOP     frmManualOP;

        public FormMotorSetting frmMotorSetting;
        public FormScanTrigger  frmScanTrigger;

        public FormDataRecipe   frmDataRecipe;
        public FormDataSystem   frmDataSystem;
        public FormDataLifeTime frmDataLifeTime;
        public FormDataOption   frmDataOption;
        public FormDataLampBuzzer frmDataLampBuzzer;
        public FormDataUserRegist frmDataUserRegist;
        public FormDataMotorCFG frmDataMotorCFG;

        public FormMonitorIO    frmMonitorIO;
        public FormMonitorBitDM frmMonitorBitDM;

        public FormAlarmList    frmAlarmList;

        public FormLog          frmLog;
        public FormLogError     frmLogError;
        public FormLogMTBA      frmLogMTBA;

        public FormCalibration  frmCalib;
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

        // The rail groups. The values are the old main menu tags, which the
        // screen numbers are built on: screen 41 lives in group 4.
        private enum eScreenGroup
        {
            AUTO    = 1,
            MANUAL  = 2,
            MOTOR   = 3,
            DATA    = 4,
            MONITOR = 5,
            ALARM   = 6,
            LOG     = 7,
            CALIB   = 8,
        }

        private sealed class ScreenEntry
        {
            public int ScreenNo;
            public string Caption;
            public Form Screen;
        }

        private readonly Dictionary<int, ScreenEntry> m_dicScreen = new Dictionary<int, ScreenEntry>();
        private readonly Dictionary<int, int> m_dicLastScreenOfGroup = new Dictionary<int, int>();
        private readonly Dictionary<int, FlowLayoutPanel> m_dicSubMenu = new Dictionary<int, FlowLayoutPanel>();
        private ScreenEntry m_CurScreen = null;

        bool bIsShowConsole = false;

        private int iSeqLinkCount = 0;
        private int iSetSeqLinkCount = 2;
        private bool bSeqLinked = false;

        DateTime dtUserLevelStartTime;
        DateTime dtStartConsoleShow;

        private CFileLog FileLog = CFileLog.GetInstance;

        public UDP_Server udp_server = new UDP_Server();

        public FormMain()
        {
            InitializeComponent();

            MmiGV.frmMain = this;
            CPopup.Owner = this;

            this.Text = "MMIApp";
            FormInitialize();
        }

        private void FormInitialize()
        {
            frmAuto1 = new FormAuto1(this);
            frmAuto2 = new FormAuto2(this);

            frmManualList = new FormManualList(this);
            frmManualOP = new FormManualOP(this);

            frmMotorSetting = new FormMotorSetting(this);
            frmScanTrigger = new FormScanTrigger(this);

            frmDataRecipe = new FormDataRecipe(this);
            frmDataSystem = new FormDataSystem(this);
            frmDataLifeTime = new FormDataLifeTime(this);
            frmDataOption = new FormDataOption(this);
            frmDataLampBuzzer = new FormDataLampBuzzer(this);
            frmDataUserRegist = new FormDataUserRegist(this);
            frmDataMotorCFG = new FormDataMotorCFG(this);

            frmMonitorIO = new FormMonitorIO(this);
            frmMonitorBitDM = new FormMonitorBitDM(this);

            frmAlarmList = new FormAlarmList(this);

            frmLog = new FormLog(this);
            frmLogError = new FormLogError(this);
            frmLogMTBA = new FormLogMTBA(this);

            frmCalib = new FormCalibration(this);

            RegisterScreen((int)MmiGV.eSCRNO.AUTO1,             "PRODUCTION",    frmAuto1);
            RegisterScreen((int)MmiGV.eSCRNO.AUTO2,             "AUTO 2",        frmAuto2);
            RegisterScreen((int)MmiGV.eSCRNO.MANUAL_LIST,       "MANUAL LIST",   frmManualList);
            RegisterScreen((int)MmiGV.eSCRNO.MANUAL_OP,         "MANUAL OP",     frmManualOP);
            RegisterScreen((int)MmiGV.eSCRNO.MOTOR_SETTING,     "MOTOR SETTING", frmMotorSetting);
            RegisterScreen((int)MmiGV.eSCRNO.MOTOR_SCANTRIGGER, "SCAN TRIGGER",  frmScanTrigger);
            RegisterScreen((int)MmiGV.eSCRNO.DATA_RECIPE,       "DATA_RECIPE",   frmDataRecipe);
            RegisterScreen((int)MmiGV.eSCRNO.DATA_SYSTEM,       "SYSTEM DATA",   frmDataSystem);
            RegisterScreen((int)MmiGV.eSCRNO.DATA_OPTION,       "DATA_OPTION",   frmDataOption);
            RegisterScreen((int)MmiGV.eSCRNO.DATA_LAMPBUZZER,   "DATA_LAMPBUZZER", frmDataLampBuzzer);
            RegisterScreen((int)MmiGV.eSCRNO.DATA_USERREGIST,   "DATA_USERREGIST", frmDataUserRegist);
            RegisterScreen((int)MmiGV.eSCRNO.DATA_MOTOR_CONFIG, "DATA_MOTOR_CONFIG", frmDataMotorCFG);
            RegisterScreen((int)MmiGV.eSCRNO.DATA_LIFETIME,     "LIFE TIME",     frmDataLifeTime);
            RegisterScreen((int)MmiGV.eSCRNO.MONITOR_IO,        "MONITOR_IO",    frmMonitorIO);
            RegisterScreen((int)MmiGV.eSCRNO.MONITOR_DMBIT,     "MONITOR_DMBIT", frmMonitorBitDM);
            RegisterScreen((int)MmiGV.eSCRNO.ALARM_LIST,        "ALARM_LIST",    frmAlarmList);
            RegisterScreen((int)MmiGV.eSCRNO.LOG,               "LOG",           frmLog);
            RegisterScreen((int)MmiGV.eSCRNO.LOG_ERROR,         "LOG_ERROR",     frmLogError);
            RegisterScreen((int)MmiGV.eSCRNO.LOG_MTBAMTBF,      "LOG_MTBAMTBF",  frmLogMTBA);
            RegisterScreen((int)MmiGV.eSCRNO.CALIB,             "TEACH",         frmCalib);

            m_dicSubMenu[(int)eScreenGroup.AUTO]    = flpSubAuto;
            m_dicSubMenu[(int)eScreenGroup.MANUAL]  = flpSubManual;
            m_dicSubMenu[(int)eScreenGroup.MOTOR]   = flpSubMotor;
            m_dicSubMenu[(int)eScreenGroup.DATA]    = flpSubData;
            m_dicSubMenu[(int)eScreenGroup.MONITOR] = flpSubIO;
            m_dicSubMenu[(int)eScreenGroup.LOG]     = flpSubLog;

            #region SUB_FORM
            // The pop-ups are the single instances CPopup keeps; the fields
            // are there so existing code can keep reaching them through the
            // frame.
            frm_NumAdd      = CPopup.Get<Form_NumAdd>();
            frm_NumPad      = CPopup.Get<Form_NumPad>();
            frm_DataCopy    = CPopup.Get<Form_DataCopy>();
            frm_MotorCalc   = CPopup.Get<Form_MotorCalc>();
            frm_PM          = CPopup.Get<Form_PM>();

            frm_PWD         = CPopup.Get<Form_PWD>();
            frm_PWD.TopMost = true;
            frm_PWD.TopLevel = true;

            frm_UserLogIn   = CPopup.Get<Form_UserLogIn>();
            frm_Msg         = CPopup.Get<Form_Msg>();
            frm_SystemInit  = CPopup.Get<Form_SystemInit>();
            frm_Language    = CPopup.Get<Form_Language>();

            // Not a pop-up: the laser panel lives in a tab of the Auto screen
            // and floats out of it on request.
            frm_Laser = new Form_Laser();
            frm_Laser.TopLevel = false;
            frm_Laser.Visible = true;
            frm_Laser.Parent = frmAuto1.tcComm;

            frm_LotInput = CPopup.Get<Form_LotInput>();
            frm_LotInput.TopMost = true;
            frm_LotInput.TopLevel = true;

            frmLogHistory = CPopup.Get<FormLogHistory>();
            #endregion SUB_FORM

            ShowScreen((int)MmiGV.eSCRNO.AUTO1, false);

            // The standard asks for the program to come up logged in as an
            // operator rather than with every screen locked.
            LogInAsOperator();
        }

        private void RegisterScreen(int nScreenNo, string strCaption, Form frm)
        {
            frm.TopLevel = false;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.AutoScroll = true;
            frm.Visible = false;
            pnlContent.Controls.Add(frm);

            HmiTheme.Apply(frm);
            CKeyboard.Attach(frm);
            // Some screens add controls in their Load (the IO channel combos
            // go onto the grid there), so theme again once that has run.
            frm.Load += (s, e) =>
            {
                HmiTheme.Apply(frm);
                CKeyboard.Attach(frm);
            };

            m_dicScreen[nScreenNo] = new ScreenEntry
            {
                ScreenNo = nScreenNo,
                Caption = strCaption,
                Screen = frm,
            };

            int nGroup = GroupOf(nScreenNo);
            if (!m_dicLastScreenOfGroup.ContainsKey(nGroup))
            {
                m_dicLastScreenOfGroup[nGroup] = nScreenNo;
            }
        }

        // 41 -> 4, 8 -> 8. Teach is a single digit screen number of its own.
        private static int GroupOf(int nScreenNo)
        {
            return (nScreenNo >= 10) ? nScreenNo / 10 : nScreenNo;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SQLiteDB.Open();

            // Before anything reads the DEVICE table: machines built before the
            // scan trigger have no columns for it.
            CRcpMaterial.EnsureScanTriggerColumns();
            FormDataLifeTime.EnsureItemNames();
            EnsurePasswordLevel((int)MmiGV.eSCRNO.DATA_LIFETIME, "LIFE TIME", 2);

            CRecipeCtl.SetMainForm(this);
            //add by chs
            CRecipeCtl.MainRecipeLoad();

            OpenConfigFile();

            MmiGV.bProgramExit = false;

            CThread.ThreadMain = new Thread(() => { CThreadMain.ExecuteMainThred(); });
            CThread.CreateThread(CThread.ThreadMain, ThreadPriority.Normal);

            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog!=null);

            CThread.ThreadMMILogMsg = new Thread(() => { MMILog.ExcuteMMILogMsg(); });
            CThread.CreateThread(CThread.ThreadMMILogMsg, ThreadPriority.Normal);

            udp_server.StartAsServer("127.0.0.1", "9999");

            CLogRetention.Start();
        }

        // Form_PWD refuses a screen that has no PWDLEVEL row, so a screen added
        // after the DB was made gets its row here.
        private static void EnsurePasswordLevel(int nScreenNo, string strName, int nUserLevel)
        {
            if (SQLiteDB.RecCount("SELECT COUNT(*) FROM PWDLEVEL WHERE SCR_INDEX = " + nScreenNo) != 0) return;
            SQLiteDB.Execute("INSERT INTO PWDLEVEL (SCR_INDEX, SCR_NAME, ITEM_INDEX, USER_LEVEL) VALUES ("
                           + nScreenNo + ", '" + strName + "', " + nScreenNo + ", " + nUserLevel + ")");
        }

        public void DisplayCurDevice()
        {
            string strDevice;
            strDevice = "[" + string.Format("{0:D3}", MmiGV.iDevNo) + "] ";
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

                CLogRetention.Stop();
                MmiGV.bProgramExit = true;
                MmiGV.pShMem.SetExitProgram();

                Thread.Sleep(2000);

                e.Cancel = false;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            SQLiteDB.Close();
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

        #region NAVIGATION

        // Rail entry: back to whichever screen of that group was open last.
        private void btnMenuClick(object sender, EventArgs e)
        {
            int nGroup = Convert.ToInt32(((Control)sender).Tag);

            int nScreenNo;
            if (!m_dicLastScreenOfGroup.TryGetValue(nGroup, out nScreenNo)) return;

            ShowScreen(nScreenNo, true);
        }

        private void btnSubMenuClick(object sender, EventArgs e)
        {
            ShowScreen(Convert.ToInt32(((Control)sender).Tag), true);
        }

        public void ShowScreen(int nScreenNo, bool bLog)
        {
            ScreenEntry next;
            if (!m_dicScreen.TryGetValue(nScreenNo, out next)) return;
            if (next == m_CurScreen) return;

            // Motor config has been behind a fixed code since before the
            // standard; it stays behind it rather than behind the user level.
            if (nScreenNo == (int)MmiGV.eSCRNO.DATA_MOTOR_CONFIG)
            {
                if (!frm_NumPad.Display()) return;
                if (frm_NumPad.GetValue() != 4899) return;
            }

            if (nScreenNo == (int)MmiGV.eSCRNO.CALIB)
            {
                frmCalib.Load3Point();
            }

            if (m_CurScreen != null)
            {
                m_CurScreen.Screen.Visible = false;
            }

            // The frame's own state moves first. Showing a screen the first
            // time runs its Load, and a Load that throws would otherwise leave
            // the rail pointing at one screen and another one on display.
            m_CurScreen = next;
            int nGroup = GroupOf(nScreenNo);
            m_dicLastScreenOfGroup[nGroup] = nScreenNo;

            UpdateRail(nGroup);
            UpdateSubMenu(nGroup, nScreenNo);

            if (frmMotorSetting != null && frmMotorSetting.bTenkeyJogMode)
            {
                frmMotorSetting.bTenkeyJogMode = false;
                frmMotorSetting.btnTenkeyJog.Checked = false;
                MmiGV.pShMem.SetTenKeyJog(MmiGV.iCurrAxis, frmMotorSetting.bTenkeyJogMode);
            }

            MmiGV.iScreenNo = nScreenNo;
            if (MmiGV.pShMem != null)
            {
                MmiGV.pShMem.SetDM(7, (uint)MmiGV.iScreenNo);
            }

            if (bLog)
            {
                CThreadMMILog MMILog = CThreadMMILog.GetInstance;
                MMILog.AddMMILog("Change Screen : " + next.Caption);
            }

            next.Screen.BringToFront();
            next.Screen.Visible = true;
        }

        private void UpdateRail(int nGroup)
        {
            foreach (Control c in pnlRail.Controls)
            {
                HmiRailButton btn = c as HmiRailButton;
                if (btn == null) continue;
                btn.Checked = (Convert.ToInt32(btn.Tag) == nGroup);
            }
        }

        private void UpdateSubMenu(int nGroup, int nScreenNo)
        {
            FlowLayoutPanel flp;
            bool bHasSub = m_dicSubMenu.TryGetValue(nGroup, out flp);

            pnlSubMenu.Visible = bHasSub;
            if (!bHasSub) return;

            foreach (FlowLayoutPanel other in m_dicSubMenu.Values)
            {
                other.Visible = (other == flp);
            }
            foreach (Control c in flp.Controls)
            {
                HmiButton btn = c as HmiButton;
                if (btn == null) continue;
                btn.Checked = (Convert.ToInt32(btn.Tag) == nScreenNo);
            }

            foreach (Control c in pnlRail.Controls)
            {
                if (Convert.ToInt32(c.Tag) == nGroup) lblSubTitle.Text = c.Text.ToUpper();
            }
        }

        #endregion NAVIGATION

        #region ALARM_BANNER

        // The banner is the one place the current alarm is shown. Grey and
        // quiet with no alarm; red with the code and the message when there is
        // one. Clicking it opens the alarm screen for the trouble shooting.
        public void ShowAlarm(uint uCode, string strName, string strMessage)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowAlarm(uCode, strName, strMessage)));
                return;
            }

            if (uCode == 0)
            {
                pnlAlarmBanner.BackColor = Color.FromArgb(0x1E, 0x21, 0x25);
                lblAlarmStripe.BackColor = HmiTheme.TextDisabled;
                lblError.ForeColor = HmiTheme.TextMuted;
                lblError.Text = CLanguage.Text("No Alarm");
                lblErrorMessage.ForeColor = HmiTheme.TextMuted;
                lblErrorMessage.Text = "";
                return;
            }

            pnlAlarmBanner.BackColor = HmiTheme.AlarmBanner;
            lblAlarmStripe.BackColor = HmiTheme.Alarm;
            lblError.ForeColor = HmiTheme.Alarm;
            lblError.Text = CLanguage.Text("Alarm") + $": E{uCode:0000}";
            lblErrorMessage.ForeColor = HmiTheme.AlarmBannerText;
            lblErrorMessage.Text = string.IsNullOrEmpty(strMessage) ? strName : strName + "  -  " + strMessage;
        }

        // System initialisation borrows the banner for its progress text.
        public void ShowBannerText(string strText)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowBannerText(strText)));
                return;
            }
            lblError.ForeColor = HmiTheme.Accent;
            lblError.Text = CLanguage.Text("System");
            lblErrorMessage.ForeColor = HmiTheme.Text;
            lblErrorMessage.Text = strText;
        }

        private void lblErrorMessage_Click(object sender, EventArgs e)
        {
            if (MmiGV.iErrorCode == 0) return;
            if (!btnMenuAlarm.Enabled) return;
            ShowScreen((int)MmiGV.eSCRNO.ALARM_LIST, true);
        }

        #endregion ALARM_BANNER

        #region USER_LEVEL

        private void SetMenuButtonEnable(int iLevel)
        {
            bool bOperator    = iLevel >= (int)MmiGV.eUserLevel.USER_LEVEL_OPERATOR;
            bool bMaintenance = iLevel >= (int)MmiGV.eUserLevel.USER_LEVEL_MAINTENANCE;
            bool bEngineer    = iLevel >= (int)MmiGV.eUserLevel.USER_LEVEL_ENGINEER;

            btnMenuAuto.Enabled    = true;
            btnMenuManual.Enabled  = bMaintenance;
            btnMenuMotor.Enabled   = bEngineer;
            btnMenuData.Enabled    = bOperator;
            btnMenuMonitor.Enabled = bOperator;
            btnMenuAlarm.Enabled   = bOperator;
            btnMenuLog.Enabled     = bOperator;
            btnMenuCalib.Enabled   = bEngineer;
            btnTenKey.Enabled      = bOperator;

            btnSubRecipe.Enabled      = bOperator;
            btnSubSysData.Enabled     = bEngineer;
            btnSubUseSkip.Enabled     = bEngineer;
            btnSubLampBuzzer.Enabled  = bEngineer;
            btnSubUserRegist.Enabled  = bEngineer;
            btnSubMotorCfg.Enabled    = bEngineer;
            btnSubLifeTime.Enabled    = bMaintenance;

            TimerUserLevel.Enabled = (iLevel != (int)MmiGV.eUserLevel.USER_LEVEL_NONE);

            // A level that cannot see the screen in front of it goes back to
            // the production screen rather than leaving it on display.
            if (m_CurScreen != null)
            {
                Control rail = RailOf(GroupOf(m_CurScreen.ScreenNo));
                if (rail != null && !rail.Enabled)
                {
                    ShowScreen((int)MmiGV.eSCRNO.AUTO1, true);
                }
            }
        }

        private Control RailOf(int nGroup)
        {
            foreach (Control c in pnlRail.Controls)
            {
                if (Convert.ToInt32(c.Tag) == nGroup) return c;
            }
            return null;
        }

        private static string UserLevelText(int iLevel)
        {
            switch (iLevel)
            {
                case (int)MmiGV.eUserLevel.USER_LEVEL_OPERATOR:    return CLanguage.Text("Operator");
                case (int)MmiGV.eUserLevel.USER_LEVEL_MAINTENANCE: return CLanguage.Text("Maintenance");
                case (int)MmiGV.eUserLevel.USER_LEVEL_ENGINEER:    return CLanguage.Text("Engineer");
                case (int)MmiGV.eUserLevel.USER_LEVEL_MASTER:      return CLanguage.Text("Master");
                default: return CLanguage.Text("No User");
            }
        }

        private void ShowUser()
        {
            lblUserName.Text = "● " + UserLevelText(MmiGV.UserInfo.iUserLevel)
                             + "  " + MmiGV.UserInfo.strUserName;
        }

        private void LogInAsOperator()
        {
            MmiGV.UserInfo.iUserLevel = (int)MmiGV.eUserLevel.USER_LEVEL_OPERATOR;
            MmiGV.UserInfo.strUserName = "OPERATOR";

            btnUserLogIn.Checked = false;
            btnUserLogIn.Text = CLanguage.Text("Log In");
            dtUserLevelStartTime = DateTime.Now;

            SetMenuButtonEnable(MmiGV.UserInfo.iUserLevel);
            ShowUser();

            if (MmiGV.pShMem != null)
            {
                MmiGV.pShMem.WUserInfo.strUserName = MmiGV.UserInfo.strUserName;
                MmiGV.pShMem.SetUserInfo();
            }
        }

        // Log In raises the level from the operator default; Log Out drops it
        // back to operator, never below.
        private void btnUserLogIn_Click(object sender, EventArgs e)
        {
            if (btnUserLogIn.Checked)
            {
                LogInAsOperator();
                return;
            }

            if (frm_UserLogIn.DISPLAY((int)MmiGV.eFormShowMode.MODAL))
            {
                btnUserLogIn.Checked = true;
                btnUserLogIn.Text = CLanguage.Text("Log Out");

                dtUserLevelStartTime = DateTime.Now;
                SetMenuButtonEnable(MmiGV.UserInfo.iUserLevel);
                ShowUser();

                MmiGV.pShMem.WUserInfo.strUserName = MmiGV.UserInfo.strUserName;
                MmiGV.pShMem.SetUserInfo();
            }
        }

        private void TimerUserLevel_Tick(object sender, EventArgs e)
        {
            TimeSpan tsDiff = DateTime.Now - dtUserLevelStartTime;
            lblUserTime.Text = tsDiff.ToString(@"hh\:mm\:ss");
        }

        #endregion USER_LEVEL

        private void btnTenKey_Click(object sender, EventArgs e)
        {
            frm_TenKey = CPopup.Show<Form_TenKey>();
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

            // The System Data settings: machine name, log keep period, life
            // time warning, keyboard and start-up language.
            CSystemConfig.Load();
            ApplySystemConfig();
            SetLanguage(CSystemConfig.Language);
        }

        // Puts the System Data settings into effect. Called at start-up and
        // again when System Data applies a change.
        public void ApplySystemConfig()
        {
            lblMachine.Text = CSystemConfig.MachineName;
        }

        #region LANGUAGE

        // Lang on the top bar: switches the captions for this session. The
        // language the program starts in is set on System Data.
        private void btnLanguageSET_Click(object sender, EventArgs e)
        {
            string strLanguage;
            if (!frm_Language.Choose(CLanguage.Current, out strLanguage)) return;
            if (strLanguage == CLanguage.Current) return;

            CThreadMMILog.GetInstance.AddMMILog("Language " + CLanguage.Current + " -> " + strLanguage);
            SetLanguage(strLanguage);
        }

        public void SetLanguage(string strLanguage)
        {
            CLanguage.Load(strLanguage);

            CLanguage.Apply(this);
            foreach (ScreenEntry entry in m_dicScreen.Values)
            {
                CLanguage.Apply(entry.Screen);
            }
            foreach (Form popup in CPopup.All)
            {
                CLanguage.Apply(popup);
            }
            CLanguage.Apply(frm_Laser);

            // The captions the frame sets in code.
            btnUserLogIn.Text = CLanguage.Text(btnUserLogIn.Checked ? "Log Out" : "Log In");
            ShowUser();
            ShowSeqLink(bSeqLinked);
            if (MmiGV.iErrorCode == 0) ShowAlarm(0, "", "");

            CLanguage.RaiseChanged();
        }

        #endregion LANGUAGE

        private void btnRESET_Click(object sender, EventArgs e)
        {
            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog != null);

            MmiGV.pShMem.SetTenKey(0);
            MMILog.AddMMILog(((Control)sender).Text + " Clicked");
        }

        #region LINK_STATUS

        private void ShowSeqLink(bool bLinked)
        {
            lblSeqLink.Text = "● " + CLanguage.Text(bLinked ? "SEQ: Connected" : "SEQ: Disconnected");
            lblSeqLink.ForeColor = bLinked ? HmiTheme.Text : HmiTheme.Alarm;
        }

        // Peripheral and SECS/GEM states are set by whichever module owns the
        // connection. Until EzGem is wired in, SECS/GEM reads Offline.
        public void ShowPeripheralLink(string strName, bool bConnected)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowPeripheralLink(strName, bConnected)));
                return;
            }
            lblPeripheral.Text = "● " + strName + (bConnected ? ": OK" : ": NG");
            lblPeripheral.ForeColor = bConnected ? HmiTheme.Text : HmiTheme.Alarm;
        }

        public void ShowSecsGemState(string strState, bool bOnline)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action(() => ShowSecsGemState(strState, bOnline)));
                return;
            }
            lblSecsGem.Text = "● SECS/GEM: " + CLanguage.Text(strState);
            lblSecsGem.ForeColor = bOnline ? HmiTheme.Text : HmiTheme.TextMuted;
        }

        private void TimerSeqLink_Tick(object sender, EventArgs e)
        {
            IntPtr targetWindowHandle = WIN32Helper.FindWindow(null, "SEQApp");

            if (targetWindowHandle != IntPtr.Zero)
            {
                if (iSeqLinkCount > iSetSeqLinkCount)
                {
                    bSeqLinked = false;
                    ShowSeqLink(false);
                }

                WIN32Helper.SendPostMessage(WIN32Helper.WM_APP_LINK_REQ, (uint)WIN32Helper.eMessageTarget.SEQ_MODULE);
                iSeqLinkCount++;
            }
            else
            {
                bSeqLinked = false;
                ShowSeqLink(false);
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
                    break;
                case var value when value == WIN32Helper.WM_APP_LINK_RSP:
                    iSeqLinkCount = 0;
                    bSeqLinked = true;
                    ShowSeqLink(true);
                    break;
                default:
                    break;
            }

            base.WndProc(ref message);
        }

        #endregion LINK_STATUS

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
                        SQLiteDB.Execute(strSQL2);
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

            SQLiteDB.Execute(strSQL);
        }

        private void btnEMO_Click(object sender, EventArgs e)
        {
            MmiGV.pShMem.SetEStop();
        }

        private void btnBuzzerOff_Click(object sender, EventArgs e)
        {
            MmiGV.pShMem.SetBuzzerOff();
        }
    }
}
