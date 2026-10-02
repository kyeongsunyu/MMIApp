
namespace MMI
{
    partial class FormLogHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogHistory));
            this.gdLogHistory = new MMI.HmiGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbErrorOnly = new System.Windows.Forms.RadioButton();
            this.rbFullLog = new System.Windows.Forms.RadioButton();
            this.btnSAVE = new MMI.HmiButton();
            this.btnClose = new MMI.HmiButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdLogHistory)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdLogHistory
            // 
            this.gdLogHistory.ColumnInfo = resources.GetString("gdLogHistory.ColumnInfo");
            this.gdLogHistory.Location = new System.Drawing.Point(28, 100);
            this.gdLogHistory.Name = "gdLogHistory";
            this.gdLogHistory.Rows.Count = 102;
            this.gdLogHistory.Rows.DefaultSize = 25;
            this.gdLogHistory.Rows.Fixed = 2;
            this.gdLogHistory.Size = new System.Drawing.Size(1033, 738);
            this.gdLogHistory.TabIndex = 37;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbFullLog);
            this.groupBox1.Controls.Add(this.rbErrorOnly);
            this.groupBox1.Location = new System.Drawing.Point(28, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(367, 78);
            this.groupBox1.TabIndex = 38;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "SELECTION";
            // 
            // rbErrorOnly
            // 
            this.rbErrorOnly.AutoSize = true;
            this.rbErrorOnly.Location = new System.Drawing.Point(30, 37);
            this.rbErrorOnly.Name = "rbErrorOnly";
            this.rbErrorOnly.Size = new System.Drawing.Size(134, 23);
            this.rbErrorOnly.TabIndex = 0;
            this.rbErrorOnly.TabStop = true;
            this.rbErrorOnly.Text = "ERROR ONLY";
            this.rbErrorOnly.UseVisualStyleBackColor = true;
            // 
            // rbFullLog
            // 
            this.rbFullLog.AutoSize = true;
            this.rbFullLog.Location = new System.Drawing.Point(206, 37);
            this.rbFullLog.Name = "rbFullLog";
            this.rbFullLog.Size = new System.Drawing.Size(104, 23);
            this.rbFullLog.TabIndex = 1;
            this.rbFullLog.TabStop = true;
            this.rbFullLog.Text = "FULL LOG";
            this.rbFullLog.UseVisualStyleBackColor = true;
            // 
            // btnSAVE
            // 
            this.btnSAVE.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.Location = new System.Drawing.Point(839, 24);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(93, 66);
            this.btnSAVE.TabIndex = 44;
            this.btnSAVE.Tag = "1";
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(958, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 66);
            this.btnClose.TabIndex = 45;
            this.btnClose.Tag = "1";
            this.btnClose.Text = "CLOSE";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // FormLogHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1084, 861);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gdLogHistory);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.FormLogHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdLogHistory)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public MMI.HmiGrid gdLogHistory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbFullLog;
        private System.Windows.Forms.RadioButton rbErrorOnly;
        private MMI.HmiButton btnSAVE;
        private MMI.HmiButton btnClose;
    }
}