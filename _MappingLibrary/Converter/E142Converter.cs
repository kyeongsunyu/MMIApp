using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class E142Converter : MapConverterSkeleton
    {
        static E142Converter()
        {
            MapConverterMap.LookupWithDefault("E142", new E142Converter());
        }

        /// <summary>
        /// 
        /// </summary>
        public E142Converter()
        {

        }

        public override void Save(Map map, string fileName)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapFile"></param>
        /// <returns></returns>
        public override MapData Read(string mapFile)
        {
            if (string.IsNullOrWhiteSpace(mapFile))
            {
                throw new ArgumentNullException(nameof(mapFile));
            }

            using (FileStream fs = new FileStream(mapFile, FileMode.Open, FileAccess.Read))
            {
                var waferId = Path.GetFileNameWithoutExtension(mapFile);
                var md = this.ParseInner(fs, waferId);
                md.SubstrateID = waferId;
                return md;
            }
        }

        private MapData ParseInner(Stream buffer, string waferId)
        {
            var mapData = new MapData();

            var root = XElement.Load(buffer);

            var mapElement = root.Descendants().First(x => x.Attribute("WaferId")?.Value == waferId);

            //mapData.SubstrateID = mapElement.Attribute("SubstrateId").Value;
            //string substrateType = mapElement.Attribute("SubstrateType").Value;

            //mapData.WaferId = mapElement.Attribute("WaferID").Value;

            var devElement = mapElement.Descendants().First();

            mapData.Rows = Convert.ToInt32(devElement.Attribute("Rows").Value);
            mapData.Columns = Convert.ToInt32(devElement.Attribute("Columns").Value);

            var binType = (BinFormatType)Enum.Parse(typeof(BinFormatType), devElement.Attribute("BinType").Value, true);

            var nullBinCode = devElement.Attribute("NullBin").Value;
            mapData.NullBin = Bin.CreateNullBin(binType, nullBinCode);

            // TODO: parse Orientation, OriginLocation, and AxisDirection
            // 

            var binElements = devElement.Descendants(mapElement.Name.Namespace + "Bin");

            mapData.Bins = new BinCollection();
            foreach (var binElement in binElements)
            {
                string binCode = binElement.Attribute("BinCode").Value;
                string binQuality = binElement.Attribute("BinQuality").Value;
                int binCount = Convert.ToInt32(binElement.Attribute("BinCount").Value);

                Bin bin = new Bin(new BinCode(binType, binCode), binQuality.ToUpper() == "PASS", string.Empty);
                if (bin != mapData.NullBin)
                {
                    mapData.Bins.Add(bin);
                }
            }

            var dataElement = devElement.Descendants(mapElement.Name.Namespace + "Data").First();
            var rowElements = dataElement.Descendants(mapElement.Name.Namespace + "Row");

            var binCodes = new ushort[1, 1, mapData.Rows, mapData.Columns];
            int rowIndex = 0;
            foreach (var rowElement in rowElements)
            {
                string cdata = rowElement.Value;

                int colIndex = 0;
                foreach (var bc in cdata)
                {
                    binCodes[0, 0, rowIndex, colIndex] = bc;
                    colIndex++;
                }

                rowIndex++;
            }
            mapData.BinCodes = binCodes;

            return mapData;
        }
    }
}


