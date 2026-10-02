namespace MMI
{
    partial class FormLog
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
            this.tabLOG = new MMI.HmiTabControl();
            this.tabControlPanel1 = new System.Windows.Forms.TabPage();
            this.lvSEQ = new System.Windows.Forms.ListView();
            this.tabControlPanel2 = new System.Windows.Forms.TabPage();
            this.lvMMI = new System.Windows.Forms.ListView();
            this.tabError = new MMI.HmiTabControl();
            this.tabControlPanel3 = new System.Windows.Forms.TabPage();
            this.lvError = new System.Windows.Forms.ListView();
            this.btnClear1 = new MMI.HmiButton();
            this.btnClear2 = new MMI.HmiButton();
            this.tabLOG.SuspendLayout();
            this.tabControlPanel1.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.tabError.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabLOG
            // 
            this.tabLOG.Controls.Add(this.tabControlPanel1);
            this.tabLOG.Controls.Add(this.tabControlPanel2);
            this.tabLOG.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabLOG.Location = new System.Drawing.Point(29, 17);
            this.tabLOG.Name = "tabLOG";
            this.tabLOG.SelectedIndex =  0;
            this.tabLOG.Size = new System.Drawing.Size(1430, 433);
            this.tabLOG.TabIndex = 5;
            this.tabLOG.Text = "tabControl2";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Controls.Add(this.lvSEQ);
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 36);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Text = "SEQ LOG";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(1430, 397);
            this.tabControlPanel1.TabIndex = 1;
            // 
            // lvSEQ
            // 
            this.lvSEQ.BackColor = System.Drawing.Color.Bisque;
            this.lvSEQ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSEQ.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvSEQ.GridLines = true;
            this.lvSEQ.HideSelection = false;
            this.lvSEQ.Location = new System.Drawing.Point(1, 1);
            this.lvSEQ.Name = "lvSEQ";
            this.lvSEQ.Size = new System.Drawing.Size(1428, 395);
            this.lvSEQ.TabIndex = 3;
            this.lvSEQ.UseCompatibleStateImageBehavior = false;
            this.lvSEQ.View = System.Windows.Forms.View.List;
            // 
            // tabItem1
            // 
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.lvMMI);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 36);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Text = "MMI LOG";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(1430, 397);
            this.tabControlPanel2.TabIndex = 5;
            // 
            // lvMMI
            // 
            this.lvMMI.BackColor = System.Drawing.Color.Bisque;
            this.lvMMI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvMMI.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvMMI.GridLines = true;
            this.lvMMI.HideSelection = false;
            this.lvMMI.Location = new System.Drawing.Point(1, 1);
            this.lvMMI.Name = "lvMMI";
            this.lvMMI.Size = new System.Drawing.Size(1428, 395);
            this.lvMMI.TabIndex = 4;
            this.lvMMI.UseCompatibleStateImageBehavior = false;
            this.lvMMI.View = System.Windows.Forms.View.List;
            // 
            // tabItem2
            // 
            // 
            // tabError
            // 
            this.tabError.Controls.Add(this.tabControlPanel3);
            this.tabError.Font = new System.Drawing.Font("Malgun Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabError.Location = new System.Drawing.Point(30, 470);
            this.tabError.Name = "tabError";
            this.tabError.SelectedIndex =  0;
            this.tabError.Size = new System.Drawing.Size(1430, 433);
            this.tabError.TabIndex = 6;
            this.tabError.Text = "tabControl2";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.lvError);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 36);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Text = "ERROR LOG";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(1430, 397);
            this.tabControlPanel3.TabIndex = 1;
            // 
            // lvError
            // 
            this.lvError.BackColor = System.Drawing.Color.Bisque;
            this.lvError.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvError.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvError.GridLines = true;
            this.lvError.HideSelection = false;
            this.lvError.Location = new System.Drawing.Point(1, 1);
            this.lvError.Name = "lvError";
            this.lvError.Size = new System.Drawing.Size(1428, 395);
            this.lvError.TabIndex = 3;
            this.lvError.UseCompatibleStateImageBehavior = false;
            this.lvError.View = System.Windows.Forms.View.List;
            // 
            // tabItem3
            // 
            // 
            // btnClear1
            // 
            this.btnClear1.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear1.Location = new System.Drawing.Point(1270, 19);
            this.btnClear1.Name = "btnClear1";
            this.btnClear1.Size = new System.Drawing.Size(132, 30);
            this.btnClear1.TabIndex = 29;
            this.btnClear1.Text = "CLEAR";
            this.btnClear1.Click += new System.EventHandler(this.btnClear1_Click);
            // 
            // btnClear2
            // 
            this.btnClear2.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear2.Location = new System.Drawing.Point(1270, 472);
            this.btnClear2.Name = "btnClear2";
            this.btnClear2.Size = new System.Drawing.Size(132, 30);
            this.btnClear2.TabIndex = 30;
            this.btnClear2.Text = "CLEAR";
            this.btnClear2.Click += new System.EventHandler(this.btnClear2_Click);
            // 
            // FormLog
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.btnClear2);
            this.Controls.Add(this.btnClear1);
            this.Controls.Add(this.tabError);
            this.Controls.Add(this.tabLOG);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormLog";
            this.Text = "FormLog";
            this.tabLOG.ResumeLayout(false);
            this.tabControlPanel1.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.tabError.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public MMI.HmiTabControl tabLOG;
        private System.Windows.Forms.TabPage tabControlPanel1;
        private System.Windows.Forms.TabPage tabControlPanel2;
        public System.Windows.Forms.ListView lvMMI;
        public MMI.HmiTabControl tabError;
        private System.Windows.Forms.TabPage tabControlPanel3;
        public System.Windows.Forms.ListView lvError;
        public System.Windows.Forms.ListView lvSEQ;
        private MMI.HmiButton btnClear1;
        private MMI.HmiButton btnClear2;
    }
}