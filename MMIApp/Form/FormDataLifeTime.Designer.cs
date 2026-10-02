namespace MMI
{
    partial class FormDataLifeTime
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
            this.pnlList = new MMI.HmiCard();
            this.dgvLifeTime = new System.Windows.Forms.DataGridView();
            this.pnlSelected = new MMI.HmiCard();
            this.lblSelNameCaption = new System.Windows.Forms.Label();
            this.lblSelName = new System.Windows.Forms.Label();
            this.lblSelLimitCaption = new System.Windows.Forms.Label();
            this.lblSelLimit = new System.Windows.Forms.Label();
            this.lblSelCurrentCaption = new System.Windows.Forms.Label();
            this.lblSelCurrent = new System.Windows.Forms.Label();
            this.lblSelRemainCaption = new System.Windows.Forms.Label();
            this.lblSelRemain = new System.Windows.Forms.Label();
            this.lblSelUseCaption = new System.Windows.Forms.Label();
            this.lblSelUse = new System.Windows.Forms.Label();
            this.lblSelDmCaption = new System.Windows.Forms.Label();
            this.lblSelDm = new System.Windows.Forms.Label();
            this.btnSetLimit = new MMI.HmiButton();
            this.btnResetCount = new MMI.HmiButton();
            this.lblSelHint = new System.Windows.Forms.Label();
            this.pnlSummary = new MMI.HmiCard();
            this.lblSumOverCaption = new System.Windows.Forms.Label();
            this.lblSumOver = new System.Windows.Forms.Label();
            this.lblSumWarnCaption = new System.Windows.Forms.Label();
            this.lblSumWarn = new System.Windows.Forms.Label();
            this.lblSumStagedCaption = new System.Windows.Forms.Label();
            this.lblSumStaged = new System.Windows.Forms.Label();
            this.lblWarnRule = new System.Windows.Forms.Label();
            this.pnlActions = new MMI.HmiCard();
            this.btnApply = new MMI.HmiButton();
            this.btnCancel = new MMI.HmiButton();
            this.btnReload = new MMI.HmiButton();
            this.lblResult = new System.Windows.Forms.Label();
            this.tmUpdate = new System.Windows.Forms.Timer(this.components);
            this.pnlList.SuspendLayout();
            this.pnlSelected.SuspendLayout();
            this.pnlSummary.SuspendLayout();
            this.pnlActions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLifeTime)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlList
            // 
            this.pnlList.Controls.Add(this.dgvLifeTime);
            this.pnlList.Location = new System.Drawing.Point(0, 0);
            this.pnlList.Size = new System.Drawing.Size(1100, 900);
            this.pnlList.TitleText = "Life Time Items";
            this.pnlList.Name = "pnlList";
            // 
            // dgvLifeTime
            // 
            this.dgvLifeTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLifeTime.Size = new System.Drawing.Size(1080, 850);
            this.dgvLifeTime.AllowUserToAddRows = false;
            this.dgvLifeTime.AllowUserToDeleteRows = false;
            this.dgvLifeTime.AllowUserToResizeRows = false;
            this.dgvLifeTime.AllowUserToResizeColumns = false;
            this.dgvLifeTime.MultiSelect = false;
            this.dgvLifeTime.ReadOnly = true;
            this.dgvLifeTime.RowHeadersVisible = false;
            this.dgvLifeTime.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLifeTime.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvLifeTime.Name = "dgvLifeTime";
            this.dgvLifeTime.SelectionChanged += new System.EventHandler(this.dgvLifeTime_SelectionChanged);
            this.dgvLifeTime.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgvLifeTime_CellPainting);
            // 
            // pnlSelected
            // 
            this.pnlSelected.Controls.Add(this.lblSelHint);
            this.pnlSelected.Controls.Add(this.btnResetCount);
            this.pnlSelected.Controls.Add(this.btnSetLimit);
            this.pnlSelected.Controls.Add(this.lblSelDm);
            this.pnlSelected.Controls.Add(this.lblSelDmCaption);
            this.pnlSelected.Controls.Add(this.lblSelUse);
            this.pnlSelected.Controls.Add(this.lblSelUseCaption);
            this.pnlSelected.Controls.Add(this.lblSelRemain);
            this.pnlSelected.Controls.Add(this.lblSelRemainCaption);
            this.pnlSelected.Controls.Add(this.lblSelCurrent);
            this.pnlSelected.Controls.Add(this.lblSelCurrentCaption);
            this.pnlSelected.Controls.Add(this.lblSelLimit);
            this.pnlSelected.Controls.Add(this.lblSelLimitCaption);
            this.pnlSelected.Controls.Add(this.lblSelName);
            this.pnlSelected.Controls.Add(this.lblSelNameCaption);
            this.pnlSelected.Location = new System.Drawing.Point(1112, 0);
            this.pnlSelected.Size = new System.Drawing.Size(532, 420);
            this.pnlSelected.TitleText = "Selected Item";
            this.pnlSelected.Name = "pnlSelected";
            // 
            // lblSelNameCaption
            // 
            this.lblSelNameCaption.Location = new System.Drawing.Point(16, 44);
            this.lblSelNameCaption.Size = new System.Drawing.Size(120, 30);
            this.lblSelNameCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelNameCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSelNameCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSelNameCaption.Text = "Item";
            this.lblSelNameCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelNameCaption.Name = "lblSelNameCaption";
            // 
            // lblSelName
            // 
            this.lblSelName.Location = new System.Drawing.Point(140, 44);
            this.lblSelName.Size = new System.Drawing.Size(374, 30);
            this.lblSelName.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSelName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblSelName.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblSelName.Text = "-";
            this.lblSelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelName.Name = "lblSelName";
            // 
            // lblSelLimitCaption
            // 
            this.lblSelLimitCaption.Location = new System.Drawing.Point(16, 82);
            this.lblSelLimitCaption.Size = new System.Drawing.Size(120, 30);
            this.lblSelLimitCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelLimitCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSelLimitCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSelLimitCaption.Text = "Limit";
            this.lblSelLimitCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelLimitCaption.Name = "lblSelLimitCaption";
            // 
            // lblSelLimit
            // 
            this.lblSelLimit.Location = new System.Drawing.Point(140, 82);
            this.lblSelLimit.Size = new System.Drawing.Size(374, 30);
            this.lblSelLimit.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelLimit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSelLimit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblSelLimit.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblSelLimit.Text = "-";
            this.lblSelLimit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSelLimit.Name = "lblSelLimit";
            // 
            // lblSelCurrentCaption
            // 
            this.lblSelCurrentCaption.Location = new System.Drawing.Point(16, 120);
            this.lblSelCurrentCaption.Size = new System.Drawing.Size(120, 30);
            this.lblSelCurrentCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelCurrentCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSelCurrentCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSelCurrentCaption.Text = "Current";
            this.lblSelCurrentCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelCurrentCaption.Name = "lblSelCurrentCaption";
            // 
            // lblSelCurrent
            // 
            this.lblSelCurrent.Location = new System.Drawing.Point(140, 120);
            this.lblSelCurrent.Size = new System.Drawing.Size(374, 30);
            this.lblSelCurrent.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelCurrent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSelCurrent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblSelCurrent.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblSelCurrent.Text = "-";
            this.lblSelCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSelCurrent.Name = "lblSelCurrent";
            // 
            // lblSelRemainCaption
            // 
            this.lblSelRemainCaption.Location = new System.Drawing.Point(16, 158);
            this.lblSelRemainCaption.Size = new System.Drawing.Size(120, 30);
            this.lblSelRemainCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelRemainCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSelRemainCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSelRemainCaption.Text = "Remain";
            this.lblSelRemainCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelRemainCaption.Name = "lblSelRemainCaption";
            // 
            // lblSelRemain
            // 
            this.lblSelRemain.Location = new System.Drawing.Point(140, 158);
            this.lblSelRemain.Size = new System.Drawing.Size(374, 30);
            this.lblSelRemain.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelRemain.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSelRemain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblSelRemain.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblSelRemain.Text = "-";
            this.lblSelRemain.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSelRemain.Name = "lblSelRemain";
            // 
            // lblSelUseCaption
            // 
            this.lblSelUseCaption.Location = new System.Drawing.Point(16, 196);
            this.lblSelUseCaption.Size = new System.Drawing.Size(120, 30);
            this.lblSelUseCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelUseCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSelUseCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSelUseCaption.Text = "Use";
            this.lblSelUseCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelUseCaption.Name = "lblSelUseCaption";
            // 
            // lblSelUse
            // 
            this.lblSelUse.Location = new System.Drawing.Point(140, 196);
            this.lblSelUse.Size = new System.Drawing.Size(374, 30);
            this.lblSelUse.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelUse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSelUse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblSelUse.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblSelUse.Text = "-";
            this.lblSelUse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSelUse.Name = "lblSelUse";
            // 
            // lblSelDmCaption
            // 
            this.lblSelDmCaption.Location = new System.Drawing.Point(16, 234);
            this.lblSelDmCaption.Size = new System.Drawing.Size(120, 30);
            this.lblSelDmCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelDmCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSelDmCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSelDmCaption.Text = "Address";
            this.lblSelDmCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelDmCaption.Name = "lblSelDmCaption";
            // 
            // lblSelDm
            // 
            this.lblSelDm.Location = new System.Drawing.Point(140, 234);
            this.lblSelDm.Size = new System.Drawing.Size(374, 30);
            this.lblSelDm.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelDm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSelDm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblSelDm.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblSelDm.Text = "-";
            this.lblSelDm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblSelDm.Name = "lblSelDm";
            // 
            // btnSetLimit
            // 
            this.btnSetLimit.Location = new System.Drawing.Point(16, 290);
            this.btnSetLimit.Size = new System.Drawing.Size(240, 56);
            this.btnSetLimit.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSetLimit.Text = "SET LIMIT";
            this.btnSetLimit.Name = "btnSetLimit";
            this.btnSetLimit.Click += new System.EventHandler(this.btnSetLimit_Click);
            // 
            // btnResetCount
            // 
            this.btnResetCount.Location = new System.Drawing.Point(274, 290);
            this.btnResetCount.Size = new System.Drawing.Size(240, 56);
            this.btnResetCount.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnResetCount.Text = "RESET COUNT";
            this.btnResetCount.Role = MMI.HmiButtonRole.Warning;
            this.btnResetCount.Name = "btnResetCount";
            this.btnResetCount.Click += new System.EventHandler(this.btnResetCount_Click);
            // 
            // lblSelHint
            // 
            this.lblSelHint.Location = new System.Drawing.Point(16, 356);
            this.lblSelHint.Size = new System.Drawing.Size(498, 30);
            this.lblSelHint.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSelHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSelHint.BackColor = System.Drawing.Color.Transparent;
            this.lblSelHint.Text = "RESET COUNT after the part has been replaced.";
            this.lblSelHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSelHint.Name = "lblSelHint";
            // 
            // pnlSummary
            // 
            this.pnlSummary.Controls.Add(this.lblWarnRule);
            this.pnlSummary.Controls.Add(this.lblSumStaged);
            this.pnlSummary.Controls.Add(this.lblSumStagedCaption);
            this.pnlSummary.Controls.Add(this.lblSumWarn);
            this.pnlSummary.Controls.Add(this.lblSumWarnCaption);
            this.pnlSummary.Controls.Add(this.lblSumOver);
            this.pnlSummary.Controls.Add(this.lblSumOverCaption);
            this.pnlSummary.Location = new System.Drawing.Point(1112, 432);
            this.pnlSummary.Size = new System.Drawing.Size(532, 250);
            this.pnlSummary.TitleText = "Summary";
            this.pnlSummary.Name = "pnlSummary";
            // 
            // lblSumOverCaption
            // 
            this.lblSumOverCaption.Location = new System.Drawing.Point(16, 44);
            this.lblSumOverCaption.Size = new System.Drawing.Size(160, 30);
            this.lblSumOverCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSumOverCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSumOverCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSumOverCaption.Text = "Over limit";
            this.lblSumOverCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSumOverCaption.Name = "lblSumOverCaption";
            // 
            // lblSumOver
            // 
            this.lblSumOver.Location = new System.Drawing.Point(16, 76);
            this.lblSumOver.Size = new System.Drawing.Size(160, 56);
            this.lblSumOver.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSumOver.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSumOver.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblSumOver.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblSumOver.Text = "0";
            this.lblSumOver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSumOver.Name = "lblSumOver";
            // 
            // lblSumWarnCaption
            // 
            this.lblSumWarnCaption.Location = new System.Drawing.Point(184, 44);
            this.lblSumWarnCaption.Size = new System.Drawing.Size(160, 30);
            this.lblSumWarnCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSumWarnCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSumWarnCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSumWarnCaption.Text = "Warning";
            this.lblSumWarnCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSumWarnCaption.Name = "lblSumWarnCaption";
            // 
            // lblSumWarn
            // 
            this.lblSumWarn.Location = new System.Drawing.Point(184, 76);
            this.lblSumWarn.Size = new System.Drawing.Size(160, 56);
            this.lblSumWarn.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSumWarn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSumWarn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblSumWarn.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblSumWarn.Text = "0";
            this.lblSumWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSumWarn.Name = "lblSumWarn";
            // 
            // lblSumStagedCaption
            // 
            this.lblSumStagedCaption.Location = new System.Drawing.Point(352, 44);
            this.lblSumStagedCaption.Size = new System.Drawing.Size(160, 30);
            this.lblSumStagedCaption.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSumStagedCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblSumStagedCaption.BackColor = System.Drawing.Color.Transparent;
            this.lblSumStagedCaption.Text = "Not applied";
            this.lblSumStagedCaption.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblSumStagedCaption.Name = "lblSumStagedCaption";
            // 
            // lblSumStaged
            // 
            this.lblSumStaged.Location = new System.Drawing.Point(352, 76);
            this.lblSumStaged.Size = new System.Drawing.Size(160, 56);
            this.lblSumStaged.Font = new System.Drawing.Font("Malgun Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblSumStaged.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblSumStaged.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.lblSumStaged.Padding = new System.Windows.Forms.Padding(0, 0, 6, 0);
            this.lblSumStaged.Text = "0";
            this.lblSumStaged.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSumStaged.Name = "lblSumStaged";
            // 
            // lblWarnRule
            // 
            this.lblWarnRule.Location = new System.Drawing.Point(16, 150);
            this.lblWarnRule.Size = new System.Drawing.Size(498, 60);
            this.lblWarnRule.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblWarnRule.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblWarnRule.BackColor = System.Drawing.Color.Transparent;
            this.lblWarnRule.Text = "";
            this.lblWarnRule.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblWarnRule.Name = "lblWarnRule";
            // 
            // pnlActions
            // 
            this.pnlActions.Controls.Add(this.lblResult);
            this.pnlActions.Controls.Add(this.btnReload);
            this.pnlActions.Controls.Add(this.btnCancel);
            this.pnlActions.Controls.Add(this.btnApply);
            this.pnlActions.Location = new System.Drawing.Point(1112, 694);
            this.pnlActions.Size = new System.Drawing.Size(532, 206);
            this.pnlActions.TitleText = "Save";
            this.pnlActions.Name = "pnlActions";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(16, 44);
            this.btnApply.Size = new System.Drawing.Size(240, 56);
            this.btnApply.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnApply.Text = "APPLY";
            this.btnApply.Role = MMI.HmiButtonRole.Primary;
            this.btnApply.Name = "btnApply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(274, 44);
            this.btnCancel.Size = new System.Drawing.Size(116, 56);
            this.btnCancel.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReload
            // 
            this.btnReload.Location = new System.Drawing.Point(398, 44);
            this.btnReload.Size = new System.Drawing.Size(116, 56);
            this.btnReload.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnReload.Text = "RELOAD";
            this.btnReload.Name = "btnReload";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // lblResult
            // 
            this.lblResult.Location = new System.Drawing.Point(16, 112);
            this.lblResult.Size = new System.Drawing.Size(498, 60);
            this.lblResult.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblResult.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblResult.BackColor = System.Drawing.Color.Transparent;
            this.lblResult.Text = "";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblResult.Name = "lblResult";
            // 
            // tmUpdate
            // 
            this.tmUpdate.Interval = 500;
            this.tmUpdate.Tick += new System.EventHandler(this.tmUpdate_Tick);
            // 
            // FormDataLifeTime
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1644, 900);
            this.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "FormDataLifeTime";
            this.Controls.Add(this.pnlActions);
            this.Controls.Add(this.pnlSummary);
            this.Controls.Add(this.pnlSelected);
            this.Controls.Add(this.pnlList);
            this.Name = "FormDataLifeTime";
            this.Load += new System.EventHandler(this.FormDataLifeTime_Load);
            this.VisibleChanged += new System.EventHandler(this.FormDataLifeTime_VisibleChanged);
            this.pnlActions.ResumeLayout(false);
            this.pnlSummary.ResumeLayout(false);
            this.pnlSelected.ResumeLayout(false);
            this.pnlList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLifeTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MMI.HmiCard pnlList;
        private System.Windows.Forms.DataGridView dgvLifeTime;
        private MMI.HmiCard pnlSelected;
        private System.Windows.Forms.Label lblSelNameCaption;
        private System.Windows.Forms.Label lblSelName;
        private System.Windows.Forms.Label lblSelLimitCaption;
        private System.Windows.Forms.Label lblSelLimit;
        private System.Windows.Forms.Label lblSelCurrentCaption;
        private System.Windows.Forms.Label lblSelCurrent;
        private System.Windows.Forms.Label lblSelRemainCaption;
        private System.Windows.Forms.Label lblSelRemain;
        private System.Windows.Forms.Label lblSelUseCaption;
        private System.Windows.Forms.Label lblSelUse;
        private System.Windows.Forms.Label lblSelDmCaption;
        private System.Windows.Forms.Label lblSelDm;
        private MMI.HmiButton btnSetLimit;
        private MMI.HmiButton btnResetCount;
        private System.Windows.Forms.Label lblSelHint;
        private MMI.HmiCard pnlSummary;
        private System.Windows.Forms.Label lblSumOverCaption;
        private System.Windows.Forms.Label lblSumOver;
        private System.Windows.Forms.Label lblSumWarnCaption;
        private System.Windows.Forms.Label lblSumWarn;
        private System.Windows.Forms.Label lblSumStagedCaption;
        private System.Windows.Forms.Label lblSumStaged;
        private System.Windows.Forms.Label lblWarnRule;
        private MMI.HmiCard pnlActions;
        private MMI.HmiButton btnApply;
        private MMI.HmiButton btnCancel;
        private MMI.HmiButton btnReload;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Timer tmUpdate;
    }
}
