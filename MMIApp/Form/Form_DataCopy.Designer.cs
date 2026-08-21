namespace MMI
{
    partial class Form_DataCopy
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
            this.cbSourceDevice = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtTargetDeviceNo = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTargetDeviceName = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnExit = new DevComponents.DotNetBar.ButtonX();
            this.btnCopy = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.SystemColors.Highlight;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX1.Location = new System.Drawing.Point(31, 28);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(448, 39);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "SELECT SOURCE DEVICE";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbSourceDevice
            // 
            this.cbSourceDevice.DisplayMember = "Text";
            this.cbSourceDevice.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSourceDevice.DropDownHeight = 200;
            this.cbSourceDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceDevice.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSourceDevice.ForeColor = System.Drawing.Color.Black;
            this.cbSourceDevice.FormattingEnabled = true;
            this.cbSourceDevice.IntegralHeight = false;
            this.cbSourceDevice.ItemHeight = 34;
            this.cbSourceDevice.Location = new System.Drawing.Point(31, 73);
            this.cbSourceDevice.Name = "cbSourceDevice";
            this.cbSourceDevice.Size = new System.Drawing.Size(448, 40);
            this.cbSourceDevice.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbSourceDevice.TabIndex = 2;
            this.cbSourceDevice.DropDownChange += new DevComponents.DotNetBar.Controls.ComboBoxEx.OnDropDownChangeEventHandler(this.cbSourceDevice_DropDownChange);
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.DarkOliveGreen;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX2.Location = new System.Drawing.Point(31, 162);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(448, 39);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "SELECT TARGET DEVICE";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX3
            // 
            this.labelX3.BackColor = System.Drawing.Color.DarkOliveGreen;
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX3.Location = new System.Drawing.Point(31, 207);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(221, 39);
            this.labelX3.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "NO";
            this.labelX3.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX4
            // 
            this.labelX4.BackColor = System.Drawing.Color.DarkOliveGreen;
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX4.Location = new System.Drawing.Point(31, 252);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(221, 39);
            this.labelX4.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "DEVICE NAME";
            this.labelX4.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtTargetDeviceNo
            // 
            this.txtTargetDeviceNo.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTargetDeviceNo.Border.Class = "TextBoxBorder";
            this.txtTargetDeviceNo.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTargetDeviceNo.DisabledBackColor = System.Drawing.Color.White;
            this.txtTargetDeviceNo.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTargetDeviceNo.ForeColor = System.Drawing.Color.Black;
            this.txtTargetDeviceNo.Location = new System.Drawing.Point(258, 207);
            this.txtTargetDeviceNo.Name = "txtTargetDeviceNo";
            this.txtTargetDeviceNo.PreventEnterBeep = true;
            this.txtTargetDeviceNo.Size = new System.Drawing.Size(221, 39);
            this.txtTargetDeviceNo.TabIndex = 6;
            this.txtTargetDeviceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTargetDeviceName
            // 
            this.txtTargetDeviceName.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtTargetDeviceName.Border.Class = "TextBoxBorder";
            this.txtTargetDeviceName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTargetDeviceName.DisabledBackColor = System.Drawing.Color.White;
            this.txtTargetDeviceName.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTargetDeviceName.ForeColor = System.Drawing.Color.Black;
            this.txtTargetDeviceName.Location = new System.Drawing.Point(258, 252);
            this.txtTargetDeviceName.Name = "txtTargetDeviceName";
            this.txtTargetDeviceName.PreventEnterBeep = true;
            this.txtTargetDeviceName.Size = new System.Drawing.Size(221, 39);
            this.txtTargetDeviceName.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnExit.BackColor = System.Drawing.Color.Black;
            this.btnExit.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnExit.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(258, 337);
            this.btnExit.Name = "btnExit";
            this.btnExit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnExit.Size = new System.Drawing.Size(221, 75);
            this.btnExit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnExit.TabIndex = 9;
            this.btnExit.Tag = "2";
            this.btnExit.Text = "EXIT";
            this.btnExit.ThemeAware = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCopy.BackColor = System.Drawing.Color.Black;
            this.btnCopy.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnCopy.Font = new System.Drawing.Font("굴림", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopy.Location = new System.Drawing.Point(31, 337);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnCopy.Size = new System.Drawing.Size(221, 75);
            this.btnCopy.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Tag = "1";
            this.btnCopy.Text = "COPY";
            this.btnCopy.ThemeAware = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Form_DataCopy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(507, 443);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.txtTargetDeviceName);
            this.Controls.Add(this.txtTargetDeviceNo);
            this.Controls.Add(this.labelX4);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.cbSourceDevice);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_DataCopy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recipe Data Copy";
            this.Load += new System.EventHandler(this.Form_DataCopy_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbSourceDevice;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTargetDeviceNo;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTargetDeviceName;
        private DevComponents.DotNetBar.ButtonX btnExit;
        private DevComponents.DotNetBar.ButtonX btnCopy;
    }
}