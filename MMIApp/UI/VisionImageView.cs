using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace MMI
{
    // The image of Auto > VISION, ported from GrabDemo's CEGrabberDisplayWnd.
    //
    // Shows an 8 bit grey frame fitted to the control. The wheel zooms about
    // the cursor, dragging pans, a double click fits again. PixelChanged
    // reports the image position under the cursor and its grey level, or -1
    // when the cursor is off the image.
    public class VisionImageView : Control
    {
        private const float MaxZoom = 32f;

        private Bitmap bitmap;
        private byte[] pixels = new byte[0];
        private int nWidth, nHeight;

        private bool bFit = true;
        private float fZoom = 1f;
        private PointF ptOrigin;          // control position of image pixel (0, 0)

        private bool bDragging;
        private Point ptDragStart;
        private PointF ptOriginAtDrag;

        public event EventHandler<VisionPixelEventArgs> PixelChanged;

        public VisionImageView()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.Selectable, true);
            BackColor = Color.FromArgb(0x12, 0x13, 0x16);
            ForeColor = Color.FromArgb(0x9A, 0xA0, 0xA6);
        }

        public int ImageWidth { get { return nWidth; } }
        public int ImageHeight { get { return nHeight; } }
        public bool HasImage { get { return bitmap != null; } }
        public float Zoom { get { return fZoom; } }

        // Live frames are drawn with plain bilinear reduction (fast); a still
        // image with the prefiltered one, which does not shimmer on fine
        // structure such as an MTF target.
        public bool Live { get; set; }

        // The current frame, packed 8 bit (pitch == width). Valid until the
        // next SetImage.
        public byte[] Pixels { get { return pixels; } }

        // Takes the frame; the array is kept (not copied) until the next call.
        public void SetImage(byte[] data, int w, int h)
        {
            if (data == null || w <= 0 || h <= 0 || data.Length < w * h) return;

            bool bResized = bitmap == null || w != nWidth || h != nHeight;
            if (bResized)
            {
                if (bitmap != null) bitmap.Dispose();
                bitmap = new Bitmap(w, h, PixelFormat.Format8bppIndexed);
                ColorPalette pal = bitmap.Palette;
                for (int i = 0; i < 256; i++) pal.Entries[i] = Color.FromArgb(i, i, i);
                bitmap.Palette = pal;
            }

            BitmapData bd = bitmap.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            try
            {
                for (int y = 0; y < h; y++)
                    System.Runtime.InteropServices.Marshal.Copy(data, y * w, bd.Scan0 + y * bd.Stride, w);
            }
            finally
            {
                bitmap.UnlockBits(bd);
            }

            pixels = data;
            nWidth = w;
            nHeight = h;
            if (bResized) bFit = true;
            if (bFit) FitToWindow();
            Invalidate();
        }

        public void Clear()
        {
            if (bitmap != null) bitmap.Dispose();
            bitmap = null;
            pixels = new byte[0];
            nWidth = nHeight = 0;
            Invalidate();
        }

        // The frame as an 8 bit BMP.
        public void SaveBmp(string path)
        {
            if (bitmap == null) return;
            bitmap.Save(path, ImageFormat.Bmp);
        }

        public void FitToWindow()
        {
            bFit = true;
            if (nWidth <= 0 || nHeight <= 0 || ClientSize.Width <= 0 || ClientSize.Height <= 0) return;
            fZoom = Math.Min((float)ClientSize.Width / nWidth, (float)ClientSize.Height / nHeight);
            ptOrigin = new PointF((ClientSize.Width - nWidth * fZoom) / 2f, (ClientSize.Height - nHeight * fZoom) / 2f);
            Invalidate();
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (bFit) FitToWindow();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);

            if (bitmap == null)
            {
                TextRenderer.DrawText(g, CLanguage.Text("No image"), Font, ClientRectangle, ForeColor,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
                return;
            }

            // Only the visible part of the image is drawn: at a high zoom on a
            // long line scan frame that is a small fraction of it.
            RectangleF view = new RectangleF((-ptOrigin.X) / fZoom, (-ptOrigin.Y) / fZoom, ClientSize.Width / fZoom, ClientSize.Height / fZoom);
            RectangleF src = RectangleF.Intersect(view, new RectangleF(0, 0, nWidth, nHeight));
            if (src.Width <= 0 || src.Height <= 0) return;

            if (fZoom >= 1f)
            {
                // whole pixels, so each one is a clean square
                src = RectangleF.FromLTRB((float)Math.Floor(src.Left), (float)Math.Floor(src.Top),
                                          (float)Math.Min(nWidth, Math.Ceiling(src.Right)), (float)Math.Min(nHeight, Math.Ceiling(src.Bottom)));
                g.InterpolationMode = InterpolationMode.NearestNeighbor;
                g.PixelOffsetMode = PixelOffsetMode.Half;
            }
            else
            {
                g.InterpolationMode = Live ? InterpolationMode.Bilinear : InterpolationMode.HighQualityBilinear;
                g.PixelOffsetMode = PixelOffsetMode.HighSpeed;
            }

            RectangleF dst = new RectangleF(ptOrigin.X + src.X * fZoom, ptOrigin.Y + src.Y * fZoom, src.Width * fZoom, src.Height * fZoom);
            using (ImageAttributes ia = new ImageAttributes())
            {
                ia.SetWrapMode(WrapMode.TileFlipXY);   // no grey seam at the edges
                g.DrawImage(bitmap, new[] { dst.Location, new PointF(dst.Right, dst.Top), new PointF(dst.Left, dst.Bottom) },
                            src, GraphicsUnit.Pixel, ia);
            }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!Focused && FindForm() != null && FindForm().ContainsFocus) Focus();
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            base.OnMouseWheel(e);
            if (bitmap == null) return;

            float fFit = Math.Min((float)ClientSize.Width / nWidth, (float)ClientSize.Height / nHeight);
            float fNew = fZoom * (e.Delta > 0 ? 1.25f : 0.8f);
            fNew = Math.Max(Math.Min(fFit, 1f) * 0.5f, Math.Min(MaxZoom, fNew));

            // keep the image point under the cursor where it is
            float ix = (e.X - ptOrigin.X) / fZoom, iy = (e.Y - ptOrigin.Y) / fZoom;
            fZoom = fNew;
            ptOrigin = new PointF(e.X - ix * fZoom, e.Y - iy * fZoom);
            bFit = false;
            Invalidate();
            ReportPixel(e.Location);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            if (e.Button == MouseButtons.Left && bitmap != null)
            {
                bDragging = true;
                ptDragStart = e.Location;
                ptOriginAtDrag = ptOrigin;
                Cursor = Cursors.SizeAll;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (bDragging)
            {
                ptOrigin = new PointF(ptOriginAtDrag.X + e.X - ptDragStart.X, ptOriginAtDrag.Y + e.Y - ptDragStart.Y);
                bFit = false;
                Invalidate();
            }
            ReportPixel(e.Location);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            bDragging = false;
            Cursor = Cursors.Default;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            PixelChanged?.Invoke(this, new VisionPixelEventArgs(-1, -1, -1));
        }

        protected override void OnDoubleClick(EventArgs e)
        {
            base.OnDoubleClick(e);
            FitToWindow();
        }

        private void ReportPixel(Point p)
        {
            if (PixelChanged == null) return;
            int x = -1, y = -1, v = -1;
            if (bitmap != null)
            {
                int ix = (int)Math.Floor((p.X - ptOrigin.X) / fZoom);
                int iy = (int)Math.Floor((p.Y - ptOrigin.Y) / fZoom);
                if (ix >= 0 && iy >= 0 && ix < nWidth && iy < nHeight && pixels.Length >= nWidth * nHeight)
                {
                    x = ix; y = iy; v = pixels[iy * nWidth + ix];
                }
            }
            PixelChanged(this, new VisionPixelEventArgs(x, y, v));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && bitmap != null)
            {
                bitmap.Dispose();
                bitmap = null;
            }
            base.Dispose(disposing);
        }
    }

    public class VisionPixelEventArgs : EventArgs
    {
        public VisionPixelEventArgs(int x, int y, int value) { X = x; Y = y; Value = value; }
        public int X { get; private set; }
        public int Y { get; private set; }
        public int Value { get; private set; }
    }
}
