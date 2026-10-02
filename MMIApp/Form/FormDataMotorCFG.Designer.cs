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
            this.gdMotorCFG = new MMI.HmiGrid();
            this.btnSave = new MMI.HmiButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdMotorCFG)).BeginInit();
            this.SuspendLayout();
            // 
            // gdMotorCFG
            // 
            this.gdMotorCFG.ColumnInfo = resources.GetString("gdMotorCFG.ColumnInfo");
            this.gdMotorCFG.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdMotorCFG.Location = new System.Drawing.Point(12, 12);
            this.gdMotorCFG.Name = "gdMotorCFG";
            this.gdMotorCFG.Rows.Count = 62;
            this.gdMotorCFG.Rows.DefaultSize = 25;
            this.gdMotorCFG.Rows.Fixed = 2;
            this.gdMotorCFG.Size = new System.Drawing.Size(1490, 906);
            this.gdMotorCFG.TabIndex = 35;
            this.gdMotorCFG.Resize += new System.EventHandler(this.gdMotorCFG_Resize);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(1514, 835);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(118, 83);
            this.btnSave.TabIndex = 46;
            this.btnSave.Tag = "1";
            this.btnSave.Text = "SAVE";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormDataMotorCFG
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1644, 930);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gdMotorCFG);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDataMotorCFG";
            this.Load += new System.EventHandler(this.FormDataMotorCFG_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormDataMotorCFG_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gdMotorCFG)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private MMI.HmiGrid gdMotorCFG;
        private MMI.HmiButton btnSave;
    }
}