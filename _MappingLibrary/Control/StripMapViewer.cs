using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Mapping
{
    public partial class StripMapViewer : UserControl
    {
        //add by chs
        public Unit ChkUnit = null;
        public Color[] colors;
        //
        private Rectangle firstBlockArea;
        private int cellWidth;
        private int cellHeight;

        private Unit selectedUnit;

        /// <summary>
        /// 
        /// </summary>
        public StripMapViewer()
        {
            InitializeComponent();

            SetStyle(ControlStyles.UserPaint
                | ControlStyles.ResizeRedraw
                | ControlStyles.SupportsTransparentBackColor
                | ControlStyles.AllPaintingInWmPaint
                | ControlStyles.OptimizedDoubleBuffer
                , true);

            this.BackColor = Color.FromArgb(63, 63, 69);
            this.ForeColor = Color.FromArgb(255, 255, 255);
            this.SelectedColor = Color.FromArgb(255, 255, 255);
            this.WorkColor = Color.FromArgb(0, 0, 255);

            this.GoodColor = Color.FromArgb(100, 128, 100);
            this.AttachedColor = Color.FromArgb(150, 200, 200);
            this.RejectColor = Color.FromArgb(255, 30, 30);
            this.ReworkColor = Color.FromArgb(128, 255, 0);
            //this.ReworkColor = Color.FromArgb(0, 64, 0);
            this.IndicatorColor = Color.FromArgb(255, 255, 0);
            this.SelectionColor = Color.LightCoral;

            this.BlockSpace = 12;
            this.CellSpace = 1;
            this.IndicatorLineWidth = 4;
        }

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler<UnitSelectedEventArgs> UnitSelected;

        public event EventHandler<UnitSelectedEventArgs> UnitDoubleClicked;

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
        [Category("Appearance"), Description("The color of background"),
            DefaultValue(typeof(Color), "#3F3F45")]
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of text"),
            DefaultValue(typeof(Color), "#FFFFFF")]
        public override Color ForeColor { get => base.ForeColor; set => base.ForeColor = value; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of select pad"),
            DefaultValue(typeof(Color), "#FFFFFF")]
        public Color SelectedColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of work pad"),
            DefaultValue(typeof(Color), "#0000FF")]
        public Color WorkColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of good pad"),
            DefaultValue(typeof(Color), "#648064")]
        public Color GoodColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of attached pad"),
            DefaultValue(typeof(Color), "#96C8C8")]
        public Color AttachedColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of reject pad"),
            DefaultValue(typeof(Color), "#FF1E1E")]
        public Color RejectColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of attached pad"),
            DefaultValue(typeof(Color), "#80FF00")]
        public Color ReworkColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of current pad indicator"),
            DefaultValue(typeof(Color), "#FFFF00")]
        public Color IndicatorColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Appearance"), Description("The color of selection rectangle"),
           DefaultValue(typeof(Color), "System.Drawing.Color.LightCoral")]
        public Color SelectionColor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Data"), DefaultValue(12)]
        public int BlockSpace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Data"), DefaultValue(1)]
        public int CellSpace { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Category("Data"), DefaultValue(4)]
        public int IndicatorLineWidth { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public UnitState SelectedUnitState { get; set; }

        private Map map;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public Map Map
        {
            set
            {
                if (this.map != value)
                {
                    this.selectedUnit = null;
                }

                this.map = value;

                CalcDrawArea();

                this.Invalidate();
            }
        }

        private Unit workUnit;
        /// <summary>
        /// 
        /// </summary>
        [Browsable(false)]
        public Unit WorkUnit
        {
            set
            {
                this.workUnit = value;

                this.Invalidate();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Unit SelectedUnit
        {
            get => this.selectedUnit;
            private set
            {
                this.selectedUnit = value;
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

            if (!IsMapValid())
            {
                return;
            }

            DrawPads(g);

            DrawWorkUnit(g);

            DrawSelectedUnit(g);

            //DrawNumbers(g);

            DrawSelection(g);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnResize(EventArgs e)
        {
            CalcDrawArea();

            this.Invalidate();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void OnMouseClick(MouseEventArgs e)
        {
            ChkUnit = null;

            if (this.Enabled)
            {
                Unit unit = this.HitTest(e.X, e.Y);
                if (unit != null)
                {
                    this.SelectedUnit = unit;

                    if (this.Editable)
                    {
                        unit.SetState(this.SelectedUnitState);
                    }

                    OnUnitSelected(unit);

                    this.Invalidate();

                    ChkUnit = unit;
                }
            }
        }

        private void OnUnitSelected(Unit unit)
        {
            if (this.UnitSelected != null)
            {
                this.UnitSelected(this, new UnitSelectedEventArgs(unit, null));
            }
        }

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
            if (this.Editable && e.Button == MouseButtons.Left)
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

                int width = endPoint.X - startPoint.X;
                int height = endPoint.Y - startPoint.Y;
                mouseRect = new Rectangle(startPoint.X, startPoint.Y, width, height);

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

            if (this.Editable)
            {
                if (IsMapValid())
                {
                    for (int br = 0; br < this.map.BlockRows; br++)
                    {
                        for (int bc = 0; bc < this.map.BlockColumns; bc++)
                        {
                            for (int r = 0; r < this.map.Rows; r++)
                            {
                                for (int c = 0; c < this.map.Columns; c++)
                                {
                                    var unit = this.map[br, bc, r, c];

                                    if (!(unit is null))
                                    {
                                        var padRect = GetUnitRect(br, bc, r, c);

                                        if (mouseRect.IntersectsWith(padRect))
                                        {
                                            unit.SetState(this.SelectedUnitState);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                // Reset the rectangle.
                mouseRect = new Rectangle(0, 0, 0, 0);

                this.Invalidate();
            }
        }

        private void DrawBackground(Graphics g)
        {
            g.Clear(this.BackColor);
        }

        private void DrawPads(Graphics g)
        {
            for (int br = 0; br < this.map.BlockRows; br++)
            {
                for (int bc = 0; bc < this.map.BlockColumns; bc++)
                {
                    for (int r = 0; r < this.map.Rows; r++)
                    {
                        for (int c = 0; c < this.map.Columns; c++)
                        {
                            DrawPad(g, br, bc, r, c);
                        }
                    }
                }
            }
        }

        private void DrawPad(Graphics g, int blockRow, int blockColumn, int row, int column)
        {
            var rect = GetUnitRect(blockRow, blockColumn, row, column);
            var unit = this.map[blockRow, blockColumn, row, column];

            if (-1 < unit.ColorNo && unit.ColorNo < colors.Length)
            {
                using (Brush brush = new SolidBrush(colors[unit.ColorNo]))
                {
                    g.FillRectangle(brush, rect);
                }
            }
            else
            {
                using (Pen pen = new Pen(Color.FromArgb(80, 80, 80)))
                {
                    g.DrawRectangle(pen, rect);
                }
            }


            {
                using (Brush brush = new SolidBrush(Color.Black))//this.ForeColor
                {
                    string s = unit.Desc;  //$"{unit.Index + 1}";
                    var size = g.MeasureString(s, this.Font);
                    var point = new PointF(rect.X + (rect.Width - size.Width) * 0.5f, rect.Y + (rect.Height - size.Height) * 0.5f);
                    g.DrawString(s, this.Font, brush, point);
                }
            }
            /*
            var color = GetUnitColor(unit);

            using (Brush b = new SolidBrush(color))
            {
                g.FillRectangle(b, rect);
            }*/
        }

        private void DrawWorkUnit(Graphics g)
        {
            if (this.workUnit != null)
            {
                var rect = GetUnitRect(this.workUnit.BlockRow, this.workUnit.BlockColumn, this.workUnit.Row, this.workUnit.Column);

                DrawIndicator(g, rect);

                rect.X -= 2;
                rect.Y -= 2;
                rect.Width += 3;
                rect.Height += 3;

                using (Pen p = new Pen(this.WorkColor))
                {
                    g.DrawRectangle(p, rect);
                }
            }
        }

        private void DrawIndicator(Graphics g, Rectangle rect)
        {
            // TODO: draw it by OriginLocation

            using (Brush b = new SolidBrush(this.IndicatorColor))
            {
                var r = new Rectangle(rect.X, 0, rect.Width, this.IndicatorLineWidth);
                g.FillRectangle(b, r);
            }

            using (Brush b = new SolidBrush(this.IndicatorColor))
            {
                var r = new Rectangle(0, rect.Y, this.IndicatorLineWidth, rect.Height);
                g.FillRectangle(b, r);
            }
        }

        private void DrawNumbers(Graphics g)
        {
            // TODO: draw it by OriginLocation

            int rows = this.map.BlockRows * this.map.Rows;
            int columns = this.map.BlockColumns * this.map.Columns;

            using (Brush brush = new SolidBrush(this.ForeColor))
            {
                for (int i = 0; i < rows; i++)
                {
                    int number = rows - 1 - i;
                    if (number == 0 || number == (rows - 1) || (((number + 1) % 5) == 0))
                    {
                        string numberString = (number + 1).ToString();

                        var size = g.MeasureString(numberString, this.Font);

                        int w = (int)System.Math.Ceiling(size.Width);
                        int h = (int)System.Math.Ceiling(size.Height);

                        int br = i / this.map.Rows;
                        int r = i % this.map.Rows;
                        int x = this.Width - this.BlockSpace + (this.BlockSpace - w) / 2;
                        int y = this.firstBlockArea.Y + (this.firstBlockArea.Height + this.BlockSpace) * br + (this.cellHeight + this.CellSpace) * r + (this.cellHeight - h) / 2;

                        g.DrawString(numberString, this.Font, brush, x, y);
                    }
                }

                for (int i = 0; i < columns; i++)
                {
                    int number = columns - 1 - i;
                    if (number == 0 || number == (columns - 1) || (((number + 1) % 5) == 0))
                    {
                        string numberString = (number + 1).ToString();

                        var size = g.MeasureString(numberString, this.Font);

                        int w = (int)System.Math.Ceiling(size.Width);
                        int h = (int)System.Math.Ceiling(size.Height);

                        int bc = i / this.map.Columns;
                        int c = i % this.map.Columns;
                        int x = this.firstBlockArea.X + (this.firstBlockArea.Width + this.BlockSpace) * bc + (this.cellWidth + this.CellSpace) * c + (this.cellWidth - w) / 2;
                        int y = this.Height - h - 1;

                        g.DrawString(numberString, this.Font, brush, x, y);
                    }
                }
            }
        }

        private void DrawSelectedUnit(Graphics g)
        {
            if (this.selectedUnit != null)
            {
                var rect = GetUnitRect(this.selectedUnit.BlockRow, this.selectedUnit.BlockColumn, this.selectedUnit.Row, this.selectedUnit.Column);

                rect.X -= 2;
                rect.Y -= 2;
                rect.Width += 3;
                rect.Height += 3;

                using (Pen p = new Pen(this.SelectedColor))
                {
                    g.DrawRectangle(p, rect);
                }
            }
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

        private void CalcDrawArea()
        {
            if (IsMapValid())
            {
                int width = (this.Width - this.BlockSpace * (this.map.BlockColumns + 1)) / this.map.BlockColumns;
                int height = (this.Height - this.BlockSpace * (this.map.BlockRows + 1)) / this.map.BlockRows;

                this.cellWidth = (width - this.CellSpace * (this.map.Columns - 1)) / this.map.Columns;
                this.cellHeight = (height - this.CellSpace * (this.map.Rows - 1)) / this.map.Rows;

                width = this.cellWidth * this.map.Columns + this.CellSpace * (this.map.Columns - 1);
                height = this.cellHeight * this.map.Rows + this.CellSpace * (this.map.Rows - 1);

                int x = (this.Width - width * this.map.BlockColumns) / (this.map.BlockColumns + 1);
                int y = (this.Height - height * this.map.BlockRows) / (this.map.BlockRows + 1);

                this.firstBlockArea = new Rectangle(x, y, width, height);
            }
            else
            {

            }
        }

        private Rectangle GetUnitRect(int blockRow, int blockColumn, int row, int column)
        {
            int x = this.firstBlockArea.X + (this.firstBlockArea.Width + this.BlockSpace) * blockColumn + (this.cellWidth + this.CellSpace) * column;
            int y = this.firstBlockArea.Y + (this.firstBlockArea.Height + this.BlockSpace) * blockRow + (this.cellHeight + this.CellSpace) * row;
            int width = this.cellWidth;
            int height = this.cellHeight;

            return new Rectangle(x, y, width, height);
        }

        private Color GetUnitColor(Unit unit)
        {
            var map = new Dictionary<UnitState, Color>()
            {
                { UnitState.Good, this.GoodColor },
                { UnitState.Placed, this.AttachedColor },
                { UnitState.Processed, Color.White },
                { UnitState.Reject, this.RejectColor }
            };

            return map[unit.State];
        }

        private Unit HitTest(int mouseX, int mouseY)
        {
            if (!IsMapValid())
            {
                return null;
            }

            int left = this.firstBlockArea.X;
            int top = this.firstBlockArea.Y;
            int right = this.firstBlockArea.X + (this.firstBlockArea.Width + this.BlockSpace) * (this.map.BlockColumns - 1) + (this.cellWidth + this.CellSpace) * this.map.Columns;
            int bottom = this.firstBlockArea.Y + (this.firstBlockArea.Height + this.BlockSpace) * (this.map.BlockRows - 1) + (this.cellHeight + this.CellSpace) * this.map.Rows;

            if (mouseX < left || mouseX > right ||
                mouseY < top || mouseY > bottom)
            {
                return null;
            }

            int blockRow = (mouseY - this.firstBlockArea.Y) / (this.firstBlockArea.Height + this.BlockSpace);
            int blockColumn = (mouseX - this.firstBlockArea.X) / (this.firstBlockArea.Width + this.BlockSpace);

            int row = (mouseY - this.firstBlockArea.Y - (this.firstBlockArea.Height + this.BlockSpace) * blockRow) / (this.cellHeight + this.CellSpace);
            int column = (mouseX - this.firstBlockArea.X - (this.firstBlockArea.Width + this.BlockSpace) * blockColumn) / (this.cellWidth + this.CellSpace);

            if (blockRow < 0 || blockRow >= this.map.BlockRows ||
                blockColumn < 0 || blockColumn >= this.map.BlockColumns ||
                row < 0 || row >= this.map.Rows ||
                column < 0 || column >= this.map.Columns)
            {
                return null;
            }

            return this.map[blockRow, blockColumn, row, column];
        }

        private bool IsMapValid()
        {
            return this.map != null;
        }
    }
}


