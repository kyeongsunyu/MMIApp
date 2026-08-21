using System;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class XYPosition : XYStruct<double>
    {
        public XYPosition(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        protected override void SetX(double x)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "The value of X of the XYPosition must be greater than zero");
            }

            this._x = x;
        }

        protected override void SetY(double y)
        {
            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y), "The value of Y of the XYPosition must be greater than zero");
            }

            this._y = y;
        }
    }
}


