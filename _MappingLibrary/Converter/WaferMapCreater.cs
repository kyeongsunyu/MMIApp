using System;
using System.Collections.Generic;

namespace Mapping
{
    internal class WaferMapCreater
    {
        public WaferMapCreater()
        {

        }

        public MapData Create(double diameter, double dieSizeX, double dieSizeY)
        {
            if (diameter <= 0)
            {
                throw new ArgumentOutOfRangeException("Diameter must been greater than 0.");
            }
            if (dieSizeX <= 0)
            {
                throw new ArgumentOutOfRangeException("DieSizeX must been greater than 0.");
            }
            if (dieSizeY <= 0)
            {
                throw new ArgumentOutOfRangeException("DieSizeY must been greater than 0.");
            }

            var mapData = new MapData();
            double radius = diameter * 0.5;

            int rows = (int)System.Math.Floor(diameter / dieSizeY);
            if (rows == 0)
            {
                throw new ArgumentException("Invalid input parameter.");
            }
            int cols = (int)System.Math.Floor(diameter / dieSizeX);
            if (cols == 0)
            {
                throw new ArgumentException("Invalid input parameter.");
            }

            // center row
            double cr = rows * 0.5 - 0.5;
            // center column
            double cc = cols * 0.5 - 0.5;

            // ô¨ð¶?Í£
            double left = (0 - cc) * dieSizeX - dieSizeX * 0.5;
            double top = (cr - System.Math.Floor(cr)) * dieSizeY + dieSizeY * 0.5;
            double right = left + dieSizeX;
            double bottom = top - dieSizeY;

            if (!IsRectInCircle(radius, top, left, bottom, right))
            {
                cols -= 1;
            }

            if (cols == 0)
            {
                throw new ArgumentException("Invalid input parameter.");
            }

            left = (System.Math.Floor(cc) - cc) * dieSizeX - dieSizeX * 0.5;
            top = (cr - 0) * dieSizeY + dieSizeY * 0.5;
            right = left + dieSizeX;
            bottom = top - dieSizeY;

            if (!IsRectInCircle(radius, top, left, bottom, right))
            {
                rows -= 1;
            }

            if (rows == 0)
            {
                throw new ArgumentException("Invalid input parameter.");
            }

            cr = rows * 0.5 - 0.5;
            cc = cols * 0.5 - 0.5;

            mapData.Rows = rows;
            mapData.Columns = cols;
            mapData.NullBin = Bin.CreateNullBin('.');
            mapData.EmptyBin = Bin.CreateEmptyBin('-');
            mapData.SubstrateID = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");

            var rates = new List<double>(new double[] { 1, 0 });
            var binList = new List<char>(new char[] { '1', '0' });
            mapData.Bins = new BinCollection();
            foreach (var b in binList)
            {
                mapData.Bins.Add(new Bin(b, true));
            }

            mapData.BinCodes = new BinCode[1, 1, rows, cols];
            var list = new List<int>(); // Enumerable.Range(0, rows * cols).ToList();

            int counts = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    left = (j - cc) * dieSizeX - dieSizeX * 0.5;
                    top = (cr - i) * dieSizeY + dieSizeY * 0.5;

                    double d1 = System.Math.Sqrt(top * top + left * left);
                    if (d1 >= radius)
                    {
                        mapData.BinCodes[0, 0, i, j] = '.';
                        continue;
                    }

                    right = left + dieSizeX;

                    double d2 = System.Math.Sqrt(top * top + right * right);
                    if (d2 >= radius)
                    {
                        mapData.BinCodes[0, 0, i, j] = '.';
                        continue;
                    }

                    bottom = top - dieSizeY;

                    double d3 = System.Math.Sqrt(bottom * bottom + left * left);
                    if (d3 >= radius)
                    {
                        mapData.BinCodes[0, 0, i, j] = '.';
                        continue;
                    }

                    double d4 = System.Math.Sqrt(bottom * bottom + right * right);
                    if (d4 >= radius)
                    {
                        mapData.BinCodes[0, 0, i, j] = '.';
                        continue;
                    }

                    counts++;
                    list.Add(i * cols + j);
                }
            }

            Shuffle(list);

            int index = 0;
            int count = 1;
            foreach (int v in list)
            {
                int r = v / cols;
                int c = v % cols;

                bool reach = ((double)count / counts) >= rates[index];

                mapData.BinCodes[0, 0, r, c] = binList[index];
                if (reach)
                {
                    count = 1;
                    index++;
                }
                else
                {
                    count++;
                }
            }

            return mapData;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="diameter"></param>
        /// <param name="dieSizeX"></param>
        /// <param name="dieSizeY"></param>
        /// <param name="centerOffsetX"></param>
        /// <param name="centerOffsetY"></param>
        /// <param name="centerRow"></param>
        /// <param name="centerColumn"></param>
        /// <returns></returns>
        public MapData Create(double diameter, double dieSizeX, double dieSizeY, double centerOffsetX, double centerOffsetY, out int centerRow, out int centerColumn)
        {
            if (diameter <= 0)
            {
                throw new ArgumentOutOfRangeException("Diameter must been greater than 0.");
            }
            if (dieSizeX <= 0)
            {
                throw new ArgumentOutOfRangeException("DieSizeX must been greater than 0.");
            }
            if (dieSizeY <= 0)
            {
                throw new ArgumentOutOfRangeException("DieSizeY must been greater than 0.");
            }

            var mapData = new MapData();
            double radius = diameter * 0.5;

            int rows = 0;
            int count = 0;
            while (true)
            {
                double top = centerOffsetY + dieSizeY * 0.5 + count * dieSizeY;
                double left = centerOffsetX - dieSizeX * 0.5;
                double bottom = top - dieSizeY;
                double right = left + dieSizeX;

                if (IsRectInCircle(radius, top, left, bottom, right))
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            rows += count;

            // center row
            centerRow = rows - 1;

            count = 0;
            while (true)
            {
                double top = centerOffsetY + dieSizeY * 0.5 - (count + 1) * dieSizeY;
                double left = centerOffsetX - dieSizeX * 0.5;
                double bottom = top - dieSizeY;
                double right = left + dieSizeX;

                if (IsRectInCircle(radius, top, left, bottom, right))
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            rows += count;
            if (rows == 0)
            {
                throw new ArgumentException("Invalid input parameter.");
            }

            int cols = 0;
            count = 0;
            while (true)
            {
                double top = centerOffsetY + dieSizeY * 0.5;
                double left = centerOffsetX - dieSizeX * 0.5 - count * dieSizeX;
                double bottom = top - dieSizeY;
                double right = left + dieSizeX;

                if (IsRectInCircle(radius, top, left, bottom, right))
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            cols += count;

            // center column
            centerColumn = cols - 1;

            count = 0;
            while (true)
            {
                double top = centerOffsetY + dieSizeY * 0.5;
                double left = centerOffsetX - dieSizeX * 0.5 + (count + 1) * dieSizeX;
                double bottom = top - dieSizeY;
                double right = left + dieSizeX;

                if (IsRectInCircle(radius, top, left, bottom, right))
                {
                    count++;
                }
                else
                {
                    break;
                }
            }
            cols += count;
            if (cols == 0)
            {
                throw new ArgumentException("Invalid input parameter.");
            }



            mapData.Rows = rows;
            mapData.Columns = cols;
            mapData.NullBin = Bin.CreateNullBin('.');
            mapData.EmptyBin = Bin.CreateEmptyBin('-');
            mapData.SubstrateID = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");

            mapData.Bins = new BinCollection();
            mapData.Bins.Add(new Bin('1', true));
            mapData.Bins.Add(new Bin('0', false));

            mapData.BinCodes = new BinCode[1, 1, rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    double left = centerOffsetX - dieSizeX * 0.5 + (j - centerColumn) * dieSizeX;
                    double top = centerOffsetY + dieSizeY * 0.5 + (centerRow - i) * dieSizeY;
                    double bottom = top - dieSizeY;
                    double right = left + dieSizeX;

                    if (IsRectInCircle(radius, top, left, bottom, right))
                    {
                        mapData.BinCodes[0, 0, i, j] = '1';
                    }
                    else
                    {
                        mapData.BinCodes[0, 0, i, j] = '.';
                    }
                }
            }

            return mapData;
        }

        public MapData CreateEmptyBin(double radius, double dieSizeX, double dieSizeY)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Radius must been greater than 0.");
            }
            if (dieSizeX <= 0)
            {
                throw new ArgumentOutOfRangeException("DieSizeX must been greater than 0.");
            }
            if (dieSizeY <= 0)
            {
                throw new ArgumentOutOfRangeException("DieSizeY must been greater than 0.");
            }

            var mapData = new MapData();
            double diameter = radius * 2;

            int rows = (int)System.Math.Floor(diameter / dieSizeY);
            if (rows == 0)
            {
                throw new ArgumentException("Invalid input parameter.");
            }
            int cols = (int)System.Math.Floor(diameter / dieSizeX);
            if (cols == 0)
            {
                throw new ArgumentException("Invalid input parameter.");
            }

            // center row
            double cr = rows * 0.5 - 0.5;
            // center column
            double cc = cols * 0.5 - 0.5;

            // ô¨ð¶?Í£
            double left = (0 - cc) * dieSizeX - dieSizeX * 0.5;
            double top = (cr - System.Math.Floor(cr)) * dieSizeY + dieSizeY * 0.5;
            double right = left + dieSizeX;
            double bottom = top - dieSizeY;

            if (!IsRectInCircle(radius, top, left, bottom, right))
            {
                cols -= 1;
            }

            if (cols == 0)
            {
                throw new ArgumentException("Invalid input parameter.");
            }

            left = (System.Math.Floor(cc) - cc) * dieSizeX - dieSizeX * 0.5;
            top = (cr - 0) * dieSizeY + dieSizeY * 0.5;
            right = left + dieSizeX;
            bottom = top - dieSizeY;

            if (!IsRectInCircle(radius, top, left, bottom, right))
            {
                rows -= 1;
            }

            if (rows == 0)
            {
                throw new ArgumentException("Invalid input parameter.");
            }

            cr = rows * 0.5 - 0.5;
            cc = cols * 0.5 - 0.5;

            mapData.Rows = rows;
            mapData.Columns = cols;
            mapData.NullBin = Bin.CreateNullBin('.');
            mapData.SubstrateID = DateTime.Now.ToString("yyyy-MM-dd-HH_mm_ss");

            mapData.EmptyBin = Bin.CreateEmptyBin('-');
            mapData.Bins = new BinCollection();

            mapData.BinCodes = new BinCode[1, 1, rows, cols];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    left = (j - cc) * dieSizeX - dieSizeX * 0.5;
                    top = (cr - i) * dieSizeY + dieSizeY * 0.5;

                    double d1 = System.Math.Sqrt(top * top + left * left);
                    if (d1 >= radius)
                    {
                        mapData.BinCodes[0, 0, i, j] = '.';
                        continue;
                    }

                    right = left + dieSizeX;

                    double d2 = System.Math.Sqrt(top * top + right * right);
                    if (d2 >= radius)
                    {
                        mapData.BinCodes[0, 0, i, j] = '.';
                        continue;
                    }

                    bottom = top - dieSizeY;

                    double d3 = System.Math.Sqrt(bottom * bottom + left * left);
                    if (d3 >= radius)
                    {
                        mapData.BinCodes[0, 0, i, j] = '.';
                        continue;
                    }

                    double d4 = System.Math.Sqrt(bottom * bottom + right * right);
                    if (d4 >= radius)
                    {
                        mapData.BinCodes[0, 0, i, j] = '.';
                        continue;
                    }

                    mapData.BinCodes[0, 0, i, j] = '-';
                }
            }

            return mapData;
        }

        private bool IsRectInCircle(double radius, double top, double left, double bottom, double right)
        {
            double d1 = System.Math.Sqrt(top * top + left * left);
            if (d1 >= radius)
            {
                return false;
            }

            double d2 = System.Math.Sqrt(top * top + right * right);
            if (d2 >= radius)
            {
                return false;
            }

            double d3 = System.Math.Sqrt(bottom * bottom + left * left);
            if (d3 >= radius)
            {
                return false;
            }

            double d4 = System.Math.Sqrt(bottom * bottom + right * right);
            if (d4 >= radius)
            {
                return false;
            }

            return true;
        }

        private void Shuffle(List<int> list)
        {
            int currentIndex;
            int tempValue;

            var rd = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                currentIndex = rd.Next(0, list.Count - i);
                tempValue = list[currentIndex];
                list[currentIndex] = list[list.Count - 1 - i];
                list[list.Count - 1 - i] = tempValue;
            }
        }


    }
}


