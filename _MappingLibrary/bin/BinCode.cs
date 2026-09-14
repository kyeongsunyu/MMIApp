using System;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class BinCode
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        public BinCode(char binCode)
        {
            this.FormatType = BinFormatType.Ascii;
            this.Code = binCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="formatType"></param>
        /// <param name="binCode"></param>
        public BinCode(BinFormatType formatType, string binCode)
        {
            this.FormatType = formatType;
            this.Code = GetBinCode(formatType, binCode);
        }

        /// <summary>
        /// The format in which the each device will be presented.
        /// </summary>
        public BinFormatType FormatType { get; set; }

        /// <summary>
        /// A bin category, other that the value assigned to
        /// NullBin, that may be assigned to a device.
        /// It should be represented according to <see cref="BinFormatType"/>.
        /// </summary>
        public ushort Code { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public string FormattedCode
        {
            get => this.GetFormattedCode();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            return this.Equals(obj as BinCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool Equals(BinCode obj)
        {
            if (obj is null)
            {
                return false;
            }

            bool equal = (this.Code == obj.Code);

            return equal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return Code;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} - {1}", this.FormattedCode, this.FormatType);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        public static implicit operator BinCode(char binCode)
        {
            return new BinCode(binCode);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        public static implicit operator char(BinCode binCode)
        {
            return (char)binCode.Code;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        public static implicit operator ushort(BinCode binCode)
        {
            return binCode.Code;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(BinCode left, BinCode right)
        {
            if ((left as object) == null)
            {
                return ((right as object) == null);
            }

            return left.Equals(right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(BinCode left, BinCode right)
        {
            return !(left == right);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="binCode"></param>
        /// <returns></returns>
        public static bool operator ==(BinCode left, char binCode)
        {
            return left.Code == binCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="binCode"></param>
        /// <returns></returns>
        public static bool operator !=(BinCode left, char binCode)
        {
            return left.Code != binCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(char binCode, BinCode right)
        {
            return right.Code == binCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(char binCode, BinCode right)
        {
            return right.Code != binCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="binCode"></param>
        /// <returns></returns>
        public static bool operator ==(BinCode left, ushort binCode)
        {
            return left.Code == binCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="left"></param>
        /// <param name="binCode"></param>
        /// <returns></returns>
        public static bool operator !=(BinCode left, ushort binCode)
        {
            return left.Code != binCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(ushort binCode, BinCode right)
        {
            return right.Code == binCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(ushort binCode, BinCode right)
        {
            return right.Code != binCode;
        }

        private ushort GetBinCode(BinFormatType formatType, string binCode)
        {
            if (string.IsNullOrEmpty(binCode))
            {
                throw new ArgumentException($"Invalid bin format type - FormatType={formatType}, Bincode={binCode}");
            }

            ushort code = 0;

            try
            {
                switch (formatType)
                {
                    case BinFormatType.Ascii:
                        if (binCode.Length != 1)
                        {
                            throw new ArgumentException($"Invalid bin format type - FormatType={formatType}, Bincode={binCode}");
                        }
                        code = binCode[0];
                        break;

                    case BinFormatType.Decimal:
                        code = Convert.ToUInt16(binCode, 10);
                        break;

                    case BinFormatType.HexaDecimal:
                        code = Convert.ToUInt16(binCode, 16);
                        break;

                    case BinFormatType.Integer2:
                        code = Convert.ToUInt16(binCode, 16);
                        break;

                    default:
                        code = 0;
                        break;
                }
            }
#pragma warning disable CS0168
            catch (Exception ex)
#pragma warning restore CS0168
            {
                throw new ArgumentException($"Invalid bin format type - FormatType={formatType}, Bincode={binCode}");
            }

            return code;
        }

        private string GetFormattedCode()
        {
            string code = string.Empty;

            switch (this.FormatType)
            {
                case BinFormatType.Ascii:
                    code = ((char)this.Code).ToString();
                    break;

                case BinFormatType.Decimal:
                    code = this.Code.ToString("000");
                    break;

                case BinFormatType.HexaDecimal:
                    code = this.Code.ToString("X2");
                    break;

                case BinFormatType.Integer2:
                    code = this.Code.ToString("X4");
                    break;

                default:
                    code = string.Empty;
                    break;
            }

            return code;
        }
    }
}


