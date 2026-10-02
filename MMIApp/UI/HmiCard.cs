using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MMI
{
    // Standard Panel drawn as an L11 card: rounded, one step lighter than the
    // page, with an optional title along the top. Child controls sit below the
    // title because the title height is added to the top padding.
    public class HmiCard : Panel
    {
        private string _title = "";
        private int _radius = 8;
        private const int TitleHeight = 30;

        public HmiCard()
        {
            SetStyle(ControlStyles.UserPaint
                   | ControlStyles.AllPaintingInWmPaint
                   | ControlStyles.OptimizedDoubleBuffer
                   | ControlStyles.ResizeRedraw, true);
            BackColor = HmiTheme.Card;
            ForeColor = HmiTheme.Text;
            Padding = new Padding(10);
        }

        [DefaultValue("")]
        public string TitleText
        {
            get { return _title; }
            set
            {
                bool bHadTitle = !string.IsNullOrEmpty(_title);
                _title = value ?? "";
                bool bHasTitle = !string.IsNullOrEmpty(_title);
                if (bHadTitle != bHasTitle)
                {
                    Padding = new Padding(Padding.Left,
                        Padding.Top + (bHasTitle ? TitleHeight : -TitleHeight),
                        Padding.Right, Padding.Bottom);
                }
                Invalidate();
            }
        }

        [DefaultValue(8)]
        public int CornerRadius
        {
            get { return _radius; }
            set { _radius = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color parentBack = Parent != null ? Parent.BackColor : HmiTheme.Background;
            g.Clear(parentBack);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle r = new Rectangle(0, 0, Width - 1, Height - 1);
            using (GraphicsPath path = HmiButton.RoundRect(r, _radius))
            using (SolidBrush fill = new SolidBrush(BackColor))
            {
                g.FillPath(fill, path);
            }

            if (!string.IsNullOrEmpty(_title))
            {
                Rectangle t = new Rectangle(12, 6, Width - 24, TitleHeight - 6);
                TextRenderer.DrawText(g, _title, HmiTheme.FontCaption, t, HmiTheme.TextMuted,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }
        }
    }

    // A KPI tile: a muted caption over a large value, as on the L11 Auto screen.
    public class HmiKpiCard : HmiCard
    {
        private readonly Label _value = new Label();

        public HmiKpiCard()
        {
            _value.Dock = DockStyle.Fill;
            _value.Font = HmiTheme.FontValue;
            _value.ForeColor = HmiTheme.Text;
            _value.BackColor = Color.Transparent;
            _value.TextAlign = ContentAlignment.MiddleLeft;
            _value.Text = "-";
            Controls.Add(_value);
            TitleText = "KPI";
        }

        [DefaultValue("-")]
        public string ValueText
        {
            get { return _value.Text; }
            set { _value.Text = value; }
        }

        public Color ValueColor
        {
            get { return _value.ForeColor; }
            set { _value.ForeColor = value; }
        }
    }
}
