using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
#pragma warning disable CS1591
    /// <summary>
    /// 
    /// </summary>
    public class GelPak
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="exist"></param>
        public GelPak(int row, int column, bool exist)
        {
            this.Row = row;
            this.Column = column;
            this.Exist = exist;
        }

        public int Row { get; private set; }

        public int Column { get; private set; }

        private bool exist;
        public bool Exist
        {
            get => this.exist;
            private set
            {
                if (this.exist != value)
                {
                    this.exist = value;

                    if (this.Map != null)
                    {
                        if (this.exist)
                        {
                            this.Map.SetAllUnitState(UnitState.Good);
                        }
                        else
                        {
                            this.Map.SetAllUnitState(UnitState.Reject);
                        }
                    }
                }
            }
        }

        public int GelPakBinCode { get; private set; }

        public Map Map { get; private set; }

        public void SetMap(Map map)
        {
            this.Map = map;
        }

        public void SetExist(bool exist)
        {
            this.Exist = exist;
        }

        public void SetBinType(int code)
        {
            this.GelPakBinCode = code;
        }

        public void CreateMap(int blockRows, int blockColumns, int rows, int columns)
        {
            this.Map = Map.CreateStripMap(blockRows, blockColumns, rows, columns);
        }

        public override bool Equals(object obj)
        {
            return this.Equals(obj as GelPak);
        }

        public bool Equals(GelPak obj)
        {
            if ((obj as object) == null)
            {
                return false;
            }

            bool equal = (this.Row == obj.Row &&
                          this.Column == obj.Column);

            return equal;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(GelPak left, GelPak right)
        {
            if ((left as object) == null)
            {
                return ((right as object) == null);
            }

            return left.Equals(right);
        }

        public static bool operator !=(GelPak left, GelPak right)
        {
            return !(left == right);
        }

        public bool NextWorkDie()
        {
            if (this.IsWorkDie(this.Map.Current))
            {
                return true;
            }
            else
            {
                if (this.Map.NextUnit())
                {
                    return this.NextWorkDie();
                }
                else
                {
                    return false;
                }
            }
        }

        private bool IsWorkDie(Unit die)
        {
            return (die != null && die.State == UnitState.Good);
        }
    }
#pragma warning restore CS1591
}


