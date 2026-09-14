using System;
using System.Collections.Generic;
using System.Drawing;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class BinColorManager
    {
        private int index = -1;
        private readonly List<Color> colorCache = new List<Color>()
        {
            Color.FromArgb(0,   128, 0),
            Color.FromArgb(128, 255, 0),
            Color.FromArgb(128, 255, 255),
            Color.FromArgb(0,   128, 255),
            Color.FromArgb(128, 128, 255),
            Color.FromArgb(255, 128, 192),
            Color.FromArgb(128, 0,   64),
            Color.FromArgb(255, 128, 255),
            Color.FromArgb(255, 128, 128),
            Color.FromArgb(255, 0,   0),
            Color.FromArgb(255, 128, 64),
            Color.FromArgb(128, 64,  0)
        };

        /// <summary>
        /// 
        /// </summary>
        public BinColorManager()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="colors"></param>
        public BinColorManager(IEnumerable<Color> colors)
        {
            this.colorCache.Clear();
            this.colorCache.AddRange(colors);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Color Next()
        {
            index++;

            if (index >= colorCache.Count)
            {
                index = 0;
            }

            return this.colorCache[index];
        }
    }
}


