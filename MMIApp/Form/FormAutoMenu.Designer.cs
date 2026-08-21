namespace MMI
{
    partial class FormAutoMenu
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
            this.btnMenuAuto2 = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuAuto1 = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Info;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnMenuAuto2);
            this.panelEx1.Controls.Add(this.btnMenuAuto1);
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
            this.panelEx1.TabIndex = 3;
            // 
            // btnMenuAuto2
            // 
            this.btnMenuAuto2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuAuto2.BackColor = System.Drawing.Color.Black;
            this.btnMenuAuto2.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnMenuAuto2.Location = new System.Drawing.Point(12, 123);
            this.btnMenuAuto2.Name = "btnMenuAuto2";
            this.btnMenuAuto2.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuAuto2.Size = new System.Drawing.Size(80, 80);
            this.btnMenuAuto2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuAuto2.TabIndex = 4;
            this.btnMenuAuto2.Tag = "12";
            this.btnMenuAuto2.Text = "AUTO2";
            this.btnMenuAuto2.ThemeAware = true;
            this.btnMenuAuto2.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuAuto1
            // 
            this.btnMenuAuto1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuAuto1.BackColor = System.Drawing.Color.Black;
            this.btnMenuAuto1.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnMenuAuto1.Location = new System.Drawing.Point(12, 26);
            this.btnMenuAuto1.Name = "btnMenuAuto1";
            this.btnMenuAuto1.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuAuto1.Size = new System.Drawing.Size(80, 80);
            this.btnMenuAuto1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuAuto1.TabIndex = 3;
            this.btnMenuAuto1.Tag = "11";
            this.btnMenuAuto1.Text = "AUTO1";
            this.btnMenuAuto1.ThemeAware = true;
            this.btnMenuAuto1.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // FormAutoMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(120, 930);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAutoMenu";
            this.Text = "FormAutoMenu";
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnMenuAuto2;
        private DevComponents.DotNetBar.ButtonX btnMenuAuto1;
    }
}