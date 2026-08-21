using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public enum WaferEditType
    {
        /// <summary>
        /// 
        /// </summary>
        NOEdit,

        /// <summary>
        /// 
        /// </summary>
        UnitEdit,

        /// <summary>
        /// 
        /// </summary>
        BinEdit
    }

    /// <summary>
    /// 
    /// </summary>
    public partial class WaferMapViewer : UserControl
    {
        private Rectangle realArea;
        private Rectangle drawArea;
        private Rectangle showArea;
        private Rectangle partArea;
        private Size shotSize;
        private Rectangle flatArea;
        private int[] unitSizeXs;
        private int[] unitSizeYs;

        private Map map;
        private Unit workUnit;
        private Unit selectedUnit;
        private Unit centerUnit;
        private Image image;


        //add by chs
        public Unit ChkUnit = null;
        public Color[] colors;

        /// <summary>
        /// 
        /// </summary>
        public WaferMapViewer()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint
                | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                , true);

            this.SelectionColor = Color.LightCoral;
            this.BackColor = Color.FromArgb(63, 63, 69);
            this.GridColor = Color.FromArgb(80, 80, 80);
            this.PickedColor = Color.FromArgb(220, 220, 220);
            this.PickedBoarderColor = Color.FromArgb(144, 147, 157);
            this.RejectColor = Color.FromArgb(255, 30, 30);
            this.BondedColor = Color.FromArgb(0, 192, 0);

            this.EmptyBinColor = Color.White;

            this.MinUnitSize = 6;
            this.FlatThickness = 6;
            this.FlatLength = 50;
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UnitSelectedEventArgs> UnitDoubleClicked;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UnitSelectedEventArgs> UnitSelected;

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public new bool AutoScroll { get => base.AutoScroll; set => base.AutoScroll = value; }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public new Size AutoScrollMargin { get => base.AutoScrollMargin; set => base.AutoScrollMargin = value; }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public new Size AutoScrollMinSize { get => base.AutoScrollMinSize; set => base.AutoScrollMinSize = value; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Data"), DefaultValue(false)]
        public bool Editable { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Data"), DefaultValue(WaferEditType.NOEdit)]
        public WaferEditType CurEdit { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of selection rectangle"),
            DefaultValue(typeof(Color), "System.Drawing.Color.LightCoral")]
        public Color SelectionColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of background"),
            DefaultValue(typeof(Color), "#3F3F45")]
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of grid"),
            DefaultValue(typeof(Color), "#505050")]
        public Color GridColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of picked die"),
            DefaultValue(typeof(Color), "#DCDCDC")]
        public Color PickedColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of bonded die"),
            DefaultValue(typeof(Color), "#3F3F45")]
        public Color BondedColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of reject die"),
            DefaultValue(typeof(Color), "#FF1E1E")]
        public Color RejectColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of empty bin"),
          DefaultValue(typeof(Color), "#FF1E1E")]
        public Color EmptyBinColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The boarder color of picked die"),
            DefaultValue(typeof(Color), "#90939D")]
        public Color PickedBoarderColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), DefaultValue(5)]
        public int MinUnitSize { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The thickness of flat"), DefaultValue(6)]
        public int FlatThickness { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The length of flat"), DefaultValue(50)]
        public int FlatLength { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public BinCollection bins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public UnitState SelectedUnitState { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public Bin SetBinType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public Map Map
        {
            get { return this.map; }
            set
            {
                if (this.map != value)
                {
                    this.selectedUnit = null;
                    this.SetScrollValue(this.vScrollBar, 0);
                    this.SetScrollValue(this.hScrollBar, 0);
                }
                else
                {
                    this.workUnit = null;
                }

                this.map = value;

                if (this.map != null)
                {
                    this.bins = this.map.Bins;
                }

                this.Invalidate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public Unit WorkUnit
        {
            get { return this.workUnit; }
            set
            {
                this.workUnit = value;

                if (this.map != null && this.workUnit != null)
                {
                    if (this.vScrollBar.Visible)
                    {
                        int row = 0;
                        if (this.map.IsMPW)
                        {
                            int rows = this.showArea.Height / this.shotSize.Height;
                            row = this.workUnit.BlockRow - rows / 2;
                            if (row < 0)
                            {
                                row = 0;
                            }
                        }
                        else
                        {
                            int rows = this.showArea.Height / this.unitSizeYs[0];
                            row = this.workUnit.Row - rows / 2;
                            if (row < 0)
                            {
                                row = 0;
                            }
                        }
                        this.SetScrollValue(this.vScrollBar, row);
                    }
                    if (this.hScrollBar.Visible)
                    {
                        int col = 0;
                        if (this.map.IsMPW)
                        {
                            int cols = this.showArea.Width / this.shotSize.Width;
                            col = this.workUnit.BlockColumn - cols / 2;
                            if (col < 0)
                            {
                                col = 0;
                            }
                        }
                        else
                        {
                            int cols = this.showArea.Width / this.unitSizeXs[0];
                            col = this.workUnit.Column - cols / 2;
                            if (col < 0)
                            {
                                col = 0;
                            }
                        }
                        this.SetScrollValue(this.hScrollBar, col);
                    }
                }

                this.Invalidate();
            }
        }

        [Browsable(false)]
        public Unit CenterUnit
        {
            get { return this.centerUnit; }
            set
            {
                this.centerUnit = value;

                this.Invalidate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            DrawBackground(g);

            CalcMapArea();

            //DrawFlat(g);

            if (this.image == null ||
                (this.image.Width != this.drawArea.Width || this.image.Height != this.drawArea.Height))
            {
                this.image = new Bitmap(this.drawArea.Width, this.drawArea.Height);
            }
            using (var graphics = Graphics.FromImage(this.image))
            {
                 DrawBackground(graphics);

                 DrawFrame(graphics);

                DrawAllDies(graphics);

                this.partArea = new Rectangle(0, 0, this.showArea.Width, this.showArea.Height);
                if (this.vScrollBar.Visible)
                {
                    int top = (this.map.IsMPW ? this.shotSize.Height : this.unitSizeYs[0]) * this.vScrollBar.Value;
                    int height = this.showArea.Height;
                    if ((top + height) > this.drawArea.Height)
                    {
                        top = this.drawArea.Height - height;
                    }
                    this.partArea.Y = top;
                    this.partArea.Height = height;
                }
                if (this.hScrollBar.Visible)
                {
                    int left = (this.map.IsMPW ? this.shotSize.Width : this.unitSizeXs[0]) * this.hScrollBar.Value;
                    int width = this.showArea.Width;
                    if ((left + width) > this.drawArea.Width)
                    {
                        left = this.drawArea.Width - width;
                    }
                    this.partArea.X = left;
                    this.partArea.Width = width;
                }

                g.DrawImage(image, this.showArea, this.partArea, GraphicsUnit.Pixel);
            }

            DrawSelection(g);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            this.vScrollBar.Left = this.Width - this.vScrollBar.Width;
            this.hScrollBar.Top = this.Height - this.hScrollBar.Height;
            this.vScrollBar.Height = this.hScrollBar.Top;
            this.hScrollBar.Width = this.vScrollBar.Left;
            this.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            if (this.Enabled && IsMapValid() && e.Button == MouseButtons.Left)
            {
                Unit unit = this.GetClickedUnit(e.X, e.Y);

                if (unit != null && unit.Bin != null)
                {
                    this.selectedUnit = unit;

                    switch (this.CurEdit)
                    {
                        case WaferEditType.UnitEdit:
                            unit.SetState(this.SelectedUnitState);
                            break;

                        case WaferEditType.BinEdit:
                            unit.Bin = this.SetBinType;
                            break;

                        default: break;
                    }

                    OnUnitSelected();

                    this.Invalidate();
                }
            }
        }

        private void OnUnitSelected()
        {
            if (this.UnitSelected != null)
            {
                this.UnitSelected(this, new UnitSelectedEventArgs(this.selectedUnit, null));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDoubleClick(MouseEventArgs e)
        {
            if (this.Enabled && IsMapValid() && this.selectedUnit != null && e.Button == MouseButtons.Left)
            {
                OnUnitDoubleClicked();
            }
        }

        private void OnUnitDoubleClicked()
        {
            if (this.UnitDoubleClicked != null)
            {
                this.UnitDoubleClicked(this, new UnitSelectedEventArgs(this.selectedUnit, null));
            }
        }

        private bool isDrag = false;
        private Rectangle mouseRect = new Rectangle(0, 0, 0, 0);
        private Point startPoint;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (this.CurEdit != WaferEditType.NOEdit && e.Button == MouseButtons.Left)
            {
                isDrag = true;
            }

            startPoint = e.Location;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (isDrag)
            {
                // Calculate the endpoint and dimensions for the new rectangle.
                Point endPoint = e.Location;
                mouseRect = this.GetRectangle(startPoint, endPoint);

                this.Invalidate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseUp(MouseEventArgs e)
        {
            // If the MouseUp event occurs, the user is not dragging.
            isDrag = false;

            if (this.CurEdit != WaferEditType.NOEdit)
            {
                if (IsMapValid())
                {
                    var rect = this.GetSelectRect();

                    this.SetSelectUnit(rect);
                }

                // Reset the rectangle.
                mouseRect = new Rectangle(0, 0, 0, 0);

                this.Invalidate();
            }
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            this.Invalidate();
        }

        private void DrawSelection(Graphics g)
        {
            if (this.isDrag)
            {
                using (Pen pen = new Pen(SelectionColor))
                {
                    g.DrawRectangle(pen, mouseRect);
                }
            }
        }

        private void DrawBackground(Graphics g)
        {
            g.Clear(this.BackColor);
        }

        private void DrawFrame(Graphics g)
        {
            if (!IsMapValid())
            {
                using (Brush b = new SolidBrush(this.PickedColor))
                {
                    g.FillEllipse(b, this.drawArea);
                }
            }
        }

        private void DrawFlat(Graphics g)
        {
            using (Brush b = new SolidBrush(Color.Black))
            {
                g.FillRectangle(b, this.flatArea);
            }
        }

        private void DrawAllDies(Graphics g)
        {
            if (!this.IsMapValid())
            {
                return;
            }

            if (this.map.IsMPW)
            {
                this.DrawMPWAllDies(g);
            }
            else
            {
                this.DrawSPWAllDies(g);
            }
        }

        private void DrawMPWAllDies(Graphics g)
        {
            if (this.map == null)
            {
                return;
            }

            for (int sr = 0; sr < map.BlockRows; sr++)
            {
                for (int sc = 0; sc < map.BlockColumns; sc++)
                {
                    int shotTop = this.drawArea.Top + sr * shotSize.Height;
                    int shotLeft = this.drawArea.Left + sc * shotSize.Width;

                    DrawShot(g, sr, sc, shotTop, shotLeft);
                }
            }
        }

        private void DrawShot(Graphics g, int sr, int sc, int shotTop, int shotLeft)
        {
            int top = shotTop;
            int height = 0;
            for (int r = 0; r < this.map.Rows; r++)
            {
                top += height;
                height = unitSizeYs[r];
                int left = shotLeft;
                int width = 0;
                for (int c = 0; c < this.map.Columns; c++)
                {
                    left += width;
                    width = unitSizeXs[c];

                    var unit = this.Map[sr, sc, r, c];
                    var rect = new Rectangle(left, top, width, height);

                    DrawUnit(g, unit, rect);
                }
            }

            DrawShotFrame(g, shotLeft, shotTop, this.shotSize.Width, this.shotSize.Height);

            DrawCircle(g);
        }

        private void DrawCircle(Graphics g)
        {
            if (this.map.IsMPW)
            {
                using (Pen p = new Pen(Color.White))
                {
                    g.DrawEllipse(p, this.drawArea);
                }
            }
        }

        private void DrawShotFrame(Graphics g, int x, int y, int width, int height)
        {
            if (this.map.IsMPW)
            {
                using (Pen p = new Pen(Color.White))
                {
                    g.DrawRectangle(p, x, y, width, height);
                }
            }
        }

        private void DrawUnit(Graphics g, Unit unit, Rectangle rect)
        {
            if (unit != null /*&& unit.Bin != this.Map.NullBin*/)
            {
                //Color cellColor = GetCellColor(unit);

                //if (unit.Bin == this.map.EmptyBin)
                //{
                //cellColor = Color.n
                //}


                /*
                if (unit.State == UnitState.Picked || unit.State == UnitState.Processed)
                {
                    var r = new Rectangle(rect.Left + 1, rect.Top + 1, rect.Width - 2, rect.Height - 2);
                    using (Brush brush = new SolidBrush(this.PickedColor))
                    {
                        g.FillRectangle(brush, r);
                    }
                    using (Pen pen = new Pen(PickedBoarderColor))
                    {
                        g.DrawRectangle(pen, r);
                    }
                }
                else if (unit.State == UnitState.Placed)
                {
                    using (Brush brush = new SolidBrush(this.BondedColor))
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
                else if (unit.State == UnitState.Reject)
                {
                    using (Brush brush = new SolidBrush(this.RejectColor))
                    {
                        g.FillRectangle(brush, rect);
                    }
                }
                else
                */

                if(-1 < unit.ColorNo && unit.ColorNo < colors.Length)
                {
                    using (Brush brush = new SolidBrush(colors[unit.ColorNo]))
                    {
                        g.FillRectangle(brush, rect);
                    }

                    DrawCenterUnit(g, unit, rect);
                    DrawWorkUnit(g, unit, rect);
                    DrawSelectedUnit(g, unit, rect);
                }

                using (Pen pen = new Pen(this.GridColor))
                {
                    g.DrawRectangle(pen, rect);
                }


                //if (unit.IsWorkUnit)
                {
                    using (Brush brush = new SolidBrush(this.ForeColor))
                    {
                        string s = unit.Desc;  //$"{unit.Index + 1}";
                        var size = g.MeasureString(s, this.Font);
                        var point = new PointF(rect.X + (rect.Width - size.Width) * 0.5f, rect.Y + (rect.Height - size.Height) * 0.5f);
                        g.DrawString(s, this.Font, brush, point);
                    }
                }
            }
        }

        private void DrawCenterUnit(Graphics g, Unit unit, Rectangle rect)
        {
            if (unit != null && this.centerUnit == unit)
            {
                var cx = rect.Left + rect.Width / 2;
                var cy = rect.Top + rect.Height / 2;
                var points = new Point[]{
                    new Point(rect.Left + 1, rect.Bottom - 1),
                    new Point(cx, cy),
                    new Point(rect.Right - 1, rect.Bottom - 1)
                };
                using (Brush brush = new SolidBrush(Color.Orange))
                    g.FillPolygon(brush, points);
            }
        }

        private void DrawWorkUnit(Graphics g, Unit unit, Rectangle rect)
        {
            if (unit != null && this.workUnit == unit)
            {
                var cx = rect.Left + rect.Width / 2;
                var cy = rect.Top + rect.Height / 2;
                var points = new Point[]{
                    new Point(cx, rect.Top + 1),
                    new Point(cx, cy),
                    new Point(rect.Right - 1, rect.Bottom - 1),
                    new Point(rect.Right - 1, rect.Top + 1)
                };
                using (Brush brush = new SolidBrush(Color.Blue))
                    g.FillPolygon(brush, points);
            }
        }

        private void DrawSelectedUnit(Graphics g, Unit unit, Rectangle rect)
        {
            if (this.Enabled && this.selectedUnit != null && this.selectedUnit == unit)
            {
                using (Pen pen = new Pen(Color.Black, 1))
                {
                    g.DrawLine(pen, rect.Left + 1, rect.Top + 1, rect.Left + 1, rect.Bottom - 2);
                    g.DrawLine(pen, rect.Left + 1, rect.Top + 1, rect.Right - 2, rect.Top + 1);
                }
                using (Pen pen = new Pen(Color.White, 1))
                {
                    g.DrawLine(pen, rect.Left + 1, rect.Bottom - 1, rect.Right - 1, rect.Bottom - 1);
                    g.DrawLine(pen, rect.Right - 1, rect.Top + 1, rect.Right - 1, rect.Bottom - 1);
                }
            }
        }

        private void DrawSPWAllDies(Graphics g)
        {
            for (int i = 0; i < this.map.Rows; i++)
            {
                for (int j = 0; j < this.map.Columns; j++)
                {
                    var unit = this.Map[i, j];
                    var rect = this.GetCellRect(i, j);

                    DrawUnit(g, unit, rect);
                }
            }
        }

        private void CalcMapArea()
        {
            this.HideAllScrolls();

            if (this.map == null)
            {
                this.CalcEmptyMapDrawArea();
                return;
            }

        __recalc:
            this.CalcShowArea();
            bool succ = this.CalcDrawArea();
            if (!succ)
            {
                goto __recalc;
            }
            this.CalcFlatArea();
        }

        private void CalcEmptyMapDrawArea()
        {
            var rect = new Rectangle(0, 0, this.Width, this.Height);

            Orientation or = this.Map == null ? Orientation.OT0 : this.Map.Orientation;

            switch (or)
            {
                case Orientation.OT0:
                    rect = new Rectangle(0, 0, this.Width, this.Height - this.FlatThickness);
                    break;
                case Orientation.OT90:
                    rect = new Rectangle(this.FlatThickness, 0, this.Width - this.FlatThickness, this.Height);
                    break;
                case Orientation.OT180:
                    rect = new Rectangle(0, this.FlatThickness, this.Width, this.Height - this.FlatThickness);
                    break;
                case Orientation.OT270:
                    rect = new Rectangle(0, 0, this.Width - this.FlatThickness, this.Height);
                    break;
                default:
                    break;
            }

            int min = rect.Width > rect.Height ? rect.Height : rect.Width;
            this.showArea = new Rectangle((rect.Width - min) / 2, (rect.Height - min) / 2, min, min);
            this.drawArea = new Rectangle(0, 0, min, min);

            this.CalcFlatArea();
        }

        private void CalcShowArea()
        {
            int scrollWidth = this.vScrollBar.Visible ? this.vScrollBar.Width : 0;
            int scrollHeight = this.hScrollBar.Visible ? this.hScrollBar.Height : 0;
            var rect = new Rectangle(0, 0, this.Width, this.Height);

            Orientation or = this.Map == null ? Orientation.OT0 : this.Map.Orientation;

            switch (or)
            {
                case Orientation.OT0:
                    rect = new Rectangle(0, 0, this.Width - scrollWidth, this.Height - this.FlatThickness - scrollHeight);
                    break;
                case Orientation.OT90:
                    rect = new Rectangle(this.FlatThickness, 0, this.Width - this.FlatThickness - scrollWidth, this.Height - scrollHeight);
                    break;
                case Orientation.OT180:
                    rect = new Rectangle(0, this.FlatThickness, this.Width - scrollWidth, this.Height - this.FlatThickness - scrollHeight);
                    break;
                case Orientation.OT270:
                    rect = new Rectangle(0, 0, this.Width - this.FlatThickness - scrollWidth, this.Height - scrollHeight);
                    break;
                default:
                    break;
            }

            int min = rect.Width > rect.Height ? rect.Height : rect.Width;
            this.showArea = new Rectangle((rect.Width - min) / 2, (rect.Height - min) / 2, min, min);
        }

        private bool CalcDrawArea()
        {
            if (this.map.IsMPW)
            {
                return this.CalcMPWDrawArea();
            }
            else
            {
                return this.CalcSPWDrawArea();
            }
        }

        private bool CalcSPWDrawArea()
        {
            //int lcm = this.LeastCommonMultiple(this.map.Rows, this.map.Columns);
            int unitX = this.MinUnitSize;
            int unitY = (int)System.Math.Floor(unitX * 1.0 * this.map.Columns / this.map.Rows);
            if (this.map.Rows > this.map.Columns)
            {
                unitY = this.MinUnitSize;
                unitX = (int)System.Math.Floor(unitY * 1.0 * this.map.Rows / this.map.Columns);
            }

            this.unitSizeXs = new int[] { unitX };
            this.unitSizeYs = new int[] { unitY };

            this.drawArea = new Rectangle(0, 0, unitX * this.map.Columns, unitY * this.map.Rows);
            this.realArea = this.drawArea;

            if (this.drawArea.Width <= this.showArea.Width &&
                this.drawArea.Height <= this.showArea.Height)
            {
                unitX = this.showArea.Width / this.map.Columns;
                unitY = this.showArea.Height / this.map.Rows;
                this.unitSizeXs = new int[] { unitX };
                this.unitSizeYs = new int[] { unitY };
                this.drawArea = new Rectangle(0, 0, this.showArea.Width, this.showArea.Height);
                this.realArea = new Rectangle(0, 0, unitX * this.map.Columns, unitY * this.map.Rows);
                this.vScrollBar.LargeChange = 1;
                this.vScrollBar.Maximum = 0;
                this.hScrollBar.LargeChange = 1;
                this.hScrollBar.Maximum = 0;
                return true;
            }

            bool prevVScrollVisible = this.vScrollBar.Visible;
            if (this.drawArea.Height > this.showArea.Height)
            {
                this.vScrollBar.Visible = true;
            }

            bool prevHScrollVisible = this.hScrollBar.Visible;
            if (this.drawArea.Width > this.showArea.Width)
            {
                this.hScrollBar.Visible = true;
            }

            if ((!prevVScrollVisible && this.vScrollBar.Visible) || (!prevHScrollVisible && this.hScrollBar.Visible))
            {
                return false;
            }

            int rows = 1;
            if (this.drawArea.Height > this.showArea.Height)
            {
                rows = this.map.Rows;// (int)Math.Ceiling(this.drawArea.Height * 1.0 / this.showArea.Height);
                this.vScrollBar.LargeChange = 30;
                this.vScrollBar.SmallChange = 10;
                this.vScrollBar.Maximum = rows - 1 - this.showArea.Height / this.unitSizeYs[0] + this.vScrollBar.LargeChange;
            }

            int cols = 1;
            if (this.drawArea.Width > this.showArea.Width)
            {
                cols = this.map.Columns;// (int)Math.Ceiling(this.drawArea.Width * 1.0 / this.showArea.Width);
                this.hScrollBar.LargeChange = 30;
                this.hScrollBar.SmallChange = 10;
                this.hScrollBar.Maximum = cols - 1 - this.showArea.Width / this.unitSizeXs[0] + this.hScrollBar.LargeChange;
            }

            return true;
        }

        private bool CalcMPWDrawArea()
        {
            int count = 0;
            double minUnitX = this.map.DieSizeXs.Min();
            double minUnitY = this.map.DieSizeYs.Min();

            int minUnitSizeX = this.MinUnitSize;
            int minUnitSizeY = this.MinUnitSize;

        __calc:
            if (minUnitX > minUnitY)
            {
                minUnitSizeX = (int)(minUnitSizeY * minUnitX / minUnitY);
            }
            else
            {
                minUnitSizeY = (int)(minUnitSizeX * minUnitY / minUnitX);
            }

            int rows = this.map.Rows;
            int cols = this.map.Columns;
            this.unitSizeXs = new int[cols];
            this.unitSizeYs = new int[rows];
            int shotSizeY = 0;
            for (int r = 0; r < rows; r++)
            {
                int y = (int)(minUnitSizeY * this.map.DieSizeYs[r] / minUnitY);
                this.unitSizeYs[r] = y;
                shotSizeY += y;
            }
            int shotSizeX = 0;
            for (int c = 0; c < cols; c++)
            {
                int x = (int)(minUnitSizeX * this.map.DieSizeXs[c] / minUnitX);
                this.unitSizeXs[c] = x;
                shotSizeX += x;
            }

            this.shotSize = new Size(shotSizeX, shotSizeY);

            int width = shotSizeX * map.BlockColumns;
            int height = shotSizeY * map.BlockRows;

            bool recalc = (width < this.showArea.Width) || (height < this.showArea.Height);

            if (recalc && count == 0)
            {
                count++;
                if (width < this.showArea.Width)
                {
                    shotSizeX = this.showArea.Width / map.BlockColumns;
                    minUnitSizeX = (int)(shotSizeX * minUnitX / map.ShotStepX);
                }

                if (height < this.showArea.Height)
                {
                    shotSizeY = this.showArea.Height / map.BlockRows;
                    minUnitSizeY = (int)(shotSizeY * minUnitY / map.ShotStepY);
                }
                goto __calc;
            }

            this.drawArea = new Rectangle(0, 0, width, height);
            this.realArea = this.drawArea;

            bool prevVScrollVisible = this.vScrollBar.Visible;
            if (this.drawArea.Height > this.showArea.Height)
            {
                this.vScrollBar.Visible = true;
            }

            bool prevHScrollVisible = this.hScrollBar.Visible;
            if (this.drawArea.Width > this.showArea.Width)
            {
                this.hScrollBar.Visible = true;
            }

            if ((!prevVScrollVisible && this.vScrollBar.Visible) || (!prevHScrollVisible && this.hScrollBar.Visible))
            {
                return false;
            }

            if (this.drawArea.Height > this.showArea.Height)
            {
                rows = this.map.BlockRows;
                this.vScrollBar.LargeChange = 2;
                this.vScrollBar.SmallChange = 1;
                this.vScrollBar.Maximum = rows - 1 - this.showArea.Height / this.shotSize.Height + this.vScrollBar.LargeChange;
            }

            if (this.drawArea.Width > this.showArea.Width)
            {
                cols = this.map.BlockColumns;
                this.hScrollBar.LargeChange = 2;
                this.hScrollBar.SmallChange = 1;
                this.hScrollBar.Maximum = cols - 1 - this.showArea.Width / this.shotSize.Width + this.hScrollBar.LargeChange;
            }

            return true;
        }

        private void CalcFlatArea()
        {
            int scrollWidth = this.vScrollBar.Visible ? this.vScrollBar.Width : 0;
            int scrollHeight = this.hScrollBar.Visible ? this.hScrollBar.Height : 0;
            int w = this.Width - scrollWidth;
            int h = this.Height - scrollHeight;

            Orientation or = this.Map == null ? Orientation.OT0 : this.Map.Orientation;

            switch (or)
            {
                case Orientation.OT0:
                    this.flatArea = new Rectangle((w - this.FlatLength) / 2, this.Height - this.FlatThickness - scrollHeight, this.FlatLength, this.FlatThickness);
                    break;
                case Orientation.OT90:
                    this.flatArea = new Rectangle(0, (h - this.FlatLength) / 2, this.FlatThickness, this.FlatLength);
                    break;
                case Orientation.OT180:
                    this.flatArea = new Rectangle((w - this.FlatLength) / 2, 0, this.FlatLength, this.FlatThickness);
                    break;
                case Orientation.OT270:
                    this.flatArea = new Rectangle(this.Width - this.FlatThickness - scrollWidth, (h - this.FlatLength) / 2, this.FlatThickness, this.FlatLength);
                    break;
                default:
                    break;
            }
        }

        private Rectangle GetCellRect(int row, int col)
        {
            int x = this.drawArea.Left + col * this.unitSizeXs[0];
            int y = this.drawArea.Top + row * this.unitSizeYs[0];

            return new Rectangle(x, y, this.unitSizeXs[0], this.unitSizeYs[0]);
        }

        private Color GetCellColor(Unit unit)
        {
            if (this.map.IsMPW)
            {
                try
                {
                    if (unit == null)
                    {
                        return Color.LightCyan;
                    }
                    var bin = this.map.ShotBins[unit.Row, unit.Column];
                    if (bin == null)
                    {
                        return Color.LightCyan;
                    }
                    return bin.Color;
                }
#pragma warning disable CS0168
                catch (Exception ex)
#pragma warning restore
                {
                    return Color.LightCyan;
                }
            }

            if (unit != null && unit.Bin != null)
            {
                return unit.Bin.Color;
            }

            return Color.Violet;
        }

        private Unit GetClickedUnit(int mouseX, int mouseY)
        {
            if (this.map.IsMPW)
            {
                return this.GetMPWClickedUnit(mouseX, mouseY);
            }
            else
            {
                return this.GetSPWClickedUnit(mouseX, mouseY);
            }
        }

        private Unit GetMPWClickedUnit(int mouseX, int mouseY)
        {
            double dx = (mouseX - this.showArea.Left) + this.partArea.Left;
            int sc = (int)System.Math.Floor(dx * this.map.BlockColumns / this.drawArea.Width);

            double dy = (mouseY - this.showArea.Top) + this.partArea.Top;
            int sr = (int)System.Math.Floor(dy * this.map.BlockRows / this.drawArea.Height);

            int c = 0;
            double remainX = dx - this.shotSize.Width * sc;
            int sx = 0;
            for (int i = 0; i < this.map.Columns; i++)
            {
                sx += this.unitSizeXs[i];
                if (sx >= remainX)
                {
                    c = i;
                    break;
                }
            }

            int r = 0;
            double remainY = dy - this.shotSize.Height * sr;
            int sy = 0;
            for (int i = 0; i < this.map.Rows; i++)
            {
                sy += this.unitSizeYs[i];
                if (sy >= remainY)
                {
                    r = i;
                    break;
                }
            }

            return this.map[sr, sc, r, c];
        }

        private Unit GetSPWClickedUnit(int mouseX, int mouseY)
        {
            double dx = (mouseX - this.showArea.Left) + this.partArea.Left;
            int col = (int)System.Math.Floor(dx / this.unitSizeXs[0]);

            double dy = (mouseY - this.showArea.Top) + this.partArea.Top;
            int row = (int)System.Math.Floor(dy / this.unitSizeYs[0]);

            ChkUnit = this.map[row, col];
            return this.map[row, col];
        }

        private bool IsMapValid()
        {
            return this.Map != null;
        }

        private void HideAllScrolls()
        {
            this.vScrollBar.Visible = false;
            this.hScrollBar.Visible = false;
        }

        private void SetScrollValue(ScrollBar scroll, int value)
        {
            if (this.IsDisposed || !this.IsHandleCreated)
                return;
            this.BeginInvoke((MethodInvoker)delegate
            {
                int v = value;
                if (v < scroll.Minimum)
                {
                    v = scroll.Minimum;
                }
                if (v > scroll.Maximum)
                {
                    v = scroll.Maximum;
                }
                scroll.Value = v;
            });
        }

        private bool IsDesignMode()
        {
            bool isDesignMode = false;

#if DEBUG
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                isDesignMode = true;
            }
            else if (Process.GetCurrentProcess().ProcessName == "devenv")
            {
                isDesignMode = true;
            }
#endif

            return isDesignMode;
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            int x = p1.X, w = p2.X - p1.X;
            if (p1.X > p2.X)
            {
                x = p2.X;
                w = p1.X - p2.X;
            }
            int y = p1.Y, h = p2.Y - p1.Y;
            if (p1.Y > p2.Y)
            {
                x = p2.Y;
                w = p1.Y - p2.Y;
            }

            return new Rectangle(x, y, w, h);
        }

        private Rectangle GetSelectRect()
        {
            var rect = Rectangle.Intersect(this.mouseRect, this.showArea);
            if (rect.IsEmpty)
                return Rectangle.Empty;

            var r1 = Rectangle.FromLTRB(
                (rect.X - this.showArea.X) + this.partArea.X,
                (rect.Y - this.showArea.Y) + this.partArea.Y,
                (rect.Right - this.showArea.Right) + this.partArea.Right,
                (rect.Bottom - this.showArea.Bottom) + this.partArea.Bottom);
            return Rectangle.Intersect(this.realArea, r1);
        }

        private void SetSelectUnit(Rectangle rect)
        {
            if (rect.IsEmpty)
            {
                return;
            }

            var su = this.GetSelectUnit(rect.X, rect.Y);
            if (su == null)
            {
                return;
            }
            var eu = this.GetSelectUnit(rect.Right, rect.Bottom);
            if (eu == null)
            {
                return;
            }

            if (this.map.IsMPW)
            {
                SetMPWSelectUnit(su, eu);
            }
            else
            {
                SetSPWSelectUnit(su, eu);
            }
        }

        private void SetMPWSelectUnit(Unit su, Unit eu)
        {
            for (int br = su.BlockRow; br <= eu.BlockRow; br++)
            {
                for (int bc = su.BlockColumn; bc <= eu.BlockColumn; bc++)
                {
                    int sr = 0, er = this.map.Rows - 1;
                    int sc = 0, ec = this.map.Columns - 1;
                    if (su.BlockRow == eu.BlockRow)
                    {
                        sr = su.Row;
                        er = eu.Row;
                    }
                    else if (br == su.BlockRow)
                    {
                        sr = su.Row;
                        er = this.map.Rows - 1;
                    }
                    else if (br == eu.BlockRow)
                    {
                        sr = 0;
                        er = eu.Row;
                    }
                    if (su.BlockColumn == eu.BlockColumn)
                    {
                        sc = su.Column;
                        ec = eu.Column;
                    }
                    else if (bc == su.BlockColumn)
                    {
                        sc = su.Column;
                        ec = this.map.Columns - 1;
                    }
                    else if (bc == eu.BlockColumn)
                    {
                        sc = 0;
                        ec = eu.Column;
                    }
                    for (int r = sr; r <= er; r++)
                    {
                        for (int c = sc; c <= ec; c++)
                        {
                            var unit = this.Map[br, bc, r, c];

                            if (unit != null && unit.Bin != this.Map.NullBin)
                            {
                                switch (this.CurEdit)
                                {
                                    case WaferEditType.UnitEdit:
                                        unit.SetState(this.SelectedUnitState);
                                        break;

                                    case WaferEditType.BinEdit:
                                        unit.Bin = this.SetBinType;
                                        break;

                                    default: break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void SetSPWSelectUnit(Unit su, Unit eu)
        {
            for (int br = su.BlockRow; br <= eu.BlockRow; br++)
            {
                for (int bc = su.BlockColumn; bc <= eu.BlockColumn; bc++)
                {
                    for (int r = su.Row; r <= eu.Row; r++)
                    {
                        for (int c = su.Column; c <= eu.Column; c++)
                        {
                            var unit = this.Map[br, bc, r, c];

                            if (unit != null && unit.Bin != this.Map.NullBin)
                            {
                                switch (this.CurEdit)
                                {
                                    case WaferEditType.UnitEdit:
                                        unit.SetState(this.SelectedUnitState);
                                        break;

                                    case WaferEditType.BinEdit:
                                        unit.Bin = this.SetBinType;
                                        break;

                                    default: break;
                                }
                            }
                        }
                    }
                }
            }
        }

        private Unit GetSelectUnit(int mouseX, int mouseY)
        {
            if (this.map.IsMPW)
            {
                return this.GetMPWSelectUnit(mouseX, mouseY);
            }
            else
            {
                return this.GetSPWSelectUnit(mouseX, mouseY);
            }
        }

        private Unit GetMPWSelectUnit(int mouseX, int mouseY)
        {
            int sc = mouseX / this.shotSize.Width;
            if (sc >= this.map.BlockColumns)
            {
                sc = this.map.BlockColumns - 1;
            }

            int sr = mouseY / this.shotSize.Height;
            if (sr >= this.map.BlockRows)
            {
                sr = this.map.BlockRows - 1;
            }

            int c = 0;
            double remainX = mouseX - this.shotSize.Width * sc;
            int sx = 0;
            for (int i = 0; i < this.map.Columns; i++)
            {
                sx += this.unitSizeXs[i];
                if (sx >= remainX)
                {
                    c = i;
                    break;
                }
            }

            int r = 0;
            double remainY = mouseY - this.shotSize.Height * sr;
            int sy = 0;
            for (int i = 0; i < this.map.Rows; i++)
            {
                sy += this.unitSizeYs[i];
                if (sy >= remainY)
                {
                    r = i;
                    break;
                }
            }

            return this.map[sr, sc, r, c];
        }

        private Unit GetSPWSelectUnit(int mouseX, int mouseY)
        {
            int col = mouseX / this.unitSizeXs[0];
            if (col >= this.map.Columns)
            {
                col = this.map.Columns - 1;
            }

            int row = mouseY / this.unitSizeYs[0];
            if (row >= this.map.Rows)
            {
                row = this.map.Rows - 1;
            }

            return this.map[row, col];
        }

        private int LeastCommonMultiple(int num1, int num2)
        {
            int tmp = num1;
            if (num1 < num2)
            {
                tmp = num1;
                num1 = num2;
                num2 = tmp;
            }

            int a = num1, b = num2;
            while (b != 0)
            {
                tmp = a % b;
                a = b;
                b = tmp;
            }

            int lcm = num1 * num2 / a;
            return lcm;
        }
    }
}


