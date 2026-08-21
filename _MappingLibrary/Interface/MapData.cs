using System;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class MapData
    {
        /// <summary>
        /// 
        /// </summary>
        public BinCode[,,,] BinCodes { get; set; }


        public BinCode[,,,] OriginalBinCodes { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int BlockRows { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public int BlockColumns { get; set; } = 1;

        /// <summary>
        /// 
        /// </summary>
        public int Rows { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Columns { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Bin NullBin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Bin EmptyBin { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public BinCollection Bins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Bin[,] ShotBins { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LotID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SubstrateID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int SlotNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public OriginLocation OriginLocation { get; set; } = OriginLocation.UpperLeft;

        /// <summary>
        /// 
        /// </summary>
        public AxisDirection AxisDirection { get; set; } = AxisDirection.UpLeft;
    }
}


