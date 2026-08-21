namespace MMI
{
    partial class Form_MotorCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_MotorCalc));
            this.grbCalc = new System.Windows.Forms.GroupBox();
            this.rd5 = new System.Windows.Forms.RadioButton();
            this.rd4 = new System.Windows.Forms.RadioButton();
            this.rd3 = new System.Windows.Forms.RadioButton();
            this.rd2 = new System.Windows.Forms.RadioButton();
            this.rd1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.btnCancel = new DevComponents.DotNetBar.ButtonX();
            this.btnOK = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.gdCalc = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.grbCalc.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gdCalc)).BeginInit();
            this.SuspendLayout();
            // 
            // grbCalc
            // 
            this.grbCalc.Controls.Add(this.rd5);
            this.grbCalc.Controls.Add(this.rd4);
            this.grbCalc.Controls.Add(this.rd3);
            this.grbCalc.Controls.Add(this.rd2);
            this.grbCalc.Controls.Add(this.rd1);
            this.grbCalc.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbCalc.Location = new System.Drawing.Point(428, 24);
            this.grbCalc.Name = "grbCalc";
            this.grbCalc.Size = new System.Drawing.Size(302, 297);
            this.grbCalc.TabIndex = 2;
            this.grbCalc.TabStop = false;
            this.grbCalc.Text = "FUNCTION";
            // 
            // rd5
            // 
            this.rd5.AutoSize = true;
            this.rd5.Location = new System.Drawing.Point(28, 237);
            this.rd5.Name = "rd5";
            this.rd5.Size = new System.Drawing.Size(153, 29);
            this.rd5.TabIndex = 6;
            this.rd5.TabStop = true;
            this.rd5.Text = "ITEM NAME";
            this.rd5.UseVisualStyleBackColor = true;
            // 
            // rd4
            // 
            this.rd4.AutoSize = true;
            this.rd4.Location = new System.Drawing.Point(28, 191);
            this.rd4.Name = "rd4";
            this.rd4.Size = new System.Drawing.Size(97, 29);
            this.rd4.TabIndex = 5;
            this.rd4.TabStop = true;
            this.rd4.Text = "ACCEL";
            this.rd4.UseVisualStyleBackColor = true;
            // 
            // rd3
            // 
            this.rd3.AutoSize = true;
            this.rd3.Location = new System.Drawing.Point(27, 145);
            this.rd3.Name = "rd3";
            this.rd3.Size = new System.Drawing.Size(99, 29);
            this.rd3.TabIndex = 4;
            this.rd3.TabStop = true;
            this.rd3.Text = "SPEED";
            this.rd3.UseVisualStyleBackColor = true;
            // 
            // rd2
            // 
            this.rd2.AutoSize = true;
            this.rd2.Location = new System.Drawing.Point(27, 99);
            this.rd2.Name = "rd2";
            this.rd2.Size = new System.Drawing.Size(240, 29);
            this.rd2.TabIndex = 3;
            this.rd2.TabStop = true;
            this.rd2.Text = "CURRENT + OFFSET";
            this.rd2.UseVisualStyleBackColor = true;
            // 
            // rd1
            // 
            this.rd1.AutoSize = true;
            this.rd1.Location = new System.Drawing.Point(27, 53);
            this.rd1.Name = "rd1";
            this.rd1.Size = new System.Drawing.Size(192, 29);
            this.rd1.TabIndex = 2;
            this.rd1.TabStop = true;
            this.rd1.Text = "BASE + OFFSET";
            this.rd1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(54, 352);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 29);
            this.label1.TabIndex = 3;
            this.label1.Text = "ITEM NAME";
            // 
            // txtItem
            // 
            this.txtItem.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtItem.Location = new System.Drawing.Point(58, 384);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(672, 33);
            this.txtItem.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnCancel.BackColor = System.Drawing.Color.Black;
            this.btnCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.MagentaWithBackground;
            this.btnCancel.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(399, 435);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnCancel.Size = new System.Drawing.Size(240, 75);
            this.btnCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnCancel.TabIndex = 6;
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
            this.btnOK.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(109, 435);
            this.btnOK.Name = "btnOK";
            this.btnOK.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(2);
            this.btnOK.Size = new System.Drawing.Size(240, 75);
            this.btnOK.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnOK.TabIndex = 5;
            this.btnOK.Tag = "1";
            this.btnOK.Text = "OK";
            this.btnOK.ThemeAware = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.gdCalc);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 297);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATA SETTING";
            // 
            // gdCalc
            // 
            this.gdCalc.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None;
            this.gdCalc.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.gdCalc.ColumnInfo = resources.GetString("gdCalc.ColumnInfo");
            this.gdCalc.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gdCalc.Location = new System.Drawing.Point(24, 53);
            this.gdCalc.Name = "gdCalc";
            this.gdCalc.Rows.Count = 7;
            this.gdCalc.Rows.DefaultSize = 30;
            this.gdCalc.Rows.Fixed = 0;
            this.gdCalc.Size = new System.Drawing.Size(305, 215);
            this.gdCalc.StyleInfo = resources.GetString("gdCalc.StyleInfo");
            this.gdCalc.TabIndex = 4;
            this.gdCalc.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Black;
            this.gdCalc.Click += new System.EventHandler(this.gdCalc_Click);
            // 
            // Form_MotorCalc
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(760, 533);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grbCalc);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_MotorCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.Form_MotorCalc_Load);
            this.grbCalc.ResumeLayout(false);
            this.grbCalc.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gdCalc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grbCalc;
        private System.Windows.Forms.RadioButton rd5;
        private System.Windows.Forms.RadioButton rd4;
        private System.Windows.Forms.RadioButton rd3;
        private System.Windows.Forms.RadioButton rd2;
        private System.Windows.Forms.RadioButton rd1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtItem;
        private DevComponents.DotNetBar.ButtonX btnCancel;
        private DevComponents.DotNetBar.ButtonX btnOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private C1.Win.C1FlexGrid.C1FlexGrid gdCalc;
    }
}