namespace MMI
{
    partial class Form_Language
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblHint = new System.Windows.Forms.Label();
            this.btnEN = new MMI.HmiButton();
            this.btnKO = new MMI.HmiButton();
            this.btnZH = new MMI.HmiButton();
            this.btnCancel = new MMI.HmiButton();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(24, 16);
            this.lblTitle.Size = new System.Drawing.Size(612, 40);
            this.lblTitle.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.Text = "Language";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblTitle.Name = "lblTitle";
            // 
            // lblHint
            // 
            this.lblHint.Location = new System.Drawing.Point(24, 56);
            this.lblHint.Size = new System.Drawing.Size(612, 30);
            this.lblHint.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHint.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblHint.BackColor = System.Drawing.Color.Transparent;
            this.lblHint.Text = "For this session. The start-up language is set on System Data.";
            this.lblHint.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHint.Name = "lblHint";
            // 
            // btnEN
            // 
            this.btnEN.Location = new System.Drawing.Point(24, 104);
            this.btnEN.Size = new System.Drawing.Size(196, 72);
            this.btnEN.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnEN.Text = "English";
            this.btnEN.Tag = "EN";
            this.btnEN.Name = "btnEN";
            this.btnEN.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // btnKO
            // 
            this.btnKO.Location = new System.Drawing.Point(232, 104);
            this.btnKO.Size = new System.Drawing.Size(196, 72);
            this.btnKO.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnKO.Text = "한국어";
            this.btnKO.Tag = "KO";
            this.btnKO.Name = "btnKO";
            this.btnKO.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // btnZH
            // 
            this.btnZH.Location = new System.Drawing.Point(440, 104);
            this.btnZH.Size = new System.Drawing.Size(196, 72);
            this.btnZH.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnZH.Text = "中文";
            this.btnZH.Tag = "ZH";
            this.btnZH.Name = "btnZH";
            this.btnZH.Click += new System.EventHandler(this.btnLanguage_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(476, 196);
            this.btnCancel.Size = new System.Drawing.Size(160, 48);
            this.btnCancel.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form_Language
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(660, 264);
            this.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Language";
            this.TopMost = true;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnZH);
            this.Controls.Add(this.btnKO);
            this.Controls.Add(this.btnEN);
            this.Controls.Add(this.lblHint);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form_Language";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblHint;
        private MMI.HmiButton btnEN;
        private MMI.HmiButton btnKO;
        private MMI.HmiButton btnZH;
        private MMI.HmiButton btnCancel;
    }
}
