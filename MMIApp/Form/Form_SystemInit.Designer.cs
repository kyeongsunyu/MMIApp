namespace MMI
{
    partial class Form_SystemInit
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.progressBar = new DevComponents.DotNetBar.Controls.CircularProgress();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.SystemColors.Highlight;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(516, 222);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "\r\n\r\nSYSTEM INITIALIZING";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            this.labelX1.TextLineAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Highlight;
            // 
            // 
            // 
            this.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Location = new System.Drawing.Point(49, 148);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(425, 74);
            this.lblTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Initializing";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // progressBar
            // 
            this.progressBar.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.progressBar.BackgroundStyle.BackColor = System.Drawing.Color.BurlyWood;
            this.progressBar.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent;
            this.progressBar.BackgroundStyle.BackColorGradientType = DevComponents.DotNetBar.eGradientType.Radial;
            this.progressBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar.Location = new System.Drawing.Point(0, 222);
            this.progressBar.Name = "progressBar";
            this.progressBar.PieBorderDark = System.Drawing.Color.Black;
            this.progressBar.ProgressBarType = DevComponents.DotNetBar.eCircularProgressType.Spoke;
            this.progressBar.ProgressColor = System.Drawing.Color.Olive;
            this.progressBar.ProgressTextColor = System.Drawing.Color.Black;
            this.progressBar.ProgressTextVisible = true;
            this.progressBar.Size = new System.Drawing.Size(516, 352);
            this.progressBar.SpokeBorderLight = System.Drawing.Color.Transparent;
            this.progressBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeXP;
            this.progressBar.TabIndex = 3;
            this.progressBar.Value = 50;
            // 
            // Form_SystemInit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(516, 574);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_SystemInit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.Controls.CircularProgress progressBar;
    }
}