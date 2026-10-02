using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace MMI
{
    // The grid every screen uses: a standard DataGridView, themed, with the
    // small part of the ComponentOne FlexGrid programming model the screens
    // were written against.
    //
    // FlexGrid numbers rows and columns from the top-left corner including its
    // header ("fixed") rows and columns, and a screen with a two row header
    // reads its first data row as row 2. HmiGrid keeps that numbering: header
    // rows are ordinary rows, frozen, read-only and drawn as headers, and the
    // DataGridView's own column header is switched off. gd[r, c] therefore
    // means the same cell it did before, and so do Rows.Fixed, Cols[c].Width,
    // GetCellRange and MergedRanges.
    //
    // New screens can use it as a plain DataGridView; the compatible members
    // are there so the existing screens did not have to be rewritten.
    public class HmiGrid : DataGridView
    {
        private readonly HmiGridRows _rows;
        private readonly HmiGridCols _cols;
        private readonly HmiGridStyles _styles;
        private readonly List<CellRange> _merged = new List<CellRange>();
        private readonly Dictionary<long, Image> _images = new Dictionary<long, Image>();
        private readonly Dictionary<long, CellStyle> _cellStyles = new Dictionary<long, CellStyle>();
        private int _fixedRows = 1;
        private int _fixedCols = 1;
        private int _pendingRows = -1;
        private int _defaultRowHeight = 25;
        private int _defaultColWidth = 100;
        private int _updateDepth;
        private bool _allowEditing = true;
        private int _mouseRow = -1;
        private int _mouseCol = -1;

        public HmiGrid()
        {
            _rows = new HmiGridRows(this);
            _cols = new HmiGridCols(this);
            _styles = new HmiGridStyles();

            DoubleBuffered = true;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToOrderColumns = false;
            RowHeadersVisible = false;
            ColumnHeadersVisible = false;
            MultiSelect = false;
            base.SelectionMode = DataGridViewSelectionMode.CellSelect;
            EditMode = DataGridViewEditMode.EditOnKeystrokeOrF2;
            RowTemplate.Height = _defaultRowHeight;
            ScrollBars = ScrollBars.Both;

            HmiTheme.StyleGrid(this);
            _styles.Fixed.Changed += (s, e) => Invalidate();
        }

        #region FlexGrid compatible members

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new HmiGridRows Rows { get { return _rows; } }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HmiGridCols Cols { get { return _cols; } }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public HmiGridStyles Styles { get { return _styles; } }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<CellRange> MergedRanges { get { return _merged; } }

        public object this[int row, int col]
        {
            get
            {
                if (!IsCell(row, col)) return null;
                return base.Rows[row].Cells[col].Value;
            }
            set
            {
                if (!IsCell(row, col)) return;
                base.Rows[row].Cells[col].Value = value;
            }
        }

        // Grid level edit switch; a column can still be locked on its own.
        [DefaultValue(true)]
        public bool AllowEditing
        {
            get { return _allowEditing; }
            set { _allowEditing = value; ApplyReadOnly(); }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Row
        {
            get { return CurrentCell != null ? CurrentCell.RowIndex : -1; }
            set
            {
                int c = CurrentCell != null ? CurrentCell.ColumnIndex : Math.Min(_fixedCols, ColumnCount - 1);
                SelectCell(value, c);
            }
        }

        [Browsable(false), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Col
        {
            get { return CurrentCell != null ? CurrentCell.ColumnIndex : -1; }
            set
            {
                int r = CurrentCell != null ? CurrentCell.RowIndex : Math.Min(_fixedRows, RowCount - 1);
                SelectCell(r, value);
            }
        }

        [Browsable(false)]
        public int MouseRow { get { return _mouseRow; } }

        [Browsable(false)]
        public int MouseCol { get { return _mouseCol; } }

        // FlexGrid's designer string: "count,fixed,?,?,?,defaultWidth,Columns:0{...}\t1{...}".
        // Only the shape is read - counts, widths, captions, edit and visible
        // flags. Colours and fonts are the theme's.
        [DefaultValue("")]
        public string ColumnInfo
        {
            get { return ""; }
            set { ApplyColumnInfo(value); }
        }

        private void SelectCell(int row, int col)
        {
            if (!IsCell(row, col) || !Columns[col].Visible || !base.Rows[row].Visible) return;
            CurrentCell = base.Rows[row].Cells[col];
        }

        // Empties every cell and drops cell styles, images and merges. The
        // screens call it before rebuilding a grid from scratch.
        public void Clear()
        {
            foreach (DataGridViewRow r in base.Rows)
            {
                foreach (DataGridViewCell c in r.Cells) c.Value = null;
            }
            _cellStyles.Clear();
            _images.Clear();
            _merged.Clear();
            Invalidate();
        }

        // Sorts the data rows on one column, numerically when every value
        // parses as a number. Header rows stay where they are.
        public void Sort(SortFlags order, int col)
        {
            if (col < 0 || col >= ColumnCount || RowCount <= _fixedRows) return;
            List<object[]> rows = new List<object[]>();
            for (int r = _fixedRows; r < RowCount; r++)
            {
                object[] v = new object[ColumnCount];
                for (int c = 0; c < ColumnCount; c++) v[c] = base.Rows[r].Cells[c].Value;
                rows.Add(v);
            }
            bool numeric = true;
            foreach (object[] v in rows)
            {
                double d;
                if (v[col] != null && !double.TryParse(Convert.ToString(v[col]), out d)) { numeric = false; break; }
            }
            Comparison<object[]> cmp = (a, b) =>
            {
                if (numeric)
                {
                    double da = 0, db = 0;
                    if (a[col] != null) double.TryParse(Convert.ToString(a[col]), out da);
                    if (b[col] != null) double.TryParse(Convert.ToString(b[col]), out db);
                    return da.CompareTo(db);
                }
                return string.Compare(Convert.ToString(a[col]), Convert.ToString(b[col]), StringComparison.CurrentCulture);
            };
            rows.Sort(cmp);
            if (order == SortFlags.Descending) rows.Reverse();
            for (int i = 0; i < rows.Count; i++)
            {
                for (int c = 0; c < ColumnCount; c++) base.Rows[_fixedRows + i].Cells[c].Value = rows[i][c];
            }
        }

        public void BeginUpdate()
        {
            if (_updateDepth++ == 0) SuspendLayout();
        }

        public void EndUpdate()
        {
            if (_updateDepth == 0) return;
            if (--_updateDepth == 0)
            {
                ResumeLayout();
                Invalidate();
            }
        }

        public CellRange GetCellRange(int row, int col)
        {
            return new CellRange(this, row, col, row, col);
        }

        public CellRange GetCellRange(int r1, int c1, int r2, int c2)
        {
            return new CellRange(this, r1, c1, r2, c2);
        }

        public void SetCellImage(int row, int col, Image image)
        {
            long key = Key(row, col);
            if (image == null) _images.Remove(key);
            else _images[key] = image;
            if (IsCell(row, col)) InvalidateCell(col, row);
        }

        // FlexGrid wrote .xls; this writes the same table as tab separated
        // text next to it, which Excel opens directly.
        public void SaveExcel(string fileName, string sheetName, FileFlags flags)
        {
            string path = Path.ChangeExtension(fileName, ".csv");
            if (!string.IsNullOrEmpty(sheetName) && File.Exists(path) && !path.Contains(sheetName))
            {
                path = Path.Combine(Path.GetDirectoryName(path) ?? "",
                    Path.GetFileNameWithoutExtension(path) + "_" + sheetName + ".csv");
            }
            bool bFixed = (flags & FileFlags.IncludeFixedCells) != 0;
            StringBuilder sb = new StringBuilder();
            for (int r = bFixed ? 0 : _fixedRows; r < RowCount; r++)
            {
                if (!base.Rows[r].Visible) continue;
                for (int c = bFixed ? 0 : _fixedCols; c < ColumnCount; c++)
                {
                    if (!Columns[c].Visible) continue;
                    object v = base.Rows[r].Cells[c].Value;
                    sb.Append(v == null ? "" : v.ToString().Replace('\t', ' '));
                    sb.Append(c == ColumnCount - 1 ? "" : "\t");
                }
                sb.AppendLine();
            }
            File.WriteAllText(path, sb.ToString(), Encoding.UTF8);
        }

        public event RowColEventHandler AfterEdit;
        public event EventHandler SelChange;
        public event OwnerDrawCellEventHandler OwnerDrawCell;

        #endregion

        #region internals used by the row, column and range helpers

        internal int FixedRows
        {
            get { return _fixedRows; }
            set { _fixedRows = Math.Max(0, value); ApplyFixed(); }
        }

        internal int FixedCols
        {
            get { return _fixedCols; }
            set { _fixedCols = Math.Max(0, value); ApplyFixed(); }
        }

        internal int DefaultRowHeight
        {
            get { return _defaultRowHeight; }
            set
            {
                _defaultRowHeight = Math.Max(10, value);
                RowTemplate.Height = _defaultRowHeight;
                foreach (DataGridViewRow r in base.Rows) r.Height = _defaultRowHeight;
            }
        }

        internal int DefaultColWidth
        {
            get { return _defaultColWidth; }
            set { _defaultColWidth = Math.Max(5, value); }
        }

        internal DataGridViewRowCollection BaseRows { get { return base.Rows; } }

        internal void SetRowCount(int count)
        {
            count = Math.Max(0, count);
            if (ColumnCount == 0)
            {
                _pendingRows = count;
                return;
            }
            if (RowCount < count) base.Rows.Add(count - RowCount);
            while (RowCount > count) base.Rows.RemoveAt(RowCount - 1);
            ApplyFixed();
        }

        internal void SetColCount(int count)
        {
            count = Math.Max(0, count);
            while (ColumnCount < count)
            {
                DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
                col.SortMode = DataGridViewColumnSortMode.NotSortable;
                col.Width = _defaultColWidth;
                Columns.Add(col);
            }
            while (ColumnCount > count) Columns.RemoveAt(ColumnCount - 1);
            if (_pendingRows >= 0 && ColumnCount > 0)
            {
                int n = _pendingRows;
                _pendingRows = -1;
                SetRowCount(n);
            }
            ApplyFixed();
        }

        internal bool IsCell(int row, int col)
        {
            return row >= 0 && col >= 0 && row < RowCount && col < ColumnCount;
        }

        internal bool IsFixed(int row, int col)
        {
            return row < _fixedRows || col < _fixedCols;
        }

        internal void SetCellStyle(int row, int col, CellStyle style)
        {
            long key = Key(row, col);
            if (style == null) _cellStyles.Remove(key);
            else _cellStyles[key] = style;
        }

        internal void ApplyReadOnly()
        {
            for (int c = 0; c < ColumnCount; c++)
            {
                HmiGridCol col = _cols[c];
                Columns[c].ReadOnly = !_allowEditing || !col.AllowEditing || c < _fixedCols;
            }
            for (int r = 0; r < Math.Min(_fixedRows, RowCount); r++)
            {
                base.Rows[r].ReadOnly = true;
            }
        }

        private void ApplyFixed()
        {
            for (int r = 0; r < RowCount; r++)
            {
                base.Rows[r].Frozen = r < _fixedRows;
            }
            for (int c = 0; c < ColumnCount; c++)
            {
                Columns[c].Frozen = c < _fixedCols;
            }
            ApplyReadOnly();
        }

        private static long Key(int row, int col)
        {
            return ((long)row << 32) | (uint)col;
        }

        private void ApplyColumnInfo(string info)
        {
            if (string.IsNullOrEmpty(info)) return;

            int head = info.IndexOf("Columns:", StringComparison.Ordinal);
            string[] shape = (head >= 0 ? info.Substring(0, head) : info).Split(',');
            int count, fixedCols, width;
            if (shape.Length > 0 && int.TryParse(shape[0], out count)) SetColCount(count);
            if (shape.Length > 1 && int.TryParse(shape[1], out fixedCols)) FixedCols = fixedCols;
            if (shape.Length > 5 && int.TryParse(shape[5], out width))
            {
                DefaultColWidth = width;
                for (int c = 0; c < ColumnCount; c++) Columns[c].Width = width;
            }
            if (head < 0) return;

            foreach (string part in info.Substring(head + 8).Split('\t'))
            {
                int open = part.IndexOf('{');
                int idx;
                if (open <= 0 || !int.TryParse(part.Substring(0, open), out idx)) continue;
                if (idx >= ColumnCount) continue;

                string body = part.Substring(open + 1).TrimEnd('}', ';');
                foreach (string kv in SplitTopLevel(body))
                {
                    int colon = kv.IndexOf(':');
                    if (colon <= 0) continue;
                    string k = kv.Substring(0, colon);
                    string v = kv.Substring(colon + 1).Trim('"');
                    switch (k)
                    {
                        case "Width":
                            int w;
                            if (int.TryParse(v, out w)) Columns[idx].Width = w;
                            break;
                        case "Caption":
                            Columns[idx].HeaderText = v;
                            if (_fixedRows > 0 && RowCount > 0) base.Rows[0].Cells[idx].Value = v;
                            break;
                        case "AllowEditing":
                            _cols[idx].AllowEditing = !string.Equals(v, "False", StringComparison.OrdinalIgnoreCase);
                            break;
                        case "Visible":
                            Columns[idx].Visible = !string.Equals(v, "False", StringComparison.OrdinalIgnoreCase);
                            break;
                    }
                }
            }
        }

        // Splits "a:1;b:\"x;y\";c:2" on the semicolons outside quotes.
        private static IEnumerable<string> SplitTopLevel(string s)
        {
            StringBuilder sb = new StringBuilder();
            bool quoted = false;
            foreach (char ch in s)
            {
                if (ch == '"') quoted = !quoted;
                if (ch == ';' && !quoted)
                {
                    yield return sb.ToString();
                    sb.Clear();
                    continue;
                }
                sb.Append(ch);
            }
            if (sb.Length > 0) yield return sb.ToString();
        }

        #endregion

        #region events and painting

        protected override void OnCellEndEdit(DataGridViewCellEventArgs e)
        {
            base.OnCellEndEdit(e);
            AfterEdit?.Invoke(this, new RowColEventArgs(e.RowIndex, e.ColumnIndex));
        }

        protected override void OnCurrentCellChanged(EventArgs e)
        {
            base.OnCurrentCellChanged(e);
            SelChange?.Invoke(this, EventArgs.Empty);
        }

        protected override void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            _mouseRow = e.RowIndex;
            _mouseCol = e.ColumnIndex;
            base.OnCellMouseEnter(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            HitTestInfo hit = HitTest(e.X, e.Y);
            _mouseRow = hit.RowIndex;
            _mouseCol = hit.ColumnIndex;
            base.OnMouseDown(e);
        }

        private CellRange MergedAt(int row, int col)
        {
            foreach (CellRange r in _merged)
            {
                if (r.Contains(row, col)) return r;
            }
            return null;
        }

        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            if (e.Handled || e.RowIndex < 0 || e.ColumnIndex < 0) return;

            int row = e.RowIndex, col = e.ColumnIndex;
            OwnerDrawCell?.Invoke(this, new OwnerDrawCellEventArgs(row, col, e.Graphics, e.CellBounds));

            bool bFixed = IsFixed(row, col);
            CellRange merged = MergedAt(row, col);
            Rectangle area = e.CellBounds;
            object value = e.Value;
            int valueRow = row, valueCol = col;

            if (merged != null)
            {
                int x = e.CellBounds.X, y = e.CellBounds.Y;
                for (int c = col - 1; c >= merged.c1; c--) if (Columns[c].Visible) x -= Columns[c].Width;
                for (int r = row - 1; r >= merged.r1; r--) if (base.Rows[r].Visible) y -= base.Rows[r].Height;
                int w = 0, h = 0;
                for (int c = merged.c1; c <= merged.c2 && c < ColumnCount; c++) if (Columns[c].Visible) w += Columns[c].Width;
                for (int r = merged.r1; r <= merged.r2 && r < RowCount; r++) if (base.Rows[r].Visible) h += base.Rows[r].Height;
                area = new Rectangle(x, y, w, h);
                valueRow = merged.r1;
                valueCol = merged.c1;
                value = base.Rows[valueRow].Cells[valueCol].Value;
            }

            CellStyle style;
            _cellStyles.TryGetValue(Key(valueRow, valueCol), out style);
            CellStyle colStyle = (valueCol < ColumnCount) ? _cols[valueCol].StyleNew : null;

            bool bSelected = !bFixed && (e.State & DataGridViewElementStates.Selected) != 0;

            Color back = bFixed ? HmiTheme.GridHeader : HmiTheme.Card;
            Color fore = bFixed ? HmiTheme.TextMuted : HmiTheme.Text;
            Font font = bFixed ? (_styles.Fixed.Font ?? HmiTheme.FontBold) : (Font ?? HmiTheme.FontBody);
            TextAlignEnum align = bFixed ? _styles.Fixed.TextAlignOr(TextAlignEnum.CenterCenter)
                                         : _cols[valueCol].TextAlign;

            if (!bFixed)
            {
                if (colStyle != null) ApplyStyle(colStyle, ref back, ref fore, ref font, ref align);
                if (!Columns[valueCol].ReadOnly) back = HmiTheme.Input;
            }
            else if (_cols[valueCol].StyleFixed.HasFont)
            {
                font = _cols[valueCol].StyleFixed.Font;
            }
            if (style != null) ApplyStyle(style, ref back, ref fore, ref font, ref align);
            if (bSelected) back = HmiTheme.Selection;

            Graphics g = e.Graphics;
            Region oldClip = g.Clip;
            g.SetClip(e.CellBounds);

            using (SolidBrush b = new SolidBrush(back)) g.FillRectangle(b, area);
            using (Pen p = new Pen(HmiTheme.GridLine))
            {
                g.DrawLine(p, area.Left, area.Bottom - 1, area.Right - 1, area.Bottom - 1);
                g.DrawLine(p, area.Right - 1, area.Top, area.Right - 1, area.Bottom - 1);
            }

            Image img;
            if (_images.TryGetValue(Key(valueRow, valueCol), out img) && img != null)
            {
                int side = Math.Max(4, Math.Min(area.Width, area.Height) - 8);
                Rectangle ir = new Rectangle(area.X + (area.Width - side) / 2, area.Y + (area.Height - side) / 2, side, side);
                g.DrawImage(img, ir);
            }

            string text = value == null ? "" : Convert.ToString(value);
            if (text.Length > 0)
            {
                Rectangle tr = Rectangle.Inflate(area, -4, 0);
                TextRenderer.DrawText(g, text, font, tr, fore, ToFlags(align)
                    | TextFormatFlags.EndEllipsis | TextFormatFlags.NoPrefix | TextFormatFlags.WordBreak);
            }

            g.Clip = oldClip;
            e.Handled = true;
        }

        private static void ApplyStyle(CellStyle s, ref Color back, ref Color fore, ref Font font, ref TextAlignEnum align)
        {
            if (s.HasBackColor) back = s.BackColor;
            if (s.HasForeColor) fore = s.ForeColor;
            if (s.HasFont) font = s.Font;
            if (s.HasTextAlign) align = s.TextAlign;
        }

        private static TextFormatFlags ToFlags(TextAlignEnum a)
        {
            switch (a)
            {
                case TextAlignEnum.LeftCenter:   return TextFormatFlags.Left | TextFormatFlags.VerticalCenter;
                case TextAlignEnum.RightCenter:  return TextFormatFlags.Right | TextFormatFlags.VerticalCenter;
                case TextAlignEnum.LeftTop:      return TextFormatFlags.Left | TextFormatFlags.Top;
                case TextAlignEnum.CenterTop:    return TextFormatFlags.HorizontalCenter | TextFormatFlags.Top;
                case TextAlignEnum.RightTop:     return TextFormatFlags.Right | TextFormatFlags.Top;
                case TextAlignEnum.LeftBottom:   return TextFormatFlags.Left | TextFormatFlags.Bottom;
                case TextAlignEnum.CenterBottom: return TextFormatFlags.HorizontalCenter | TextFormatFlags.Bottom;
                case TextAlignEnum.RightBottom:  return TextFormatFlags.Right | TextFormatFlags.Bottom;
                default:                         return TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            }
        }

        #endregion
    }

    #region FlexGrid compatible helper types

    public enum TextAlignEnum
    {
        LeftTop, LeftCenter, LeftBottom,
        CenterTop, CenterCenter, CenterBottom,
        RightTop, RightCenter, RightBottom,
        GeneralTop, GeneralCenter, GeneralBottom,
    }

    public enum ImageAlignEnum { CenterCenter, TileStretch, Stretch, LeftCenter, RightCenter }

    public enum SortFlags { None, Ascending, Descending }

    [Flags]
    public enum FileFlags { None = 0, IncludeFixedCells = 1, AsDisplayed = 2 }

    public class RowColEventArgs : EventArgs
    {
        public RowColEventArgs(int row, int col) { Row = row; Col = col; }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public bool Cancel { get; set; }
    }
    public delegate void RowColEventHandler(object sender, RowColEventArgs e);

    public class OwnerDrawCellEventArgs : EventArgs
    {
        public OwnerDrawCellEventArgs(int row, int col, Graphics g, Rectangle bounds)
        {
            Row = row; Col = col; Graphics = g; Bounds = bounds;
        }
        public int Row { get; private set; }
        public int Col { get; private set; }
        public Graphics Graphics { get; private set; }
        public Rectangle Bounds { get; private set; }
    }
    public delegate void OwnerDrawCellEventHandler(object sender, OwnerDrawCellEventArgs e);

    // A cell style. Only what was set is applied; the rest stays the theme's.
    // Colours from the light palette the screens were written with are
    // translated, so an old "Bisque means editable" still reads as editable on
    // the dark theme.
    public class CellStyle
    {
        private Color _back, _fore;
        private Font _font;
        private TextAlignEnum _align;

        public string Name { get; internal set; }
        internal bool HasBackColor, HasForeColor, HasFont, HasTextAlign;
        internal event EventHandler Changed;

        public Color BackColor
        {
            get { return _back; }
            set { _back = HmiTheme.MapLegacyBack(value); HasBackColor = true; Changed?.Invoke(this, EventArgs.Empty); }
        }
        public Color ForeColor
        {
            get { return _fore; }
            set { _fore = HmiTheme.MapLegacyFore(value); HasForeColor = true; Changed?.Invoke(this, EventArgs.Empty); }
        }
        public Font Font
        {
            get { return _font; }
            set { _font = HmiTheme.MapLegacyFont(value); HasFont = value != null; Changed?.Invoke(this, EventArgs.Empty); }
        }
        public TextAlignEnum TextAlign
        {
            get { return _align; }
            set { _align = value; HasTextAlign = true; Changed?.Invoke(this, EventArgs.Empty); }
        }
        internal TextAlignEnum TextAlignOr(TextAlignEnum fallback) { return HasTextAlign ? _align : fallback; }
    }

    public class HmiGridStyles
    {
        private readonly Dictionary<string, CellStyle> _named = new Dictionary<string, CellStyle>();
        public HmiGridStyles() { Fixed = new CellStyle { Name = "Fixed" }; Normal = new CellStyle { Name = "Normal" }; }
        public CellStyle Fixed { get; private set; }
        public CellStyle Normal { get; private set; }
        public CellStyle Add(string name)
        {
            CellStyle s = new CellStyle { Name = name };
            _named[name] = s;
            return s;
        }
        public CellStyle this[string name]
        {
            get { CellStyle s; return _named.TryGetValue(name, out s) ? s : null; }
        }
    }

    public class CellRange
    {
        private readonly HmiGrid _grid;
        public int r1, c1, r2, c2;

        internal CellRange(HmiGrid grid, int row1, int col1, int row2, int col2)
        {
            _grid = grid;
            r1 = Math.Min(row1, row2); r2 = Math.Max(row1, row2);
            c1 = Math.Min(col1, col2); c2 = Math.Max(col1, col2);
        }

        public bool Contains(int row, int col)
        {
            return row >= r1 && row <= r2 && col >= c1 && col <= c2;
        }

        // Applies the style to every cell in the range.
        public CellStyle Style
        {
            get { return null; }
            set
            {
                for (int r = r1; r <= r2; r++)
                    for (int c = c1; c <= c2; c++)
                        _grid.SetCellStyle(r, c, value);
                _grid.Invalidate();
            }
        }

        public object Data
        {
            get { return _grid[r1, c1]; }
            set
            {
                for (int r = r1; r <= r2; r++)
                    for (int c = c1; c <= c2; c++)
                        _grid[r, c] = value;
            }
        }
    }

    public class HmiGridRow
    {
        private readonly HmiGrid _grid;
        private readonly int _index;
        internal HmiGridRow(HmiGrid grid, int index) { _grid = grid; _index = index; }

        public int Index { get { return _index; } }

        public int Height
        {
            get { return _grid.BaseRows[_index].Height; }
            set { _grid.BaseRows[_index].Height = Math.Max(3, value); }
        }

        public bool Visible
        {
            get { return _grid.BaseRows[_index].Visible; }
            set { _grid.BaseRows[_index].Visible = value; }
        }

        // Pixel offset of the row from the top of the grid, as FlexGrid gave it.
        public int Top
        {
            get
            {
                int y = 0;
                for (int r = 0; r < _index; r++)
                {
                    if (_grid.BaseRows[r].Visible) y += _grid.BaseRows[r].Height;
                }
                return y;
            }
        }
    }

    public class HmiGridRows
    {
        private readonly HmiGrid _grid;
        internal HmiGridRows(HmiGrid grid) { _grid = grid; }

        public int Count
        {
            get { return _grid.RowCount; }
            set { _grid.SetRowCount(value); }
        }

        public int Fixed
        {
            get { return _grid.FixedRows; }
            set { _grid.FixedRows = value; }
        }

        public int DefaultSize
        {
            get { return _grid.DefaultRowHeight; }
            set { _grid.DefaultRowHeight = value; }
        }

        public HmiGridRow this[int index] { get { return new HmiGridRow(_grid, index); } }
    }

    public class HmiGridCol
    {
        private readonly HmiGrid _grid;
        private readonly int _index;
        internal HmiGridCol(HmiGrid grid, int index, HmiGridColState state) { _grid = grid; _index = index; State = state; }
        internal HmiGridColState State { get; private set; }

        public int Index { get { return _index; } }

        public int Width
        {
            get { return _grid.Columns[_index].Width; }
            set { _grid.Columns[_index].Width = Math.Max(2, value); }
        }

        public bool Visible
        {
            get { return _grid.Columns[_index].Visible; }
            set { _grid.Columns[_index].Visible = value; }
        }

        public string Caption
        {
            get { return _grid.Columns[_index].HeaderText; }
            set
            {
                _grid.Columns[_index].HeaderText = value;
                if (_grid.FixedRows > 0 && _grid.RowCount > 0) _grid[0, _index] = value;
            }
        }

        public bool AllowEditing
        {
            get { return State.AllowEditing; }
            set { State.AllowEditing = value; _grid.ApplyReadOnly(); }
        }

        public bool AllowResizing
        {
            get { return _grid.Columns[_index].Resizable == DataGridViewTriState.True; }
            set { _grid.Columns[_index].Resizable = value ? DataGridViewTriState.True : DataGridViewTriState.False; }
        }

        public TextAlignEnum TextAlign
        {
            get { return State.TextAlign; }
            set { State.TextAlign = value; _grid.Invalidate(); }
        }

        // Images are drawn centred and scaled to the cell; kept for the
        // screens that still set it.
        public ImageAlignEnum ImageAlign { get; set; }

        public CellStyle StyleNew { get { return State.Style; } }
        public CellStyle Style
        {
            get { return State.Style; }
            set
            {
                if (value == null) return;
                if (value.HasBackColor) State.Style.BackColor = value.BackColor;
                if (value.HasForeColor) State.Style.ForeColor = value.ForeColor;
                if (value.HasFont) State.Style.Font = value.Font;
                if (value.HasTextAlign) State.Style.TextAlign = value.TextAlign;
            }
        }
        public CellStyle StyleFixed { get { return State.StyleFixed; } }

        // Pixel offset of the column from the left of the grid.
        public int Left
        {
            get
            {
                int x = 0;
                for (int c = 0; c < _index; c++)
                {
                    if (_grid.Columns[c].Visible) x += _grid.Columns[c].Width;
                }
                return x;
            }
        }
    }

    internal class HmiGridColState
    {
        public bool AllowEditing = true;
        public TextAlignEnum TextAlign = TextAlignEnum.CenterCenter;
        public readonly CellStyle Style = new CellStyle();
        public readonly CellStyle StyleFixed = new CellStyle();
    }

    public class HmiGridCols
    {
        private readonly HmiGrid _grid;
        private readonly Dictionary<int, HmiGridColState> _state = new Dictionary<int, HmiGridColState>();
        internal HmiGridCols(HmiGrid grid) { _grid = grid; }

        public int Count
        {
            get { return _grid.ColumnCount; }
            set { _grid.SetColCount(value); }
        }

        public int Fixed
        {
            get { return _grid.FixedCols; }
            set { _grid.FixedCols = value; }
        }

        public int DefaultSize
        {
            get { return _grid.DefaultColWidth; }
            set
            {
                _grid.DefaultColWidth = value;
                for (int c = 0; c < _grid.ColumnCount; c++) _grid.Columns[c].Width = value;
            }
        }

        public HmiGridCol this[int index]
        {
            get
            {
                HmiGridColState s;
                if (!_state.TryGetValue(index, out s))
                {
                    s = new HmiGridColState();
                    s.Style.Changed += (o, e) => _grid.Invalidate();
                    _state[index] = s;
                }
                return new HmiGridCol(_grid, index, s);
            }
        }
    }

    #endregion
}
