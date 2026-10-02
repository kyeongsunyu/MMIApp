using System.Drawing;
using System.Windows.Forms;

namespace MMI
{
    // Standard TabControl drawn flat: the tab strip on the page colour, the
    // selected tab underlined in the accent colour, and no 3D border around
    // the pages. The pages themselves are ordinary TabPages.
    public class HmiTabControl : TabControl
    {
        public HmiTabControl()
        {
            SetStyle(ControlStyles.UserPaint
                   | ControlStyles.AllPaintingInWmPaint
                   | ControlStyles.OptimizedDoubleBuffer
                   | ControlStyles.ResizeRedraw, true);
            SizeMode = TabSizeMode.Fixed;
            ItemSize = new Size(150, 36);
            Font = HmiTheme.FontBold;
            Padding = new Point(12, 4);
        }

        private bool _showTabs = true;

        // False hides the tab strip. Screens that pick the page from a list of
        // their own (manual operation picks it by section) use the control as
        // a stack of pages and keep the strip out of the way.
        [System.ComponentModel.DefaultValue(true)]
        public bool ShowTabs
        {
            get { return _showTabs; }
            set
            {
                _showTabs = value;
                ItemSize = value ? new Size(150, 36) : new Size(0, 1);
                Appearance = value ? TabAppearance.Normal : TabAppearance.FlatButtons;
                Invalidate();
            }
        }

        // Without a strip the page fills the whole control.
        public override Rectangle DisplayRectangle
        {
            get
            {
                if (_showTabs) return base.DisplayRectangle;
                return new Rectangle(0, 0, Width, Height);
            }
        }

        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            if (e.Control is TabPage)
            {
                e.Control.BackColor = HmiTheme.Background;
                e.Control.ForeColor = HmiTheme.Text;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Color parentBack = Parent != null ? Parent.BackColor : HmiTheme.Background;
            if (parentBack == Color.Transparent) parentBack = HmiTheme.Background;
            g.Clear(parentBack);

            if (!_showTabs) return;

            for (int i = 0; i < TabCount; i++)
            {
                Rectangle r = GetTabRect(i);
                bool selected = (i == SelectedIndex);
                using (SolidBrush b = new SolidBrush(selected ? HmiTheme.Card : parentBack))
                {
                    g.FillRectangle(b, r);
                }
                if (selected)
                {
                    using (SolidBrush a = new SolidBrush(HmiTheme.Accent))
                    {
                        g.FillRectangle(a, r.X, r.Bottom - 3, r.Width, 3);
                    }
                }
                TextRenderer.DrawText(g, TabPages[i].Text, Font, r,
                    selected ? HmiTheme.Text : HmiTheme.TextMuted,
                    TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.EndEllipsis);
            }

            if (TabCount > 0)
            {
                Rectangle strip = GetTabRect(0);
                using (Pen p = new Pen(HmiTheme.CardBorder))
                {
                    g.DrawLine(p, 0, strip.Bottom, Width, strip.Bottom);
                }
            }
        }

        protected override void OnSelectedIndexChanged(System.EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            Invalidate();
        }
    }
}
