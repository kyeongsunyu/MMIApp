namespace MMI
{
    partial class FormMonitorMenu
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
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.btnMenuBitDM = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuIO = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Info;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnMenuBitDM);
            this.panelEx1.Controls.Add(this.btnMenuIO);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(120, 930);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.Color = System.Drawing.SystemColors.Info;
            this.panelEx1.Style.BackColor2.Color = System.Drawing.SystemColors.Info;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 7;
            // 
            // btnMenuBitDM
            // 
            this.btnMenuBitDM.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuBitDM.BackColor = System.Drawing.Color.Black;
            this.btnMenuBitDM.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnMenuBitDM.Location = new System.Drawing.Point(12, 123);
            this.btnMenuBitDM.Name = "btnMenuBitDM";
            this.btnMenuBitDM.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuBitDM.Size = new System.Drawing.Size(80, 80);
            this.btnMenuBitDM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuBitDM.TabIndex = 4;
            this.btnMenuBitDM.Tag = "52";
            this.btnMenuBitDM.Text = "BIT  \r\nDM";
            this.btnMenuBitDM.ThemeAware = true;
            this.btnMenuBitDM.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuIO
            // 
            this.btnMenuIO.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuIO.BackColor = System.Drawing.Color.Black;
            this.btnMenuIO.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnMenuIO.Location = new System.Drawing.Point(12, 26);
            this.btnMenuIO.Name = "btnMenuIO";
            this.btnMenuIO.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuIO.Size = new System.Drawing.Size(80, 80);
            this.btnMenuIO.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuIO.TabIndex = 3;
            this.btnMenuIO.Tag = "51";
            this.btnMenuIO.Text = "IO";
            this.btnMenuIO.ThemeAware = true;
            this.btnMenuIO.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // FormMonitorMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(120, 930);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMonitorMenu";
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnMenuBitDM;
        private DevComponents.DotNetBar.ButtonX btnMenuIO;
    }
}