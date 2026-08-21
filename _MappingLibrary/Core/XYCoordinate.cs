using System;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class XYCoordinate : XYStruct<int>
    {
        public XYCoordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
}


