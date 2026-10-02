namespace MMI
{
    partial class FormDataLampBuzzer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataLampBuzzer));
            this.gdLampBuzzer = new MMI.HmiGrid();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnYellowLamp = new System.Windows.Forms.Panel();
            this.pnRedLamp = new System.Windows.Forms.Panel();
            this.pnGreenLamp = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblOffTime = new System.Windows.Forms.Label();
            this.lblOnTime = new System.Windows.Forms.Label();
            this.lblBuzzerCount = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grGreenLamp = new System.Windows.Forms.GroupBox();
            this.rdGreenBLINK = new System.Windows.Forms.RadioButton();
            this.rdGreenON = new System.Windows.Forms.RadioButton();
            this.rdGreenOFF = new System.Windows.Forms.RadioButton();
            this.grYellowLamp = new System.Windows.Forms.GroupBox();
            this.rdYellowBLINK = new System.Windows.Forms.RadioButton();
            this.rdYellowON = new System.Windows.Forms.RadioButton();
            this.rdYellowOFF = new System.Windows.Forms.RadioButton();
            this.grRedLamp = new System.Windows.Forms.GroupBox();
            this.rdRedBLINK = new System.Windows.Forms.RadioButton();
            this.rdRedON = new System.Windows.Forms.RadioButton();
            this.rdRedOFF = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnInit = new MMI.HmiButton();
            this.btnSAVE = new MMI.HmiButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdLampBuzzer)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grGreenLamp.SuspendLayout();
            this.grYellowLamp.SuspendLayout();
            this.grRedLamp.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdLampBuzzer
            // 
            this.gdLampBuzzer.ColumnInfo = resources.GetString("gdLampBuzzer.ColumnInfo");
            this.gdLampBuzzer.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gdLampBuzzer.Location = new System.Drawing.Point(59, 32);
            this.gdLampBuzzer.Name = "gdLampBuzzer";
            this.gdLampBuzzer.Rows.Count = 1002;
            this.gdLampBuzzer.Rows.DefaultSize = 30;
            this.gdLampBuzzer.Rows.Fixed = 2;
            this.gdLampBuzzer.Size = new System.Drawing.Size(1366, 605);
            this.gdLampBuzzer.TabIndex = 30;
            this.gdLampBuzzer.Click += new System.EventHandler(this.gdLampBuzzer_Click);
            this.gdLampBuzzer.DoubleClick += new System.EventHandler(this.gdLampBuzzer_DoubleClick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Location = new System.Drawing.Point(86, 799);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(18, 94);
            this.panel2.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pnYellowLamp);
            this.panel1.Controls.Add(this.pnRedLamp);
            this.panel1.Controls.Add(this.pnGreenLamp);
            this.panel1.Location = new System.Drawing.Point(59, 670);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(70, 128);
            this.panel1.TabIndex = 35;
            // 
            // pnYellowLamp
            // 
            this.pnYellowLamp.BackColor = System.Drawing.Color.Yellow;
            this.pnYellowLamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnYellowLamp.Location = new System.Drawing.Point(3, 87);
            this.pnYellowLamp.Name = "pnYellowLamp";
            this.pnYellowLamp.Size = new System.Drawing.Size(60, 36);
            this.pnYellowLamp.TabIndex = 33;
            // 
            // pnRedLamp
            // 
            this.pnRedLamp.BackColor = System.Drawing.Color.Red;
            this.pnRedLamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnRedLamp.Location = new System.Drawing.Point(3, 45);
            this.pnRedLamp.Name = "pnRedLamp";
            this.pnRedLamp.Size = new System.Drawing.Size(60, 36);
            this.pnRedLamp.TabIndex = 32;
            // 
            // pnGreenLamp
            // 
            this.pnGreenLamp.BackColor = System.Drawing.Color.Lime;
            this.pnGreenLamp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnGreenLamp.Location = new System.Drawing.Point(3, 3);
            this.pnGreenLamp.Name = "pnGreenLamp";
            this.pnGreenLamp.Size = new System.Drawing.Size(60, 36);
            this.pnGreenLamp.TabIndex = 31;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Gray;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnInit);
            this.panel3.Controls.Add(this.btnSAVE);
            this.panel3.Controls.Add(this.groupBox3);
            this.panel3.Controls.Add(this.grGreenLamp);
            this.panel3.Controls.Add(this.grYellowLamp);
            this.panel3.Controls.Add(this.grRedLamp);
            this.panel3.Controls.Add(this.lblTitle);
            this.panel3.Location = new System.Drawing.Point(148, 670);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1277, 229);
            this.panel3.TabIndex = 37;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblOffTime);
            this.groupBox3.Controls.Add(this.lblOnTime);
            this.groupBox3.Controls.Add(this.lblBuzzerCount);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(751, 66);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(300, 138);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "RED LAMP";
            // 
            // lblOffTime
            // 
            this.lblOffTime.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOffTime.Location = new System.Drawing.Point(151, 104);
            this.lblOffTime.Name = "lblOffTime";
            this.lblOffTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOffTime.Size = new System.Drawing.Size(77, 24);
            this.lblOffTime.TabIndex = 49;
            this.lblOffTime.Text = "0";
            this.lblOffTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOffTime.Click += new System.EventHandler(this.lblOffTime_Click);
            // 
            // lblOnTime
            // 
            this.lblOnTime.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOnTime.Location = new System.Drawing.Point(151, 67);
            this.lblOnTime.Name = "lblOnTime";
            this.lblOnTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblOnTime.Size = new System.Drawing.Size(77, 25);
            this.lblOnTime.TabIndex = 48;
            this.lblOnTime.Text = "0";
            this.lblOnTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblOnTime.Click += new System.EventHandler(this.lblOnTime_Click);
            // 
            // lblBuzzerCount
            // 
            this.lblBuzzerCount.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuzzerCount.Location = new System.Drawing.Point(151, 29);
            this.lblBuzzerCount.Name = "lblBuzzerCount";
            this.lblBuzzerCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblBuzzerCount.Size = new System.Drawing.Size(77, 25);
            this.lblBuzzerCount.TabIndex = 47;
            this.lblBuzzerCount.Text = "0";
            this.lblBuzzerCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblBuzzerCount.Click += new System.EventHandler(this.lblBuzzerCount_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(234, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 29);
            this.label5.TabIndex = 7;
            this.label5.Text = "ms";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(234, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 29);
            this.label4.TabIndex = 6;
            this.label4.Text = "ms";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(21, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "OFF TIME :";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(21, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "ON TIME :";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(21, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "COUNT :";
            // 
            // grGreenLamp
            // 
            this.grGreenLamp.Controls.Add(this.rdGreenBLINK);
            this.grGreenLamp.Controls.Add(this.rdGreenON);
            this.grGreenLamp.Controls.Add(this.rdGreenOFF);
            this.grGreenLamp.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grGreenLamp.Location = new System.Drawing.Point(499, 66);
            this.grGreenLamp.Name = "grGreenLamp";
            this.grGreenLamp.Size = new System.Drawing.Size(186, 138);
            this.grGreenLamp.TabIndex = 13;
            this.grGreenLamp.TabStop = false;
            this.grGreenLamp.Text = "GREEN LAMP";
            // 
            // rdGreenBLINK
            // 
            this.rdGreenBLINK.ForeColor = System.Drawing.Color.Lime;
            this.rdGreenBLINK.Location = new System.Drawing.Point(13, 99);
            this.rdGreenBLINK.Name = "rdGreenBLINK";
            this.rdGreenBLINK.Size = new System.Drawing.Size(97, 29);
            this.rdGreenBLINK.TabIndex = 2;
            this.rdGreenBLINK.TabStop = true;
            this.rdGreenBLINK.Text = "BLINK";
            this.rdGreenBLINK.UseVisualStyleBackColor = true;
            // 
            // rdGreenON
            // 
            this.rdGreenON.ForeColor = System.Drawing.Color.Lime;
            this.rdGreenON.Location = new System.Drawing.Point(16, 64);
            this.rdGreenON.Name = "rdGreenON";
            this.rdGreenON.Size = new System.Drawing.Size(62, 29);
            this.rdGreenON.TabIndex = 1;
            this.rdGreenON.TabStop = true;
            this.rdGreenON.Text = "ON";
            this.rdGreenON.UseVisualStyleBackColor = true;
            // 
            // rdGreenOFF
            // 
            this.rdGreenOFF.ForeColor = System.Drawing.Color.Lime;
            this.rdGreenOFF.Location = new System.Drawing.Point(16, 29);
            this.rdGreenOFF.Name = "rdGreenOFF";
            this.rdGreenOFF.Size = new System.Drawing.Size(70, 29);
            this.rdGreenOFF.TabIndex = 0;
            this.rdGreenOFF.TabStop = true;
            this.rdGreenOFF.Text = "OFF";
            this.rdGreenOFF.UseVisualStyleBackColor = true;
            // 
            // grYellowLamp
            // 
            this.grYellowLamp.Controls.Add(this.rdYellowBLINK);
            this.grYellowLamp.Controls.Add(this.rdYellowON);
            this.grYellowLamp.Controls.Add(this.rdYellowOFF);
            this.grYellowLamp.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grYellowLamp.Location = new System.Drawing.Point(263, 66);
            this.grYellowLamp.Name = "grYellowLamp";
            this.grYellowLamp.Size = new System.Drawing.Size(186, 138);
            this.grYellowLamp.TabIndex = 12;
            this.grYellowLamp.TabStop = false;
            this.grYellowLamp.Text = "YELLOW LAMP";
            // 
            // rdYellowBLINK
            // 
            this.rdYellowBLINK.ForeColor = System.Drawing.Color.Yellow;
            this.rdYellowBLINK.Location = new System.Drawing.Point(16, 99);
            this.rdYellowBLINK.Name = "rdYellowBLINK";
            this.rdYellowBLINK.Size = new System.Drawing.Size(97, 29);
            this.rdYellowBLINK.TabIndex = 2;
            this.rdYellowBLINK.TabStop = true;
            this.rdYellowBLINK.Text = "BLINK";
            this.rdYellowBLINK.UseVisualStyleBackColor = true;
            // 
            // rdYellowON
            // 
            this.rdYellowON.ForeColor = System.Drawing.Color.Yellow;
            this.rdYellowON.Location = new System.Drawing.Point(16, 64);
            this.rdYellowON.Name = "rdYellowON";
            this.rdYellowON.Size = new System.Drawing.Size(62, 29);
            this.rdYellowON.TabIndex = 1;
            this.rdYellowON.TabStop = true;
            this.rdYellowON.Text = "ON";
            this.rdYellowON.UseVisualStyleBackColor = true;
            // 
            // rdYellowOFF
            // 
            this.rdYellowOFF.ForeColor = System.Drawing.Color.Yellow;
            this.rdYellowOFF.Location = new System.Drawing.Point(16, 29);
            this.rdYellowOFF.Name = "rdYellowOFF";
            this.rdYellowOFF.Size = new System.Drawing.Size(70, 29);
            this.rdYellowOFF.TabIndex = 0;
            this.rdYellowOFF.TabStop = true;
            this.rdYellowOFF.Text = "OFF";
            this.rdYellowOFF.UseVisualStyleBackColor = true;
            // 
            // grRedLamp
            // 
            this.grRedLamp.Controls.Add(this.rdRedBLINK);
            this.grRedLamp.Controls.Add(this.rdRedON);
            this.grRedLamp.Controls.Add(this.rdRedOFF);
            this.grRedLamp.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grRedLamp.Location = new System.Drawing.Point(28, 66);
            this.grRedLamp.Name = "grRedLamp";
            this.grRedLamp.Size = new System.Drawing.Size(186, 138);
            this.grRedLamp.TabIndex = 11;
            this.grRedLamp.TabStop = false;
            this.grRedLamp.Text = "RED LAMP";
            // 
            // rdRedBLINK
            // 
            this.rdRedBLINK.ForeColor = System.Drawing.Color.Red;
            this.rdRedBLINK.Location = new System.Drawing.Point(16, 99);
            this.rdRedBLINK.Name = "rdRedBLINK";
            this.rdRedBLINK.Size = new System.Drawing.Size(92, 29);
            this.rdRedBLINK.TabIndex = 2;
            this.rdRedBLINK.TabStop = true;
            this.rdRedBLINK.Text = "BLINK";
            this.rdRedBLINK.UseVisualStyleBackColor = true;
            // 
            // rdRedON
            // 
            this.rdRedON.ForeColor = System.Drawing.Color.Red;
            this.rdRedON.Location = new System.Drawing.Point(16, 64);
            this.rdRedON.Name = "rdRedON";
            this.rdRedON.Size = new System.Drawing.Size(92, 29);
            this.rdRedON.TabIndex = 1;
            this.rdRedON.TabStop = true;
            this.rdRedON.Text = "ON";
            this.rdRedON.UseVisualStyleBackColor = true;
            // 
            // rdRedOFF
            // 
            this.rdRedOFF.ForeColor = System.Drawing.Color.Red;
            this.rdRedOFF.Location = new System.Drawing.Point(16, 29);
            this.rdRedOFF.Name = "rdRedOFF";
            this.rdRedOFF.Size = new System.Drawing.Size(92, 29);
            this.rdRedOFF.TabIndex = 0;
            this.rdRedOFF.TabStop = true;
            this.rdRedOFF.Text = "OFF";
            this.rdRedOFF.UseVisualStyleBackColor = true;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(28, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblTitle.Size = new System.Drawing.Size(1023, 41);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "00";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInit
            // 
            this.btnInit.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInit.Location = new System.Drawing.Point(1120, 18);
            this.btnInit.Name = "btnInit";
            this.btnInit.Size = new System.Drawing.Size(123, 82);
            this.btnInit.TabIndex = 47;
            this.btnInit.Tag = "1";
            this.btnInit.Text = "DEFAULT";
            this.btnInit.Click += new System.EventHandler(this.btnInit_Click);
            // 
            // btnSAVE
            // 
            this.btnSAVE.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.Location = new System.Drawing.Point(1120, 122);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(123, 82);
            this.btnSAVE.TabIndex = 46;
            this.btnSAVE.Tag = "1";
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // FormDataLampBuzzer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gdLampBuzzer);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDataLampBuzzer";
            this.Load += new System.EventHandler(this.FormDataLampBuzzer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdLampBuzzer)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.grGreenLamp.ResumeLayout(false);
            this.grYellowLamp.ResumeLayout(false);
            this.grRedLamp.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MMI.HmiGrid gdLampBuzzer;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pnYellowLamp;
        private System.Windows.Forms.Panel pnRedLamp;
        private System.Windows.Forms.Panel pnGreenLamp;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox grRedLamp;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grGreenLamp;
        private System.Windows.Forms.RadioButton rdGreenBLINK;
        private System.Windows.Forms.RadioButton rdGreenON;
        private System.Windows.Forms.RadioButton rdGreenOFF;
        private System.Windows.Forms.GroupBox grYellowLamp;
        private System.Windows.Forms.RadioButton rdYellowBLINK;
        private System.Windows.Forms.RadioButton rdYellowON;
        private System.Windows.Forms.RadioButton rdYellowOFF;
        private System.Windows.Forms.RadioButton rdRedBLINK;
        private System.Windows.Forms.RadioButton rdRedON;
        private System.Windows.Forms.RadioButton rdRedOFF;
        private System.Windows.Forms.Label lblOffTime;
        private System.Windows.Forms.Label lblOnTime;
        private System.Windows.Forms.Label lblBuzzerCount;
        private MMI.HmiButton btnInit;
        private MMI.HmiButton btnSAVE;
    }
}