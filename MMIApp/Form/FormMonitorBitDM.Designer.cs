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
            this.gdDM = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblBinValue = new DevComponents.DotNetBar.LabelX();
            this.lblHexValue = new DevComponents.DotNetBar.LabelX();
            this.lblDeviceValue = new DevComponents.DotNetBar.LabelX();
            this.lblIndexNO = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.lblTitle = new DevComponents.DotNetBar.LabelX();
            this.imageBit = new System.Windows.Forms.ImageList(this.components);
            this.cbBit = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cbDM = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnSAVE = new DevComponents.DotNetBar.ButtonX();
            this.gdBit = new C1.Win.C1FlexGrid.C1FlexGrid();
            ((System.ComponentModel.ISupportInitialize)(this.gdDM)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdBit)).BeginInit();
            this.SuspendLayout();
            // 
            // gdDM
            // 
            this.gdDM.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdDM.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdDM.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdDM.ColumnInfo = resources.GetString("gdDM.ColumnInfo");
            this.gdDM.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdDM.Location = new System.Drawing.Point(753, 32);
            this.gdDM.Name = "gdDM";
            this.gdDM.Rows.Count = 12;
            this.gdDM.Rows.DefaultSize = 30;
            this.gdDM.Rows.Fixed = 2;
            this.gdDM.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdDM.Size = new System.Drawing.Size(677, 368);
            this.gdDM.StyleInfo = resources.GetString("gdDM.StyleInfo");
            this.gdDM.TabIndex = 38;
            this.gdDM.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            this.gdDM.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gdDM_AfterEdit);
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
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(753, 406);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(569, 179);
            this.groupBox1.TabIndex = 39;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DM DEC/HEX/BIN DISPLAY";
            // 
            // lblBinValue
            // 
            this.lblBinValue.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.lblBinValue.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblBinValue.BackgroundStyle.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.lblBinValue.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblBinValue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblBinValue.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblBinValue.BackgroundStyle.BorderBottomWidth = 1;
            this.lblBinValue.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblBinValue.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblBinValue.BackgroundStyle.BorderGradientAngle = 0;
            this.lblBinValue.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblBinValue.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblBinValue.BackgroundStyle.BorderLeftWidth = 1;
            this.lblBinValue.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblBinValue.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblBinValue.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblBinValue.BackgroundStyle.BorderRightWidth = 1;
            this.lblBinValue.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblBinValue.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblBinValue.BackgroundStyle.BorderTopWidth = 1;
            this.lblBinValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblBinValue.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBinValue.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblBinValue.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBinValue.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblBinValue.Location = new System.Drawing.Point(105, 134);
            this.lblBinValue.Name = "lblBinValue";
            this.lblBinValue.Size = new System.Drawing.Size(446, 41);
            this.lblBinValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblBinValue.TabIndex = 18;
            this.lblBinValue.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblHexValue
            // 
            this.lblHexValue.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.lblHexValue.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblHexValue.BackgroundStyle.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.lblHexValue.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblHexValue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblHexValue.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblHexValue.BackgroundStyle.BorderBottomWidth = 1;
            this.lblHexValue.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblHexValue.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblHexValue.BackgroundStyle.BorderGradientAngle = 0;
            this.lblHexValue.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblHexValue.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblHexValue.BackgroundStyle.BorderLeftWidth = 1;
            this.lblHexValue.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblHexValue.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblHexValue.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblHexValue.BackgroundStyle.BorderRightWidth = 1;
            this.lblHexValue.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblHexValue.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblHexValue.BackgroundStyle.BorderTopWidth = 1;
            this.lblHexValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblHexValue.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblHexValue.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblHexValue.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHexValue.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblHexValue.Location = new System.Drawing.Point(105, 87);
            this.lblHexValue.Name = "lblHexValue";
            this.lblHexValue.Size = new System.Drawing.Size(446, 41);
            this.lblHexValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblHexValue.TabIndex = 17;
            this.lblHexValue.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblDeviceValue
            // 
            this.lblDeviceValue.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.lblDeviceValue.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblDeviceValue.BackgroundStyle.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.lblDeviceValue.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblDeviceValue.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblDeviceValue.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblDeviceValue.BackgroundStyle.BorderBottomWidth = 1;
            this.lblDeviceValue.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblDeviceValue.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblDeviceValue.BackgroundStyle.BorderGradientAngle = 0;
            this.lblDeviceValue.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblDeviceValue.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblDeviceValue.BackgroundStyle.BorderLeftWidth = 1;
            this.lblDeviceValue.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblDeviceValue.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblDeviceValue.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblDeviceValue.BackgroundStyle.BorderRightWidth = 1;
            this.lblDeviceValue.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblDeviceValue.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblDeviceValue.BackgroundStyle.BorderTopWidth = 1;
            this.lblDeviceValue.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblDeviceValue.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblDeviceValue.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblDeviceValue.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeviceValue.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblDeviceValue.Location = new System.Drawing.Point(315, 40);
            this.lblDeviceValue.Name = "lblDeviceValue";
            this.lblDeviceValue.Size = new System.Drawing.Size(236, 41);
            this.lblDeviceValue.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblDeviceValue.TabIndex = 16;
            this.lblDeviceValue.TextAlignment = System.Drawing.StringAlignment.Center;
            this.lblDeviceValue.DoubleClick += new System.EventHandler(this.lblDeviceValue_DoubleClick);
            // 
            // lblIndexNO
            // 
            this.lblIndexNO.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.lblIndexNO.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblIndexNO.BackgroundStyle.BackColor2 = System.Drawing.Color.CornflowerBlue;
            this.lblIndexNO.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblIndexNO.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblIndexNO.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblIndexNO.BackgroundStyle.BorderBottomWidth = 1;
            this.lblIndexNO.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblIndexNO.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblIndexNO.BackgroundStyle.BorderGradientAngle = 0;
            this.lblIndexNO.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblIndexNO.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblIndexNO.BackgroundStyle.BorderLeftWidth = 1;
            this.lblIndexNO.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblIndexNO.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblIndexNO.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblIndexNO.BackgroundStyle.BorderRightWidth = 1;
            this.lblIndexNO.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblIndexNO.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblIndexNO.BackgroundStyle.BorderTopWidth = 1;
            this.lblIndexNO.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblIndexNO.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblIndexNO.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblIndexNO.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIndexNO.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblIndexNO.Location = new System.Drawing.Point(105, 40);
            this.lblIndexNO.Name = "lblIndexNO";
            this.lblIndexNO.Size = new System.Drawing.Size(204, 41);
            this.lblIndexNO.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblIndexNO.TabIndex = 15;
            this.lblIndexNO.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX2.BackgroundStyle.BackColor2 = System.Drawing.Color.DarkOliveGreen;
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
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX2.Location = new System.Drawing.Point(19, 134);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(63, 41);
            this.labelX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX2.TabIndex = 13;
            this.labelX2.Text = "BIN";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.labelX1.BackgroundStyle.BackColor2 = System.Drawing.Color.DarkOliveGreen;
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
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.labelX1.Location = new System.Drawing.Point(19, 87);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(63, 41);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.labelX1.TabIndex = 12;
            this.labelX1.Text = "HEX";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Info;
            // 
            // 
            // 
            this.lblTitle.BackgroundStyle.BackColor = System.Drawing.Color.Transparent;
            this.lblTitle.BackgroundStyle.BackColor2 = System.Drawing.Color.DarkOliveGreen;
            this.lblTitle.BackgroundStyle.BackColorGradientAngle = 90;
            this.lblTitle.BackgroundStyle.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblTitle.BackgroundStyle.BorderBottomColor = System.Drawing.Color.Black;
            this.lblTitle.BackgroundStyle.BorderBottomWidth = 1;
            this.lblTitle.BackgroundStyle.BorderColor = System.Drawing.Color.Black;
            this.lblTitle.BackgroundStyle.BorderColor2 = System.Drawing.Color.Black;
            this.lblTitle.BackgroundStyle.BorderGradientAngle = 0;
            this.lblTitle.BackgroundStyle.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblTitle.BackgroundStyle.BorderLeftColor = System.Drawing.Color.Black;
            this.lblTitle.BackgroundStyle.BorderLeftWidth = 1;
            this.lblTitle.BackgroundStyle.BorderLightGradientAngle = 0;
            this.lblTitle.BackgroundStyle.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblTitle.BackgroundStyle.BorderRightColor = System.Drawing.Color.Black;
            this.lblTitle.BackgroundStyle.BorderRightWidth = 1;
            this.lblTitle.BackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.lblTitle.BackgroundStyle.BorderTopColor = System.Drawing.Color.Black;
            this.lblTitle.BackgroundStyle.BorderTopWidth = 1;
            this.lblTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblTitle.BackgroundStyle.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.BackgroundStyle.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.InfoText;
            this.lblTitle.Location = new System.Drawing.Point(19, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(63, 41);
            this.lblTitle.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2013;
            this.lblTitle.TabIndex = 11;
            this.lblTitle.Text = "NO";
            this.lblTitle.TextAlignment = System.Drawing.StringAlignment.Center;
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
            this.cbBit.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbBit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBit.FocusCuesEnabled = false;
            this.cbBit.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBit.ForeColor = System.Drawing.Color.Black;
            this.cbBit.FormattingEnabled = true;
            this.cbBit.ItemHeight = 25;
            this.cbBit.Location = new System.Drawing.Point(162, 36);
            this.cbBit.Name = "cbBit";
            this.cbBit.Size = new System.Drawing.Size(121, 31);
            this.cbBit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbBit.TabIndex = 41;
            this.cbBit.SelectedIndexChanged += new System.EventHandler(this.cbBit_SelectedIndexChanged);
            // 
            // cbDM
            // 
            this.cbDM.DisplayMember = "Text";
            this.cbDM.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbDM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDM.FocusCuesEnabled = false;
            this.cbDM.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDM.ForeColor = System.Drawing.Color.Black;
            this.cbDM.FormattingEnabled = true;
            this.cbDM.ItemHeight = 25;
            this.cbDM.Location = new System.Drawing.Point(1065, 36);
            this.cbDM.Name = "cbDM";
            this.cbDM.Size = new System.Drawing.Size(121, 31);
            this.cbDM.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cbDM.TabIndex = 42;
            this.cbDM.SelectedIndexChanged += new System.EventHandler(this.cbDM_SelectedIndexChanged);
            // 
            // btnSAVE
            // 
            this.btnSAVE.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSAVE.BackColor = System.Drawing.Color.Black;
            this.btnSAVE.ColorTable = DevComponents.DotNetBar.eButtonColor.Flat;
            this.btnSAVE.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.Location = new System.Drawing.Point(1340, 515);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnSAVE.Size = new System.Drawing.Size(90, 66);
            this.btnSAVE.TabIndex = 52;
            this.btnSAVE.Tag = "1";
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.TextColor = System.Drawing.Color.White;
            this.btnSAVE.ThemeAware = true;
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // gdBit
            // 
            this.gdBit.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.gdBit.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdBit.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdBit.ColumnInfo = resources.GetString("gdBit.ColumnInfo");
            this.gdBit.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw;
            this.gdBit.Location = new System.Drawing.Point(35, 32);
            this.gdBit.Name = "gdBit";
            this.gdBit.Rows.Count = 18;
            this.gdBit.Rows.DefaultSize = 30;
            this.gdBit.Rows.Fixed = 2;
            this.gdBit.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
            this.gdBit.Size = new System.Drawing.Size(690, 547);
            this.gdBit.StyleInfo = resources.GetString("gdBit.StyleInfo");
            this.gdBit.TabIndex = 37;
            this.gdBit.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Black;
            this.gdBit.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gdBit_AfterEdit);
            this.gdBit.OwnerDrawCell += new C1.Win.C1FlexGrid.OwnerDrawCellEventHandler(this.gdBit_OwnerDrawCell);
            this.gdBit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gdBit_MouseDoubleClick);
            // 
            // FormMonitorBitDM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.cbDM);
            this.Controls.Add(this.cbBit);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gdDM);
            this.Controls.Add(this.gdBit);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
        public C1.Win.C1FlexGrid.C1FlexGrid gdDM;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX lblTitle;
        private DevComponents.DotNetBar.LabelX lblBinValue;
        private DevComponents.DotNetBar.LabelX lblHexValue;
        private DevComponents.DotNetBar.LabelX lblDeviceValue;
        private DevComponents.DotNetBar.LabelX lblIndexNO;
        private System.Windows.Forms.ImageList imageBit;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cbBit;
        public DevComponents.DotNetBar.Controls.ComboBoxEx cbDM;
        private DevComponents.DotNetBar.ButtonX btnSAVE;
        public C1.Win.C1FlexGrid.C1FlexGrid gdBit;
    }
}