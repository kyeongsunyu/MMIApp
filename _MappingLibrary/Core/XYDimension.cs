using System;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class XYDimension : XYStruct<double>
    {
        public XYDimension(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        protected override void SetX(double x)
        {
            if (x < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(x), "The value of X of the XYDimension must be greater than zero");
            }

            this._x = x;
        }

        protected override void SetY(double y)
        {
            if (y < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(y), "The value of Y of the XYDimension must be greater than zero");
            }

            this._y = y;
        }
    }
}


