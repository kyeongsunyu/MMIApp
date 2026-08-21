using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Mapping
{
    /// <summary>
    /// Ruidiwei txt 형식 지도
    /// </summary>
    public class RDWConverter : MapConverterSkeleton
    {
        static RDWConverter()
        {
            MapConverterMap.LookupWithDefault("RDW", new RDWConverter());
        }

        private int prefixDotNumber;
        private int suffixDotNumber;
        private BinCode[,,,] OriginalBinCodes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RDWConverter()
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapFile"></param>
        /// <returns></returns>
        public override MapData Read(string mapFile, bool isOriginalMap = false)
        {
            if (string.IsNullOrWhiteSpace(mapFile))
            {
                throw new ArgumentNullException(nameof(mapFile));
            }

            using (FileStream fs = new FileStream(mapFile, FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs, Encoding.Default))
                {
                    var md = this.ReadRDW(sr, isOriginalMap);
                    md.SubstrateID = Path.GetFileNameWithoutExtension(mapFile);
                    return md;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        /// <param name="fileName"></param>
        public override void Save(Map map, string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                throw new ArgumentNullException(nameof(fileName));
            }

            int sum = map.Count();
            int goodCount = map.Count(UnitState.Good);
            int pickedCount = map.CountPicked();

            using (FileStream fs = new FileStream(Path.GetFullPath(fileName), FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamWriter sw = new StreamWriter(fs, Encoding.Default))
                {
                    sw.WriteLine("Operator: E021049");
                    sw.WriteLine("Device: G0069A");
                    sw.WriteLine("Lot ID: A021206");
                    sw.WriteLine("Wafer ID: 1");
                    sw.WriteLine("Meas Time: 2022-11-01 10:20:07");
                    sw.WriteLine($"Gross Die: {sum}");
                    sw.WriteLine($"Pass Die: {goodCount}");
                    sw.WriteLine("Fail Die: 5");
                    sw.WriteLine("Total Yield: 98.31%");
                    sw.WriteLine("nocth-DOWN.");

                    for (int i = 0; i < map.Rows; i++)
                    {
                        StringBuilder builder = new StringBuilder();
                        for (int j = 0; j < prefixDotNumber; j++)
                        {
                            builder.Append('.');
                        }
                        for (int j = 0; j < map.Columns; j++)
                        {
                            var unit = OriginalBinCodes[0, 0, i, j];
                            builder.Append(unit.FormattedCode);
                        }
                        for (int j = 0; j < suffixDotNumber; j++)
                        {
                            builder.Append('.');
                        }
                        sw.WriteLine(builder.ToString());
                    }

                    sw.WriteLine("[WorkingMap]");
                    for (int i = 0; i < map.Rows; i++)
                    {
                        StringBuilder builder = new StringBuilder();
                        for (int j = 0; j < prefixDotNumber; j++)
                        {
                            builder.Append('.');
                        }
                        for (int j = 0; j < map.Columns; j++)
                        {
                            string binCode = ".";
                            var unit = map[i, j];
                            if (unit.Bin == map.NullBin)
                            {
                                binCode = ".";
                            }
                            else if (unit.State == UnitState.Picked || unit.State == UnitState.Processed)
                            {
                                binCode = "@";
                            }
                            else if (unit.State == UnitState.Reject)
                            {
                                binCode = "&";
                            }
                            else
                            {
                                binCode = unit.Bin.FormattedCode;
                            }
                            builder.Append(binCode);
                        }
                        for (int j = 0; j < suffixDotNumber; j++)
                        {
                            builder.Append('.');
                        }
                        sw.WriteLine(builder.ToString());
                    }
                }
            }
        }

        private MapData ReadRDW(StreamReader sr, bool isOriginalMap)
        {
            var mapData = new MapData();

            // Operator
            var line = sr.ReadLine();

            // Device
            sr.ReadLine();

            // Lot ID
            line = sr.ReadLine();

            // Wafer ID
            sr.ReadLine();

            // Meas Time
            sr.ReadLine();

            // Gross Die
            sr.ReadLine();

            // Pass Die
            sr.ReadLine();

            // Fail Die
            sr.ReadLine();

            // Total Yield
            sr.ReadLine();

            // nocth
            sr.ReadLine();

            mapData.NullBin = Bin.CreateNullBin('.');

            // BinInformation
            mapData.Bins = new BinCollection();

            int rows = 0;
            int columns = 0;
            int max = columns;
            int length = 0;
            int start = 0;
            int end = 0;
            var binCodes = new List<List<char>>();
            do
            {
                line = sr.ReadLine();
                if (line == "[WorkingMap]" && !isOriginalMap)
                {
                    rows = 0;
                    columns = 0;
                    binCodes = new List<List<char>>();
                    continue;
                }
                if (line is null || (line == "[WorkingMap]" && isOriginalMap))
                {
                    break;
                }
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var blank = line.Trim('.');
                if (string.IsNullOrWhiteSpace(blank))
                {
                    continue;
                }

                rows++;
                length = line.Length;
                columns = blank.Length;
                if (max < columns)
                {
                    max = columns;
                    start = length - line.TrimStart('.').Length;
                    end = start + columns;
                }

                var codes = new List<char>();
                foreach (var ch in line)
                {
                    codes.Add(ch);
                }
                binCodes.Add(codes);

            } while (true);

            mapData.Rows = rows;
            mapData.Columns = max;

            prefixDotNumber = start;
            suffixDotNumber = length - end;

            // BinCode
            mapData.BinCodes = new BinCode[1, 1, mapData.Rows, mapData.Columns];

            List<char> bins = new List<char>();
            int r = 0, c = 0;
            foreach (var codes in binCodes)
            {
                c = 0;
                for (int i = start; i < end; i++)
                {
                    mapData.BinCodes[0, 0, r, c] = codes[i];
                    c++;

                    var binCode = new BinCode(codes[i]);
                    var bin = new Bin(binCode, true);
                    var foundBin = mapData.Bins.Find(x => x.Code == binCode);
                    if ((foundBin is null) && binCode != mapData.NullBin.Code)
                    {
                        mapData.Bins.Add(bin);
                    }
                }
                r++;
            }

            if (isOriginalMap)
                OriginalBinCodes = mapData.BinCodes;

            return mapData;
        }
    }
}


