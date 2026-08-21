using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Collections;
using System.ComponentModel;

namespace MMI
{
    class CUtil
    {
        #region SINGLETON
        private static readonly Lazy<CUtil> instance = new Lazy<CUtil>(() => new CUtil());

        public static CUtil GetInstance
        {
            get { return instance.Value; }
        }
        #endregion SINGLETON

        //-- Integer 내의 해당 비트의 비트 상태를 돌려 준다.
        public bool GetBit<T>(int data, T bitno)
        {
            var bRtn = false;

            try
            {
                if ((data & (1 << Convert.ToInt32(bitno))) > 0)
                    bRtn = true;
                else
                    bRtn = false;
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            //    AddLog(ex.Message);
            }

            return bRtn;
        }

        //-- Integer 내의 해당 비트를 설정 한다.
        public int SetBit<T>(int data, T bitno, bool onoff)
        {
            var nRtn = 0;

            try
            {
                if (onoff)
                    nRtn = data | (1 << Convert.ToInt32(bitno));
                else
                    nRtn = data & ~(1 << Convert.ToInt32(bitno));
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
             //   AddLog(ex.Message);
            }

            return nRtn;
        }
        public uint BITChange(uint data, int BitNo)
        {
            return BIT(data, BitNo) ? (data & (uint)(~(1 << BitNo))): (data | (uint)(1 << BitNo));
        }

        public uint BITONOFF(uint data, int BitNo, bool bOnOff)
        {
            return bOnOff ? (data | (uint)(1 << BitNo)) : (data & (uint)(~(1 << BitNo)));
        }
        public bool BIT(uint data, int BitNo)
        {
            return ((data & ((uint)1 << BitNo)) != 0 ? true : false);
        }

        public DateTime Delay(int MS)
        {
            DateTime thisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime afterMoment = thisMoment.Add(duration);

            while (afterMoment >= thisMoment)
            {
                System.Windows.Forms.Application.DoEvents();

                thisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }

        public static UInt16 BoolArrayToInt(bool[] arr, int channel)
        {
            UInt16 val = 0;
            for (int i = 0; i < 16; i++)
                if (arr[channel * 16 + i])
                    val |= (UInt16)(1 << i);

            return val;
        }
        public static string IntToBinaryString(int number)
        {
            const int mask = 1;
            var binary = string.Empty;
            while (number > 0)
            {
                // Logical AND the number and prepend it to the result string
                binary = (number & mask) + binary;
                number = number >> 1;
            }

            return binary;
        }

        public static byte[] BitArrayToByteArray(BitArray ba)
        {
            byte[] bytes;

            if (ba.Length % 8 == 0)
            {
                bytes = new byte[ba.Length / 8];
            }
            else
            {
                bytes = new byte[ba.Length / 8 + 1];
            }

            for (int i = 0; i < ba.Length; i += 8)
            {
                int pos = i / 8;
                for (int j = 0; j < 8; j++)
                {
                    if (i + j < ba.Length)
                    {
                        if (ba[i + j] == true)
                        {
                            bytes[pos] &= 1;
                        }
                    }
                    bytes[pos] <<= 1;

                }
            }
            return bytes;
        }
        static public string D2B(int nValue)
        {
            int nBinary;
            char[] cTemp = new char[1];
            string sValue = "";

            while (nValue > 0)
            {
                nBinary = nValue % 2;
                sValue = nBinary + sValue;
                nValue = nValue / 2;
            }

            cTemp = sValue.ToCharArray();
            Array.Reverse(cTemp);
            sValue = new string(cTemp);
            for (int i = sValue.Length; i < 16; i++)
            {
                sValue += "0";
            }
            return sValue;
        }

        static public Int64 B2D(string sValue)
        {
            string sBny = "";
            Int64 nValue = 0, nAdd = 0;
            int nIndex = sValue.Length;
            for (int i = nIndex; i > 0; i--)
            {
                sBny = sValue.Substring(i - 1, 1);
                if (sBny == "1")
                {
                    nValue = nValue + Convert.ToInt64(Math.Pow(2, nAdd));
                }
                nAdd++;
            }
            return nValue;
        }

        public static string D2SHEX(Int32 dwData, int nLen, string sFill)
        {
            string sRtn = "";
            char[] pzData = new char[33];
            int nSize = 0;

            sRtn = Convert.ToString(dwData, 16);
            nSize = Math.Abs(nLen - sRtn.Length);

            if (sRtn.Length > 4)
            {
                sRtn = sRtn.Substring(sRtn.Length - 4, 4);
            }

            nSize = Math.Abs(nLen - sRtn.Length);
            for (int nFillCnt = 0; nFillCnt < nSize; nFillCnt++)
            {
                sRtn = sRtn.Insert(0, sFill);
            }

            return sRtn.ToUpper();
        }

        public static byte[] IntToBCD(int input)
        {
            if (input > 9999 || input < 0)
            {
                return null;
            }

            int thousands = input / 1000;
            int hundreds = (input -= thousands * 1000) / 100;
            int tens = (input -= hundreds * 100) / 10;
            int ones = (input -= tens * 10);
            byte[] bcd = new byte[]
            {
                (byte)(thousands << 4 | hundreds), (byte)(tens << 4 | ones)
            };
            return bcd;
        }

        public static int HexToInt(string hex)
        {
            int intValue = int.Parse(hex, System.Globalization.NumberStyles.HexNumber);
            return intValue;
        }

        //10진수->16진수
        public static string DecToHex(long lValue)
        {
            return Convert.ToString(lValue, 16).ToUpper();
        }

        //16진수->10진수
        public static long HexToDec(string strHex)
        {
            return Convert.ToInt64(strHex, 16);
        }

        //10진수->2진수
        public static string DecToBin(long lValue)
        {
            return Convert.ToString(lValue, 2);
        }

        //10진수->8진수
        public static string DecToOct(long lValue)
        {
            return Convert.ToString(lValue, 8);
        }

        //"00000101" => 5
        public static string ByteArrayToBinString(byte[] byteArray)
        {
            string s = string.Join(" ",
                byteArray.Select(x => Convert.ToString(x, 2).PadLeft(8, '0')));

            return s;
        }

        //1바이트 기준
        public static int BoolArrayToWord(bool[] boolArray)
        {
            if (boolArray.Length > 16) return 0;
            int[] nArray = new int[16] { 1, 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024, 2048, 4096, 8192, 16384, 32768 };
            int nValue = 0;
            for (int i = 0; i < boolArray.Length; i++)
            {
                nValue += (boolArray[i] == true ? nArray[i] : 0);
                //                 if (nValue == 8)
                //                 {
                //                     int a = 0;
                //                 }
            }
            return nValue;
        }

        public static int ByteArrayToInt16(byte[] btArr)
        {
            return BitConverter.ToInt16(btArr, 0);
        }

        public static double ByteArrayToDouble(byte[] btArr)
        {
            return BitConverter.ToDouble(btArr, 0);
        }

        //2D 배열을 90도 회전
        public static int[,] RotateArrayClockwise(int[,] src)
        {
            int width;
            int height;
            int[,] dst;

            width = src.GetUpperBound(0) + 1;   //행 갯수    
            height = src.GetUpperBound(1) + 1;  //열 갯수
            dst = new int[height, width];

            for (int row = 0; row < height; row++)
            {
                for (int col = 0; col < width; col++)
                {
                    int newRow;
                    int newCol;

                    newRow = col;
                    newCol = height - (row + 1);

                    dst[newCol, newRow] = src[col, row];
                }
            }
            return dst;
        }

        #region 2차원 배열 왼쪽으로 회전하기 - RotateLeft<T>(sourceArray) 
        /* ---------------   -------------- 
         * 소스 2차원 배열    왼쪽 회전 배열 
         * ---------------   -------------- 
         * 012               25 
         * 345               14 
         *                   03 
         * --------------- ---------------- 
        */
        /// <summary> 
        /// /// 2차원 배열 왼쪽으로 회전하기 
        /// /// </summary> 
        /// /// <typeparam name="T">배열 타입</typeparam> 
        /// /// <param name="sourceArray">소스 배열</param> 
        /// /// <returns>왼쪽 회전 배열</returns> 
        public T[,] RotateLeft<T>(T[,] sourceArray)
        {
            int lengthY = sourceArray.GetLength(0);
            int lengthX = sourceArray.GetLength(1);
            T[,] targetArray = new T[lengthX, lengthY];
            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    targetArray[x, y] = sourceArray[y, lengthX - 1 - x];
                }
            }
            return targetArray;
        }
        #endregion

        #region 2차원 배열 오른쪽으로 회전하기 - RotateRight<T>(sourceArray) 
        /* 
         * --------------- ---------------- 
         * 소스 2차원 배열 오른쪽 회전 배열 
         * --------------- ----------------
         * 012              30 
         * 345              41 
         *                  52 
         * --------------- ---------------- 
         */ /// <summary> 
        /// 2차원 배열 오른쪽으로 회전하기 
        /// /// </summary> 
        /// /// <typeparam name="T">배열 타입</typeparam> 
        /// /// <param name="sourceArray">소스 배열</param> 
        /// /// <returns>오른쪽 회전 배열</returns> 
        public static T[,] RotateRight<T>(T[,] sourceArray)
        {
            int lengthY = sourceArray.GetLength(0);
            int lengthX = sourceArray.GetLength(1);
            T[,] targetArray = new T[lengthX, lengthY];
            for (int y = 0; y < lengthY; y++)
            {
                for (int x = 0; x < lengthX; x++)
                {
                    targetArray[x, y] = sourceArray[lengthY - 1 - y, x];
                }
            }
            return targetArray;
        }
        #endregion

        #region WORD-DOWRD-BYTE-NIBBLE 변환관련
        public static short MAKEWORD(byte a, byte b)
        {
            return ((short)(((byte)(a & 0xff)) | ((short)((byte)(b & 0xff))) << 8));
        }

        public static byte LOBYTE(short a)
        {
            return ((byte)(a & 0xff));
        }

        public static byte HIBYTE(short a)
        {
            return ((byte)(a >> 8));
        }

        public static int MAKELONG(short a, short b)
        {
            return (((int)(a & 0xffff)) | (((int)(b & 0xffff)) << 16));
        }

        public static short HIWORD(int a)
        {
            return ((short)(a >> 16));
        }

        public static short LOWORD(int a)
        {
            return ((short)(a & 0xffff));
        }

        public static byte MAKEBYTE(byte Nibble_a, byte Nibble_b)
        {
            return ((byte)(((byte)(Nibble_a & 0xf)) | ((byte)((byte)(Nibble_b & 0xf))) << 4));
        }

        public static byte HINIBBLE(byte a)
        {
            return (byte)(a >> 4 & 0xf); // = 0000 0001
        }

        public static byte LONIBBLE(byte a)
        {
            return (byte)(a & 0xf); // = 0000 0010
        }

        public static short[] IntToDWord(int a)
        {
            short[] array = new short[2];
            array[0] = LOWORD(a);
            array[1] = HIWORD(a);

            return array;
        }

        public static short[] IntToDWord(int[] a)
        {
            short[] array = new short[a.Length * 2];

            int nCnt = 0;
            for (int i = 0; i < a.Length; i++)
            {
                array[nCnt++] = LOWORD(a[i]);
                array[nCnt++] = HIWORD(a[i]);
            }

            return array;
        }
        #endregion


        public static Image byteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }

        public byte[] imageToByteArray(System.Drawing.Image imageIn)
        {
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
            return ms.ToArray();
        }



        #region 다각형 무게 중심 구하기 - GetPolygonCentroid(sourceList)

        /// <summary>
        /// 다각형 무게 중심 구하기
        /// </summary>
        /// <param name="sourceList">소스 리스트</param>
        /// <returns>다각형 무게 중심</returns>
        //public static Point2d GetPolygonCentroid(List<Point2d> sourceList)
        //{
        //    double centerX = 0d;
        //    double centerY = 0d;
        //    double polygonArea = 0d;

        //    int firstIndex;
        //    int secondIndex;
        //    int sourceCount = sourceList.Count;

        //    Point2d firstPoint;
        //    Point2d secondPoint;

        //    double factor = 0d;

        //    for (firstIndex = 0; firstIndex < sourceCount; firstIndex++)
        //    {
        //        secondIndex = (firstIndex + 1) % sourceCount;

        //        firstPoint = sourceList[firstIndex];
        //        secondPoint = sourceList[secondIndex];

        //        factor = ((firstPoint.X * secondPoint.Y) - (secondPoint.X * firstPoint.Y));

        //        polygonArea += factor;

        //        centerX += (firstPoint.X + secondPoint.X) * factor;
        //        centerY += (firstPoint.Y + secondPoint.Y) * factor;
        //    }

        //    polygonArea /= 2d;
        //    polygonArea *= 6d;

        //    factor = 1d / polygonArea;

        //    centerX *= factor;
        //    centerY *= factor;

        //    return new Point2d(centerX, centerY);
        //}

        #endregion


        public string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());

            var attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                    typeof(DescriptionAttribute),
                    false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            return value.ToString();
        }
        // int nNumByNum = Convert.ToInt32(Util.GetEnumDescription(CORRECTION.COR_5X5));

        public string GetReadableTimeByMs(long ms)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(ms);
            return $"{t.Hours:00}:{t.Minutes:00}:{t.Seconds:00}";
            //if (t.Hours > 0) return $"{t.Hours}h:{t.Minutes}m:{t.Seconds}s";
            //else if (t.Minutes > 0) return $"{t.Minutes}m:{t.Seconds}s";
            //else if (t.Seconds > 0) return $"{t.Seconds}s:{t.Milliseconds}ms";
            //else return $"{t.Milliseconds:000}ms";
        }
    }
}
