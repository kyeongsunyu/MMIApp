using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MMI
{
    public enum HmiProgressStyle
    {
        Ring,   // a circle that fills clockwise, the percentage in the middle
        Bar,    // a thin bar, the percentage beside it
    }

    // Progress in the L11 theme. It replaces the DotNetBar CircularProgress of
    // the original system initialisation window; the stock ProgressBar that
    // stood in for it filled the whole window and read as a grey square.
    // Value / Minimum / Maximum work as on a ProgressBar.
    public class HmiProgress : Control
    {
        private int nValue, nMin, nMax = 100;
        private HmiProgressStyle style = HmiProgressStyle.Ring;

        public HmiProgress()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            ForeColor = HmiTheme.Text;
            TrackColor = HmiTheme.Control;
            FillColor = HmiTheme.Accent;
            Thickness = 14;
        }

        [DefaultValue(HmiProgressStyle.Ring)]
        public HmiProgressStyle ProgressStyle
        {
            get { return style; }
            set { style = value; Invalidate(); }
        }

        public Color TrackColor { get; set; }
        public Color FillColor { get; set; }

        // Ring width, or the bar's height.
        public int Thickness { get; set; }

        public int Minimum
        {
            get { return nMin; }
            set { nMin = value; if (nMax < nMin) nMax = nMin; Value = nValue; }
        }

        public int Maximum
        {
            get { return nMax; }
            set { nMax = Math.Max(value, nMin); Value = nValue; }
        }

        public int Value
        {
            get { return nValue; }
            set
            {
                int v = Math.Max(nMin, Math.Min(nMax, value));
                if (v == nValue) return;
                nValue = v;
                Invalidate();
            }
        }

        private float Fraction
        {
            get { return nMax > nMin ? (float)(nValue - nMin) / (nMax - nMin) : 0f; }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            string text = ((int)Math.Round(Fraction * 100)).ToString() + " %";

            if (style == HmiProgressStyle.Ring)
            {
                int d = Math.Min(ClientSize.Width, ClientSize.Height) - Thickness - 2;
                if (d <= 0) return;
                RectangleF r = new RectangleF((ClientSize.Width - d) / 2f, (ClientSize.Height - d) / 2f, d, d);

                using (Pen track = new Pen(TrackColor, Thickness))
                    g.DrawEllipse(track, r);
                if (Fraction > 0)
                {
                    using (Pen fill = new Pen(FillColor, Thickness) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                        g.DrawArc(fill, r, -90f, 360f * Fraction);
                }
                TextRenderer.DrawText(g, text, Font, ClientRectangle, ForeColor,
                                      TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
            }
            else
            {
                Size ts = TextRenderer.MeasureText("100 %", Font);
                int h = Math.Min(Thickness, ClientSize.Height);
                int w = ClientSize.Width - ts.Width - 12;
                if (w <= 0) return;
                int y = (ClientSize.Height - h) / 2;

                using (GraphicsPath track = Rounded(new RectangleF(0, y, w, h), h / 2f))
                using (SolidBrush b = new SolidBrush(TrackColor))
                    g.FillPath(b, track);
                float fw = w * Fraction;
                if (fw >= 1)
                {
                    using (GraphicsPath fill = Rounded(new RectangleF(0, y, Math.Max(fw, h), h), h / 2f))
                    using (SolidBrush b = new SolidBrush(FillColor))
                        g.FillPath(b, fill);
                }
                TextRenderer.DrawText(g, text, Font, new Rectangle(w + 12, 0, ts.Width, ClientSize.Height), ForeColor,
                                      TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
            }
        }

        private static GraphicsPath Rounded(RectangleF r, float rad)
        {
            GraphicsPath p = new GraphicsPath();
            float d = Math.Min(rad * 2, Math.Min(r.Width, r.Height));
            p.AddArc(r.Left, r.Top, d, d, 90, 180);
            p.AddArc(r.Right - d, r.Top, d, d, 270, 180);
            p.CloseFigure();
            return p;
        }
    }
}
