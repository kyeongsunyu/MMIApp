namespace MMI
{
    partial class Form_Msg
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
            this.lblMsg = new DevComponents.DotNetBar.LabelX();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.SystemColors.Highlight;
            // 
            // 
            // 
            this.lblMsg.BackgroundStyle.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblMsg.BackgroundStyle.BackColor2 = System.Drawing.Color.Transparent;
            this.lblMsg.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblMsg.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblMsg.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblMsg.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblMsg.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblMsg.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblMsg.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblMsg.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblMsg.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblMsg.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblMsg.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMsg.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsg.ForeColor = System.Drawing.Color.Black;
            this.lblMsg.Location = new System.Drawing.Point(0, 0);
            this.lblMsg.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(1204, 275);
            this.lblMsg.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.lblMsg.TabIndex = 1;
            this.lblMsg.Text = "message...";
            this.lblMsg.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Black;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(602, 275);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnCancel.Size = new System.Drawing.Size(600, 117);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Tag = "2";
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.ThemeAware = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOK.BackColor = System.Drawing.Color.Black;
            this.btnOK.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(0, 275);
            this.btnOK.Name = "btnOK";
            this.btnOK.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnOK.Size = new System.Drawing.Size(600, 117);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 10;
            this.btnOK.Tag = "1";
            this.btnOK.Text = "OK";
            this.btnOK.ThemeAware = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // Form_Msg
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1204, 392);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblMsg);
            this.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Msg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Msg";
            this.Load += new System.EventHandler(this.Form_Msg_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Msg_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblMsg;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
    }
}