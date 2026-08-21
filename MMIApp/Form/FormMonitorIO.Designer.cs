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
            this.gdIO = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.cbInputCh = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbOutputCh = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnOutControl = new DevComponents.DotNetBar.ButtonX();
            this.btnEdit = new DevComponents.DotNetBar.ButtonX();
            this.imageIO = new System.Windows.Forms.ImageList(this.components);
            this.lblOutCh = new DevComponents.DotNetBar.LabelX();
            this.lblInCh = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.gdIO)).BeginInit();
            this.SuspendLayout();
            // 
            // gdIO
            // 
            this.gdIO.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdIO.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdIO.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdIO.ColumnInfo = resources.GetString("gdIO.ColumnInfo");
            this.gdIO.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdIO.Location = new System.Drawing.Point(31, 26);
            this.gdIO.Name = "gdIO";
            this.gdIO.Rows.Count = 18;
            this.gdIO.Rows.DefaultSize = 30;
            this.gdIO.Rows.Fixed = 2;
            this.gdIO.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdIO.Size = new System.Drawing.Size(1390, 555);
            this.gdIO.StyleInfo = resources.GetString("gdIO.StyleInfo");
            this.gdIO.TabIndex = 36;
            this.gdIO.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            this.gdIO.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gdIO_AfterEdit);
            this.gdIO.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(this.gdIO_OwnerDrawCell);
            this.gdIO.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gdIO_MouseClick);
            this.gdIO.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gdIO_MouseDoubleClick);
            // 
            // cbInputCh
            // 
            this.cbInputCh.DisplayMember = "Text";
            this.cbInputCh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbInputCh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInputCh.FocusCuesEnabled = false;
            this.cbInputCh.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbInputCh.ForeColor = System.Drawing.Color.Black;
            this.cbInputCh.FormattingEnabled = true;
            this.cbInputCh.ItemHeight = 28;
            this.cbInputCh.Location = new System.Drawing.Point(191, 81);
            this.cbInputCh.Name = "cbInputCh";
            this.cbInputCh.Size = new System.Drawing.Size(121, 34);
            this.cbInputCh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbInputCh.TabIndex = 37;
            this.cbInputCh.DropDownChange += new DevComponents.DotNetBar.Controls.ComboBoxEx.OnDropDownChangeEventHandler(this.cbInputCh_DropDownChange);
            this.cbInputCh.SelectedIndexChanged += new System.EventHandler(this.cbInputCh_SelectedIndexChanged);
            // 
            // cbOutputCh
            // 
            this.cbOutputCh.DisplayMember = "Text";
            this.cbOutputCh.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbOutputCh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutputCh.FocusCuesEnabled = false;
            this.cbOutputCh.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbOutputCh.ForeColor = System.Drawing.Color.Black;
            this.cbOutputCh.FormattingEnabled = true;
            this.cbOutputCh.ItemHeight = 28;
            this.cbOutputCh.Location = new System.Drawing.Point(561, 81);
            this.cbOutputCh.Name = "cbOutputCh";
            this.cbOutputCh.Size = new System.Drawing.Size(121, 34);
            this.cbOutputCh.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbOutputCh.TabIndex = 38;
            this.cbOutputCh.DropDownChange += new DevComponents.DotNetBar.Controls.ComboBoxEx.OnDropDownChangeEventHandler(this.cbOutputCh_DropDownChange);
            this.cbOutputCh.SelectedIndexChanged += new System.EventHandler(this.cbOutputCh_SelectedIndexChanged);
            // 
            // btnOutControl
            // 
            this.btnOutControl.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnOutControl.BackColor = System.Drawing.Color.Black;
            this.btnOutControl.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnOutControl.Location = new System.Drawing.Point(1303, 638);
            this.btnOutControl.Name = "btnOutControl";
            this.btnOutControl.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnOutControl.Size = new System.Drawing.Size(132, 66);
            this.btnOutControl.TabIndex = 52;
            this.btnOutControl.Tag = "1";
            this.btnOutControl.Text = "OUTPUT ENABLE";
            this.btnOutControl.TextColor = System.Drawing.Color.White;
            this.btnOutControl.ThemeAware = true;
            this.btnOutControl.Click += new System.EventHandler(this.btnOutControl_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnEdit.BackColor = System.Drawing.Color.Black;
            this.btnEdit.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnEdit.Location = new System.Drawing.Point(1127, 638);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnEdit.Size = new System.Drawing.Size(136, 66);
            this.btnEdit.TabIndex = 51;
            this.btnEdit.Tag = "1";
            this.btnEdit.Text = "NAME EDIT";
            this.btnEdit.TextColor = System.Drawing.Color.White;
            this.btnEdit.ThemeAware = true;
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
            this.lblOutCh.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.lblOutCh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblOutCh.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOutCh.ForeColor = System.Drawing.Color.Lime;
            this.lblOutCh.Location = new System.Drawing.Point(481, 114);
            this.lblOutCh.Name = "lblOutCh";
            this.lblOutCh.Size = new System.Drawing.Size(70, 70);
            this.lblOutCh.TabIndex = 56;
            this.lblOutCh.Text = "00";
            this.lblOutCh.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblInCh
            // 
            this.lblInCh.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.lblInCh.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblInCh.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInCh.ForeColor = System.Drawing.Color.Red;
            this.lblInCh.Location = new System.Drawing.Point(126, 114);
            this.lblInCh.Name = "lblInCh";
            this.lblInCh.Size = new System.Drawing.Size(70, 70);
            this.lblInCh.TabIndex = 57;
            this.lblInCh.Text = "00";
            this.lblInCh.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // FormMonitorIO
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.lblOutCh);
            this.Controls.Add(this.lblInCh);
            this.Controls.Add(this.btnOutControl);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.cbOutputCh);
            this.Controls.Add(this.cbInputCh);
            this.Controls.Add(this.gdIO);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormMonitorIO";
            this.Opacity = 0D;
            this.Load += new System.EventHandler(this.FormMonitorIO_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormMonitorIO_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.gdIO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public C1.Win.C1FlexGrid.C1FlexGrid gdIO;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbInputCh;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbOutputCh;
        private DevComponents.DotNetBar.ButtonX btnOutControl;
        private DevComponents.DotNetBar.ButtonX btnEdit;
        private System.Windows.Forms.ImageList imageIO;
        private DevComponents.DotNetBar.LabelX lblOutCh;
        private DevComponents.DotNetBar.LabelX lblInCh;
    }
}