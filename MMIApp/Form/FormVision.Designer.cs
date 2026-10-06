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
            this.imgView = new MMI.VisionImageView();
            this.lblPixel = new System.Windows.Forms.Label();
            this.pnlControl = new MMI.HmiCard();
            this.btnGrab = new MMI.HmiButton();
            this.btnSnap = new MMI.HmiButton();
            this.btnFreeze = new MMI.HmiButton();
            this.btnFit = new MMI.HmiButton();
            this.btnLoadImage = new MMI.HmiButton();
            this.btnSaveImage = new MMI.HmiButton();
            this.lblBufferCount = new System.Windows.Forms.Label();
            this.txtBufferCount = new System.Windows.Forms.TextBox();
            this.btnBufferApply = new MMI.HmiButton();
            this.lblCameraTitle = new System.Windows.Forms.Label();
            this.lblCamera = new System.Windows.Forms.Label();
            this.lblStatusTitle = new System.Windows.Forms.Label();
            this.lblVisionStatus = new System.Windows.Forms.Label();
            this.btnConnect = new MMI.HmiButton();
            this.pnlProfile = new MMI.HmiCard();
            this.profileView = new MMI.VisionProfileView();
            this.btnProfileSave = new MMI.HmiButton();
            this.pnlMtf = new MMI.HmiCard();
            this.lblMtfHead1 = new System.Windows.Forms.Label();
            this.lblMtf1 = new System.Windows.Forms.Label();
            this.lblMtfHead2 = new System.Windows.Forms.Label();
            this.lblMtf2 = new System.Windows.Forms.Label();
            this.lblMtfHead3 = new System.Windows.Forms.Label();
            this.lblMtf3 = new System.Windows.Forms.Label();
            this.lblMtfHead4 = new System.Windows.Forms.Label();
            this.lblMtf4 = new System.Windows.Forms.Label();
            this.lblMtfHead5 = new System.Windows.Forms.Label();
            this.lblMtf5 = new System.Windows.Forms.Label();
            this.lblMtfHead6 = new System.Windows.Forms.Label();
            this.lblMtf6 = new System.Windows.Forms.Label();
            this.lblMtfNote = new System.Windows.Forms.Label();
            this.tmrStatus = new System.Windows.Forms.Timer(this.components);
            this.pnlImage.SuspendLayout();
            this.pnlControl.SuspendLayout();
            this.pnlProfile.SuspendLayout();
            this.pnlMtf.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlImage
            // 
            this.pnlImage.Controls.Add(this.lblPixel);
            this.pnlImage.Controls.Add(this.imgView);
            this.pnlImage.Location = new System.Drawing.Point(0, 0);
            this.pnlImage.Size = new System.Drawing.Size(1220, 620);
            this.pnlImage.TitleText = "Image";
            this.pnlImage.Name = "pnlImage";
            // 
            // imgView
            // 
            this.imgView.Location = new System.Drawing.Point(14, 40);
            this.imgView.Size = new System.Drawing.Size(1192, 546);
            this.imgView.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.imgView.Name = "imgView";
            // 
            // lblPixel
            // 
            this.lblPixel.Location = new System.Drawing.Point(14, 590);
            this.lblPixel.Size = new System.Drawing.Size(1192, 24);
            this.lblPixel.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblPixel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblPixel.BackColor = System.Drawing.Color.Transparent;
            this.lblPixel.Text = "";
            this.lblPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPixel.Name = "lblPixel";
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.btnConnect);
            this.pnlControl.Controls.Add(this.lblVisionStatus);
            this.pnlControl.Controls.Add(this.lblStatusTitle);
            this.pnlControl.Controls.Add(this.lblCamera);
            this.pnlControl.Controls.Add(this.lblCameraTitle);
            this.pnlControl.Controls.Add(this.btnBufferApply);
            this.pnlControl.Controls.Add(this.txtBufferCount);
            this.pnlControl.Controls.Add(this.lblBufferCount);
            this.pnlControl.Controls.Add(this.btnSaveImage);
            this.pnlControl.Controls.Add(this.btnLoadImage);
            this.pnlControl.Controls.Add(this.btnFit);
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
            this.btnGrab.Role = MMI.HmiButtonRole.Success;
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // btnSnap
            // 
            this.btnSnap.Location = new System.Drawing.Point(212, 44);
            this.btnSnap.Size = new System.Drawing.Size(186, 56);
            this.btnSnap.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSnap.Text = "SNAP";
            this.btnSnap.Name = "btnSnap";
            this.btnSnap.Click += new System.EventHandler(this.btnSnap_Click);
            // 
            // btnFreeze
            // 
            this.btnFreeze.Location = new System.Drawing.Point(14, 108);
            this.btnFreeze.Size = new System.Drawing.Size(186, 56);
            this.btnFreeze.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFreeze.Text = "FREEZE";
            this.btnFreeze.Role = MMI.HmiButtonRole.Danger;
            this.btnFreeze.Name = "btnFreeze";
            this.btnFreeze.Click += new System.EventHandler(this.btnFreeze_Click);
            // 
            // btnFit
            // 
            this.btnFit.Location = new System.Drawing.Point(212, 108);
            this.btnFit.Size = new System.Drawing.Size(186, 56);
            this.btnFit.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnFit.Text = "FIT";
            this.btnFit.Name = "btnFit";
            this.btnFit.Click += new System.EventHandler(this.btnFit_Click);
            // 
            // btnLoadImage
            // 
            this.btnLoadImage.Location = new System.Drawing.Point(14, 172);
            this.btnLoadImage.Size = new System.Drawing.Size(186, 56);
            this.btnLoadImage.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnLoadImage.Text = "LOAD BMP";
            this.btnLoadImage.Name = "btnLoadImage";
            this.btnLoadImage.Click += new System.EventHandler(this.btnLoadImage_Click);
            // 
            // btnSaveImage
            // 
            this.btnSaveImage.Location = new System.Drawing.Point(212, 172);
            this.btnSaveImage.Size = new System.Drawing.Size(186, 56);
            this.btnSaveImage.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSaveImage.Text = "SAVE BMP";
            this.btnSaveImage.Name = "btnSaveImage";
            this.btnSaveImage.Click += new System.EventHandler(this.btnSaveImage_Click);
            // 
            // lblBufferCount
            // 
            this.lblBufferCount.Location = new System.Drawing.Point(14, 244);
            this.lblBufferCount.Size = new System.Drawing.Size(120, 36);
            this.lblBufferCount.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblBufferCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblBufferCount.BackColor = System.Drawing.Color.Transparent;
            this.lblBufferCount.Text = "Buffers";
            this.lblBufferCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblBufferCount.Name = "lblBufferCount";
            // 
            // txtBufferCount
            // 
            this.txtBufferCount.Location = new System.Drawing.Point(140, 246);
            this.txtBufferCount.Size = new System.Drawing.Size(90, 32);
            this.txtBufferCount.Font = new System.Drawing.Font("Malgun Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBufferCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBufferCount.Text = "8";
            this.txtBufferCount.Name = "txtBufferCount";
            // 
            // btnBufferApply
            // 
            this.btnBufferApply.Location = new System.Drawing.Point(242, 238);
            this.btnBufferApply.Size = new System.Drawing.Size(156, 48);
            this.btnBufferApply.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnBufferApply.Text = "APPLY";
            this.btnBufferApply.Name = "btnBufferApply";
            this.btnBufferApply.Click += new System.EventHandler(this.btnBufferApply_Click);
            // 
            // lblCameraTitle
            // 
            this.lblCameraTitle.Location = new System.Drawing.Point(14, 292);
            this.lblCameraTitle.Size = new System.Drawing.Size(384, 22);
            this.lblCameraTitle.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCameraTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblCameraTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblCameraTitle.Text = "Camera (read only)";
            this.lblCameraTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblCameraTitle.Name = "lblCameraTitle";
            // 
            // lblCamera
            // 
            this.lblCamera.Location = new System.Drawing.Point(14, 314);
            this.lblCamera.Size = new System.Drawing.Size(384, 40);
            this.lblCamera.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblCamera.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblCamera.BackColor = System.Drawing.Color.Transparent;
            this.lblCamera.Text = "-";
            this.lblCamera.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblCamera.Name = "lblCamera";
            // 
            // lblStatusTitle
            // 
            this.lblStatusTitle.Location = new System.Drawing.Point(14, 356);
            this.lblStatusTitle.Size = new System.Drawing.Size(384, 22);
            this.lblStatusTitle.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblStatusTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblStatusTitle.BackColor = System.Drawing.Color.Transparent;
            this.lblStatusTitle.Text = "Status";
            this.lblStatusTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblStatusTitle.Name = "lblStatusTitle";
            // 
            // lblVisionStatus
            // 
            this.lblVisionStatus.Location = new System.Drawing.Point(14, 378);
            this.lblVisionStatus.Size = new System.Drawing.Size(384, 170);
            this.lblVisionStatus.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblVisionStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblVisionStatus.BackColor = System.Drawing.Color.Transparent;
            this.lblVisionStatus.Text = "";
            this.lblVisionStatus.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblVisionStatus.Name = "lblVisionStatus";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(14, 552);
            this.btnConnect.Size = new System.Drawing.Size(384, 52);
            this.btnConnect.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pnlProfile
            // 
            this.pnlProfile.Controls.Add(this.btnProfileSave);
            this.pnlProfile.Controls.Add(this.profileView);
            this.pnlProfile.Location = new System.Drawing.Point(0, 632);
            this.pnlProfile.Size = new System.Drawing.Size(1220, 194);
            this.pnlProfile.TitleText = "Profile (centre line)";
            this.pnlProfile.Name = "pnlProfile";
            // 
            // profileView
            // 
            this.profileView.Location = new System.Drawing.Point(14, 38);
            this.profileView.Size = new System.Drawing.Size(1080, 146);
            this.profileView.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.profileView.Name = "profileView";
            // 
            // btnProfileSave
            // 
            this.btnProfileSave.Location = new System.Drawing.Point(1106, 84);
            this.btnProfileSave.Size = new System.Drawing.Size(100, 52);
            this.btnProfileSave.Font = new System.Drawing.Font("Malgun Gothic", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnProfileSave.Text = "SAVE";
            this.btnProfileSave.Name = "btnProfileSave";
            this.btnProfileSave.Click += new System.EventHandler(this.btnProfileSave_Click);
            // 
            // pnlMtf
            // 
            this.pnlMtf.Controls.Add(this.lblMtfNote);
            this.pnlMtf.Controls.Add(this.lblMtf6);
            this.pnlMtf.Controls.Add(this.lblMtfHead6);
            this.pnlMtf.Controls.Add(this.lblMtf5);
            this.pnlMtf.Controls.Add(this.lblMtfHead5);
            this.pnlMtf.Controls.Add(this.lblMtf4);
            this.pnlMtf.Controls.Add(this.lblMtfHead4);
            this.pnlMtf.Controls.Add(this.lblMtf3);
            this.pnlMtf.Controls.Add(this.lblMtfHead3);
            this.pnlMtf.Controls.Add(this.lblMtf2);
            this.pnlMtf.Controls.Add(this.lblMtfHead2);
            this.pnlMtf.Controls.Add(this.lblMtf1);
            this.pnlMtf.Controls.Add(this.lblMtfHead1);
            this.pnlMtf.Location = new System.Drawing.Point(1232, 632);
            this.pnlMtf.Size = new System.Drawing.Size(412, 194);
            this.pnlMtf.TitleText = "MTF (6 sections, %)";
            this.pnlMtf.Name = "pnlMtf";
            // 
            // lblMtfHead1
            // 
            this.lblMtfHead1.Location = new System.Drawing.Point(14, 44);
            this.lblMtfHead1.Size = new System.Drawing.Size(64, 28);
            this.lblMtfHead1.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtfHead1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblMtfHead1.BackColor = System.Drawing.Color.Transparent;
            this.lblMtfHead1.Text = "S1";
            this.lblMtfHead1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtfHead1.Name = "lblMtfHead1";
            // 
            // lblMtf1
            // 
            this.lblMtf1.Location = new System.Drawing.Point(14, 74);
            this.lblMtf1.Size = new System.Drawing.Size(64, 40);
            this.lblMtf1.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtf1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMtf1.BackColor = System.Drawing.Color.Transparent;
            this.lblMtf1.Text = "-";
            this.lblMtf1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtf1.Name = "lblMtf1";
            this.lblMtf1.Click += new System.EventHandler(this.lblMtf_Click);
            // 
            // lblMtfHead2
            // 
            this.lblMtfHead2.Location = new System.Drawing.Point(78, 44);
            this.lblMtfHead2.Size = new System.Drawing.Size(64, 28);
            this.lblMtfHead2.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtfHead2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblMtfHead2.BackColor = System.Drawing.Color.Transparent;
            this.lblMtfHead2.Text = "S2";
            this.lblMtfHead2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtfHead2.Name = "lblMtfHead2";
            // 
            // lblMtf2
            // 
            this.lblMtf2.Location = new System.Drawing.Point(78, 74);
            this.lblMtf2.Size = new System.Drawing.Size(64, 40);
            this.lblMtf2.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtf2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMtf2.BackColor = System.Drawing.Color.Transparent;
            this.lblMtf2.Text = "-";
            this.lblMtf2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtf2.Name = "lblMtf2";
            this.lblMtf2.Click += new System.EventHandler(this.lblMtf_Click);
            // 
            // lblMtfHead3
            // 
            this.lblMtfHead3.Location = new System.Drawing.Point(142, 44);
            this.lblMtfHead3.Size = new System.Drawing.Size(64, 28);
            this.lblMtfHead3.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtfHead3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblMtfHead3.BackColor = System.Drawing.Color.Transparent;
            this.lblMtfHead3.Text = "S3";
            this.lblMtfHead3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtfHead3.Name = "lblMtfHead3";
            // 
            // lblMtf3
            // 
            this.lblMtf3.Location = new System.Drawing.Point(142, 74);
            this.lblMtf3.Size = new System.Drawing.Size(64, 40);
            this.lblMtf3.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtf3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMtf3.BackColor = System.Drawing.Color.Transparent;
            this.lblMtf3.Text = "-";
            this.lblMtf3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtf3.Name = "lblMtf3";
            this.lblMtf3.Click += new System.EventHandler(this.lblMtf_Click);
            // 
            // lblMtfHead4
            // 
            this.lblMtfHead4.Location = new System.Drawing.Point(206, 44);
            this.lblMtfHead4.Size = new System.Drawing.Size(64, 28);
            this.lblMtfHead4.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtfHead4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblMtfHead4.BackColor = System.Drawing.Color.Transparent;
            this.lblMtfHead4.Text = "S4";
            this.lblMtfHead4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtfHead4.Name = "lblMtfHead4";
            // 
            // lblMtf4
            // 
            this.lblMtf4.Location = new System.Drawing.Point(206, 74);
            this.lblMtf4.Size = new System.Drawing.Size(64, 40);
            this.lblMtf4.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtf4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMtf4.BackColor = System.Drawing.Color.Transparent;
            this.lblMtf4.Text = "-";
            this.lblMtf4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtf4.Name = "lblMtf4";
            this.lblMtf4.Click += new System.EventHandler(this.lblMtf_Click);
            // 
            // lblMtfHead5
            // 
            this.lblMtfHead5.Location = new System.Drawing.Point(270, 44);
            this.lblMtfHead5.Size = new System.Drawing.Size(64, 28);
            this.lblMtfHead5.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtfHead5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblMtfHead5.BackColor = System.Drawing.Color.Transparent;
            this.lblMtfHead5.Text = "S5";
            this.lblMtfHead5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtfHead5.Name = "lblMtfHead5";
            // 
            // lblMtf5
            // 
            this.lblMtf5.Location = new System.Drawing.Point(270, 74);
            this.lblMtf5.Size = new System.Drawing.Size(64, 40);
            this.lblMtf5.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtf5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMtf5.BackColor = System.Drawing.Color.Transparent;
            this.lblMtf5.Text = "-";
            this.lblMtf5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtf5.Name = "lblMtf5";
            this.lblMtf5.Click += new System.EventHandler(this.lblMtf_Click);
            // 
            // lblMtfHead6
            // 
            this.lblMtfHead6.Location = new System.Drawing.Point(334, 44);
            this.lblMtfHead6.Size = new System.Drawing.Size(64, 28);
            this.lblMtfHead6.Font = new System.Drawing.Font("Malgun Gothic", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtfHead6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblMtfHead6.BackColor = System.Drawing.Color.Transparent;
            this.lblMtfHead6.Text = "S6";
            this.lblMtfHead6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtfHead6.Name = "lblMtfHead6";
            // 
            // lblMtf6
            // 
            this.lblMtf6.Location = new System.Drawing.Point(334, 74);
            this.lblMtf6.Size = new System.Drawing.Size(64, 40);
            this.lblMtf6.Font = new System.Drawing.Font("Malgun Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtf6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.lblMtf6.BackColor = System.Drawing.Color.Transparent;
            this.lblMtf6.Text = "-";
            this.lblMtf6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtf6.Name = "lblMtf6";
            this.lblMtf6.Click += new System.EventHandler(this.lblMtf_Click);
            // 
            // lblMtfNote
            // 
            this.lblMtfNote.Location = new System.Drawing.Point(14, 120);
            this.lblMtfNote.Size = new System.Drawing.Size(384, 60);
            this.lblMtfNote.Font = new System.Drawing.Font("Malgun Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMtfNote.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(154)))), ((int)(((byte)(160)))), ((int)(((byte)(166)))));
            this.lblMtfNote.BackColor = System.Drawing.Color.Transparent;
            this.lblMtfNote.Text = "(max - min) / (max + min), 1 % trimmed per section. Touch the values to copy them.";
            this.lblMtfNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblMtfNote.Name = "lblMtfNote";
            // 
            // tmrStatus
            // 
            this.tmrStatus.Interval = 500;
            this.tmrStatus.Tick += new System.EventHandler(this.tmrStatus_Tick);
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
            this.VisibleChanged += new System.EventHandler(this.FormVision_VisibleChanged);
            this.pnlMtf.ResumeLayout(false);
            this.pnlProfile.ResumeLayout(false);
            this.pnlControl.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MMI.HmiCard pnlImage;
        private MMI.VisionImageView imgView;
        private System.Windows.Forms.Label lblPixel;
        private MMI.HmiCard pnlControl;
        private MMI.HmiButton btnGrab;
        private MMI.HmiButton btnSnap;
        private MMI.HmiButton btnFreeze;
        private MMI.HmiButton btnFit;
        private MMI.HmiButton btnLoadImage;
        private MMI.HmiButton btnSaveImage;
        private System.Windows.Forms.Label lblBufferCount;
        private System.Windows.Forms.TextBox txtBufferCount;
        private MMI.HmiButton btnBufferApply;
        private System.Windows.Forms.Label lblCameraTitle;
        private System.Windows.Forms.Label lblCamera;
        private System.Windows.Forms.Label lblStatusTitle;
        private System.Windows.Forms.Label lblVisionStatus;
        private MMI.HmiButton btnConnect;
        private MMI.HmiCard pnlProfile;
        private MMI.VisionProfileView profileView;
        private MMI.HmiButton btnProfileSave;
        private MMI.HmiCard pnlMtf;
        private System.Windows.Forms.Label lblMtfHead1;
        private System.Windows.Forms.Label lblMtf1;
        private System.Windows.Forms.Label lblMtfHead2;
        private System.Windows.Forms.Label lblMtf2;
        private System.Windows.Forms.Label lblMtfHead3;
        private System.Windows.Forms.Label lblMtf3;
        private System.Windows.Forms.Label lblMtfHead4;
        private System.Windows.Forms.Label lblMtf4;
        private System.Windows.Forms.Label lblMtfHead5;
        private System.Windows.Forms.Label lblMtf5;
        private System.Windows.Forms.Label lblMtfHead6;
        private System.Windows.Forms.Label lblMtf6;
        private System.Windows.Forms.Label lblMtfNote;
        private System.Windows.Forms.Timer tmrStatus;
    }
}
