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
            this.labelX1 = new System.Windows.Forms.Label();
            this.cbSourceDevice = new System.Windows.Forms.ComboBox();
            this.labelX2 = new System.Windows.Forms.Label();
            this.labelX3 = new System.Windows.Forms.Label();
            this.labelX4 = new System.Windows.Forms.Label();
            this.txtTargetDeviceNo = new System.Windows.Forms.TextBox();
            this.txtTargetDeviceName = new System.Windows.Forms.TextBox();
            this.btnExit = new MMI.HmiButton();
            this.btnCopy = new MMI.HmiButton();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX1.Location = new System.Drawing.Point(31, 28);
            this.labelX1.Name = "labelX1";
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.labelX1.Size = new System.Drawing.Size(448, 39);
            this.labelX1.TabIndex = 1;
            this.labelX1.Text = "SELECT SOURCE DEVICE";
            this.labelX1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSourceDevice
            // 
            this.cbSourceDevice.DisplayMember = "Text";
            this.cbSourceDevice.DropDownHeight = 200;
            this.cbSourceDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSourceDevice.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbSourceDevice.FormattingEnabled = true;
            this.cbSourceDevice.IntegralHeight = false;
            this.cbSourceDevice.Location = new System.Drawing.Point(31, 73);
            this.cbSourceDevice.Name = "cbSourceDevice";
            this.cbSourceDevice.Size = new System.Drawing.Size(448, 40);
            this.cbSourceDevice.TabIndex = 2;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX2.Location = new System.Drawing.Point(31, 162);
            this.labelX2.Name = "labelX2";
            this.labelX2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.labelX2.Size = new System.Drawing.Size(448, 39);
            this.labelX2.TabIndex = 3;
            this.labelX2.Text = "SELECT TARGET DEVICE";
            this.labelX2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelX3
            // 
            this.labelX3.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX3.Location = new System.Drawing.Point(31, 207);
            this.labelX3.Name = "labelX3";
            this.labelX3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.labelX3.Size = new System.Drawing.Size(221, 39);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "NO";
            this.labelX3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelX4
            // 
            this.labelX4.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX4.Location = new System.Drawing.Point(31, 252);
            this.labelX4.Name = "labelX4";
            this.labelX4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.labelX4.Size = new System.Drawing.Size(221, 39);
            this.labelX4.TabIndex = 5;
            this.labelX4.Text = "DEVICE NAME";
            this.labelX4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtTargetDeviceNo
            // 
            this.txtTargetDeviceNo.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTargetDeviceNo.Location = new System.Drawing.Point(258, 207);
            this.txtTargetDeviceNo.Name = "txtTargetDeviceNo";
            this.txtTargetDeviceNo.Size = new System.Drawing.Size(221, 39);
            this.txtTargetDeviceNo.TabIndex = 6;
            this.txtTargetDeviceNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTargetDeviceName
            // 
            this.txtTargetDeviceName.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtTargetDeviceName.Location = new System.Drawing.Point(258, 252);
            this.txtTargetDeviceName.Name = "txtTargetDeviceName";
            this.txtTargetDeviceName.Size = new System.Drawing.Size(221, 39);
            this.txtTargetDeviceName.TabIndex = 7;
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(258, 337);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(221, 75);
            this.btnExit.TabIndex = 9;
            this.btnExit.Tag = "2";
            this.btnExit.Text = "EXIT";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCopy.Location = new System.Drawing.Point(31, 337);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(221, 75);
            this.btnCopy.TabIndex = 8;
            this.btnCopy.Tag = "1";
            this.btnCopy.Text = "COPY";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // Form_DataCopy
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
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
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_DataCopy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Recipe Data Copy";
            this.Load += new System.EventHandler(this.Form_DataCopy_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelX1;
        private System.Windows.Forms.ComboBox cbSourceDevice;
        private System.Windows.Forms.Label labelX2;
        private System.Windows.Forms.Label labelX3;
        private System.Windows.Forms.Label labelX4;
        private System.Windows.Forms.TextBox txtTargetDeviceNo;
        private System.Windows.Forms.TextBox txtTargetDeviceName;
        private MMI.HmiButton btnExit;
        private MMI.HmiButton btnCopy;
    }
}