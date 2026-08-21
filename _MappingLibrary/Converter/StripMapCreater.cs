using System;

namespace Mapping
{
    internal class StripMapCreater
    {
        public StripMapCreater()
        {

        }

        public MapData Create(int blockRows, int blockColumns, int rows, int columns)
        {
            if (blockRows <= 0)
            {
                throw new ArgumentOutOfRangeException("block rows must been greater than 0.");
            }
            if (blockColumns <= 0)
            {
                throw new ArgumentOutOfRangeException("block columns must been greater than 0.");
            }
            if (rows <= 0)
            {
                throw new ArgumentOutOfRangeException("rows must been greater than 0.");
            }
            if (columns <= 0)
            {
                throw new ArgumentOutOfRangeException("columns must been greater than 0.");
            }

            var mapData = new MapData();

            mapData.BlockRows = blockRows;
            mapData.BlockColumns = blockColumns;
            mapData.Rows = rows;
            mapData.Columns = columns;
            mapData.NullBin = Bin.CreateNullBin('.');
            mapData.EmptyBin = Bin.CreateEmptyBin('-');
            mapData.SubstrateID = DateTime.Now.ToString("yyyy-MM-dd_HH:mm:ss");

            mapData.Bins = new BinCollection();
            mapData.Bins.Add(new Bin( '1', true));

            mapData.BinCodes = new BinCode[blockRows, blockColumns, rows, columns];
            for (int br = 0; br < blockRows; br++)
            {
                for (int bc = 0; bc < blockColumns; bc++)
                {
                    for (int r = 0; r < rows; r++)
                    {
                        for (int c = 0; c < columns; c++)
                        {
                            mapData.BinCodes[br, bc, r, c] = '1';
                        }
                    }
                }
            }

            return mapData;
        }
    }
}


