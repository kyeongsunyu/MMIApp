using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;

namespace MMI
{
    // Auto > VISION (screen 13, engineer level).
    //
    // GrabDemo, the eGrabber (Coaxlink, CoaXPress) line scan viewer, migrated
    // from MFC:
    //   GRAB / SNAP / FREEZE   continuous, one frame, stop
    //   image                  wheel zoom about the cursor, drag to pan,
    //                          double click (or FIT) to fit, pixel value under
    //                          the cursor
    //   profile                grey level along the centre line; SAVE writes it
    //                          as text, one value per line
    //   MTF                    six sections of the centre line; touching the
    //                          values copies them
    //   NEW                    clears the image, the profile and the MTF
    //   LOAD / SAVE BMP        8 bit grey
    //   Buffers                the grabber's buffer ring
    //   SCAN LINK / A / B      the camera takes the lines of a TRIGGER scan,
    //                          trigger wired through the grabber (A) or
    //                          straight into the camera (B); see
    //                          FormVision.Scan.cs
    //
    // The camera settings are not touched: the camera runs as it is set up
    // (see VisionGrabber). Its geometry and pixel format are shown read only.
    //
    // The grabber is opened the first time the screen is shown. Without a
    // board, a camera or the eGrabber runtime the screen stays usable offline
    // (BMP files) and the status says what is missing; CONNECT tries again.
    // Leaving the screen freezes a running GRAB, not an armed scan.
    public partial class FormVision : Form
    {
        // Minimum spacing of the profile and MTF updates during a GRAB.
        private const int AnalysisPeriodMs = 120;
        // How long after GRAB / SNAP before "no frames" is a problem rather
        // than a slow first frame.
        private const int NoFrameWarnMs = 3000;

        private FormMain frmMain = null;

        private VisionGrabber grabber;
        private bool bTriedOpen;
        private string strOpenError = "";
        private byte[] frame = new byte[0];
        private int nTickLastAnalysis;
        private int nTickStart;
        private bool bWaitingFirstFrame;
        private readonly double[] mtf = new double[VisionAnalysis.Sections];
        private bool bHaveMtf;
        private string strImageSource = "";

        public FormVision()
        {
            InitializeComponent();
            Init();
        }

        public FormVision(FormMain frm)
        {
            InitializeComponent();
            this.frmMain = frm;
            Init();
        }

        private void Init()
        {
            imgView.PixelChanged += ImgView_PixelChanged;
            CLanguage.Changed += (s, e) => { ShowCamera(); ShowStatus(); };
            InitScanLink();
            UpdateButtons();
            ShowCamera();
            ShowStatus();
        }

        private void FormVision_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                if (!bTriedOpen) Connect();
                tmrStatus.Start();
            }
            else
            {
                tmrStatus.Stop();
                if (grabber != null && grabber.IsGrabbing && !bScanArmed) Freeze();
            }
        }

        // ---------------------------------------------------------------------
        // grabber

        private void Connect()
        {
            bTriedOpen = true;
            CloseCamera();

            Cursor = Cursors.WaitCursor;
            try
            {
                string strError;
                grabber = OpenGrabber(out strError);
                strOpenError = grabber == null ? strError : "";
            }
            catch (Exception ex) when (ex is FileNotFoundException || ex is TypeLoadException || ex is BadImageFormatException)
            {
                // EGrabber.NETFramework.dll or its native part is missing
                grabber = null;
                strOpenError = CLanguage.Text("The eGrabber runtime is not installed on this PC.") + "\n" + ex.Message;
            }
            catch (Exception ex)
            {
                grabber = null;
                strOpenError = ex.Message;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

            if (grabber != null)
            {
                grabber.FrameReady += Grabber_FrameReady;
                grabber.Stopped += Grabber_Stopped;
                txtBufferCount.Text = grabber.BufferCount.ToString();
            }
            bWiringApplied = false;
            RefreshLink();
            UpdateButtons();
            ShowCamera();
            ShowStatus();
        }

        // Separate and not inlined, so that a missing eGrabber assembly fails
        // here, inside Connect's try, and not when Connect itself is compiled.
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static VisionGrabber OpenGrabber(out string strError)
        {
            return VisionGrabber.Open(out strError);
        }

        // On program exit: the grabber closed and SEQ no longer waiting for it.
        public void Shutdown()
        {
            if (tmrLink != null) tmrLink.Stop();
            CloseCamera();
            if (bSeqTookLink) SendLink(false, 0, 0);
            bSeqTookLink = false;
        }

        // Before a reconnect, and from Shutdown.
        public void CloseCamera()
        {
            if (grabber == null) return;
            grabber.FrameReady -= Grabber_FrameReady;
            grabber.Stopped -= Grabber_Stopped;
            if (bScanArmed) { bScanArmed = false; SendLink(true, 0, 0); }
            grabber.Dispose();
            grabber = null;
            bWiringApplied = false;
        }

        private void Grabber_FrameReady()
        {
            if (IsHandleCreated && !IsDisposed)
            {
                try { BeginInvoke((Action)ShowFrame); } catch (InvalidOperationException) { }
            }
        }

        private void Grabber_Stopped()
        {
            if (IsHandleCreated && !IsDisposed)
            {
                try { BeginInvoke((Action)AcquisitionEnded); } catch (InvalidOperationException) { }
            }
        }

        private void ShowFrame()
        {
            if (grabber == null) return;

            int w, h;
            if (!grabber.TakeFrame(ref frame, out w, out h)) return;

            bWaitingFirstFrame = false;
            strImageSource = CLanguage.Text("camera");
            imgView.Live = grabber.IsGrabbing;
            imgView.SetImage(frame, w, h);
            // paint now: WM_PAINT is the lowest priority message and would
            // keep being put off while frames arrive
            imgView.Update();

            int nNow = Environment.TickCount;
            if (!grabber.IsGrabbing || unchecked(nNow - nTickLastAnalysis) >= AnalysisPeriodMs)
            {
                nTickLastAnalysis = nNow;
                Analyse();
            }
        }

        private void AcquisitionEnded()
        {
            // the frame of a SNAP, or the last one of a GRAB, gets its analysis
            // and the still image quality
            imgView.Live = false;
            imgView.Invalidate();
            if (imgView.HasImage) Analyse();
            bWaitingFirstFrame = false;
            if (bScanArmed && grabber != null && grabber.FramesDisplayed > 0) ScanFrameArrived();
            UpdateButtons();
            ShowStatus();
        }

        private void StartAcquisition(int nFrames)
        {
            if (grabber == null || grabber.IsGrabbing) return;
            // a GRAB or SNAP of its own takes frames, not a scan's worth of lines
            grabber.RestoreBuffer();
            if (grabber.Start(nFrames))
            {
                nTickStart = Environment.TickCount;
                bWaitingFirstFrame = true;
            }
            UpdateButtons();
            ShowStatus();
        }

        private void Freeze()
        {
            if (grabber == null) return;
            grabber.Stop();
            if (bScanArmed)
            {
                // SEQ must not scan for a grabber that is no longer taking
                bScanArmed = false;
                SendLink(true, 0, 0);
                strScanResult = CLanguage.Text("Scan: cancelled");
                bScanWarn = true;
            }
            UpdateButtons();
            ShowStatus();
        }

        // ---------------------------------------------------------------------
        // analysis

        private void Analyse()
        {
            byte[] line = VisionAnalysis.CentreLine(imgView.Pixels, imgView.ImageWidth, imgView.ImageHeight);
            profileView.SetLine(line);

            double[] r = VisionAnalysis.Mtf(line);
            bHaveMtf = r != null;
            for (int i = 0; i < VisionAnalysis.Sections; i++)
            {
                mtf[i] = r != null ? r[i] : 0;
                Label lbl = MtfLabel(i);
                string s = r != null ? r[i].ToString("0.00") : "-";
                if (lbl.Text != s) lbl.Text = s;
            }
        }

        private Label MtfLabel(int i)
        {
            switch (i)
            {
                case 0: return lblMtf1;
                case 1: return lblMtf2;
                case 2: return lblMtf3;
                case 3: return lblMtf4;
                case 4: return lblMtf5;
                default: return lblMtf6;
            }
        }

        // ---------------------------------------------------------------------
        // buttons

        private void btnGrab_Click(object sender, EventArgs e)
        {
            StartAcquisition(0);
        }

        private void btnSnap_Click(object sender, EventArgs e)
        {
            StartAcquisition(1);
        }

        private void btnFreeze_Click(object sender, EventArgs e)
        {
            Freeze();
        }

        private void btnFit_Click(object sender, EventArgs e)
        {
            imgView.FitToWindow();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        private void btnBufferApply_Click(object sender, EventArgs e)
        {
            if (grabber == null) return;

            int n;
            if (!int.TryParse(txtBufferCount.Text.Trim(), out n) || n < 2 || n > 256)
            {
                MessageBox.Show(CLanguage.Format("Enter a value from {0} to {1}.", 2, 256), Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBufferCount.Text = grabber.BufferCount.ToString();
                return;
            }

            // the ring is reallocated with the acquisition stopped, then the
            // GRAB goes on
            bool bWasGrabbing = grabber.IsGrabbing;
            if (bWasGrabbing) Freeze();
            grabber.RestoreBuffer();

            string strError;
            if (!grabber.SetBufferCount(n, out strError))
            {
                MessageBox.Show(CLanguage.Text("The buffers could not be allocated.") + "\n" + strError, Text,
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            txtBufferCount.Text = grabber.BufferCount.ToString();
            ShowCamera();

            if (bWasGrabbing) StartAcquisition(0);
            UpdateButtons();
            ShowStatus();
        }

        // GrabDemo's FILE NEW: an empty view, as before the first frame.
        private void btnNewImage_Click(object sender, EventArgs e)
        {
            if (grabber != null && grabber.IsGrabbing) Freeze();

            imgView.Clear();
            frame = new byte[0];
            strImageSource = "";
            lblPixel.Text = "";
            profileView.SetLine(null);
            bHaveMtf = false;
            for (int i = 0; i < VisionAnalysis.Sections; i++)
            {
                mtf[i] = 0;
                MtfLabel(i).Text = "-";
            }
            UpdateButtons();
            ShowStatus();
        }

        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            if (grabber != null && grabber.IsGrabbing) Freeze();

            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Bitmap (*.bmp)|*.bmp|" + CLanguage.Text("All images") + "|*.bmp;*.png;*.tif;*.tiff;*.jpg|*.*|*.*";
                dlg.InitialDirectory = ImageFolder();
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    int w, h;
                    byte[] data = VisionAnalysis.LoadGrey(dlg.FileName, out w, out h);
                    frame = data;
                    imgView.Live = false;
                    imgView.SetImage(frame, w, h);
                    imgView.FitToWindow();
                    strImageSource = Path.GetFileName(dlg.FileName);
                    Analyse();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(CLanguage.Text("The image could not be opened.") + "\n" + ex.Message, Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            UpdateButtons();
            ShowStatus();
        }

        private void btnSaveImage_Click(object sender, EventArgs e)
        {
            if (!imgView.HasImage) return;
            if (grabber != null && grabber.IsGrabbing) Freeze();

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Bitmap (*.bmp)|*.bmp";
                dlg.InitialDirectory = ImageFolder();
                dlg.FileName = "VISION_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".bmp";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    imgView.SaveBmp(dlg.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(CLanguage.Text("The image could not be saved.") + "\n" + ex.Message, Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnProfileSave_Click(object sender, EventArgs e)
        {
            byte[] line = profileView.Line;
            if (line.Length == 0) return;
            if (grabber != null && grabber.IsGrabbing) Freeze();

            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = "Text (*.txt)|*.txt|CSV (*.csv)|*.csv";
                dlg.InitialDirectory = ImageFolder();
                dlg.FileName = "PROFILE_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";
                if (dlg.ShowDialog(this) != DialogResult.OK) return;

                try
                {
                    StringBuilder sb = new StringBuilder(line.Length * 5);
                    foreach (byte v in line) sb.Append(v).Append("\r\n");
                    File.WriteAllText(dlg.FileName, sb.ToString());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(CLanguage.Text("The profile could not be saved.") + "\n" + ex.Message, Text,
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        // The six values, tab separated, for a spreadsheet.
        private void lblMtf_Click(object sender, EventArgs e)
        {
            if (!bHaveMtf) return;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < VisionAnalysis.Sections; i++)
            {
                if (i > 0) sb.Append('\t');
                sb.Append(mtf[i].ToString("0.00"));
            }
            sb.Append("\r\n");
            try
            {
                Clipboard.SetText(sb.ToString());
                lblMtfNote.Text = CLanguage.Text("MTF copied to the clipboard.");
            }
            catch (Exception) { }
        }

        private static string ImageFolder()
        {
            string path = Path.Combine(Application.StartupPath, "VisionImage");
            try { Directory.CreateDirectory(path); } catch (Exception) { }
            return path;
        }

        // ---------------------------------------------------------------------
        // display

        private void UpdateButtons()
        {
            bool bOnline = grabber != null;
            bool bGrabbing = bOnline && grabber.IsGrabbing;

            btnGrab.Enabled = bOnline && !bGrabbing;
            btnSnap.Enabled = bOnline && !bGrabbing;
            btnFreeze.Enabled = bGrabbing;
            btnBufferApply.Enabled = bOnline;
            txtBufferCount.ReadOnly = !bOnline;
            btnConnect.Enabled = !bGrabbing;
            btnScanLink.Enabled = !bScanArmed;
            btnWiringA.Enabled = !bScanArmed;
            btnWiringB.Enabled = !bScanArmed;
            btnLoadImage.Enabled = !bScanArmed;
            btnSaveImage.Enabled = imgView.HasImage;
            btnNewImage.Enabled = imgView.HasImage;
            btnFit.Enabled = imgView.HasImage;
        }

        private void ShowCamera()
        {
            if (grabber == null)
            {
                lblCamera.Text = "-";
                return;
            }
            string name = grabber.DeviceName.Length > 0 ? grabber.DeviceName + "   " : "";
            lblCamera.Text = name + CLanguage.Format("{0} x {1}  {2}", grabber.CameraWidth, grabber.CameraHeight, grabber.PixelFormat)
                           + "\n" + CLanguage.Format("Buffers: {0}", grabber.BufferCount);
        }

        private void ShowStatus()
        {
            StringBuilder sb = new StringBuilder();
            string link = LinkStatusLine();
            if (grabber == null)
            {
                sb.Append(CLanguage.Text("Offline. BMP files can be opened."));
                if (link.Length > 0) sb.Append("\n").Append(link);
                if (strOpenError.Length > 0) sb.Append("\n").Append(strOpenError);
                lblVisionStatus.ForeColor = bTriedOpen ? HmiTheme.Warning : HmiTheme.TextMuted;
                lblVisionStatus.Text = sb.ToString();
                return;
            }

            bool bGrabbing = grabber.IsGrabbing;
            sb.Append(bScanArmed ? CLanguage.Text("Waiting for the scan") : bGrabbing ? CLanguage.Text("Grabbing") : CLanguage.Text("Stopped"));
            if (strImageSource.Length > 0) sb.Append("   ").Append(CLanguage.Format("Image: {0}", strImageSource));
            sb.Append("\n").Append(CLanguage.Format("Received {0}   Displayed {1}   Rejected {2}",
                                                    grabber.FramesReceived, grabber.FramesDisplayed, grabber.FramesRejected));
            string fmt = grabber.LastFormat;
            if (fmt.Length > 0) sb.Append("\n").Append(CLanguage.Format("Last frame: {0}", fmt));

            bool bWarn = false;
            if (link.Length > 0) sb.Append("\n").Append(link);
            if (strLinkError.Length > 0) { sb.Append("\n").Append(strLinkError); bWarn = true; }
            if (strScanResult.Length > 0) { sb.Append("\n").Append(strScanResult); bWarn |= bScanWarn; }
            string err = grabber.LastError;
            if (err.Length > 0)
            {
                sb.Append("\n").Append(err);
                bWarn = true;
            }
            if (bGrabbing && bWaitingFirstFrame && grabber.FramesReceived == 0 &&
                unchecked(Environment.TickCount - nTickStart) > NoFrameWarnMs)
            {
                sb.Append("\n").Append(CLanguage.Text("No frame yet. Check the camera trigger and the CoaXPress link."));
                bWarn = true;
            }

            lblVisionStatus.ForeColor = bWarn ? HmiTheme.Warning : (bGrabbing ? HmiTheme.Normal : HmiTheme.TextMuted);
            lblVisionStatus.Text = sb.ToString();
        }

        private void tmrStatus_Tick(object sender, EventArgs e)
        {
            CheckScanTimeout();
            ShowStatus();
        }

        private string LinkStatusLine()
        {
            if (!ScanLinkOn) return "";
            string wiring = CSystemConfig.VisionWiring == "A"
                          ? CLanguage.Text("wiring A (through the grabber)")
                          : CLanguage.Text("wiring B (camera direct)");
            string seq = grabber == null ? CLanguage.Text("does not wait (VISION offline)")
                       : bSeqTookLink ? CLanguage.Text("waits for VISION") : CLanguage.Text("not answering");
            return CLanguage.Format("Scan link on, {0}, SEQ {1}", wiring, seq);
        }

        private void ImgView_PixelChanged(object sender, VisionPixelEventArgs e)
        {
            string size = imgView.HasImage ? CLanguage.Format("{0} x {1}", imgView.ImageWidth, imgView.ImageHeight) : "";
            string zoom = imgView.HasImage ? string.Format("   {0:0.##} %", imgView.Zoom * 100) : "";
            if (e.Value < 0)
                lblPixel.Text = size + zoom;
            else
                lblPixel.Text = size + zoom + "   " + CLanguage.Format("X {0}  Y {1}  value {2}", e.X, e.Y, e.Value);
        }
    }
}
