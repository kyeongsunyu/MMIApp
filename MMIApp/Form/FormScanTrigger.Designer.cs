namespace MMI
{
    partial class FormScanTrigger
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
            this.pnlScanTrigger = new MMI.HmiCard();
            this.rdoScanTrigPeriodic = new System.Windows.Forms.RadioButton();
            this.rdoScanTrigTimer = new System.Windows.Forms.RadioButton();
            this.lblcapScanTrig5 = new System.Windows.Forms.Label();
            this.txtScanTrigMotionStart = new System.Windows.Forms.TextBox();
            this.lblcapScanTrig0 = new System.Windows.Forms.Label();
            this.txtScanTrigStart = new System.Windows.Forms.TextBox();
            this.lblcapScanTrig1 = new System.Windows.Forms.Label();
            this.txtScanTrigEnd = new System.Windows.Forms.TextBox();
            this.lblcapScanTrig6 = new System.Windows.Forms.Label();
            this.txtScanTrigMotionEnd = new System.Windows.Forms.TextBox();
            this.lblcapScanTrig2 = new System.Windows.Forms.Label();
            this.txtScanTrigPitch = new System.Windows.Forms.TextBox();
            this.lblcapScanTrig3 = new System.Windows.Forms.Label();
            this.txtScanTrigSpeed = new System.Windows.Forms.TextBox();
            this.lblcapScanTrig4 = new System.Windows.Forms.Label();
            this.txtScanTrigPulse = new System.Windows.Forms.TextBox();
            this.lblcapScanTrigR0 = new System.Windows.Forms.Label();
            this.lblScanTrigRate = new System.Windows.Forms.Label();
            this.lblcapScanTrigR1 = new System.Windows.Forms.Label();
            this.lblScanTrigLines = new System.Windows.Forms.Label();
            this.lblcapScanTrigR2 = new System.Windows.Forms.Label();
            this.lblScanTrigTime = new System.Windows.Forms.Label();
            this.lblcapScanTrigR3 = new System.Windows.Forms.Label();
            this.lblScanTrigCounts = new System.Windows.Forms.Label();
            this.lblcapScanTrigR4 = new System.Windows.Forms.Label();
            this.lblScanTrigState = new System.Windows.Forms.Label();
            this.lblcapScanTrigR5 = new System.Windows.Forms.Label();
            this.lblScanTrigResult = new System.Windows.Forms.Label();
            this.btnScanTrigSet = new MMI.HmiButton();
            this.btnScanTrigStart = new MMI.HmiButton();
            this.btnScanTrigStop = new MMI.HmiButton();
            this.btnScanTrigTest = new MMI.HmiButton();
            this.pnlGeometry = new MMI.HmiCard();
            this.pnlGeometryView = new System.Windows.Forms.Panel();
            this.pnlCounter = new MMI.HmiCard();
            this.lblEncPosCaption = new System.Windows.Forms.Label();
            this.lblEncPos = new System.Windows.Forms.Label();
            this.lblEncCountCaption = new System.Windows.Forms.Label();
            this.lblEncCount = new System.Windows.Forms.Label();
            this.lblTrigCountCaption = new System.Windows.Forms.Label();
            this.lblTrigCount = new System.Windows.Forms.Label();
            this.lblProgressCaption = new System.Windows.Forms.Label();
            this.pnlProgressTrack = new System.Windows.Forms.Panel();
            this.pnlProgressFill = new System.Windows.Forms.Panel();
            this.lblProgress = new System.Windows.Forms.Label();
            this.lblOutputCaption = new System.Windows.Forms.Label();
            this.lblOutput = new System.Windows.Forms.Label();
            this.lblArmCaption = new System.Windows.Forms.Label();
            this.lblArmCount = new System.Windows.Forms.Label();
            this.lblBlockCaption = new System.Windows.Forms.Label();
            this.lblBlock = new System.Windows.Forms.Label();
            this.lblWrongWayCaption = new System.Windows.Forms.Label();
            this.lblWrongWay = new System.Windows.Forms.Label();
            this.btnTrigCountClear = new MMI.HmiButton();
            this.btnEncToAxis = new MMI.HmiButton();
            this.lblCounterResult = new System.Windows.Forms.Label();
            this.pnlHwCfg = new MMI.HmiCard();
            this.lblChannelCaption = new System.Windows.Forms.Label();
            this.cbChannel = new System.Windows.Forms.ComboBox();
            this.lblEncInputCaption = new System.Windows.Forms.Label();
            this.cbEncInput = new System.Windows.Forms.ComboBox();
            this.lblLevelCaption = new System.Windows.Forms.Label();
            this.cbLevel = new System.Windows.Forms.ComboBox();
            this.lblDirectionCaption = new System.Windows.Forms.Label();
            this.cbDirection = new System.Windows.Forms.ComboBox();
            this.lblOutPortCaption = new System.Windows.Forms.Label();
            this.chkOut0 = new System.Windows.Forms.CheckBox();
            this.chkOut1 = new System.Windows.Forms.CheckBox();
            this.chkOut2 = new System.Windows.Forms.CheckBox();
            this.chkOut3 = new System.Windows.Forms.CheckBox();
            this.lblUnitCaption = new System.Windows.Forms.Label();
            this.txtEncUnit = new System.Windows.Forms.TextBox();
            this.lblReverseCaption = new System.Windows.Forms.Label();
            this.chkEncReverse = new System.Windows.Forms.CheckBox();
            this.lblWrongWayLimitCaption = new System.Windows.Forms.Label();
            this.txtWrongWay = new System.Windows.Forms.TextBox();
            this.lblHwCfgResult = new System.Windows.Forms.Label();
            this.btnHwRead = new MMI.HmiButton();
            this.btnHwWrite = new MMI.HmiButton();
            this.btnHwDefaults = new MMI.HmiButton();
            this.pnlLog = new MMI.HmiCard();
            this.btnLogClear = new MMI.HmiButton();
            this.pnlMotor = new MMI.HmiCard();
            this.lblAxisCaption = new System.Windows.Forms.Label();
            this.cbAxis = new System.Windows.Forms.ComboBox();
            this.lblCurIdxCaption = new System.Windows.Forms.Label();
            this.lblCurIdx = new System.Windows.Forms.Label();
            this.lblNextIdxCaption = new System.Windows.Forms.Label();
            this.lblNextIdx = new System.Windows.Forms.Label();
            this.lblCurPosCaption = new System.Windows.Forms.Label();
            this.lblCurPos = new System.Windows.Forms.Label();
            this.lblNextPosCaption = new System.Windows.Forms.Label();
            this.lblNextPos = new System.Windows.Forms.Label();
            this.lblStsMinusLimit = new System.Windows.Forms.Label();
            this.lblStsPlusLimit = new System.Windows.Forms.Label();
            this.lblStsOrg = new System.Windows.Forms.Label();
            this.lblStsHome = new System.Windows.Forms.Label();
            this.lblStsMoving = new System.Windows.Forms.Label();
            this.lblStsAlarm = new System.Windows.Forms.Label();
            this.btnServo = new MMI.HmiButton();
            this.btnHome = new MMI.HmiButton();
            this.btnAlarmReset = new MMI.HmiButton();
            this.pnlJog = new MMI.HmiCard();
            this.btnJogEnable = new MMI.HmiButton();
            this.lblStepCaption = new System.Windows.Forms.Label();
            this.lblStep = new System.Windows.Forms.Label();
            this.lblJogVelCaption = new System.Windows.Forms.Label();
            this.txtJogVel = new System.Windows.Forms.TextBox();
            this.btnStepP0 = new MMI.HmiButton();
            this.btnStepP1 = new MMI.HmiButton();
            this.btnStepP2 = new MMI.HmiButton();
            this.btnStepP3 = new MMI.HmiButton();
            this.btnStepP4 = new MMI.HmiButton();
            this.btnStepM0 = new MMI.HmiButton();
            this.btnStepM1 = new MMI.HmiButton();
            this.btnStepM2 = new MMI.HmiButton();
            this.btnStepM3 = new MMI.HmiButton();
            this.btnStepM4 = new MMI.HmiButton();
            this.btnModeStep = new MMI.HmiButton();
            this.btnModeJog = new MMI.HmiButton();
            this.lblModeHint = new System.Windows.Forms.Label();
            this.btnJogMinus = new MMI.HmiButton();
            this.btnJogPlus = new MMI.HmiButton();
            this.lblJogResult = new System.Windows.Forms.Label();
            this.tmView = new System.Windows.Forms.Timer(this.components);
            this.pnlLogButtons = new System.Windows.Forms.Panel();
            this.lstLog = new System.Windows.Forms.ListBox();
            this.pnlScanTrigger.SuspendLayout();
            this.pnlGeometry.SuspendLayout();
            this.pnlGeometryView.SuspendLayout();
            this.pnlCounter.SuspendLayout();
            this.pnlProgressTrack.SuspendLayout();
            this.pnlProgressFill.SuspendLayout();
            this.pnlHwCfg.SuspendLayout();
            this.pnlLog.SuspendLayout();
            this.pnlMotor.SuspendLayout();
            this.pnlJog.SuspendLayout();
            this.pnlLogButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlScanTrigger
            // 
            this.pnlScanTrigger.Controls.Add(this.btnScanTrigTest);
            this.pnlScanTrigger.Controls.Add(this.btnScanTrigStop);
            this.pnlScanTrigger.Controls.Add(this.btnScanTrigStart);
            this.pnlScanTrigger.Controls.Add(this.btnScanTrigSet);
            this.pnlScanTrigger.Controls.Add(this.lblScanTrigResult);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrigR5);
            this.pnlScanTrigger.Controls.Add(this.lblScanTrigState);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrigR4);
            this.pnlScanTrigger.Controls.Add(this.lblScanTrigCounts);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrigR3);
            this.pnlScanTrigger.Controls.Add(this.lblScanTrigTime);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrigR2);
            this.pnlScanTrigger.Controls.Add(this.lblScanTrigLines);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrigR1);
            this.pnlScanTrigger.Controls.Add(this.lblScanTrigRate);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrigR0);
            this.pnlScanTrigger.Controls.Add(this.txtScanTrigPulse);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrig4);
            this.pnlScanTrigger.Controls.Add(this.txtScanTrigSpeed);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrig3);
            this.pnlScanTrigger.Controls.Add(this.txtScanTrigPitch);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrig2);
            this.pnlScanTrigger.Controls.Add(this.txtScanTrigMotionEnd);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrig6);
            this.pnlScanTrigger.Controls.Add(this.txtScanTrigEnd);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrig1);
            this.pnlScanTrigger.Controls.Add(this.txtScanTrigStart);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrig0);
            this.pnlScanTrigger.Controls.Add(this.txtScanTrigMotionStart);
            this.pnlScanTrigger.Controls.Add(this.lblcapScanTrig5);
            this.pnlScanTrigger.Controls.Add(this.rdoScanTrigTimer);
            this.pnlScanTrigger.Controls.Add(this.rdoScanTrigPeriodic);
            this.pnlScanTrigger.Location = new System.Drawing.Point(0, 86);
            this.pnlScanTrigger.Size = new System.Drawing.Size(540, 530);
            this.pnlScanTrigger.TitleText = "Scan Trigger";
            this.pnlScanTrigger.Name = "pnlScanTrigger";
            // 
            // rdoScanTrigPeriodic
            // 
            this.rdoScanTrigPeriodic.Location = new System.Drawing.Point(14, 38);
            this.rdoScanTrigPeriodic.Size = new System.Drawing.Size(170, 26);
            this.rdoScanTrigPeriodic.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoScanTrigPeriodic.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.rdoScanTrigPeriodic.Checked = true;
            this.rdoScanTrigPeriodic.TabStop = true;
            this.rdoScanTrigPeriodic.Text = "PERIODIC (enc)";
            this.rdoScanTrigPeriodic.Name = "rdoScanTrigPeriodic";
            this.rdoScanTrigPeriodic.CheckedChanged += new System.EventHandler(this.ScanTriggerMode_CheckedChanged);
            // 
            // rdoScanTrigTimer
            // 
            this.rdoScanTrigTimer.Location = new System.Drawing.Point(200, 38);
            this.rdoScanTrigTimer.Size = new System.Drawing.Size(170, 26);
            this.rdoScanTrigTimer.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rdoScanTrigTimer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.rdoScanTrigTimer.Text = "TIMER (freq)";
            this.rdoScanTrigTimer.Name = "rdoScanTrigTimer";
            this.rdoScanTrigTimer.CheckedChanged += new System.EventHandler(this.ScanTriggerMode_CheckedChanged);
            // 
            // lblcapScanTrig5
            // 
            this.lblcapScanTrig5.Location = new System.Drawing.Point(14, 72);
            this.lblcapScanTrig5.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrig5.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrig5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrig5.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrig5.Text = "Motion Start (mm)";
            this.lblcapScanTrig5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrig5.Name = "lblcapScanTrig5";
            // 
            // txtScanTrigMotionStart
            // 
            this.txtScanTrigMotionStart.Location = new System.Drawing.Point(190, 72);
            this.txtScanTrigMotionStart.Size = new System.Drawing.Size(150, 28);
            this.txtScanTrigMotionStart.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtScanTrigMotionStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtScanTrigMotionStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtScanTrigMotionStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScanTrigMotionStart.Text = "0.000";
            this.txtScanTrigMotionStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtScanTrigMotionStart.Name = "txtScanTrigMotionStart";
            this.txtScanTrigMotionStart.TextChanged += new System.EventHandler(this.ScanTriggerInput_TextChanged);
            // 
            // lblcapScanTrig0
            // 
            this.lblcapScanTrig0.Location = new System.Drawing.Point(14, 106);
            this.lblcapScanTrig0.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrig0.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrig0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrig0.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrig0.Text = "Trig Start (mm)";
            this.lblcapScanTrig0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrig0.Name = "lblcapScanTrig0";
            // 
            // txtScanTrigStart
            // 
            this.txtScanTrigStart.Location = new System.Drawing.Point(190, 106);
            this.txtScanTrigStart.Size = new System.Drawing.Size(150, 28);
            this.txtScanTrigStart.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtScanTrigStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtScanTrigStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtScanTrigStart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScanTrigStart.Text = "0.000";
            this.txtScanTrigStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtScanTrigStart.Name = "txtScanTrigStart";
            this.txtScanTrigStart.TextChanged += new System.EventHandler(this.ScanTriggerInput_TextChanged);
            // 
            // lblcapScanTrig1
            // 
            this.lblcapScanTrig1.Location = new System.Drawing.Point(14, 140);
            this.lblcapScanTrig1.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrig1.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrig1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrig1.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrig1.Text = "Trig End (mm)";
            this.lblcapScanTrig1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrig1.Name = "lblcapScanTrig1";
            // 
            // txtScanTrigEnd
            // 
            this.txtScanTrigEnd.Location = new System.Drawing.Point(190, 140);
            this.txtScanTrigEnd.Size = new System.Drawing.Size(150, 28);
            this.txtScanTrigEnd.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtScanTrigEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtScanTrigEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtScanTrigEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScanTrigEnd.Text = "0.000";
            this.txtScanTrigEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtScanTrigEnd.Name = "txtScanTrigEnd";
            this.txtScanTrigEnd.TextChanged += new System.EventHandler(this.ScanTriggerInput_TextChanged);
            // 
            // lblcapScanTrig6
            // 
            this.lblcapScanTrig6.Location = new System.Drawing.Point(14, 174);
            this.lblcapScanTrig6.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrig6.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrig6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrig6.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrig6.Text = "Motion End (mm)";
            this.lblcapScanTrig6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrig6.Name = "lblcapScanTrig6";
            // 
            // txtScanTrigMotionEnd
            // 
            this.txtScanTrigMotionEnd.Location = new System.Drawing.Point(190, 174);
            this.txtScanTrigMotionEnd.Size = new System.Drawing.Size(150, 28);
            this.txtScanTrigMotionEnd.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtScanTrigMotionEnd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtScanTrigMotionEnd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtScanTrigMotionEnd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScanTrigMotionEnd.Text = "0.000";
            this.txtScanTrigMotionEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtScanTrigMotionEnd.Name = "txtScanTrigMotionEnd";
            this.txtScanTrigMotionEnd.TextChanged += new System.EventHandler(this.ScanTriggerInput_TextChanged);
            // 
            // lblcapScanTrig2
            // 
            this.lblcapScanTrig2.Location = new System.Drawing.Point(14, 208);
            this.lblcapScanTrig2.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrig2.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrig2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrig2.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrig2.Text = "Pixel Res (um)";
            this.lblcapScanTrig2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrig2.Name = "lblcapScanTrig2";
            // 
            // txtScanTrigPitch
            // 
            this.txtScanTrigPitch.Location = new System.Drawing.Point(190, 208);
            this.txtScanTrigPitch.Size = new System.Drawing.Size(150, 28);
            this.txtScanTrigPitch.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtScanTrigPitch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtScanTrigPitch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtScanTrigPitch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScanTrigPitch.Text = "0.000";
            this.txtScanTrigPitch.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtScanTrigPitch.Name = "txtScanTrigPitch";
            this.txtScanTrigPitch.TextChanged += new System.EventHandler(this.ScanTriggerInput_TextChanged);
            // 
            // lblcapScanTrig3
            // 
            this.lblcapScanTrig3.Location = new System.Drawing.Point(14, 242);
            this.lblcapScanTrig3.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrig3.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrig3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrig3.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrig3.Text = "Speed (mm/s)";
            this.lblcapScanTrig3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrig3.Name = "lblcapScanTrig3";
            // 
            // txtScanTrigSpeed
            // 
            this.txtScanTrigSpeed.Location = new System.Drawing.Point(190, 242);
            this.txtScanTrigSpeed.Size = new System.Drawing.Size(150, 28);
            this.txtScanTrigSpeed.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtScanTrigSpeed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtScanTrigSpeed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtScanTrigSpeed.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScanTrigSpeed.Text = "0.000";
            this.txtScanTrigSpeed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtScanTrigSpeed.Name = "txtScanTrigSpeed";
            this.txtScanTrigSpeed.TextChanged += new System.EventHandler(this.ScanTriggerInput_TextChanged);
            // 
            // lblcapScanTrig4
            // 
            this.lblcapScanTrig4.Location = new System.Drawing.Point(14, 276);
            this.lblcapScanTrig4.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrig4.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrig4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrig4.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrig4.Text = "Pulse W (us)";
            this.lblcapScanTrig4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrig4.Name = "lblcapScanTrig4";
            // 
            // txtScanTrigPulse
            // 
            this.txtScanTrigPulse.Location = new System.Drawing.Point(190, 276);
            this.txtScanTrigPulse.Size = new System.Drawing.Size(150, 28);
            this.txtScanTrigPulse.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtScanTrigPulse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtScanTrigPulse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtScanTrigPulse.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtScanTrigPulse.Text = "10.00";
            this.txtScanTrigPulse.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtScanTrigPulse.Name = "txtScanTrigPulse";
            this.txtScanTrigPulse.TextChanged += new System.EventHandler(this.ScanTriggerInput_TextChanged);
            // 
            // lblcapScanTrigR0
            // 
            this.lblcapScanTrigR0.Location = new System.Drawing.Point(14, 318);
            this.lblcapScanTrigR0.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrigR0.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrigR0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrigR0.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrigR0.Text = "Line Rate (kHz)";
            this.lblcapScanTrigR0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrigR0.Name = "lblcapScanTrigR0";
            // 
            // lblScanTrigRate
            // 
            this.lblScanTrigRate.Location = new System.Drawing.Point(190, 318);
            this.lblScanTrigRate.Size = new System.Drawing.Size(150, 28);
            this.lblScanTrigRate.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblScanTrigRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblScanTrigRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigRate.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblScanTrigRate.Text = "-";
            this.lblScanTrigRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigRate.Name = "lblScanTrigRate";
            // 
            // lblcapScanTrigR1
            // 
            this.lblcapScanTrigR1.Location = new System.Drawing.Point(14, 350);
            this.lblcapScanTrigR1.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrigR1.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrigR1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrigR1.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrigR1.Text = "Lines";
            this.lblcapScanTrigR1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrigR1.Name = "lblcapScanTrigR1";
            // 
            // lblScanTrigLines
            // 
            this.lblScanTrigLines.Location = new System.Drawing.Point(190, 350);
            this.lblScanTrigLines.Size = new System.Drawing.Size(150, 28);
            this.lblScanTrigLines.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblScanTrigLines.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblScanTrigLines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigLines.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblScanTrigLines.Text = "-";
            this.lblScanTrigLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigLines.Name = "lblScanTrigLines";
            // 
            // lblcapScanTrigR2
            // 
            this.lblcapScanTrigR2.Location = new System.Drawing.Point(14, 382);
            this.lblcapScanTrigR2.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrigR2.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrigR2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrigR2.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrigR2.Text = "Scan Time (s)";
            this.lblcapScanTrigR2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrigR2.Name = "lblcapScanTrigR2";
            // 
            // lblScanTrigTime
            // 
            this.lblScanTrigTime.Location = new System.Drawing.Point(190, 382);
            this.lblScanTrigTime.Size = new System.Drawing.Size(150, 28);
            this.lblScanTrigTime.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblScanTrigTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblScanTrigTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigTime.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblScanTrigTime.Text = "-";
            this.lblScanTrigTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigTime.Name = "lblScanTrigTime";
            // 
            // lblcapScanTrigR3
            // 
            this.lblcapScanTrigR3.Location = new System.Drawing.Point(14, 414);
            this.lblcapScanTrigR3.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrigR3.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrigR3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrigR3.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrigR3.Text = "Enc Count";
            this.lblcapScanTrigR3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrigR3.Name = "lblcapScanTrigR3";
            // 
            // lblScanTrigCounts
            // 
            this.lblScanTrigCounts.Location = new System.Drawing.Point(190, 414);
            this.lblScanTrigCounts.Size = new System.Drawing.Size(150, 28);
            this.lblScanTrigCounts.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblScanTrigCounts.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblScanTrigCounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigCounts.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblScanTrigCounts.Text = "-";
            this.lblScanTrigCounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigCounts.Name = "lblScanTrigCounts";
            // 
            // lblcapScanTrigR4
            // 
            this.lblcapScanTrigR4.Location = new System.Drawing.Point(14, 446);
            this.lblcapScanTrigR4.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrigR4.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrigR4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrigR4.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrigR4.Text = "State";
            this.lblcapScanTrigR4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrigR4.Name = "lblcapScanTrigR4";
            // 
            // lblScanTrigState
            // 
            this.lblScanTrigState.Location = new System.Drawing.Point(190, 446);
            this.lblScanTrigState.Size = new System.Drawing.Size(150, 28);
            this.lblScanTrigState.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblScanTrigState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblScanTrigState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigState.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblScanTrigState.Text = "-";
            this.lblScanTrigState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigState.Name = "lblScanTrigState";
            // 
            // lblcapScanTrigR5
            // 
            this.lblcapScanTrigR5.Location = new System.Drawing.Point(14, 478);
            this.lblcapScanTrigR5.Size = new System.Drawing.Size(170, 28);
            this.lblcapScanTrigR5.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblcapScanTrigR5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblcapScanTrigR5.BackColor = System.Drawing.Color.Transparent;
            this.lblcapScanTrigR5.Text = "Result";
            this.lblcapScanTrigR5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblcapScanTrigR5.Name = "lblcapScanTrigR5";
            // 
            // lblScanTrigResult
            // 
            this.lblScanTrigResult.Location = new System.Drawing.Point(190, 478);
            this.lblScanTrigResult.Size = new System.Drawing.Size(150, 28);
            this.lblScanTrigResult.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblScanTrigResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblScanTrigResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigResult.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblScanTrigResult.Text = "-";
            this.lblScanTrigResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigResult.Name = "lblScanTrigResult";
            // 
            // btnScanTrigSet
            // 
            this.btnScanTrigSet.Location = new System.Drawing.Point(356, 72);
            this.btnScanTrigSet.Size = new System.Drawing.Size(170, 44);
            this.btnScanTrigSet.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnScanTrigSet.Text = "SET";
            this.btnScanTrigSet.Role = MMI.HmiButtonRole.Primary;
            this.btnScanTrigSet.Name = "btnScanTrigSet";
            this.btnScanTrigSet.Click += new System.EventHandler(this.btnScanTrigSet_Click);
            // 
            // btnScanTrigStart
            // 
            this.btnScanTrigStart.Location = new System.Drawing.Point(356, 124);
            this.btnScanTrigStart.Size = new System.Drawing.Size(170, 44);
            this.btnScanTrigStart.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnScanTrigStart.Text = "START";
            this.btnScanTrigStart.Role = MMI.HmiButtonRole.Success;
            this.btnScanTrigStart.Enabled = false;
            this.btnScanTrigStart.Name = "btnScanTrigStart";
            this.btnScanTrigStart.Click += new System.EventHandler(this.btnScanTrigStart_Click);
            // 
            // btnScanTrigStop
            // 
            this.btnScanTrigStop.Location = new System.Drawing.Point(356, 176);
            this.btnScanTrigStop.Size = new System.Drawing.Size(170, 44);
            this.btnScanTrigStop.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnScanTrigStop.Text = "STOP";
            this.btnScanTrigStop.Role = MMI.HmiButtonRole.Danger;
            this.btnScanTrigStop.Name = "btnScanTrigStop";
            this.btnScanTrigStop.Click += new System.EventHandler(this.btnScanTrigStop_Click);
            // 
            // btnScanTrigTest
            // 
            this.btnScanTrigTest.Location = new System.Drawing.Point(356, 228);
            this.btnScanTrigTest.Size = new System.Drawing.Size(170, 44);
            this.btnScanTrigTest.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnScanTrigTest.Text = "OUTPUT TEST";
            this.btnScanTrigTest.Name = "btnScanTrigTest";
            this.btnScanTrigTest.Click += new System.EventHandler(this.btnScanTrigTest_Click);
            // 
            // pnlGeometry
            // 
            this.pnlGeometry.Controls.Add(this.pnlGeometryView);
            this.pnlGeometry.Location = new System.Drawing.Point(552, 86);
            this.pnlGeometry.Size = new System.Drawing.Size(500, 250);
            this.pnlGeometry.TitleText = "Scan Geometry  (motor index 50 - 53)";
            this.pnlGeometry.Name = "pnlGeometry";
            // 
            // pnlGeometryView
            // 
            this.pnlGeometryView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGeometryView.Size = new System.Drawing.Size(480, 200);
            this.pnlGeometryView.BackColor = System.Drawing.Color.Transparent;
            this.pnlGeometryView.Name = "pnlGeometryView";
            this.pnlGeometryView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlGeometryView_Paint);
            // 
            // pnlCounter
            // 
            this.pnlCounter.Controls.Add(this.lblCounterResult);
            this.pnlCounter.Controls.Add(this.btnEncToAxis);
            this.pnlCounter.Controls.Add(this.btnTrigCountClear);
            this.pnlCounter.Controls.Add(this.lblWrongWay);
            this.pnlCounter.Controls.Add(this.lblWrongWayCaption);
            this.pnlCounter.Controls.Add(this.lblBlock);
            this.pnlCounter.Controls.Add(this.lblBlockCaption);
            this.pnlCounter.Controls.Add(this.lblArmCount);
            this.pnlCounter.Controls.Add(this.lblArmCaption);
            this.pnlCounter.Controls.Add(this.lblOutput);
            this.pnlCounter.Controls.Add(this.lblOutputCaption);
            this.pnlCounter.Controls.Add(this.lblProgress);
            this.pnlCounter.Controls.Add(this.pnlProgressTrack);
            this.pnlCounter.Controls.Add(this.lblProgressCaption);
            this.pnlCounter.Controls.Add(this.lblTrigCount);
            this.pnlCounter.Controls.Add(this.lblTrigCountCaption);
            this.pnlCounter.Controls.Add(this.lblEncCount);
            this.pnlCounter.Controls.Add(this.lblEncCountCaption);
            this.pnlCounter.Controls.Add(this.lblEncPos);
            this.pnlCounter.Controls.Add(this.lblEncPosCaption);
            this.pnlCounter.Location = new System.Drawing.Point(552, 348);
            this.pnlCounter.Size = new System.Drawing.Size(500, 564);
            this.pnlCounter.TitleText = "Live Counter";
            this.pnlCounter.Name = "pnlCounter";
            // 
            // lblEncPosCaption
            // 
            this.lblEncPosCaption.Location = new System.Drawing.Point(14, 42);
            this.lblEncPosCaption.Size = new System.Drawing.Size(190, 44);
            this.lblEncPosCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEncPosCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblEncPosCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblEncPosCaption.Text = "Encoder Position (mm)";
            this.lblEncPosCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEncPosCaption.Name = "lblEncPosCaption";
            // 
            // lblEncPos
            // 
            this.lblEncPos.Location = new System.Drawing.Point(210, 42);
            this.lblEncPos.Size = new System.Drawing.Size(270, 44);
            this.lblEncPos.Font = new System.Drawing.Font("Malgun Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEncPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblEncPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblEncPos.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblEncPos.Text = "-";
            this.lblEncPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEncPos.Name = "lblEncPos";
            // 
            // lblEncCountCaption
            // 
            this.lblEncCountCaption.Location = new System.Drawing.Point(14, 96);
            this.lblEncCountCaption.Size = new System.Drawing.Size(190, 44);
            this.lblEncCountCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEncCountCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblEncCountCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblEncCountCaption.Text = "Encoder (counts)";
            this.lblEncCountCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEncCountCaption.Name = "lblEncCountCaption";
            // 
            // lblEncCount
            // 
            this.lblEncCount.Location = new System.Drawing.Point(210, 96);
            this.lblEncCount.Size = new System.Drawing.Size(270, 44);
            this.lblEncCount.Font = new System.Drawing.Font("Malgun Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEncCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblEncCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblEncCount.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblEncCount.Text = "-";
            this.lblEncCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblEncCount.Name = "lblEncCount";
            // 
            // lblTrigCountCaption
            // 
            this.lblTrigCountCaption.Location = new System.Drawing.Point(14, 150);
            this.lblTrigCountCaption.Size = new System.Drawing.Size(190, 44);
            this.lblTrigCountCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTrigCountCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblTrigCountCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblTrigCountCaption.Text = "Trigger Count";
            this.lblTrigCountCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTrigCountCaption.Name = "lblTrigCountCaption";
            // 
            // lblTrigCount
            // 
            this.lblTrigCount.Location = new System.Drawing.Point(210, 150);
            this.lblTrigCount.Size = new System.Drawing.Size(270, 44);
            this.lblTrigCount.Font = new System.Drawing.Font("Malgun Gothic", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTrigCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblTrigCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblTrigCount.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblTrigCount.Text = "-";
            this.lblTrigCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTrigCount.Name = "lblTrigCount";
            // 
            // lblProgressCaption
            // 
            this.lblProgressCaption.Location = new System.Drawing.Point(14, 204);
            this.lblProgressCaption.Size = new System.Drawing.Size(190, 28);
            this.lblProgressCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProgressCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblProgressCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblProgressCaption.Text = "Progress";
            this.lblProgressCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblProgressCaption.Name = "lblProgressCaption";
            // 
            // pnlProgressTrack
            // 
            this.pnlProgressTrack.Controls.Add(this.pnlProgressFill);
            this.pnlProgressTrack.Location = new System.Drawing.Point(210, 210);
            this.pnlProgressTrack.Size = new System.Drawing.Size(190, 16);
            this.pnlProgressTrack.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.pnlProgressTrack.Name = "pnlProgressTrack";
            // 
            // pnlProgressFill
            // 
            this.pnlProgressFill.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlProgressFill.Size = new System.Drawing.Size(0, 16);
            this.pnlProgressFill.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(164)))), ((int)(((byte)(108)))));
            this.pnlProgressFill.Name = "pnlProgressFill";
            // 
            // lblProgress
            // 
            this.lblProgress.Location = new System.Drawing.Point(408, 204);
            this.lblProgress.Size = new System.Drawing.Size(72, 28);
            this.lblProgress.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblProgress.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblProgress.Text = "-";
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProgress.Name = "lblProgress";
            // 
            // lblOutputCaption
            // 
            this.lblOutputCaption.Location = new System.Drawing.Point(14, 244);
            this.lblOutputCaption.Size = new System.Drawing.Size(190, 28);
            this.lblOutputCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOutputCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblOutputCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblOutputCaption.Text = "Trigger Output";
            this.lblOutputCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOutputCaption.Name = "lblOutputCaption";
            // 
            // lblOutput
            // 
            this.lblOutput.Location = new System.Drawing.Point(210, 244);
            this.lblOutput.Size = new System.Drawing.Size(270, 28);
            this.lblOutput.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOutput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOutput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblOutput.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblOutput.Text = "-";
            this.lblOutput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOutput.Name = "lblOutput";
            // 
            // lblArmCaption
            // 
            this.lblArmCaption.Location = new System.Drawing.Point(14, 280);
            this.lblArmCaption.Size = new System.Drawing.Size(190, 28);
            this.lblArmCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblArmCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblArmCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblArmCaption.Text = "Armed At (counts)";
            this.lblArmCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblArmCaption.Name = "lblArmCaption";
            // 
            // lblArmCount
            // 
            this.lblArmCount.Location = new System.Drawing.Point(210, 280);
            this.lblArmCount.Size = new System.Drawing.Size(270, 28);
            this.lblArmCount.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblArmCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblArmCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblArmCount.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblArmCount.Text = "-";
            this.lblArmCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblArmCount.Name = "lblArmCount";
            // 
            // lblBlockCaption
            // 
            this.lblBlockCaption.Location = new System.Drawing.Point(14, 316);
            this.lblBlockCaption.Size = new System.Drawing.Size(190, 28);
            this.lblBlockCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBlockCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblBlockCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblBlockCaption.Text = "Block (counts)";
            this.lblBlockCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBlockCaption.Name = "lblBlockCaption";
            // 
            // lblBlock
            // 
            this.lblBlock.Location = new System.Drawing.Point(210, 316);
            this.lblBlock.Size = new System.Drawing.Size(270, 28);
            this.lblBlock.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBlock.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblBlock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblBlock.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblBlock.Text = "-";
            this.lblBlock.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBlock.Name = "lblBlock";
            // 
            // lblWrongWayCaption
            // 
            this.lblWrongWayCaption.Location = new System.Drawing.Point(14, 352);
            this.lblWrongWayCaption.Size = new System.Drawing.Size(190, 28);
            this.lblWrongWayCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWrongWayCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblWrongWayCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblWrongWayCaption.Text = "Behind Arm (counts)";
            this.lblWrongWayCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWrongWayCaption.Name = "lblWrongWayCaption";
            // 
            // lblWrongWay
            // 
            this.lblWrongWay.Location = new System.Drawing.Point(210, 352);
            this.lblWrongWay.Size = new System.Drawing.Size(270, 28);
            this.lblWrongWay.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWrongWay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblWrongWay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblWrongWay.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblWrongWay.Text = "-";
            this.lblWrongWay.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblWrongWay.Name = "lblWrongWay";
            // 
            // btnTrigCountClear
            // 
            this.btnTrigCountClear.Location = new System.Drawing.Point(14, 398);
            this.btnTrigCountClear.Size = new System.Drawing.Size(230, 44);
            this.btnTrigCountClear.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTrigCountClear.Text = "TRIGGER COUNT CLEAR";
            this.btnTrigCountClear.Name = "btnTrigCountClear";
            this.btnTrigCountClear.Click += new System.EventHandler(this.btnTrigCountClear_Click);
            // 
            // btnEncToAxis
            // 
            this.btnEncToAxis.Location = new System.Drawing.Point(254, 398);
            this.btnEncToAxis.Size = new System.Drawing.Size(230, 44);
            this.btnEncToAxis.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEncToAxis.Text = "ENCODER = AXIS POSITION";
            this.btnEncToAxis.Name = "btnEncToAxis";
            this.btnEncToAxis.Click += new System.EventHandler(this.btnEncToAxis_Click);
            // 
            // lblCounterResult
            // 
            this.lblCounterResult.Location = new System.Drawing.Point(14, 452);
            this.lblCounterResult.Size = new System.Drawing.Size(470, 28);
            this.lblCounterResult.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCounterResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblCounterResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblCounterResult.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblCounterResult.Text = "";
            this.lblCounterResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCounterResult.Name = "lblCounterResult";
            // 
            // pnlHwCfg
            // 
            this.pnlHwCfg.Controls.Add(this.btnHwDefaults);
            this.pnlHwCfg.Controls.Add(this.btnHwWrite);
            this.pnlHwCfg.Controls.Add(this.btnHwRead);
            this.pnlHwCfg.Controls.Add(this.lblHwCfgResult);
            this.pnlHwCfg.Controls.Add(this.txtWrongWay);
            this.pnlHwCfg.Controls.Add(this.lblWrongWayLimitCaption);
            this.pnlHwCfg.Controls.Add(this.chkEncReverse);
            this.pnlHwCfg.Controls.Add(this.lblReverseCaption);
            this.pnlHwCfg.Controls.Add(this.txtEncUnit);
            this.pnlHwCfg.Controls.Add(this.lblUnitCaption);
            this.pnlHwCfg.Controls.Add(this.chkOut3);
            this.pnlHwCfg.Controls.Add(this.chkOut2);
            this.pnlHwCfg.Controls.Add(this.chkOut1);
            this.pnlHwCfg.Controls.Add(this.chkOut0);
            this.pnlHwCfg.Controls.Add(this.lblOutPortCaption);
            this.pnlHwCfg.Controls.Add(this.cbDirection);
            this.pnlHwCfg.Controls.Add(this.lblDirectionCaption);
            this.pnlHwCfg.Controls.Add(this.cbLevel);
            this.pnlHwCfg.Controls.Add(this.lblLevelCaption);
            this.pnlHwCfg.Controls.Add(this.cbEncInput);
            this.pnlHwCfg.Controls.Add(this.lblEncInputCaption);
            this.pnlHwCfg.Controls.Add(this.cbChannel);
            this.pnlHwCfg.Controls.Add(this.lblChannelCaption);
            this.pnlHwCfg.Location = new System.Drawing.Point(1064, 86);
            this.pnlHwCfg.Size = new System.Drawing.Size(580, 470);
            this.pnlHwCfg.TitleText = "Counter H/W Config";
            this.pnlHwCfg.Name = "pnlHwCfg";
            // 
            // lblChannelCaption
            // 
            this.lblChannelCaption.Location = new System.Drawing.Point(14, 40);
            this.lblChannelCaption.Size = new System.Drawing.Size(220, 28);
            this.lblChannelCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblChannelCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblChannelCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblChannelCaption.Text = "Counter Channel";
            this.lblChannelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblChannelCaption.Name = "lblChannelCaption";
            // 
            // cbChannel
            // 
            this.cbChannel.Location = new System.Drawing.Point(240, 40);
            this.cbChannel.Size = new System.Drawing.Size(320, 28);
            this.cbChannel.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChannel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbChannel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.cbChannel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cbChannel.FormattingEnabled = true;
            this.cbChannel.Name = "cbChannel";
            this.cbChannel.Items.AddRange(new object[] { "CH 0", "CH 1", "CH 2", "CH 3" });
            this.cbChannel.SelectedIndexChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // lblEncInputCaption
            // 
            this.lblEncInputCaption.Location = new System.Drawing.Point(14, 78);
            this.lblEncInputCaption.Size = new System.Drawing.Size(220, 28);
            this.lblEncInputCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblEncInputCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblEncInputCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblEncInputCaption.Text = "Encoder Input";
            this.lblEncInputCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblEncInputCaption.Name = "lblEncInputCaption";
            // 
            // cbEncInput
            // 
            this.cbEncInput.Location = new System.Drawing.Point(240, 78);
            this.cbEncInput.Size = new System.Drawing.Size(320, 28);
            this.cbEncInput.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbEncInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEncInput.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbEncInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.cbEncInput.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cbEncInput.FormattingEnabled = true;
            this.cbEncInput.Name = "cbEncInput";
            this.cbEncInput.Items.AddRange(new object[] { "ENC 0", "ENC 1", "ENC 2", "ENC 3" });
            this.cbEncInput.SelectedIndexChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // lblLevelCaption
            // 
            this.lblLevelCaption.Location = new System.Drawing.Point(14, 116);
            this.lblLevelCaption.Size = new System.Drawing.Size(220, 28);
            this.lblLevelCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLevelCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLevelCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblLevelCaption.Text = "Active Level";
            this.lblLevelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLevelCaption.Name = "lblLevelCaption";
            // 
            // cbLevel
            // 
            this.cbLevel.Location = new System.Drawing.Point(240, 116);
            this.cbLevel.Size = new System.Drawing.Size(320, 28);
            this.cbLevel.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLevel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbLevel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.cbLevel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cbLevel.FormattingEnabled = true;
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Items.AddRange(new object[] { "LOW", "HIGH" });
            this.cbLevel.SelectedIndexChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // lblDirectionCaption
            // 
            this.lblDirectionCaption.Location = new System.Drawing.Point(14, 154);
            this.lblDirectionCaption.Size = new System.Drawing.Size(220, 28);
            this.lblDirectionCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDirectionCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblDirectionCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblDirectionCaption.Text = "Direction Check";
            this.lblDirectionCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblDirectionCaption.Name = "lblDirectionCaption";
            // 
            // cbDirection
            // 
            this.cbDirection.Location = new System.Drawing.Point(240, 154);
            this.cbDirection.Size = new System.Drawing.Size(320, 28);
            this.cbDirection.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbDirection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDirection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbDirection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.cbDirection.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cbDirection.FormattingEnabled = true;
            this.cbDirection.Name = "cbDirection";
            this.cbDirection.Items.AddRange(new object[] { "BOTH", "UP ONLY", "DOWN ONLY" });
            this.cbDirection.SelectedIndexChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // lblOutPortCaption
            // 
            this.lblOutPortCaption.Location = new System.Drawing.Point(14, 192);
            this.lblOutPortCaption.Size = new System.Drawing.Size(220, 28);
            this.lblOutPortCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOutPortCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblOutPortCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblOutPortCaption.Text = "Trigger Output";
            this.lblOutPortCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOutPortCaption.Name = "lblOutPortCaption";
            // 
            // chkOut0
            // 
            this.chkOut0.Location = new System.Drawing.Point(240, 192);
            this.chkOut0.Size = new System.Drawing.Size(76, 28);
            this.chkOut0.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkOut0.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.chkOut0.Text = "OUT 0";
            this.chkOut0.Name = "chkOut0";
            this.chkOut0.CheckedChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // chkOut1
            // 
            this.chkOut1.Location = new System.Drawing.Point(320, 192);
            this.chkOut1.Size = new System.Drawing.Size(76, 28);
            this.chkOut1.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkOut1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.chkOut1.Text = "OUT 1";
            this.chkOut1.Name = "chkOut1";
            this.chkOut1.CheckedChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // chkOut2
            // 
            this.chkOut2.Location = new System.Drawing.Point(400, 192);
            this.chkOut2.Size = new System.Drawing.Size(76, 28);
            this.chkOut2.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkOut2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.chkOut2.Text = "OUT 2";
            this.chkOut2.Name = "chkOut2";
            this.chkOut2.CheckedChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // chkOut3
            // 
            this.chkOut3.Location = new System.Drawing.Point(480, 192);
            this.chkOut3.Size = new System.Drawing.Size(76, 28);
            this.chkOut3.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkOut3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.chkOut3.Text = "OUT 3";
            this.chkOut3.Name = "chkOut3";
            this.chkOut3.CheckedChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // lblUnitCaption
            // 
            this.lblUnitCaption.Location = new System.Drawing.Point(14, 230);
            this.lblUnitCaption.Size = new System.Drawing.Size(220, 28);
            this.lblUnitCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUnitCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblUnitCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblUnitCaption.Text = "Unit per Count (mm)";
            this.lblUnitCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUnitCaption.Name = "lblUnitCaption";
            // 
            // txtEncUnit
            // 
            this.txtEncUnit.Location = new System.Drawing.Point(240, 230);
            this.txtEncUnit.Size = new System.Drawing.Size(320, 28);
            this.txtEncUnit.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtEncUnit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtEncUnit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtEncUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtEncUnit.Text = "0.001";
            this.txtEncUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtEncUnit.Name = "txtEncUnit";
            this.txtEncUnit.TextChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // lblReverseCaption
            // 
            this.lblReverseCaption.Location = new System.Drawing.Point(14, 268);
            this.lblReverseCaption.Size = new System.Drawing.Size(220, 28);
            this.lblReverseCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReverseCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblReverseCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblReverseCaption.Text = "Encoder Reverse";
            this.lblReverseCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReverseCaption.Name = "lblReverseCaption";
            // 
            // chkEncReverse
            // 
            this.chkEncReverse.Location = new System.Drawing.Point(240, 268);
            this.chkEncReverse.Size = new System.Drawing.Size(320, 28);
            this.chkEncReverse.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.chkEncReverse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.chkEncReverse.Text = "Count the encoder the other way";
            this.chkEncReverse.Name = "chkEncReverse";
            this.chkEncReverse.CheckedChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // lblWrongWayLimitCaption
            // 
            this.lblWrongWayLimitCaption.Location = new System.Drawing.Point(14, 306);
            this.lblWrongWayLimitCaption.Size = new System.Drawing.Size(220, 28);
            this.lblWrongWayLimitCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWrongWayLimitCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblWrongWayLimitCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblWrongWayLimitCaption.Text = "Wrong Way Limit (counts)";
            this.lblWrongWayLimitCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWrongWayLimitCaption.Name = "lblWrongWayLimitCaption";
            // 
            // txtWrongWay
            // 
            this.txtWrongWay.Location = new System.Drawing.Point(240, 306);
            this.txtWrongWay.Size = new System.Drawing.Size(320, 28);
            this.txtWrongWay.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtWrongWay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtWrongWay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtWrongWay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtWrongWay.Text = "200";
            this.txtWrongWay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtWrongWay.Name = "txtWrongWay";
            this.txtWrongWay.TextChanged += new System.EventHandler(this.HwCfgInput_Changed);
            // 
            // lblHwCfgResult
            // 
            this.lblHwCfgResult.Location = new System.Drawing.Point(14, 352);
            this.lblHwCfgResult.Size = new System.Drawing.Size(546, 28);
            this.lblHwCfgResult.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHwCfgResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblHwCfgResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblHwCfgResult.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblHwCfgResult.Text = "";
            this.lblHwCfgResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHwCfgResult.Name = "lblHwCfgResult";
            // 
            // btnHwRead
            // 
            this.btnHwRead.Location = new System.Drawing.Point(14, 390);
            this.btnHwRead.Size = new System.Drawing.Size(170, 44);
            this.btnHwRead.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHwRead.Text = "READ";
            this.btnHwRead.Name = "btnHwRead";
            this.btnHwRead.Click += new System.EventHandler(this.btnHwRead_Click);
            // 
            // btnHwWrite
            // 
            this.btnHwWrite.Location = new System.Drawing.Point(196, 390);
            this.btnHwWrite.Size = new System.Drawing.Size(170, 44);
            this.btnHwWrite.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHwWrite.Text = "WRITE";
            this.btnHwWrite.Role = MMI.HmiButtonRole.Primary;
            this.btnHwWrite.Name = "btnHwWrite";
            this.btnHwWrite.Click += new System.EventHandler(this.btnHwWrite_Click);
            // 
            // btnHwDefaults
            // 
            this.btnHwDefaults.Location = new System.Drawing.Point(378, 390);
            this.btnHwDefaults.Size = new System.Drawing.Size(182, 44);
            this.btnHwDefaults.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHwDefaults.Text = "DEFAULTS";
            this.btnHwDefaults.Name = "btnHwDefaults";
            this.btnHwDefaults.Click += new System.EventHandler(this.btnHwDefaults_Click);
            // 
            // pnlLog
            // 
            this.pnlLog.Controls.Add(this.lstLog);
            this.pnlLog.Controls.Add(this.pnlLogButtons);
            this.pnlLog.Location = new System.Drawing.Point(0, 628);
            this.pnlLog.Size = new System.Drawing.Size(540, 284);
            this.pnlLog.TitleText = "Trigger Log";
            this.pnlLog.Name = "pnlLog";
            // 
            // btnLogClear
            // 
            this.btnLogClear.Location = new System.Drawing.Point(8, 0);
            this.btnLogClear.Size = new System.Drawing.Size(82, 36);
            this.btnLogClear.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLogClear.Text = "CLEAR";
            this.btnLogClear.Name = "btnLogClear";
            this.btnLogClear.Click += new System.EventHandler(this.btnLogClear_Click);
            // 
            // pnlMotor
            // 
            this.pnlMotor.Controls.Add(this.btnAlarmReset);
            this.pnlMotor.Controls.Add(this.btnHome);
            this.pnlMotor.Controls.Add(this.btnServo);
            this.pnlMotor.Controls.Add(this.lblStsAlarm);
            this.pnlMotor.Controls.Add(this.lblStsMoving);
            this.pnlMotor.Controls.Add(this.lblStsHome);
            this.pnlMotor.Controls.Add(this.lblStsOrg);
            this.pnlMotor.Controls.Add(this.lblStsPlusLimit);
            this.pnlMotor.Controls.Add(this.lblStsMinusLimit);
            this.pnlMotor.Controls.Add(this.lblNextPos);
            this.pnlMotor.Controls.Add(this.lblNextPosCaption);
            this.pnlMotor.Controls.Add(this.lblCurPos);
            this.pnlMotor.Controls.Add(this.lblCurPosCaption);
            this.pnlMotor.Controls.Add(this.lblNextIdx);
            this.pnlMotor.Controls.Add(this.lblNextIdxCaption);
            this.pnlMotor.Controls.Add(this.lblCurIdx);
            this.pnlMotor.Controls.Add(this.lblCurIdxCaption);
            this.pnlMotor.Controls.Add(this.cbAxis);
            this.pnlMotor.Controls.Add(this.lblAxisCaption);
            this.pnlMotor.Location = new System.Drawing.Point(0, 0);
            this.pnlMotor.Size = new System.Drawing.Size(1644, 74);
            this.pnlMotor.TitleText = "";
            this.pnlMotor.Name = "pnlMotor";
            // 
            // lblAxisCaption
            // 
            this.lblAxisCaption.Location = new System.Drawing.Point(14, 8);
            this.lblAxisCaption.Size = new System.Drawing.Size(130, 28);
            this.lblAxisCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAxisCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblAxisCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblAxisCaption.Text = "MOTOR SELECT";
            this.lblAxisCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAxisCaption.Name = "lblAxisCaption";
            // 
            // cbAxis
            // 
            this.cbAxis.Location = new System.Drawing.Point(14, 36);
            this.cbAxis.Size = new System.Drawing.Size(316, 28);
            this.cbAxis.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbAxis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAxis.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAxis.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.cbAxis.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.cbAxis.FormattingEnabled = true;
            this.cbAxis.Name = "cbAxis";
            this.cbAxis.SelectedIndexChanged += new System.EventHandler(this.cbAxis_SelectedIndexChanged);
            // 
            // lblCurIdxCaption
            // 
            this.lblCurIdxCaption.Location = new System.Drawing.Point(348, 8);
            this.lblCurIdxCaption.Size = new System.Drawing.Size(134, 28);
            this.lblCurIdxCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurIdxCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblCurIdxCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCurIdxCaption.Text = "Current Index";
            this.lblCurIdxCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurIdxCaption.Name = "lblCurIdxCaption";
            // 
            // lblCurIdx
            // 
            this.lblCurIdx.Location = new System.Drawing.Point(486, 8);
            this.lblCurIdx.Size = new System.Drawing.Size(110, 28);
            this.lblCurIdx.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurIdx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblCurIdx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblCurIdx.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblCurIdx.Text = "-";
            this.lblCurIdx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCurIdx.Name = "lblCurIdx";
            // 
            // lblNextIdxCaption
            // 
            this.lblNextIdxCaption.Location = new System.Drawing.Point(612, 8);
            this.lblNextIdxCaption.Size = new System.Drawing.Size(112, 28);
            this.lblNextIdxCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNextIdxCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblNextIdxCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblNextIdxCaption.Text = "Next Index";
            this.lblNextIdxCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNextIdxCaption.Name = "lblNextIdxCaption";
            // 
            // lblNextIdx
            // 
            this.lblNextIdx.Location = new System.Drawing.Point(728, 8);
            this.lblNextIdx.Size = new System.Drawing.Size(110, 28);
            this.lblNextIdx.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNextIdx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblNextIdx.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblNextIdx.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblNextIdx.Text = "-";
            this.lblNextIdx.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNextIdx.Name = "lblNextIdx";
            // 
            // lblCurPosCaption
            // 
            this.lblCurPosCaption.Location = new System.Drawing.Point(348, 38);
            this.lblCurPosCaption.Size = new System.Drawing.Size(134, 28);
            this.lblCurPosCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurPosCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblCurPosCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblCurPosCaption.Text = "Current Position";
            this.lblCurPosCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCurPosCaption.Name = "lblCurPosCaption";
            // 
            // lblCurPos
            // 
            this.lblCurPos.Location = new System.Drawing.Point(486, 38);
            this.lblCurPos.Size = new System.Drawing.Size(110, 28);
            this.lblCurPos.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblCurPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblCurPos.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblCurPos.Text = "-";
            this.lblCurPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCurPos.Name = "lblCurPos";
            // 
            // lblNextPosCaption
            // 
            this.lblNextPosCaption.Location = new System.Drawing.Point(612, 38);
            this.lblNextPosCaption.Size = new System.Drawing.Size(112, 28);
            this.lblNextPosCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNextPosCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblNextPosCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblNextPosCaption.Text = "Next Position";
            this.lblNextPosCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNextPosCaption.Name = "lblNextPosCaption";
            // 
            // lblNextPos
            // 
            this.lblNextPos.Location = new System.Drawing.Point(728, 38);
            this.lblNextPos.Size = new System.Drawing.Size(110, 28);
            this.lblNextPos.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNextPos.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblNextPos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblNextPos.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblNextPos.Text = "-";
            this.lblNextPos.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblNextPos.Name = "lblNextPos";
            // 
            // lblStsMinusLimit
            // 
            this.lblStsMinusLimit.Location = new System.Drawing.Point(858, 8);
            this.lblStsMinusLimit.Size = new System.Drawing.Size(98, 28);
            this.lblStsMinusLimit.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStsMinusLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.lblStsMinusLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStsMinusLimit.Text = "-LIMIT";
            this.lblStsMinusLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStsMinusLimit.Name = "lblStsMinusLimit";
            // 
            // lblStsPlusLimit
            // 
            this.lblStsPlusLimit.Location = new System.Drawing.Point(962, 8);
            this.lblStsPlusLimit.Size = new System.Drawing.Size(98, 28);
            this.lblStsPlusLimit.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStsPlusLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.lblStsPlusLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStsPlusLimit.Text = "+LIMIT";
            this.lblStsPlusLimit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStsPlusLimit.Name = "lblStsPlusLimit";
            // 
            // lblStsOrg
            // 
            this.lblStsOrg.Location = new System.Drawing.Point(1066, 8);
            this.lblStsOrg.Size = new System.Drawing.Size(98, 28);
            this.lblStsOrg.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStsOrg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.lblStsOrg.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStsOrg.Text = "ORG";
            this.lblStsOrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStsOrg.Name = "lblStsOrg";
            // 
            // lblStsHome
            // 
            this.lblStsHome.Location = new System.Drawing.Point(858, 38);
            this.lblStsHome.Size = new System.Drawing.Size(98, 28);
            this.lblStsHome.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStsHome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.lblStsHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStsHome.Text = "HOMED";
            this.lblStsHome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStsHome.Name = "lblStsHome";
            // 
            // lblStsMoving
            // 
            this.lblStsMoving.Location = new System.Drawing.Point(962, 38);
            this.lblStsMoving.Size = new System.Drawing.Size(98, 28);
            this.lblStsMoving.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStsMoving.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.lblStsMoving.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStsMoving.Text = "MOVING";
            this.lblStsMoving.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStsMoving.Name = "lblStsMoving";
            // 
            // lblStsAlarm
            // 
            this.lblStsAlarm.Location = new System.Drawing.Point(1066, 38);
            this.lblStsAlarm.Size = new System.Drawing.Size(98, 28);
            this.lblStsAlarm.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStsAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.lblStsAlarm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStsAlarm.Text = "ALARM";
            this.lblStsAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStsAlarm.Name = "lblStsAlarm";
            // 
            // btnServo
            // 
            this.btnServo.Location = new System.Drawing.Point(1180, 8);
            this.btnServo.Size = new System.Drawing.Size(142, 56);
            this.btnServo.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnServo.Text = "SERVO ON/OFF";
            this.btnServo.Name = "btnServo";
            this.btnServo.Click += new System.EventHandler(this.btnServo_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(1332, 8);
            this.btnHome.Size = new System.Drawing.Size(142, 56);
            this.btnHome.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnHome.Text = "HOME";
            this.btnHome.Role = MMI.HmiButtonRole.Warning;
            this.btnHome.Name = "btnHome";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnAlarmReset
            // 
            this.btnAlarmReset.Location = new System.Drawing.Point(1484, 8);
            this.btnAlarmReset.Size = new System.Drawing.Size(142, 56);
            this.btnAlarmReset.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAlarmReset.Text = "ALARM RESET";
            this.btnAlarmReset.Name = "btnAlarmReset";
            this.btnAlarmReset.Click += new System.EventHandler(this.btnAlarmReset_Click);
            // 
            // pnlJog
            // 
            this.pnlJog.Controls.Add(this.lblJogResult);
            this.pnlJog.Controls.Add(this.btnJogPlus);
            this.pnlJog.Controls.Add(this.btnJogMinus);
            this.pnlJog.Controls.Add(this.lblModeHint);
            this.pnlJog.Controls.Add(this.btnModeJog);
            this.pnlJog.Controls.Add(this.btnModeStep);
            this.pnlJog.Controls.Add(this.btnStepM4);
            this.pnlJog.Controls.Add(this.btnStepM3);
            this.pnlJog.Controls.Add(this.btnStepM2);
            this.pnlJog.Controls.Add(this.btnStepM1);
            this.pnlJog.Controls.Add(this.btnStepM0);
            this.pnlJog.Controls.Add(this.btnStepP4);
            this.pnlJog.Controls.Add(this.btnStepP3);
            this.pnlJog.Controls.Add(this.btnStepP2);
            this.pnlJog.Controls.Add(this.btnStepP1);
            this.pnlJog.Controls.Add(this.btnStepP0);
            this.pnlJog.Controls.Add(this.txtJogVel);
            this.pnlJog.Controls.Add(this.lblJogVelCaption);
            this.pnlJog.Controls.Add(this.lblStep);
            this.pnlJog.Controls.Add(this.lblStepCaption);
            this.pnlJog.Controls.Add(this.btnJogEnable);
            this.pnlJog.Location = new System.Drawing.Point(1064, 568);
            this.pnlJog.Size = new System.Drawing.Size(580, 344);
            this.pnlJog.TitleText = "Jog";
            this.pnlJog.Name = "pnlJog";
            // 
            // btnJogEnable
            // 
            this.btnJogEnable.Location = new System.Drawing.Point(14, 40);
            this.btnJogEnable.Size = new System.Drawing.Size(160, 40);
            this.btnJogEnable.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJogEnable.Text = "JOG ENABLE";
            this.btnJogEnable.Name = "btnJogEnable";
            this.btnJogEnable.Click += new System.EventHandler(this.btnJogEnable_Click);
            // 
            // lblStepCaption
            // 
            this.lblStepCaption.Location = new System.Drawing.Point(186, 46);
            this.lblStepCaption.Size = new System.Drawing.Size(80, 28);
            this.lblStepCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStepCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStepCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblStepCaption.Text = "Step (mm)";
            this.lblStepCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStepCaption.Name = "lblStepCaption";
            // 
            // lblStep
            // 
            this.lblStep.Location = new System.Drawing.Point(268, 40);
            this.lblStep.Size = new System.Drawing.Size(110, 40);
            this.lblStep.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblStep.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblStep.Text = "0.00";
            this.lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep.Name = "lblStep";
            // 
            // lblJogVelCaption
            // 
            this.lblJogVelCaption.Location = new System.Drawing.Point(392, 46);
            this.lblJogVelCaption.Size = new System.Drawing.Size(70, 28);
            this.lblJogVelCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblJogVelCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblJogVelCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblJogVelCaption.Text = "Velocity";
            this.lblJogVelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblJogVelCaption.Name = "lblJogVelCaption";
            // 
            // txtJogVel
            // 
            this.txtJogVel.Location = new System.Drawing.Point(466, 46);
            this.txtJogVel.Size = new System.Drawing.Size(100, 28);
            this.txtJogVel.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtJogVel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.txtJogVel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.txtJogVel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJogVel.Text = "10";
            this.txtJogVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtJogVel.MaxLength = 5;
            this.txtJogVel.Name = "txtJogVel";
            this.txtJogVel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtJogVel_KeyPress);
            // 
            // btnStepP0
            // 
            this.btnStepP0.Location = new System.Drawing.Point(14, 92);
            this.btnStepP0.Size = new System.Drawing.Size(104, 40);
            this.btnStepP0.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepP0.Text = "+0.01";
            this.btnStepP0.Tag = "0";
            this.btnStepP0.Name = "btnStepP0";
            this.btnStepP0.Click += new System.EventHandler(this.btnStepPlus_Click);
            // 
            // btnStepP1
            // 
            this.btnStepP1.Location = new System.Drawing.Point(124, 92);
            this.btnStepP1.Size = new System.Drawing.Size(104, 40);
            this.btnStepP1.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepP1.Text = "+0.1";
            this.btnStepP1.Tag = "1";
            this.btnStepP1.Name = "btnStepP1";
            this.btnStepP1.Click += new System.EventHandler(this.btnStepPlus_Click);
            // 
            // btnStepP2
            // 
            this.btnStepP2.Location = new System.Drawing.Point(234, 92);
            this.btnStepP2.Size = new System.Drawing.Size(104, 40);
            this.btnStepP2.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepP2.Text = "+1.0";
            this.btnStepP2.Tag = "2";
            this.btnStepP2.Name = "btnStepP2";
            this.btnStepP2.Click += new System.EventHandler(this.btnStepPlus_Click);
            // 
            // btnStepP3
            // 
            this.btnStepP3.Location = new System.Drawing.Point(344, 92);
            this.btnStepP3.Size = new System.Drawing.Size(104, 40);
            this.btnStepP3.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepP3.Text = "+10.0";
            this.btnStepP3.Tag = "3";
            this.btnStepP3.Name = "btnStepP3";
            this.btnStepP3.Click += new System.EventHandler(this.btnStepPlus_Click);
            // 
            // btnStepP4
            // 
            this.btnStepP4.Location = new System.Drawing.Point(454, 92);
            this.btnStepP4.Size = new System.Drawing.Size(104, 40);
            this.btnStepP4.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepP4.Text = "+100.0";
            this.btnStepP4.Tag = "4";
            this.btnStepP4.Name = "btnStepP4";
            this.btnStepP4.Click += new System.EventHandler(this.btnStepPlus_Click);
            // 
            // btnStepM0
            // 
            this.btnStepM0.Location = new System.Drawing.Point(14, 138);
            this.btnStepM0.Size = new System.Drawing.Size(104, 40);
            this.btnStepM0.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepM0.Text = "-0.01";
            this.btnStepM0.Tag = "0";
            this.btnStepM0.Name = "btnStepM0";
            this.btnStepM0.Click += new System.EventHandler(this.btnStepMinus_Click);
            // 
            // btnStepM1
            // 
            this.btnStepM1.Location = new System.Drawing.Point(124, 138);
            this.btnStepM1.Size = new System.Drawing.Size(104, 40);
            this.btnStepM1.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepM1.Text = "-0.1";
            this.btnStepM1.Tag = "1";
            this.btnStepM1.Name = "btnStepM1";
            this.btnStepM1.Click += new System.EventHandler(this.btnStepMinus_Click);
            // 
            // btnStepM2
            // 
            this.btnStepM2.Location = new System.Drawing.Point(234, 138);
            this.btnStepM2.Size = new System.Drawing.Size(104, 40);
            this.btnStepM2.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepM2.Text = "-1.0";
            this.btnStepM2.Tag = "2";
            this.btnStepM2.Name = "btnStepM2";
            this.btnStepM2.Click += new System.EventHandler(this.btnStepMinus_Click);
            // 
            // btnStepM3
            // 
            this.btnStepM3.Location = new System.Drawing.Point(344, 138);
            this.btnStepM3.Size = new System.Drawing.Size(104, 40);
            this.btnStepM3.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepM3.Text = "-10.0";
            this.btnStepM3.Tag = "3";
            this.btnStepM3.Name = "btnStepM3";
            this.btnStepM3.Click += new System.EventHandler(this.btnStepMinus_Click);
            // 
            // btnStepM4
            // 
            this.btnStepM4.Location = new System.Drawing.Point(454, 138);
            this.btnStepM4.Size = new System.Drawing.Size(104, 40);
            this.btnStepM4.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepM4.Text = "-100.0";
            this.btnStepM4.Tag = "4";
            this.btnStepM4.Name = "btnStepM4";
            this.btnStepM4.Click += new System.EventHandler(this.btnStepMinus_Click);
            // 
            // btnModeStep
            // 
            this.btnModeStep.Location = new System.Drawing.Point(14, 192);
            this.btnModeStep.Size = new System.Drawing.Size(130, 34);
            this.btnModeStep.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModeStep.Text = "STEP";
            this.btnModeStep.Name = "btnModeStep";
            this.btnModeStep.Click += new System.EventHandler(this.btnModeStep_Click);
            // 
            // btnModeJog
            // 
            this.btnModeJog.Location = new System.Drawing.Point(150, 192);
            this.btnModeJog.Size = new System.Drawing.Size(130, 34);
            this.btnModeJog.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModeJog.Text = "JOG";
            this.btnModeJog.Name = "btnModeJog";
            this.btnModeJog.Click += new System.EventHandler(this.btnModeJog_Click);
            // 
            // lblModeHint
            // 
            this.lblModeHint.Location = new System.Drawing.Point(14, 232);
            this.lblModeHint.Size = new System.Drawing.Size(266, 30);
            this.lblModeHint.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblModeHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblModeHint.BackColor = System.Drawing.Color.Transparent;
            this.lblModeHint.Text = "";
            this.lblModeHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblModeHint.Name = "lblModeHint";
            // 
            // btnJogMinus
            // 
            this.btnJogMinus.Location = new System.Drawing.Point(298, 192);
            this.btnJogMinus.Size = new System.Drawing.Size(128, 70);
            this.btnJogMinus.Font = new System.Drawing.Font("Malgun Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJogMinus.Text = "-";
            this.btnJogMinus.Tag = "0";
            this.btnJogMinus.Name = "btnJogMinus";
            this.btnJogMinus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMove_MouseDown);
            this.btnJogMinus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMove_MouseUp);
            this.btnJogMinus.MouseLeave += new System.EventHandler(this.btnJogMove_MouseLeave);
            // 
            // btnJogPlus
            // 
            this.btnJogPlus.Location = new System.Drawing.Point(434, 192);
            this.btnJogPlus.Size = new System.Drawing.Size(128, 70);
            this.btnJogPlus.Font = new System.Drawing.Font("Malgun Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJogPlus.Text = "+";
            this.btnJogPlus.Tag = "1";
            this.btnJogPlus.Name = "btnJogPlus";
            this.btnJogPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMove_MouseDown);
            this.btnJogPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMove_MouseUp);
            this.btnJogPlus.MouseLeave += new System.EventHandler(this.btnJogMove_MouseLeave);
            // 
            // lblJogResult
            // 
            this.lblJogResult.Location = new System.Drawing.Point(14, 274);
            this.lblJogResult.Size = new System.Drawing.Size(548, 28);
            this.lblJogResult.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblJogResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblJogResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblJogResult.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblJogResult.Text = "";
            this.lblJogResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblJogResult.Name = "lblJogResult";
            // 
            // tmView
            // 
            this.tmView.Interval = 1000;
            this.tmView.Tick += new System.EventHandler(this.tmView_Tick);
            // 
            // pnlLogButtons
            // 
            this.pnlLogButtons.Controls.Add(this.btnLogClear);
            this.pnlLogButtons.Dock = System.Windows.Forms.DockStyle.Right;
            this.pnlLogButtons.Size = new System.Drawing.Size(90, 100);
            this.pnlLogButtons.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogButtons.Name = "pnlLogButtons";
            // 
            // lstLog
            // 
            this.lstLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstLog.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lstLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lstLog.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lstLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstLog.IntegralHeight = false;
            this.lstLog.HorizontalScrollbar = true;
            this.lstLog.Size = new System.Drawing.Size(290, 100);
            this.lstLog.Name = "lstLog";
            // 
            // FormScanTrigger
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1644, 912);
            this.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "FormScanTrigger";
            this.Controls.Add(this.pnlJog);
            this.Controls.Add(this.pnlMotor);
            this.Controls.Add(this.pnlLog);
            this.Controls.Add(this.pnlHwCfg);
            this.Controls.Add(this.pnlCounter);
            this.Controls.Add(this.pnlGeometry);
            this.Controls.Add(this.pnlScanTrigger);
            this.Name = "FormScanTrigger";
            this.Load += new System.EventHandler(this.FormScanTrigger_Load);
            this.VisibleChanged += new System.EventHandler(this.FormScanTrigger_VisibleChanged);
            this.pnlLogButtons.ResumeLayout(false);
            this.pnlJog.ResumeLayout(false);
            this.pnlMotor.ResumeLayout(false);
            this.pnlLog.ResumeLayout(false);
            this.pnlHwCfg.ResumeLayout(false);
            this.pnlProgressFill.ResumeLayout(false);
            this.pnlProgressTrack.ResumeLayout(false);
            this.pnlCounter.ResumeLayout(false);
            this.pnlGeometryView.ResumeLayout(false);
            this.pnlGeometry.ResumeLayout(false);
            this.pnlScanTrigger.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MMI.HmiCard pnlScanTrigger;
        private System.Windows.Forms.RadioButton rdoScanTrigPeriodic;
        private System.Windows.Forms.RadioButton rdoScanTrigTimer;
        private System.Windows.Forms.Label lblcapScanTrig5;
        private System.Windows.Forms.TextBox txtScanTrigMotionStart;
        private System.Windows.Forms.Label lblcapScanTrig0;
        private System.Windows.Forms.TextBox txtScanTrigStart;
        private System.Windows.Forms.Label lblcapScanTrig1;
        private System.Windows.Forms.TextBox txtScanTrigEnd;
        private System.Windows.Forms.Label lblcapScanTrig6;
        private System.Windows.Forms.TextBox txtScanTrigMotionEnd;
        private System.Windows.Forms.Label lblcapScanTrig2;
        private System.Windows.Forms.TextBox txtScanTrigPitch;
        private System.Windows.Forms.Label lblcapScanTrig3;
        private System.Windows.Forms.TextBox txtScanTrigSpeed;
        private System.Windows.Forms.Label lblcapScanTrig4;
        private System.Windows.Forms.TextBox txtScanTrigPulse;
        private System.Windows.Forms.Label lblcapScanTrigR0;
        private System.Windows.Forms.Label lblScanTrigRate;
        private System.Windows.Forms.Label lblcapScanTrigR1;
        private System.Windows.Forms.Label lblScanTrigLines;
        private System.Windows.Forms.Label lblcapScanTrigR2;
        private System.Windows.Forms.Label lblScanTrigTime;
        private System.Windows.Forms.Label lblcapScanTrigR3;
        private System.Windows.Forms.Label lblScanTrigCounts;
        private System.Windows.Forms.Label lblcapScanTrigR4;
        private System.Windows.Forms.Label lblScanTrigState;
        private System.Windows.Forms.Label lblcapScanTrigR5;
        private System.Windows.Forms.Label lblScanTrigResult;
        private MMI.HmiButton btnScanTrigSet;
        private MMI.HmiButton btnScanTrigStart;
        private MMI.HmiButton btnScanTrigStop;
        private MMI.HmiButton btnScanTrigTest;
        private MMI.HmiCard pnlGeometry;
        private System.Windows.Forms.Panel pnlGeometryView;
        private MMI.HmiCard pnlCounter;
        private System.Windows.Forms.Label lblEncPosCaption;
        private System.Windows.Forms.Label lblEncPos;
        private System.Windows.Forms.Label lblEncCountCaption;
        private System.Windows.Forms.Label lblEncCount;
        private System.Windows.Forms.Label lblTrigCountCaption;
        private System.Windows.Forms.Label lblTrigCount;
        private System.Windows.Forms.Label lblProgressCaption;
        private System.Windows.Forms.Panel pnlProgressTrack;
        private System.Windows.Forms.Panel pnlProgressFill;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.Label lblOutputCaption;
        private System.Windows.Forms.Label lblOutput;
        private System.Windows.Forms.Label lblArmCaption;
        private System.Windows.Forms.Label lblArmCount;
        private System.Windows.Forms.Label lblBlockCaption;
        private System.Windows.Forms.Label lblBlock;
        private System.Windows.Forms.Label lblWrongWayCaption;
        private System.Windows.Forms.Label lblWrongWay;
        private MMI.HmiButton btnTrigCountClear;
        private MMI.HmiButton btnEncToAxis;
        private System.Windows.Forms.Label lblCounterResult;
        private MMI.HmiCard pnlHwCfg;
        private System.Windows.Forms.Label lblChannelCaption;
        private System.Windows.Forms.ComboBox cbChannel;
        private System.Windows.Forms.Label lblEncInputCaption;
        private System.Windows.Forms.ComboBox cbEncInput;
        private System.Windows.Forms.Label lblLevelCaption;
        private System.Windows.Forms.ComboBox cbLevel;
        private System.Windows.Forms.Label lblDirectionCaption;
        private System.Windows.Forms.ComboBox cbDirection;
        private System.Windows.Forms.Label lblOutPortCaption;
        private System.Windows.Forms.CheckBox chkOut0;
        private System.Windows.Forms.CheckBox chkOut1;
        private System.Windows.Forms.CheckBox chkOut2;
        private System.Windows.Forms.CheckBox chkOut3;
        private System.Windows.Forms.Label lblUnitCaption;
        private System.Windows.Forms.TextBox txtEncUnit;
        private System.Windows.Forms.Label lblReverseCaption;
        private System.Windows.Forms.CheckBox chkEncReverse;
        private System.Windows.Forms.Label lblWrongWayLimitCaption;
        private System.Windows.Forms.TextBox txtWrongWay;
        private System.Windows.Forms.Label lblHwCfgResult;
        private MMI.HmiButton btnHwRead;
        private MMI.HmiButton btnHwWrite;
        private MMI.HmiButton btnHwDefaults;
        private MMI.HmiCard pnlLog;
        private MMI.HmiButton btnLogClear;
        private MMI.HmiCard pnlMotor;
        private System.Windows.Forms.Label lblAxisCaption;
        private System.Windows.Forms.ComboBox cbAxis;
        private System.Windows.Forms.Label lblCurIdxCaption;
        private System.Windows.Forms.Label lblCurIdx;
        private System.Windows.Forms.Label lblNextIdxCaption;
        private System.Windows.Forms.Label lblNextIdx;
        private System.Windows.Forms.Label lblCurPosCaption;
        private System.Windows.Forms.Label lblCurPos;
        private System.Windows.Forms.Label lblNextPosCaption;
        private System.Windows.Forms.Label lblNextPos;
        private System.Windows.Forms.Label lblStsMinusLimit;
        private System.Windows.Forms.Label lblStsPlusLimit;
        private System.Windows.Forms.Label lblStsOrg;
        private System.Windows.Forms.Label lblStsHome;
        private System.Windows.Forms.Label lblStsMoving;
        private System.Windows.Forms.Label lblStsAlarm;
        private MMI.HmiButton btnServo;
        private MMI.HmiButton btnHome;
        private MMI.HmiButton btnAlarmReset;
        private MMI.HmiCard pnlJog;
        private MMI.HmiButton btnJogEnable;
        private System.Windows.Forms.Label lblStepCaption;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label lblJogVelCaption;
        private System.Windows.Forms.TextBox txtJogVel;
        private MMI.HmiButton btnStepP0;
        private MMI.HmiButton btnStepP1;
        private MMI.HmiButton btnStepP2;
        private MMI.HmiButton btnStepP3;
        private MMI.HmiButton btnStepP4;
        private MMI.HmiButton btnStepM0;
        private MMI.HmiButton btnStepM1;
        private MMI.HmiButton btnStepM2;
        private MMI.HmiButton btnStepM3;
        private MMI.HmiButton btnStepM4;
        private MMI.HmiButton btnModeStep;
        private MMI.HmiButton btnModeJog;
        private System.Windows.Forms.Label lblModeHint;
        private MMI.HmiButton btnJogMinus;
        private MMI.HmiButton btnJogPlus;
        private System.Windows.Forms.Label lblJogResult;
        private System.Windows.Forms.Timer tmView;
        private System.Windows.Forms.Panel pnlLogButtons;
        private System.Windows.Forms.ListBox lstLog;
    }
}
