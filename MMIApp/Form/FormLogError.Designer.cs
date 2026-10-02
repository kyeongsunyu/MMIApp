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
            this.labelX1 = new System.Windows.Forms.Label();
            this.labelX2 = new System.Windows.Forms.Label();
            this.CalendarStart = new System.Windows.Forms.DateTimePicker();
            this.CalendaEnd = new System.Windows.Forms.DateTimePicker();
            this.gdErrorHistory = new MMI.HmiGrid();
            this.gdErrorCount = new MMI.HmiGrid();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btnFind = new MMI.HmiButton();
            this.btnSAVE = new MMI.HmiButton();
            this.lblErrorName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gdErrorHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdErrorCount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(27, 23);
            this.labelX1.Name = "labelX1";
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.labelX1.Size = new System.Drawing.Size(74, 25);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "STRT :";
            this.labelX1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(294, 23);
            this.labelX2.Name = "labelX2";
            this.labelX2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.labelX2.Size = new System.Drawing.Size(74, 25);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "END :";
            this.labelX2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CalendarStart
            // 
            this.CalendarStart.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalendarStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CalendarStart.Location = new System.Drawing.Point(117, 22);
            this.CalendarStart.Name = "CalendarStart";
            this.CalendarStart.Size = new System.Drawing.Size(139, 26);
            this.CalendarStart.TabIndex = 415;
            this.CalendarStart.ValueChanged += new System.EventHandler(this.CalendarStart_ValueChanged);
            // 
            // CalendaEnd
            // 
            this.CalendaEnd.Font = new System.Drawing.Font("Malgun Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalendaEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.CalendaEnd.Location = new System.Drawing.Point(392, 22);
            this.CalendaEnd.Name = "CalendaEnd";
            this.CalendaEnd.Size = new System.Drawing.Size(139, 26);
            this.CalendaEnd.TabIndex = 416;
            this.CalendaEnd.ValueChanged += new System.EventHandler(this.CalendaEnd_ValueChanged);
            // 
            // gdErrorHistory
            // 
            this.gdErrorHistory.ColumnInfo = resources.GetString("gdErrorHistory.ColumnInfo");
            this.gdErrorHistory.Location = new System.Drawing.Point(27, 64);
            this.gdErrorHistory.Name = "gdErrorHistory";
            this.gdErrorHistory.Rows.Count = 2;
            this.gdErrorHistory.Rows.DefaultSize = 22;
            this.gdErrorHistory.Size = new System.Drawing.Size(1422, 297);
            this.gdErrorHistory.TabIndex = 417;
            // 
            // gdErrorCount
            // 
            this.gdErrorCount.ColumnInfo = resources.GetString("gdErrorCount.ColumnInfo");
            this.gdErrorCount.Location = new System.Drawing.Point(27, 398);
            this.gdErrorCount.Name = "gdErrorCount";
            this.gdErrorCount.Rows.Count = 102;
            this.gdErrorCount.Rows.DefaultSize = 22;
            this.gdErrorCount.Size = new System.Drawing.Size(982, 422);
            this.gdErrorCount.TabIndex = 418;
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
            this.btnFind.Location = new System.Drawing.Point(887, 22);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(80, 26);
            this.btnFind.TabIndex = 420;
            this.btnFind.Tag = "1";
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnSAVE
            // 
            this.btnSAVE.Location = new System.Drawing.Point(1020, 22);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(80, 26);
            this.btnSAVE.TabIndex = 421;
            this.btnSAVE.Tag = "1";
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // searchPanel
            // 
            // 
            // searchPanel2
            // 
            // 
            // lblErrorName
            // 
            this.lblErrorName.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorName.Location = new System.Drawing.Point(357, 844);
            this.lblErrorName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblErrorName.Name = "lblErrorName";
            this.lblErrorName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblErrorName.Size = new System.Drawing.Size(643, 30);
            this.lblErrorName.TabIndex = 424;
            this.lblErrorName.Text = "ERROR NAME";
            // 
            // FormLogError
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
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
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogError";
            this.Load += new System.EventHandler(this.FormLogError_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdErrorHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdErrorCount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label labelX1;
        private System.Windows.Forms.Label labelX2;
        private System.Windows.Forms.DateTimePicker CalendarStart;
        private System.Windows.Forms.DateTimePicker CalendaEnd;
        public MMI.HmiGrid gdErrorHistory;
        public MMI.HmiGrid gdErrorCount;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private MMI.HmiButton btnFind;
        private MMI.HmiButton btnSAVE;
        private System.Windows.Forms.Label lblErrorName;
    }
}