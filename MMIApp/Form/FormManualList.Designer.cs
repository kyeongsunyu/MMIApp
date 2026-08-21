using C1.Win.C1FlexGrid;

namespace MMI
{
    partial class FormManualList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormManualList));
            this.gdTenKeySection = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.gdTenKey = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gdTenKeySection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdTenKey)).BeginInit();
            this.SuspendLayout();
            // 
            // gdTenKeySection
            // 
            this.gdTenKeySection.ColumnInfo = resources.GetString("gdTenKeySection.ColumnInfo");
            this.gdTenKeySection.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gdTenKeySection.Location = new System.Drawing.Point(73, 37);
            this.gdTenKeySection.Name = "gdTenKeySection";
            this.gdTenKeySection.Rows.Count = 21;
            this.gdTenKeySection.Rows.DefaultSize = 30;
            this.gdTenKeySection.Size = new System.Drawing.Size(548, 635);
            this.gdTenKeySection.StyleInfo = resources.GetString("gdTenKeySection.StyleInfo");
            this.gdTenKeySection.TabIndex = 2;
            this.gdTenKeySection.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            this.gdTenKeySection.Click += new System.EventHandler(this.gdTenKeySection_Click);
            // 
            // gdTenKey
            // 
            this.gdTenKey.AllowEditing = false;
            this.gdTenKey.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdTenKey.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdTenKey.ColumnInfo = resources.GetString("gdTenKey.ColumnInfo");
            this.gdTenKey.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gdTenKey.Location = new System.Drawing.Point(714, 37);
            this.gdTenKey.Name = "gdTenKey";
            this.gdTenKey.Rows.Count = 21;
            this.gdTenKey.Rows.DefaultSize = 30;
            this.gdTenKey.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdTenKey.Size = new System.Drawing.Size(665, 635);
            this.gdTenKey.StyleInfo = resources.GetString("gdTenKey.StyleInfo");
            this.gdTenKey.TabIndex = 3;
            this.gdTenKey.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.gdTenKey.Paint += new System.Windows.Forms.PaintEventHandler(this.gdTenKey_Paint);
            this.gdTenKey.DoubleClick += new System.EventHandler(this.gdTenKey_DoubleClick);
            // 
            // FormManualList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.gdTenKey);
            this.Controls.Add(this.gdTenKeySection);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormManualList";
            this.Load += new System.EventHandler(this.FormManualList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdTenKeySection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdTenKey)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private C1.Win.C1FlexGrid.C1FlexGrid gdTenKeySection;
        private C1.Win.C1FlexGrid.C1FlexGrid gdTenKey;
    }
}