namespace MMI
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnlTopBar = new System.Windows.Forms.Panel();
            this.pnlAlarmBanner = new System.Windows.Forms.Panel();
            this.pnlRail = new System.Windows.Forms.Panel();
            this.pnlSubMenu = new System.Windows.Forms.Panel();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.TimerUserLevel = new System.Windows.Forms.Timer(this.components);
            this.TimerSeqLink = new System.Windows.Forms.Timer(this.components);
            this.timerConsole = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.flpTopButtons = new System.Windows.Forms.FlowLayoutPanel();
            this.flpTopStatus = new System.Windows.Forms.FlowLayoutPanel();
            this.lblMachine = new System.Windows.Forms.Label();
            this.lblDeviceCaption = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.lblSeqLinkDot = new System.Windows.Forms.Label();
            this.lblSeqLink = new System.Windows.Forms.Label();
            this.lblPeripheralDot = new System.Windows.Forms.Label();
            this.lblPeripheral = new System.Windows.Forms.Label();
            this.lblSecsGemDot = new System.Windows.Forms.Label();
            this.lblSecsGem = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserTime = new System.Windows.Forms.Label();
            this.btnEMO = new MMI.HmiButton();
            this.btnRESET = new MMI.HmiButton();
            this.btnBuzzerOff = new MMI.HmiButton();
            this.btnTenKey = new MMI.HmiButton();
            this.btnPM = new MMI.HmiButton();
            this.btnLanguageSET = new MMI.HmiButton();
            this.btnUserLogIn = new MMI.HmiButton();
            this.lblAlarmStripe = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.btnMenuAuto = new MMI.HmiRailButton();
            this.btnMenuManual = new MMI.HmiRailButton();
            this.btnMenuMotor = new MMI.HmiRailButton();
            this.btnMenuData = new MMI.HmiRailButton();
            this.btnMenuMonitor = new MMI.HmiRailButton();
            this.btnMenuAlarm = new MMI.HmiRailButton();
            this.btnMenuLog = new MMI.HmiRailButton();
            this.btnMenuCalib = new MMI.HmiRailButton();
            this.lblSubTitle = new System.Windows.Forms.Label();
            this.flpSubAuto = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSubAuto1 = new MMI.HmiButton();
            this.btnSubTrigger = new MMI.HmiButton();
            this.flpSubManual = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSubManualList = new MMI.HmiButton();
            this.btnSubManualOP = new MMI.HmiButton();
            this.flpSubData = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSubRecipe = new MMI.HmiButton();
            this.btnSubSysData = new MMI.HmiButton();
            this.btnSubUseSkip = new MMI.HmiButton();
            this.btnSubLifeTime = new MMI.HmiButton();
            this.btnSubLampBuzzer = new MMI.HmiButton();
            this.btnSubUserRegist = new MMI.HmiButton();
            this.btnSubMotorCfg = new MMI.HmiButton();
            this.flpSubIO = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSubIO = new MMI.HmiButton();
            this.btnSubBitDM = new MMI.HmiButton();
            this.flpSubLog = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSubLog = new MMI.HmiButton();
            this.btnSubErrorHistory = new MMI.HmiButton();
            this.btnSubMTBA = new MMI.HmiButton();
            this.showHideConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTopBar.SuspendLayout();
            this.pnlAlarmBanner.SuspendLayout();
            this.pnlRail.SuspendLayout();
            this.pnlSubMenu.SuspendLayout();
            this.pnlContent.SuspendLayout();
            this.flpTopButtons.SuspendLayout();
            this.flpTopStatus.SuspendLayout();
            this.flpSubAuto.SuspendLayout();
            this.flpSubManual.SuspendLayout();
            this.flpSubData.SuspendLayout();
            this.flpSubIO.SuspendLayout();
            this.flpSubLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTopBar
            // 
            this.pnlTopBar.Controls.Add(this.flpTopStatus);
            this.pnlTopBar.Controls.Add(this.flpTopButtons);
            this.pnlTopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(20)))), ((int)(((byte)(23)))));
            this.pnlTopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopBar.Size = new System.Drawing.Size(1920, 44);
            this.pnlTopBar.Padding = new System.Windows.Forms.Padding(12, 0, 6, 0);
            this.pnlTopBar.Name = "pnlTopBar";
            // 
            // pnlAlarmBanner
            // 
            this.pnlAlarmBanner.Controls.Add(this.lblErrorMessage);
            this.pnlAlarmBanner.Controls.Add(this.lblError);
            this.pnlAlarmBanner.Controls.Add(this.lblAlarmStripe);
            this.pnlAlarmBanner.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.pnlAlarmBanner.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlAlarmBanner.Size = new System.Drawing.Size(1920, 34);
            this.pnlAlarmBanner.Name = "pnlAlarmBanner";
            // 
            // pnlRail
            // 
            this.pnlRail.Controls.Add(this.btnMenuCalib);
            this.pnlRail.Controls.Add(this.btnMenuLog);
            this.pnlRail.Controls.Add(this.btnMenuAlarm);
            this.pnlRail.Controls.Add(this.btnMenuMonitor);
            this.pnlRail.Controls.Add(this.btnMenuData);
            this.pnlRail.Controls.Add(this.btnMenuMotor);
            this.pnlRail.Controls.Add(this.btnMenuManual);
            this.pnlRail.Controls.Add(this.btnMenuAuto);
            this.pnlRail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(24)))), ((int)(((byte)(27)))));
            this.pnlRail.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlRail.Size = new System.Drawing.Size(72, 1002);
            this.pnlRail.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pnlRail.Name = "pnlRail";
            // 
            // pnlSubMenu
            // 
            this.pnlSubMenu.Controls.Add(this.flpSubLog);
            this.pnlSubMenu.Controls.Add(this.flpSubIO);
            this.pnlSubMenu.Controls.Add(this.flpSubData);
            this.pnlSubMenu.Controls.Add(this.flpSubManual);
            this.pnlSubMenu.Controls.Add(this.flpSubAuto);
            this.pnlSubMenu.Controls.Add(this.lblSubTitle);
            this.pnlSubMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(34)))), ((int)(((byte)(38)))));
            this.pnlSubMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSubMenu.Size = new System.Drawing.Size(188, 1002);
            this.pnlSubMenu.Padding = new System.Windows.Forms.Padding(10, 6, 10, 6);
            this.pnlSubMenu.Name = "pnlSubMenu";
            // 
            // pnlContent
            // 
            this.pnlContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Size = new System.Drawing.Size(1660, 1002);
            this.pnlContent.Padding = new System.Windows.Forms.Padding(8);
            this.pnlContent.Name = "pnlContent";
            // 
            // TimerUserLevel
            // 
            this.TimerUserLevel.Interval = 1000;
            this.TimerUserLevel.Tick += new System.EventHandler(this.TimerUserLevel_Tick);
            // 
            // TimerSeqLink
            // 
            this.TimerSeqLink.Enabled = true;
            this.TimerSeqLink.Interval = 5000;
            this.TimerSeqLink.Tick += new System.EventHandler(this.TimerSeqLink_Tick);
            // 
            // timerConsole
            // 
            this.timerConsole.Interval = 10000;
            this.timerConsole.Tick += new System.EventHandler(this.timerConsole_Tick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideConsoleToolStripMenuItem});
            this.contextMenuStrip.Size = new System.Drawing.Size(182, 26);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.contextMenuStrip;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "MMIApp";
            this.TrayIcon.Visible = true;
            // 
            // flpTopButtons
            // 
            this.flpTopButtons.Controls.Add(this.btnEMO);
            this.flpTopButtons.Controls.Add(this.btnRESET);
            this.flpTopButtons.Controls.Add(this.btnBuzzerOff);
            this.flpTopButtons.Controls.Add(this.btnTenKey);
            this.flpTopButtons.Controls.Add(this.btnPM);
            this.flpTopButtons.Controls.Add(this.btnLanguageSET);
            this.flpTopButtons.Controls.Add(this.btnUserLogIn);
            this.flpTopButtons.AutoSize = true;
            this.flpTopButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpTopButtons.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flpTopButtons.WrapContents = false;
            this.flpTopButtons.Size = new System.Drawing.Size(574, 44);
            this.flpTopButtons.Margin = new System.Windows.Forms.Padding(0);
            this.flpTopButtons.Name = "flpTopButtons";
            // 
            // flpTopStatus
            // 
            this.flpTopStatus.Controls.Add(this.lblMachine);
            this.flpTopStatus.Controls.Add(this.lblDeviceCaption);
            this.flpTopStatus.Controls.Add(this.lblDevice);
            this.flpTopStatus.Controls.Add(this.lblSeqLinkDot);
            this.flpTopStatus.Controls.Add(this.lblSeqLink);
            this.flpTopStatus.Controls.Add(this.lblPeripheralDot);
            this.flpTopStatus.Controls.Add(this.lblPeripheral);
            this.flpTopStatus.Controls.Add(this.lblSecsGemDot);
            this.flpTopStatus.Controls.Add(this.lblSecsGem);
            this.flpTopStatus.Controls.Add(this.lblUserName);
            this.flpTopStatus.Controls.Add(this.lblUserTime);
            this.flpTopStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpTopStatus.WrapContents = false;
            this.flpTopStatus.Size = new System.Drawing.Size(1330, 44);
            this.flpTopStatus.Margin = new System.Windows.Forms.Padding(0);
            this.flpTopStatus.Name = "flpTopStatus";
            // 
            // lblMachine
            // 
            this.lblMachine.AutoSize = false;
            this.lblMachine.Size = new System.Drawing.Size(150, 44);
            this.lblMachine.Margin = new System.Windows.Forms.Padding(0);
            this.lblMachine.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMachine.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMachine.Text = "MMI";
            this.lblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMachine.Name = "lblMachine";
            // 
            // lblDeviceCaption
            // 
            this.lblDeviceCaption.AutoSize = false;
            this.lblDeviceCaption.Size = new System.Drawing.Size(76, 44);
            this.lblDeviceCaption.Margin = new System.Windows.Forms.Padding(0);
            this.lblDeviceCaption.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDeviceCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblDeviceCaption.Text = "Device";
            this.lblDeviceCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDeviceCaption.Name = "lblDeviceCaption";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = false;
            this.lblDevice.Size = new System.Drawing.Size(280, 44);
            this.lblDevice.Margin = new System.Windows.Forms.Padding(0);
            this.lblDevice.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblDevice.Text = "[00] -";
            this.lblDevice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDevice.Name = "lblDevice";
            // 
            // lblSeqLinkDot
            // 
            this.lblSeqLinkDot.AutoSize = false;
            this.lblSeqLinkDot.Size = new System.Drawing.Size(18, 44);
            this.lblSeqLinkDot.Margin = new System.Windows.Forms.Padding(0);
            this.lblSeqLinkDot.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSeqLinkDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(72)))), ((int)(((byte)(77)))));
            this.lblSeqLinkDot.Text = "●";
            this.lblSeqLinkDot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSeqLinkDot.Name = "lblSeqLinkDot";
            // 
            // lblSeqLink
            // 
            this.lblSeqLink.AutoSize = false;
            this.lblSeqLink.Size = new System.Drawing.Size(158, 44);
            this.lblSeqLink.Margin = new System.Windows.Forms.Padding(0);
            this.lblSeqLink.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSeqLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSeqLink.Text = "SEQ: Disconnected";
            this.lblSeqLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSeqLink.Name = "lblSeqLink";
            // 
            // lblPeripheralDot
            // 
            this.lblPeripheralDot.AutoSize = false;
            this.lblPeripheralDot.Size = new System.Drawing.Size(18, 44);
            this.lblPeripheralDot.Margin = new System.Windows.Forms.Padding(0);
            this.lblPeripheralDot.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPeripheralDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblPeripheralDot.Text = "●";
            this.lblPeripheralDot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPeripheralDot.Name = "lblPeripheralDot";
            // 
            // lblPeripheral
            // 
            this.lblPeripheral.AutoSize = false;
            this.lblPeripheral.Size = new System.Drawing.Size(158, 44);
            this.lblPeripheral.Margin = new System.Windows.Forms.Padding(0);
            this.lblPeripheral.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPeripheral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblPeripheral.Text = "Peripheral: -";
            this.lblPeripheral.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPeripheral.Name = "lblPeripheral";
            // 
            // lblSecsGemDot
            // 
            this.lblSecsGemDot.AutoSize = false;
            this.lblSecsGemDot.Size = new System.Drawing.Size(18, 44);
            this.lblSecsGemDot.Margin = new System.Windows.Forms.Padding(0);
            this.lblSecsGemDot.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecsGemDot.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(72)))), ((int)(((byte)(77)))));
            this.lblSecsGemDot.Text = "●";
            this.lblSecsGemDot.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSecsGemDot.Name = "lblSecsGemDot";
            // 
            // lblSecsGem
            // 
            this.lblSecsGem.AutoSize = false;
            this.lblSecsGem.Size = new System.Drawing.Size(178, 44);
            this.lblSecsGem.Margin = new System.Windows.Forms.Padding(0);
            this.lblSecsGem.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSecsGem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSecsGem.Text = "SECS/GEM: Offline";
            this.lblSecsGem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSecsGem.Name = "lblSecsGem";
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = false;
            this.lblUserName.Size = new System.Drawing.Size(230, 44);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(0);
            this.lblUserName.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblUserName.Text = "● Operator";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserName.Name = "lblUserName";
            // 
            // lblUserTime
            // 
            this.lblUserTime.AutoSize = false;
            this.lblUserTime.Size = new System.Drawing.Size(76, 44);
            this.lblUserTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblUserTime.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblUserTime.Text = "00:00:00";
            this.lblUserTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUserTime.Name = "lblUserTime";
            // 
            // btnEMO
            // 
            this.btnEMO.Size = new System.Drawing.Size(64, 32);
            this.btnEMO.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.btnEMO.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEMO.Text = "EMO";
            this.btnEMO.CornerRadius = 4;
            this.btnEMO.TabStop = false;
            this.btnEMO.Role = MMI.HmiButtonRole.Danger;
            this.btnEMO.Name = "btnEMO";
            this.btnEMO.Click += new System.EventHandler(this.btnEMO_Click);
            // 
            // btnRESET
            // 
            this.btnRESET.Size = new System.Drawing.Size(76, 32);
            this.btnRESET.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.btnRESET.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRESET.Text = "Reset";
            this.btnRESET.CornerRadius = 4;
            this.btnRESET.TabStop = false;
            this.btnRESET.Name = "btnRESET";
            this.btnRESET.Click += new System.EventHandler(this.btnRESET_Click);
            // 
            // btnBuzzerOff
            // 
            this.btnBuzzerOff.Size = new System.Drawing.Size(84, 32);
            this.btnBuzzerOff.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.btnBuzzerOff.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBuzzerOff.Text = "Buzzer Off";
            this.btnBuzzerOff.CornerRadius = 4;
            this.btnBuzzerOff.TabStop = false;
            this.btnBuzzerOff.Name = "btnBuzzerOff";
            this.btnBuzzerOff.Click += new System.EventHandler(this.btnBuzzerOff_Click);
            // 
            // btnTenKey
            // 
            this.btnTenKey.Size = new System.Drawing.Size(76, 32);
            this.btnTenKey.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.btnTenKey.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTenKey.Text = "Ten Key";
            this.btnTenKey.CornerRadius = 4;
            this.btnTenKey.TabStop = false;
            this.btnTenKey.Name = "btnTenKey";
            this.btnTenKey.Click += new System.EventHandler(this.btnTenKey_Click);
            // 
            // btnPM
            // 
            this.btnPM.Size = new System.Drawing.Size(56, 32);
            this.btnPM.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.btnPM.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPM.Text = "PM";
            this.btnPM.CornerRadius = 4;
            this.btnPM.TabStop = false;
            this.btnPM.Name = "btnPM";
            this.btnPM.Click += new System.EventHandler(this.btnPM_Click);
            // 
            // btnLanguageSET
            // 
            this.btnLanguageSET.Size = new System.Drawing.Size(76, 32);
            this.btnLanguageSET.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.btnLanguageSET.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLanguageSET.Text = "Lang";
            this.btnLanguageSET.CornerRadius = 4;
            this.btnLanguageSET.TabStop = false;
            this.btnLanguageSET.Name = "btnLanguageSET";
            this.btnLanguageSET.Click += new System.EventHandler(this.btnLanguageSET_Click);
            // 
            // btnUserLogIn
            // 
            this.btnUserLogIn.Size = new System.Drawing.Size(76, 32);
            this.btnUserLogIn.Margin = new System.Windows.Forms.Padding(6, 6, 0, 6);
            this.btnUserLogIn.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUserLogIn.Text = "Log In";
            this.btnUserLogIn.CornerRadius = 4;
            this.btnUserLogIn.TabStop = false;
            this.btnUserLogIn.Name = "btnUserLogIn";
            this.btnUserLogIn.Click += new System.EventHandler(this.btnUserLogIn_Click);
            // 
            // lblAlarmStripe
            // 
            this.lblAlarmStripe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(95)))), ((int)(((byte)(100)))), ((int)(((byte)(107)))));
            this.lblAlarmStripe.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblAlarmStripe.Size = new System.Drawing.Size(4, 34);
            this.lblAlarmStripe.Margin = new System.Windows.Forms.Padding(0);
            this.lblAlarmStripe.Name = "lblAlarmStripe";
            // 
            // lblError
            // 
            this.lblError.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblError.Size = new System.Drawing.Size(160, 34);
            this.lblError.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblError.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblError.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.lblError.Text = "No Alarm";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblError.Name = "lblError";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblErrorMessage.Size = new System.Drawing.Size(1756, 34);
            this.lblErrorMessage.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblErrorMessage.AutoEllipsis = true;
            this.lblErrorMessage.Text = "";
            this.lblErrorMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Click += new System.EventHandler(this.lblErrorMessage_Click);
            // 
            // btnMenuAuto
            // 
            this.btnMenuAuto.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuAuto.Size = new System.Drawing.Size(72, 64);
            this.btnMenuAuto.Glyph = "\uE768";
            this.btnMenuAuto.Text = "Auto";
            this.btnMenuAuto.Tag = "1";
            this.btnMenuAuto.TabStop = false;
            this.btnMenuAuto.Name = "btnMenuAuto";
            this.btnMenuAuto.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuManual
            // 
            this.btnMenuManual.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuManual.Size = new System.Drawing.Size(72, 64);
            this.btnMenuManual.Glyph = "\uE90F";
            this.btnMenuManual.Text = "Manual";
            this.btnMenuManual.Tag = "2";
            this.btnMenuManual.TabStop = false;
            this.btnMenuManual.Name = "btnMenuManual";
            this.btnMenuManual.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuMotor
            // 
            this.btnMenuMotor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuMotor.Size = new System.Drawing.Size(72, 64);
            this.btnMenuMotor.Glyph = "\uE713";
            this.btnMenuMotor.Text = "Motor";
            this.btnMenuMotor.Tag = "3";
            this.btnMenuMotor.TabStop = false;
            this.btnMenuMotor.Name = "btnMenuMotor";
            this.btnMenuMotor.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuData
            // 
            this.btnMenuData.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuData.Size = new System.Drawing.Size(72, 64);
            this.btnMenuData.Glyph = "\uE8F1";
            this.btnMenuData.Text = "Data";
            this.btnMenuData.Tag = "4";
            this.btnMenuData.TabStop = false;
            this.btnMenuData.Name = "btnMenuData";
            this.btnMenuData.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuMonitor
            // 
            this.btnMenuMonitor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuMonitor.Size = new System.Drawing.Size(72, 64);
            this.btnMenuMonitor.Glyph = "\uE9D9";
            this.btnMenuMonitor.Text = "IO";
            this.btnMenuMonitor.Tag = "5";
            this.btnMenuMonitor.TabStop = false;
            this.btnMenuMonitor.Name = "btnMenuMonitor";
            this.btnMenuMonitor.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuAlarm
            // 
            this.btnMenuAlarm.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuAlarm.Size = new System.Drawing.Size(72, 64);
            this.btnMenuAlarm.Glyph = "\uE7BA";
            this.btnMenuAlarm.Text = "Alarm";
            this.btnMenuAlarm.Tag = "6";
            this.btnMenuAlarm.TabStop = false;
            this.btnMenuAlarm.Name = "btnMenuAlarm";
            this.btnMenuAlarm.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuLog
            // 
            this.btnMenuLog.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuLog.Size = new System.Drawing.Size(72, 64);
            this.btnMenuLog.Glyph = "\uE81C";
            this.btnMenuLog.Text = "Log";
            this.btnMenuLog.Tag = "7";
            this.btnMenuLog.TabStop = false;
            this.btnMenuLog.Name = "btnMenuLog";
            this.btnMenuLog.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuCalib
            // 
            this.btnMenuCalib.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuCalib.Size = new System.Drawing.Size(72, 64);
            this.btnMenuCalib.Glyph = "\uE707";
            this.btnMenuCalib.Text = "Teach";
            this.btnMenuCalib.Tag = "8";
            this.btnMenuCalib.TabStop = false;
            this.btnMenuCalib.Name = "btnMenuCalib";
            this.btnMenuCalib.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // lblSubTitle
            // 
            this.lblSubTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubTitle.Size = new System.Drawing.Size(168, 40);
            this.lblSubTitle.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSubTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSubTitle.Text = "AUTO";
            this.lblSubTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSubTitle.Name = "lblSubTitle";
            // 
            // flpSubAuto
            // 
            this.flpSubAuto.Controls.Add(this.btnSubAuto1);
            this.flpSubAuto.Controls.Add(this.btnSubTrigger);
            this.flpSubAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSubAuto.Size = new System.Drawing.Size(168, 950);
            this.flpSubAuto.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSubAuto.WrapContents = false;
            this.flpSubAuto.Visible = false;
            this.flpSubAuto.Name = "flpSubAuto";
            // 
            // btnSubAuto1
            // 
            this.btnSubAuto1.Size = new System.Drawing.Size(168, 44);
            this.btnSubAuto1.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubAuto1.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubAuto1.Text = "Production";
            this.btnSubAuto1.Tag = "11";
            this.btnSubAuto1.TabStop = false;
            this.btnSubAuto1.Name = "btnSubAuto1";
            this.btnSubAuto1.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubTrigger
            // 
            this.btnSubTrigger.Size = new System.Drawing.Size(168, 44);
            this.btnSubTrigger.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubTrigger.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubTrigger.Text = "TRIGGER";
            this.btnSubTrigger.Tag = "12";
            this.btnSubTrigger.TabStop = false;
            this.btnSubTrigger.Name = "btnSubTrigger";
            this.btnSubTrigger.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // flpSubManual
            // 
            this.flpSubManual.Controls.Add(this.btnSubManualList);
            this.flpSubManual.Controls.Add(this.btnSubManualOP);
            this.flpSubManual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSubManual.Size = new System.Drawing.Size(168, 950);
            this.flpSubManual.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSubManual.WrapContents = false;
            this.flpSubManual.Visible = false;
            this.flpSubManual.Name = "flpSubManual";
            // 
            // btnSubManualList
            // 
            this.btnSubManualList.Size = new System.Drawing.Size(168, 44);
            this.btnSubManualList.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubManualList.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubManualList.Text = "List";
            this.btnSubManualList.Tag = "21";
            this.btnSubManualList.TabStop = false;
            this.btnSubManualList.Name = "btnSubManualList";
            this.btnSubManualList.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubManualOP
            // 
            this.btnSubManualOP.Size = new System.Drawing.Size(168, 44);
            this.btnSubManualOP.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubManualOP.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubManualOP.Text = "Operation";
            this.btnSubManualOP.Tag = "22";
            this.btnSubManualOP.TabStop = false;
            this.btnSubManualOP.Name = "btnSubManualOP";
            this.btnSubManualOP.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // flpSubData
            // 
            this.flpSubData.Controls.Add(this.btnSubRecipe);
            this.flpSubData.Controls.Add(this.btnSubSysData);
            this.flpSubData.Controls.Add(this.btnSubUseSkip);
            this.flpSubData.Controls.Add(this.btnSubLifeTime);
            this.flpSubData.Controls.Add(this.btnSubLampBuzzer);
            this.flpSubData.Controls.Add(this.btnSubUserRegist);
            this.flpSubData.Controls.Add(this.btnSubMotorCfg);
            this.flpSubData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSubData.Size = new System.Drawing.Size(168, 950);
            this.flpSubData.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSubData.WrapContents = false;
            this.flpSubData.Visible = false;
            this.flpSubData.Name = "flpSubData";
            // 
            // btnSubRecipe
            // 
            this.btnSubRecipe.Size = new System.Drawing.Size(168, 44);
            this.btnSubRecipe.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubRecipe.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubRecipe.Text = "Recipe";
            this.btnSubRecipe.Tag = "41";
            this.btnSubRecipe.TabStop = false;
            this.btnSubRecipe.Name = "btnSubRecipe";
            this.btnSubRecipe.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubSysData
            // 
            this.btnSubSysData.Size = new System.Drawing.Size(168, 44);
            this.btnSubSysData.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubSysData.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubSysData.Text = "System Data";
            this.btnSubSysData.Tag = "42";
            this.btnSubSysData.TabStop = false;
            this.btnSubSysData.Name = "btnSubSysData";
            this.btnSubSysData.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubUseSkip
            // 
            this.btnSubUseSkip.Size = new System.Drawing.Size(168, 44);
            this.btnSubUseSkip.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubUseSkip.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubUseSkip.Text = "USE / SKIP";
            this.btnSubUseSkip.Tag = "43";
            this.btnSubUseSkip.TabStop = false;
            this.btnSubUseSkip.Name = "btnSubUseSkip";
            this.btnSubUseSkip.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubLifeTime
            // 
            this.btnSubLifeTime.Size = new System.Drawing.Size(168, 44);
            this.btnSubLifeTime.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubLifeTime.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubLifeTime.Text = "Life Time";
            this.btnSubLifeTime.Tag = "47";
            this.btnSubLifeTime.TabStop = false;
            this.btnSubLifeTime.Name = "btnSubLifeTime";
            this.btnSubLifeTime.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubLampBuzzer
            // 
            this.btnSubLampBuzzer.Size = new System.Drawing.Size(168, 44);
            this.btnSubLampBuzzer.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubLampBuzzer.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubLampBuzzer.Text = "Lamp Buzzer";
            this.btnSubLampBuzzer.Tag = "44";
            this.btnSubLampBuzzer.TabStop = false;
            this.btnSubLampBuzzer.Name = "btnSubLampBuzzer";
            this.btnSubLampBuzzer.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubUserRegist
            // 
            this.btnSubUserRegist.Size = new System.Drawing.Size(168, 44);
            this.btnSubUserRegist.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubUserRegist.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubUserRegist.Text = "User Regist";
            this.btnSubUserRegist.Tag = "45";
            this.btnSubUserRegist.TabStop = false;
            this.btnSubUserRegist.Name = "btnSubUserRegist";
            this.btnSubUserRegist.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubMotorCfg
            // 
            this.btnSubMotorCfg.Size = new System.Drawing.Size(168, 44);
            this.btnSubMotorCfg.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubMotorCfg.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubMotorCfg.Text = "Motor Config";
            this.btnSubMotorCfg.Tag = "46";
            this.btnSubMotorCfg.TabStop = false;
            this.btnSubMotorCfg.Name = "btnSubMotorCfg";
            this.btnSubMotorCfg.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // flpSubIO
            // 
            this.flpSubIO.Controls.Add(this.btnSubIO);
            this.flpSubIO.Controls.Add(this.btnSubBitDM);
            this.flpSubIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSubIO.Size = new System.Drawing.Size(168, 950);
            this.flpSubIO.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSubIO.WrapContents = false;
            this.flpSubIO.Visible = false;
            this.flpSubIO.Name = "flpSubIO";
            // 
            // btnSubIO
            // 
            this.btnSubIO.Size = new System.Drawing.Size(168, 44);
            this.btnSubIO.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubIO.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubIO.Text = "Input / Output";
            this.btnSubIO.Tag = "51";
            this.btnSubIO.TabStop = false;
            this.btnSubIO.Name = "btnSubIO";
            this.btnSubIO.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubBitDM
            // 
            this.btnSubBitDM.Size = new System.Drawing.Size(168, 44);
            this.btnSubBitDM.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubBitDM.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubBitDM.Text = "Bit / DM";
            this.btnSubBitDM.Tag = "52";
            this.btnSubBitDM.TabStop = false;
            this.btnSubBitDM.Name = "btnSubBitDM";
            this.btnSubBitDM.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // flpSubLog
            // 
            this.flpSubLog.Controls.Add(this.btnSubLog);
            this.flpSubLog.Controls.Add(this.btnSubErrorHistory);
            this.flpSubLog.Controls.Add(this.btnSubMTBA);
            this.flpSubLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpSubLog.Size = new System.Drawing.Size(168, 950);
            this.flpSubLog.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSubLog.WrapContents = false;
            this.flpSubLog.Visible = false;
            this.flpSubLog.Name = "flpSubLog";
            // 
            // btnSubLog
            // 
            this.btnSubLog.Size = new System.Drawing.Size(168, 44);
            this.btnSubLog.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubLog.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubLog.Text = "Log";
            this.btnSubLog.Tag = "71";
            this.btnSubLog.TabStop = false;
            this.btnSubLog.Name = "btnSubLog";
            this.btnSubLog.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubErrorHistory
            // 
            this.btnSubErrorHistory.Size = new System.Drawing.Size(168, 44);
            this.btnSubErrorHistory.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubErrorHistory.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubErrorHistory.Text = "Error History";
            this.btnSubErrorHistory.Tag = "72";
            this.btnSubErrorHistory.TabStop = false;
            this.btnSubErrorHistory.Name = "btnSubErrorHistory";
            this.btnSubErrorHistory.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // btnSubMTBA
            // 
            this.btnSubMTBA.Size = new System.Drawing.Size(168, 44);
            this.btnSubMTBA.Margin = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.btnSubMTBA.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSubMTBA.Text = "MTBA / MTBF";
            this.btnSubMTBA.Tag = "73";
            this.btnSubMTBA.TabStop = false;
            this.btnSubMTBA.Name = "btnSubMTBA";
            this.btnSubMTBA.Click += new System.EventHandler(this.btnSubMenuClick);
            // 
            // showHideConsoleToolStripMenuItem
            // 
            this.showHideConsoleToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.showHideConsoleToolStripMenuItem.Text = "Show/Hide Console";
            this.showHideConsoleToolStripMenuItem.Name = "showHideConsoleToolStripMenuItem";
            this.showHideConsoleToolStripMenuItem.Click += new System.EventHandler(this.showHideConsoleToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1920, 1041);
            this.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.MinimumSize = new System.Drawing.Size(1280, 800);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MMIApp";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlSubMenu);
            this.Controls.Add(this.pnlRail);
            this.Controls.Add(this.pnlAlarmBanner);
            this.Controls.Add(this.pnlTopBar);
            this.Name = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.flpSubLog.ResumeLayout(false);
            this.flpSubLog.PerformLayout();
            this.flpSubIO.ResumeLayout(false);
            this.flpSubIO.PerformLayout();
            this.flpSubData.ResumeLayout(false);
            this.flpSubData.PerformLayout();
            this.flpSubManual.ResumeLayout(false);
            this.flpSubManual.PerformLayout();
            this.flpSubAuto.ResumeLayout(false);
            this.flpSubAuto.PerformLayout();
            this.flpTopStatus.ResumeLayout(false);
            this.flpTopStatus.PerformLayout();
            this.flpTopButtons.ResumeLayout(false);
            this.flpTopButtons.PerformLayout();
            this.pnlContent.ResumeLayout(false);
            this.pnlSubMenu.ResumeLayout(false);
            this.pnlRail.ResumeLayout(false);
            this.pnlAlarmBanner.ResumeLayout(false);
            this.pnlTopBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlTopBar;
        private System.Windows.Forms.Panel pnlAlarmBanner;
        private System.Windows.Forms.Panel pnlRail;
        private System.Windows.Forms.Panel pnlSubMenu;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Timer TimerUserLevel;
        private System.Windows.Forms.Timer TimerSeqLink;
        private System.Windows.Forms.Timer timerConsole;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.FlowLayoutPanel flpTopButtons;
        private System.Windows.Forms.FlowLayoutPanel flpTopStatus;
        private System.Windows.Forms.Label lblMachine;
        private System.Windows.Forms.Label lblDeviceCaption;
        public System.Windows.Forms.Label lblDevice;
        public System.Windows.Forms.Label lblSeqLinkDot;
        public System.Windows.Forms.Label lblSeqLink;
        public System.Windows.Forms.Label lblPeripheralDot;
        public System.Windows.Forms.Label lblPeripheral;
        public System.Windows.Forms.Label lblSecsGemDot;
        public System.Windows.Forms.Label lblSecsGem;
        public System.Windows.Forms.Label lblUserName;
        public System.Windows.Forms.Label lblUserTime;
        public MMI.HmiButton btnEMO;
        public MMI.HmiButton btnRESET;
        public MMI.HmiButton btnBuzzerOff;
        public MMI.HmiButton btnTenKey;
        private MMI.HmiButton btnPM;
        public MMI.HmiButton btnLanguageSET;
        private MMI.HmiButton btnUserLogIn;
        private System.Windows.Forms.Label lblAlarmStripe;
        public System.Windows.Forms.Label lblError;
        public System.Windows.Forms.Label lblErrorMessage;
        public MMI.HmiRailButton btnMenuAuto;
        public MMI.HmiRailButton btnMenuManual;
        public MMI.HmiRailButton btnMenuMotor;
        public MMI.HmiRailButton btnMenuData;
        public MMI.HmiRailButton btnMenuMonitor;
        public MMI.HmiRailButton btnMenuAlarm;
        public MMI.HmiRailButton btnMenuLog;
        public MMI.HmiRailButton btnMenuCalib;
        private System.Windows.Forms.Label lblSubTitle;
        private System.Windows.Forms.FlowLayoutPanel flpSubAuto;
        public MMI.HmiButton btnSubAuto1;
        public MMI.HmiButton btnSubTrigger;
        private System.Windows.Forms.FlowLayoutPanel flpSubManual;
        public MMI.HmiButton btnSubManualList;
        public MMI.HmiButton btnSubManualOP;
        private System.Windows.Forms.FlowLayoutPanel flpSubData;
        public MMI.HmiButton btnSubRecipe;
        public MMI.HmiButton btnSubSysData;
        public MMI.HmiButton btnSubUseSkip;
        public MMI.HmiButton btnSubLifeTime;
        public MMI.HmiButton btnSubLampBuzzer;
        public MMI.HmiButton btnSubUserRegist;
        public MMI.HmiButton btnSubMotorCfg;
        private System.Windows.Forms.FlowLayoutPanel flpSubIO;
        public MMI.HmiButton btnSubIO;
        public MMI.HmiButton btnSubBitDM;
        private System.Windows.Forms.FlowLayoutPanel flpSubLog;
        public MMI.HmiButton btnSubLog;
        public MMI.HmiButton btnSubErrorHistory;
        public MMI.HmiButton btnSubMTBA;
        private System.Windows.Forms.ToolStripMenuItem showHideConsoleToolStripMenuItem;
    }
}
