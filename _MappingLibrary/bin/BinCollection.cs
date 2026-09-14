using System;
using System.Collections.Generic;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class BinCollection : List<Bin>
    {
        /// <summary>
        /// 
        /// </summary>
        public BinCollection()
            : base()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        public BinCollection(IEnumerable<Bin> collection)
            : base(collection)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        /// <returns></returns>
        public Bin this[ushort binCode]
        {
            get
            {
                return this.Find(b => b.Code == binCode);
            }
        }
    }
}


