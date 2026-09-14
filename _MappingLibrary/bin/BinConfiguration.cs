using System;
using System.Drawing;
using System.Runtime.Serialization;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    [Serializable]
    public class BinConfiguration : ISerializable
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        /// <param name="pick"></param>
        /// <param name="color"></param>
        public BinConfiguration(BinCode binCode, bool pick, Color color)
        {
            this.BinCode = binCode;
            this.Pick = pick;
            this.Color = color;
        }

        protected BinConfiguration(SerializationInfo info, StreamingContext context)
        {
            try
            {
                var code = info.GetString("bin");
                var format = info.GetString("format");
                this.BinCode = new BinCode(GetFormattedType(format), code);
            }
            catch
            {
                this.BinCode = new BinCode( (char)info.GetUInt16("bin"));
            }

            this.Pick = info.GetBoolean("pick");
            byte a = info.GetByte("colorA");
            byte r = info.GetByte("colorR");
            byte g = info.GetByte("colorG");
            byte b = info.GetByte("colorB");
            this.Color = Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// 
        /// </summary>
        public BinCode BinCode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool Pick { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Color Color { get; set; }

        #region ISerializable

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("bin", this.BinCode.FormattedCode);
            info.AddValue("format", this.BinCode.FormatType);
            info.AddValue("pick", this.Pick);
            info.AddValue("colorA", this.Color.A);
            info.AddValue("colorR", this.Color.R);
            info.AddValue("colorG", this.Color.G);
            info.AddValue("colorB", this.Color.B);
        }

        #endregion

        public BinFormatType GetFormattedType(string format)
        {
            BinFormatType binFormatType = BinFormatType.Ascii;

            switch (format)
            {
                case "Ascii":
                    binFormatType = BinFormatType.Ascii;
                    break;
                case "Decimal":
                    binFormatType = BinFormatType.Decimal;
                    break;
                case "HexaDecimal":
                    binFormatType = BinFormatType.HexaDecimal;
                    break;
                case "Integer2":
                    binFormatType = BinFormatType.Integer2;
                    break;
                default:
                    break;
            }

            return binFormatType;
        }
    }
}


