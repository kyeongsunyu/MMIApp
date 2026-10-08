using System;
using System.IO;
using System.Windows.Forms;

namespace MMI
{
    // What the top bar shows for VISION.
    public enum eVisionLink
    {
        NotOpened,      // grey  "VISION: -"
        Offline,        // red   "VISION: Disconnected"
        Connected,      // grey  "VISION: Connected", scan link off or not taken by SEQ
        Ready,          // green "VISION: Connected", SEQ waits for VISION before each scan
    }

    // The scan link: the line scan camera takes the lines of a TRIGGER scan.
    //
    //   SCAN LINK on    the grabber gets the wiring's features (A: the trigger
    //                   comes into a Coaxlink input, B: straight into the
    //                   camera) and SEQ is told to wait for VISION before
    //                   every scan (the handshake, _scantriggervision).
    //   TRIGGER START   PrepareForScan: one buffer = the scan's line count,
    //                   one frame armed, then READY to SEQ. SEQ goes to the
    //                   start position, waits for that ready (WAIT VISION) and
    //                   only then arms the trigger, so no line is lost.
    //   the scan        every trigger pulse is one line; the full buffer is
    //                   the image. It is shown, analysed and saved as BMP.
    //   DONE / ABORTED  ScanFinished compares SEQ's trigger count, the lines
    //                   expected and the lines received.
    //
    // The camera itself is not written: its trigger setting matches the wiring
    // and is set up beforehand.
    public partial class FormVision
    {
        // A scan image bigger than this is refused: it would not fit the
        // display (GDI+) or memory. Shorter scans or a coarser pitch fit.
        private const long MaxScanBytes = 512L * 1024 * 1024;
        // After SEQ's DONE, how long the last lines may take to arrive.
        private const int ScanFrameWaitMs = 2000;
        // How often SEQ is reminded of the link (it forgets on a restart).
        private const int LinkRefreshMs = 2000;

        private eVisionLink linkState = eVisionLink.NotOpened;
        private bool bSeqTookLink;
        private bool bWiringApplied;
        private string strLinkError = "";

        // A scan the operator ran with VISION offline (TRIGGER asked); only
        // for the status line.
        private bool bOfflineScan;
        // SEQ has been told not to wait (it may still hold a use from before
        // an MMI restart, or from before VISION went offline).
        private bool bSeqUseOffSent;

        private bool bScanArmed;
        private bool bScanGotFrame;
        private bool bScanSeqDone;
        private int nScanLines;
        private int nScanTriggers = -1;
        private int nScanReceivedLines;
        private int nScanFinishTick;
        private string strScanResult = "";
        private bool bScanWarn;
        private string strLastScanFile = "";

        private Timer tmrLink;

        private void InitScanLink()
        {
            btnScanLink.Checked = CSystemConfig.VisionScanLink;
            ShowWiring();

            tmrLink = new Timer { Interval = LinkRefreshMs };
            tmrLink.Tick += (s, e) => { RefreshLink(); CheckScanTimeout(); };
            tmrLink.Start();
        }

        public eVisionLink LinkState { get { return linkState; } }

        private bool ScanLinkOn { get { return CSystemConfig.VisionScanLink; } }

        // Opens the grabber at program start, so the top bar says where VISION
        // stands without the screen having been visited.
        public void ConnectAtStartup()
        {
            if (!bTriedOpen) Connect();
        }

        // ---------------------------------------------------------------------
        // link

        // The wiring's features on the grabber, and the handshake on in SEQ;
        // or both back off. Called when the link or the wiring changes, after a
        // connect, and every LinkRefreshMs.
        //
        // SEQ waits for VISION only while the grabber is open. With VISION
        // offline it is told not to wait, so a scan the operator chooses to
        // run anyway (TRIGGER asks first) goes like one with the link off,
        // with no extra round trip at START.
        private void RefreshLink()
        {
            if (ScanLinkOn && grabber != null)
            {
                bSeqUseOffSent = false;
                if (grabber != null && !bWiringApplied && !grabber.IsGrabbing)
                {
                    string strError;
                    string features = CSystemConfig.VisionWiring == "A" ? CSystemConfig.VisionFeaturesA : CSystemConfig.VisionFeaturesB;
                    grabber.RestoreDeviceFeatures();
                    bWiringApplied = grabber.SetDeviceFeatures(CSystemConfig.ParseFeatures(features), out strError);
                    strLinkError = bWiringApplied ? "" : CLanguage.Format("Grabber setting for wiring {0} refused: {1}", CSystemConfig.VisionWiring, strError);
                }
                bSeqTookLink = SendLink(true, -1, 0);
            }
            else
            {
                if (bSeqTookLink || !bSeqUseOffSent) bSeqUseOffSent = SendLink(false, 0, 0);
                bSeqTookLink = false;
                if (grabber != null && !grabber.IsGrabbing)
                {
                    if (bWiringApplied) grabber.RestoreDeviceFeatures();
                    grabber.RestoreBuffer();
                }
                bWiringApplied = false;
                if (!ScanLinkOn) strLinkError = "";
            }
            ShowLinkState();
        }

        // The handshake to SEQ; true when SEQ answers holding what was sent.
        private bool SendLink(bool bUse, int nReady, int nLines)
        {
            // a send to a SEQ that is not there blocks for its timeout; the
            // refresh brings the link back once SEQ answers again
            if (MmiGV.pShMem == null || (frmMain != null && !frmMain.IsSeqLinked)) return false;
            int nTries = nReady < 0 ? 1 : 3;
            for (int k = 0; k < nTries; k++)
            {
                try
                {
                    if (MmiGV.pShMem.SetScanTriggerVision(bUse, nReady, nLines) &&
                        MmiGV.pShMem.bScanTriggerVisionUse == bUse &&
                        (nReady < 0 || MmiGV.pShMem.bScanTriggerVisionReady == (nReady == 1)))
                        return true;
                }
                catch (Exception) { return false; }
            }
            return false;
        }

        private void ShowLinkState()
        {
            eVisionLink s;
            if (grabber == null) s = bTriedOpen ? eVisionLink.Offline : eVisionLink.NotOpened;
            else s = (ScanLinkOn && bSeqTookLink && bWiringApplied) ? eVisionLink.Ready : eVisionLink.Connected;

            linkState = s;
            if (frmMain != null) frmMain.ShowVisionLink(s);
        }

        private void btnScanLink_Click(object sender, EventArgs e)
        {
            if (grabber != null && grabber.IsGrabbing) Freeze();

            CSystemConfig.VisionScanLink = !CSystemConfig.VisionScanLink;
            btnScanLink.Checked = CSystemConfig.VisionScanLink;
            CSystemConfig.SaveVision();
            bWiringApplied = false;
            RefreshLink();
            UpdateButtons();
            ShowStatus();
        }

        private void btnWiringA_Click(object sender, EventArgs e) { SetWiring("A"); }
        private void btnWiringB_Click(object sender, EventArgs e) { SetWiring("B"); }

        private void SetWiring(string w)
        {
            if (CSystemConfig.VisionWiring != w)
            {
                if (grabber != null && grabber.IsGrabbing) Freeze();
                CSystemConfig.VisionWiring = w;
                CSystemConfig.SaveVision();
                bWiringApplied = false;
                RefreshLink();
            }
            ShowWiring();
            ShowStatus();
        }

        private void ShowWiring()
        {
            btnWiringA.Checked = CSystemConfig.VisionWiring == "A";
            btnWiringB.Checked = CSystemConfig.VisionWiring == "B";
        }

        // ---------------------------------------------------------------------
        // scan

        // TRIGGER START, before the START goes to SEQ. True when the scan may
        // go ahead: the link is off, or VISION is armed and SEQ holds the ready.
        public bool PrepareForScan(int nLines, out string strError)
        {
            strError = "";
            if (!ScanLinkOn) return true;

            if (grabber == null)
            {
                strError = CLanguage.Text("VISION is offline. Connect it, or turn SCAN LINK off.");
                return false;
            }
            if (nLines <= 0)
            {
                strError = CLanguage.Text("The scan has no lines. SET the recipe first.");
                return false;
            }
            long nBytes = (long)Math.Max(1, grabber.CameraWidth) * nLines;
            if (nBytes > MaxScanBytes)
            {
                strError = CLanguage.Format("The scan image would be {0:N0} MB, more than {1:N0} MB. Shorten the scan or use a coarser pitch.",
                                            nBytes / (1024 * 1024), MaxScanBytes / (1024 * 1024));
                return false;
            }

            if (grabber.IsGrabbing) grabber.Stop();
            if (!bWiringApplied) RefreshLink();
            if (!bWiringApplied)
            {
                strError = strLinkError;
                return false;
            }

            string strBuf;
            if (!grabber.SetScanBuffer(nLines, out strBuf))
            {
                strError = CLanguage.Text("The grabber could not be set up for the scan.") + "\n" + strBuf;
                return false;
            }
            if (!grabber.Start(1))
            {
                strError = CLanguage.Text("The grabber could not be started.");
                return false;
            }
            if (!SendLink(true, 1, nLines))
            {
                grabber.Stop();
                strError = CLanguage.Text("SEQ did not take the VISION ready.");
                return false;
            }

            bSeqTookLink = true;
            bScanArmed = true;
            bScanGotFrame = false;
            bScanSeqDone = false;
            nScanLines = nLines;
            nScanTriggers = -1;
            nScanReceivedLines = 0;
            bScanWarn = false;
            strScanResult = CLanguage.Format("Scan: waiting for {0:N0} lines", nLines);
            nTickStart = Environment.TickCount;
            bWaitingFirstFrame = false;     // a scan's first lines come after the move
            imgView.Live = true;
            UpdateButtons();
            ShowStatus();
            ShowLinkState();
            return true;
        }

        // TRIGGER asks before a START: the link is on but VISION cannot take
        // the lines.
        public bool LinkOnButOffline { get { return ScanLinkOn && grabber == null; } }

        // TRIGGER, the operator chose to scan anyway (an oscilloscope check of
        // the trigger with no camera). SEQ already does not wait while VISION
        // is offline; this only says so on the status.
        public void ScanWithoutVision()
        {
            bOfflineScan = true;
            strScanResult = CLanguage.Text("Scan: run without VISION (this scan only)");
            bScanWarn = true;
            ShowStatus();
        }

        // TRIGGER: the START was not sent, or SEQ refused it.
        public void CancelScan()
        {
            bOfflineScan = false;
            if (!bScanArmed) return;
            bScanArmed = false;
            if (grabber != null) grabber.Stop();
            SendLink(true, 0, 0);
            strScanResult = CLanguage.Text("Scan: not started");
            bScanWarn = true;
            UpdateButtons();
            ShowStatus();
        }

        // TRIGGER, from SEQ's event: the cycle ended (7 DONE, 8 ABORTED).
        public void ScanFinished(int nState, int nTriggerCount)
        {
            if (InvokeRequired) { BeginInvoke((Action)(() => ScanFinished(nState, nTriggerCount))); return; }
            if (bOfflineScan)
            {
                strScanResult = CLanguage.Format("Scan without VISION: {0}, triggers {1}",
                                                 nState == 7 ? "DONE" : "ABORTED", nTriggerCount < 0 ? "-" : nTriggerCount.ToString("N0"));
                bOfflineScan = false;
                ShowStatus();
                return;
            }
            if (!bScanArmed && !bScanGotFrame) return;

            nScanTriggers = nTriggerCount;
            if (nState != 7)
            {
                bScanArmed = false;
                if (grabber != null && grabber.IsGrabbing) grabber.Stop();
                strScanResult = CLanguage.Text("Scan: aborted by SEQ");
                bScanWarn = true;
                ShowStatus();
                UpdateButtons();
                return;
            }

            bScanSeqDone = true;
            nScanFinishTick = Environment.TickCount;
            if (bScanGotFrame) ReportScan();
            // else the lines may still be on their way; CheckScanTimeout waits
        }

        // The frame of an armed scan arrived (AcquisitionEnded).
        private void ScanFrameArrived()
        {
            bScanArmed = false;
            bScanGotFrame = true;
            nScanReceivedLines = imgView.ImageHeight;

            try
            {
                string folder = Path.Combine(ImageFolder(), "Scan", DateTime.Now.ToString("yyyyMMdd"));
                Directory.CreateDirectory(folder);
                string recipe = "";
                try { recipe = CRecipeCtl.CurMaterialRcp.Material_NAME ?? ""; } catch (Exception) { }
                foreach (char c in Path.GetInvalidFileNameChars()) recipe = recipe.Replace(c, '_');
                strLastScanFile = Path.Combine(folder, "SCAN_" + (recipe.Length > 0 ? recipe + "_" : "") + DateTime.Now.ToString("HHmmss") + ".bmp");
                imgView.SaveBmp(strLastScanFile);
            }
            catch (Exception ex)
            {
                strLastScanFile = "";
                strLinkError = CLanguage.Text("The image could not be saved.") + " " + ex.Message;
            }

            if (bScanSeqDone) ReportScan();
            else strScanResult = CLanguage.Format("Scan: {0:N0} lines received", nScanReceivedLines);
        }

        private void ReportScan()
        {
            bool bLinesOk = nScanReceivedLines == nScanLines;
            bool bTrigOk = nScanTriggers < 0 || nScanTriggers == nScanLines;
            bScanWarn = !bLinesOk || !bTrigOk;
            strScanResult = CLanguage.Format("Scan: lines {0:N0} / expected {1:N0}, triggers {2}",
                                             nScanReceivedLines, nScanLines, nScanTriggers < 0 ? "-" : nScanTriggers.ToString("N0"))
                          + (bScanWarn ? "  " + CLanguage.Text("MISMATCH") : "  OK");
            bScanSeqDone = false;
            bScanGotFrame = false;
            ShowStatus();
        }

        // Called with the status refresh: SEQ is done but the buffer never
        // filled, which means fewer lines came than the buffer holds.
        private void CheckScanTimeout()
        {
            if (!bScanSeqDone || bScanGotFrame) return;
            if (unchecked(Environment.TickCount - nScanFinishTick) < ScanFrameWaitMs) return;

            bScanSeqDone = false;
            bScanArmed = false;
            if (grabber != null && grabber.IsGrabbing) grabber.Stop();
            strScanResult = CLanguage.Format("Scan: no image. Fewer lines than {0:N0} arrived (triggers {1}). Check the trigger wiring and the camera trigger setting.",
                                             nScanLines, nScanTriggers < 0 ? "-" : nScanTriggers.ToString("N0"));
            bScanWarn = true;
            UpdateButtons();
            ShowStatus();
        }
    }
}
