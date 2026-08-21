using System;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class UnitPosition
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockX"></param>
        /// <param name="blockY"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        public UnitPosition(int blockX, int blockY, int row, int column)
        {
            this.BlockX = blockX;
            this.BlockY = blockY;
            this.Row = row;
            this.Column = column;
        }

        /// <summary>
        /// 
        /// </summary>
        public int BlockX { get; }

        /// <summary>
        /// 
        /// </summary>
        public int BlockY { get; }

        /// <summary>
        /// 
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// 
        /// </summary>
        public int Column { get; }
    }
}


