using System;
using System.Threading;
using Euresys.EGrabber;
using Action = System.Action;
using Buffer = System.Buffer;

namespace MMI
{
    // The eGrabber (Coaxlink, CoaXPress) acquisition behind Auto > VISION,
    // ported from GrabDemo's CEGrabberController.
    //
    // The camera is used as it is configured: nothing here writes a feature of
    // the camera (the remote device). GrabDemo forced OperationMode = Area and
    // ExposureTime = 5000 on open, wrote Width / Height / OffsetX / OffsetY from
    // its buffer dialog and set the stream's BufferHeight to the camera height;
    // none of that is ported. What remains is grabber side only: the buffer
    // ring (ReallocBuffers) and starting and stopping the acquisition.
    //
    // This is the only class that names the Euresys types, so a PC without the
    // eGrabber runtime fails in Open (FileNotFoundException), which FormVision
    // turns into the offline screen.
    //
    // A worker thread pops the buffers. Each frame shown is normalised to 8 bit
    // packed grey (pitch == width) and kept as the latest frame; FrameReady is
    // raised once until the UI takes it, so a slow UI always sees the newest
    // frame instead of a backlog.
    sealed class VisionGrabber : IDisposable
    {
        public const int DefaultBufferCount = 8;
        private const ulong PopTimeoutMs = 200;

        private EGenTL gentl;
        private EGrabber grabber;

        private Thread worker;
        private volatile bool bStopRequest;
        private volatile bool bGrabbing;

        private readonly object frameLock = new object();
        private byte[] latestFrame = new byte[0];
        private int nLatestWidth, nLatestHeight;
        private bool bFrameReady;
        private int nFramePending;
        private int nFirstFrame;
        private int nTickLastShown;

        private long nReceived, nDisplayed, nRejected;
        private string strLastFormat = "", strLastError = "";

        public int BufferCount { get; private set; } = DefaultBufferCount;
        public int CameraWidth { get; private set; }
        public int CameraHeight { get; private set; }
        public string PixelFormat { get; private set; } = "";
        public string DeviceName { get; private set; } = "";

        // Minimum spacing of the frames handed to the screen; 0 shows every
        // frame the screen can keep up with.
        public int DisplayIntervalMs { get; set; } = 33;

        public bool IsGrabbing { get { return bGrabbing; } }
        public long FramesReceived { get { return Interlocked.Read(ref nReceived); } }
        public long FramesDisplayed { get { return Interlocked.Read(ref nDisplayed); } }
        public long FramesRejected { get { return Interlocked.Read(ref nRejected); } }
        public string LastFormat { get { lock (frameLock) return strLastFormat; } }
        public string LastError { get { lock (frameLock) return strLastError; } }

        // Raised on the worker thread. FrameReady once per frame the screen has
        // to take with TakeFrame; Stopped when an acquisition ends, by FREEZE,
        // after the frame of a SNAP or on an error.
        public event Action FrameReady;
        public event Action Stopped;

        private VisionGrabber() { }

        // Loads the GenTL producer and opens grabber 0. On failure returns null
        // and says why, with what the board and camera discovery found.
        public static VisionGrabber Open(out string strError)
        {
            strError = "";
            VisionGrabber v = new VisionGrabber();

            try
            {
                v.gentl = new EGenTL();
            }
            catch (Exception ex)
            {
                strError = CLanguage.Text("Failed to load the GenTL producer (coaxlink.cti). Check that eGrabber is installed.")
                         + "\n" + ex.Message;
                v.Dispose();
                return null;
            }

            try
            {
                v.grabber = new EGrabber(v.gentl);
            }
            catch (Exception ex)
            {
                if (v.grabber != null) v.grabber.Dispose();
                v.grabber = null;
                strError = CLanguage.Text("Could not open the frame grabber.") + "\n" + v.Diagnostics() + "\n" + ex.Message;
                v.Dispose();
                return null;
            }

            try
            {
                v.grabber.ReallocBuffers((ulong)v.BufferCount, 0);
                v.ReadGeometry();
                try { v.DeviceName = v.grabber.Remote.Get<string>("DeviceModelName"); } catch (Exception) { v.DeviceName = ""; }
            }
            catch (Exception ex)
            {
                strError = CLanguage.Text("The frame grabber was opened but the buffers could not be allocated.") + "\n" + ex.Message;
                v.Dispose();
                return null;
            }

            return v;
        }

        private void ReadGeometry()
        {
            try { CameraWidth = (int)grabber.Width; } catch (Exception) { CameraWidth = 0; }
            try { CameraHeight = (int)grabber.Height; } catch (Exception) { CameraHeight = 0; }
            try { PixelFormat = grabber.PixelFormat ?? ""; } catch (Exception) { PixelFormat = ""; }
        }

        // What the board and camera discovery finds; only while no grabber is
        // open, since the discovery holds the interface and device lists.
        private string Diagnostics()
        {
            if (gentl == null) return CLanguage.Text("GenTL producer was not loaded.");

            try
            {
                using (EGrabberDiscovery discovery = new EGrabberDiscovery(gentl))
                {
                    discovery.Discover(true);

                    int nIf = discovery.InterfaceCount;
                    int nCam = discovery.CameraCount;
                    int nDev = 0;
                    for (int i = 0; i < nIf; i++) nDev += discovery.GetDeviceCount(i);

                    string s = CLanguage.Format("Detected: {0} board(s), {1} device(s), {2} camera(s).", nIf, nDev, nCam);
                    if (nIf == 0)
                        s += "\n" + CLanguage.Text("No frame grabber board was found. Check the PCIe slot and the Coaxlink driver.");
                    else if (nCam == 0)
                        s += "\n" + CLanguage.Text("The board is present but no camera answers over CoaXPress. Check the camera power (PoCXP needs the board's auxiliary power), the cable at both ends, and that the camera has finished booting.");
                    return s;
                }
            }
            catch (Exception ex)
            {
                return CLanguage.Format("Diagnostics unavailable: {0}", ex.Message);
            }
        }

        // GRAB: nFrames = 0, until FREEZE. SNAP: nFrames = 1.
        public bool Start(int nFrames)
        {
            if (grabber == null || bGrabbing) return false;

            Interlocked.Exchange(ref nReceived, 0);
            Interlocked.Exchange(ref nDisplayed, 0);
            Interlocked.Exchange(ref nRejected, 0);
            lock (frameLock) strLastError = "";
            Interlocked.Exchange(ref nFramePending, 0);
            Interlocked.Exchange(ref nFirstFrame, 1);

            bStopRequest = false;
            bGrabbing = true;
            ulong count = nFrames > 0 ? (ulong)nFrames : ulong.MaxValue;
            worker = new Thread(() => Run(count)) { IsBackground = true, Name = "VisionGrabber" };
            worker.Start();
            return true;
        }

        // FREEZE. Waits for the worker, which stops the grabber itself.
        public void Stop()
        {
            Thread t = worker;
            if (t == null) return;
            bStopRequest = true;
            if (Thread.CurrentThread != t) t.Join(3000);
            worker = null;
        }

        private void Run(ulong count)
        {
            bool bStarted = false;
            try
            {
                grabber.Start(count, true);
                bStarted = true;

                ulong nGot = 0;
                while (!bStopRequest && nGot < count)
                {
                    try
                    {
                        using (ScopedBuffer buffer = new ScopedBuffer(grabber, PopTimeoutMs))
                        {
                            nGot++;
                            OnBuffer(buffer, count == 1);
                        }
                    }
                    catch (GenTLError ex) when (ex.GcError == GC_ERROR.GC_ERR_TIMEOUT)
                    {
                        // no frame within the timeout; look at the stop request again
                    }
                }
            }
            catch (GenTLError ex) when (ex.GcError == GC_ERROR.GC_ERR_ABORT)
            {
                // the acquisition was stopped under the pop
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
            finally
            {
                if (bStarted)
                {
                    try { grabber.Stop(); } catch (Exception ex) { SetError(ex.Message); }
                }
                bGrabbing = false;
                Action h = Stopped;
                if (h != null) h();
            }
        }

        private void OnBuffer(ScopedBuffer buffer, bool bSnap)
        {
            Interlocked.Increment(ref nReceived);
            try
            {
                // The first frame after a start and the frame of a SNAP always
                // go through. Otherwise skip the frame while the screen has not
                // taken the last one, or within the display interval: the
                // screen always reads the newest frame, so converting this one
                // would only cost the grabber thread time.
                bool bMustShow = Interlocked.Exchange(ref nFirstFrame, 0) != 0 || bSnap;
                int nNow = Environment.TickCount;
                if (!bMustShow)
                {
                    if (Interlocked.CompareExchange(ref nFramePending, 0, 0) != 0) return;
                    if (DisplayIntervalMs > 0 && unchecked(nNow - nTickLastShown) < DisplayIntervalMs) return;
                }
                nTickLastShown = nNow;

                // BufferInfo is the variant that is right for line scan and TDI
                // streams too: the line count is the delivered height there.
                BufferInfo info = buffer.GetInfo();
                long nWidth = (long)info.Width;
                long nPitch = (long)info.LinePitch;
                long nHeight = (long)info.DeliveredHeight;
                int nBpp = (int)info.BitsPerPixel;

                long nFilled = 0;
                try { nFilled = (long)buffer.GetInfo<ulong>(BUFFER_INFO_CMD.BUFFER_INFO_SIZE_FILLED); } catch (Exception) { nFilled = 0; }
                if (nFilled == 0) nFilled = (long)info.Size;

                if (nWidth == 0) nWidth = CameraWidth;
                // The configured height when the buffer holds that many lines:
                // the delivered height can vary a little on TDI streams, and a
                // height changing every frame makes the view flicker and re-fit.
                if (nPitch > 0 && CameraHeight > 0 && nFilled >= nPitch * CameraHeight) nHeight = CameraHeight;
                if (nHeight == 0 && nPitch > 0) nHeight = nFilled / nPitch;

                string strFormat = string.IsNullOrEmpty(info.PixelFormat) ? "?" : info.PixelFormat;
                lock (frameLock) strLastFormat = string.Format("{0}x{1} {2}", nWidth, nHeight, strFormat);

                string strReason;
                bool bOk = StoreFrame(info.BasePtr, nWidth, nHeight, nPitch, nBpp, nFilled, out strReason);
                if (!bOk)
                {
                    // Packed and colour formats: let the eGrabber converter
                    // make Mono8 of them.
                    string strConvert;
                    if (StoreConverted(buffer, out strConvert))
                    {
                        bOk = true;
                        strReason = "";
                    }
                    else if (strConvert.Length > 0)
                    {
                        strReason += " / " + strConvert;
                    }
                }

                if (bOk)
                {
                    Interlocked.Increment(ref nDisplayed);
                    SetError(strReason);
                    if (Interlocked.Exchange(ref nFramePending, 1) == 0)
                    {
                        Action h = FrameReady;
                        if (h != null) h();
                    }
                }
                else
                {
                    Interlocked.Increment(ref nRejected);
                    SetError(strReason);
                }
            }
            catch (Exception ex)
            {
                Interlocked.Increment(ref nRejected);
                SetError(ex.Message);
            }
        }

        // One delivered buffer into the latest frame as 8 bit packed grey.
        // 9..16 bit mono (LSB aligned 16 bit words) is shifted down to 8 bit.
        // A buffer that came up short is shown with the missing lines blank.
        private unsafe bool StoreFrame(IntPtr pBase, long nWidth, long nHeight, long nPitch, int nBpp,
                                       long nAvailable, out string strReason)
        {
            strReason = "";
            if (pBase == IntPtr.Zero || nWidth <= 0 || nHeight <= 0)
            {
                strReason = string.Format("buffer reported no image data ({0}x{1})", nWidth, nHeight);
                return false;
            }

            int bpp = nBpp > 0 ? nBpp : 8;
            long nBytesPerPixel = (bpp + 7) / 8;
            if (nPitch == 0) nPitch = nWidth * nBytesPerPixel;

            if (nPitch < nWidth * nBytesPerPixel)
            {
                strReason = string.Format("unsupported packed pixel format ({0} bpp, line pitch {1} for {2} px)", bpp, nPitch, nWidth);
                return false;
            }
            if (bpp > 16)
            {
                strReason = string.Format("unsupported pixel depth ({0} bpp), only 8..16 bit mono is displayed", bpp);
                return false;
            }

            long nLines = nAvailable / nPitch;
            if (nLines == 0)
            {
                strReason = string.Format("buffer too short: {0} bytes for a {1} byte line", nAvailable, nPitch);
                return false;
            }
            long nCopy = Math.Min(nLines, nHeight);
            if (nCopy < nHeight) strReason = string.Format("partial frame: {0} of {1} lines", nCopy, nHeight);

            int w = (int)nWidth, h = (int)nHeight;
            lock (frameLock)
            {
                if (latestFrame.Length != w * h) latestFrame = new byte[w * h];

                fixed (byte* pDst0 = latestFrame)
                {
                    byte* pSrc0 = (byte*)pBase;
                    if (nBytesPerPixel == 1)
                    {
                        for (long y = 0; y < nCopy; y++)
                            Buffer.MemoryCopy(pSrc0 + y * nPitch, pDst0 + y * w, w, w);
                    }
                    else
                    {
                        int nShift = bpp - 8;
                        for (long y = 0; y < nCopy; y++)
                        {
                            ushort* pRow = (ushort*)(pSrc0 + y * nPitch);
                            byte* pDst = pDst0 + y * w;
                            for (int x = 0; x < w; x++) pDst[x] = (byte)(pRow[x] >> nShift);
                        }
                    }
                    for (long y = nCopy; y < h; y++)
                    {
                        byte* pDst = pDst0 + y * w;
                        for (int x = 0; x < w; x++) pDst[x] = 0;
                    }
                }

                nLatestWidth = w;
                nLatestHeight = h;
                bFrameReady = true;
            }
            return true;
        }

        private unsafe bool StoreConverted(ScopedBuffer buffer, out string strReason)
        {
            strReason = "";
            try
            {
                using (ConvertedBuffer cb = buffer.Convert("Mono8"))
                {
                    int w = cb.Width, h = cb.Height, nPitch = cb.LinePitch > 0 ? cb.LinePitch : cb.Width;
                    if (w <= 0 || h <= 0 || cb.Pixels == IntPtr.Zero) return false;

                    lock (frameLock)
                    {
                        if (latestFrame.Length != w * h) latestFrame = new byte[w * h];
                        fixed (byte* pDst0 = latestFrame)
                        {
                            byte* pSrc0 = (byte*)cb.Pixels;
                            for (int y = 0; y < h; y++)
                                Buffer.MemoryCopy(pSrc0 + (long)y * nPitch, pDst0 + (long)y * w, w, w);
                        }
                        nLatestWidth = w;
                        nLatestHeight = h;
                        bFrameReady = true;
                    }
                    return true;
                }
            }
            catch (Exception ex)
            {
                strReason = "Mono8 conversion: " + ex.Message;
                return false;
            }
        }

        // The screen takes the latest frame. The arrays are swapped, not
        // copied: the caller's previous array comes back for reuse.
        public bool TakeFrame(ref byte[] frame, out int nWidth, out int nHeight)
        {
            Interlocked.Exchange(ref nFramePending, 0);
            lock (frameLock)
            {
                nWidth = nLatestWidth;
                nHeight = nLatestHeight;
                if (!bFrameReady) return false;

                byte[] t = frame ?? new byte[0];
                frame = latestFrame;
                latestFrame = t;
                bFrameReady = false;
                return true;
            }
        }

        // Grabber side only: the number of buffers in the ring. The camera
        // geometry is read again, never written.
        public bool SetBufferCount(int nCount, out string strError)
        {
            strError = "";
            if (grabber == null || bGrabbing) return false;
            try
            {
                grabber.ReallocBuffers((ulong)nCount, 0);
                BufferCount = nCount;
                ReadGeometry();
                return true;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return false;
            }
        }

        // ---------------------------------------------------------------------
        // scan link (grabber side only)

        private readonly System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>> deviceOriginals =
            new System.Collections.Generic.List<System.Collections.Generic.KeyValuePair<string, string>>();
        private long nOriginalBufferHeight = -1;

        public bool IsScanBuffer { get; private set; }

        // Grabber (Device module) features for the trigger wiring, as
        // "Feature=Value" pairs applied in order. The value each one had first
        // is remembered for RestoreDeviceFeatures. The camera is not written.
        public bool SetDeviceFeatures(System.Collections.Generic.IList<System.Collections.Generic.KeyValuePair<string, string>> features,
                                      out string strError)
        {
            strError = "";
            if (grabber == null || bGrabbing) { strError = "grabber busy or closed"; return false; }

            foreach (var f in features)
            {
                try
                {
                    if (!deviceOriginals.Exists(o => o.Key == f.Key))
                        deviceOriginals.Add(new System.Collections.Generic.KeyValuePair<string, string>(f.Key, grabber.Device.Get<string>(f.Key)));
                    grabber.Device.Set<string>(f.Key, f.Value);
                }
                catch (Exception ex)
                {
                    strError = string.Format("{0}={1}: {2}", f.Key, f.Value, ex.Message);
                    return false;
                }
            }
            return true;
        }

        // Back to what the grabber had before SetDeviceFeatures, last first.
        public void RestoreDeviceFeatures()
        {
            if (grabber == null || bGrabbing) return;
            for (int i = deviceOriginals.Count - 1; i >= 0; i--)
            {
                try { grabber.Device.Set<string>(deviceOriginals[i].Key, deviceOriginals[i].Value); } catch (Exception) { }
            }
            deviceOriginals.Clear();
        }

        // One buffer = one scan: the stream's BufferHeight set to the scan's
        // line count, two buffers. Line scan firmware only; area scan firmware
        // has no BufferHeight.
        public bool SetScanBuffer(int nLines, out string strError)
        {
            strError = "";
            if (grabber == null || bGrabbing) { strError = "grabber busy or closed"; return false; }
            try
            {
                if (nOriginalBufferHeight < 0) nOriginalBufferHeight = grabber.Stream.Get<long>("BufferHeight");
                grabber.Stream.Set<long>("BufferHeight", nLines);
                grabber.ReallocBuffers(2, 0);
                IsScanBuffer = true;
                return true;
            }
            catch (Exception ex)
            {
                strError = "BufferHeight " + nLines + ": " + ex.Message;
                return false;
            }
        }

        // The buffers as they were before the scan link: the original
        // BufferHeight and BufferCount buffers.
        public void RestoreBuffer()
        {
            if (grabber == null || bGrabbing || !IsScanBuffer) return;
            try
            {
                if (nOriginalBufferHeight >= 0) grabber.Stream.Set<long>("BufferHeight", nOriginalBufferHeight);
                grabber.ReallocBuffers((ulong)BufferCount, 0);
            }
            catch (Exception ex)
            {
                SetError(ex.Message);
            }
            IsScanBuffer = false;
            ReadGeometry();
        }

        private void SetError(string s)
        {
            lock (frameLock) strLastError = s ?? "";
        }

        public void Dispose()
        {
            Stop();
            // the board keeps its settings after this program, so hand it back
            // as it was found
            RestoreBuffer();
            RestoreDeviceFeatures();
            if (grabber != null)
            {
                try { grabber.Dispose(); } catch (Exception) { }
                grabber = null;
            }
            if (gentl != null)
            {
                try { gentl.Dispose(); } catch (Exception) { }
                gentl = null;
            }
        }
    }
}
