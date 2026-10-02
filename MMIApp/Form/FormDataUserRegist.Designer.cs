namespace MMI
{
    partial class FormDataUserRegist
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataUserRegist));
            this.gdUser = new MMI.HmiGrid();
            this.grSelectLevel = new System.Windows.Forms.GroupBox();
            this.rdMaster = new System.Windows.Forms.RadioButton();
            this.rdEngineer = new System.Windows.Forms.RadioButton();
            this.rdMaintenance = new System.Windows.Forms.RadioButton();
            this.rdOperator = new System.Windows.Forms.RadioButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.labelX1 = new System.Windows.Forms.Label();
            this.txtConfirm = new System.Windows.Forms.TextBox();
            this.btnDelete = new MMI.HmiButton();
            this.btnSAVE = new MMI.HmiButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdUser)).BeginInit();
            this.grSelectLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // gdUser
            // 
            this.gdUser.ColumnInfo = resources.GetString("gdUser.ColumnInfo");
            this.gdUser.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.gdUser.Location = new System.Drawing.Point(59, 32);
            this.gdUser.Name = "gdUser";
            this.gdUser.Rows.Count = 100;
            this.gdUser.Rows.DefaultSize = 30;
            this.gdUser.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.gdUser.Size = new System.Drawing.Size(408, 874);
            this.gdUser.TabIndex = 29;
            this.gdUser.Click += new System.EventHandler(this.gdUser_Click);
            // 
            // grSelectLevel
            // 
            this.grSelectLevel.Controls.Add(this.rdMaster);
            this.grSelectLevel.Controls.Add(this.rdEngineer);
            this.grSelectLevel.Controls.Add(this.rdMaintenance);
            this.grSelectLevel.Controls.Add(this.rdOperator);
            this.grSelectLevel.Font = new System.Drawing.Font("Malgun Gothic", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grSelectLevel.Location = new System.Drawing.Point(548, 114);
            this.grSelectLevel.Name = "grSelectLevel";
            this.grSelectLevel.Size = new System.Drawing.Size(498, 259);
            this.grSelectLevel.TabIndex = 30;
            this.grSelectLevel.TabStop = false;
            this.grSelectLevel.Text = "SELECT LEVEL";
            // 
            // rdMaster
            // 
            this.rdMaster.AutoSize = true;
            this.rdMaster.Location = new System.Drawing.Point(36, 208);
            this.rdMaster.Name = "rdMaster";
            this.rdMaster.Size = new System.Drawing.Size(130, 33);
            this.rdMaster.TabIndex = 3;
            this.rdMaster.TabStop = true;
            this.rdMaster.Tag = "4";
            this.rdMaster.Text = "MASTER";
            this.rdMaster.UseVisualStyleBackColor = true;
            this.rdMaster.Click += new System.EventHandler(this.rdLevelClick);
            // 
            // rdEngineer
            // 
            this.rdEngineer.AutoSize = true;
            this.rdEngineer.Location = new System.Drawing.Point(36, 154);
            this.rdEngineer.Name = "rdEngineer";
            this.rdEngineer.Size = new System.Drawing.Size(161, 33);
            this.rdEngineer.TabIndex = 2;
            this.rdEngineer.TabStop = true;
            this.rdEngineer.Tag = "3";
            this.rdEngineer.Text = "ENGINEER";
            this.rdEngineer.UseVisualStyleBackColor = true;
            this.rdEngineer.Click += new System.EventHandler(this.rdLevelClick);
            // 
            // rdMaintenance
            // 
            this.rdMaintenance.AutoSize = true;
            this.rdMaintenance.Location = new System.Drawing.Point(36, 100);
            this.rdMaintenance.Name = "rdMaintenance";
            this.rdMaintenance.Size = new System.Drawing.Size(214, 33);
            this.rdMaintenance.TabIndex = 1;
            this.rdMaintenance.TabStop = true;
            this.rdMaintenance.Tag = "2";
            this.rdMaintenance.Text = "MAINTENANCE";
            this.rdMaintenance.UseVisualStyleBackColor = true;
            this.rdMaintenance.Click += new System.EventHandler(this.rdLevelClick);
            // 
            // rdOperator
            // 
            this.rdOperator.AutoSize = true;
            this.rdOperator.Location = new System.Drawing.Point(36, 46);
            this.rdOperator.Name = "rdOperator";
            this.rdOperator.Size = new System.Drawing.Size(163, 33);
            this.rdOperator.TabIndex = 0;
            this.rdOperator.TabStop = true;
            this.rdOperator.Tag = "1";
            this.rdOperator.Text = "OPERATOR";
            this.rdOperator.UseVisualStyleBackColor = true;
            this.rdOperator.Click += new System.EventHandler(this.rdLevelClick);
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(548, 400);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblTitle.Size = new System.Drawing.Size(267, 33);
            this.lblTitle.TabIndex = 31;
            this.lblTitle.Text = "NEW PASSWORD";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPassword.Location = new System.Drawing.Point(835, 400);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(211, 33);
            this.txtPassword.TabIndex = 32;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // labelX1
            // 
            this.labelX1.Font = new System.Drawing.Font("Malgun Gothic", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelX1.Location = new System.Drawing.Point(548, 439);
            this.labelX1.Name = "labelX1";
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.labelX1.Size = new System.Drawing.Size(267, 33);
            this.labelX1.TabIndex = 33;
            this.labelX1.Text = "CONFIRM PASSWORD";
            // 
            // txtConfirm
            // 
            this.txtConfirm.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConfirm.Location = new System.Drawing.Point(835, 439);
            this.txtConfirm.Name = "txtConfirm";
            this.txtConfirm.PasswordChar = '*';
            this.txtConfirm.Size = new System.Drawing.Size(211, 33);
            this.txtConfirm.TabIndex = 34;
            this.txtConfirm.TextChanged += new System.EventHandler(this.txtConfirm_TextChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(548, 517);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(192, 66);
            this.btnDelete.TabIndex = 47;
            this.btnDelete.Tag = "1";
            this.btnDelete.Text = "DELETE";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSAVE
            // 
            this.btnSAVE.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSAVE.Location = new System.Drawing.Point(854, 517);
            this.btnSAVE.Name = "btnSAVE";
            this.btnSAVE.Size = new System.Drawing.Size(192, 66);
            this.btnSAVE.TabIndex = 46;
            this.btnSAVE.Tag = "1";
            this.btnSAVE.Text = "SAVE";
            this.btnSAVE.Click += new System.EventHandler(this.btnSAVE_Click);
            // 
            // FormDataUserRegist
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1480, 930);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnSAVE);
            this.Controls.Add(this.txtConfirm);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.grSelectLevel);
            this.Controls.Add(this.gdUser);
            this.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormDataUserRegist";
            this.Text = "FormDataUserRegist";
            this.Load += new System.EventHandler(this.FormDataUserRegist_Load);
            this.Shown += new System.EventHandler(this.FormDataUserRegist_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gdUser)).EndInit();
            this.grSelectLevel.ResumeLayout(false);
            this.grSelectLevel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MMI.HmiGrid gdUser;
        private System.Windows.Forms.GroupBox grSelectLevel;
        private System.Windows.Forms.RadioButton rdOperator;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label labelX1;
        private System.Windows.Forms.TextBox txtConfirm;
        private System.Windows.Forms.RadioButton rdMaster;
        private System.Windows.Forms.RadioButton rdEngineer;
        private System.Windows.Forms.RadioButton rdMaintenance;
        private MMI.HmiButton btnDelete;
        private MMI.HmiButton btnSAVE;
    }
}