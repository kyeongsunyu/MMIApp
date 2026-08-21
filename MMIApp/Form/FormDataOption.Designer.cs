namespace MMI
{
    partial class FormDataOption
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataOption));
            this.gdOption = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnSAVE = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.gdOption)).BeginInit();
            this.SuspendLayout();
            // 
            // gdOption
            // 
            this.gdOption.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdOption.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdOption.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdOption.ColumnInfo = resources.GetString("gdOption.ColumnInfo");
            this.gdOption.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdOption.Location = new System.Drawing.Point(59, 32);
            this.gdOption.Name = "gdOption";
            this.gdOption.Rows.Count = 34;
            this.gdOption.Rows.DefaultSize = 25;
            this.gdOption.Rows.Fixed = 2;
            this.gdOption.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdOption.Size = new System.Drawing.Size(1263, 855);
            this.gdOption.StyleInfo = resources.GetString("gdOption.StyleInfo");
            this.gdOption.TabIndex = 35;
            this.gdOption.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            this.gdOption.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gdOption_AfterEdit);
            this.gdOption.DoubleClick += new System.EventHandler(this.gdOption_DoubleClick);
            // 
            // btnSAVE
            // 
            this.btnSAVE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSAVE.BackColor = System.Drawing.Color.Black;
            this.btnSAVE.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnSAVE.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.Location = new System.Drawing.Point(1328, 815);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSAVE.Size = new System.Drawing.Size(140, 72);
            this.btnSAVE.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSAVE.TabIndex = 37;
            this.btnSAVE.Tag = "2";
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.ThemeAware = true;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.BackColor = System.Drawing.Color.Black;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnEdit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(1328, 737);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnEdit.Size = new System.Drawing.Size(140, 72);
            this.btnEdit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnEdit.TabIndex = 36;
            this.btnEdit.Tag = "1";
            this.btnEdit.Text = "ITEM EDIT";
            this.btnEdit.ThemeAware = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // FormDataOption
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.gdOption);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDataOption";
            this.Text = "FormDataOption";
            this.Load += new System.EventHandler(this.FormDataOption_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormDataOption_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gdOption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public C1.Win.C1FlexGrid.C1FlexGrid gdOption;
        private DevComponents.DotNetBar.ButtonX btnSAVE;
        private DevComponents.DotNetBar.ButtonX btnEdit;
    }
}