using System;
using System.Collections.Generic;
using System.Drawing;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class BinConfigurationCollection : List<BinConfiguration>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        /// <returns></returns>
        public BinConfiguration this[ushort binCode]
        {
            get
            {
                return this.Find(x => x.BinCode == binCode);
            }
        }
    }
}


