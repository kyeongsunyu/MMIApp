
namespace MMI
{
    partial class Form_Laser
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
            this.pnLaser = new MMI.HmiCard();
            this.SuspendLayout();
            // 
            // pnLaser
            // 
            this.pnLaser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLaser.Location = new System.Drawing.Point(0, 0);
            this.pnLaser.Name = "pnLaser";
            this.pnLaser.Size = new System.Drawing.Size(860, 790);
            this.pnLaser.TabIndex = 169;
            this.pnLaser.TitleText =  "LASER PANEL";
            this.pnLaser.DoubleClick += new System.EventHandler(this.pnLaser_DoubleClick);
            // 
            // Form_Laser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(860, 790);
            this.Controls.Add(this.pnLaser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Laser";
            this.Text = "Form_Laser";
            this.Load += new System.EventHandler(this.Form_Laser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MMI.HmiCard pnLaser;
    }
}