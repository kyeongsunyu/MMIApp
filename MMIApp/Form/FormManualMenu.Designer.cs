namespace MMI
{
    partial class FormManualMenu
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
            this.btnMenuOP = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuList = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Info;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnMenuOP);
            this.panelEx1.Controls.Add(this.btnMenuList);
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
            // btnMenuOP
            // 
            this.btnMenuOP.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuOP.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuOP.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnMenuOP.Location = new System.Drawing.Point(12, 123);
            this.btnMenuOP.Name = "btnMenuOP";
            this.btnMenuOP.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuOP.Size = new System.Drawing.Size(80, 80);
            this.btnMenuOP.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuOP.TabIndex = 4;
            this.btnMenuOP.Tag = "22";
            this.btnMenuOP.Text = "OP";
            this.btnMenuOP.ThemeAware = true;
            this.btnMenuOP.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuList
            // 
            this.btnMenuList.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuList.BackColor = System.Drawing.Color.Transparent;
            this.btnMenuList.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnMenuList.Image = global::MMI.Properties.Resources.format_list_unordered;
            this.btnMenuList.Location = new System.Drawing.Point(12, 26);
            this.btnMenuList.Name = "btnMenuList";
            this.btnMenuList.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuList.Size = new System.Drawing.Size(80, 80);
            this.btnMenuList.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.btnMenuList.TabIndex = 3;
            this.btnMenuList.Tag = "21";
            this.btnMenuList.Text = "LIST";
            this.btnMenuList.ThemeAware = true;
            this.btnMenuList.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // FormManualMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(120, 930);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormManualMenu";
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnMenuOP;
        private DevComponents.DotNetBar.ButtonX btnMenuList;
    }
}