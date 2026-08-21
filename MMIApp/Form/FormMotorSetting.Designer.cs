
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
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.cbMotor = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnMTS_CCW = new DevComponents.DotNetBar.ButtonX();
            this.btnMTS_CW = new DevComponents.DotNetBar.ButtonX();
            this.btnMTS_ORG = new DevComponents.DotNetBar.ButtonX();
            this.btnMTS_HOME = new DevComponents.DotNetBar.ButtonX();
            this.btnMTS_MOVING = new DevComponents.DotNetBar.ButtonX();
            this.bntMTS_ALARM = new DevComponents.DotNetBar.ButtonX();
            this.btmMTS_SERVO = new DevComponents.DotNetBar.ButtonX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.lblCurrentIndex = new DevComponents.DotNetBar.LabelX();
            this.lblCurrentPosition = new DevComponents.DotNetBar.LabelX();
            this.lblNextPosition = new DevComponents.DotNetBar.LabelX();
            this.lblNextIndex = new DevComponents.DotNetBar.LabelX();
            this.gdMotor = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.grbJog = new System.Windows.Forms.GroupBox();
            this.txtVelocity = new System.Windows.Forms.TextBox();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.btnMoveM = new DevComponents.DotNetBar.ButtonX();
            this.btnMoveP = new DevComponents.DotNetBar.ButtonX();
            this.btnJogEnable = new DevComponents.DotNetBar.ButtonX();
            this.btnUnitEnable = new DevComponents.DotNetBar.ButtonX();
            this.pnUNIT = new System.Windows.Forms.Panel();
            this.lblUnitValue = new DevComponents.DotNetBar.LabelX();
            this.btnUnit5m = new DevComponents.DotNetBar.ButtonX();
            this.btnUnit4m = new DevComponents.DotNetBar.ButtonX();
            this.btnUnit3m = new DevComponents.DotNetBar.ButtonX();
            this.btnUnit2m = new DevComponents.DotNetBar.ButtonX();
            this.btnUnit5p = new DevComponents.DotNetBar.ButtonX();
            this.btnUnit4p = new DevComponents.DotNetBar.ButtonX();
            this.btnUnit3p = new DevComponents.DotNetBar.ButtonX();
            this.btnUnit2p = new DevComponents.DotNetBar.ButtonX();
            this.btnUnit1m = new DevComponents.DotNetBar.ButtonX();
            this.btnUnit1p = new DevComponents.DotNetBar.ButtonX();
            this.grbFunction = new System.Windows.Forms.GroupBox();
            this.btnMoveIndex = new DevComponents.DotNetBar.ButtonX();
            this.btnCalc = new DevComponents.DotNetBar.ButtonX();
            this.btnSavePos = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnTenkeyJog = new DevComponents.DotNetBar.ButtonX();
            this.btnJogMode = new DevComponents.DotNetBar.ButtonX();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblIdx = new DevComponents.DotNetBar.LabelX();
            this.btnIDXWrite = new DevComponents.DotNetBar.ButtonX();
            this.gdMotorCommon = new C1.Win.C1FlexGrid.C1FlexGrid();
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
            this.labelX3.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX3.BackgroundStyle.BackColor2 = System.Drawing.Color.DarkOliveGreen;
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
            this.labelX3.BackgroundStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX3.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX3.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX3.Location = new System.Drawing.Point(29, 12);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(294, 25);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "MOTOR SELECT";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbMotor
            // 
            this.cbMotor.DisplayMember = "Text";
            this.cbMotor.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbMotor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMotor.FocusCuesEnabled = false;
            this.cbMotor.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMotor.ForeColor = System.Drawing.Color.Black;
            this.cbMotor.FormattingEnabled = true;
            this.cbMotor.ItemHeight = 22;
            this.cbMotor.Location = new System.Drawing.Point(29, 43);
            this.cbMotor.Name = "cbMotor";
            this.cbMotor.Size = new System.Drawing.Size(294, 28);
            this.cbMotor.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbMotor.TabIndex = 10;
            this.cbMotor.DropDownChange += new DevComponents.DotNetBar.Controls.ComboBoxEx.OnDropDownChangeEventHandler(this.cbMotor_DropDownChange);
            this.cbMotor.SelectedIndexChanged += new System.EventHandler(this.cbMotor_SelectedIndexChanged);
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.SystemColors.Info;
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
            this.labelX1.BackgroundStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX1.Location = new System.Drawing.Point(347, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(187, 25);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX1.TabIndex = 11;
            this.labelX1.Text = " CURRENT INDEX";
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.BackgroundStyle.BackColor2 = System.Drawing.Color.ForestGreen;
            this.labelX2.BackgroundStyle.BackColorGradientAngle = 90;
            this.labelX2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX2.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX2.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderGradientAngle = 0;
            this.labelX2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX2.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX2.BackgroundStyle.BorderLightGradientAngle = 0;
            this.labelX2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX2.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderRightWidth = 1;
            this.labelX2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX2.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderTopWidth = 1;
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.BackgroundStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX2.Location = new System.Drawing.Point(654, 12);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(147, 25);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX2.TabIndex = 12;
            this.labelX2.Text = " NEXT INDEX";
            // 
            // btnMTS_CCW
            // 
            this.btnMTS_CCW.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMTS_CCW.BackColor = System.Drawing.Color.Black;
            this.btnMTS_CCW.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMTS_CCW.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMTS_CCW.Location = new System.Drawing.Point(940, 12);
            this.btnMTS_CCW.Name = "btnMTS_CCW";
            this.btnMTS_CCW.Size = new System.Drawing.Size(83, 25);
            this.btnMTS_CCW.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMTS_CCW.TabIndex = 15;
            this.btnMTS_CCW.Text = "-Limit";
            this.btnMTS_CCW.TextColor = System.Drawing.Color.White;
            this.btnMTS_CCW.ThemeAware = true;
            // 
            // btnMTS_CW
            // 
            this.btnMTS_CW.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMTS_CW.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnMTS_CW.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMTS_CW.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMTS_CW.Location = new System.Drawing.Point(1029, 12);
            this.btnMTS_CW.Name = "btnMTS_CW";
            this.btnMTS_CW.Size = new System.Drawing.Size(83, 25);
            this.btnMTS_CW.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMTS_CW.TabIndex = 16;
            this.btnMTS_CW.Text = "+Limit";
            this.btnMTS_CW.TextColor = System.Drawing.Color.White;
            this.btnMTS_CW.ThemeAware = true;
            // 
            // btnMTS_ORG
            // 
            this.btnMTS_ORG.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMTS_ORG.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnMTS_ORG.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMTS_ORG.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMTS_ORG.Location = new System.Drawing.Point(1118, 12);
            this.btnMTS_ORG.Name = "btnMTS_ORG";
            this.btnMTS_ORG.Size = new System.Drawing.Size(83, 25);
            this.btnMTS_ORG.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMTS_ORG.TabIndex = 17;
            this.btnMTS_ORG.Text = "ORG";
            this.btnMTS_ORG.TextColor = System.Drawing.Color.White;
            this.btnMTS_ORG.ThemeAware = true;
            // 
            // btnMTS_HOME
            // 
            this.btnMTS_HOME.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMTS_HOME.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnMTS_HOME.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMTS_HOME.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMTS_HOME.Location = new System.Drawing.Point(940, 43);
            this.btnMTS_HOME.Name = "btnMTS_HOME";
            this.btnMTS_HOME.Size = new System.Drawing.Size(83, 25);
            this.btnMTS_HOME.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMTS_HOME.TabIndex = 18;
            this.btnMTS_HOME.Text = "HOME";
            this.btnMTS_HOME.TextColor = System.Drawing.Color.White;
            this.btnMTS_HOME.ThemeAware = true;
            this.btnMTS_HOME.Click += new System.EventHandler(this.btnMTS_HOME_Click);
            // 
            // btnMTS_MOVING
            // 
            this.btnMTS_MOVING.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMTS_MOVING.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btnMTS_MOVING.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMTS_MOVING.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMTS_MOVING.Location = new System.Drawing.Point(1029, 43);
            this.btnMTS_MOVING.Name = "btnMTS_MOVING";
            this.btnMTS_MOVING.Size = new System.Drawing.Size(83, 25);
            this.btnMTS_MOVING.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMTS_MOVING.TabIndex = 19;
            this.btnMTS_MOVING.Text = "MOVING";
            this.btnMTS_MOVING.TextColor = System.Drawing.Color.White;
            this.btnMTS_MOVING.ThemeAware = true;
            // 
            // bntMTS_ALARM
            // 
            this.bntMTS_ALARM.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.bntMTS_ALARM.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.bntMTS_ALARM.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.bntMTS_ALARM.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntMTS_ALARM.Location = new System.Drawing.Point(1118, 43);
            this.bntMTS_ALARM.Name = "bntMTS_ALARM";
            this.bntMTS_ALARM.Size = new System.Drawing.Size(83, 25);
            this.bntMTS_ALARM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.bntMTS_ALARM.TabIndex = 20;
            this.bntMTS_ALARM.Text = "ALARM";
            this.bntMTS_ALARM.TextColor = System.Drawing.Color.White;
            this.bntMTS_ALARM.ThemeAware = true;
            this.bntMTS_ALARM.Click += new System.EventHandler(this.bntMTS_ALARM_Click);
            // 
            // btmMTS_SERVO
            // 
            this.btmMTS_SERVO.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btmMTS_SERVO.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.btmMTS_SERVO.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btmMTS_SERVO.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmMTS_SERVO.Location = new System.Drawing.Point(1207, 12);
            this.btmMTS_SERVO.Name = "btmMTS_SERVO";
            this.btmMTS_SERVO.Size = new System.Drawing.Size(83, 56);
            this.btmMTS_SERVO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btmMTS_SERVO.TabIndex = 21;
            this.btmMTS_SERVO.Text = "SERVO ON/OFF";
            this.btmMTS_SERVO.TextColor = System.Drawing.Color.White;
            this.btmMTS_SERVO.ThemeAware = true;
            this.btmMTS_SERVO.Click += new System.EventHandler(this.btmMTS_SERVO_Click);
            // 
            // labelX6
            // 
            this.labelX6.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX6.BackgroundStyle.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.labelX6.BackgroundStyle.BackColorGradientAngle = 90;
            this.labelX6.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX6.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.labelX6.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX6.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.labelX6.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.labelX6.BackgroundStyle.BorderGradientAngle = 0;
            this.labelX6.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX6.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.labelX6.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX6.BackgroundStyle.BorderLightGradientAngle = 0;
            this.labelX6.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX6.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.labelX6.BackgroundStyle.BorderRightWidth = 1;
            this.labelX6.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX6.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.labelX6.BackgroundStyle.BorderTopWidth = 1;
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.BackgroundStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX6.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX6.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX6.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX6.Location = new System.Drawing.Point(345, 43);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(187, 25);
            this.labelX6.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX6.TabIndex = 22;
            this.labelX6.Text = " CURRENT POSITION";
            // 
            // labelX7
            // 
            this.labelX7.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX7.BackgroundStyle.BackColor2 = System.Drawing.Color.ForestGreen;
            this.labelX7.BackgroundStyle.BackColorGradientAngle = 90;
            this.labelX7.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX7.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.labelX7.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX7.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.labelX7.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.labelX7.BackgroundStyle.BorderGradientAngle = 0;
            this.labelX7.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX7.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.labelX7.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX7.BackgroundStyle.BorderLightGradientAngle = 0;
            this.labelX7.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX7.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.labelX7.BackgroundStyle.BorderRightWidth = 1;
            this.labelX7.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX7.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.labelX7.BackgroundStyle.BorderTopWidth = 1;
            this.labelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX7.BackgroundStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX7.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX7.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX7.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX7.Location = new System.Drawing.Point(652, 43);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(149, 25);
            this.labelX7.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX7.TabIndex = 24;
            this.labelX7.Text = " NEXT POSITION";
            // 
            // lblCurrentIndex
            // 
            this.lblCurrentIndex.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblCurrentIndex.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentIndex.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent;
            this.lblCurrentIndex.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblCurrentIndex.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentIndex.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblCurrentIndex.BackgroundStyle.BorderBottomWidth = 1;
            this.lblCurrentIndex.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblCurrentIndex.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblCurrentIndex.BackgroundStyle.BorderGradientAngle = 0;
            this.lblCurrentIndex.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentIndex.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblCurrentIndex.BackgroundStyle.BorderLeftWidth = 1;
            this.lblCurrentIndex.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblCurrentIndex.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentIndex.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblCurrentIndex.BackgroundStyle.BorderRightWidth = 1;
            this.lblCurrentIndex.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentIndex.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblCurrentIndex.BackgroundStyle.BorderTopWidth = 1;
            this.lblCurrentIndex.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCurrentIndex.BackgroundStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrentIndex.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblCurrentIndex.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentIndex.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblCurrentIndex.Location = new System.Drawing.Point(542, 12);
            this.lblCurrentIndex.Name = "lblCurrentIndex";
            this.lblCurrentIndex.Size = new System.Drawing.Size(106, 25);
            this.lblCurrentIndex.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblCurrentIndex.TabIndex = 25;
            this.lblCurrentIndex.Text = "1";
            this.lblCurrentIndex.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCurrentPosition
            // 
            this.lblCurrentPosition.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblCurrentPosition.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblCurrentPosition.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent;
            this.lblCurrentPosition.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblCurrentPosition.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentPosition.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblCurrentPosition.BackgroundStyle.BorderBottomWidth = 1;
            this.lblCurrentPosition.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblCurrentPosition.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblCurrentPosition.BackgroundStyle.BorderGradientAngle = 0;
            this.lblCurrentPosition.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentPosition.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblCurrentPosition.BackgroundStyle.BorderLeftWidth = 1;
            this.lblCurrentPosition.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblCurrentPosition.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentPosition.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblCurrentPosition.BackgroundStyle.BorderRightWidth = 1;
            this.lblCurrentPosition.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblCurrentPosition.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblCurrentPosition.BackgroundStyle.BorderTopWidth = 1;
            this.lblCurrentPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCurrentPosition.BackgroundStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCurrentPosition.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblCurrentPosition.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentPosition.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblCurrentPosition.Location = new System.Drawing.Point(540, 43);
            this.lblCurrentPosition.Name = "lblCurrentPosition";
            this.lblCurrentPosition.Size = new System.Drawing.Size(106, 25);
            this.lblCurrentPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblCurrentPosition.TabIndex = 26;
            this.lblCurrentPosition.Text = "0.00";
            this.lblCurrentPosition.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblNextPosition
            // 
            this.lblNextPosition.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblNextPosition.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblNextPosition.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent;
            this.lblNextPosition.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblNextPosition.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblNextPosition.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblNextPosition.BackgroundStyle.BorderBottomWidth = 1;
            this.lblNextPosition.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblNextPosition.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblNextPosition.BackgroundStyle.BorderGradientAngle = 0;
            this.lblNextPosition.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblNextPosition.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblNextPosition.BackgroundStyle.BorderLeftWidth = 1;
            this.lblNextPosition.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblNextPosition.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblNextPosition.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblNextPosition.BackgroundStyle.BorderRightWidth = 1;
            this.lblNextPosition.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblNextPosition.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblNextPosition.BackgroundStyle.BorderTopWidth = 1;
            this.lblNextPosition.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNextPosition.BackgroundStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNextPosition.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblNextPosition.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextPosition.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblNextPosition.Location = new System.Drawing.Point(808, 43);
            this.lblNextPosition.Name = "lblNextPosition";
            this.lblNextPosition.Size = new System.Drawing.Size(117, 25);
            this.lblNextPosition.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblNextPosition.TabIndex = 28;
            this.lblNextPosition.Text = "0.00";
            this.lblNextPosition.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblNextIndex
            // 
            this.lblNextIndex.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.lblNextIndex.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblNextIndex.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent;
            this.lblNextIndex.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblNextIndex.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblNextIndex.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblNextIndex.BackgroundStyle.BorderBottomWidth = 1;
            this.lblNextIndex.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblNextIndex.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblNextIndex.BackgroundStyle.BorderGradientAngle = 0;
            this.lblNextIndex.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblNextIndex.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblNextIndex.BackgroundStyle.BorderLeftWidth = 1;
            this.lblNextIndex.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblNextIndex.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblNextIndex.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblNextIndex.BackgroundStyle.BorderRightWidth = 1;
            this.lblNextIndex.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblNextIndex.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblNextIndex.BackgroundStyle.BorderTopWidth = 1;
            this.lblNextIndex.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNextIndex.BackgroundStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNextIndex.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblNextIndex.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNextIndex.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblNextIndex.Location = new System.Drawing.Point(810, 12);
            this.lblNextIndex.Name = "lblNextIndex";
            this.lblNextIndex.Size = new System.Drawing.Size(117, 25);
            this.lblNextIndex.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblNextIndex.TabIndex = 27;
            this.lblNextIndex.Text = "1";
            this.lblNextIndex.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // gdMotor
            // 
            this.gdMotor.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdMotor.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdMotor.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdMotor.ColumnInfo = resources.GetString("gdMotor.ColumnInfo");
            this.gdMotor.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdMotor.Location = new System.Drawing.Point(29, 76);
            this.gdMotor.Name = "gdMotor";
            this.gdMotor.Rows.Count = 51;
            this.gdMotor.Rows.DefaultSize = 25;
            this.gdMotor.Rows.Fixed = 2;
            this.gdMotor.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdMotor.Size = new System.Drawing.Size(1261, 404);
            this.gdMotor.StyleInfo = resources.GetString("gdMotor.StyleInfo");
            this.gdMotor.TabIndex = 34;
            this.gdMotor.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
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
            this.grbJog.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.labelX5.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX5.BackgroundStyle.BackColor2 = System.Drawing.Color.ForestGreen;
            this.labelX5.BackgroundStyle.BackColorGradientAngle = 90;
            this.labelX5.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX5.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.labelX5.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX5.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.labelX5.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.labelX5.BackgroundStyle.BorderGradientAngle = 0;
            this.labelX5.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX5.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.labelX5.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX5.BackgroundStyle.BorderLightGradientAngle = 0;
            this.labelX5.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX5.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.labelX5.BackgroundStyle.BorderRightWidth = 1;
            this.labelX5.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX5.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.labelX5.BackgroundStyle.BorderTopWidth = 1;
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.BackgroundStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX5.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX5.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX5.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX5.Location = new System.Drawing.Point(32, 304);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(88, 27);
            this.labelX5.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX5.TabIndex = 43;
            this.labelX5.Text = " Velocity";
            // 
            // btnMoveM
            // 
            this.btnMoveM.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMoveM.BackColor = System.Drawing.Color.Black;
            this.btnMoveM.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMoveM.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveM.Location = new System.Drawing.Point(137, 402);
            this.btnMoveM.Name = "btnMoveM";
            this.btnMoveM.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMoveM.Size = new System.Drawing.Size(90, 38);
            this.btnMoveM.TabIndex = 42;
            this.btnMoveM.Tag = "0";
            this.btnMoveM.Text = "-";
            this.btnMoveM.TextColor = System.Drawing.Color.White;
            this.btnMoveM.ThemeAware = true;
            this.btnMoveM.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveMouseDown);
            this.btnMoveM.MouseLeave += new System.EventHandler(this.btnMoveMMouseLeave);
            this.btnMoveM.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveMouseUp);
            // 
            // btnMoveP
            // 
            this.btnMoveP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMoveP.BackColor = System.Drawing.Color.Black;
            this.btnMoveP.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMoveP.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveP.Location = new System.Drawing.Point(30, 401);
            this.btnMoveP.Name = "btnMoveP";
            this.btnMoveP.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMoveP.Size = new System.Drawing.Size(90, 38);
            this.btnMoveP.TabIndex = 41;
            this.btnMoveP.Tag = "1";
            this.btnMoveP.Text = "+";
            this.btnMoveP.TextColor = System.Drawing.Color.White;
            this.btnMoveP.ThemeAware = true;
            this.btnMoveP.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMoveMouseDown);
            this.btnMoveP.MouseLeave += new System.EventHandler(this.btnMoveMMouseLeave);
            this.btnMoveP.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMoveMouseUp);
            // 
            // btnJogEnable
            // 
            this.btnJogEnable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnJogEnable.BackColor = System.Drawing.Color.Black;
            this.btnJogEnable.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnJogEnable.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogEnable.Location = new System.Drawing.Point(137, 358);
            this.btnJogEnable.Name = "btnJogEnable";
            this.btnJogEnable.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnJogEnable.Size = new System.Drawing.Size(90, 38);
            this.btnJogEnable.TabIndex = 40;
            this.btnJogEnable.Tag = "1";
            this.btnJogEnable.Text = "JOG";
            this.btnJogEnable.TextColor = System.Drawing.Color.White;
            this.btnJogEnable.ThemeAware = true;
            this.btnJogEnable.Click += new System.EventHandler(this.btnJogEnable_Click);
            // 
            // btnUnitEnable
            // 
            this.btnUnitEnable.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnitEnable.BackColor = System.Drawing.Color.Black;
            this.btnUnitEnable.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnitEnable.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnitEnable.Location = new System.Drawing.Point(30, 358);
            this.btnUnitEnable.Name = "btnUnitEnable";
            this.btnUnitEnable.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnitEnable.Size = new System.Drawing.Size(90, 38);
            this.btnUnitEnable.TabIndex = 39;
            this.btnUnitEnable.Tag = "1";
            this.btnUnitEnable.Text = "Unit(mm)";
            this.btnUnitEnable.TextColor = System.Drawing.Color.White;
            this.btnUnitEnable.ThemeAware = true;
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
            this.lblUnitValue.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.lblUnitValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblUnitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitValue.ForeColor = System.Drawing.Color.Lime;
            this.lblUnitValue.Location = new System.Drawing.Point(9, 3);
            this.lblUnitValue.Name = "lblUnitValue";
            this.lblUnitValue.Size = new System.Drawing.Size(175, 66);
            this.lblUnitValue.TabIndex = 57;
            this.lblUnitValue.Text = "0000";
            this.lblUnitValue.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnUnit5m
            // 
            this.btnUnit5m.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit5m.BackColor = System.Drawing.Color.Black;
            this.btnUnit5m.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnit5m.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit5m.Location = new System.Drawing.Point(104, 219);
            this.btnUnit5m.Name = "btnUnit5m";
            this.btnUnit5m.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnit5m.Size = new System.Drawing.Size(80, 30);
            this.btnUnit5m.TabIndex = 47;
            this.btnUnit5m.Tag = "4";
            this.btnUnit5m.Text = "-100.0x";
            this.btnUnit5m.TextColor = System.Drawing.Color.White;
            this.btnUnit5m.ThemeAware = true;
            this.btnUnit5m.Click += new System.EventHandler(this.btnUnitMinusClick);
            // 
            // btnUnit4m
            // 
            this.btnUnit4m.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit4m.BackColor = System.Drawing.Color.Black;
            this.btnUnit4m.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnit4m.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit4m.Location = new System.Drawing.Point(104, 183);
            this.btnUnit4m.Name = "btnUnit4m";
            this.btnUnit4m.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnit4m.Size = new System.Drawing.Size(80, 30);
            this.btnUnit4m.TabIndex = 46;
            this.btnUnit4m.Tag = "3";
            this.btnUnit4m.Text = "-10.0x";
            this.btnUnit4m.TextColor = System.Drawing.Color.White;
            this.btnUnit4m.ThemeAware = true;
            this.btnUnit4m.Click += new System.EventHandler(this.btnUnitMinusClick);
            // 
            // btnUnit3m
            // 
            this.btnUnit3m.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit3m.BackColor = System.Drawing.Color.Black;
            this.btnUnit3m.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnit3m.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit3m.Location = new System.Drawing.Point(104, 147);
            this.btnUnit3m.Name = "btnUnit3m";
            this.btnUnit3m.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnit3m.Size = new System.Drawing.Size(80, 30);
            this.btnUnit3m.TabIndex = 45;
            this.btnUnit3m.Tag = "2";
            this.btnUnit3m.Text = "-1.0x";
            this.btnUnit3m.TextColor = System.Drawing.Color.White;
            this.btnUnit3m.ThemeAware = true;
            this.btnUnit3m.Click += new System.EventHandler(this.btnUnitMinusClick);
            // 
            // btnUnit2m
            // 
            this.btnUnit2m.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit2m.BackColor = System.Drawing.Color.Black;
            this.btnUnit2m.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnit2m.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit2m.Location = new System.Drawing.Point(104, 111);
            this.btnUnit2m.Name = "btnUnit2m";
            this.btnUnit2m.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnit2m.Size = new System.Drawing.Size(80, 30);
            this.btnUnit2m.TabIndex = 44;
            this.btnUnit2m.Tag = "1";
            this.btnUnit2m.Text = "-0.1x";
            this.btnUnit2m.TextColor = System.Drawing.Color.White;
            this.btnUnit2m.ThemeAware = true;
            this.btnUnit2m.Click += new System.EventHandler(this.btnUnitMinusClick);
            // 
            // btnUnit5p
            // 
            this.btnUnit5p.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit5p.BackColor = System.Drawing.Color.Black;
            this.btnUnit5p.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnit5p.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit5p.Location = new System.Drawing.Point(9, 219);
            this.btnUnit5p.Name = "btnUnit5p";
            this.btnUnit5p.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnit5p.Size = new System.Drawing.Size(80, 30);
            this.btnUnit5p.TabIndex = 43;
            this.btnUnit5p.Tag = "4";
            this.btnUnit5p.Text = "+100.0x";
            this.btnUnit5p.TextColor = System.Drawing.Color.White;
            this.btnUnit5p.ThemeAware = true;
            this.btnUnit5p.Click += new System.EventHandler(this.btnUnitPlusClick);
            // 
            // btnUnit4p
            // 
            this.btnUnit4p.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit4p.BackColor = System.Drawing.Color.Black;
            this.btnUnit4p.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnit4p.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit4p.Location = new System.Drawing.Point(9, 183);
            this.btnUnit4p.Name = "btnUnit4p";
            this.btnUnit4p.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnit4p.Size = new System.Drawing.Size(80, 30);
            this.btnUnit4p.TabIndex = 42;
            this.btnUnit4p.Tag = "3";
            this.btnUnit4p.Text = "+10.0x";
            this.btnUnit4p.TextColor = System.Drawing.Color.White;
            this.btnUnit4p.ThemeAware = true;
            this.btnUnit4p.Click += new System.EventHandler(this.btnUnitPlusClick);
            // 
            // btnUnit3p
            // 
            this.btnUnit3p.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit3p.BackColor = System.Drawing.Color.Black;
            this.btnUnit3p.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnit3p.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit3p.Location = new System.Drawing.Point(9, 147);
            this.btnUnit3p.Name = "btnUnit3p";
            this.btnUnit3p.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnit3p.Size = new System.Drawing.Size(80, 30);
            this.btnUnit3p.TabIndex = 41;
            this.btnUnit3p.Tag = "2";
            this.btnUnit3p.Text = "+1.0x";
            this.btnUnit3p.TextColor = System.Drawing.Color.White;
            this.btnUnit3p.ThemeAware = true;
            this.btnUnit3p.Click += new System.EventHandler(this.btnUnitPlusClick);
            // 
            // btnUnit2p
            // 
            this.btnUnit2p.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit2p.BackColor = System.Drawing.Color.Black;
            this.btnUnit2p.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnit2p.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit2p.Location = new System.Drawing.Point(9, 111);
            this.btnUnit2p.Name = "btnUnit2p";
            this.btnUnit2p.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnit2p.Size = new System.Drawing.Size(80, 30);
            this.btnUnit2p.TabIndex = 40;
            this.btnUnit2p.Tag = "1";
            this.btnUnit2p.Text = "+0.1x";
            this.btnUnit2p.TextColor = System.Drawing.Color.White;
            this.btnUnit2p.ThemeAware = true;
            this.btnUnit2p.Click += new System.EventHandler(this.btnUnitPlusClick);
            // 
            // btnUnit1m
            // 
            this.btnUnit1m.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit1m.BackColor = System.Drawing.Color.Black;
            this.btnUnit1m.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnit1m.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit1m.Location = new System.Drawing.Point(104, 75);
            this.btnUnit1m.Name = "btnUnit1m";
            this.btnUnit1m.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnit1m.Size = new System.Drawing.Size(80, 30);
            this.btnUnit1m.TabIndex = 39;
            this.btnUnit1m.Tag = "0";
            this.btnUnit1m.Text = "-0.01x";
            this.btnUnit1m.TextColor = System.Drawing.Color.White;
            this.btnUnit1m.ThemeAware = true;
            this.btnUnit1m.Click += new System.EventHandler(this.btnUnitMinusClick);
            // 
            // btnUnit1p
            // 
            this.btnUnit1p.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnUnit1p.BackColor = System.Drawing.Color.Black;
            this.btnUnit1p.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnUnit1p.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnit1p.Location = new System.Drawing.Point(9, 75);
            this.btnUnit1p.Name = "btnUnit1p";
            this.btnUnit1p.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnUnit1p.Size = new System.Drawing.Size(80, 30);
            this.btnUnit1p.TabIndex = 38;
            this.btnUnit1p.Tag = "0";
            this.btnUnit1p.Text = "+0.01x";
            this.btnUnit1p.TextColor = System.Drawing.Color.White;
            this.btnUnit1p.ThemeAware = true;
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
            this.grbFunction.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.btnMoveIndex.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMoveIndex.BackColor = System.Drawing.Color.Black;
            this.btnMoveIndex.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMoveIndex.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMoveIndex.Location = new System.Drawing.Point(27, 227);
            this.btnMoveIndex.Name = "btnMoveIndex";
            this.btnMoveIndex.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMoveIndex.Size = new System.Drawing.Size(90, 66);
            this.btnMoveIndex.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnMoveIndex.TabIndex = 47;
            this.btnMoveIndex.Tag = "1";
            this.btnMoveIndex.Text = "MOVE INDEX";
            this.btnMoveIndex.TextColor = System.Drawing.Color.White;
            this.btnMoveIndex.ThemeAware = true;
            this.btnMoveIndex.Click += new System.EventHandler(this.btnMoveIndex_Click);
            // 
            // btnCalc
            // 
            this.btnCalc.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCalc.BackColor = System.Drawing.Color.Black;
            this.btnCalc.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCalc.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalc.Location = new System.Drawing.Point(135, 227);
            this.btnCalc.Name = "btnCalc";
            this.btnCalc.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnCalc.Size = new System.Drawing.Size(90, 66);
            this.btnCalc.TabIndex = 46;
            this.btnCalc.Tag = "1";
            this.btnCalc.Text = "CALC";
            this.btnCalc.TextColor = System.Drawing.Color.White;
            this.btnCalc.ThemeAware = true;
            this.btnCalc.Click += new System.EventHandler(this.btnCalc_Click);
            // 
            // btnSavePos
            // 
            this.btnSavePos.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSavePos.BackColor = System.Drawing.Color.Black;
            this.btnSavePos.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSavePos.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSavePos.Location = new System.Drawing.Point(134, 318);
            this.btnSavePos.Name = "btnSavePos";
            this.btnSavePos.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSavePos.Size = new System.Drawing.Size(90, 66);
            this.btnSavePos.TabIndex = 45;
            this.btnSavePos.Tag = "1";
            this.btnSavePos.Text = "SAVE Position";
            this.btnSavePos.TextColor = System.Drawing.Color.White;
            this.btnSavePos.ThemeAware = true;
            this.btnSavePos.Click += new System.EventHandler(this.btnSavePos_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.BackColor = System.Drawing.Color.Black;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(136, 129);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnEdit.Size = new System.Drawing.Size(89, 66);
            this.btnEdit.TabIndex = 44;
            this.btnEdit.Tag = "1";
            this.btnEdit.Text = "EDIT";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.ThemeAware = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnTenkeyJog
            // 
            this.btnTenkeyJog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTenkeyJog.BackColor = System.Drawing.Color.Black;
            this.btnTenkeyJog.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnTenkeyJog.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTenkeyJog.Location = new System.Drawing.Point(26, 318);
            this.btnTenkeyJog.Name = "btnTenkeyJog";
            this.btnTenkeyJog.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnTenkeyJog.Size = new System.Drawing.Size(90, 66);
            this.btnTenkeyJog.TabIndex = 43;
            this.btnTenkeyJog.Tag = "1";
            this.btnTenkeyJog.Text = "TENKEY JOG";
            this.btnTenkeyJog.TextColor = System.Drawing.Color.White;
            this.btnTenkeyJog.ThemeAware = true;
            this.btnTenkeyJog.Click += new System.EventHandler(this.btnTenkeyJog_Click);
            // 
            // btnJogMode
            // 
            this.btnJogMode.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnJogMode.BackColor = System.Drawing.Color.Black;
            this.btnJogMode.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnJogMode.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnJogMode.Location = new System.Drawing.Point(28, 129);
            this.btnJogMode.Name = "btnJogMode";
            this.btnJogMode.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnJogMode.Size = new System.Drawing.Size(89, 66);
            this.btnJogMode.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnJogMode.TabIndex = 42;
            this.btnJogMode.Tag = "1";
            this.btnJogMode.Text = "JOG MODE";
            this.btnJogMode.TextColor = System.Drawing.Color.White;
            this.btnJogMode.ThemeAware = true;
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
            this.lblIdx.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.lblIdx.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIdx.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdx.ForeColor = System.Drawing.Color.Lime;
            this.lblIdx.Location = new System.Drawing.Point(6, 8);
            this.lblIdx.Name = "lblIdx";
            this.lblIdx.Size = new System.Drawing.Size(91, 62);
            this.lblIdx.TabIndex = 58;
            this.lblIdx.Text = "000";
            this.lblIdx.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnIDXWrite
            // 
            this.btnIDXWrite.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnIDXWrite.BackColor = System.Drawing.Color.Black;
            this.btnIDXWrite.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnIDXWrite.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIDXWrite.Location = new System.Drawing.Point(115, 8);
            this.btnIDXWrite.Name = "btnIDXWrite";
            this.btnIDXWrite.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnIDXWrite.Size = new System.Drawing.Size(87, 62);
            this.btnIDXWrite.TabIndex = 50;
            this.btnIDXWrite.Tag = "1";
            this.btnIDXWrite.Text = "IDX WRITE";
            this.btnIDXWrite.TextColor = System.Drawing.Color.White;
            this.btnIDXWrite.ThemeAware = true;
            this.btnIDXWrite.Click += new System.EventHandler(this.btnIDXWrite_Click);
            // 
            // gdMotorCommon
            // 
            this.gdMotorCommon.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdMotorCommon.ColumnInfo = resources.GetString("gdMotorCommon.ColumnInfo");
            this.gdMotorCommon.Location = new System.Drawing.Point(29, 492);
            this.gdMotorCommon.Name = "gdMotorCommon";
            this.gdMotorCommon.Rows.Count = 52;
            this.gdMotorCommon.Rows.DefaultSize = 25;
            this.gdMotorCommon.Rows.Fixed = 2;
            this.gdMotorCommon.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdMotorCommon.Size = new System.Drawing.Size(1261, 429);
            this.gdMotorCommon.StyleInfo = resources.GetString("gdMotorCommon.StyleInfo");
            this.gdMotorCommon.TabIndex = 38;
            this.gdMotorCommon.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            this.gdMotorCommon.Click += new System.EventHandler(this.gdMotorCommon_Click);
            this.gdMotorCommon.DoubleClick += new System.EventHandler(this.gdMotorCommon_DoubleClick);
            // 
            // FormMotorSetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
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
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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

        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbMotor;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        public DevComponents.DotNetBar.ButtonX btnMTS_CCW;
        public DevComponents.DotNetBar.ButtonX btnMTS_CW;
        public DevComponents.DotNetBar.ButtonX btnMTS_ORG;
        public DevComponents.DotNetBar.ButtonX btnMTS_HOME;
        public DevComponents.DotNetBar.ButtonX btnMTS_MOVING;
        public DevComponents.DotNetBar.ButtonX bntMTS_ALARM;
        public DevComponents.DotNetBar.ButtonX btmMTS_SERVO;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.LabelX labelX7;
        public DevComponents.DotNetBar.LabelX lblCurrentIndex;
        public DevComponents.DotNetBar.LabelX lblCurrentPosition;
        public DevComponents.DotNetBar.LabelX lblNextPosition;
        public DevComponents.DotNetBar.LabelX lblNextIndex;
        public C1.Win.C1FlexGrid.C1FlexGrid gdMotor;
        private System.Windows.Forms.GroupBox grbJog;
        private System.Windows.Forms.Panel pnUNIT;
        private DevComponents.DotNetBar.ButtonX btnUnit5m;
        private DevComponents.DotNetBar.ButtonX btnUnit4m;
        private DevComponents.DotNetBar.ButtonX btnUnit3m;
        private DevComponents.DotNetBar.ButtonX btnUnit2m;
        private DevComponents.DotNetBar.ButtonX btnUnit5p;
        private DevComponents.DotNetBar.ButtonX btnUnit4p;
        private DevComponents.DotNetBar.ButtonX btnUnit3p;
        private DevComponents.DotNetBar.ButtonX btnUnit2p;
        private DevComponents.DotNetBar.ButtonX btnUnit1m;
        private DevComponents.DotNetBar.ButtonX btnUnit1p;
        private System.Windows.Forms.GroupBox grbFunction;
        private System.Windows.Forms.Panel panel1;
        private DevComponents.DotNetBar.ButtonX btnMoveM;
        private DevComponents.DotNetBar.ButtonX btnMoveP;
        private DevComponents.DotNetBar.ButtonX btnJogEnable;
        private DevComponents.DotNetBar.ButtonX btnUnitEnable;
        private DevComponents.DotNetBar.ButtonX btnSavePos;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnJogMode;
        private DevComponents.DotNetBar.ButtonX btnIDXWrite;
        public C1.Win.C1FlexGrid.C1FlexGrid gdMotorCommon;
        private DevComponents.DotNetBar.ButtonX btnCalc;
        private DevComponents.DotNetBar.LabelX lblUnitValue;
        private DevComponents.DotNetBar.LabelX lblIdx;
        public DevComponents.DotNetBar.ButtonX btnTenkeyJog;
        private DevComponents.DotNetBar.ButtonX btnMoveIndex;
        private System.Windows.Forms.TextBox txtVelocity;
        private DevComponents.DotNetBar.LabelX labelX5;
    }
}