using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MMI
{
    // The centre line profile of Auto > VISION, ported from GrabDemo's
    // CProfileGraphWnd: grey level 0..255 against the position on the line,
    // with the six MTF sections S1..S6 marked.
    public class VisionProfileView : Control
    {
        private static readonly int[] YTicks = { 0, 64, 128, 192, 255 };

        private byte[] line = new byte[0];
        private readonly List<PointF> pts = new List<PointF>();

        public VisionProfileView()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.UserPaint | ControlStyles.ResizeRedraw, true);
            BackColor = Color.FromArgb(0x12, 0x13, 0x16);
            ForeColor = Color.FromArgb(0x9A, 0xA0, 0xA6);
            LineColor = HmiTheme.Accent;
        }

        public Color LineColor { get; set; }

        public byte[] Line { get { return line; } }

        public void SetLine(byte[] data)
        {
            line = data ?? new byte[0];
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(BackColor);

            Rectangle area = new Rectangle(38, 6, Math.Max(2, ClientSize.Width - 46), Math.Max(2, ClientSize.Height - 26));

            using (Pen grid = new Pen(Color.FromArgb(0x3A, 0x3E, 0x45)))
            {
                foreach (int v in YTicks)
                {
                    int y = area.Bottom - (int)(v * area.Height / 255.0);
                    g.DrawLine(grid, area.Left, y, area.Right, y);
                    TextRenderer.DrawText(g, v.ToString(), Font, new Rectangle(0, y - 8, area.Left - 4, 16), ForeColor,
                                          TextFormatFlags.Right | TextFormatFlags.VerticalCenter);
                }
                for (int i = 0; i <= 6; i++)
                {
                    int x = area.Left + i * area.Width / 6;
                    g.DrawLine(grid, x, area.Top, x, area.Bottom);
                    if (i < 6)
                        TextRenderer.DrawText(g, "S" + (i + 1), Font, new Rectangle(x, area.Bottom + 2, area.Width / 6, 16), ForeColor,
                                              TextFormatFlags.HorizontalCenter);
                }
            }

            int n = line.Length, gw = area.Width;
            if (n < 2 || gw < 2) return;

            double scaleY = area.Height / 255.0;
            pts.Clear();
            if (n <= gw)
            {
                for (int i = 0; i < n; i++)
                    pts.Add(new PointF(area.Left + (float)((double)i * gw / (n - 1)), area.Bottom - (float)(line[i] * scaleY)));
            }
            else
            {
                // More samples than columns: the min and the max of each column.
                // Plain decimation would drop exactly the peaks an MTF profile
                // is about; this keeps the envelope at two points per column.
                for (int col = 0; col < gw; col++)
                {
                    int from = (int)((long)col * n / gw);
                    int to = (int)((long)(col + 1) * n / gw);
                    if (to <= from) to = from + 1;
                    if (to > n) to = n;

                    int lo = line[from], hi = lo;
                    for (int s = from + 1; s < to; s++)
                    {
                        int v = line[s];
                        if (v < lo) lo = v; else if (v > hi) hi = v;
                    }

                    float x = area.Left + col;
                    PointF pHi = new PointF(x, area.Bottom - (float)(hi * scaleY));
                    PointF pLo = new PointF(x, area.Bottom - (float)(lo * scaleY));
                    // alternate, so neighbouring columns join at the near end
                    if ((col & 1) != 0) { pts.Add(pHi); pts.Add(pLo); }
                    else { pts.Add(pLo); pts.Add(pHi); }
                }
            }

            if (pts.Count >= 2)
            {
                g.SmoothingMode = SmoothingMode.None;
                using (Pen pen = new Pen(LineColor, 1f))
                    g.DrawLines(pen, pts.ToArray());
            }
        }
    }
}
