
namespace MMI
{
    partial class Form_LotInput
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
            this.labelX2 = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.txtLotID = new System.Windows.Forms.RichTextBox();
            this.txtLotCount = new System.Windows.Forms.RichTextBox();
            this.btnOK = new MMI.HmiButton();
            this.btnCancel = new MMI.HmiButton();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.labelX1.Size = new System.Drawing.Size(488, 127);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "\r\nLOT INFO.";
            this.labelX1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(12, 179);
            this.labelX2.Name = "labelX2";
            this.labelX2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.labelX2.Size = new System.Drawing.Size(75, 32);
            this.labelX2.TabIndex = 28;
            this.labelX2.Text = "COUNT";
            // 
            // lblDevice
            // 
            this.lblDevice.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.Location = new System.Drawing.Point(12, 141);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblDevice.Size = new System.Drawing.Size(75, 32);
            this.lblDevice.TabIndex = 27;
            this.lblDevice.Text = "LOT ID";
            // 
            // txtLotID
            // 
            this.txtLotID.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotID.Location = new System.Drawing.Point(93, 141);
            this.txtLotID.Name = "txtLotID";
            this.txtLotID.Size = new System.Drawing.Size(383, 32);
            this.txtLotID.TabIndex = 29;
            this.txtLotID.Text = "";
            // 
            // txtLotCount
            // 
            this.txtLotCount.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLotCount.Location = new System.Drawing.Point(93, 179);
            this.txtLotCount.Name = "txtLotCount";
            this.txtLotCount.Size = new System.Drawing.Size(383, 32);
            this.txtLotCount.TabIndex = 30;
            this.txtLotCount.Text = "";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(12, 229);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(229, 86);
            this.btnOK.TabIndex = 31;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Malgun Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(247, 229);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(229, 86);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "CANCEL";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Form_LotInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(488, 330);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtLotCount);
            this.Controls.Add(this.txtLotID);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.labelX1);
            this.Name = "Form_LotInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form_LotInput";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelX1;
        public System.Windows.Forms.Label labelX2;
        public System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.RichTextBox txtLotID;
        private System.Windows.Forms.RichTextBox txtLotCount;
        private MMI.HmiButton btnOK;
        private MMI.HmiButton btnCancel;
    }
}