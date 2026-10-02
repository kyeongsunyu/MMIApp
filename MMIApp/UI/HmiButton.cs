using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MMI
{
    // What a button means, which decides its colour. Most buttons are Normal;
    // the coloured ones are kept for the few actions where the colour carries
    // the meaning (START, STOP, an alarm reset).
    public enum HmiButtonRole
    {
        Normal,
        Primary,
        Success,
        Danger,
        Warning,
    }

    // Standard Button, drawn flat with rounded corners. Checked turns it into a
    // toggle: the old DotNetBar ButtonX was used that way for menu selection and
    // for on/off outputs, and the screens still read and write Checked.
    public class HmiButton : Button
    {
        private bool _checked;
        private bool _hover;
        private bool _pressed;
        private HmiButtonRole _role = HmiButtonRole.Normal;
        private int _radius = 6;

        public HmiButton()
        {
            SetStyle(ControlStyles.UserPaint
                   | ControlStyles.AllPaintingInWmPaint
                   | ControlStyles.OptimizedDoubleBuffer
                   | ControlStyles.ResizeRedraw
                   | ControlStyles.SupportsTransparentBackColor, true);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            ForeColor = HmiTheme.Text;
            Font = HmiTheme.FontBold;
            Cursor = Cursors.Hand;
        }

        [DefaultValue(false)]
        public bool Checked
        {
            get { return _checked; }
            set
            {
                if (_checked == value) return;
                _checked = value;
                Invalidate();
                CheckedChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        // Click flips Checked when this is set, the way a CheckBox with
        // Appearance=Button would, but drawn like the other buttons.
        [DefaultValue(false)]
        public bool AutoCheck { get; set; }

        [DefaultValue(HmiButtonRole.Normal)]
        public HmiButtonRole Role
        {
            get { return _role; }
            set { _role = value; Invalidate(); }
        }

        [DefaultValue(6)]
        public int CornerRadius
        {
            get { return _radius; }
            set { _radius = Math.Max(0, value); Invalidate(); }
        }

        public event EventHandler CheckedChanged;

        protected override void OnClick(EventArgs e)
        {
            if (AutoCheck) Checked = !Checked;
            base.OnClick(e);
        }

        protected override void OnMouseEnter(EventArgs e) { _hover = true; Invalidate(); base.OnMouseEnter(e); }
        protected override void OnMouseLeave(EventArgs e) { _hover = false; _pressed = false; Invalidate(); base.OnMouseLeave(e); }
        protected override void OnMouseDown(MouseEventArgs e) { _pressed = true; Invalidate(); base.OnMouseDown(e); }
        protected override void OnMouseUp(MouseEventArgs e) { _pressed = false; Invalidate(); base.OnMouseUp(e); }
        protected override void OnEnabledChanged(EventArgs e) { Invalidate(); base.OnEnabledChanged(e); }

        // Screens written for the DotNetBar button show a state by setting
        // BackColor: blue for on or moving, red or maroon for a limit or an
        // alarm, green for in progress, brown for a sensor, black for off. The
        // button is drawn from its role, so without this those states never
        // showed. Black (and the default transparent) means no state.
        private Color StateColor()
        {
            Color b = BackColor;
            if (b.IsEmpty || b.A == 0) return Color.Empty;
            switch (b.Name)
            {
                case "Black":
                    return Color.Empty;
                case "Blue": case "RoyalBlue": case "Navy": case "DodgerBlue": case "MediumBlue":
                    return HmiTheme.Accent;
                case "Red": case "Maroon": case "DarkRed": case "Crimson": case "OrangeRed":
                    return HmiTheme.Alarm;
                case "Green": case "Lime": case "LimeGreen": case "ForestGreen": case "DarkGreen":
                    return HmiTheme.Normal;
                case "Brown": case "Orange": case "DarkOrange": case "Yellow": case "Gold":
                    return HmiTheme.Warning;
                default:
                    return b;
            }
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            Invalidate();
            base.OnBackColorChanged(e);
        }

        protected Color FillColor()
        {
            if (!Enabled) return HmiTheme.Card;

            Color c;
            Color state = StateColor();
            if (!state.IsEmpty)
            {
                c = state;
                if (_pressed) return ControlPaint.Dark(c, 0.05f);
                if (_hover) return ControlPaint.Light(c, 0.15f);
                return c;
            }
            switch (_role)
            {
                case HmiButtonRole.Primary: c = HmiTheme.Accent;  break;
                case HmiButtonRole.Success: c = HmiTheme.Normal;  break;
                case HmiButtonRole.Danger:  c = HmiTheme.Alarm;   break;
                case HmiButtonRole.Warning: c = HmiTheme.Warning; break;
                default: c = _checked ? HmiTheme.Accent : HmiTheme.Control; break;
            }
            if (_role != HmiButtonRole.Normal && !_checked && AutoCheck)
            {
                // A coloured toggle that is off reads as off, not as its colour.
                c = HmiTheme.Control;
            }
            if (_pressed) return ControlPaint.Dark(c, 0.05f);
            if (_hover) return ControlPaint.Light(c, 0.15f);
            return c;
        }

        protected Color TextColor()
        {
            if (!Enabled) return HmiTheme.TextDisabled;
            Color state = StateColor();
            if (!state.IsEmpty) return (state == HmiTheme.Warning) ? HmiTheme.TopBar : Color.White;
            bool bFilled = _checked || (_role != HmiButtonRole.Normal && !(AutoCheck && !_checked));
            if (_role == HmiButtonRole.Warning && bFilled) return HmiTheme.TopBar;
            return bFilled ? Color.White : ForeColor;
        }

        internal static GraphicsPath RoundRect(Rectangle r, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            if (radius <= 0)
            {
                path.AddRectangle(r);
                return path;
            }
            int d = radius * 2;
            path.AddArc(r.X, r.Y, d, d, 180, 90);
            path.AddArc(r.Right - d, r.Y, d, d, 270, 90);
            path.AddArc(r.Right - d, r.Bottom - d, d, d, 0, 90);
            path.AddArc(r.X, r.Bottom - d, d, d, 90, 90);
            path.CloseFigure();
            return path;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color parentBack = Parent != null ? Parent.BackColor : HmiTheme.Background;
            g.Clear(parentBack);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = RoundRect(r, _radius))
            using (SolidBrush fill = new SolidBrush(FillColor()))
            {
                g.FillPath(fill, path);
                if (!Enabled || (_role == HmiButtonRole.Normal && !_checked))
                {
                    using (Pen border = new Pen(HmiTheme.CardBorder))
                    {
                        g.DrawPath(border, path);
                    }
                }
            }

            PaintContent(g);

            if (Focused && ShowFocusCues)
            {
                Rectangle f = Rectangle.Inflate(r, -3, -3);
                using (GraphicsPath path = RoundRect(f, Math.Max(0, _radius - 2)))
                using (Pen p = new Pen(Color.FromArgb(160, Color.White)) { DashStyle = DashStyle.Dot })
                {
                    g.DrawPath(p, path);
                }
            }
        }

        protected virtual void PaintContent(Graphics g)
        {
            Rectangle text = new Rectangle(Padding.Left, Padding.Top,
                                           Width - Padding.Horizontal, Height - Padding.Vertical);
            if (Image != null)
            {
                int x = (Width - Image.Width) / 2;
                int y = string.IsNullOrEmpty(Text) ? (Height - Image.Height) / 2 : 6;
                g.DrawImage(Image, x, y, Image.Width, Image.Height);
                if (!string.IsNullOrEmpty(Text))
                {
                    text = new Rectangle(0, y + Image.Height, Width, Height - y - Image.Height);
                }
            }
            TextRenderer.DrawText(g, Text, FitFont(g, Text, text), text, TextColor(),
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter
              | TextFormatFlags.WordBreak | TextFormatFlags.EndEllipsis);
        }

        // A caption that does not fit (a longer language on a button sized for
        // English) is drawn smaller, down to three quarters of the font, before
        // it is allowed to wrap out of sight or end in an ellipsis.
        private const float MinFitRatio = 0.75f;
        private Font _fitFont;
        private string _fitKey;

        protected Font FitFont(Graphics g, string strText, Rectangle area)
        {
            if (string.IsNullOrEmpty(strText) || area.Width <= 0 || area.Height <= 0) return Font;

            string strKey = strText + "|" + area.Size + "|" + Font.Name + "|" + Font.Size + "|" + Font.Style;
            if (strKey == _fitKey && _fitFont != null) return _fitFont;

            // A caption laid out on one line, or written on several lines on
            // purpose, keeps its shape: a one-line caption shrinks until it fits
            // on one line; only one that cannot is left to wrap.
            bool bOneLine = strText.IndexOf('\n') < 0;
            Font fit = Font;
            for (float fSize = Font.Size; fSize >= Font.Size * MinFitRatio; fSize -= 0.5f)
            {
                Font f = (fSize == Font.Size) ? Font : new Font(Font.FontFamily, fSize, Font.Style, Font.Unit);
                Size need = bOneLine
                    ? TextRenderer.MeasureText(g, strText, f, new Size(int.MaxValue, int.MaxValue), TextFormatFlags.NoPadding)
                    : TextRenderer.MeasureText(g, strText, f, new Size(area.Width, int.MaxValue),
                                               TextFormatFlags.WordBreak | TextFormatFlags.NoPadding);
                if (fit != Font && fit != f) fit.Dispose();
                fit = f;
                if (need.Width <= area.Width - 4 && need.Height <= area.Height) break;
            }
            // Even the smallest size does not fit on one line: wrap it at the
            // size the button was given, as before.
            if (bOneLine && TextRenderer.MeasureText(g, strText, fit, new Size(int.MaxValue, int.MaxValue),
                                                     TextFormatFlags.NoPadding).Width > area.Width - 4)
            {
                if (fit != Font) fit.Dispose();
                fit = Font;
            }

            if (_fitFont != null && _fitFont != Font && _fitFont != fit) _fitFont.Dispose();
            _fitFont = fit;
            _fitKey = strKey;
            return fit;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && _fitFont != null && _fitFont != Font)
            {
                _fitFont.Dispose();
                _fitFont = null;
            }
            base.Dispose(disposing);
        }
    }

    // A rail entry: icon glyph over a short label, with the accent bar down the
    // left edge when it is the screen being shown.
    public class HmiRailButton : HmiButton
    {
        private string _glyph = "";

        public HmiRailButton()
        {
            CornerRadius = 0;
            Font = HmiTheme.FontSmall;
        }

        [DefaultValue("")]
        public string Glyph
        {
            get { return _glyph; }
            set { _glyph = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color back = Checked ? HmiTheme.Card : HmiTheme.Rail;
            if (Enabled && !Checked && ClientRectangle.Contains(PointToClient(Cursor.Position)))
            {
                back = HmiTheme.Control;
            }
            g.Clear(back);

            if (Checked)
            {
                using (SolidBrush bar = new SolidBrush(HmiTheme.Accent))
                {
                    g.FillRectangle(bar, 0, 0, 4, Height);
                }
            }

            Color fore = !Enabled ? HmiTheme.TextDisabled : (Checked ? HmiTheme.Accent : HmiTheme.Text);
            Rectangle icon = new Rectangle(0, 8, Width, Height / 2 - 4);
            Rectangle label = new Rectangle(0, Height / 2 + 2, Width, Height / 2 - 8);
            TextRenderer.DrawText(g, _glyph, HmiTheme.FontIcon, icon, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom);
            TextRenderer.DrawText(g, Text, FitFont(g, Text, label), label, fore,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.Top | TextFormatFlags.EndEllipsis);
        }
    }
}
