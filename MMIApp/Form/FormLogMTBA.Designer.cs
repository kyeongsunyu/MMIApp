namespace MMI
{
    partial class FormLogMTBA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogMTBA));
            this.gdMTBA = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.gdMTBF = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.btnStartDate = new DevComponents.DotNetBar.ButtonX();
            this.btnEndDate = new DevComponents.DotNetBar.ButtonX();
            this.btnStartTime = new DevComponents.DotNetBar.ButtonX();
            this.btnEndTime = new DevComponents.DotNetBar.ButtonX();
            this.gdRunLog = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLogHistory = new DevComponents.DotNetBar.ButtonX();
            this.btnREFRESH = new DevComponents.DotNetBar.ButtonX();
            this.btnCLEAR = new DevComponents.DotNetBar.ButtonX();
            this.btnSAVE = new DevComponents.DotNetBar.ButtonX();
            this.rbOldDB = new System.Windows.Forms.RadioButton();
            this.rbNewDB = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdMTBA)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdMTBF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdRunLog)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdMTBA
            // 
            this.gdMTBA.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdMTBA.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdMTBA.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdMTBA.ColumnInfo = resources.GetString("gdMTBA.ColumnInfo");
            this.gdMTBA.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdMTBA.Location = new System.Drawing.Point(45, 24);
            this.gdMTBA.Name = "gdMTBA";
            this.gdMTBA.Rows.Count = 13;
            this.gdMTBA.Rows.DefaultSize = 25;
            this.gdMTBA.Rows.Fixed = 2;
            this.gdMTBA.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdMTBA.Size = new System.Drawing.Size(708, 331);
            this.gdMTBA.StyleInfo = resources.GetString("gdMTBA.StyleInfo");
            this.gdMTBA.TabIndex = 36;
            this.gdMTBA.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            // 
            // gdMTBF
            // 
            this.gdMTBF.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdMTBF.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdMTBF.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdMTBF.ColumnInfo = resources.GetString("gdMTBF.ColumnInfo");
            this.gdMTBF.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdMTBF.Location = new System.Drawing.Point(45, 370);
            this.gdMTBF.Name = "gdMTBF";
            this.gdMTBF.Rows.Count = 3;
            this.gdMTBF.Rows.DefaultSize = 25;
            this.gdMTBF.Rows.Fixed = 2;
            this.gdMTBF.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdMTBF.Size = new System.Drawing.Size(708, 394);
            this.gdMTBF.StyleInfo = resources.GetString("gdMTBF.StyleInfo");
            this.gdMTBF.TabIndex = 37;
            this.gdMTBF.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.Color.OliveDrab;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(776, 24);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(109, 32);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX1.TabIndex = 38;
            this.labelX1.Text = "START";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.Olive;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.Color.White;
            this.labelX2.Location = new System.Drawing.Point(776, 68);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(109, 32);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX2.TabIndex = 39;
            this.labelX2.Text = "END";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnStartDate
            // 
            this.btnStartDate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartDate.BackColor = System.Drawing.Color.Black;
            this.btnStartDate.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnStartDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartDate.Location = new System.Drawing.Point(891, 24);
            this.btnStartDate.Name = "btnStartDate";
            this.btnStartDate.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnStartDate.Size = new System.Drawing.Size(137, 32);
            this.btnStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStartDate.TabIndex = 40;
            this.btnStartDate.Tag = "1";
            this.btnStartDate.Text = "YYYY-MM-DD";
            this.btnStartDate.ThemeAware = true;
            this.btnStartDate.Click += new System.EventHandler(this.btnStartDate_Click);
            // 
            // btnEndDate
            // 
            this.btnEndDate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEndDate.BackColor = System.Drawing.Color.Black;
            this.btnEndDate.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnEndDate.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndDate.Location = new System.Drawing.Point(891, 68);
            this.btnEndDate.Name = "btnEndDate";
            this.btnEndDate.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnEndDate.Size = new System.Drawing.Size(137, 32);
            this.btnEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEndDate.TabIndex = 41;
            this.btnEndDate.Tag = "1";
            this.btnEndDate.Text = "YYYY-MM-DD";
            this.btnEndDate.ThemeAware = true;
            this.btnEndDate.Click += new System.EventHandler(this.btnEndDate_Click);
            // 
            // btnStartTime
            // 
            this.btnStartTime.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnStartTime.BackColor = System.Drawing.Color.Black;
            this.btnStartTime.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnStartTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStartTime.Location = new System.Drawing.Point(1038, 24);
            this.btnStartTime.Name = "btnStartTime";
            this.btnStartTime.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnStartTime.Size = new System.Drawing.Size(90, 32);
            this.btnStartTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnStartTime.TabIndex = 42;
            this.btnStartTime.Tag = "11";
            this.btnStartTime.Text = "00:00";
            this.btnStartTime.ThemeAware = true;
            this.btnStartTime.Click += new System.EventHandler(this.btnStartTime_Click);
            // 
            // btnEndTime
            // 
            this.btnEndTime.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEndTime.BackColor = System.Drawing.Color.Black;
            this.btnEndTime.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnEndTime.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEndTime.Location = new System.Drawing.Point(1038, 68);
            this.btnEndTime.Name = "btnEndTime";
            this.btnEndTime.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnEndTime.Size = new System.Drawing.Size(90, 32);
            this.btnEndTime.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEndTime.TabIndex = 43;
            this.btnEndTime.Tag = "11";
            this.btnEndTime.Text = "00:00";
            this.btnEndTime.ThemeAware = true;
            this.btnEndTime.Click += new System.EventHandler(this.btnEndTime_Click);
            // 
            // gdRunLog
            // 
            this.gdRunLog.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdRunLog.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdRunLog.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdRunLog.ColumnInfo = resources.GetString("gdRunLog.ColumnInfo");
            this.gdRunLog.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdRunLog.Location = new System.Drawing.Point(776, 124);
            this.gdRunLog.Name = "gdRunLog";
            this.gdRunLog.Rows.Count = 9;
            this.gdRunLog.Rows.DefaultSize = 25;
            this.gdRunLog.Rows.Fixed = 2;
            this.gdRunLog.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdRunLog.Size = new System.Drawing.Size(357, 229);
            this.gdRunLog.StyleInfo = resources.GetString("gdRunLog.StyleInfo");
            this.gdRunLog.TabIndex = 44;
            this.gdRunLog.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnLogHistory);
            this.panel1.Controls.Add(this.btnREFRESH);
            this.panel1.Controls.Add(this.btnCLEAR);
            this.panel1.Controls.Add(this.btnSAVE);
            this.panel1.Controls.Add(this.rbOldDB);
            this.panel1.Controls.Add(this.rbNewDB);
            this.panel1.Location = new System.Drawing.Point(776, 370);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(357, 394);
            this.panel1.TabIndex = 45;
            // 
            // btnLogHistory
            // 
            this.btnLogHistory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogHistory.BackColor = System.Drawing.Color.Black;
            this.btnLogHistory.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnLogHistory.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogHistory.Location = new System.Drawing.Point(38, 216);
            this.btnLogHistory.Name = "btnLogHistory";
            this.btnLogHistory.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnLogHistory.Size = new System.Drawing.Size(150, 66);
            this.btnLogHistory.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnLogHistory.TabIndex = 46;
            this.btnLogHistory.Tag = "1";
            this.btnLogHistory.Text = "LOG HISTORY";
            this.btnLogHistory.TextColor = System.Drawing.Color.White;
            this.btnLogHistory.ThemeAware = true;
            this.btnLogHistory.Click += new System.EventHandler(this.btnLogHistory_Click);
            // 
            // btnREFRESH
            // 
            this.btnREFRESH.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnREFRESH.BackColor = System.Drawing.Color.Black;
            this.btnREFRESH.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnREFRESH.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnREFRESH.Location = new System.Drawing.Point(38, 119);
            this.btnREFRESH.Name = "btnREFRESH";
            this.btnREFRESH.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnREFRESH.Size = new System.Drawing.Size(150, 66);
            this.btnREFRESH.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnREFRESH.TabIndex = 45;
            this.btnREFRESH.Tag = "1";
            this.btnREFRESH.Text = "REFRESH";
            this.btnREFRESH.TextColor = System.Drawing.Color.White;
            this.btnREFRESH.ThemeAware = true;
            this.btnREFRESH.Click += new System.EventHandler(this.btnREFRESH_Click);
            // 
            // btnCLEAR
            // 
            this.btnCLEAR.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCLEAR.BackColor = System.Drawing.Color.Black;
            this.btnCLEAR.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnCLEAR.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCLEAR.Location = new System.Drawing.Point(228, 119);
            this.btnCLEAR.Name = "btnCLEAR";
            this.btnCLEAR.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnCLEAR.Size = new System.Drawing.Size(93, 66);
            this.btnCLEAR.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnCLEAR.TabIndex = 44;
            this.btnCLEAR.Tag = "1";
            this.btnCLEAR.Text = "CLEAR";
            this.btnCLEAR.TextColor = System.Drawing.Color.White;
            this.btnCLEAR.ThemeAware = true;
            this.btnCLEAR.Click += new System.EventHandler(this.btnCLEAR_Click);
            // 
            // btnSAVE
            // 
            this.btnSAVE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSAVE.BackColor = System.Drawing.Color.Black;
            this.btnSAVE.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSAVE.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.Location = new System.Drawing.Point(228, 216);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSAVE.Size = new System.Drawing.Size(93, 66);
            this.btnSAVE.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnSAVE.TabIndex = 43;
            this.btnSAVE.Tag = "1";
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.TextColor = System.Drawing.Color.White;
            this.btnSAVE.ThemeAware = true;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // rbOldDB
            // 
            this.rbOldDB.AutoSize = true;
            this.rbOldDB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbOldDB.Location = new System.Drawing.Point(189, 35);
            this.rbOldDB.Name = "rbOldDB";
            this.rbOldDB.Size = new System.Drawing.Size(88, 23);
            this.rbOldDB.TabIndex = 1;
            this.rbOldDB.Text = "OLD DB";
            this.rbOldDB.UseVisualStyleBackColor = true;
            this.rbOldDB.Click += new System.EventHandler(this.rbOldDB_Click);
            // 
            // rbNewDB
            // 
            this.rbNewDB.AutoSize = true;
            this.rbNewDB.Checked = true;
            this.rbNewDB.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbNewDB.Location = new System.Drawing.Point(51, 35);
            this.rbNewDB.Name = "rbNewDB";
            this.rbNewDB.Size = new System.Drawing.Size(93, 23);
            this.rbNewDB.TabIndex = 0;
            this.rbNewDB.TabStop = true;
            this.rbNewDB.Text = "NEW DB";
            this.rbNewDB.UseVisualStyleBackColor = true;
            this.rbNewDB.Click += new System.EventHandler(this.rbNewDB_Click);
            // 
            // FormLogMTBA
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gdRunLog);
            this.Controls.Add(this.btnEndTime);
            this.Controls.Add(this.btnStartTime);
            this.Controls.Add(this.btnEndDate);
            this.Controls.Add(this.btnStartDate);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.gdMTBF);
            this.Controls.Add(this.gdMTBA);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogMTBA";
            this.Text = "FormLogMTBA";
            this.Load += new System.EventHandler(this.FormLogMTBA_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdMTBA)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdMTBF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdRunLog)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public C1.Win.C1FlexGrid.C1FlexGrid gdMTBA;
        public C1.Win.C1FlexGrid.C1FlexGrid gdMTBF;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        public DevComponents.DotNetBar.ButtonX btnStartDate;
        public DevComponents.DotNetBar.ButtonX btnEndDate;
        private DevComponents.DotNetBar.ButtonX btnStartTime;
        private DevComponents.DotNetBar.ButtonX btnEndTime;
        public C1.Win.C1FlexGrid.C1FlexGrid gdRunLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbOldDB;
        private System.Windows.Forms.RadioButton rbNewDB;
        private DevComponents.DotNetBar.ButtonX btnLogHistory;
        private DevComponents.DotNetBar.ButtonX btnREFRESH;
        private DevComponents.DotNetBar.ButtonX btnCLEAR;
        private DevComponents.DotNetBar.ButtonX btnSAVE;
    }
}