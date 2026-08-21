using System;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitSelectedEventArgs : EventArgs
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="gelPak"></param>
        public UnitSelectedEventArgs(Unit unit, GelPak gelPak)
        {
            this.Unit = unit;
            this.GelPak = gelPak;
        }

        /// <summary>
        /// 
        /// </summary>
        public Unit Unit { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public GelPak GelPak { get; private set; }
    }
}


