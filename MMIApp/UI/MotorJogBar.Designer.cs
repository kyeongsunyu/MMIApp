namespace MMI
{
    partial class MotorJogBar
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlMotor = new MMI.HmiCard();
            this.pnlJog = new MMI.HmiCard();
            this.cbAxis = new System.Windows.Forms.ComboBox();
            this.txtJogVel = new System.Windows.Forms.TextBox();
            this.lblAxisCaption = new System.Windows.Forms.Label();
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
            this.lblStepCaption = new System.Windows.Forms.Label();
            this.lblStep = new System.Windows.Forms.Label();
            this.lblJogVelCaption = new System.Windows.Forms.Label();
            this.lblModeHint = new System.Windows.Forms.Label();
            this.lblJogResult = new System.Windows.Forms.Label();
            this.btnServo = new MMI.HmiButton();
            this.btnHome = new MMI.HmiButton();
            this.btnAlarmReset = new MMI.HmiButton();
            this.btnJogEnable = new MMI.HmiButton();
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
            this.btnJogMinus = new MMI.HmiButton();
            this.btnJogPlus = new MMI.HmiButton();
            this.pnlMotor.SuspendLayout();
            this.pnlJog.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlJog.Controls.Add(this.lblModeHint);
            this.pnlJog.Controls.Add(this.btnJogPlus);
            this.pnlJog.Controls.Add(this.btnJogMinus);
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
            this.pnlJog.Location = new System.Drawing.Point(0, 86);
            this.pnlJog.Size = new System.Drawing.Size(1644, 86);
            this.pnlJog.TitleText = "";
            this.pnlJog.Name = "pnlJog";
            // 
            // btnJogEnable
            // 
            this.btnJogEnable.Location = new System.Drawing.Point(14, 8);
            this.btnJogEnable.Size = new System.Drawing.Size(150, 32);
            this.btnJogEnable.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJogEnable.Text = "JOG ENABLE";
            this.btnJogEnable.Name = "btnJogEnable";
            this.btnJogEnable.Click += new System.EventHandler(this.btnJogEnable_Click);
            // 
            // btnModeStep
            // 
            this.btnModeStep.Location = new System.Drawing.Point(14, 46);
            this.btnModeStep.Size = new System.Drawing.Size(72, 30);
            this.btnModeStep.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModeStep.Text = "STEP";
            this.btnModeStep.Name = "btnModeStep";
            this.btnModeStep.Click += new System.EventHandler(this.btnModeStep_Click);
            // 
            // btnModeJog
            // 
            this.btnModeJog.Location = new System.Drawing.Point(90, 46);
            this.btnModeJog.Size = new System.Drawing.Size(72, 30);
            this.btnModeJog.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnModeJog.Text = "JOG";
            this.btnModeJog.Name = "btnModeJog";
            this.btnModeJog.Click += new System.EventHandler(this.btnModeJog_Click);
            // 
            // lblStepCaption
            // 
            this.lblStepCaption.Location = new System.Drawing.Point(176, 8);
            this.lblStepCaption.Size = new System.Drawing.Size(86, 30);
            this.lblStepCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStepCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStepCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblStepCaption.Text = "Step (mm)";
            this.lblStepCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStepCaption.Name = "lblStepCaption";
            // 
            // lblStep
            // 
            this.lblStep.Location = new System.Drawing.Point(176, 44);
            this.lblStep.Size = new System.Drawing.Size(86, 32);
            this.lblStep.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStep.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblStep.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblStep.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblStep.Text = "0.00";
            this.lblStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStep.Name = "lblStep";
            // 
            // btnStepP0
            // 
            this.btnStepP0.Location = new System.Drawing.Point(272, 8);
            this.btnStepP0.Size = new System.Drawing.Size(86, 32);
            this.btnStepP0.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepP0.Text = "+0.01";
            this.btnStepP0.Tag = "0";
            this.btnStepP0.Name = "btnStepP0";
            this.btnStepP0.Click += new System.EventHandler(this.btnStepPlus_Click);
            // 
            // btnStepP1
            // 
            this.btnStepP1.Location = new System.Drawing.Point(364, 8);
            this.btnStepP1.Size = new System.Drawing.Size(86, 32);
            this.btnStepP1.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepP1.Text = "+0.1";
            this.btnStepP1.Tag = "1";
            this.btnStepP1.Name = "btnStepP1";
            this.btnStepP1.Click += new System.EventHandler(this.btnStepPlus_Click);
            // 
            // btnStepP2
            // 
            this.btnStepP2.Location = new System.Drawing.Point(456, 8);
            this.btnStepP2.Size = new System.Drawing.Size(86, 32);
            this.btnStepP2.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepP2.Text = "+1.0";
            this.btnStepP2.Tag = "2";
            this.btnStepP2.Name = "btnStepP2";
            this.btnStepP2.Click += new System.EventHandler(this.btnStepPlus_Click);
            // 
            // btnStepP3
            // 
            this.btnStepP3.Location = new System.Drawing.Point(548, 8);
            this.btnStepP3.Size = new System.Drawing.Size(86, 32);
            this.btnStepP3.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepP3.Text = "+10.0";
            this.btnStepP3.Tag = "3";
            this.btnStepP3.Name = "btnStepP3";
            this.btnStepP3.Click += new System.EventHandler(this.btnStepPlus_Click);
            // 
            // btnStepP4
            // 
            this.btnStepP4.Location = new System.Drawing.Point(640, 8);
            this.btnStepP4.Size = new System.Drawing.Size(86, 32);
            this.btnStepP4.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepP4.Text = "+100.0";
            this.btnStepP4.Tag = "4";
            this.btnStepP4.Name = "btnStepP4";
            this.btnStepP4.Click += new System.EventHandler(this.btnStepPlus_Click);
            // 
            // btnStepM0
            // 
            this.btnStepM0.Location = new System.Drawing.Point(272, 44);
            this.btnStepM0.Size = new System.Drawing.Size(86, 32);
            this.btnStepM0.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepM0.Text = "-0.01";
            this.btnStepM0.Tag = "0";
            this.btnStepM0.Name = "btnStepM0";
            this.btnStepM0.Click += new System.EventHandler(this.btnStepMinus_Click);
            // 
            // btnStepM1
            // 
            this.btnStepM1.Location = new System.Drawing.Point(364, 44);
            this.btnStepM1.Size = new System.Drawing.Size(86, 32);
            this.btnStepM1.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepM1.Text = "-0.1";
            this.btnStepM1.Tag = "1";
            this.btnStepM1.Name = "btnStepM1";
            this.btnStepM1.Click += new System.EventHandler(this.btnStepMinus_Click);
            // 
            // btnStepM2
            // 
            this.btnStepM2.Location = new System.Drawing.Point(456, 44);
            this.btnStepM2.Size = new System.Drawing.Size(86, 32);
            this.btnStepM2.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepM2.Text = "-1.0";
            this.btnStepM2.Tag = "2";
            this.btnStepM2.Name = "btnStepM2";
            this.btnStepM2.Click += new System.EventHandler(this.btnStepMinus_Click);
            // 
            // btnStepM3
            // 
            this.btnStepM3.Location = new System.Drawing.Point(548, 44);
            this.btnStepM3.Size = new System.Drawing.Size(86, 32);
            this.btnStepM3.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepM3.Text = "-10.0";
            this.btnStepM3.Tag = "3";
            this.btnStepM3.Name = "btnStepM3";
            this.btnStepM3.Click += new System.EventHandler(this.btnStepMinus_Click);
            // 
            // btnStepM4
            // 
            this.btnStepM4.Location = new System.Drawing.Point(640, 44);
            this.btnStepM4.Size = new System.Drawing.Size(86, 32);
            this.btnStepM4.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnStepM4.Text = "-100.0";
            this.btnStepM4.Tag = "4";
            this.btnStepM4.Name = "btnStepM4";
            this.btnStepM4.Click += new System.EventHandler(this.btnStepMinus_Click);
            // 
            // lblJogVelCaption
            // 
            this.lblJogVelCaption.Location = new System.Drawing.Point(744, 8);
            this.lblJogVelCaption.Size = new System.Drawing.Size(70, 30);
            this.lblJogVelCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblJogVelCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblJogVelCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblJogVelCaption.Text = "Velocity";
            this.lblJogVelCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblJogVelCaption.Name = "lblJogVelCaption";
            // 
            // txtJogVel
            // 
            this.txtJogVel.Location = new System.Drawing.Point(744, 44);
            this.txtJogVel.Size = new System.Drawing.Size(86, 32);
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
            // btnJogMinus
            // 
            this.btnJogMinus.Location = new System.Drawing.Point(846, 8);
            this.btnJogMinus.Size = new System.Drawing.Size(120, 68);
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
            this.btnJogPlus.Location = new System.Drawing.Point(972, 8);
            this.btnJogPlus.Size = new System.Drawing.Size(120, 68);
            this.btnJogPlus.Font = new System.Drawing.Font("Malgun Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnJogPlus.Text = "+";
            this.btnJogPlus.Tag = "1";
            this.btnJogPlus.Name = "btnJogPlus";
            this.btnJogPlus.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnJogMove_MouseDown);
            this.btnJogPlus.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnJogMove_MouseUp);
            this.btnJogPlus.MouseLeave += new System.EventHandler(this.btnJogMove_MouseLeave);
            // 
            // lblModeHint
            // 
            this.lblModeHint.Location = new System.Drawing.Point(1104, 8);
            this.lblModeHint.Size = new System.Drawing.Size(526, 30);
            this.lblModeHint.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblModeHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblModeHint.BackColor = System.Drawing.Color.Transparent;
            this.lblModeHint.Text = "";
            this.lblModeHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblModeHint.Name = "lblModeHint";
            // 
            // lblJogResult
            // 
            this.lblJogResult.Location = new System.Drawing.Point(1104, 44);
            this.lblJogResult.Size = new System.Drawing.Size(526, 32);
            this.lblJogResult.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblJogResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblJogResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblJogResult.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblJogResult.Text = "";
            this.lblJogResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblJogResult.Name = "lblJogResult";
            // 
            // MotorJogBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Controls.Add(this.pnlJog);
            this.Controls.Add(this.pnlMotor);
            this.Name = "MotorJogBar";
            this.Size = new System.Drawing.Size(1644, 172);
            this.pnlJog.ResumeLayout(false);
            this.pnlJog.PerformLayout();
            this.pnlMotor.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private MMI.HmiCard pnlMotor;
        private MMI.HmiCard pnlJog;
        private System.Windows.Forms.ComboBox cbAxis;
        private System.Windows.Forms.TextBox txtJogVel;
        private System.Windows.Forms.Label lblAxisCaption;
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
        private System.Windows.Forms.Label lblStepCaption;
        private System.Windows.Forms.Label lblStep;
        private System.Windows.Forms.Label lblJogVelCaption;
        private System.Windows.Forms.Label lblModeHint;
        private System.Windows.Forms.Label lblJogResult;
        private MMI.HmiButton btnServo;
        private MMI.HmiButton btnHome;
        private MMI.HmiButton btnAlarmReset;
        private MMI.HmiButton btnJogEnable;
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
        private MMI.HmiButton btnJogMinus;
        private MMI.HmiButton btnJogPlus;
    }
}
