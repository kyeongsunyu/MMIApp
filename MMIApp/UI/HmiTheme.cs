using System.Drawing;
using System.Windows.Forms;

namespace MMI
{
    // L11 high-performance dark theme. Every colour and font the screens use
    // comes from here, so a later light variant or a customer palette is a
    // change to this one file.
    //
    // ISA-101: the screen is grey, and colour is spent only on state that needs
    // attention - red for an alarm, amber for a warning, green for running and
    // blue for "the operator has to do something here".
    public static class HmiTheme
    {
        public static readonly Color TopBar        = Color.FromArgb(0x12, 0x14, 0x17);
        public static readonly Color Rail          = Color.FromArgb(0x16, 0x18, 0x1B);
        public static readonly Color Background    = Color.FromArgb(0x1B, 0x1D, 0x21);
        public static readonly Color Card          = Color.FromArgb(0x25, 0x28, 0x2D);
        public static readonly Color CardBorder    = Color.FromArgb(0x33, 0x37, 0x3D);
        public static readonly Color Input         = Color.FromArgb(0x1B, 0x1D, 0x21);
        public static readonly Color Control       = Color.FromArgb(0x30, 0x34, 0x3A);
        public static readonly Color ControlHover  = Color.FromArgb(0x3A, 0x3F, 0x46);
        public static readonly Color GridLine      = Color.FromArgb(0x33, 0x37, 0x3D);
        public static readonly Color GridHeader    = Color.FromArgb(0x2C, 0x30, 0x36);
        public static readonly Color Selection     = Color.FromArgb(0x1F, 0x3A, 0x64);

        public static readonly Color Text          = Color.FromArgb(0xE6, 0xE6, 0xE6);
        public static readonly Color TextMuted     = Color.FromArgb(0x9A, 0xA0, 0xA6);
        public static readonly Color TextDisabled  = Color.FromArgb(0x5F, 0x64, 0x6B);

        public static readonly Color Accent        = Color.FromArgb(0x3D, 0x8B, 0xFD);
        public static readonly Color Alarm         = Color.FromArgb(0xE5, 0x48, 0x4D);
        public static readonly Color Normal        = Color.FromArgb(0x30, 0xA4, 0x6C);
        public static readonly Color Warning       = Color.FromArgb(0xF5, 0xA5, 0x24);

        public static readonly Color AlarmBanner     = Color.FromArgb(0x3A, 0x1D, 0x20);
        public static readonly Color AlarmBannerText = Color.FromArgb(0xF2, 0xD0, 0xD2);

        public const string FontName = "Malgun Gothic";
        public const string IconFontName = "Segoe MDL2 Assets";

        public static readonly Font FontSmall   = new Font(FontName, 9F,  FontStyle.Regular);
        public static readonly Font FontBody    = new Font(FontName, 10F, FontStyle.Regular);
        public static readonly Font FontBold    = new Font(FontName, 10F, FontStyle.Bold);
        public static readonly Font FontCaption = new Font(FontName, 11F, FontStyle.Regular);
        public static readonly Font FontTitle   = new Font(FontName, 12F, FontStyle.Bold);
        public static readonly Font FontValue   = new Font(FontName, 24F, FontStyle.Bold);
        public static readonly Font FontIcon    = new Font(IconFontName, 16F, FontStyle.Regular);

        // Paints the standard controls in a container that a designer file laid
        // out with default colours. Hmi* controls paint themselves and are
        // skipped, as is anything a screen has deliberately coloured with a
        // state colour after this runs.
        public static void Apply(Control root)
        {
            ApplyOne(root);
            foreach (Control child in root.Controls)
            {
                Apply(child);
            }
        }

        private static void ApplyOne(Control c)
        {
            if (c is HmiButton || c is HmiCard) return;

            if (c is Form || c is UserControl)
            {
                c.BackColor = Background;
                c.ForeColor = Text;
            }
            else if (c is TextBox || c is ComboBox || c is NumericUpDown || c is ListBox)
            {
                c.BackColor = Input;
                c.ForeColor = Text;
                if (c is TextBox) ((TextBox)c).BorderStyle = BorderStyle.FixedSingle;
                if (c is ComboBox) ((ComboBox)c).FlatStyle = FlatStyle.Flat;
            }
            else if (c is CheckBox || c is RadioButton)
            {
                c.ForeColor = Text;
                c.BackColor = Color.Transparent;
            }
            else if (c is Label)
            {
                c.ForeColor = Text;
            }
            else if (c is Button)
            {
                Button b = (Button)c;
                b.FlatStyle = FlatStyle.Flat;
                b.FlatAppearance.BorderColor = CardBorder;
                b.FlatAppearance.MouseOverBackColor = ControlHover;
                b.BackColor = Control;
                b.ForeColor = Text;
            }
            else if (c is GroupBox)
            {
                c.ForeColor = TextMuted;
            }
            else if (c is DataGridView)
            {
                StyleGrid((DataGridView)c);
            }
            else if (c is ListView)
            {
                c.BackColor = Input;
                c.ForeColor = Text;
            }
        }

        public static void StyleGrid(DataGridView g)
        {
            g.BackgroundColor = Card;
            g.BorderStyle = BorderStyle.None;
            g.GridColor = GridLine;
            g.EnableHeadersVisualStyles = false;
            g.CellBorderStyle = DataGridViewCellBorderStyle.Single;
            g.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            g.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            g.DefaultCellStyle.BackColor = Card;
            g.DefaultCellStyle.ForeColor = Text;
            g.DefaultCellStyle.SelectionBackColor = Selection;
            g.DefaultCellStyle.SelectionForeColor = Text;
            g.DefaultCellStyle.Font = FontBody;

            g.ColumnHeadersDefaultCellStyle.BackColor = GridHeader;
            g.ColumnHeadersDefaultCellStyle.ForeColor = TextMuted;
            g.ColumnHeadersDefaultCellStyle.SelectionBackColor = GridHeader;
            g.ColumnHeadersDefaultCellStyle.Font = FontBold;
            g.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            g.RowHeadersDefaultCellStyle.BackColor = GridHeader;
            g.RowHeadersDefaultCellStyle.ForeColor = TextMuted;
            g.RowHeadersDefaultCellStyle.SelectionBackColor = GridHeader;
        }
    }
}
