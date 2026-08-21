namespace MMI
{
    partial class FormDataMotorCFG
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataMotorCFG));
            this.gdMotorCFG = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnSave = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.gdMotorCFG)).BeginInit();
            this.SuspendLayout();
            // 
            // gdMotorCFG
            // 
            this.gdMotorCFG.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdMotorCFG.ColumnInfo = resources.GetString("gdMotorCFG.ColumnInfo");
            this.gdMotorCFG.Location = new System.Drawing.Point(59, 32);
            this.gdMotorCFG.Name = "gdMotorCFG";
            this.gdMotorCFG.Rows.Count = 62;
            this.gdMotorCFG.Rows.DefaultSize = 25;
            this.gdMotorCFG.Rows.Fixed = 2;
            this.gdMotorCFG.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdMotorCFG.Size = new System.Drawing.Size(1225, 880);
            this.gdMotorCFG.StyleInfo = resources.GetString("gdMotorCFG.StyleInfo");
            this.gdMotorCFG.TabIndex = 35;
            this.gdMotorCFG.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            // 
            // btnSave
            // 
            this.btnSave.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSave.BackColor = System.Drawing.Color.Black;
            this.btnSave.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSave.Location = new System.Drawing.Point(1339, 828);
            this.btnSave.Name = "btnSave";
            this.btnSave.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSave.Size = new System.Drawing.Size(111, 83);
            this.btnSave.TabIndex = 46;
            this.btnSave.Tag = "1";
            this.btnSave.Text = "SAVE";
            this.btnSave.TextColor = System.Drawing.Color.White;
            this.btnSave.ThemeAware = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormDataMotorCFG
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gdMotorCFG);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDataMotorCFG";
            this.Load += new System.EventHandler(this.FormDataMotorCFG_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormDataMotorCFG_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gdMotorCFG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private C1.Win.C1FlexGrid.C1FlexGrid gdMotorCFG;
        private DevComponents.DotNetBar.ButtonX btnSave;
    }
}