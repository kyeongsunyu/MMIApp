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
            this.gdOption = new MMI.HmiGrid();
            this.btnSAVE = new MMI.HmiButton();
            this.btnEdit = new MMI.HmiButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdOption)).BeginInit();
            this.SuspendLayout();
            // 
            // gdOption
            // 
            this.gdOption.ColumnInfo = resources.GetString("gdOption.ColumnInfo");
            this.gdOption.Location = new System.Drawing.Point(59, 32);
            this.gdOption.Name = "gdOption";
            this.gdOption.Rows.Count = 34;
            this.gdOption.Rows.DefaultSize = 25;
            this.gdOption.Rows.Fixed = 2;
            this.gdOption.Size = new System.Drawing.Size(1263, 855);
            this.gdOption.TabIndex = 35;
            this.gdOption.AfterEdit += new MMI.RowColEventHandler(this.gdOption_AfterEdit);
            this.gdOption.DoubleClick += new System.EventHandler(this.gdOption_DoubleClick);
            // 
            // btnSAVE
            // 
            this.btnSAVE.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.Location = new System.Drawing.Point(1328, 815);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(140, 72);
            this.btnSAVE.TabIndex = 37;
            this.btnSAVE.Tag = "2";
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(1328, 737);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(140, 72);
            this.btnEdit.TabIndex = 36;
            this.btnEdit.Tag = "1";
            this.btnEdit.Text = "ITEM EDIT";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // FormDataOption
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.gdOption);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDataOption";
            this.Text = "FormDataOption";
            this.Load += new System.EventHandler(this.FormDataOption_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormDataOption_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gdOption)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public MMI.HmiGrid gdOption;
        private MMI.HmiButton btnSAVE;
        private MMI.HmiButton btnEdit;
    }
}