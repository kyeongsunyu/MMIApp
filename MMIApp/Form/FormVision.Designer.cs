namespace MMI
{
    partial class FormVision
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
            this.pnlImage = new MMI.HmiCard();
            this.lblImageNote = new System.Windows.Forms.Label();
            this.pnlControl = new MMI.HmiCard();
            this.btnGrab = new MMI.HmiButton();
            this.btnSnap = new MMI.HmiButton();
            this.btnFreeze = new MMI.HmiButton();
            this.btnBufferOptions = new MMI.HmiButton();
            this.btnLoadImage = new MMI.HmiButton();
            this.btnSaveImage = new MMI.HmiButton();
            this.lblVisionStatus = new System.Windows.Forms.Label();
            this.pnlProfile = new MMI.HmiCard();
            this.lblProfileNote = new System.Windows.Forms.Label();
            this.pnlMtf = new MMI.HmiCard();
            this.lblMtfNote = new System.Windows.Forms.Label();
            this.pnlImage.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.pnlMtf.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.lblImageNote);
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Size = new System.Drawing.Size(1220, 620);
            this.pnlImage.TitleText = "Image";
            this.pnlImage.Name = "pnlImage";
            // 
            // lblImageNote
            // 
            this.lblImageNote.Location = new System.Drawing.Point(14, 40);
            this.lblImageNote.Size = new System.Drawing.Size(1192, 560);
            this.lblImageNote.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblImageNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblImageNote.BackColor = System.Drawing.Color.Transparent;
            this.lblImageNote.Text = "Live image (eGrabber, Coaxlink)\r\nzoom with the wheel, pan by dragging, pixel value under the cursor";
            this.lblImageNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblImageNote.Name = "lblImageNote";
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.lblVisionStatus);
            this.pnlControl.Controls.Add(this.btnSaveImage);
            this.pnlControl.Controls.Add(this.btnLoadImage);
            this.pnlControl.Controls.Add(this.btnBufferOptions);
            this.pnlControl.Controls.Add(this.btnFreeze);
            this.pnlControl.Controls.Add(this.btnSnap);
            this.pnlControl.Controls.Add(this.btnGrab);
            this.pnlControl.Location = new System.Drawing.Point(1232, 0);
            this.pnlControl.Size = new System.Drawing.Size(412, 620);
            this.pnlControl.TitleText = "Acquisition";
            this.pnlControl.Name = "pnlControl";
            // 
            // btnGrab
            // 
            this.btnGrab.Location = new System.Drawing.Point(14, 44);
            this.btnGrab.Size = new System.Drawing.Size(186, 56);
            this.btnGrab.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnGrab.Text = "GRAB";
            this.btnGrab.Enabled = false;
            this.btnGrab.Name = "btnGrab";
            // 
            // btnSnap
            // 
            this.btnSnap.Location = new System.Drawing.Point(212, 44);
            this.btnSnap.Size = new System.Drawing.Size(186, 56);
            this.btnSnap.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSnap.Text = "SNAP";
            this.btnSnap.Enabled = false;
            this.btnSnap.Name = "btnSnap";
            // 
            // btnFreeze
            // 
            this.btnFreeze.Location = new System.Drawing.Point(14, 110);
            this.btnFreeze.Size = new System.Drawing.Size(186, 56);
            this.btnFreeze.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFreeze.Text = "FREEZE";
            this.btnFreeze.Enabled = false;
            this.btnFreeze.Name = "btnFreeze";
            // 
            // btnBufferOptions
            // 
            this.btnBufferOptions.Location = new System.Drawing.Point(212, 110);
            this.btnBufferOptions.Size = new System.Drawing.Size(186, 56);
            this.btnBufferOptions.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBufferOptions.Text = "BUFFER";
            this.btnBufferOptions.Enabled = false;
            this.btnBufferOptions.Name = "btnBufferOptions";
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(14, 176);
            this.btnLoadImage.Size = new System.Drawing.Size(186, 56);
            this.btnLoadImage.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadImage.Text = "LOAD BMP";
            this.btnLoadImage.Enabled = false;
            this.btnLoadImage.Name = "btnLoadImage";
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(212, 176);
            this.btnSaveImage.Size = new System.Drawing.Size(186, 56);
            this.btnSaveImage.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSaveImage.Text = "SAVE BMP";
            this.btnSaveImage.Enabled = false;
            this.btnSaveImage.Name = "btnSaveImage";
            // 
            // lblVisionStatus
            // 
            this.lblVisionStatus.Location = new System.Drawing.Point(14, 250);
            this.lblVisionStatus.Size = new System.Drawing.Size(384, 60);
            this.lblVisionStatus.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVisionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblVisionStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblVisionStatus.Text = "Not connected. The GrabDemo migration is pending.";
            this.lblVisionStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblVisionStatus.Name = "lblVisionStatus";
            // 
            // pnlProfile
            // 
            this.pnlProfile.Controls.Add(this.lblProfileNote);
            this.pnlProfile.Location = new System.Drawing.Point(0, 632);
            this.pnlProfile.Size = new System.Drawing.Size(1220, 194);
            this.pnlProfile.TitleText = "Profile (centre line)";
            this.pnlProfile.Name = "pnlProfile";
            // 
            // lblProfileNote
            // 
            this.lblProfileNote.Location = new System.Drawing.Point(14, 40);
            this.lblProfileNote.Size = new System.Drawing.Size(1192, 140);
            this.lblProfileNote.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblProfileNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblProfileNote.BackColor = System.Drawing.Color.Transparent;
            this.lblProfileNote.Text = "Grey level along the centre line";
            this.lblProfileNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblProfileNote.Name = "lblProfileNote";
            // 
            // pnlMtf
            // 
            this.pnlMtf.Controls.Add(this.lblMtfNote);
            this.pnlMtf.Location = new System.Drawing.Point(1232, 632);
            this.pnlMtf.Size = new System.Drawing.Size(412, 194);
            this.pnlMtf.TitleText = "MTF (6 sections, %)";
            this.pnlMtf.Name = "pnlMtf";
            // 
            // lblMtfNote
            // 
            this.lblMtfNote.Location = new System.Drawing.Point(14, 40);
            this.lblMtfNote.Size = new System.Drawing.Size(384, 140);
            this.lblMtfNote.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtfNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblMtfNote.BackColor = System.Drawing.Color.Transparent;
            this.lblMtfNote.Text = "(max - min) / (max + min), 1 % trimmed per section";
            this.lblMtfNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtfNote.Name = "lblMtfNote";
            // 
            // FormVision
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(29)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(1644, 826);
            this.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Text = "FormVision";
            this.Controls.Add(this.pnlMtf);
            this.Controls.Add(this.pnlProfile);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.pnlImage);
            this.Name = "FormVision";
            this.pnlMtf.ResumeLayout(false);
            this.pnlProfile.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MMI.HmiCard pnlImage;
        private System.Windows.Forms.Label lblImageNote;
        private MMI.HmiCard pnlControl;
        private MMI.HmiButton btnGrab;
        private MMI.HmiButton btnSnap;
        private MMI.HmiButton btnFreeze;
        private MMI.HmiButton btnBufferOptions;
        private MMI.HmiButton btnLoadImage;
        private MMI.HmiButton btnSaveImage;
        private System.Windows.Forms.Label lblVisionStatus;
        private MMI.HmiCard pnlProfile;
        private System.Windows.Forms.Label lblProfileNote;
        private MMI.HmiCard pnlMtf;
        private System.Windows.Forms.Label lblMtfNote;
    }
}
