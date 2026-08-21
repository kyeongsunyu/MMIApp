namespace MMI
{
    partial class FormLogError
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogError));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.CalendarStart = new System.Windows.Forms.DateTimePicker();
            this.CalendaEnd = new System.Windows.Forms.DateTimePicker();
            this.gdErrorHistory = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.gdErrorCount = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnFind = new DevComponents.DotNetBar.ButtonX();
            this.btnSAVE = new DevComponents.DotNetBar.ButtonX();
            this.searchPanel = new C1.Win.C1FlexGrid.C1FlexGridSearchPanel();
            this.searchPanel2 = new C1.Win.C1FlexGrid.C1FlexGridSearchPanel();
            this.lblErrorName = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.gdErrorHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdErrorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
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
            this.labelX1.Location = new System.Drawing.Point(27, 23);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(74, 25);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "STRT :";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.BackgroundStyle.BackColor2 = System.Drawing.Color.CornflowerBlue;
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
            this.labelX2.Location = new System.Drawing.Point(294, 23);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(74, 25);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "END :";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // CalendarStart
            // 
            this.CalendarStart.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalendarStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CalendarStart.Location = new System.Drawing.Point(117, 22);
            this.CalendarStart.Name = "CalendarStart";
            this.CalendarStart.Size = new System.Drawing.Size(139, 26);
            this.CalendarStart.TabIndex = 415;
            this.CalendarStart.ValueChanged += new System.EventHandler(this.CalendarStart_ValueChanged);
            // 
            // CalendaEnd
            // 
            this.CalendaEnd.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalendaEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CalendaEnd.Location = new System.Drawing.Point(392, 22);
            this.CalendaEnd.Name = "CalendaEnd";
            this.CalendaEnd.Size = new System.Drawing.Size(139, 26);
            this.CalendaEnd.TabIndex = 416;
            this.CalendaEnd.ValueChanged += new System.EventHandler(this.CalendaEnd_ValueChanged);
            // 
            // gdErrorHistory
            // 
            this.gdErrorHistory.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdErrorHistory.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdErrorHistory.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.searchPanel.SetC1FlexGridSearchPanel(this.gdErrorHistory, this.searchPanel);
            this.gdErrorHistory.ColumnInfo = resources.GetString("gdErrorHistory.ColumnInfo");
            this.gdErrorHistory.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdErrorHistory.Location = new System.Drawing.Point(27, 64);
            this.gdErrorHistory.Name = "gdErrorHistory";
            this.gdErrorHistory.Rows.Count = 2;
            this.gdErrorHistory.Rows.DefaultSize = 22;
            this.gdErrorHistory.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdErrorHistory.Size = new System.Drawing.Size(1422, 297);
            this.gdErrorHistory.StyleInfo = resources.GetString("gdErrorHistory.StyleInfo");
            this.gdErrorHistory.TabIndex = 417;
            this.gdErrorHistory.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            // 
            // gdErrorCount
            // 
            this.gdErrorCount.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdErrorCount.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdErrorCount.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.searchPanel2.SetC1FlexGridSearchPanel(this.gdErrorCount, this.searchPanel2);
            this.gdErrorCount.ColumnInfo = resources.GetString("gdErrorCount.ColumnInfo");
            this.gdErrorCount.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdErrorCount.Location = new System.Drawing.Point(27, 398);
            this.gdErrorCount.Name = "gdErrorCount";
            this.gdErrorCount.Rows.Count = 102;
            this.gdErrorCount.Rows.DefaultSize = 22;
            this.gdErrorCount.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdErrorCount.Size = new System.Drawing.Size(982, 422);
            this.gdErrorCount.StyleInfo = resources.GetString("gdErrorCount.StyleInfo");
            this.gdErrorCount.TabIndex = 418;
            this.gdErrorCount.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            this.gdErrorCount.Click += new System.EventHandler(this.gdErrorCount_Click);
            // 
            // chart
            // 
            chartArea1.Area3DStyle.Enable3D = true;
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(1022, 398);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.CustomProperties = "PieStartAngle=270";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(427, 422);
            this.chart.TabIndex = 419;
            this.chart.Text = "chart1";
            title1.Name = "Title1";
            title1.Text = "Error Count TOP5";
            this.chart.Titles.Add(title1);
            // 
            // btnFind
            // 
            this.btnFind.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnFind.BackColor = System.Drawing.Color.Black;
            this.btnFind.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnFind.Location = new System.Drawing.Point(887, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnFind.Size = new System.Drawing.Size(80, 26);
            this.btnFind.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnFind.TabIndex = 420;
            this.btnFind.Tag = "1";
            this.btnFind.Text = "Find";
            this.btnFind.ThemeAware = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnSAVE
            // 
            this.btnSAVE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSAVE.BackColor = System.Drawing.Color.Black;
            this.btnSAVE.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnSAVE.Location = new System.Drawing.Point(1020, 22);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSAVE.Size = new System.Drawing.Size(80, 26);
            this.btnSAVE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSAVE.TabIndex = 421;
            this.btnSAVE.Tag = "1";
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.ThemeAware = true;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // searchPanel
            // 
            this.searchPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchPanel.Location = new System.Drawing.Point(27, 350);
            this.searchPanel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always;
            this.searchPanel.ShowClearButton = false;
            this.searchPanel.ShowSearchButton = false;
            this.searchPanel.Size = new System.Drawing.Size(224, 42);
            this.searchPanel.TabIndex = 422;
            this.searchPanel.Watermark = "Input Searching ...";
            // 
            // searchPanel2
            // 
            this.searchPanel2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchPanel2.Location = new System.Drawing.Point(18, 832);
            this.searchPanel2.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            this.searchPanel2.Name = "searchPanel2";
            this.searchPanel2.SearchMode = C1.Win.C1FlexGrid.SearchMode.Always;
            this.searchPanel2.ShowClearButton = false;
            this.searchPanel2.ShowSearchButton = false;
            this.searchPanel2.Size = new System.Drawing.Size(224, 42);
            this.searchPanel2.TabIndex = 423;
            this.searchPanel2.Watermark = "Input Searching ...";
            // 
            // lblErrorName
            // 
            this.lblErrorName.BackColor = System.Drawing.SystemColors.Highlight;
            // 
            // 
            // 
            this.lblErrorName.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblErrorName.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorName.ForeColor = System.Drawing.Color.White;
            this.lblErrorName.Location = new System.Drawing.Point(357, 844);
            this.lblErrorName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblErrorName.Name = "lblErrorName";
            this.lblErrorName.Size = new System.Drawing.Size(643, 30);
            this.lblErrorName.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.lblErrorName.TabIndex = 424;
            this.lblErrorName.Text = "ERROR NAME";
            // 
            // FormLogError
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.lblErrorName);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.gdErrorCount);
            this.Controls.Add(this.gdErrorHistory);
            this.Controls.Add(this.CalendaEnd);
            this.Controls.Add(this.CalendarStart);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.searchPanel);
            this.Controls.Add(this.searchPanel2);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogError";
            this.Load += new System.EventHandler(this.FormLogError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdErrorHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdErrorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private System.Windows.Forms.DateTimePicker CalendarStart;
        private System.Windows.Forms.DateTimePicker CalendaEnd;
        public C1.Win.C1FlexGrid.C1FlexGrid gdErrorHistory;
        public C1.Win.C1FlexGrid.C1FlexGrid gdErrorCount;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private DevComponents.DotNetBar.ButtonX btnFind;
        private DevComponents.DotNetBar.ButtonX btnSAVE;
        private C1.Win.C1FlexGrid.C1FlexGridSearchPanel searchPanel;
        private C1.Win.C1FlexGrid.C1FlexGridSearchPanel searchPanel2;
        private DevComponents.DotNetBar.LabelX lblErrorName;
    }
}