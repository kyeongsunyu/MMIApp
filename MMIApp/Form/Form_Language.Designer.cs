namespace MMI
{
    partial class Form_Language
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
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.cbSelect = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.btnSET = new DevComponents.DotNetBar.ButtonX();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.progressBar = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.timerProgress = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            this.labelX1.BackColor = System.Drawing.SystemColors.Highlight;
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelX1.Font = new System.Drawing.Font("Tahoma", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.ForeColor = System.Drawing.Color.White;
            this.labelX1.Location = new System.Drawing.Point(0, 0);
            this.labelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(671, 182);
            this.labelX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.OfficeMobile2014;
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "LANGUAGE SELECT";
            this.labelX1.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // labelX2
            // 
            this.labelX2.BackColor = System.Drawing.Color.RoyalBlue;
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX2.FontBold = true;
            this.labelX2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelX2.Location = new System.Drawing.Point(40, 216);
            this.labelX2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(128, 39);
            this.labelX2.TabIndex = 1;
            this.labelX2.Text = "SELECT";
            this.labelX2.TextAlignment = System.Drawing.StringAlignment.Center;
            // 
            // cbSelect
            // 
            this.cbSelect.DisplayMember = "Text";
            this.cbSelect.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSelect.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSelect.FormattingEnabled = true;
            this.cbSelect.ItemHeight = 31;
            this.cbSelect.Location = new System.Drawing.Point(197, 216);
            this.cbSelect.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbSelect.Name = "cbSelect";
            this.cbSelect.Size = new System.Drawing.Size(213, 37);
            this.cbSelect.Style = DevComponents.DotNetBar.eDotNetBarStyle.Office2003;
            this.cbSelect.TabIndex = 2;
            // 
            // btnSET
            // 
            this.btnSET.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnSET.BackColor = System.Drawing.SystemColors.InfoText;
            this.btnSET.ColorTable = DevComponents.DotNetBar.eButtonColor.Blue;
            this.btnSET.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSET.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSET.Location = new System.Drawing.Point(447, 216);
            this.btnSET.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSET.Name = "btnSET";
            this.btnSET.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(6);
            this.btnSET.Size = new System.Drawing.Size(122, 39);
            this.btnSET.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnSET.TabIndex = 3;
            this.btnSET.Text = "SET";
            this.btnSET.Click += new System.EventHandler(this.btnSET_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.progressBar);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(41, 285);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(528, 119);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Applying Language";
            // 
            // progressBar
            // 
            // 
            // 
            // 
            this.progressBar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.progressBar.Location = new System.Drawing.Point(46, 42);
            this.progressBar.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(428, 51);
            this.progressBar.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.progressBar.TabIndex = 5;
            this.progressBar.TextVisible = true;
            this.progressBar.Value = 50;
            // 
            // timerProgress
            // 
            this.timerProgress.Tick += new System.EventHandler(this.timerProgress_Tick);
            // 
            // Form_Language
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(671, 429);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSET);
            this.Controls.Add(this.cbSelect);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form_Language";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Language Select";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cbSelect;
        private DevComponents.DotNetBar.ButtonX btnSET;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevComponents.DotNetBar.Controls.ProgressBarX progressBar;
        private System.Windows.Forms.Timer timerProgress;
    }
}