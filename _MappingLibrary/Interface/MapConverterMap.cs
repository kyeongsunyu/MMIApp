using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class MapConverterMap
    {
        private static readonly object _lock = new object();
        private static readonly Hashtable lookupTable = new Hashtable(StringComparer.OrdinalIgnoreCase);

        static MapConverterMap()
        {
            MapConverterMap.LookupWithDefault("CHIP MOS", new ChipMosConverter());
            MapConverterMap.LookupWithDefault("G85", new G85Converter());
            MapConverterMap.LookupWithDefault("BYD", new BYDConverter());
            MapConverterMap.LookupWithDefault("SMEC", new SMECConverter());
            MapConverterMap.LookupWithDefault("RDW", new RDWConverter());
            MapConverterMap.LookupWithDefault("HW", new HWConverter());
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="name"></param>
        ///// <returns></returns>
        //public IMapConverter this[string name]
        //{
        //    get
        //    {
        //        if (name == null)
        //        {
        //            throw new ArgumentNullException("name");
        //        }

        //        lock (this)
        //        {
        //            return (IMapConverter)lookupTable[name];
        //        }
        //    }
        //}

        public static IEnumerable<string> LookupAll()
        {
            foreach (string key in lookupTable.Keys)
            {
                yield return key;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IMapConverter Lookup(string name)
        {
            lock (_lock)
            {
                IMapConverter converter = (IMapConverter)lookupTable[name];
                return converter;
            }
        }

        public static IMapConverter LookupWithDefault(string name, IMapConverter defaultConverter)
        {
            if (defaultConverter is null)
            {
                throw new ArgumentNullException("defaultConverter");
            }

            lock (_lock)
            {
                IMapConverter converter = (IMapConverter)lookupTable[name];
                if (converter is null)
                {
                    lookupTable[name] = defaultConverter;
                    return defaultConverter;
                }
                return converter;
            }
        }

        public static void Remove(string name)
        {
            lock (_lock)
            {
                lookupTable.Remove(name);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static void Clear()
        {
            lookupTable.Clear();
        }
    }
}


