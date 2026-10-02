namespace MMI
{
    partial class FormDataSystem
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
            this.pnlMachine = new MMI.HmiCard();
            this.lblMachineNameCaption = new System.Windows.Forms.Label();
            this.txtMachineName = new System.Windows.Forms.TextBox();
            this.pnlLog = new MMI.HmiCard();
            this.lblLogKeepDaysCaption = new System.Windows.Forms.Label();
            this.lblLogKeepDays = new System.Windows.Forms.Label();
            this.lblLogKeepDaysUnit = new System.Windows.Forms.Label();
            this.btnLogKeepDays = new MMI.HmiButton();
            this.lblLogCutOff = new System.Windows.Forms.Label();
            this.lblLogFoldersCaption = new System.Windows.Forms.Label();
            this.lstLogFolders = new System.Windows.Forms.ListBox();
            this.lblLogRule = new System.Windows.Forms.Label();
            this.btnPurgeNow = new MMI.HmiButton();
            this.lblPurgeResult = new System.Windows.Forms.Label();
            this.pnlLifeTime = new MMI.HmiCard();
            this.lblLifeTimeWarnCaption = new System.Windows.Forms.Label();
            this.lblLifeTimeWarn = new System.Windows.Forms.Label();
            this.lblLifeTimeWarnUnit = new System.Windows.Forms.Label();
            this.btnLifeTimeWarn = new MMI.HmiButton();
            this.lblLifeTimeRule = new System.Windows.Forms.Label();
            this.pnlInput = new MMI.HmiCard();
            this.lblKeyboardCaption = new System.Windows.Forms.Label();
            this.btnKeyboardSoftware = new MMI.HmiButton();
            this.btnKeyboardHardware = new MMI.HmiButton();
            this.lblKeyboardRule = new System.Windows.Forms.Label();
            this.pnlLanguage = new MMI.HmiCard();
            this.lblLanguageCaption = new System.Windows.Forms.Label();
            this.btnLanguageEN = new MMI.HmiButton();
            this.btnLanguageKO = new MMI.HmiButton();
            this.btnLanguageZH = new MMI.HmiButton();
            this.lblLanguageRule = new System.Windows.Forms.Label();
            this.pnlSave = new MMI.HmiCard();
            this.btnApply = new MMI.HmiButton();
            this.btnCancel = new MMI.HmiButton();
            this.lblStaged = new System.Windows.Forms.Label();
            this.lblResult = new System.Windows.Forms.Label();
            this.pnlMachine.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.pnlLifeTime.SuspendLayout();
            this.pnlInput.SuspendLayout();
            this.pnlLanguage.SuspendLayout();
            this.pnlSave.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMachine
            // 
            this.pnlMachine.Controls.Add(this.txtMachineName);
            this.pnlMachine.Controls.Add(this.lblMachineNameCaption);
            this.pnlMachine.Location = new System.Drawing.Point(0, 0);
            this.pnlMachine.Size = new System.Drawing.Size(800, 130);
            this.pnlMachine.TitleText = "Machine";
            this.pnlMachine.Name = "pnlMachine";
            // 
            // lblMachineNameCaption
            // 
            this.lblMachineNameCaption.Location = new System.Drawing.Point(16, 50);
            this.lblMachineNameCaption.Size = new System.Drawing.Size(230, 34);
            this.lblMachineNameCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMachineNameCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblMachineNameCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblMachineNameCaption.Text = "Machine name (top bar)";
            this.lblMachineNameCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblMachineNameCaption.Name = "lblMachineNameCaption";
            // 
            // txtMachineName
            // 
            this.txtMachineName.Location = new System.Drawing.Point(250, 50);
            this.txtMachineName.Size = new System.Drawing.Size(530, 40);
            this.txtMachineName.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtMachineName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtMachineName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtMachineName.MaxLength = 40;
            this.txtMachineName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMachineName.Name = "txtMachineName";
            this.txtMachineName.TextChanged += new System.EventHandler(this.txtMachineName_TextChanged);
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.lblPurgeResult);
            this.pnlLog.Controls.Add(this.btnPurgeNow);
            this.pnlLog.Controls.Add(this.lblLogRule);
            this.pnlLog.Controls.Add(this.lstLogFolders);
            this.pnlLog.Controls.Add(this.lblLogFoldersCaption);
            this.pnlLog.Controls.Add(this.lblLogCutOff);
            this.pnlLog.Controls.Add(this.btnLogKeepDays);
            this.pnlLog.Controls.Add(this.lblLogKeepDaysUnit);
            this.pnlLog.Controls.Add(this.lblLogKeepDays);
            this.pnlLog.Controls.Add(this.lblLogKeepDaysCaption);
            this.pnlLog.Location = new System.Drawing.Point(0, 142);
            this.pnlLog.Size = new System.Drawing.Size(800, 470);
            this.pnlLog.TitleText = "Log Retention";
            this.pnlLog.Name = "pnlLog";
            // 
            // lblLogKeepDaysCaption
            // 
            this.lblLogKeepDaysCaption.Location = new System.Drawing.Point(16, 50);
            this.lblLogKeepDaysCaption.Size = new System.Drawing.Size(230, 34);
            this.lblLogKeepDaysCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLogKeepDaysCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLogKeepDaysCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblLogKeepDaysCaption.Text = "Keep log files for";
            this.lblLogKeepDaysCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogKeepDaysCaption.Name = "lblLogKeepDaysCaption";
            // 
            // lblLogKeepDays
            // 
            this.lblLogKeepDays.Location = new System.Drawing.Point(250, 46);
            this.lblLogKeepDays.Size = new System.Drawing.Size(140, 40);
            this.lblLogKeepDays.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLogKeepDays.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblLogKeepDays.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblLogKeepDays.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblLogKeepDays.Text = "90";
            this.lblLogKeepDays.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLogKeepDays.Name = "lblLogKeepDays";
            // 
            // lblLogKeepDaysUnit
            // 
            this.lblLogKeepDaysUnit.Location = new System.Drawing.Point(398, 50);
            this.lblLogKeepDaysUnit.Size = new System.Drawing.Size(60, 34);
            this.lblLogKeepDaysUnit.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLogKeepDaysUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLogKeepDaysUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblLogKeepDaysUnit.Text = "days";
            this.lblLogKeepDaysUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogKeepDaysUnit.Name = "lblLogKeepDaysUnit";
            // 
            // btnLogKeepDays
            // 
            this.btnLogKeepDays.Location = new System.Drawing.Point(470, 46);
            this.btnLogKeepDays.Size = new System.Drawing.Size(120, 40);
            this.btnLogKeepDays.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogKeepDays.Text = "SET";
            this.btnLogKeepDays.Name = "btnLogKeepDays";
            this.btnLogKeepDays.Click += new System.EventHandler(this.btnLogKeepDays_Click);
            // 
            // lblLogCutOff
            // 
            this.lblLogCutOff.Location = new System.Drawing.Point(16, 94);
            this.lblLogCutOff.Size = new System.Drawing.Size(764, 34);
            this.lblLogCutOff.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLogCutOff.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLogCutOff.BackColor = System.Drawing.Color.Transparent;
            this.lblLogCutOff.Text = "";
            this.lblLogCutOff.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogCutOff.Name = "lblLogCutOff";
            // 
            // lblLogFoldersCaption
            // 
            this.lblLogFoldersCaption.Location = new System.Drawing.Point(16, 134);
            this.lblLogFoldersCaption.Size = new System.Drawing.Size(764, 34);
            this.lblLogFoldersCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLogFoldersCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLogFoldersCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblLogFoldersCaption.Text = "Folders purged (LOG FOLDERS in MachineConfig.ini [SYSTEM])";
            this.lblLogFoldersCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogFoldersCaption.Name = "lblLogFoldersCaption";
            // 
            // lstLogFolders
            // 
            this.lstLogFolders.Location = new System.Drawing.Point(16, 170);
            this.lstLogFolders.Size = new System.Drawing.Size(764, 120);
            this.lstLogFolders.Font = new System.Drawing.Font("Consolas", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lstLogFolders.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lstLogFolders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lstLogFolders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLogFolders.IntegralHeight = false;
            this.lstLogFolders.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lstLogFolders.Name = "lstLogFolders";
            // 
            // lblLogRule
            // 
            this.lblLogRule.Location = new System.Drawing.Point(16, 298);
            this.lblLogRule.Size = new System.Drawing.Size(764, 34);
            this.lblLogRule.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLogRule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLogRule.BackColor = System.Drawing.Color.Transparent;
            this.lblLogRule.Text = "MMI and SEQ logs alike (.log, .txt). Checked a minute after start-up, then every hour.";
            this.lblLogRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLogRule.Name = "lblLogRule";
            // 
            // btnPurgeNow
            // 
            this.btnPurgeNow.Location = new System.Drawing.Point(16, 344);
            this.btnPurgeNow.Size = new System.Drawing.Size(200, 48);
            this.btnPurgeNow.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnPurgeNow.Text = "PURGE NOW";
            this.btnPurgeNow.Name = "btnPurgeNow";
            this.btnPurgeNow.Click += new System.EventHandler(this.btnPurgeNow_Click);
            // 
            // lblPurgeResult
            // 
            this.lblPurgeResult.Location = new System.Drawing.Point(230, 344);
            this.lblPurgeResult.Size = new System.Drawing.Size(550, 48);
            this.lblPurgeResult.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPurgeResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblPurgeResult.BackColor = System.Drawing.Color.Transparent;
            this.lblPurgeResult.Text = "";
            this.lblPurgeResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPurgeResult.Name = "lblPurgeResult";
            // 
            // pnlLifeTime
            // 
            this.pnlLifeTime.Controls.Add(this.lblLifeTimeRule);
            this.pnlLifeTime.Controls.Add(this.btnLifeTimeWarn);
            this.pnlLifeTime.Controls.Add(this.lblLifeTimeWarnUnit);
            this.pnlLifeTime.Controls.Add(this.lblLifeTimeWarn);
            this.pnlLifeTime.Controls.Add(this.lblLifeTimeWarnCaption);
            this.pnlLifeTime.Location = new System.Drawing.Point(0, 624);
            this.pnlLifeTime.Size = new System.Drawing.Size(800, 140);
            this.pnlLifeTime.TitleText = "Life Time";
            this.pnlLifeTime.Name = "pnlLifeTime";
            // 
            // lblLifeTimeWarnCaption
            // 
            this.lblLifeTimeWarnCaption.Location = new System.Drawing.Point(16, 50);
            this.lblLifeTimeWarnCaption.Size = new System.Drawing.Size(230, 34);
            this.lblLifeTimeWarnCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLifeTimeWarnCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLifeTimeWarnCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblLifeTimeWarnCaption.Text = "Warn from";
            this.lblLifeTimeWarnCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLifeTimeWarnCaption.Name = "lblLifeTimeWarnCaption";
            // 
            // lblLifeTimeWarn
            // 
            this.lblLifeTimeWarn.Location = new System.Drawing.Point(250, 46);
            this.lblLifeTimeWarn.Size = new System.Drawing.Size(140, 40);
            this.lblLifeTimeWarn.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLifeTimeWarn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblLifeTimeWarn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblLifeTimeWarn.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.lblLifeTimeWarn.Text = "90";
            this.lblLifeTimeWarn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLifeTimeWarn.Name = "lblLifeTimeWarn";
            // 
            // lblLifeTimeWarnUnit
            // 
            this.lblLifeTimeWarnUnit.Location = new System.Drawing.Point(398, 50);
            this.lblLifeTimeWarnUnit.Size = new System.Drawing.Size(130, 34);
            this.lblLifeTimeWarnUnit.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLifeTimeWarnUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLifeTimeWarnUnit.BackColor = System.Drawing.Color.Transparent;
            this.lblLifeTimeWarnUnit.Text = "% of the limit";
            this.lblLifeTimeWarnUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLifeTimeWarnUnit.Name = "lblLifeTimeWarnUnit";
            // 
            // btnLifeTimeWarn
            // 
            this.btnLifeTimeWarn.Location = new System.Drawing.Point(540, 46);
            this.btnLifeTimeWarn.Size = new System.Drawing.Size(120, 40);
            this.btnLifeTimeWarn.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLifeTimeWarn.Text = "SET";
            this.btnLifeTimeWarn.Name = "btnLifeTimeWarn";
            this.btnLifeTimeWarn.Click += new System.EventHandler(this.btnLifeTimeWarn_Click);
            // 
            // lblLifeTimeRule
            // 
            this.lblLifeTimeRule.Location = new System.Drawing.Point(16, 94);
            this.lblLifeTimeRule.Size = new System.Drawing.Size(764, 34);
            this.lblLifeTimeRule.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLifeTimeRule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLifeTimeRule.BackColor = System.Drawing.Color.Transparent;
            this.lblLifeTimeRule.Text = "Items at or past this share show WARN on Life Time; at the limit they show OVER.";
            this.lblLifeTimeRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLifeTimeRule.Name = "lblLifeTimeRule";
            // 
            // pnlInput
            // 
            this.pnlInput.Controls.Add(this.lblKeyboardRule);
            this.pnlInput.Controls.Add(this.btnKeyboardHardware);
            this.pnlInput.Controls.Add(this.btnKeyboardSoftware);
            this.pnlInput.Controls.Add(this.lblKeyboardCaption);
            this.pnlInput.Location = new System.Drawing.Point(812, 0);
            this.pnlInput.Size = new System.Drawing.Size(832, 240);
            this.pnlInput.TitleText = "Input";
            this.pnlInput.Name = "pnlInput";
            // 
            // lblKeyboardCaption
            // 
            this.lblKeyboardCaption.Location = new System.Drawing.Point(16, 50);
            this.lblKeyboardCaption.Size = new System.Drawing.Size(200, 34);
            this.lblKeyboardCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKeyboardCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblKeyboardCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblKeyboardCaption.Text = "Keyboard";
            this.lblKeyboardCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKeyboardCaption.Name = "lblKeyboardCaption";
            // 
            // btnKeyboardSoftware
            // 
            this.btnKeyboardSoftware.Location = new System.Drawing.Point(220, 44);
            this.btnKeyboardSoftware.Size = new System.Drawing.Size(280, 56);
            this.btnKeyboardSoftware.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyboardSoftware.Text = "SOFTWARE";
            this.btnKeyboardSoftware.Name = "btnKeyboardSoftware";
            this.btnKeyboardSoftware.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // btnKeyboardHardware
            // 
            this.btnKeyboardHardware.Location = new System.Drawing.Point(516, 44);
            this.btnKeyboardHardware.Size = new System.Drawing.Size(280, 56);
            this.btnKeyboardHardware.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKeyboardHardware.Text = "HARDWARE";
            this.btnKeyboardHardware.Name = "btnKeyboardHardware";
            this.btnKeyboardHardware.Click += new System.EventHandler(this.btnKeyboard_Click);
            // 
            // lblKeyboardRule
            // 
            this.lblKeyboardRule.Location = new System.Drawing.Point(16, 116);
            this.lblKeyboardRule.Size = new System.Drawing.Size(800, 60);
            this.lblKeyboardRule.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblKeyboardRule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblKeyboardRule.BackColor = System.Drawing.Color.Transparent;
            this.lblKeyboardRule.Text = "SOFTWARE opens the on-screen keyboard when a text box is touched.\r\nHARDWARE leaves typing to an attached keyboard.";
            this.lblKeyboardRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblKeyboardRule.Name = "lblKeyboardRule";
            // 
            // pnlLanguage
            // 
            this.pnlLanguage.Controls.Add(this.lblLanguageRule);
            this.pnlLanguage.Controls.Add(this.btnLanguageZH);
            this.pnlLanguage.Controls.Add(this.btnLanguageKO);
            this.pnlLanguage.Controls.Add(this.btnLanguageEN);
            this.pnlLanguage.Controls.Add(this.lblLanguageCaption);
            this.pnlLanguage.Location = new System.Drawing.Point(812, 252);
            this.pnlLanguage.Size = new System.Drawing.Size(832, 240);
            this.pnlLanguage.TitleText = "Language";
            this.pnlLanguage.Name = "pnlLanguage";
            // 
            // lblLanguageCaption
            // 
            this.lblLanguageCaption.Location = new System.Drawing.Point(16, 50);
            this.lblLanguageCaption.Size = new System.Drawing.Size(200, 34);
            this.lblLanguageCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLanguageCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLanguageCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblLanguageCaption.Text = "Start in";
            this.lblLanguageCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLanguageCaption.Name = "lblLanguageCaption";
            // 
            // btnLanguageEN
            // 
            this.btnLanguageEN.Location = new System.Drawing.Point(220, 44);
            this.btnLanguageEN.Size = new System.Drawing.Size(184, 56);
            this.btnLanguageEN.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLanguageEN.Text = "English";
            this.btnLanguageEN.Tag = "EN";
            this.btnLanguageEN.Name = "btnLanguageEN";
            this.btnLanguageEN.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // btnLanguageKO
            // 
            this.btnLanguageKO.Location = new System.Drawing.Point(416, 44);
            this.btnLanguageKO.Size = new System.Drawing.Size(184, 56);
            this.btnLanguageKO.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLanguageKO.Text = "한국어";
            this.btnLanguageKO.Tag = "KO";
            this.btnLanguageKO.Name = "btnLanguageKO";
            this.btnLanguageKO.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // btnLanguageZH
            // 
            this.btnLanguageZH.Location = new System.Drawing.Point(612, 44);
            this.btnLanguageZH.Size = new System.Drawing.Size(184, 56);
            this.btnLanguageZH.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLanguageZH.Text = "中文";
            this.btnLanguageZH.Tag = "ZH";
            this.btnLanguageZH.Name = "btnLanguageZH";
            this.btnLanguageZH.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // lblLanguageRule
            // 
            this.lblLanguageRule.Location = new System.Drawing.Point(16, 116);
            this.lblLanguageRule.Size = new System.Drawing.Size(800, 60);
            this.lblLanguageRule.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLanguageRule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLanguageRule.BackColor = System.Drawing.Color.Transparent;
            this.lblLanguageRule.Text = "The language the program starts in. Lang on the top bar switches it\r\nfor the session. Captions come from the files in the Language folder.";
            this.lblLanguageRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLanguageRule.Name = "lblLanguageRule";
            // 
            // pnlSave
            // 
            this.pnlSave.Controls.Add(this.lblResult);
            this.pnlSave.Controls.Add(this.lblStaged);
            this.pnlSave.Controls.Add(this.btnCancel);
            this.pnlSave.Controls.Add(this.btnApply);
            this.pnlSave.Location = new System.Drawing.Point(812, 504);
            this.pnlSave.Size = new System.Drawing.Size(832, 260);
            this.pnlSave.TitleText = "Save";
            this.pnlSave.Name = "pnlSave";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(16, 50);
            this.btnApply.Size = new System.Drawing.Size(280, 60);
            this.btnApply.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.Text = "APPLY";
            this.btnApply.Role = MMI.HmiButtonRole.Primary;
            this.btnApply.Name = "btnApply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(312, 50);
            this.btnCancel.Size = new System.Drawing.Size(180, 60);
            this.btnCancel.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lblStaged
            // 
            this.lblStaged.Location = new System.Drawing.Point(16, 124);
            this.lblStaged.Size = new System.Drawing.Size(800, 34);
            this.lblStaged.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStaged.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(139)))), ((int)(((byte)(253)))));
            this.lblStaged.BackColor = System.Drawing.Color.Transparent;
            this.lblStaged.Text = "";
            this.lblStaged.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStaged.Name = "lblStaged";
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(16, 160);
            this.lblResult.Size = new System.Drawing.Size(800, 60);
            this.lblResult.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Text = "";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblResult.Name = "lblResult";
            // 
            // FormDataSystem
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1644, 900);
            this.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "FormDataSystem";
            this.Controls.Add(this.pnlSave);
            this.Controls.Add(this.pnlLanguage);
            this.Controls.Add(this.pnlInput);
            this.Controls.Add(this.pnlLifeTime);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlMachine);
            this.Name = "FormDataSystem";
            this.Load += new System.EventHandler(this.FormDataSystem_Load);
            this.VisibleChanged += new System.EventHandler(this.FormDataSystem_VisibleChanged);
            this.pnlSave.ResumeLayout(false);
            this.pnlLanguage.ResumeLayout(false);
            this.pnlInput.ResumeLayout(false);
            this.pnlLifeTime.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.pnlMachine.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MMI.HmiCard pnlMachine;
        private System.Windows.Forms.Label lblMachineNameCaption;
        private System.Windows.Forms.TextBox txtMachineName;
        private MMI.HmiCard pnlLog;
        private System.Windows.Forms.Label lblLogKeepDaysCaption;
        private System.Windows.Forms.Label lblLogKeepDays;
        private System.Windows.Forms.Label lblLogKeepDaysUnit;
        private MMI.HmiButton btnLogKeepDays;
        private System.Windows.Forms.Label lblLogCutOff;
        private System.Windows.Forms.Label lblLogFoldersCaption;
        private System.Windows.Forms.ListBox lstLogFolders;
        private System.Windows.Forms.Label lblLogRule;
        private MMI.HmiButton btnPurgeNow;
        private System.Windows.Forms.Label lblPurgeResult;
        private MMI.HmiCard pnlLifeTime;
        private System.Windows.Forms.Label lblLifeTimeWarnCaption;
        private System.Windows.Forms.Label lblLifeTimeWarn;
        private System.Windows.Forms.Label lblLifeTimeWarnUnit;
        private MMI.HmiButton btnLifeTimeWarn;
        private System.Windows.Forms.Label lblLifeTimeRule;
        private MMI.HmiCard pnlInput;
        private System.Windows.Forms.Label lblKeyboardCaption;
        private MMI.HmiButton btnKeyboardSoftware;
        private MMI.HmiButton btnKeyboardHardware;
        private System.Windows.Forms.Label lblKeyboardRule;
        private MMI.HmiCard pnlLanguage;
        private System.Windows.Forms.Label lblLanguageCaption;
        private MMI.HmiButton btnLanguageEN;
        private MMI.HmiButton btnLanguageKO;
        private MMI.HmiButton btnLanguageZH;
        private System.Windows.Forms.Label lblLanguageRule;
        private MMI.HmiCard pnlSave;
        private MMI.HmiButton btnApply;
        private MMI.HmiButton btnCancel;
        private System.Windows.Forms.Label lblStaged;
        private System.Windows.Forms.Label lblResult;
    }
}
