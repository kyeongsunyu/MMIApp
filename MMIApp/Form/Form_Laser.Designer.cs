
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
            this.pnLaser = new DevComponents.DotNetBar.PanelEx();
            this.SuspendLayout();
            // 
            // pnLaser
            // 
            this.pnLaser.CanvasColor = System.Drawing.SystemColors.Control;
            this.pnLaser.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.pnLaser.DisabledBackColor = System.Drawing.Color.Empty;
            this.pnLaser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnLaser.Location = new System.Drawing.Point(0, 0);
            this.pnLaser.Name = "pnLaser";
            this.pnLaser.Size = new System.Drawing.Size(860, 790);
            this.pnLaser.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.pnLaser.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.pnLaser.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.pnLaser.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.pnLaser.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.pnLaser.Style.GradientAngle = 90;
            this.pnLaser.TabIndex = 169;
            this.pnLaser.Text = "LASER PANEL";
            this.pnLaser.DoubleClick += new System.EventHandler(this.pnLaser_DoubleClick);
            // 
            // Form_Laser
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(860, 790);
            this.Controls.Add(this.pnLaser);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Laser";
            this.Text = "Form_Laser";
            this.Load += new System.EventHandler(this.Form_Laser_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx pnLaser;
    }
}