namespace MMI
{
    partial class FormAlarmList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAlarmList));
            this.gdAlarm = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureErrPoint = new System.Windows.Forms.PictureBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtOccurrenceFactor = new System.Windows.Forms.RichTextBox();
            this.txtTroubleShooting = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnImageOpen = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.btnMP3Play = new DevComponents.DotNetBar.ButtonX();
            this.btnMP3Stop = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.gdAlarm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureErrPoint)).BeginInit();
            this.SuspendLayout();
            // 
            // gdAlarm
            // 
            this.gdAlarm.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdAlarm.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdAlarm.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdAlarm.ColumnInfo = resources.GetString("gdAlarm.ColumnInfo");
            this.gdAlarm.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdAlarm.Location = new System.Drawing.Point(27, 28);
            this.gdAlarm.Name = "gdAlarm";
            this.gdAlarm.Rows.Count = 2001;
            this.gdAlarm.Rows.DefaultSize = 30;
            this.gdAlarm.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdAlarm.Size = new System.Drawing.Size(680, 573);
            this.gdAlarm.StyleInfo = resources.GetString("gdAlarm.StyleInfo");
            this.gdAlarm.TabIndex = 38;
            this.gdAlarm.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            this.gdAlarm.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gdAlarm_AfterEdit);
            this.gdAlarm.Click += new System.EventHandler(this.gdAlarm_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(735, 28);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(827, 573);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 39;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            // 
            // pictureErrPoint
            // 
            this.pictureErrPoint.BackColor = System.Drawing.Color.Transparent;
            this.pictureErrPoint.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureErrPoint.ErrorImage")));
            this.pictureErrPoint.Image = ((System.Drawing.Image)(resources.GetObject("pictureErrPoint.Image")));
            this.pictureErrPoint.Location = new System.Drawing.Point(1049, 188);
            this.pictureErrPoint.Name = "pictureErrPoint";
            this.pictureErrPoint.Size = new System.Drawing.Size(83, 84);
            this.pictureErrPoint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureErrPoint.TabIndex = 40;
            this.pictureErrPoint.TabStop = false;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.BackgroundStyle.BackColor2 = System.Drawing.SystemColors.GradientInactiveCaption;
            this.labelX2.BackgroundStyle.BackColorGradientAngle = 90;
            this.labelX2.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX2.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX2.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderGradientAngle = 0;
            this.labelX2.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX2.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX2.BackgroundStyle.BorderLightGradientAngle = 0;
            this.labelX2.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX2.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderRightWidth = 1;
            this.labelX2.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX2.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.labelX2.BackgroundStyle.BorderTopWidth = 1;
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX2.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX2.Location = new System.Drawing.Point(27, 607);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(680, 41);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX2.TabIndex = 41;
            this.labelX2.Text = "OCCURRENCE FACTOR";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.BackgroundStyle.BackColor2 = System.Drawing.Color.DarkSeaGreen;
            this.labelX1.BackgroundStyle.BackColorGradientAngle = 90;
            this.labelX1.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX1.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderBottomWidth = 1;
            this.labelX1.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderGradientAngle = 0;
            this.labelX1.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX1.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderLeftWidth = 1;
            this.labelX1.BackgroundStyle.BorderLightGradientAngle = 0;
            this.labelX1.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX1.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderRightWidth = 1;
            this.labelX1.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.labelX1.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.labelX1.BackgroundStyle.BorderTopWidth = 1;
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelX1.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX1.Location = new System.Drawing.Point(735, 607);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(827, 41);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX1.TabIndex = 42;
            this.labelX1.Text = "TROUBLE SHOOTING";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // txtOccurrenceFactor
            // 
            this.txtOccurrenceFactor.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.txtOccurrenceFactor.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOccurrenceFactor.Location = new System.Drawing.Point(27, 654);
            this.txtOccurrenceFactor.Name = "txtOccurrenceFactor";
            this.txtOccurrenceFactor.Size = new System.Drawing.Size(680, 264);
            this.txtOccurrenceFactor.TabIndex = 43;
            this.txtOccurrenceFactor.Text = "";
            this.txtOccurrenceFactor.Leave += new System.EventHandler(this.txtOccurrenceFactor_Leave);
            // 
            // txtTroubleShooting
            // 
            this.txtTroubleShooting.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.txtTroubleShooting.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTroubleShooting.Location = new System.Drawing.Point(735, 654);
            this.txtTroubleShooting.Name = "txtTroubleShooting";
            this.txtTroubleShooting.Size = new System.Drawing.Size(827, 264);
            this.txtTroubleShooting.TabIndex = 44;
            this.txtTroubleShooting.Text = "";
            this.txtTroubleShooting.Leave += new System.EventHandler(this.txtTroubleShooting_Leave);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // btnImageOpen
            // 
            this.btnImageOpen.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnImageOpen.BackColor = System.Drawing.Color.Black;
            this.btnImageOpen.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnImageOpen.Location = new System.Drawing.Point(1485, 560);
            this.btnImageOpen.Name = "btnImageOpen";
            this.btnImageOpen.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnImageOpen.Size = new System.Drawing.Size(77, 41);
            this.btnImageOpen.TabIndex = 45;
            this.btnImageOpen.Tag = "1";
            this.btnImageOpen.Text = "OPEN";
            this.btnImageOpen.TextColor = System.Drawing.Color.White;
            this.btnImageOpen.ThemeAware = true;
            this.btnImageOpen.Click += new System.EventHandler(this.btnImageOpen_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.BackColor = System.Drawing.Color.Black;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnEdit.Location = new System.Drawing.Point(735, 560);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnEdit.Size = new System.Drawing.Size(94, 41);
            this.btnEdit.TabIndex = 46;
            this.btnEdit.Tag = "1";
            this.btnEdit.Text = "EDIT";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.ThemeAware = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnMP3Play
            // 
            this.btnMP3Play.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMP3Play.BackColor = System.Drawing.Color.Black;
            this.btnMP3Play.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMP3Play.Location = new System.Drawing.Point(93, 430);
            this.btnMP3Play.Name = "btnMP3Play";
            this.btnMP3Play.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMP3Play.Size = new System.Drawing.Size(254, 46);
            this.btnMP3Play.TabIndex = 47;
            this.btnMP3Play.Tag = "1";
            this.btnMP3Play.Text = "MP3 PLAY";
            this.btnMP3Play.TextColor = System.Drawing.Color.White;
            this.btnMP3Play.ThemeAware = true;
            this.btnMP3Play.Visible = false;
            this.btnMP3Play.Click += new System.EventHandler(this.btnMP3Play_Click);
            // 
            // btnMP3Stop
            // 
            this.btnMP3Stop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnMP3Stop.BackColor = System.Drawing.Color.Black;
            this.btnMP3Stop.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnMP3Stop.Location = new System.Drawing.Point(384, 430);
            this.btnMP3Stop.Name = "btnMP3Stop";
            this.btnMP3Stop.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnMP3Stop.Size = new System.Drawing.Size(254, 46);
            this.btnMP3Stop.TabIndex = 48;
            this.btnMP3Stop.Tag = "1";
            this.btnMP3Stop.Text = "MP3 STOP";
            this.btnMP3Stop.TextColor = System.Drawing.Color.White;
            this.btnMP3Stop.ThemeAware = true;
            this.btnMP3Stop.Visible = false;
            this.btnMP3Stop.Click += new System.EventHandler(this.btnMP3Stop_Click);
            // 
            // FormAlarmList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1600, 930);
            this.Controls.Add(this.btnMP3Stop);
            this.Controls.Add(this.btnMP3Play);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.gdAlarm);
            this.Controls.Add(this.btnImageOpen);
            this.Controls.Add(this.txtTroubleShooting);
            this.Controls.Add(this.txtOccurrenceFactor);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.pictureErrPoint);
            this.Controls.Add(this.pictureBox);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAlarmList";
            this.Load += new System.EventHandler(this.FormAlarmList_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormAlarmList_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gdAlarm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureErrPoint)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public C1.Win.C1FlexGrid.C1FlexGrid gdAlarm;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.PictureBox pictureErrPoint;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.RichTextBox txtOccurrenceFactor;
        private System.Windows.Forms.RichTextBox txtTroubleShooting;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private DevComponents.DotNetBar.ButtonX btnImageOpen;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private DevComponents.DotNetBar.ButtonX btnMP3Play;
        private DevComponents.DotNetBar.ButtonX btnMP3Stop;
    }
}