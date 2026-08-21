
namespace MMI
{
    partial class Form_TimeInput
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
            this.lblNum = new DevComponents.DotNetBar.LabelX();
            this.btn_Enter = new System.Windows.Forms.Button();
            this.btn_DEL = new System.Windows.Forms.Button();
            this.btnNO_0 = new System.Windows.Forms.Button();
            this.btn_DOT = new System.Windows.Forms.Button();
            this.btnNO_3 = new System.Windows.Forms.Button();
            this.btnNO_2 = new System.Windows.Forms.Button();
            this.btnNO_1 = new System.Windows.Forms.Button();
            this.btnNO_6 = new System.Windows.Forms.Button();
            this.btnNO_5 = new System.Windows.Forms.Button();
            this.btnNO_4 = new System.Windows.Forms.Button();
            this.btnNO_9 = new System.Windows.Forms.Button();
            this.btnNO_8 = new System.Windows.Forms.Button();
            this.btnNO_7 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblNum
            // 
            this.lblNum.BackColor = System.Drawing.Color.Black;
            // 
            // 
            // 
            this.lblNum.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblNum.Font = new System.Drawing.Font("Thomas Digital", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNum.ForeColor = System.Drawing.Color.Lime;
            this.lblNum.Location = new System.Drawing.Point(2, 3);
            this.lblNum.Name = "lblNum";
            this.lblNum.Size = new System.Drawing.Size(224, 66);
            this.lblNum.TabIndex = 96;
            this.lblNum.Text = "00000000";
            this.lblNum.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // btn_Enter
            // 
            this.btn_Enter.BackColor = System.Drawing.Color.MediumBlue;
            this.btn_Enter.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Enter.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_Enter.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_Enter.Location = new System.Drawing.Point(4, 299);
            this.btn_Enter.Name = "btn_Enter";
            this.btn_Enter.Size = new System.Drawing.Size(224, 50);
            this.btn_Enter.TabIndex = 95;
            this.btn_Enter.Tag = "12";
            this.btn_Enter.Text = "ENTER";
            this.btn_Enter.UseVisualStyleBackColor = false;
            this.btn_Enter.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btn_DEL
            // 
            this.btn_DEL.BackColor = System.Drawing.Color.Brown;
            this.btn_DEL.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DEL.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_DEL.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_DEL.Location = new System.Drawing.Point(158, 243);
            this.btn_DEL.Name = "btn_DEL";
            this.btn_DEL.Size = new System.Drawing.Size(70, 50);
            this.btn_DEL.TabIndex = 93;
            this.btn_DEL.Tag = "11";
            this.btn_DEL.Text = "DEL";
            this.btn_DEL.UseVisualStyleBackColor = false;
            this.btn_DEL.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btnNO_0
            // 
            this.btnNO_0.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNO_0.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO_0.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNO_0.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNO_0.Location = new System.Drawing.Point(81, 243);
            this.btnNO_0.Name = "btnNO_0";
            this.btnNO_0.Size = new System.Drawing.Size(70, 50);
            this.btnNO_0.TabIndex = 92;
            this.btnNO_0.Tag = "0";
            this.btnNO_0.Text = "0";
            this.btnNO_0.UseVisualStyleBackColor = false;
            this.btnNO_0.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btn_DOT
            // 
            this.btn_DOT.BackColor = System.Drawing.SystemColors.ControlText;
            this.btn_DOT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_DOT.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btn_DOT.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btn_DOT.Location = new System.Drawing.Point(4, 243);
            this.btn_DOT.Name = "btn_DOT";
            this.btn_DOT.Size = new System.Drawing.Size(70, 50);
            this.btn_DOT.TabIndex = 91;
            this.btn_DOT.Tag = "10";
            this.btn_DOT.Text = ":";
            this.btn_DOT.UseVisualStyleBackColor = false;
            this.btn_DOT.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btnNO_3
            // 
            this.btnNO_3.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNO_3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO_3.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNO_3.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNO_3.Location = new System.Drawing.Point(158, 187);
            this.btnNO_3.Name = "btnNO_3";
            this.btnNO_3.Size = new System.Drawing.Size(70, 50);
            this.btnNO_3.TabIndex = 90;
            this.btnNO_3.Tag = "3";
            this.btnNO_3.Text = "3";
            this.btnNO_3.UseVisualStyleBackColor = false;
            this.btnNO_3.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btnNO_2
            // 
            this.btnNO_2.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNO_2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO_2.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNO_2.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNO_2.Location = new System.Drawing.Point(81, 187);
            this.btnNO_2.Name = "btnNO_2";
            this.btnNO_2.Size = new System.Drawing.Size(70, 50);
            this.btnNO_2.TabIndex = 89;
            this.btnNO_2.Tag = "2";
            this.btnNO_2.Text = "2";
            this.btnNO_2.UseVisualStyleBackColor = false;
            this.btnNO_2.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btnNO_1
            // 
            this.btnNO_1.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNO_1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO_1.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNO_1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNO_1.Location = new System.Drawing.Point(4, 187);
            this.btnNO_1.Name = "btnNO_1";
            this.btnNO_1.Size = new System.Drawing.Size(70, 50);
            this.btnNO_1.TabIndex = 88;
            this.btnNO_1.Tag = "1";
            this.btnNO_1.Text = "1";
            this.btnNO_1.UseVisualStyleBackColor = false;
            this.btnNO_1.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btnNO_6
            // 
            this.btnNO_6.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNO_6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO_6.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNO_6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNO_6.Location = new System.Drawing.Point(158, 131);
            this.btnNO_6.Name = "btnNO_6";
            this.btnNO_6.Size = new System.Drawing.Size(70, 50);
            this.btnNO_6.TabIndex = 87;
            this.btnNO_6.Tag = "6";
            this.btnNO_6.Text = "6";
            this.btnNO_6.UseVisualStyleBackColor = false;
            this.btnNO_6.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btnNO_5
            // 
            this.btnNO_5.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNO_5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO_5.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNO_5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNO_5.Location = new System.Drawing.Point(81, 131);
            this.btnNO_5.Name = "btnNO_5";
            this.btnNO_5.Size = new System.Drawing.Size(70, 50);
            this.btnNO_5.TabIndex = 86;
            this.btnNO_5.Tag = "5";
            this.btnNO_5.Text = "5";
            this.btnNO_5.UseVisualStyleBackColor = false;
            this.btnNO_5.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btnNO_4
            // 
            this.btnNO_4.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNO_4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO_4.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNO_4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNO_4.Location = new System.Drawing.Point(4, 131);
            this.btnNO_4.Name = "btnNO_4";
            this.btnNO_4.Size = new System.Drawing.Size(70, 50);
            this.btnNO_4.TabIndex = 85;
            this.btnNO_4.Tag = "4";
            this.btnNO_4.Text = "4";
            this.btnNO_4.UseVisualStyleBackColor = false;
            this.btnNO_4.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btnNO_9
            // 
            this.btnNO_9.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNO_9.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO_9.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNO_9.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNO_9.Location = new System.Drawing.Point(158, 75);
            this.btnNO_9.Name = "btnNO_9";
            this.btnNO_9.Size = new System.Drawing.Size(70, 50);
            this.btnNO_9.TabIndex = 84;
            this.btnNO_9.Tag = "9";
            this.btnNO_9.Text = "9";
            this.btnNO_9.UseVisualStyleBackColor = false;
            this.btnNO_9.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btnNO_8
            // 
            this.btnNO_8.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNO_8.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO_8.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNO_8.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNO_8.Location = new System.Drawing.Point(81, 75);
            this.btnNO_8.Name = "btnNO_8";
            this.btnNO_8.Size = new System.Drawing.Size(70, 50);
            this.btnNO_8.TabIndex = 83;
            this.btnNO_8.Tag = "8";
            this.btnNO_8.Text = "8";
            this.btnNO_8.UseVisualStyleBackColor = false;
            this.btnNO_8.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // btnNO_7
            // 
            this.btnNO_7.BackColor = System.Drawing.SystemColors.ControlText;
            this.btnNO_7.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNO_7.Font = new System.Drawing.Font("굴림", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNO_7.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnNO_7.Location = new System.Drawing.Point(4, 75);
            this.btnNO_7.Name = "btnNO_7";
            this.btnNO_7.Size = new System.Drawing.Size(70, 50);
            this.btnNO_7.TabIndex = 82;
            this.btnNO_7.Tag = "7";
            this.btnNO_7.Text = "7";
            this.btnNO_7.UseVisualStyleBackColor = false;
            this.btnNO_7.Click += new System.EventHandler(this.TimeInputClick);
            // 
            // Form_TimeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(227, 355);
            this.Controls.Add(this.lblNum);
            this.Controls.Add(this.btn_Enter);
            this.Controls.Add(this.btn_DEL);
            this.Controls.Add(this.btnNO_0);
            this.Controls.Add(this.btn_DOT);
            this.Controls.Add(this.btnNO_3);
            this.Controls.Add(this.btnNO_2);
            this.Controls.Add(this.btnNO_1);
            this.Controls.Add(this.btnNO_6);
            this.Controls.Add(this.btnNO_5);
            this.Controls.Add(this.btnNO_4);
            this.Controls.Add(this.btnNO_9);
            this.Controls.Add(this.btnNO_8);
            this.Controls.Add(this.btnNO_7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_TimeInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblNum;
        private System.Windows.Forms.Button btn_Enter;
        private System.Windows.Forms.Button btn_DEL;
        private System.Windows.Forms.Button btnNO_0;
        private System.Windows.Forms.Button btn_DOT;
        private System.Windows.Forms.Button btnNO_3;
        private System.Windows.Forms.Button btnNO_2;
        private System.Windows.Forms.Button btnNO_1;
        private System.Windows.Forms.Button btnNO_6;
        private System.Windows.Forms.Button btnNO_5;
        private System.Windows.Forms.Button btnNO_4;
        private System.Windows.Forms.Button btnNO_9;
        private System.Windows.Forms.Button btnNO_8;
        private System.Windows.Forms.Button btnNO_7;
    }
}