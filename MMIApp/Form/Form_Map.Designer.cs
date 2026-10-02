
namespace MMI
{
    partial class Form_Map
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
            this.MapView = new Mapping.StripMapViewer();
            this.cbMap = new System.Windows.Forms.ComboBox();
            this.btnClose = new MMI.HmiButton();
            this.btnApply = new MMI.HmiButton();
            this.btnAllEmpty = new MMI.HmiButton();
            this.btnAllExist = new MMI.HmiButton();
            this.SuspendLayout();
            // 
            // MapView
            // 
            this.MapView.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.MapView.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.MapView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MapView.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MapView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MapView.IndicatorColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
            this.MapView.Location = new System.Drawing.Point(9, 80);
            this.MapView.Margin = new System.Windows.Forms.Padding(0);
            this.MapView.Name = "MapView";
            this.MapView.SelectedColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.MapView.SelectedUnitState = null;
            this.MapView.SelectionColor = System.Drawing.Color.LightCoral;
            this.MapView.Size = new System.Drawing.Size(324, 429);
            this.MapView.TabIndex = 169;
            this.MapView.WorkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            // 
            // cbMap
            // 
            this.cbMap.DisplayMember = "Text";
            this.cbMap.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMap.Font = new System.Drawing.Font("Malgun Gothic", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbMap.FormattingEnabled = true;
            this.cbMap.Location = new System.Drawing.Point(9, 21);
            this.cbMap.Name = "cbMap";
            this.cbMap.Size = new System.Drawing.Size(324, 36);
            this.cbMap.TabIndex = 170;
            this.cbMap.SelectedIndexChanged += new System.EventHandler(this.cbMap_SelectedIndexChanged);
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(364, 469);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(171, 40);
            this.btnClose.TabIndex = 171;
            this.btnClose.Text = "CLOSE";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.Location = new System.Drawing.Point(364, 411);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(171, 40);
            this.btnApply.TabIndex = 172;
            this.btnApply.Text = "APPLY";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // btnAllEmpty
            // 
            this.btnAllEmpty.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllEmpty.Location = new System.Drawing.Point(364, 80);
            this.btnAllEmpty.Name = "btnAllEmpty";
            this.btnAllEmpty.Size = new System.Drawing.Size(171, 40);
            this.btnAllEmpty.TabIndex = 173;
            this.btnAllEmpty.Text = "ALL EMPTY";
            this.btnAllEmpty.Click += new System.EventHandler(this.btnAllEmpty_Click);
            // 
            // btnAllExist
            // 
            this.btnAllExist.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAllExist.Location = new System.Drawing.Point(364, 138);
            this.btnAllExist.Name = "btnAllExist";
            this.btnAllExist.Size = new System.Drawing.Size(171, 40);
            this.btnAllExist.TabIndex = 174;
            this.btnAllExist.Text = "ALL EXIST";
            this.btnAllExist.Click += new System.EventHandler(this.btnAllExist_Click);
            // 
            // Form_Map
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(563, 538);
            this.Controls.Add(this.btnAllExist);
            this.Controls.Add(this.btnAllEmpty);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.cbMap);
            this.Controls.Add(this.MapView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Map";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Map";
            this.Load += new System.EventHandler(this.Form_Map_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Map_Paint);
            this.ResumeLayout(false);

        }

        #endregion

        private Mapping.StripMapViewer MapView;
        private System.Windows.Forms.ComboBox cbMap;
        public MMI.HmiButton btnClose;
        public MMI.HmiButton btnApply;
        public MMI.HmiButton btnAllEmpty;
        public MMI.HmiButton btnAllExist;
    }
}