namespace MMI
{
    partial class FormAuto1
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
            this.pnlKpiIn = new MMI.HmiCard();
            this.lblInCount = new System.Windows.Forms.Label();
            this.pnlKpiOut = new MMI.HmiCard();
            this.lblOutCount = new System.Windows.Forms.Label();
            this.pnlKpiGood = new MMI.HmiCard();
            this.lblGoodCount = new System.Windows.Forms.Label();
            this.pnlKpiRework = new MMI.HmiCard();
            this.lblReworkCount = new System.Windows.Forms.Label();
            this.pnlKpiNG = new MMI.HmiCard();
            this.lblNGCount = new System.Windows.Forms.Label();
            this.pnlKpiUPH = new MMI.HmiCard();
            this.lblUPH = new System.Windows.Forms.Label();
            this.pnlLot = new MMI.HmiCard();
            this.lblLotIdCaption = new System.Windows.Forms.Label();
            this.lblLotID = new System.Windows.Forms.Label();
            this.lblLotCountCaption = new System.Windows.Forms.Label();
            this.lblLotCount = new System.Windows.Forms.Label();
            this.btnLOTInput = new MMI.HmiButton();
            this.btnLotCancel = new MMI.HmiButton();
            this.pnlEquipState = new MMI.HmiCard();
            this.lblStateRun = new System.Windows.Forms.Label();
            this.lblStateStop = new System.Windows.Forms.Label();
            this.lblStateAlarm = new System.Windows.Forms.Label();
            this.lblRunTimeCaption = new System.Windows.Forms.Label();
            this.lblRunningTime = new System.Windows.Forms.Label();
            this.lblStopTimeCaption = new System.Windows.Forms.Label();
            this.lblStopTime = new System.Windows.Forms.Label();
            this.pnlControl = new MMI.HmiCard();
            this.btnSTART = new MMI.HmiButton();
            this.btnSTOP = new MMI.HmiButton();
            this.btnRESET = new MMI.HmiButton();
            this.btnInit = new MMI.HmiButton();
            this.btnLOTEnd = new MMI.HmiButton();
            this.pnlProduction = new MMI.HmiCard();
            this.lblPanelInCaption = new System.Windows.Forms.Label();
            this.lblPanelInCount = new System.Windows.Forms.Label();
            this.lblRateCaption = new System.Windows.Forms.Label();
            this.lblRate = new System.Windows.Forms.Label();
            this.lblTargetUPHCaption = new System.Windows.Forms.Label();
            this.lblTargetUPH = new System.Windows.Forms.Label();
            this.btnTargetUPH = new MMI.HmiButton();
            this.lblAirTitle = new System.Windows.Forms.Label();
            this.lblAir1Caption = new System.Windows.Forms.Label();
            this.lblAir1 = new System.Windows.Forms.Label();
            this.lblAir2Caption = new System.Windows.Forms.Label();
            this.lblAir2 = new System.Windows.Forms.Label();
            this.lblAir3Caption = new System.Windows.Forms.Label();
            this.lblAir3 = new System.Windows.Forms.Label();
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
            this.pnlComm = new MMI.HmiCard();
            this.tcAuto = new MMI.HmiTabControl();
            this.tcComm = new System.Windows.Forms.TabPage();
            this.tcInspVision = new System.Windows.Forms.TabPage();
            this.tcVision = new System.Windows.Forms.Panel();
            this.tmRun = new System.Windows.Forms.Timer(this.components);
            this.pnlKpiIn.SuspendLayout();
            this.pnlKpiOut.SuspendLayout();
            this.pnlKpiGood.SuspendLayout();
            this.pnlKpiRework.SuspendLayout();
            this.pnlKpiNG.SuspendLayout();
            this.pnlKpiUPH.SuspendLayout();
            this.pnlLot.SuspendLayout();
            this.pnlEquipState.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.pnlProduction.SuspendLayout();
            this.pnlScanTrigger.SuspendLayout();
            this.pnlComm.SuspendLayout();
            this.tcAuto.SuspendLayout();
            this.tcComm.SuspendLayout();
            this.tcInspVision.SuspendLayout();
            this.tcVision.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKpiIn
            // 
            this.pnlKpiIn.Controls.Add(this.lblInCount);
            this.pnlKpiIn.Location = new System.Drawing.Point(0, 0);
            this.pnlKpiIn.Size = new System.Drawing.Size(262, 112);
            this.pnlKpiIn.TitleText = "Unit In";
            this.pnlKpiIn.Name = "pnlKpiIn";
            // 
            // lblInCount
            // 
            this.lblInCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInCount.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblInCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblInCount.BackColor = System.Drawing.Color.Transparent;
            this.lblInCount.Text = "0";
            this.lblInCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblInCount.Size = new System.Drawing.Size(242, 62);
            this.lblInCount.Name = "lblInCount";
            // 
            // pnlKpiOut
            // 
            this.pnlKpiOut.Controls.Add(this.lblOutCount);
            this.pnlKpiOut.Location = new System.Drawing.Point(274, 0);
            this.pnlKpiOut.Size = new System.Drawing.Size(262, 112);
            this.pnlKpiOut.TitleText = "Unit Out";
            this.pnlKpiOut.Name = "pnlKpiOut";
            // 
            // lblOutCount
            // 
            this.lblOutCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutCount.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOutCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOutCount.BackColor = System.Drawing.Color.Transparent;
            this.lblOutCount.Text = "0";
            this.lblOutCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblOutCount.Size = new System.Drawing.Size(242, 62);
            this.lblOutCount.Name = "lblOutCount";
            // 
            // pnlKpiGood
            // 
            this.pnlKpiGood.Controls.Add(this.lblGoodCount);
            this.pnlKpiGood.Location = new System.Drawing.Point(548, 0);
            this.pnlKpiGood.Size = new System.Drawing.Size(262, 112);
            this.pnlKpiGood.TitleText = "Good";
            this.pnlKpiGood.Name = "pnlKpiGood";
            // 
            // lblGoodCount
            // 
            this.lblGoodCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblGoodCount.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblGoodCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(164)))), ((int)(((byte)(108)))));
            this.lblGoodCount.BackColor = System.Drawing.Color.Transparent;
            this.lblGoodCount.Text = "0";
            this.lblGoodCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblGoodCount.Size = new System.Drawing.Size(242, 62);
            this.lblGoodCount.Name = "lblGoodCount";
            // 
            // pnlKpiRework
            // 
            this.pnlKpiRework.Controls.Add(this.lblReworkCount);
            this.pnlKpiRework.Location = new System.Drawing.Point(822, 0);
            this.pnlKpiRework.Size = new System.Drawing.Size(262, 112);
            this.pnlKpiRework.TitleText = "Rework";
            this.pnlKpiRework.Name = "pnlKpiRework";
            // 
            // lblReworkCount
            // 
            this.lblReworkCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReworkCount.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReworkCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(165)))), ((int)(((byte)(36)))));
            this.lblReworkCount.BackColor = System.Drawing.Color.Transparent;
            this.lblReworkCount.Text = "0";
            this.lblReworkCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblReworkCount.Size = new System.Drawing.Size(242, 62);
            this.lblReworkCount.Name = "lblReworkCount";
            // 
            // pnlKpiNG
            // 
            this.pnlKpiNG.Controls.Add(this.lblNGCount);
            this.pnlKpiNG.Location = new System.Drawing.Point(1096, 0);
            this.pnlKpiNG.Size = new System.Drawing.Size(262, 112);
            this.pnlKpiNG.TitleText = "NG";
            this.pnlKpiNG.Name = "pnlKpiNG";
            // 
            // lblNGCount
            // 
            this.lblNGCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNGCount.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblNGCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(72)))), ((int)(((byte)(77)))));
            this.lblNGCount.BackColor = System.Drawing.Color.Transparent;
            this.lblNGCount.Text = "0";
            this.lblNGCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNGCount.Size = new System.Drawing.Size(242, 62);
            this.lblNGCount.Name = "lblNGCount";
            // 
            // pnlKpiUPH
            // 
            this.pnlKpiUPH.Controls.Add(this.lblUPH);
            this.pnlKpiUPH.Location = new System.Drawing.Point(1370, 0);
            this.pnlKpiUPH.Size = new System.Drawing.Size(262, 112);
            this.pnlKpiUPH.TitleText = "UPH";
            this.pnlKpiUPH.Name = "pnlKpiUPH";
            // 
            // lblUPH
            // 
            this.lblUPH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblUPH.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblUPH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblUPH.BackColor = System.Drawing.Color.Transparent;
            this.lblUPH.Text = "0";
            this.lblUPH.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblUPH.Size = new System.Drawing.Size(242, 62);
            this.lblUPH.Name = "lblUPH";
            // 
            // pnlLot
            // 
            this.pnlLot.Controls.Add(this.btnLotCancel);
            this.pnlLot.Controls.Add(this.btnLOTInput);
            this.pnlLot.Controls.Add(this.lblLotCount);
            this.pnlLot.Controls.Add(this.lblLotCountCaption);
            this.pnlLot.Controls.Add(this.lblLotID);
            this.pnlLot.Controls.Add(this.lblLotIdCaption);
            this.pnlLot.Location = new System.Drawing.Point(0, 126);
            this.pnlLot.Size = new System.Drawing.Size(540, 150);
            this.pnlLot.TitleText = "Lot";
            this.pnlLot.Name = "pnlLot";
            // 
            // lblLotIdCaption
            // 
            this.lblLotIdCaption.Location = new System.Drawing.Point(14, 40);
            this.lblLotIdCaption.Size = new System.Drawing.Size(90, 28);
            this.lblLotIdCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLotIdCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLotIdCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblLotIdCaption.Text = "Lot ID";
            this.lblLotIdCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLotIdCaption.Name = "lblLotIdCaption";
            // 
            // lblLotID
            // 
            this.lblLotID.Location = new System.Drawing.Point(110, 40);
            this.lblLotID.Size = new System.Drawing.Size(410, 30);
            this.lblLotID.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLotID.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblLotID.Text = "";
            this.lblLotID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLotID.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblLotID.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblLotID.Name = "lblLotID";
            // 
            // lblLotCountCaption
            // 
            this.lblLotCountCaption.Location = new System.Drawing.Point(14, 76);
            this.lblLotCountCaption.Size = new System.Drawing.Size(90, 28);
            this.lblLotCountCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLotCountCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblLotCountCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblLotCountCaption.Text = "Count";
            this.lblLotCountCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblLotCountCaption.Name = "lblLotCountCaption";
            // 
            // lblLotCount
            // 
            this.lblLotCount.Location = new System.Drawing.Point(110, 76);
            this.lblLotCount.Size = new System.Drawing.Size(160, 30);
            this.lblLotCount.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblLotCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblLotCount.Text = "";
            this.lblLotCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblLotCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblLotCount.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblLotCount.Name = "lblLotCount";
            // 
            // btnLOTInput
            // 
            this.btnLOTInput.Location = new System.Drawing.Point(280, 108);
            this.btnLOTInput.Size = new System.Drawing.Size(116, 34);
            this.btnLOTInput.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLOTInput.Text = "Lot Input";
            this.btnLOTInput.Role = MMI.HmiButtonRole.Primary;
            this.btnLOTInput.Name = "btnLOTInput";
            this.btnLOTInput.Click += new System.EventHandler(this.btnLOTInput_Click);
            // 
            // btnLotCancel
            // 
            this.btnLotCancel.Location = new System.Drawing.Point(404, 108);
            this.btnLotCancel.Size = new System.Drawing.Size(116, 34);
            this.btnLotCancel.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLotCancel.Text = "Lot Cancel";
            this.btnLotCancel.Name = "btnLotCancel";
            // 
            // pnlEquipState
            // 
            this.pnlEquipState.Controls.Add(this.lblStopTime);
            this.pnlEquipState.Controls.Add(this.lblStopTimeCaption);
            this.pnlEquipState.Controls.Add(this.lblRunningTime);
            this.pnlEquipState.Controls.Add(this.lblRunTimeCaption);
            this.pnlEquipState.Controls.Add(this.lblStateAlarm);
            this.pnlEquipState.Controls.Add(this.lblStateStop);
            this.pnlEquipState.Controls.Add(this.lblStateRun);
            this.pnlEquipState.Location = new System.Drawing.Point(552, 126);
            this.pnlEquipState.Size = new System.Drawing.Size(540, 150);
            this.pnlEquipState.TitleText = "Equipment State";
            this.pnlEquipState.Name = "pnlEquipState";
            // 
            // lblStateRun
            // 
            this.lblStateRun.Location = new System.Drawing.Point(14, 40);
            this.lblStateRun.Size = new System.Drawing.Size(160, 36);
            this.lblStateRun.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStateRun.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.lblStateRun.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStateRun.Text = "RUN";
            this.lblStateRun.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStateRun.Name = "lblStateRun";
            // 
            // lblStateStop
            // 
            this.lblStateStop.Location = new System.Drawing.Point(186, 40);
            this.lblStateStop.Size = new System.Drawing.Size(160, 36);
            this.lblStateStop.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStateStop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.lblStateStop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStateStop.Text = "STOP";
            this.lblStateStop.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStateStop.Name = "lblStateStop";
            // 
            // lblStateAlarm
            // 
            this.lblStateAlarm.Location = new System.Drawing.Point(358, 40);
            this.lblStateAlarm.Size = new System.Drawing.Size(160, 36);
            this.lblStateAlarm.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStateAlarm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(52)))), ((int)(((byte)(58)))));
            this.lblStateAlarm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStateAlarm.Text = "ALARM";
            this.lblStateAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblStateAlarm.Name = "lblStateAlarm";
            // 
            // lblRunTimeCaption
            // 
            this.lblRunTimeCaption.Location = new System.Drawing.Point(14, 92);
            this.lblRunTimeCaption.Size = new System.Drawing.Size(90, 28);
            this.lblRunTimeCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRunTimeCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblRunTimeCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblRunTimeCaption.Text = "Run Time";
            this.lblRunTimeCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRunTimeCaption.Name = "lblRunTimeCaption";
            // 
            // lblRunningTime
            // 
            this.lblRunningTime.Location = new System.Drawing.Point(104, 92);
            this.lblRunningTime.Size = new System.Drawing.Size(150, 30);
            this.lblRunningTime.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRunningTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblRunningTime.Text = "00:00:00";
            this.lblRunningTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRunningTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblRunningTime.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblRunningTime.Name = "lblRunningTime";
            // 
            // lblStopTimeCaption
            // 
            this.lblStopTimeCaption.Location = new System.Drawing.Point(276, 92);
            this.lblStopTimeCaption.Size = new System.Drawing.Size(90, 28);
            this.lblStopTimeCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStopTimeCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblStopTimeCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblStopTimeCaption.Text = "Stop Time";
            this.lblStopTimeCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStopTimeCaption.Name = "lblStopTimeCaption";
            // 
            // lblStopTime
            // 
            this.lblStopTime.Location = new System.Drawing.Point(366, 92);
            this.lblStopTime.Size = new System.Drawing.Size(160, 30);
            this.lblStopTime.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStopTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblStopTime.Text = "00:00:00";
            this.lblStopTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblStopTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblStopTime.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblStopTime.Name = "lblStopTime";
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnLOTEnd);
            this.pnlControl.Controls.Add(this.btnInit);
            this.pnlControl.Controls.Add(this.btnRESET);
            this.pnlControl.Controls.Add(this.btnSTOP);
            this.pnlControl.Controls.Add(this.btnSTART);
            this.pnlControl.Location = new System.Drawing.Point(1104, 126);
            this.pnlControl.Size = new System.Drawing.Size(540, 150);
            this.pnlControl.TitleText = "Control";
            this.pnlControl.Name = "pnlControl";
            // 
            // btnSTART
            // 
            this.btnSTART.Location = new System.Drawing.Point(14, 44);
            this.btnSTART.Size = new System.Drawing.Size(120, 56);
            this.btnSTART.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSTART.Text = "Start";
            this.btnSTART.Role = MMI.HmiButtonRole.Success;
            this.btnSTART.Tag = "1";
            this.btnSTART.Name = "btnSTART";
            this.btnSTART.Click += new System.EventHandler(this.btnSeqOperation);
            // 
            // btnSTOP
            // 
            this.btnSTOP.Location = new System.Drawing.Point(142, 44);
            this.btnSTOP.Size = new System.Drawing.Size(120, 56);
            this.btnSTOP.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSTOP.Text = "Stop";
            this.btnSTOP.Role = MMI.HmiButtonRole.Danger;
            this.btnSTOP.Tag = "2";
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Click += new System.EventHandler(this.btnSeqOperation);
            // 
            // btnRESET
            // 
            this.btnRESET.Location = new System.Drawing.Point(270, 44);
            this.btnRESET.Size = new System.Drawing.Size(120, 56);
            this.btnRESET.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnRESET.Text = "Reset";
            this.btnRESET.Tag = "3";
            this.btnRESET.Name = "btnRESET";
            this.btnRESET.Click += new System.EventHandler(this.btnSeqOperation);
            // 
            // btnInit
            // 
            this.btnInit.Location = new System.Drawing.Point(398, 44);
            this.btnInit.Size = new System.Drawing.Size(128, 56);
            this.btnInit.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnInit.Text = "Initialize";
            this.btnInit.Tag = "11";
            this.btnInit.Name = "btnInit";
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnLOTEnd
            // 
            this.btnLOTEnd.Location = new System.Drawing.Point(14, 108);
            this.btnLOTEnd.Size = new System.Drawing.Size(120, 32);
            this.btnLOTEnd.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLOTEnd.Text = "Lot End";
            this.btnLOTEnd.Name = "btnLOTEnd";
            // 
            // pnlProduction
            // 
            this.pnlProduction.Controls.Add(this.lblAir3);
            this.pnlProduction.Controls.Add(this.lblAir3Caption);
            this.pnlProduction.Controls.Add(this.lblAir2);
            this.pnlProduction.Controls.Add(this.lblAir2Caption);
            this.pnlProduction.Controls.Add(this.lblAir1);
            this.pnlProduction.Controls.Add(this.lblAir1Caption);
            this.pnlProduction.Controls.Add(this.lblAirTitle);
            this.pnlProduction.Controls.Add(this.btnTargetUPH);
            this.pnlProduction.Controls.Add(this.lblTargetUPH);
            this.pnlProduction.Controls.Add(this.lblTargetUPHCaption);
            this.pnlProduction.Controls.Add(this.lblRate);
            this.pnlProduction.Controls.Add(this.lblRateCaption);
            this.pnlProduction.Controls.Add(this.lblPanelInCount);
            this.pnlProduction.Controls.Add(this.lblPanelInCaption);
            this.pnlProduction.Location = new System.Drawing.Point(0, 288);
            this.pnlProduction.Size = new System.Drawing.Size(540, 610);
            this.pnlProduction.TitleText = "Production";
            this.pnlProduction.Name = "pnlProduction";
            // 
            // lblPanelInCaption
            // 
            this.lblPanelInCaption.Location = new System.Drawing.Point(14, 42);
            this.lblPanelInCaption.Size = new System.Drawing.Size(220, 28);
            this.lblPanelInCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPanelInCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblPanelInCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblPanelInCaption.Text = "Panel In";
            this.lblPanelInCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPanelInCaption.Name = "lblPanelInCaption";
            // 
            // lblPanelInCount
            // 
            this.lblPanelInCount.Location = new System.Drawing.Point(300, 42);
            this.lblPanelInCount.Size = new System.Drawing.Size(220, 30);
            this.lblPanelInCount.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPanelInCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblPanelInCount.Text = "0";
            this.lblPanelInCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblPanelInCount.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblPanelInCount.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblPanelInCount.Name = "lblPanelInCount";
            // 
            // lblRateCaption
            // 
            this.lblRateCaption.Location = new System.Drawing.Point(14, 82);
            this.lblRateCaption.Size = new System.Drawing.Size(220, 28);
            this.lblRateCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRateCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblRateCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblRateCaption.Text = "Rate (UPH / Target)";
            this.lblRateCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblRateCaption.Name = "lblRateCaption";
            // 
            // lblRate
            // 
            this.lblRate.Location = new System.Drawing.Point(300, 82);
            this.lblRate.Size = new System.Drawing.Size(220, 30);
            this.lblRate.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblRate.Text = "0.00 %";
            this.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblRate.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblRate.Name = "lblRate";
            // 
            // lblTargetUPHCaption
            // 
            this.lblTargetUPHCaption.Location = new System.Drawing.Point(14, 122);
            this.lblTargetUPHCaption.Size = new System.Drawing.Size(220, 28);
            this.lblTargetUPHCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTargetUPHCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblTargetUPHCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblTargetUPHCaption.Text = "Target UPH";
            this.lblTargetUPHCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTargetUPHCaption.Name = "lblTargetUPHCaption";
            // 
            // lblTargetUPH
            // 
            this.lblTargetUPH.Location = new System.Drawing.Point(300, 122);
            this.lblTargetUPH.Size = new System.Drawing.Size(120, 30);
            this.lblTargetUPH.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTargetUPH.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblTargetUPH.Text = "1";
            this.lblTargetUPH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTargetUPH.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblTargetUPH.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblTargetUPH.Name = "lblTargetUPH";
            // 
            // btnTargetUPH
            // 
            this.btnTargetUPH.Location = new System.Drawing.Point(428, 122);
            this.btnTargetUPH.Size = new System.Drawing.Size(92, 30);
            this.btnTargetUPH.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTargetUPH.Text = "Set";
            this.btnTargetUPH.Name = "btnTargetUPH";
            this.btnTargetUPH.Click += new System.EventHandler(this.btnTargetUPH_Click);
            // 
            // lblAirTitle
            // 
            this.lblAirTitle.Location = new System.Drawing.Point(14, 186);
            this.lblAirTitle.Size = new System.Drawing.Size(300, 28);
            this.lblAirTitle.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAirTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblAirTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblAirTitle.Text = "Air Pressure (MPa)";
            this.lblAirTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAirTitle.Name = "lblAirTitle";
            // 
            // lblAir1Caption
            // 
            this.lblAir1Caption.Location = new System.Drawing.Point(14, 222);
            this.lblAir1Caption.Size = new System.Drawing.Size(160, 28);
            this.lblAir1Caption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAir1Caption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblAir1Caption.BackColor = System.Drawing.Color.Transparent;
            this.lblAir1Caption.Text = "Air 1";
            this.lblAir1Caption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAir1Caption.Name = "lblAir1Caption";
            // 
            // lblAir1
            // 
            this.lblAir1.Location = new System.Drawing.Point(14, 252);
            this.lblAir1.Size = new System.Drawing.Size(160, 40);
            this.lblAir1.Font = new System.Drawing.Font("Malgun Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAir1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblAir1.Text = "0.00";
            this.lblAir1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAir1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblAir1.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblAir1.Name = "lblAir1";
            // 
            // lblAir2Caption
            // 
            this.lblAir2Caption.Location = new System.Drawing.Point(186, 222);
            this.lblAir2Caption.Size = new System.Drawing.Size(160, 28);
            this.lblAir2Caption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAir2Caption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblAir2Caption.BackColor = System.Drawing.Color.Transparent;
            this.lblAir2Caption.Text = "Air 2";
            this.lblAir2Caption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAir2Caption.Name = "lblAir2Caption";
            // 
            // lblAir2
            // 
            this.lblAir2.Location = new System.Drawing.Point(186, 252);
            this.lblAir2.Size = new System.Drawing.Size(160, 40);
            this.lblAir2.Font = new System.Drawing.Font("Malgun Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAir2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblAir2.Text = "0.00";
            this.lblAir2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAir2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblAir2.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblAir2.Name = "lblAir2";
            // 
            // lblAir3Caption
            // 
            this.lblAir3Caption.Location = new System.Drawing.Point(358, 222);
            this.lblAir3Caption.Size = new System.Drawing.Size(160, 28);
            this.lblAir3Caption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAir3Caption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblAir3Caption.BackColor = System.Drawing.Color.Transparent;
            this.lblAir3Caption.Text = "Air 3";
            this.lblAir3Caption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblAir3Caption.Name = "lblAir3Caption";
            // 
            // lblAir3
            // 
            this.lblAir3.Location = new System.Drawing.Point(358, 252);
            this.lblAir3.Size = new System.Drawing.Size(160, 40);
            this.lblAir3.Font = new System.Drawing.Font("Malgun Gothic", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblAir3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblAir3.Text = "0.00";
            this.lblAir3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAir3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblAir3.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblAir3.Name = "lblAir3";
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
            this.pnlScanTrigger.Location = new System.Drawing.Point(552, 288);
            this.pnlScanTrigger.Size = new System.Drawing.Size(540, 610);
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
            this.lblScanTrigRate.Text = "-";
            this.lblScanTrigRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigRate.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
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
            this.lblScanTrigLines.Text = "-";
            this.lblScanTrigLines.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigLines.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigLines.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
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
            this.lblScanTrigTime.Text = "-";
            this.lblScanTrigTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigTime.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
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
            this.lblScanTrigCounts.Text = "-";
            this.lblScanTrigCounts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigCounts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigCounts.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
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
            this.lblScanTrigState.Text = "-";
            this.lblScanTrigState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigState.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigState.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
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
            this.lblScanTrigResult.Text = "-";
            this.lblScanTrigResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblScanTrigResult.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblScanTrigResult.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
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
            // pnlComm
            // 
            this.pnlComm.Controls.Add(this.tcAuto);
            this.pnlComm.Location = new System.Drawing.Point(1104, 288);
            this.pnlComm.Size = new System.Drawing.Size(540, 610);
            this.pnlComm.TitleText = "";
            this.pnlComm.Name = "pnlComm";
            // 
            // tcAuto
            // 
            this.tcAuto.Controls.Add(this.tcComm);
            this.tcAuto.Controls.Add(this.tcInspVision);
            this.tcAuto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcAuto.Size = new System.Drawing.Size(520, 590);
            this.tcAuto.Name = "tcAuto";
            this.tcAuto.DoubleClick += new System.EventHandler(this.spTabLaser_DoubleClick);
            // 
            // tcComm
            // 
            this.tcComm.Text = "Communication";
            this.tcComm.Padding = new System.Windows.Forms.Padding(4);
            this.tcComm.Size = new System.Drawing.Size(512, 546);
            this.tcComm.Name = "tcComm";
            // 
            // tcInspVision
            // 
            this.tcInspVision.Controls.Add(this.tcVision);
            this.tcInspVision.Text = "Vision";
            this.tcInspVision.Padding = new System.Windows.Forms.Padding(4);
            this.tcInspVision.Size = new System.Drawing.Size(512, 546);
            this.tcInspVision.Name = "tcInspVision";
            // 
            // tcVision
            // 
            this.tcVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcVision.Size = new System.Drawing.Size(504, 538);
            this.tcVision.Name = "tcVision";
            // 
            // tmRun
            // 
            this.tmRun.Enabled = true;
            this.tmRun.Interval = 1000;
            this.tmRun.Tick += new System.EventHandler(this.tmRun_Tick);
            // 
            // FormAuto1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1644, 900);
            this.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "FormAuto1";
            this.Controls.Add(this.pnlComm);
            this.Controls.Add(this.pnlScanTrigger);
            this.Controls.Add(this.pnlProduction);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlEquipState);
            this.Controls.Add(this.pnlLot);
            this.Controls.Add(this.pnlKpiUPH);
            this.Controls.Add(this.pnlKpiNG);
            this.Controls.Add(this.pnlKpiRework);
            this.Controls.Add(this.pnlKpiGood);
            this.Controls.Add(this.pnlKpiOut);
            this.Controls.Add(this.pnlKpiIn);
            this.Name = "FormAuto1";
            this.Shown += new System.EventHandler(this.FormAuto1_Shown);
            this.tcVision.ResumeLayout(false);
            this.tcInspVision.ResumeLayout(false);
            this.tcComm.ResumeLayout(false);
            this.tcAuto.ResumeLayout(false);
            this.pnlComm.ResumeLayout(false);
            this.pnlScanTrigger.ResumeLayout(false);
            this.pnlProduction.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlEquipState.ResumeLayout(false);
            this.pnlLot.ResumeLayout(false);
            this.pnlKpiUPH.ResumeLayout(false);
            this.pnlKpiNG.ResumeLayout(false);
            this.pnlKpiRework.ResumeLayout(false);
            this.pnlKpiGood.ResumeLayout(false);
            this.pnlKpiOut.ResumeLayout(false);
            this.pnlKpiIn.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MMI.HmiCard pnlKpiIn;
        public System.Windows.Forms.Label lblInCount;
        private MMI.HmiCard pnlKpiOut;
        public System.Windows.Forms.Label lblOutCount;
        private MMI.HmiCard pnlKpiGood;
        public System.Windows.Forms.Label lblGoodCount;
        private MMI.HmiCard pnlKpiRework;
        public System.Windows.Forms.Label lblReworkCount;
        private MMI.HmiCard pnlKpiNG;
        public System.Windows.Forms.Label lblNGCount;
        private MMI.HmiCard pnlKpiUPH;
        public System.Windows.Forms.Label lblUPH;
        private MMI.HmiCard pnlLot;
        private System.Windows.Forms.Label lblLotIdCaption;
        public System.Windows.Forms.Label lblLotID;
        private System.Windows.Forms.Label lblLotCountCaption;
        public System.Windows.Forms.Label lblLotCount;
        public MMI.HmiButton btnLOTInput;
        private MMI.HmiButton btnLotCancel;
        private MMI.HmiCard pnlEquipState;
        private System.Windows.Forms.Label lblStateRun;
        private System.Windows.Forms.Label lblStateStop;
        private System.Windows.Forms.Label lblStateAlarm;
        private System.Windows.Forms.Label lblRunTimeCaption;
        public System.Windows.Forms.Label lblRunningTime;
        private System.Windows.Forms.Label lblStopTimeCaption;
        public System.Windows.Forms.Label lblStopTime;
        private MMI.HmiCard pnlControl;
        private MMI.HmiButton btnSTART;
        private MMI.HmiButton btnSTOP;
        private MMI.HmiButton btnRESET;
        private MMI.HmiButton btnInit;
        private MMI.HmiButton btnLOTEnd;
        private MMI.HmiCard pnlProduction;
        private System.Windows.Forms.Label lblPanelInCaption;
        public System.Windows.Forms.Label lblPanelInCount;
        private System.Windows.Forms.Label lblRateCaption;
        public System.Windows.Forms.Label lblRate;
        private System.Windows.Forms.Label lblTargetUPHCaption;
        public System.Windows.Forms.Label lblTargetUPH;
        public MMI.HmiButton btnTargetUPH;
        private System.Windows.Forms.Label lblAirTitle;
        private System.Windows.Forms.Label lblAir1Caption;
        public System.Windows.Forms.Label lblAir1;
        private System.Windows.Forms.Label lblAir2Caption;
        public System.Windows.Forms.Label lblAir2;
        private System.Windows.Forms.Label lblAir3Caption;
        public System.Windows.Forms.Label lblAir3;
        public MMI.HmiCard pnlScanTrigger;
        public System.Windows.Forms.RadioButton rdoScanTrigPeriodic;
        public System.Windows.Forms.RadioButton rdoScanTrigTimer;
        public System.Windows.Forms.Label lblcapScanTrig5;
        public System.Windows.Forms.TextBox txtScanTrigMotionStart;
        public System.Windows.Forms.Label lblcapScanTrig0;
        public System.Windows.Forms.TextBox txtScanTrigStart;
        public System.Windows.Forms.Label lblcapScanTrig1;
        public System.Windows.Forms.TextBox txtScanTrigEnd;
        public System.Windows.Forms.Label lblcapScanTrig6;
        public System.Windows.Forms.TextBox txtScanTrigMotionEnd;
        public System.Windows.Forms.Label lblcapScanTrig2;
        public System.Windows.Forms.TextBox txtScanTrigPitch;
        public System.Windows.Forms.Label lblcapScanTrig3;
        public System.Windows.Forms.TextBox txtScanTrigSpeed;
        public System.Windows.Forms.Label lblcapScanTrig4;
        public System.Windows.Forms.TextBox txtScanTrigPulse;
        public System.Windows.Forms.Label lblcapScanTrigR0;
        public System.Windows.Forms.Label lblScanTrigRate;
        public System.Windows.Forms.Label lblcapScanTrigR1;
        public System.Windows.Forms.Label lblScanTrigLines;
        public System.Windows.Forms.Label lblcapScanTrigR2;
        public System.Windows.Forms.Label lblScanTrigTime;
        public System.Windows.Forms.Label lblcapScanTrigR3;
        public System.Windows.Forms.Label lblScanTrigCounts;
        public System.Windows.Forms.Label lblcapScanTrigR4;
        public System.Windows.Forms.Label lblScanTrigState;
        public System.Windows.Forms.Label lblcapScanTrigR5;
        public System.Windows.Forms.Label lblScanTrigResult;
        public MMI.HmiButton btnScanTrigSet;
        public MMI.HmiButton btnScanTrigStart;
        public MMI.HmiButton btnScanTrigStop;
        public MMI.HmiButton btnScanTrigTest;
        private MMI.HmiCard pnlComm;
        public MMI.HmiTabControl tcAuto;
        public System.Windows.Forms.TabPage tcComm;
        public System.Windows.Forms.TabPage tcInspVision;
        public System.Windows.Forms.Panel tcVision;
        private System.Windows.Forms.Timer tmRun;
    }
}
