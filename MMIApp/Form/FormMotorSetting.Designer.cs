
namespace MMI
{
    partial class FormMotorSetting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMotorSetting));
            this.labelX3 = new System.Windows.Forms.Label();
            this.cbMotor = new System.Windows.Forms.ComboBox();
            this.labelX1 = new System.Windows.Forms.Label();
            this.labelX2 = new System.Windows.Forms.Label();
            this.btnMTS_CCW = new MMI.HmiButton();
            this.btnMTS_CW = new MMI.HmiButton();
            this.btnMTS_ORG = new MMI.HmiButton();
            this.btnMTS_HOME = new MMI.HmiButton();
            this.btnMTS_MOVING = new MMI.HmiButton();
            this.bntMTS_ALARM = new MMI.HmiButton();
            this.btmMTS_SERVO = new MMI.HmiButton();
            this.labelX6 = new System.Windows.Forms.Label();
            this.labelX7 = new System.Windows.Forms.Label();
            this.lblCurrentIndex = new System.Windows.Forms.Label();
            this.lblCurrentPosition = new System.Windows.Forms.Label();
            this.lblNextPosition = new System.Windows.Forms.Label();
            this.lblNextIndex = new System.Windows.Forms.Label();
            this.gdMotor = new MMI.HmiGrid();
            this.grbJog = new System.Windows.Forms.GroupBox();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.labelX5 = new System.Windows.Forms.Label();
            this.btnMoveM = new MMI.HmiButton();
            this.btnMoveP = new MMI.HmiButton();
            this.btnJogEnable = new MMI.HmiButton();
            this.btnUnitEnable = new MMI.HmiButton();
            this.pnUNIT = new System.Windows.Forms.Panel();
            this.lblUnitValue = new System.Windows.Forms.Label();
            this.btnUnit5m = new MMI.HmiButton();
            this.btnUnit4m = new MMI.HmiButton();
            this.btnUnit3m = new MMI.HmiButton();
            this.btnUnit2m = new MMI.HmiButton();
            this.btnUnit5p = new MMI.HmiButton();
            this.btnUnit4p = new MMI.HmiButton();
            this.btnUnit3p = new MMI.HmiButton();
            this.btnUnit2p = new MMI.HmiButton();
            this.btnUnit1m = new MMI.HmiButton();
            this.btnUnit1p = new MMI.HmiButton();
            this.grbFunction = new System.Windows.Forms.GroupBox();
            this.btnMoveIndex = new MMI.HmiButton();
            this.btnCalc = new MMI.HmiButton();
            this.btnSavePos = new MMI.HmiButton();
            this.btnEdit = new MMI.HmiButton();
            this.btnTenkeyJog = new MMI.HmiButton();
            this.btnJogMode = new MMI.HmiButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIdx = new System.Windows.Forms.Label();
            this.btnIDXWrite = new MMI.HmiButton();
            this.gdMotorCommon = new MMI.HmiGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gdMotor)).BeginInit();
            this.grbJog.SuspendLayout();
            this.pnUNIT.SuspendLayout();
            this.grbFunction.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdMotorCommon)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX3
            // 
            this.labelX3.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.Location = new System.Drawing.Point(29, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.labelX3.Size = new System.Drawing.Size(294, 25);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "MOTOR SELECT";
            this.labelX3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbMotor
            // 
            this.cbMotor.DisplayMember = "Text";
            this.cbMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMotor.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMotor.FormattingEnabled = true;
            this.cbMotor.Location = new System.Drawing.Point(29, 43);
            this.cbMotor.Name = "cbMotor";
            this.cbMotor.Size = new System.Drawing.Size(294, 28);
            this.cbMotor.TabIndex = 10;
            this.cbMotor.SelectedIndexChanged += new System.EventHandler(this.cbMotor_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(347, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.labelX1.Size = new System.Drawing.Size(187, 25);
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = " CURRENT INDEX";
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(654, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.labelX2.Size = new System.Drawing.Size(147, 25);
            this.labelX2.TabIndex = 12;
            this.labelX2.Text = " NEXT INDEX";
            // 
            // btnMTS_CCW
            // 
            this.btnMTS_CCW.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMTS_CCW.Location = new System.Drawing.Point(940, 12);
            this.btnMTS_CCW.Name = "btnMTS_CCW";
            this.btnMTS_CCW.Size = new System.Drawing.Size(83, 25);
            this.btnMTS_CCW.TabIndex = 15;
            this.btnMTS_CCW.Text = "-Limit";
            // 
            // btnMTS_CW
            // 
            this.btnMTS_CW.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMTS_CW.Location = new System.Drawing.Point(1029, 12);
            this.btnMTS_CW.Name = "btnMTS_CW";
            this.btnMTS_CW.Size = new System.Drawing.Size(83, 25);
            this.btnMTS_CW.TabIndex = 16;
            this.btnMTS_CW.Text = "+Limit";
            // 
            // btnMTS_ORG
            // 
            this.btnMTS_ORG.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMTS_ORG.Location = new System.Drawing.Point(1118, 12);
            this.btnMTS_ORG.Name = "btnMTS_ORG";
            this.btnMTS_ORG.Size = new System.Drawing.Size(83, 25);
            this.btnMTS_ORG.TabIndex = 17;
            this.btnMTS_ORG.Text = "ORG";
            // 
            // btnMTS_HOME
            // 
            this.btnMTS_HOME.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMTS_HOME.Location = new System.Drawing.Point(940, 43);
            this.btnMTS_HOME.Name = "btnMTS_HOME";
            this.btnMTS_HOME.Size = new System.Drawing.Size(83, 25);
            this.btnMTS_HOME.TabIndex = 18;
            this.btnMTS_HOME.Text = "HOME";
            this.btnMTS_HOME.Click += new System.EventHandler(this.btnMTS_HOME_Click);
            // 
            // btnMTS_MOVING
            // 
            this.btnMTS_MOVING.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMTS_MOVING.Location = new System.Drawing.Point(1029, 43);
            this.btnMTS_MOVING.Name = "btnMTS_MOVING";
            this.btnMTS_MOVING.Size = new System.Drawing.Size(83, 25);
            this.btnMTS_MOVING.TabIndex = 19;
            this.btnMTS_MOVING.Text = "MOVING";
            // 
            // bntMTS_ALARM
            // 
            this.bntMTS_ALARM.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntMTS_ALARM.Location = new System.Drawing.Point(1118, 43);
            this.bntMTS_ALARM.Name = "bntMTS_ALARM";
            this.bntMTS_ALARM.Size = new System.Drawing.Size(83, 25);
            this.bntMTS_ALARM.TabIndex = 20;
            this.bntMTS_ALARM.Text = "ALARM";
            this.bntMTS_ALARM.Click += new System.EventHandler(this.bntMTS_ALARM_Click);
            // 
            // btmMTS_SERVO
            // 
            this.btmMTS_SERVO.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmMTS_SERVO.Location = new System.Drawing.Point(1207, 12);
            this.btmMTS_SERVO.Name = "btmMTS_SERVO";
            this.btmMTS_SERVO.Size = new System.Drawing.Size(83, 56);
            this.btmMTS_SERVO.TabIndex = 21;
            this.btmMTS_SERVO.Text = "SERVO ON/OFF";
            this.btmMTS_SERVO.Click += new System.EventHandler(this.btmMTS_SERVO_Click);
            // 
            // labelX6
            // 
            this.labelX6.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.Location = new System.Drawing.Point(345, 43);
            this.labelX6.Name = "labelX6";
            this.labelX6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.labelX6.Size = new System.Drawing.Size(187, 25);
            this.labelX6.TabIndex = 22;
            this.labelX6.Text = " CURRENT POSITION";
            // 
            // labelX7
            // 
            this.labelX7.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.Location = new System.Drawing.Point(652, 43);
            this.labelX7.Name = "labelX7";
            this.labelX7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.labelX7.Size = new System.Drawing.Size(149, 25);
            this.labelX7.TabIndex = 24;
            this.labelX7.Text = " NEXT POSITION";
            // 
            // lblCurrentIndex
            // 
            this.lblCurrentIndex.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentIndex.Location = new System.Drawing.Point(542, 12);
            this.lblCurrentIndex.Name = "lblCurrentIndex";
            this.lblCurrentIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblCurrentIndex.Size = new System.Drawing.Size(106, 25);
            this.lblCurrentIndex.TabIndex = 25;
            this.lblCurrentIndex.Text = "1";
            this.lblCurrentIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCurrentPosition
            // 
            this.lblCurrentPosition.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPosition.Location = new System.Drawing.Point(540, 43);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblCurrentPosition.Size = new System.Drawing.Size(106, 25);
            this.lblCurrentPosition.TabIndex = 26;
            this.lblCurrentPosition.Text = "0.00";
            this.lblCurrentPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNextPosition
            // 
            this.lblNextPosition.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextPosition.Location = new System.Drawing.Point(808, 43);
            this.lblNextPosition.Name = "lblNextPosition";
            this.lblNextPosition.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblNextPosition.Size = new System.Drawing.Size(117, 25);
            this.lblNextPosition.TabIndex = 28;
            this.lblNextPosition.Text = "0.00";
            this.lblNextPosition.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNextIndex
            // 
            this.lblNextIndex.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextIndex.Location = new System.Drawing.Point(810, 12);
            this.lblNextIndex.Name = "lblNextIndex";
            this.lblNextIndex.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblNextIndex.Size = new System.Drawing.Size(117, 25);
            this.lblNextIndex.TabIndex = 27;
            this.lblNextIndex.Text = "1";
            this.lblNextIndex.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // gdMotor
            // 
            this.gdMotor.ColumnInfo = resources.GetString("gdMotor.ColumnInfo");
            this.gdMotor.Location = new System.Drawing.Point(29, 76);
            this.gdMotor.Name = "gdMotor";
            this.gdMotor.Rows.Count = 51;
            this.gdMotor.Rows.DefaultSize = 25;
            this.gdMotor.Rows.Fixed = 2;
            this.gdMotor.Size = new System.Drawing.Size(1261, 404);
            this.gdMotor.TabIndex = 34;
            this.gdMotor.Click += new System.EventHandler(this.gdMotor_Click);
            this.gdMotor.DoubleClick += new System.EventHandler(this.gdMotor_DoubleClick);
            // 
            // grbJog
            // 
            this.grbJog.Controls.Add(this.txtVelocity);
            this.grbJog.Controls.Add(this.labelX5);
            this.grbJog.Controls.Add(this.btnMoveM);
            this.grbJog.Controls.Add(this.btnMoveP);
            this.grbJog.Controls.Add(this.btnJogEnable);
            this.grbJog.Controls.Add(this.btnUnitEnable);
            this.grbJog.Controls.Add(this.pnUNIT);
            this.grbJog.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbJog.ForeColor = System.Drawing.Color.Blue;
            this.grbJog.Location = new System.Drawing.Point(1325, 12);
            this.grbJog.Name = "grbJog";
            this.grbJog.Size = new System.Drawing.Size(240, 468);
            this.grbJog.TabIndex = 36;
            this.grbJog.TabStop = false;
            this.grbJog.Text = "JOG MODE";
            // 
            // txtVelocity
            // 
            this.txtVelocity.Location = new System.Drawing.Point(135, 304);
            this.txtVelocity.Name = "txtVelocity";
            this.txtVelocity.Size = new System.Drawing.Size(80, 27);
            this.txtVelocity.TabIndex = 44;
            this.txtVelocity.Text = "10";
            this.txtVelocity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtVelocity.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVelocity_KeyPress);
            // 
            // labelX5
            // 
            this.labelX5.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.Location = new System.Drawing.Point(32, 304);
            this.labelX5.Name = "labelX5";
            this.labelX5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.labelX5.Size = new System.Drawing.Size(88, 27);
            this.labelX5.TabIndex = 43;
            this.labelX5.Text = " Velocity";
            // 
            // btnMoveM
            // 
            this.btnMoveM.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveM.Location = new System.Drawing.Point(137, 402);
            this.btnMoveM.Name = "btnMoveM";
            this.btnMoveM.Size = new System.Drawing.Size(90, 38);
            this.btnMoveM.TabIndex = 42;
            this.btnMoveM.Tag = "0";
            this.btnMoveM.Text = "-";
            this.btnMoveM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveMouseDown);
            this.btnMoveM.MouseLeave += new System.EventHandler(this.btnMoveMMouseLeave);
            this.btnMoveM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveMouseUp);
            // 
            // btnMoveP
            // 
            this.btnMoveP.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveP.Location = new System.Drawing.Point(30, 401);
            this.btnMoveP.Name = "btnMoveP";
            this.btnMoveP.Size = new System.Drawing.Size(90, 38);
            this.btnMoveP.TabIndex = 41;
            this.btnMoveP.Tag = "1";
            this.btnMoveP.Text = "+";
            this.btnMoveP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveMouseDown);
            this.btnMoveP.MouseLeave += new System.EventHandler(this.btnMoveMMouseLeave);
            this.btnMoveP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveMouseUp);
            // 
            // btnJogEnable
            // 
            this.btnJogEnable.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogEnable.Location = new System.Drawing.Point(137, 358);
            this.btnJogEnable.Name = "btnJogEnable";
            this.btnJogEnable.Size = new System.Drawing.Size(90, 38);
            this.btnJogEnable.TabIndex = 40;
            this.btnJogEnable.Tag = "1";
            this.btnJogEnable.Text = "JOG";
            this.btnJogEnable.Click += new System.EventHandler(this.btnJogEnable_Click);
            // 
            // btnUnitEnable
            // 
            this.btnUnitEnable.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnitEnable.Location = new System.Drawing.Point(30, 358);
            this.btnUnitEnable.Name = "btnUnitEnable";
            this.btnUnitEnable.Size = new System.Drawing.Size(90, 38);
            this.btnUnitEnable.TabIndex = 39;
            this.btnUnitEnable.Tag = "1";
            this.btnUnitEnable.Text = "Unit(mm)";
            this.btnUnitEnable.Click += new System.EventHandler(this.btnUnitEnable_Click);
            // 
            // pnUNIT
            // 
            this.pnUNIT.BackColor = System.Drawing.SystemColors.Info;
            this.pnUNIT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnUNIT.Controls.Add(this.lblUnitValue);
            this.pnUNIT.Controls.Add(this.btnUnit5m);
            this.pnUNIT.Controls.Add(this.btnUnit4m);
            this.pnUNIT.Controls.Add(this.btnUnit3m);
            this.pnUNIT.Controls.Add(this.btnUnit2m);
            this.pnUNIT.Controls.Add(this.btnUnit5p);
            this.pnUNIT.Controls.Add(this.btnUnit4p);
            this.pnUNIT.Controls.Add(this.btnUnit3p);
            this.pnUNIT.Controls.Add(this.btnUnit2p);
            this.pnUNIT.Controls.Add(this.btnUnit1m);
            this.pnUNIT.Controls.Add(this.btnUnit1p);
            this.pnUNIT.Location = new System.Drawing.Point(28, 31);
            this.pnUNIT.Name = "pnUNIT";
            this.pnUNIT.Size = new System.Drawing.Size(195, 254);
            this.pnUNIT.TabIndex = 33;
            // 
            // lblUnitValue
            // 
            this.lblUnitValue.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitValue.Location = new System.Drawing.Point(9, 3);
            this.lblUnitValue.Name = "lblUnitValue";
            this.lblUnitValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblUnitValue.Size = new System.Drawing.Size(175, 66);
            this.lblUnitValue.TabIndex = 57;
            this.lblUnitValue.Text = "0000";
            this.lblUnitValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnUnit5m
            // 
            this.btnUnit5m.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit5m.Location = new System.Drawing.Point(104, 219);
            this.btnUnit5m.Name = "btnUnit5m";
            this.btnUnit5m.Size = new System.Drawing.Size(80, 30);
            this.btnUnit5m.TabIndex = 47;
            this.btnUnit5m.Tag = "4";
            this.btnUnit5m.Text = "-100.0x";
            this.btnUnit5m.Click += new System.EventHandler(this.btnUnitMinusClick);
            // 
            // btnUnit4m
            // 
            this.btnUnit4m.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit4m.Location = new System.Drawing.Point(104, 183);
            this.btnUnit4m.Name = "btnUnit4m";
            this.btnUnit4m.Size = new System.Drawing.Size(80, 30);
            this.btnUnit4m.TabIndex = 46;
            this.btnUnit4m.Tag = "3";
            this.btnUnit4m.Text = "-10.0x";
            this.btnUnit4m.Click += new System.EventHandler(this.btnUnitMinusClick);
            // 
            // btnUnit3m
            // 
            this.btnUnit3m.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit3m.Location = new System.Drawing.Point(104, 147);
            this.btnUnit3m.Name = "btnUnit3m";
            this.btnUnit3m.Size = new System.Drawing.Size(80, 30);
            this.btnUnit3m.TabIndex = 45;
            this.btnUnit3m.Tag = "2";
            this.btnUnit3m.Text = "-1.0x";
            this.btnUnit3m.Click += new System.EventHandler(this.btnUnitMinusClick);
            // 
            // btnUnit2m
            // 
            this.btnUnit2m.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit2m.Location = new System.Drawing.Point(104, 111);
            this.btnUnit2m.Name = "btnUnit2m";
            this.btnUnit2m.Size = new System.Drawing.Size(80, 30);
            this.btnUnit2m.TabIndex = 44;
            this.btnUnit2m.Tag = "1";
            this.btnUnit2m.Text = "-0.1x";
            this.btnUnit2m.Click += new System.EventHandler(this.btnUnitMinusClick);
            // 
            // btnUnit5p
            // 
            this.btnUnit5p.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit5p.Location = new System.Drawing.Point(9, 219);
            this.btnUnit5p.Name = "btnUnit5p";
            this.btnUnit5p.Size = new System.Drawing.Size(80, 30);
            this.btnUnit5p.TabIndex = 43;
            this.btnUnit5p.Tag = "4";
            this.btnUnit5p.Text = "+100.0x";
            this.btnUnit5p.Click += new System.EventHandler(this.btnUnitPlusClick);
            // 
            // btnUnit4p
            // 
            this.btnUnit4p.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit4p.Location = new System.Drawing.Point(9, 183);
            this.btnUnit4p.Name = "btnUnit4p";
            this.btnUnit4p.Size = new System.Drawing.Size(80, 30);
            this.btnUnit4p.TabIndex = 42;
            this.btnUnit4p.Tag = "3";
            this.btnUnit4p.Text = "+10.0x";
            this.btnUnit4p.Click += new System.EventHandler(this.btnUnitPlusClick);
            // 
            // btnUnit3p
            // 
            this.btnUnit3p.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit3p.Location = new System.Drawing.Point(9, 147);
            this.btnUnit3p.Name = "btnUnit3p";
            this.btnUnit3p.Size = new System.Drawing.Size(80, 30);
            this.btnUnit3p.TabIndex = 41;
            this.btnUnit3p.Tag = "2";
            this.btnUnit3p.Text = "+1.0x";
            this.btnUnit3p.Click += new System.EventHandler(this.btnUnitPlusClick);
            // 
            // btnUnit2p
            // 
            this.btnUnit2p.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit2p.Location = new System.Drawing.Point(9, 111);
            this.btnUnit2p.Name = "btnUnit2p";
            this.btnUnit2p.Size = new System.Drawing.Size(80, 30);
            this.btnUnit2p.TabIndex = 40;
            this.btnUnit2p.Tag = "1";
            this.btnUnit2p.Text = "+0.1x";
            this.btnUnit2p.Click += new System.EventHandler(this.btnUnitPlusClick);
            // 
            // btnUnit1m
            // 
            this.btnUnit1m.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit1m.Location = new System.Drawing.Point(104, 75);
            this.btnUnit1m.Name = "btnUnit1m";
            this.btnUnit1m.Size = new System.Drawing.Size(80, 30);
            this.btnUnit1m.TabIndex = 39;
            this.btnUnit1m.Tag = "0";
            this.btnUnit1m.Text = "-0.01x";
            this.btnUnit1m.Click += new System.EventHandler(this.btnUnitMinusClick);
            // 
            // btnUnit1p
            // 
            this.btnUnit1p.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit1p.Location = new System.Drawing.Point(9, 75);
            this.btnUnit1p.Name = "btnUnit1p";
            this.btnUnit1p.Size = new System.Drawing.Size(80, 30);
            this.btnUnit1p.TabIndex = 38;
            this.btnUnit1p.Tag = "0";
            this.btnUnit1p.Text = "+0.01x";
            this.btnUnit1p.Click += new System.EventHandler(this.btnUnitPlusClick);
            // 
            // grbFunction
            // 
            this.grbFunction.Controls.Add(this.btnMoveIndex);
            this.grbFunction.Controls.Add(this.btnCalc);
            this.grbFunction.Controls.Add(this.btnSavePos);
            this.grbFunction.Controls.Add(this.btnEdit);
            this.grbFunction.Controls.Add(this.btnTenkeyJog);
            this.grbFunction.Controls.Add(this.btnJogMode);
            this.grbFunction.Controls.Add(this.panel1);
            this.grbFunction.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFunction.ForeColor = System.Drawing.Color.Blue;
            this.grbFunction.Location = new System.Drawing.Point(1325, 492);
            this.grbFunction.Name = "grbFunction";
            this.grbFunction.Size = new System.Drawing.Size(243, 426);
            this.grbFunction.TabIndex = 37;
            this.grbFunction.TabStop = false;
            this.grbFunction.Text = "FUNCTION";
            // 
            // btnMoveIndex
            // 
            this.btnMoveIndex.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveIndex.Location = new System.Drawing.Point(27, 227);
            this.btnMoveIndex.Name = "btnMoveIndex";
            this.btnMoveIndex.Size = new System.Drawing.Size(90, 66);
            this.btnMoveIndex.TabIndex = 47;
            this.btnMoveIndex.Tag = "1";
            this.btnMoveIndex.Text = "MOVE INDEX";
            this.btnMoveIndex.Click += new System.EventHandler(this.btnMoveIndex_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalc.Location = new System.Drawing.Point(135, 227);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Size = new System.Drawing.Size(90, 66);
            this.btnCalc.TabIndex = 46;
            this.btnCalc.Tag = "1";
            this.btnCalc.Text = "CALC";
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnSavePos
            // 
            this.btnSavePos.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePos.Location = new System.Drawing.Point(134, 318);
            this.btnSavePos.Name = "btnSavePos";
            this.btnSavePos.Size = new System.Drawing.Size(90, 66);
            this.btnSavePos.TabIndex = 45;
            this.btnSavePos.Tag = "1";
            this.btnSavePos.Text = "SAVE Position";
            this.btnSavePos.Click += new System.EventHandler(this.btnSavePos_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(136, 129);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(89, 66);
            this.btnEdit.TabIndex = 44;
            this.btnEdit.Tag = "1";
            this.btnEdit.Text = "EDIT";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnTenkeyJog
            // 
            this.btnTenkeyJog.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTenkeyJog.Location = new System.Drawing.Point(26, 318);
            this.btnTenkeyJog.Name = "btnTenkeyJog";
            this.btnTenkeyJog.Size = new System.Drawing.Size(90, 66);
            this.btnTenkeyJog.TabIndex = 43;
            this.btnTenkeyJog.Tag = "1";
            this.btnTenkeyJog.Text = "TENKEY JOG";
            this.btnTenkeyJog.Click += new System.EventHandler(this.btnTenkeyJog_Click);
            // 
            // btnJogMode
            // 
            this.btnJogMode.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogMode.Location = new System.Drawing.Point(28, 129);
            this.btnJogMode.Name = "btnJogMode";
            this.btnJogMode.Size = new System.Drawing.Size(89, 66);
            this.btnJogMode.TabIndex = 42;
            this.btnJogMode.Tag = "1";
            this.btnJogMode.Text = "JOG MODE";
            this.btnJogMode.Click += new System.EventHandler(this.btnJogMode_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.panel1.Controls.Add(this.lblIdx);
            this.panel1.Controls.Add(this.btnIDXWrite);
            this.panel1.Location = new System.Drawing.Point(20, 26);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(215, 77);
            this.panel1.TabIndex = 40;
            // 
            // lblIdx
            // 
            this.lblIdx.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdx.Location = new System.Drawing.Point(6, 8);
            this.lblIdx.Name = "lblIdx";
            this.lblIdx.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblIdx.Size = new System.Drawing.Size(91, 62);
            this.lblIdx.TabIndex = 58;
            this.lblIdx.Text = "000";
            this.lblIdx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIDXWrite
            // 
            this.btnIDXWrite.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIDXWrite.Location = new System.Drawing.Point(115, 8);
            this.btnIDXWrite.Name = "btnIDXWrite";
            this.btnIDXWrite.Size = new System.Drawing.Size(87, 62);
            this.btnIDXWrite.TabIndex = 50;
            this.btnIDXWrite.Tag = "1";
            this.btnIDXWrite.Text = "IDX WRITE";
            this.btnIDXWrite.Click += new System.EventHandler(this.btnIDXWrite_Click);
            // 
            // gdMotorCommon
            // 
            this.gdMotorCommon.ColumnInfo = resources.GetString("gdMotorCommon.ColumnInfo");
            this.gdMotorCommon.Location = new System.Drawing.Point(29, 492);
            this.gdMotorCommon.Name = "gdMotorCommon";
            this.gdMotorCommon.Rows.Count = 52;
            this.gdMotorCommon.Rows.DefaultSize = 25;
            this.gdMotorCommon.Rows.Fixed = 2;
            this.gdMotorCommon.Size = new System.Drawing.Size(1261, 429);
            this.gdMotorCommon.TabIndex = 38;
            this.gdMotorCommon.Click += new System.EventHandler(this.gdMotorCommon_Click);
            this.gdMotorCommon.DoubleClick += new System.EventHandler(this.gdMotorCommon_DoubleClick);
            // 
            // FormMotorSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1600, 930);
            this.Controls.Add(this.gdMotorCommon);
            this.Controls.Add(this.grbFunction);
            this.Controls.Add(this.grbJog);
            this.Controls.Add(this.gdMotor);
            this.Controls.Add(this.lblNextPosition);
            this.Controls.Add(this.lblNextIndex);
            this.Controls.Add(this.lblCurrentPosition);
            this.Controls.Add(this.lblCurrentIndex);
            this.Controls.Add(this.labelX7);
            this.Controls.Add(this.labelX6);
            this.Controls.Add(this.btmMTS_SERVO);
            this.Controls.Add(this.bntMTS_ALARM);
            this.Controls.Add(this.btnMTS_MOVING);
            this.Controls.Add(this.btnMTS_HOME);
            this.Controls.Add(this.btnMTS_ORG);
            this.Controls.Add(this.btnMTS_CW);
            this.Controls.Add(this.btnMTS_CCW);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.cbMotor);
            this.Controls.Add(this.labelX3);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMotorSetting";
            this.Text = "FormMotorSetting";
            this.Load += new System.EventHandler(this.FormMotorSetting_Load);
            this.Shown += new System.EventHandler(this.FormMotorSetting_Shown);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMotorSetting_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gdMotor)).EndInit();
            this.grbJog.ResumeLayout(false);
            this.grbJog.PerformLayout();
            this.pnUNIT.ResumeLayout(false);
            this.grbFunction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdMotorCommon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelX3;
        private System.Windows.Forms.ComboBox cbMotor;
        private System.Windows.Forms.Label labelX1;
        private System.Windows.Forms.Label labelX2;
        public MMI.HmiButton btnMTS_CCW;
        public MMI.HmiButton btnMTS_CW;
        public MMI.HmiButton btnMTS_ORG;
        public MMI.HmiButton btnMTS_HOME;
        public MMI.HmiButton btnMTS_MOVING;
        public MMI.HmiButton bntMTS_ALARM;
        public MMI.HmiButton btmMTS_SERVO;
        private System.Windows.Forms.Label labelX6;
        private System.Windows.Forms.Label labelX7;
        public System.Windows.Forms.Label lblCurrentIndex;
        public System.Windows.Forms.Label lblCurrentPosition;
        public System.Windows.Forms.Label lblNextPosition;
        public System.Windows.Forms.Label lblNextIndex;
        public MMI.HmiGrid gdMotor;
        private System.Windows.Forms.GroupBox grbJog;
        private System.Windows.Forms.Panel pnUNIT;
        private MMI.HmiButton btnUnit5m;
        private MMI.HmiButton btnUnit4m;
        private MMI.HmiButton btnUnit3m;
        private MMI.HmiButton btnUnit2m;
        private MMI.HmiButton btnUnit5p;
        private MMI.HmiButton btnUnit4p;
        private MMI.HmiButton btnUnit3p;
        private MMI.HmiButton btnUnit2p;
        private MMI.HmiButton btnUnit1m;
        private MMI.HmiButton btnUnit1p;
        private System.Windows.Forms.GroupBox grbFunction;
        private System.Windows.Forms.Panel panel1;
        private MMI.HmiButton btnMoveM;
        private MMI.HmiButton btnMoveP;
        private MMI.HmiButton btnJogEnable;
        private MMI.HmiButton btnUnitEnable;
        private MMI.HmiButton btnSavePos;
        private MMI.HmiButton btnEdit;
        private MMI.HmiButton btnJogMode;
        private MMI.HmiButton btnIDXWrite;
        public MMI.HmiGrid gdMotorCommon;
        private MMI.HmiButton btnCalc;
        private System.Windows.Forms.Label lblUnitValue;
        private System.Windows.Forms.Label lblIdx;
        public MMI.HmiButton btnTenkeyJog;
        private MMI.HmiButton btnMoveIndex;
        private System.Windows.Forms.TextBox txtVelocity;
        private System.Windows.Forms.Label labelX5;
    }
}