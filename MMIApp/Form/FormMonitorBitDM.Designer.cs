namespace MMI
{
    partial class FormMonitorBitDM
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMonitorBitDM));
            this.gdDM = new MMI.HmiGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBinValue = new System.Windows.Forms.Label();
            this.lblHexValue = new System.Windows.Forms.Label();
            this.lblDeviceValue = new System.Windows.Forms.Label();
            this.lblIndexNO = new System.Windows.Forms.Label();
            this.labelX2 = new System.Windows.Forms.Label();
            this.labelX1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.imageBit = new System.Windows.Forms.ImageList(this.components);
            this.cbBit = new System.Windows.Forms.ComboBox();
            this.cbDM = new System.Windows.Forms.ComboBox();
            this.btnSAVE = new MMI.HmiButton();
            this.gdBit = new MMI.HmiGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gdDM)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdBit)).BeginInit();
            this.SuspendLayout();
            // 
            // gdDM
            // 
            this.gdDM.ColumnInfo = resources.GetString("gdDM.ColumnInfo");
            this.gdDM.Location = new System.Drawing.Point(753, 32);
            this.gdDM.Name = "gdDM";
            this.gdDM.Rows.Count = 12;
            this.gdDM.Rows.DefaultSize = 30;
            this.gdDM.Rows.Fixed = 2;
            this.gdDM.Size = new System.Drawing.Size(677, 368);
            this.gdDM.TabIndex = 38;
            this.gdDM.AfterEdit += new MMI.RowColEventHandler(this.gdDM_AfterEdit);
            this.gdDM.Click += new System.EventHandler(this.gdDM_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblBinValue);
            this.groupBox1.Controls.Add(this.lblHexValue);
            this.groupBox1.Controls.Add(this.lblDeviceValue);
            this.groupBox1.Controls.Add(this.lblIndexNO);
            this.groupBox1.Controls.Add(this.labelX2);
            this.groupBox1.Controls.Add(this.labelX1);
            this.groupBox1.Controls.Add(this.lblTitle);
            this.groupBox1.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(753, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 179);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DM DEC/HEX/BIN DISPLAY";
            // 
            // lblBinValue
            // 
            this.lblBinValue.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBinValue.Location = new System.Drawing.Point(105, 134);
            this.lblBinValue.Name = "lblBinValue";
            this.lblBinValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblBinValue.Size = new System.Drawing.Size(446, 41);
            this.lblBinValue.TabIndex = 18;
            this.lblBinValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblHexValue
            // 
            this.lblHexValue.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHexValue.Location = new System.Drawing.Point(105, 87);
            this.lblHexValue.Name = "lblHexValue";
            this.lblHexValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblHexValue.Size = new System.Drawing.Size(446, 41);
            this.lblHexValue.TabIndex = 17;
            this.lblHexValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDeviceValue
            // 
            this.lblDeviceValue.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceValue.Location = new System.Drawing.Point(315, 40);
            this.lblDeviceValue.Name = "lblDeviceValue";
            this.lblDeviceValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblDeviceValue.Size = new System.Drawing.Size(236, 41);
            this.lblDeviceValue.TabIndex = 16;
            this.lblDeviceValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDeviceValue.DoubleClick += new System.EventHandler(this.lblDeviceValue_DoubleClick);
            // 
            // lblIndexNO
            // 
            this.lblIndexNO.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexNO.Location = new System.Drawing.Point(105, 40);
            this.lblIndexNO.Name = "lblIndexNO";
            this.lblIndexNO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblIndexNO.Size = new System.Drawing.Size(204, 41);
            this.lblIndexNO.TabIndex = 15;
            this.lblIndexNO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelX2
            // 
            this.labelX2.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.Location = new System.Drawing.Point(19, 134);
            this.labelX2.Name = "labelX2";
            this.labelX2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.labelX2.Size = new System.Drawing.Size(63, 41);
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "BIN";
            this.labelX2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(19, 87);
            this.labelX1.Name = "labelX1";
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.labelX1.Size = new System.Drawing.Size(63, 41);
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "HEX";
            this.labelX1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(19, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblTitle.Size = new System.Drawing.Size(63, 41);
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "NO";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // imageBit
            // 
            this.imageBit.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageBit.ImageStream")));
            this.imageBit.TransparentColor = System.Drawing.Color.Transparent;
            this.imageBit.Images.SetKeyName(0, "LED_OFF.bmp");
            this.imageBit.Images.SetKeyName(1, "LED_REDON.bmp");
            this.imageBit.Images.SetKeyName(2, "LED_GREENON.bmp");
            // 
            // cbBit
            // 
            this.cbBit.DisplayMember = "Text";
            this.cbBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBit.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBit.FormattingEnabled = true;
            this.cbBit.Location = new System.Drawing.Point(162, 36);
            this.cbBit.Name = "cbBit";
            this.cbBit.Size = new System.Drawing.Size(121, 31);
            this.cbBit.TabIndex = 41;
            this.cbBit.SelectedIndexChanged += new System.EventHandler(this.cbBit_SelectedIndexChanged);
            // 
            // cbDM
            // 
            this.cbDM.DisplayMember = "Text";
            this.cbDM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDM.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDM.FormattingEnabled = true;
            this.cbDM.Location = new System.Drawing.Point(1065, 36);
            this.cbDM.Name = "cbDM";
            this.cbDM.Size = new System.Drawing.Size(121, 31);
            this.cbDM.TabIndex = 42;
            this.cbDM.SelectedIndexChanged += new System.EventHandler(this.cbDM_SelectedIndexChanged);
            // 
            // btnSAVE
            // 
            this.btnSAVE.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.Location = new System.Drawing.Point(1340, 515);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(90, 66);
            this.btnSAVE.TabIndex = 52;
            this.btnSAVE.Tag = "1";
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // gdBit
            // 
            this.gdBit.ColumnInfo = resources.GetString("gdBit.ColumnInfo");
            this.gdBit.Location = new System.Drawing.Point(35, 32);
            this.gdBit.Name = "gdBit";
            this.gdBit.Rows.Count = 18;
            this.gdBit.Rows.DefaultSize = 30;
            this.gdBit.Rows.Fixed = 2;
            this.gdBit.Size = new System.Drawing.Size(690, 547);
            this.gdBit.TabIndex = 37;
            this.gdBit.AfterEdit += new MMI.RowColEventHandler(this.gdBit_AfterEdit);
            this.gdBit.OwnerDrawCell += new MMI.OwnerDrawCellEventHandler(this.gdBit_OwnerDrawCell);
            this.gdBit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gdBit_MouseDoubleClick);
            // 
            // FormMonitorBitDM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.cbDM);
            this.Controls.Add(this.cbBit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gdDM);
            this.Controls.Add(this.gdBit);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMonitorBitDM";
            this.Load += new System.EventHandler(this.FormMonitorBitDM_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMonitorBitDM_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gdDM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdBit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public MMI.HmiGrid gdDM;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelX2;
        private System.Windows.Forms.Label labelX1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblBinValue;
        private System.Windows.Forms.Label lblHexValue;
        private System.Windows.Forms.Label lblDeviceValue;
        private System.Windows.Forms.Label lblIndexNO;
        private System.Windows.Forms.ImageList imageBit;
        public System.Windows.Forms.ComboBox cbBit;
        public System.Windows.Forms.ComboBox cbDM;
        private MMI.HmiButton btnSAVE;
        public MMI.HmiGrid gdBit;
    }
}