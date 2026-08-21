using System;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class XYStruct<T>
        where T : struct
    {
        protected T _x;
        protected T _y;

        public XYStruct()
        {
            this.X = default(T);
            this.Y = default(T);
        }

        public XYStruct(T x, T y)
        {
            this.X = x;
            this.Y = y;
        }

        public T X
        {
            get => this._x;
            protected set => this.SetX(value);
        }

        public T Y
        {
            get => this._y;
            protected set => this.SetY(value);
        }

        protected virtual void SetX(T x)
        {
            this._x = x;
        }

        protected virtual void SetY(T y)
        {
            this._y = y;
        }
    }
}


