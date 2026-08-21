namespace MMI
{
    partial class FormLogMenu
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
            this.btnMenuMTBA = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuErrorHistory = new DevComponents.DotNetBar.ButtonX();
            this.btnMenuLog = new DevComponents.DotNetBar.ButtonX();
            this.panelEx1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Info;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.btnMenuMTBA);
            this.panelEx1.Controls.Add(this.btnMenuErrorHistory);
            this.panelEx1.Controls.Add(this.btnMenuLog);
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
            // btnMenuMTBA
            // 
            this.btnMenuMTBA.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuMTBA.BackColor = System.Drawing.Color.Black;
            this.btnMenuMTBA.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnMenuMTBA.Location = new System.Drawing.Point(12, 222);
            this.btnMenuMTBA.Name = "btnMenuMTBA";
            this.btnMenuMTBA.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuMTBA.Size = new System.Drawing.Size(80, 80);
            this.btnMenuMTBA.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuMTBA.TabIndex = 5;
            this.btnMenuMTBA.Tag = "73";
            this.btnMenuMTBA.Text = "MTBA MTBF";
            this.btnMenuMTBA.ThemeAware = true;
            this.btnMenuMTBA.Visible = false;
            this.btnMenuMTBA.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuErrorHistory
            // 
            this.btnMenuErrorHistory.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuErrorHistory.BackColor = System.Drawing.Color.Black;
            this.btnMenuErrorHistory.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnMenuErrorHistory.Location = new System.Drawing.Point(12, 123);
            this.btnMenuErrorHistory.Name = "btnMenuErrorHistory";
            this.btnMenuErrorHistory.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuErrorHistory.Size = new System.Drawing.Size(80, 80);
            this.btnMenuErrorHistory.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuErrorHistory.TabIndex = 4;
            this.btnMenuErrorHistory.Tag = "72";
            this.btnMenuErrorHistory.Text = "ERROR HISTORY";
            this.btnMenuErrorHistory.ThemeAware = true;
            this.btnMenuErrorHistory.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // btnMenuLog
            // 
            this.btnMenuLog.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMenuLog.BackColor = System.Drawing.Color.Black;
            this.btnMenuLog.ColorTable = DevComponents.DotNetBar.eButtonColor.BlueOrb;
            this.btnMenuLog.Location = new System.Drawing.Point(12, 26);
            this.btnMenuLog.Name = "btnMenuLog";
            this.btnMenuLog.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMenuLog.Size = new System.Drawing.Size(80, 80);
            this.btnMenuLog.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnMenuLog.TabIndex = 3;
            this.btnMenuLog.Tag = "71";
            this.btnMenuLog.Text = "LOG";
            this.btnMenuLog.ThemeAware = true;
            this.btnMenuLog.Click += new System.EventHandler(this.btnMenuClick);
            // 
            // FormLogMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(120, 930);
            this.Controls.Add(this.panelEx1);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLogMenu";
            this.panelEx1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.ButtonX btnMenuMTBA;
        private DevComponents.DotNetBar.ButtonX btnMenuErrorHistory;
        private DevComponents.DotNetBar.ButtonX btnMenuLog;
    }
}