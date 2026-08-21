namespace MMI
{
    partial class FormMain
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.pnMainMenu = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lbTLGreen = new System.Windows.Forms.Label();
            this.lbTLOrg = new System.Windows.Forms.Label();
            this.lbTLRed = new System.Windows.Forms.Label();
            this.imageConnect = new System.Windows.Forms.ImageList(this.components);
            this.lblUserName = new DevComponents.DotNetBar.LabelX();
            this.lblUserTime = new DevComponents.DotNetBar.LabelX();
            this.lblError = new DevComponents.DotNetBar.LabelX();
            this.lblDevice = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.TimerUserLevel = new System.Windows.Forms.Timer(this.components);
            this.TimerSeqLink = new System.Windows.Forms.Timer(this.components);
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showHideConsoleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerConsole = new System.Windows.Forms.Timer(this.components);
            this.btnSEQLink = new System.Windows.Forms.Button();
            this.pictureLOGO = new System.Windows.Forms.PictureBox();
            this.btnPM = new DevComponents.DotNetBar.ButtonX();
            this.btnUserLogIn = new DevComponents.DotNetBar.ButtonX();
            this.btnBuzzerOff = new DevComponents.DotNetBar.ButtonX();
            this.pictureEMO = new System.Windows.Forms.PictureBox();
            this.btnMenuCalib = new DevComponents.DotNetBar.ButtonX();
            this.btnLanguageSET = new DevComponents.DotNetBar.ButtonX();
            this.btnRESET = new DevComponents.DotNetBar.ButtonX();
            this.btnTenKey = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuLog = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuAlarm = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuMonitor = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuData = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuMotor = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuManual = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuAuto = new DevComponents.DotNetBar.ButtonX();
            this.pnMainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureLOGO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEMO)).BeginInit();
            this.SuspendLayout();
            // 
            // pnMainMenu
            // 
            this.pnMainMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnMainMenu.Controls.Add(this.btnBuzzerOff);
            this.pnMainMenu.Controls.Add(this.pictureEMO);
            this.pnMainMenu.Controls.Add(this.btnMenuCalib);
            this.pnMainMenu.Controls.Add(this.btnLanguageSET);
            this.pnMainMenu.Controls.Add(this.btnRESET);
            this.pnMainMenu.Controls.Add(this.btnTenKey);
            this.pnMainMenu.Controls.Add(this.btnMenuLog);
            this.pnMainMenu.Controls.Add(this.btnMenuAlarm);
            this.pnMainMenu.Controls.Add(this.btnMenuMonitor);
            this.pnMainMenu.Controls.Add(this.btnMenuData);
            this.pnMainMenu.Controls.Add(this.btnMenuMotor);
            this.pnMainMenu.Controls.Add(this.btnMenuManual);
            this.pnMainMenu.Controls.Add(this.btnMenuAuto);
            this.pnMainMenu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnMainMenu.Location = new System.Drawing.Point(0, 1031);
            this.pnMainMenu.Name = "pnMainMenu";
            this.pnMainMenu.Size = new System.Drawing.Size(1604, 100);
            this.pnMainMenu.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.labelX1);
            this.panel1.Controls.Add(this.lbTLGreen);
            this.panel1.Controls.Add(this.lbTLOrg);
            this.panel1.Controls.Add(this.lbTLRed);
            this.panel1.Controls.Add(this.btnSEQLink);
            this.panel1.Controls.Add(this.lblUserName);
            this.panel1.Controls.Add(this.lblUserTime);
            this.panel1.Controls.Add(this.pictureLOGO);
            this.panel1.Controls.Add(this.btnPM);
            this.panel1.Controls.Add(this.btnUserLogIn);
            this.panel1.Controls.Add(this.lblError);
            this.panel1.Controls.Add(this.lblDevice);
            this.panel1.Controls.Add(this.labelX4);
            this.panel1.Controls.Add(this.labelX3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1604, 100);
            this.panel1.TabIndex = 1;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.BackgroundStyle.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.labelX1.BackgroundStyle.BackColorGradientAngle = 90;
            this.labelX1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX1.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderGradientAngle = 0;
            this.labelX1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX1.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX1.BackgroundStyle.BorderLightGradientAngle = 0;
            this.labelX1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX1.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderRightWidth = 1;
            this.labelX1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX1.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderTopWidth = 1;
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(7, 52);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(98, 40);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX1.TabIndex = 1180;
            this.labelX1.Text = "STAGE";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lbTLGreen
            // 
            this.lbTLGreen.BackColor = System.Drawing.Color.Green;
            this.lbTLGreen.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTLGreen.ForeColor = System.Drawing.Color.White;
            this.lbTLGreen.Location = new System.Drawing.Point(1276, 67);
            this.lbTLGreen.Name = "lbTLGreen";
            this.lbTLGreen.Size = new System.Drawing.Size(19, 28);
            this.lbTLGreen.TabIndex = 1179;
            this.lbTLGreen.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTLOrg
            // 
            this.lbTLOrg.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.lbTLOrg.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTLOrg.ForeColor = System.Drawing.Color.White;
            this.lbTLOrg.Location = new System.Drawing.Point(1276, 38);
            this.lbTLOrg.Name = "lbTLOrg";
            this.lbTLOrg.Size = new System.Drawing.Size(19, 28);
            this.lbTLOrg.TabIndex = 1178;
            this.lbTLOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTLRed
            // 
            this.lbTLRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbTLRed.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTLRed.ForeColor = System.Drawing.Color.White;
            this.lbTLRed.Location = new System.Drawing.Point(1276, 8);
            this.lbTLRed.Name = "lbTLRed";
            this.lbTLRed.Size = new System.Drawing.Size(19, 28);
            this.lbTLRed.TabIndex = 1177;
            this.lbTLRed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageConnect
            // 
            this.imageConnect.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageConnect.ImageStream")));
            this.imageConnect.TransparentColor = System.Drawing.Color.Transparent;
            this.imageConnect.Images.SetKeyName(0, "connected.bmp");
            this.imageConnect.Images.SetKeyName(1, "disconnected.bmp");
            // 
            // lblUserName
            // 
            this.lblUserName.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.lblUserName.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblUserName.BackgroundStyle.BackColor2 = System.Drawing.Color.OliveDrab;
            this.lblUserName.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblUserName.BackgroundStyle.BackgroundImageAlpha = ((byte)(90));
            this.lblUserName.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblUserName.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblUserName.BackgroundStyle.BorderBottomWidth = 1;
            this.lblUserName.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblUserName.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblUserName.BackgroundStyle.BorderGradientAngle = 0;
            this.lblUserName.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblUserName.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblUserName.BackgroundStyle.BorderLeftWidth = 1;
            this.lblUserName.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblUserName.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblUserName.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblUserName.BackgroundStyle.BorderRightWidth = 1;
            this.lblUserName.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblUserName.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblUserName.BackgroundStyle.BorderTopWidth = 1;
            this.lblUserName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUserName.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserName.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblUserName.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.Blue;
            this.lblUserName.Location = new System.Drawing.Point(1302, 54);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(111, 40);
            this.lblUserName.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.lblUserName.TabIndex = 30;
            this.lblUserName.Text = "NO USER";
            this.lblUserName.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblUserTime
            // 
            this.lblUserTime.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.lblUserTime.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblUserTime.BackgroundStyle.BackColor2 = System.Drawing.Color.OliveDrab;
            this.lblUserTime.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblUserTime.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblUserTime.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblUserTime.BackgroundStyle.BorderBottomWidth = 1;
            this.lblUserTime.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblUserTime.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblUserTime.BackgroundStyle.BorderGradientAngle = 0;
            this.lblUserTime.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblUserTime.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblUserTime.BackgroundStyle.BorderLeftWidth = 1;
            this.lblUserTime.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblUserTime.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblUserTime.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblUserTime.BackgroundStyle.BorderRightWidth = 1;
            this.lblUserTime.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblUserTime.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblUserTime.BackgroundStyle.BorderTopWidth = 1;
            this.lblUserTime.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUserTime.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUserTime.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblUserTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserTime.ForeColor = System.Drawing.Color.Black;
            this.lblUserTime.Location = new System.Drawing.Point(1302, 8);
            this.lblUserTime.Name = "lblUserTime";
            this.lblUserTime.Size = new System.Drawing.Size(111, 40);
            this.lblUserTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.lblUserTime.TabIndex = 29;
            this.lblUserTime.Text = "USER \r\n00:00:00";
            this.lblUserTime.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.SystemColors.Desktop;
            // 
            // 
            // 
            this.lblError.BackgroundStyle.BackColor = System.Drawing.Color.Sienna;
            this.lblError.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.Info;
            this.lblError.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblError.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblError.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblError.BackgroundStyle.BorderBottomWidth = 1;
            this.lblError.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblError.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblError.BackgroundStyle.BorderGradientAngle = 0;
            this.lblError.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblError.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblError.BackgroundStyle.BorderLeftWidth = 1;
            this.lblError.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblError.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblError.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblError.BackgroundStyle.BorderRightWidth = 1;
            this.lblError.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblError.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblError.BackgroundStyle.BorderTopWidth = 1;
            this.lblError.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblError.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblError.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblError.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblError.FontBold = true;
            this.lblError.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblError.Location = new System.Drawing.Point(228, 52);
            this.lblError.Name = "lblError";
            this.lblError.SingleLineColor = System.Drawing.SystemColors.HighlightText;
            this.lblError.Size = new System.Drawing.Size(727, 40);
            this.lblError.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.lblError.TabIndex = 25;
            // 
            // lblDevice
            // 
            this.lblDevice.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.lblDevice.BackgroundStyle.BackColor = System.Drawing.Color.DarkGray;
            this.lblDevice.BackgroundStyle.BackColor2 = System.Drawing.Color.DarkGray;
            this.lblDevice.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblDevice.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblDevice.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblDevice.BackgroundStyle.BorderBottomWidth = 1;
            this.lblDevice.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblDevice.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblDevice.BackgroundStyle.BorderGradientAngle = 0;
            this.lblDevice.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblDevice.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblDevice.BackgroundStyle.BorderLeftWidth = 1;
            this.lblDevice.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblDevice.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblDevice.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblDevice.BackgroundStyle.BorderRightWidth = 1;
            this.lblDevice.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblDevice.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblDevice.BackgroundStyle.BorderTopWidth = 1;
            this.lblDevice.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDevice.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDevice.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblDevice.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.FontBold = true;
            this.lblDevice.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblDevice.Location = new System.Drawing.Point(228, 6);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.SingleLineColor = System.Drawing.Color.PaleTurquoise;
            this.lblDevice.Size = new System.Drawing.Size(727, 40);
            this.lblDevice.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblDevice.TabIndex = 24;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX4.BackgroundStyle.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.labelX4.BackgroundStyle.BackColorGradientAngle = 90;
            this.labelX4.BackgroundStyle.BackgroundImageAlpha = ((byte)(90));
            this.labelX4.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX4.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.labelX4.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX4.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.labelX4.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.labelX4.BackgroundStyle.BorderGradientAngle = 0;
            this.labelX4.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX4.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.labelX4.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX4.BackgroundStyle.BorderLightGradientAngle = 0;
            this.labelX4.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX4.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.labelX4.BackgroundStyle.BorderRightWidth = 1;
            this.labelX4.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX4.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.labelX4.BackgroundStyle.BorderTopWidth = 1;
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX4.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX4.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX4.ForeColor = System.Drawing.Color.Red;
            this.labelX4.Location = new System.Drawing.Point(111, 52);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(111, 40);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX4.TabIndex = 23;
            this.labelX4.Text = "ERROR";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.BackgroundStyle.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.labelX3.BackgroundStyle.BackColorGradientAngle = 90;
            this.labelX3.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX3.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.labelX3.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX3.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.labelX3.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.labelX3.BackgroundStyle.BorderGradientAngle = 0;
            this.labelX3.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX3.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.labelX3.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX3.BackgroundStyle.BorderLightGradientAngle = 0;
            this.labelX3.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX3.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.labelX3.BackgroundStyle.BorderRightWidth = 1;
            this.labelX3.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX3.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.labelX3.BackgroundStyle.BorderTopWidth = 1;
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX3.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX3.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.Color.Blue;
            this.labelX3.Location = new System.Drawing.Point(111, 6);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(111, 40);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX3.TabIndex = 22;
            this.labelX3.Text = "DEVICE";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // TimerUserLevel
            // 
            this.TimerUserLevel.Tick += new System.EventHandler(this.TimerUserLevel_Tick);
            // 
            // TimerSeqLink
            // 
            this.TimerSeqLink.Enabled = true;
            this.TimerSeqLink.Interval = 5000;
            this.TimerSeqLink.Tick += new System.EventHandler(this.TimerSeqLink_Tick);
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.contextMenuStrip;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "notifyIcon1";
            this.TrayIcon.Visible = true;
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showHideConsoleToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(182, 26);
            // 
            // showHideConsoleToolStripMenuItem
            // 
            this.showHideConsoleToolStripMenuItem.Name = "showHideConsoleToolStripMenuItem";
            this.showHideConsoleToolStripMenuItem.Size = new System.Drawing.Size(181, 22);
            this.showHideConsoleToolStripMenuItem.Text = "Show/Hide Console";
            this.showHideConsoleToolStripMenuItem.Click += new System.EventHandler(this.showHideConsoleToolStripMenuItem_Click);
            // 
            // timerConsole
            // 
            this.timerConsole.Interval = 10000;
            this.timerConsole.Tick += new System.EventHandler(this.timerConsole_Tick);
            // 
            // btnSEQLink
            // 
            this.btnSEQLink.BackColor = System.Drawing.SystemColors.Control;
            this.btnSEQLink.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSEQLink.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSEQLink.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSEQLink.ImageIndex = 1;
            this.btnSEQLink.ImageList = this.imageConnect;
            this.btnSEQLink.Location = new System.Drawing.Point(1183, 8);
            this.btnSEQLink.Name = "btnSEQLink";
            this.btnSEQLink.Size = new System.Drawing.Size(87, 40);
            this.btnSEQLink.TabIndex = 31;
            this.btnSEQLink.Text = "SEQ.";
            this.btnSEQLink.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSEQLink.UseVisualStyleBackColor = false;
            // 
            // pictureLOGO
            // 
            this.pictureLOGO.BackColor = System.Drawing.Color.White;
            this.pictureLOGO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureLOGO.ErrorImage = null;
            this.pictureLOGO.Image = global::MMI.Properties.Resources.keoc_logo;
            this.pictureLOGO.InitialImage = global::MMI.Properties.Resources.keoc_logo1;
            this.pictureLOGO.Location = new System.Drawing.Point(7, 6);
            this.pictureLOGO.Name = "pictureLOGO";
            this.pictureLOGO.Size = new System.Drawing.Size(98, 40);
            this.pictureLOGO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureLOGO.TabIndex = 28;
            this.pictureLOGO.TabStop = false;
            // 
            // btnPM
            // 
            this.btnPM.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnPM.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnPM.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPM.Image = global::MMI.Properties.Resources.configure_2;
            this.btnPM.ImageAlt = global::MMI.Properties.Resources.configure_2;
            this.btnPM.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnPM.Location = new System.Drawing.Point(1518, 8);
            this.btnPM.Name = "btnPM";
            this.btnPM.Size = new System.Drawing.Size(74, 86);
            this.btnPM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnPM.TabIndex = 27;
            this.btnPM.Text = "PM";
            this.btnPM.Click += new System.EventHandler(this.btnPM_Click);
            // 
            // btnUserLogIn
            // 
            this.btnUserLogIn.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUserLogIn.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnUserLogIn.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserLogIn.Image = global::MMI.Properties.Resources.system_users_3;
            this.btnUserLogIn.ImageAlt = global::MMI.Properties.Resources.system_users_3;
            this.btnUserLogIn.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnUserLogIn.Location = new System.Drawing.Point(1422, 8);
            this.btnUserLogIn.Name = "btnUserLogIn";
            this.btnUserLogIn.Size = new System.Drawing.Size(90, 86);
            this.btnUserLogIn.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnUserLogIn.TabIndex = 26;
            this.btnUserLogIn.Text = "LOG IN";
            this.btnUserLogIn.Click += new System.EventHandler(this.btnUserLogIn_Click);
            // 
            // btnBuzzerOff
            // 
            this.btnBuzzerOff.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnBuzzerOff.BackColor = System.Drawing.Color.Black;
            this.btnBuzzerOff.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnBuzzerOff.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuzzerOff.Image = global::MMI.Properties.Resources.buzzer31;
            this.btnBuzzerOff.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnBuzzerOff.Location = new System.Drawing.Point(1237, 13);
            this.btnBuzzerOff.Name = "btnBuzzerOff";
            this.btnBuzzerOff.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnBuzzerOff.Size = new System.Drawing.Size(90, 75);
            this.btnBuzzerOff.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnBuzzerOff.TabIndex = 30;
            this.btnBuzzerOff.Tag = "7";
            this.btnBuzzerOff.Text = "OFF";
            this.btnBuzzerOff.ThemeAware = true;
            this.btnBuzzerOff.Click += new System.EventHandler(this.btnBuzzerOff_Click);
            // 
            // pictureEMO
            // 
            this.pictureEMO.BackColor = System.Drawing.Color.White;
            this.pictureEMO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureEMO.ErrorImage = null;
            this.pictureEMO.Image = global::MMI.Properties.Resources.EMO1;
            this.pictureEMO.InitialImage = global::MMI.Properties.Resources.i3_logo2;
            this.pictureEMO.Location = new System.Drawing.Point(1497, 3);
            this.pictureEMO.Name = "pictureEMO";
            this.pictureEMO.Size = new System.Drawing.Size(100, 92);
            this.pictureEMO.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureEMO.TabIndex = 29;
            this.pictureEMO.TabStop = false;
            this.pictureEMO.Click += new System.EventHandler(this.pictureEMO_Click);
            // 
            // btnMenuCalib
            // 
            this.btnMenuCalib.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuCalib.BackColor = System.Drawing.Color.Black;
            this.btnMenuCalib.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnMenuCalib.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuCalib.Image = global::MMI.Properties.Resources.configure_2;
            this.btnMenuCalib.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnMenuCalib.Location = new System.Drawing.Point(389, 13);
            this.btnMenuCalib.Name = "btnMenuCalib";
            this.btnMenuCalib.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuCalib.Size = new System.Drawing.Size(98, 75);
            this.btnMenuCalib.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuCalib.TabIndex = 19;
            this.btnMenuCalib.Tag = "8";
            this.btnMenuCalib.Text = "Teach";
            this.btnMenuCalib.ThemeAware = true;
            this.btnMenuCalib.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnLanguageSET
            // 
            this.btnLanguageSET.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLanguageSET.BackColor = System.Drawing.Color.Black;
            this.btnLanguageSET.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnLanguageSET.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLanguageSET.Image = global::MMI.Properties.Resources.preferences_desktop_keyboard;
            this.btnLanguageSET.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnLanguageSET.Location = new System.Drawing.Point(1801, 12);
            this.btnLanguageSET.Name = "btnLanguageSET";
            this.btnLanguageSET.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnLanguageSET.Size = new System.Drawing.Size(90, 75);
            this.btnLanguageSET.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLanguageSET.TabIndex = 18;
            this.btnLanguageSET.Tag = "7";
            this.btnLanguageSET.Text = "LANGUAGE";
            this.btnLanguageSET.ThemeAware = true;
            this.btnLanguageSET.Visible = false;
            this.btnLanguageSET.Click += new System.EventHandler(this.btnLanguageSET_Click);
            // 
            // btnRESET
            // 
            this.btnRESET.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnRESET.BackColor = System.Drawing.Color.Black;
            this.btnRESET.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnRESET.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRESET.Image = global::MMI.Properties.Resources.view_refresh_2;
            this.btnRESET.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnRESET.Location = new System.Drawing.Point(1124, 13);
            this.btnRESET.Name = "btnRESET";
            this.btnRESET.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnRESET.Size = new System.Drawing.Size(90, 75);
            this.btnRESET.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnRESET.TabIndex = 17;
            this.btnRESET.Tag = "7";
            this.btnRESET.Text = "RESET";
            this.btnRESET.ThemeAware = true;
            this.btnRESET.Click += new System.EventHandler(this.btnRESET_Click);
            // 
            // btnTenKey
            // 
            this.btnTenKey.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTenKey.BackColor = System.Drawing.Color.Black;
            this.btnTenKey.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnTenKey.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTenKey.Image = global::MMI.Properties.Resources.accessories_calculator_3;
            this.btnTenKey.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnTenKey.Location = new System.Drawing.Point(1355, 13);
            this.btnTenKey.Name = "btnTenKey";
            this.btnTenKey.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnTenKey.Size = new System.Drawing.Size(90, 75);
            this.btnTenKey.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTenKey.TabIndex = 16;
            this.btnTenKey.Tag = "7";
            this.btnTenKey.Text = "TEN KEY";
            this.btnTenKey.ThemeAware = true;
            this.btnTenKey.Click += new System.EventHandler(this.btnTenKey_Click);
            // 
            // btnMenuLog
            // 
            this.btnMenuLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuLog.BackColor = System.Drawing.Color.Black;
            this.btnMenuLog.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnMenuLog.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuLog.Image = global::MMI.Properties.Resources.TextEdit_app;
            this.btnMenuLog.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnMenuLog.Location = new System.Drawing.Point(882, 12);
            this.btnMenuLog.Name = "btnMenuLog";
            this.btnMenuLog.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuLog.Size = new System.Drawing.Size(98, 75);
            this.btnMenuLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuLog.TabIndex = 15;
            this.btnMenuLog.Tag = "7";
            this.btnMenuLog.Text = "LOG";
            this.btnMenuLog.ThemeAware = true;
            this.btnMenuLog.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuAlarm
            // 
            this.btnMenuAlarm.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuAlarm.BackColor = System.Drawing.Color.Black;
            this.btnMenuAlarm.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnMenuAlarm.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuAlarm.Image = global::MMI.Properties.Resources.terminator;
            this.btnMenuAlarm.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnMenuAlarm.Location = new System.Drawing.Point(756, 13);
            this.btnMenuAlarm.Name = "btnMenuAlarm";
            this.btnMenuAlarm.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuAlarm.Size = new System.Drawing.Size(98, 75);
            this.btnMenuAlarm.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuAlarm.TabIndex = 14;
            this.btnMenuAlarm.Tag = "6";
            this.btnMenuAlarm.Text = "ALARM";
            this.btnMenuAlarm.ThemeAware = true;
            this.btnMenuAlarm.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuMonitor
            // 
            this.btnMenuMonitor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuMonitor.BackColor = System.Drawing.Color.Black;
            this.btnMenuMonitor.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnMenuMonitor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuMonitor.Image = global::MMI.Properties.Resources.utilities_system_monitor_2;
            this.btnMenuMonitor.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnMenuMonitor.Location = new System.Drawing.Point(630, 12);
            this.btnMenuMonitor.Name = "btnMenuMonitor";
            this.btnMenuMonitor.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuMonitor.Size = new System.Drawing.Size(98, 75);
            this.btnMenuMonitor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuMonitor.TabIndex = 13;
            this.btnMenuMonitor.Tag = "5";
            this.btnMenuMonitor.Text = "MONITOR";
            this.btnMenuMonitor.ThemeAware = true;
            this.btnMenuMonitor.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuData
            // 
            this.btnMenuData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuData.BackColor = System.Drawing.Color.Black;
            this.btnMenuData.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnMenuData.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuData.Image = global::MMI.Properties.Resources.kate_4;
            this.btnMenuData.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnMenuData.Location = new System.Drawing.Point(504, 12);
            this.btnMenuData.Name = "btnMenuData";
            this.btnMenuData.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuData.Size = new System.Drawing.Size(98, 75);
            this.btnMenuData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuData.TabIndex = 12;
            this.btnMenuData.Tag = "4";
            this.btnMenuData.Text = "DATA";
            this.btnMenuData.ThemeAware = true;
            this.btnMenuData.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuMotor
            // 
            this.btnMenuMotor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuMotor.BackColor = System.Drawing.Color.Black;
            this.btnMenuMotor.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnMenuMotor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuMotor.Image = global::MMI.Properties.Resources.system_run_3;
            this.btnMenuMotor.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnMenuMotor.Location = new System.Drawing.Point(275, 12);
            this.btnMenuMotor.Name = "btnMenuMotor";
            this.btnMenuMotor.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuMotor.Size = new System.Drawing.Size(98, 75);
            this.btnMenuMotor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuMotor.TabIndex = 11;
            this.btnMenuMotor.Tag = "3";
            this.btnMenuMotor.Text = "MOTOR";
            this.btnMenuMotor.ThemeAware = true;
            this.btnMenuMotor.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuManual
            // 
            this.btnMenuManual.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuManual.BackColor = System.Drawing.Color.Black;
            this.btnMenuManual.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnMenuManual.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuManual.Image = global::MMI.Properties.Resources.touchpad;
            this.btnMenuManual.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnMenuManual.Location = new System.Drawing.Point(149, 12);
            this.btnMenuManual.Name = "btnMenuManual";
            this.btnMenuManual.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuManual.Size = new System.Drawing.Size(98, 75);
            this.btnMenuManual.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuManual.TabIndex = 10;
            this.btnMenuManual.Tag = "2";
            this.btnMenuManual.Text = "MANUAL";
            this.btnMenuManual.ThemeAware = true;
            this.btnMenuManual.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuAuto
            // 
            this.btnMenuAuto.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuAuto.BackColor = System.Drawing.Color.Black;
            this.btnMenuAuto.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnMenuAuto.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenuAuto.Image = global::MMI.Properties.Resources.aim;
            this.btnMenuAuto.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top;
            this.btnMenuAuto.Location = new System.Drawing.Point(23, 12);
            this.btnMenuAuto.Name = "btnMenuAuto";
            this.btnMenuAuto.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuAuto.Size = new System.Drawing.Size(98, 75);
            this.btnMenuAuto.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuAuto.TabIndex = 9;
            this.btnMenuAuto.Tag = "1";
            this.btnMenuAuto.Text = "AUTO";
            this.btnMenuAuto.ThemeAware = true;
            this.btnMenuAuto.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1604, 1131);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnMainMenu);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MMIApp";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.pnMainMenu.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureLOGO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEMO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnMainMenu;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.LabelX lblUserName;
        private DevComponents.DotNetBar.LabelX lblUserTime;
        private System.Windows.Forms.PictureBox pictureLOGO;
        private DevComponents.DotNetBar.ButtonX btnPM;
        private DevComponents.DotNetBar.ButtonX btnUserLogIn;
        public DevComponents.DotNetBar.LabelX lblError;
        public DevComponents.DotNetBar.LabelX lblDevice;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX3;
        private System.Windows.Forms.Timer TimerUserLevel;
        private System.Windows.Forms.Timer TimerSeqLink;
        private System.Windows.Forms.Button btnSEQLink;
        private System.Windows.Forms.ImageList imageConnect;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem showHideConsoleToolStripMenuItem;
        private System.Windows.Forms.Timer timerConsole;
        private System.Windows.Forms.Label lbTLGreen;
        private System.Windows.Forms.Label lbTLOrg;
        private System.Windows.Forms.Label lbTLRed;
        private DevComponents.DotNetBar.LabelX labelX1;
        public DevComponents.DotNetBar.ButtonX btnRESET;
        public DevComponents.DotNetBar.ButtonX btnTenKey;
        public DevComponents.DotNetBar.ButtonX btnMenuLog;
        public DevComponents.DotNetBar.ButtonX btnMenuAlarm;
        public DevComponents.DotNetBar.ButtonX btnMenuMonitor;
        public DevComponents.DotNetBar.ButtonX btnMenuData;
        public DevComponents.DotNetBar.ButtonX btnMenuMotor;
        public DevComponents.DotNetBar.ButtonX btnMenuManual;
        public DevComponents.DotNetBar.ButtonX btnMenuAuto;
        public DevComponents.DotNetBar.ButtonX btnLanguageSET;
        public DevComponents.DotNetBar.ButtonX btnMenuCalib;
        private System.Windows.Forms.PictureBox pictureEMO;
        public DevComponents.DotNetBar.ButtonX btnBuzzerOff;
    }
}

