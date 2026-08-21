using System;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class Unit
    {
        private UnitState unitState;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="bin"></param>
        /// <param name="blockRow"></param>
        /// <param name="blockColumn"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="unitState"></param>
        public Unit(IMap map, int blockRow, int blockColumn, int row, int column, int color, string txt)
        {
            this.Map = map;
            //this.Bin = bin;
            this.BlockRow = blockRow;
            this.BlockColumn = blockColumn;
            this.Row = row;
            this.Column = column;
            ColorNo = color;
            Desc = txt;
        }

        /// <summary>
        /// 
        /// </summary>
        public IMap Map { get; }

        public int ColorNo { get; set; }
        public string Desc { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Bin Bin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int BlockRow { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public int BlockColumn { get; internal set; }

        /// <summary>
        /// 
        /// </summary>
        public int Row { get; internal set; }

        public int OriginRow
        {
            get => this.GetOriginRow();
        }

        /// <summary>
        /// 
        /// </summary>
        public int Column { get; internal set; }

        public int OriginColumn
        {
            get => this.GetOriginColumn();
        }

        /// <summary>
        /// 
        /// </summary>
        public int Index { get; internal set; } = -1;

        /// <summary>
        /// 
        /// </summary>
        public Direction Direction
        {
            get => this.GetDirection();
        }

        /// <summary>
        /// 
        /// </summary>
        public UnitState State
        {
            get => this.unitState;
            set
            {
                this.SetState(value);
            }
        }

        /// <summary>
        /// Unit global position in X-coordination.
        /// </summary>
        public double X { get; private set; }

        /// <summary>
        /// Unit global position in Y-coordination.
        /// </summary>
        public double Y { get; private set; }

        /// <summary>
        /// Unit global position in Z-coordination.
        /// </summary>
        public double Z { get; private set; }

        /// <summary>
        /// Unit global position in T-coordination.
        /// </summary>
        public double T { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsWorkUnit
        {
            get => ((this.Bin != null) && this.Bin.Work);
        }

        /// <summary>
        /// 
        /// </summary>
        public bool IsNullBin
        {
            get => this.Map.IsNullBin(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitState"></param>
        public virtual void SetState(UnitState unitState)
        {
            this.unitState = unitState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public void SetPosition(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <param name="t"></param>
        public void SetPosition(double x, double y, double z, double t)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.T = t;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Unit Left()
        {
            return this.Map.Left(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Unit Right()
        {
            return this.Map.Right(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Unit Up()
        {
            return this.Map.Up(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Unit Down()
        {
            return this.Map.Down(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as Unit);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(Unit obj)
        {
            if (obj is null)
            {
                return false;
            }

            bool equal = (this.BlockRow == obj.BlockRow &&
                          this.BlockColumn == obj.BlockColumn &&
                          this.Row == obj.Row &&
                          this.Column == obj.Column);

            return equal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(Unit left, Unit right)
        {
            if (left is null)
            {
                return (right is null);
            }

            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(Unit left, Unit right)
        {
            return !(left == right);
        }

        private Direction GetDirection()
        {
            if (this.Map.WorkDirection == WorkDirection.LT_RIGHT_S)
            {
                bool isEvenRow = ((this.Row + 1) & 1) == 1;

                if (isEvenRow)
                {
                    if (this.Column == this.Map.Columns - 1)
                    {
                        return Direction.DOWN;
                    }

                    return Direction.RIGHT;
                }

                if (this.Column == 0)
                {
                    return Direction.DOWN;
                }

                return Direction.LEFT;
            }

            if (this.Map.WorkDirection == WorkDirection.RT_LEFT_S)
            {
                bool isEvenRow = ((this.Row + 1) & 1) == 1;

                if (isEvenRow)
                {
                    if (this.Column == 0)
                    {
                        return Direction.DOWN;
                    }

                    return Direction.LEFT;
                }

                if (this.Column == this.Map.Columns - 1)
                {
                    return Direction.DOWN;
                }

                return Direction.RIGHT;
            }

            if (this.Map.WorkDirection == WorkDirection.LT_DOWN_S)
            {
                bool isEvenCol = ((this.Column + 1) & 1) == 1;

                if (isEvenCol)
                {
                    if (this.Row == this.Map.Rows - 1)
                    {
                        return Direction.RIGHT;
                    }

                    return Direction.DOWN;
                }

                if (this.Row == 0)
                {
                    return Direction.RIGHT;
                }

                return Direction.UP;
            }

            if (this.Map.WorkDirection == WorkDirection.RT_DOWN_S)
            {
                bool isEvenCol = ((this.Map.Columns - this.Column) & 1) == 1;

                if (isEvenCol)
                {
                    if (this.Row == this.Map.Rows - 1)
                    {
                        return Direction.LEFT;
                    }

                    return Direction.DOWN;
                }

                if (this.Row == 0)
                {
                    return Direction.LEFT;
                }

                return Direction.UP;
            }

            if (this.Map.WorkDirection == WorkDirection.LB_UP_S)
            {
                bool isEvenCol = ((this.Column + 1) & 1) == 1;

                if (isEvenCol)
                {
                    if (this.Row == 0)
                    {
                        return Direction.RIGHT;
                    }

                    return Direction.UP;
                }

                if (this.Row == this.Map.Rows - 1)
                {
                    return Direction.RIGHT;
                }

                return Direction.DOWN;
            }

            if (this.Map.WorkDirection == WorkDirection.RB_UP_S)
            {
                bool isEvenCol = ((this.Map.Columns - this.Column) & 1) == 1;

                if (isEvenCol)
                {
                    if (this.Row == 0)
                    {
                        return Direction.LEFT;
                    }

                    return Direction.UP;
                }

                if (this.Row == this.Map.Rows - 1)
                {
                    return Direction.LEFT;
                }

                return Direction.DOWN;
            }

            if (this.Map.WorkDirection == WorkDirection.LB_RIGHT_S)
            {
                bool isEvenRow = ((this.Map.Rows - this.Row) & 1) == 1;

                if (isEvenRow)
                {
                    if (this.Column == this.Map.Columns - 1)
                    {
                        return Direction.UP;
                    }

                    return Direction.RIGHT;
                }

                if (this.Column == 0)
                {
                    return Direction.UP;
                }

                return Direction.LEFT;
            }

            if (this.Map.WorkDirection == WorkDirection.RB_LEFT_S)
            {
                bool isEvenRow = ((this.Map.Rows - this.Row) & 1) == 1;

                if (isEvenRow)
                {
                    if (this.Column == 0)
                    {
                        return Direction.UP;
                    }

                    return Direction.LEFT;
                }

                if (this.Column == this.Map.Columns - 1)
                {
                    return Direction.UP;
                }

                return Direction.RIGHT;
            }

            return default(Direction);
        }

        private int GetOriginRow()
        {
            switch (this.Map.Orientation)
            {
                case Orientation.OT90:
                    return this.Map.Columns - 1 - this.Column;
                case Orientation.OT180:
                    return this.Map.Rows - 1 - this.Row;
                case Orientation.OT270:
                    return this.Column;
                case Orientation.OT0:
                default:
                    return this.Row;
            }
        }

        private int GetOriginColumn()
        {
            switch (this.Map.Orientation)
            {
                case Orientation.OT90:
                    return this.Row;
                case Orientation.OT180:
                    return this.Map.Columns - 1 - this.Column;
                case Orientation.OT270:
                    return this.Map.Rows - 1 - this.Row;
                case Orientation.OT0:
                default:
                    return this.Column;
            }
        }
    }
}


