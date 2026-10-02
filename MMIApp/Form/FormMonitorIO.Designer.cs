namespace MMI
{
    partial class FormMonitorIO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMonitorIO));
            this.gdIO = new MMI.HmiGrid();
            this.cbInputCh = new System.Windows.Forms.ComboBox();
            this.cbOutputCh = new System.Windows.Forms.ComboBox();
            this.btnOutControl = new MMI.HmiButton();
            this.btnEdit = new MMI.HmiButton();
            this.imageIO = new System.Windows.Forms.ImageList(this.components);
            this.lblOutCh = new System.Windows.Forms.Label();
            this.lblInCh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gdIO)).BeginInit();
            this.SuspendLayout();
            // 
            // gdIO
            // 
            this.gdIO.ColumnInfo = resources.GetString("gdIO.ColumnInfo");
            this.gdIO.Location = new System.Drawing.Point(31, 26);
            this.gdIO.Name = "gdIO";
            this.gdIO.Rows.Count = 18;
            this.gdIO.Rows.DefaultSize = 30;
            this.gdIO.Rows.Fixed = 2;
            this.gdIO.Size = new System.Drawing.Size(1390, 555);
            this.gdIO.TabIndex = 36;
            this.gdIO.AfterEdit += new MMI.RowColEventHandler(this.gdIO_AfterEdit);
            this.gdIO.OwnerDrawCell += new MMI.OwnerDrawCellEventHandler(this.gdIO_OwnerDrawCell);
            this.gdIO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gdIO_MouseClick);
            this.gdIO.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gdIO_MouseDoubleClick);
            // 
            // cbInputCh
            // 
            this.cbInputCh.DisplayMember = "Text";
            this.cbInputCh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputCh.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInputCh.FormattingEnabled = true;
            this.cbInputCh.Location = new System.Drawing.Point(191, 81);
            this.cbInputCh.Name = "cbInputCh";
            this.cbInputCh.Size = new System.Drawing.Size(121, 34);
            this.cbInputCh.TabIndex = 37;
            this.cbInputCh.SelectedIndexChanged += new System.EventHandler(this.cbInputCh_SelectedIndexChanged);
            // 
            // cbOutputCh
            // 
            this.cbOutputCh.DisplayMember = "Text";
            this.cbOutputCh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputCh.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOutputCh.FormattingEnabled = true;
            this.cbOutputCh.Location = new System.Drawing.Point(561, 81);
            this.cbOutputCh.Name = "cbOutputCh";
            this.cbOutputCh.Size = new System.Drawing.Size(121, 34);
            this.cbOutputCh.TabIndex = 38;
            this.cbOutputCh.SelectedIndexChanged += new System.EventHandler(this.cbOutputCh_SelectedIndexChanged);
            // 
            // btnOutControl
            // 
            this.btnOutControl.Location = new System.Drawing.Point(1303, 638);
            this.btnOutControl.Name = "btnOutControl";
            this.btnOutControl.Size = new System.Drawing.Size(132, 66);
            this.btnOutControl.TabIndex = 52;
            this.btnOutControl.Tag = "1";
            this.btnOutControl.Text = "OUTPUT ENABLE";
            this.btnOutControl.Click += new System.EventHandler(this.btnOutControl_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(1127, 638);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(136, 66);
            this.btnEdit.TabIndex = 51;
            this.btnEdit.Tag = "1";
            this.btnEdit.Text = "NAME EDIT";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // imageIO
            // 
            this.imageIO.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageIO.ImageStream")));
            this.imageIO.TransparentColor = System.Drawing.Color.Transparent;
            this.imageIO.Images.SetKeyName(0, "LED_OFF.bmp");
            this.imageIO.Images.SetKeyName(1, "LED_REDON.bmp");
            this.imageIO.Images.SetKeyName(2, "LED_GREENON.bmp");
            // 
            // lblOutCh
            // 
            this.lblOutCh.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutCh.Location = new System.Drawing.Point(481, 114);
            this.lblOutCh.Name = "lblOutCh";
            this.lblOutCh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOutCh.Size = new System.Drawing.Size(70, 70);
            this.lblOutCh.TabIndex = 56;
            this.lblOutCh.Text = "00";
            this.lblOutCh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInCh
            // 
            this.lblInCh.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInCh.Location = new System.Drawing.Point(126, 114);
            this.lblInCh.Name = "lblInCh";
            this.lblInCh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblInCh.Size = new System.Drawing.Size(70, 70);
            this.lblInCh.TabIndex = 57;
            this.lblInCh.Text = "00";
            this.lblInCh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMonitorIO
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.lblOutCh);
            this.Controls.Add(this.lblInCh);
            this.Controls.Add(this.btnOutControl);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cbOutputCh);
            this.Controls.Add(this.cbInputCh);
            this.Controls.Add(this.gdIO);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMonitorIO";
            this.Opacity = 0D;
            this.Load += new System.EventHandler(this.FormMonitorIO_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMonitorIO_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gdIO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public MMI.HmiGrid gdIO;
        private System.Windows.Forms.ComboBox cbInputCh;
        private System.Windows.Forms.ComboBox cbOutputCh;
        private MMI.HmiButton btnOutControl;
        private MMI.HmiButton btnEdit;
        private System.Windows.Forms.ImageList imageIO;
        private System.Windows.Forms.Label lblOutCh;
        private System.Windows.Forms.Label lblInCh;
    }
}