using System;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitState
    {
        readonly int code;
        readonly string name;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="name"></param>
        public UnitState(int code, string name)
        {
            this.code = code;
            this.name = name;
        }

        /// <summary>
        /// 
        /// </summary>
        public int Code { get => this.code; }

        /// <summary>
        /// 
        /// </summary>
        public string Name { get => this.name; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as UnitState);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(UnitState obj)
        {
            if (obj is null)
            {
                return false;
            }

            bool equal = (this.Code == obj.Code);

            return equal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Code.GetHashCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(UnitState left, UnitState right)
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
        public static bool operator !=(UnitState left, UnitState right)
        {
            return !(left == right);
        }

        public override string ToString()
        {
            return this.name;
        }

        /// <summary>
        /// 
        /// </summary>
        public static readonly UnitState Good = new UnitState(0, "Good");

        /// <summary>
        /// 
        /// </summary>
        public static readonly UnitState Processed = new UnitState(1, "Processed");

        /// <summary>
        /// 
        /// </summary>
        public static readonly UnitState Picked = new UnitState(2, "Picked");

        /// <summary>
        /// 
        /// </summary>
        public static readonly UnitState FMark = new UnitState(3, "F-Mark");

        /// <summary>
        /// 
        /// </summary>
        public static readonly UnitState Reject = new UnitState(4, "Reject");

        /// <summary>
        /// 
        /// </summary>
        public static readonly UnitState Placed = new UnitState(5, "Placed");

        /// <summary>
        /// 
        /// </summary>
        public static readonly UnitState InkDot = new UnitState(6, "Inkdot");

        /// <summary>
        /// 
        /// </summary>
        public static readonly UnitState NG = new UnitState(7, "NG");

        /// <summary>
        /// 
        /// </summary>
        public static readonly UnitState Skip = new UnitState(8, "Skip");
    }
}


