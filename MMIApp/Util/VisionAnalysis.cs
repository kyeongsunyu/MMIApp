using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace MMI
{
    // The analysis and the image files of Auto > VISION, ported from GrabDemo
    // (ProcessMTFAnalysis, the BMP load and save).
    static class VisionAnalysis
    {
        public const int Sections = 6;

        // The centre row of a packed 8 bit frame.
        public static byte[] CentreLine(byte[] frame, int nWidth, int nHeight)
        {
            if (frame == null || nWidth <= 0 || nHeight <= 0 || frame.Length < nWidth * nHeight) return new byte[0];
            byte[] line = new byte[nWidth];
            Buffer.BlockCopy(frame, (nHeight / 2) * nWidth, line, 0, nWidth);
            return line;
        }

        // The line in six sections. In each, the lowest and the highest 1 % of
        // the samples are left out and MTF = (max - min) / (max + min) * 100.
        // Null when the line is shorter than six samples.
        //
        // GrabDemo found the two order statistics with nth_element; for 8 bit
        // samples a 256 bin histogram gives the same values in one pass.
        public static double[] Mtf(byte[] line)
        {
            if (line == null || line.Length < Sections) return null;

            double[] result = new double[Sections];
            int[] hist = new int[256];
            int nSection = line.Length / Sections;

            for (int i = 0; i < Sections; i++)
            {
                int start = i * nSection;
                int end = i == Sections - 1 ? line.Length : start + nSection;
                int total = end - start;

                Array.Clear(hist, 0, hist.Length);
                for (int x = start; x < end; x++) hist[line[x]]++;

                int cut = (int)(total * 0.01);
                int lo = cut, hi = total - 1 - cut;
                if (lo >= hi) { lo = 0; hi = total - 1; }

                int minGray = Kth(hist, lo), maxGray = Kth(hist, hi);
                result[i] = maxGray + minGray > 0 ? (double)(maxGray - minGray) / (maxGray + minGray) * 100.0 : 0.0;
            }
            return result;
        }

        // The k-th smallest sample (0 based) of a histogram.
        private static int Kth(int[] hist, int k)
        {
            int n = 0;
            for (int v = 0; v < hist.Length; v++)
            {
                n += hist[v];
                if (n > k) return v;
            }
            return hist.Length - 1;
        }

        // A BMP (or any image GDI+ reads) as packed 8 bit grey. An 8 bit
        // indexed image keeps its palette's grey levels; colour is reduced to
        // luminance.
        public static byte[] LoadGrey(string path, out int nWidth, out int nHeight)
        {
            using (Bitmap src = new Bitmap(path))
            {
                int w = src.Width, h = src.Height;
                byte[] frame = new byte[w * h];

                if (src.PixelFormat == PixelFormat.Format8bppIndexed)
                {
                    Color[] pal = src.Palette.Entries;
                    byte[] map = new byte[256];
                    for (int i = 0; i < 256; i++)
                        map[i] = i < pal.Length ? Luma(pal[i]) : (byte)i;

                    BitmapData bd = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
                    try
                    {
                        byte[] row = new byte[w];
                        for (int y = 0; y < h; y++)
                        {
                            Marshal.Copy(bd.Scan0 + y * bd.Stride, row, 0, w);
                            for (int x = 0; x < w; x++) frame[y * w + x] = map[row[x]];
                        }
                    }
                    finally { src.UnlockBits(bd); }
                }
                else
                {
                    BitmapData bd = src.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
                    try
                    {
                        int[] row = new int[w];
                        for (int y = 0; y < h; y++)
                        {
                            Marshal.Copy(bd.Scan0 + y * bd.Stride, row, 0, w);
                            for (int x = 0; x < w; x++) frame[y * w + x] = Luma(Color.FromArgb(row[x]));
                        }
                    }
                    finally { src.UnlockBits(bd); }
                }

                nWidth = w;
                nHeight = h;
                return frame;
            }
        }

        private static byte Luma(Color c)
        {
            return (byte)((c.R * 299 + c.G * 587 + c.B * 114 + 500) / 1000);
        }
    }
}
