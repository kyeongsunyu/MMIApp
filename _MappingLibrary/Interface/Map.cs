using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class Map : IMap
    {
        public UnitData defUnit;

        //----------------------
        private Unit[,,,] units;
        //private Unit[,,,] originUnits;
        private List<Unit> workUnits;

        /// <summary>
        /// 
        /// </summary>
        public Map()
        {
            this.ReloadConverters();
        }

        #region MPW

        /// <summary>
        /// 
        /// </summary>
        public bool IsMPW
        {
            get; private set;
        }

        /// <summary>
        /// 
        /// </summary>
        public double Radius { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public double ShotStepX { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public double ShotStepY { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public double[] DieSizeXs { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public double[] DieSizeYs { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Bin[,] ShotBins { get; private set; }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        public IMapConverter MapConverter { get; set; }
        /// <summary>
        /// 
        /// </summary>



        public string SubstrateID { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public int BlockRows
        {
            get
            {
                if (this.units is null)
                    return 0;

                return this.units.GetLength(0);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int BlockColumns
        {
            get
            {
                if (this.units is null)
                    return 0;

                return this.units.GetLength(1);
            }
        }

        /// <summary>
        /// Number of rows.
        /// </summary>
        public int Rows
        {
            get
            {
                if (this.units is null)
                    return 0;

                return this.units.GetLength(2);
            }
        }

        /// <summary>
        /// Number of columns.
        /// </summary>
        public int Columns
        {
            get
            {
                if (this.units is null)
                    return 0;

                return this.units.GetLength(3);
            }
        }

        private WorkDirection workDirection;
        /// <summary>
        /// 
        /// </summary>
        public WorkDirection WorkDirection
        {
            get => this.workDirection;
            set
            {
                if (this.workDirection != value)
                {
                    this.workDirection = value;
                    this.Resort();
                }
            }
        }

        private OriginLocation originLocation;
        /// <summary>
        /// 
        /// </summary>
        public OriginLocation OriginLocation
        {
            get => this.originLocation;
            set
            {
                if (this.originLocation != value)
                {
                    this.originLocation = value;
                }
            }
        }

        private Orientation orientation;
        /// <summary>
        /// 
        /// </summary>
        public Orientation Orientation
        {
            get => this.orientation;
            set
            {
                if (this.orientation != value)
                {
                    this.orientation = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Bin NullBin { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Bin EmptyBin { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public BinCollection Bins { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public Unit this[int row, int column]
        {
            get
            {
                if (this.Rows == 0 || this.Columns == 0)
                    return null;

                int br = row / this.Rows;
                int r = row % this.Rows;
                int bc = column / this.Columns;
                int c = column % this.Columns;
                return this[br, bc, r, c];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockRow"></param>
        /// <param name="blockColumn"></param>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public Unit this[int blockRow, int blockColumn, int row, int column]
        {
            get
            {
                if (this.units is null)
                {
                    return null;
                }
                if ((blockRow < 0 || blockRow >= this.BlockRows) ||
                    (blockColumn < 0 || blockColumn >= this.BlockColumns) ||
                    (row < 0 || row >= this.Rows) ||
                    (column < 0 || column >= this.Columns))
                {
                    return null;
                }

                return this.units[blockRow, blockColumn, row, column];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public Unit Current { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        public void SetCurrent(Unit unit)
        {
            this.Current = unit;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool HasNextUnit()
        {
            if (this.workUnits == null)
            {
                return false;
            }

            int count = this.workUnits.Count;

            if (count == 0)
            {
                return false;
            }

            if (this.Current == null)
            {
                return true;
            }

            return this.Current.Index < (count - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool NextUnit()
        {
            if (this.workUnits == null)
            {
                return false;
            }

            int count = this.workUnits.Count;

            if (count == 0)
            {
                return false;
            }

            if (this.Current == null)
            {
                this.Current = this.workUnits[0];
                return true;
            }

            int index = this.Current.Index;
            index++;
            if (index >= count)
            {
                return false;
            }

            this.Current = this.workUnits[index];
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curr"></param>
        /// <returns></returns>
        public Unit Left(Unit curr)
        {
            if (curr is null)
            {
                return null;
            }

            if (this.IsMPW)
            {
                int bc = curr.BlockColumn;
                int c = curr.Column - 1;
                if (c < 0)
                {
                    c = this.Columns - 1;
                    bc--;
                }
                return this[curr.BlockRow, bc, curr.Row, c];
            }
            else
            {
                return this[curr.Row, curr.Column - 1];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curr"></param>
        /// <returns></returns>
        public Unit Right(Unit curr)
        {
            if (curr is null)
            {
                return null;
            }

            if (this.IsMPW)
            {
                int bc = curr.BlockColumn;
                int c = curr.Column + 1;
                if (c >= this.Columns)
                {
                    c = 0;
                    bc++;
                }
                return this[curr.BlockRow, bc, curr.Row, c];
            }
            else
            {
                return this[curr.Row, curr.Column + 1];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curr"></param>
        /// <returns></returns>
        public Unit Up(Unit curr)
        {
            if (curr is null)
            {
                return null;
            }

            if (this.IsMPW)
            {
                int br = curr.BlockRow;
                int r = curr.Row - 1;
                if (r < 0)
                {
                    r = this.Rows - 1;
                    br--;
                }
                return this[br, curr.BlockColumn, r, curr.Column];
            }
            else
            {
                return this[curr.Row - 1, curr.Column];
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curr"></param>
        /// <returns></returns>
        public Unit Down(Unit curr)
        {
            if (curr is null)
            {
                return null;
            }

            if (this.IsMPW)
            {
                int br = curr.BlockRow;
                int r = curr.Row + 1;
                if (r >= this.Rows)
                {
                    r = 0;
                    br++;
                }
                return this[br, curr.BlockColumn, r, curr.Column];
            }
            else
            {
                return this[curr.Row + 1, curr.Column];
            }
        }











        /// <summary>
        /// 
        /// </summary>
        /// <param name="mapFile"></param>
        /// 

        public void Apply()
        {
            this.Parse();
        }
        public void Read(string mapFile, bool isOriginalMap = false)
        {/*
            if (this.MapConverter is null)
            {
                throw new InvalidOperationException("Map Converter is not configured");
            }

            MapData mapData = null;
            try
            {
                if (!File.Exists(mapFile))
                {
                    string name = Path.GetFileNameWithoutExtension(mapFile);
                    throw new InvalidOperationException($"Map file '{name}' does not exist");
                }

                var OrigianlMapData = this.MapConverter.Read(mapFile, true);
                mapData = this.MapConverter.Read(mapFile, isOriginalMap);
                mapData.OriginalBinCodes = OrigianlMapData.BinCodes;

                if (mapData is null)
                {
                    throw new InvalidOperationException("Map file format is invalid");
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Map file read exception", ex);
            }

            this.Parse(mapData);*/
        
            this.Parse();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="dieSizeX"></param>
        /// <param name="dieSizeY"></param>
        /// <returns></returns>
        public static Map CreateWaferMap(double radius, double dieSizeX, double dieSizeY)
        {
            var creater = new WaferMapCreater();
            var mapData = creater.Create(radius, dieSizeX, dieSizeY);
            var map = new Map();
            map.Parse();

            return map;
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
        public static Map CreateWaferMap(double diameter, double dieSizeX, double dieSizeY, double centerOffsetX, double centerOffsetY, out int centerRow, out int centerColumn)
        {
            var creater = new WaferMapCreater();
            var mapData = creater.Create(diameter, dieSizeX, dieSizeY, centerOffsetX, centerOffsetY, out centerRow, out centerColumn);
            var map = new Map();
            map.Parse();

            return map;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="dieSizeX"></param>
        /// <param name="dieSizeY"></param>
        /// <returns></returns>
        public static Map CreateEmptyBinWaferMap(double radius, double dieSizeX, double dieSizeY)
        {
            var creater = new WaferMapCreater();
            var mapData = creater.CreateEmptyBin(radius, dieSizeX, dieSizeY);
            var map = new Map();
            map.Parse();

            return map;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// 
        /*
        public void SaveMap(string fileName)
        {
            if (this.MapConverter is null)
            {
                throw new InvalidOperationException("Map Converter is not configured");
            }

            Unit[,,,] units = null;
            try
            {
                units = this.Revert();

                this.MapConverter.Save(this, fileName);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Map save failed: {ex.Message}");
            }
            finally
            {
                this.Restore(units);
            }
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockRows"></param>
        /// <param name="blockColumns"></param>
        /// <param name="rows"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static Map CreateStripMap(int blockRows, int blockColumns, int rows, int columns)
        {
            var creater = new StripMapCreater();
            var mapData = creater.Create(blockRows, blockColumns, rows, columns);
            var map = new Map();
            map.Parse();

            return map;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="shotRows"></param>
        /// <param name="shotColumns"></param>
        /// <param name="shotStepX"></param>
        /// <param name="shotStepY"></param>
        /// <param name="rowsInShot"></param>
        /// <param name="columnsInShot"></param>
        /// <param name="dieSizeXs"></param>
        /// <param name="dieSizeYs"></param>
        /// <param name="offsetX"></param>
        /// <param name="offsetY"></param>
        /// <param name="shotBins"></param>
        /// <returns></returns>
        public static Map CreateMPWMap(double radius, int shotRows, int shotColumns, double shotStepX, double shotStepY,
            int rowsInShot, int columnsInShot, double[] dieSizeXs, double[] dieSizeYs, double offsetX, double offsetY, BinCollection shotBins)
        {
            var creater = new MPWMapCreater();
            var mapData = creater.Create(radius, shotRows, shotColumns, shotStepX, shotStepY,
                rowsInShot, columnsInShot, dieSizeXs, dieSizeYs, offsetX, offsetY, shotBins);
            var map = new Map();
            map.IsMPW = true;
            map.Parse();

            map.Radius = radius;
            map.ShotStepX = shotStepX;
            map.ShotStepY = shotStepY;
            map.DieSizeXs = dieSizeXs;
            map.DieSizeYs = dieSizeYs;

            return map;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bin"></param>
        /// <returns></returns>
        public int Count(Bin bin = null)
        {
            if (this.units is null)
            {
                return 0;
            }

            int count = 0;
            for (int br = 0; br < this.BlockRows; br++)
            {
                for (int bc = 0; bc < this.BlockColumns; bc++)
                {
                    for (int r = 0; r < this.Rows; r++)
                    {
                        for (int c = 0; c < this.Columns; c++)
                        {
                            var unit = this.units[br, bc, r, c];
                            if (bin is null)
                            {
                                if (!this.IsNullBin(unit))
                                {
                                    count++;
                                }
                            }
                            else
                            {
                                if (!(unit is null) && unit.Bin == bin)
                                {
                                    count++;
                                }
                            }
                        }
                    }
                }
            }

            return count;
        }

        public int CountPicked()
        {
            return this.Count(UnitState.Picked);
        }

        public int CountReject()
        {
            return this.Count(UnitState.Reject);
        }

        public int Count(UnitState state)
        {
            if (this.workUnits is null)
            {
                return 0;
            }

            return this.workUnits.Count(x => x.State == state);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="unitState"></param>
        public void SetUnitState(Unit unit, UnitState unitState)
        {
            if (unit is null)
            {
                throw new ArgumentNullException("unit");
            }

            var u = this.workUnits.Find(x => x.BlockRow == unit.BlockRow &&
                                             x.BlockColumn == unit.BlockColumn &&
                                             x.Row == unit.Row &&
                                             x.Column == unit.Column);

            u.SetState(unitState);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitState"></param>
        public void SetAllUnitState(UnitState unitState)
        {
            for (int br = 0; br < this.BlockRows; br++)
            {
                for (int bc = 0; bc < this.BlockColumns; bc++)
                {
                    for (int r = 0; r < this.Rows; r++)
                    {
                        for (int c = 0; c < this.Columns; c++)
                        {
                            var unit = this[br, bc, r, c];

                            if (!(unit is null))
                            {
                                unit.SetState(unitState);
                            }
                            else
                            {
                                throw new ArgumentNullException("unit");
                            }
                        }
                    }
                }
            }
        }

        public List<Unit> GetAllWorkUnit()
        {
            return this.workUnits;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        
        /*
        public Map Clone()
        {
            Map map = new Map();
            map.NullBin = this.NullBin;
            map.EmptyBin = this.EmptyBin;
            map.Bins = new BinCollection();
            foreach (var bin in this.Bins)
            {
                map.Bins.Add(new Bin(bin));
            }

            map.units = new Unit[this.BlockRows, this.BlockColumns, this.Rows, this.Columns];
            for (int br = 0; br < this.BlockRows; br++)
            {
                for (int bc = 0; bc < this.BlockColumns; bc++)
                {
                    for (int r = 0; r < this.Rows; r++)
                    {
                        for (int c = 0; c < this.Columns; c++)
                        {
                            var unit = this[br, bc, r, c];
                            Bin bin = map.GetBin(unit.Bin.Code);
                            UnitState state = unit.State;
                            map.units[br, bc, r, c] = new Unit(map, bin, br, bc, r, c, state);
                        }
                    }
                }
            }

            if (this.Current != null)
            {
                map.Current = map[this.Current.BlockRow, this.Current.BlockColumn, this.Current.Row, this.Current.Column];
            }

            return map;
        }*/

        /// <summary>
        /// 
        /// </summary>
        /// <param name="map"></param>
        public void Copy(Map map)
        {
            for (int br = 0; br < this.BlockRows; br++)
            {
                for (int bc = 0; bc < this.BlockColumns; bc++)
                {
                    for (int r = 0; r < this.Rows; r++)
                    {
                        for (int c = 0; c < this.Columns; c++)
                        {
                            this[br, bc, r, c].Bin = map[br, bc, r, c].Bin;
                            this[br, bc, r, c].SetState(map[br, bc, r, c].State);
                        }
                    }
                }
            }

            //ReIndex();
        }
        /*
        public void Rotate(Orientation orientation)
        {
            this.Orientation = orientation;

            if (this.IsMPW)
                return;

            int originRows = this.originUnits.GetLength(2);
            int originColumns = this.originUnits.GetLength(3);
            Unit[,,,] newUnits = this.units;

            switch (orientation)
            {
                case Orientation.OT90:
                    newUnits = new Unit[this.BlockRows, this.BlockColumns, originColumns, originRows];
                    for (int r = 0; r < originRows; r++)
                    {
                        for (int c = 0; c < originColumns; c++)
                        {
                            var unit = this.originUnits[0, 0, r, c];
                            newUnits[0, 0, originColumns - 1 - c, r] = new Unit(this, unit.Bin, 0, 0, originColumns - 1 - c, r, unit.State);
                        }
                    }
                    break;
                case Orientation.OT180:
                    newUnits = new Unit[this.BlockRows, this.BlockColumns, originRows, originColumns];
                    for (int r = 0; r < originRows; r++)
                    {
                        for (int c = 0; c < originColumns; c++)
                        {
                            var unit = this.originUnits[0, 0, r, c];
                            newUnits[0, 0, originRows - 1 - r, originColumns - 1 - c] = new Unit(this, unit.Bin, 0, 0, originRows - 1 - r, originColumns - 1 - c, unit.State);
                        }
                    }
                    break;
                case Orientation.OT270:
                    newUnits = new Unit[this.BlockRows, this.BlockColumns, originColumns, originRows];
                    for (int r = 0; r < originRows; r++)
                    {
                        for (int c = 0; c < originColumns; c++)
                        {
                            var unit = this.originUnits[0, 0, r, c];
                            newUnits[0, 0, c, originRows - 1 - r] = new Unit(this, unit.Bin, 0, 0, c, originRows - 1 - r, unit.State);
                        }
                    }
                    break;
                case Orientation.OT0:
                default:
                    break;
            }

            this.units = newUnits;

            this.Resort();
        }*/
        /*
        private Unit[,,,] Revert()
        {
            int originRows = this.originUnits.GetLength(2);
            int originColumns = this.originUnits.GetLength(3);

            switch (orientation)
            {
                case Orientation.OT90:
                    for (int r = 0; r < originRows; r++)
                    {
                        for (int c = 0; c < originColumns; c++)
                        {
                            this.originUnits[0, 0, r, c].SetState(this.units[0, 0, originColumns - 1 - c, r].State);
                        }
                    }
                    break;
                case Orientation.OT180:
                    for (int r = 0; r < originRows; r++)
                    {
                        for (int c = 0; c < originColumns; c++)
                        {
                            this.originUnits[0, 0, r, c].SetState(this.units[0, 0, originRows - 1 - r, originColumns - 1 - c].State);
                        }
                    }
                    break;
                case Orientation.OT270:
                    for (int r = 0; r < originRows; r++)
                    {
                        for (int c = 0; c < originColumns; c++)
                        {
                            this.originUnits[0, 0, r, c].SetState(this.units[0, 0, c, originRows - 1 - r].State);
                        }
                    }
                    break;
                case Orientation.OT0:
                default:
                    break;
            }

            var prev = this.units;
            this.units = this.originUnits;

            return prev;
        }*/

        private void Restore(Unit[,,,] units)
        {
            this.units = units;
        }

        internal virtual void Parse()
        {
            this.units = new Unit[defUnit.BlockRows, defUnit.BlockColumns, defUnit.Rows, defUnit.Columns];
            for (int br = 0; br < defUnit.BlockRows; br++)
            {
                for (int bc = 0; bc < defUnit.BlockColumns; bc++)
                {
                    for (int r = 0; r < defUnit.Rows; r++)
                    {
                        for (int c = 0; c < defUnit.Columns; c++)
                        {

                            //this.units[br, bc, r, c] = new Unit(this, br, bc, r, c, defUnit.Coloridx[r,c], defUnit.msg[r,c]);

                            this.units[br, bc, r, c] = new Unit(this, br, bc, r, c, defUnit.Coloridx[c, r], defUnit.msg[c,r]);


                            /*
                            BinCode binCode = mapData.BinCodes[br, bc, r, c];
                            if (binCode.FormatType == BinFormatType.Ascii)
                            {
                                if (binCode == '@') // picked bin
{
                                    Bin bin = null;
                                    var bins = this.Bins.FindAll(x => x.Work);
                                    bin = bins.Find(x => x.Code == mapData.OriginalBinCodes?[br, bc, r, c]);
                                    if (bin is null)
                                        bin = Bins.Find(x => x.Work);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Processed);
                                }
                                else if (binCode == '&') // reject bin
{
                                    Bin bin = null;
                                    var bins = this.Bins.FindAll(x => x.Work);
                                    bin = bins.Find(x => x.Code == mapData.OriginalBinCodes?[br, bc, r, c]);
                                    if (bin is null)
                                        bin = Bins.Find(x => x.Work);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Reject);
                                }
                                else
                                {
                                    var bin = this.GetBin(binCode);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Good);
                                }
                            }
                            else if (binCode.FormatType == BinFormatType.HexaDecimal)
                            {
                                if (binCode.FormattedCode == "FA") // picked bin
{
                                    Bin bin = null;
                                    var bins = this.Bins.FindAll(x => x.Work);
                                    bin = bins.Find(x => x.Code == mapData.OriginalBinCodes?[br, bc, r, c]);
                                    if (bin is null)
                                        bin = Bins.Find(x => x.Work);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Processed);
                                }
                                else if (binCode.FormattedCode == "FB") // reject bin
{
                                    Bin bin = null;
                                    var bins = this.Bins.FindAll(x => x.Work);
                                    bin = bins.Find(x => x.Code == mapData.OriginalBinCodes?[br, bc, r, c]);
                                    if (bin is null)
                                        bin = Bins.Find(x => x.Work);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Reject);
                                }
                                else
                                {
                                    var bin = this.GetBin(binCode);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Good);
                                }
                            }
                            */
                        }
                    }
                }
            }
            /*
            foreach (var bin in this.Bins)
            {
                bin.Count = this.Count(bin);
            }

            this.originUnits = this.units;
            this.Current = null;
            this.Resort();*/
        }
        /*
        internal virtual void Parse(MapData mapData)
        {
            this.SubstrateID = mapData.SubstrateID;
            this.NullBin = mapData.NullBin;
            this.EmptyBin = mapData.EmptyBin;
            this.Bins = mapData.Bins;
            this.ShotBins = mapData.ShotBins;
            this.units = new Unit[defUnit.BlockRows, defUnit.BlockColumns, defUnit.Rows, defUnit.Columns];
            for (int br = 0; br < defUnit.BlockRows; br++)
            {
                for (int bc = 0; bc < mapData.BlockColumns; bc++)
                {
                    for (int r = 0; r < defUnit.Rows; r++)
                    {
                        for (int c = 0; c < defUnit.Columns; c++)
                        {
                            BinCode binCode = mapData.BinCodes[br, bc, r, c];
                            if (binCode.FormatType == BinFormatType.Ascii)
                            {
                                if (binCode == '@') // picked bin
                                {
                                    Bin bin = null;
                                    var bins = this.Bins.FindAll(x => x.Work);
                                    bin = bins.Find(x => x.Code == mapData.OriginalBinCodes?[br, bc, r, c]);
                                    if (bin is null)
                                        bin = Bins.Find(x => x.Work);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Processed);
                                }
                                else if (binCode == '&') // reject bin
                                {
                                    Bin bin = null;
                                    var bins = this.Bins.FindAll(x => x.Work);
                                    bin = bins.Find(x => x.Code == mapData.OriginalBinCodes?[br, bc, r, c]);
                                    if (bin is null)
                                        bin = Bins.Find(x => x.Work);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Reject);
                                }
                                else
                                {
                                    var bin = this.GetBin(binCode);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Good);
                                }
                            }
                            else if (binCode.FormatType == BinFormatType.HexaDecimal)
                            {
                                if (binCode.FormattedCode == "FA") // picked bin
                                {
                                    Bin bin = null;
                                    var bins = this.Bins.FindAll(x => x.Work);
                                    bin = bins.Find(x => x.Code == mapData.OriginalBinCodes?[br, bc, r, c]);
                                    if (bin is null)
                                        bin = Bins.Find(x => x.Work);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Processed);
                                }
                                else if (binCode.FormattedCode == "FB") // reject bin
                                {
                                    Bin bin = null;
                                    var bins = this.Bins.FindAll(x => x.Work);
                                    bin = bins.Find(x => x.Code == mapData.OriginalBinCodes?[br, bc, r, c]);
                                    if (bin is null)
                                        bin = Bins.Find(x => x.Work);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Reject);
                                }
                                else
                                {
                                    var bin = this.GetBin(binCode);
                                    this.units[br, bc, r, c] = new Unit(this, bin, br, bc, r, c, UnitState.Good);
                                }
                            }

                        }
                    }
                }
            }

            foreach (var bin in this.Bins)
            {
                bin.Count = this.Count(bin);
            }

            this.originUnits = this.units;
            this.Current = null;
            this.Resort();
        }*/

        /// <summary>
        /// 
        /// </summary>
        public virtual void Resort()
        {
            var dir = this.IsMPW ? WorkDirection.LT_RIGHT_S : this.WorkDirection;
            var sorter = Sorter.GetSorter(dir);
            sorter.Sort(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binCode"></param>
        /// <returns></returns>
        protected virtual bool IsWorkBin(BinCode binCode)
        {
            if (binCode == this.NullBin.Code)
            {
                return false;
            }

            bool exist = this.Bins.Exists(x => x.Code == binCode && x.Work);

            return exist;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="bin"></param>
        /// <returns></returns>
        protected virtual bool IsWorkBin(Bin bin)
        {
            if (bin is null)
            {
                return false;
            }

            return bin.Work;
        }

        private bool IsWorkUnit(Unit unit)
        {
            if (!(unit is null) && unit.Bin != this.NullBin && unit.Bin.Work)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unit"></param>
        /// <returns></returns>
        public bool IsNullBin(Unit unit)
        {
            if ((unit is null) || unit.Bin == this.NullBin)
            {
                return true;
            }

            return false;
        }

        private Bin GetBin(ushort binCode)
        {
            var bin = this.Bins.Find(x => x.Code == binCode);
            if (bin == null)
            {
                if (this.NullBin.Code.Code == binCode)
                {
                    bin = this.NullBin;
                }
                else
                {
                    bin = this.EmptyBin;
                }
            }
            return bin;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="binConfigurations"></param>
        public bool UpdateBins(BinConfigurationCollection binConfigurations)
        {
            if (binConfigurations == null || this.IsMPW)
            {
                return true;
            }

            int count = 0;

            foreach (var bin in Bins)
            {
                bin.Work = false;
            }

            foreach (var c in binConfigurations)
            {
                var b = this.Bins[c.BinCode];

                if (b != null)
                {
                    b.Work = c.Pick;
                    b.Color = c.Color;
                    count++;
                }
            }

            this.Resort();

            if (this.Bins.Count != count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void ReserveLastDies(IEnumerable<Unit> units)
        {
            bool reorder = false;

            foreach (var unit in units)
            {
                if (unit.IsWorkUnit && unit.State == UnitState.Good)
                {
                    reorder = true;
                    this.workUnits.Remove(unit);
                }
            }

            foreach (var unit in units)
            {
                if (unit.IsWorkUnit && unit.State == UnitState.Good)
                {
                    this.workUnits.Add(unit);
                }
            }

            if (reorder)
            {
                int index = 0;
                foreach (var unit in this.workUnits)
                {
                    unit.Index = index;
                    index++;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="shotBins"></param>
        public void UpdateBins(BinCollection shotBins)
        {
            if (shotBins == null || !this.IsMPW)
            {
                return;
            }

            if (this.Bins == null)
            {
                this.Bins = new BinCollection();
            }
            this.Bins?.Clear();

            int i = 0;
            foreach (var bin in shotBins)
            {
                int r = i / this.Columns;
                int c = i - r * this.Columns;
                i++;

                this.ShotBins[r, c] = bin;


                if (!this.Bins.Exists(x => x.Code == bin.Code))
                {
                    this.Bins.Add(bin);
                }
            }

            for (int sr = 0; sr < this.BlockRows; sr++)
            {
                for (int sc = 0; sc < this.BlockColumns; sc++)
                {
                    for (int r = 0; r < this.Rows; r++)
                    {
                        for (int c = 0; c < this.Columns; c++)
                        {
                            var unit = this[sr, sc, r, c];
                            var bin = unit.Bin;
                            if (bin != this.NullBin && bin != this.EmptyBin)
                            {
                                unit.Bin = this.ShotBins[r, c];
                            }
                        }
                    }
                }
            }

            this.Resort();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="blockRow"></param>
        /// <param name="blockColumn"></param>
        /// <returns></returns>
        public List<Unit> GetUnits(int blockRow, int blockColumn)
        {
            return this.workUnits.FindAll(x => x.BlockRow == blockRow &&
                                               x.BlockColumn == blockColumn);
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual void ReloadConverters()
        {
            MapConverterMap.LookupWithDefault("CHIP MOS", new ChipMosConverter());
            MapConverterMap.LookupWithDefault("G85", new G85Converter());
            MapConverterMap.LookupWithDefault("BYD", new BYDConverter());
            MapConverterMap.LookupWithDefault("SMEC", new SMECConverter());
            MapConverterMap.LookupWithDefault("RDW", new RDWConverter());
            MapConverterMap.LookupWithDefault("HW", new HWConverter());
        }

        internal abstract class Sorter
        {
            public static Sorter GetSorter(WorkDirection workDirection)
            {
                Sorter sorter = null;

                switch (workDirection)
                {
                    case WorkDirection.LT_RIGHT_S:
                        sorter = new LTRSSorter();
                        break;
                    case WorkDirection.RT_LEFT_S:
                        sorter = new RTLSSorter();
                        break;
                    case WorkDirection.LT_DOWN_S:
                        sorter = new LTDSSorter();
                        break;
                    case WorkDirection.RT_DOWN_S:
                        sorter = new RTDSSorter();
                        break;
                    case WorkDirection.LB_UP_S:
                        sorter = new LBUSSorter();
                        break;
                    case WorkDirection.RB_UP_S:
                        sorter = new RBUSSorter();
                        break;
                    case WorkDirection.LB_RIGHT_S:
                        sorter = new LBRSSorter();
                        break;
                    case WorkDirection.RB_LEFT_S:
                        sorter = new RBLSSorter();
                        break;
                    case WorkDirection.LT_RIGHT_Z:
                        sorter = new LTRZSorter();
                        break;
                    case WorkDirection.RT_LEFT_Z:
                        sorter = new RTLZSorter();
                        break;
                    case WorkDirection.LT_DOWN_Z:
                        sorter = new LTDZSorter();
                        break;
                    case WorkDirection.RT_DOWN_Z:
                        sorter = new RTDZSorter();
                        break;
                    case WorkDirection.LB_UP_Z:
                        sorter = new LBUZSorter();
                        break;
                    case WorkDirection.RB_UP_Z:
                        sorter = new RBUZSorter();
                        break;
                    case WorkDirection.LB_RIGHT_Z:
                        sorter = new LBRZSorter();
                        break;
                    case WorkDirection.RB_LEFT_Z:
                        sorter = new RBLZSorter();
                        break;
                    default:
                        sorter = new LTRSSorter();
                        break;
                }

                return sorter;
            }

            protected abstract void InternalSort(Map map);

            public void Sort(Map map)
            {
                this.InternalSort(map);

                var prev = map.Current;
                if (!(prev is null))
                {
                    map.Current = map.workUnits.Find(x => x == prev);
                }
            }

            private class LTRSSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = 0, end = map.BlockColumns, step = 1;
                            if ((br & 1) == 1)
                            {
                                bc = map.BlockColumns - 1;
                                end = -1;
                                step = -1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = 0, e = map.Columns, dir = 1;
                                    if ((r & 1) == 1)
                                    {
                                        c = map.Columns - 1;
                                        e = -1;
                                        dir = -1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            for (int bc = 0; bc < map.BlockColumns; bc++)
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    for (int c = 0; c < map.Columns; c++)
                                    {
                                        bool oddr = (r & 1) == 1;

                                        bool oddbr = (br & 1) == 1;

                                        var unit = map.units[br, oddbr ? map.BlockColumns - 1 - bc : bc, r, oddr ? map.Columns - c - 1 : c];

                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class RTLSSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            for (int bc = 0; bc < map.BlockColumns; bc++)
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    for (int c = 0; c < map.Columns; c++)
                                    {
                                        bool oddr = (r & 1) == 0;

                                        bool oddbr = (br & 1) == 0;

                                        var unit = map.units[br, oddbr ? map.BlockColumns - 1 - bc : bc, r, oddr ? map.Columns - c - 1 : c];

                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class LTDSSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int bc = 0; bc < map.BlockColumns; bc++)
                        {
                            for (int br = 0; br < map.BlockRows; br++)
                            {
                                for (int c = 0; c < map.Columns; c++)
                                {
                                    for (int r = 0; r < map.Rows; r++)
                                    {
                                        bool oddc = (c & 1) == 1;

                                        bool oddbc = (bc & 1) == 1;

                                        var unit = map.units[oddbc ? map.BlockRows - 1 - br : br, bc, oddc ? map.Rows - 1 - r : r, c];

                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class RTDSSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int bc = map.BlockColumns - 1; bc >= 0; bc--)
                        {
                            for (int br = 0; br < map.BlockRows; br++)
                            {
                                for (int c = map.Columns - 1; c >= 0; c--)
                                {
                                    for (int r = 0; r < map.Rows; r++)
                                    {
                                        bool oddc = (c & 1) == 0;

                                        bool oddbc = (bc & 1) == 0;

                                        var unit = map.units[oddbc ? map.BlockRows - 1 - br : br, bc, oddc ? map.Rows - 1 - r : r, c];

                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class LBUSSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int bc = 0; bc < map.BlockColumns; bc++)
                        {
                            for (int br = 0; br < map.BlockRows; br++)
                            {
                                for (int c = 0; c < map.Columns; c++)
                                {
                                    for (int r = 0; r < map.Rows; r++)
                                    {
                                        bool oddc = (c & 1) == 0;

                                        bool oddbc = (bc & 1) == 0;

                                        var unit = map.units[br, oddbc ? map.BlockColumns - 1 - bc : bc, r, oddc ? map.Columns - 1 - c : c];

                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class RBUSSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int bc = map.BlockColumns - 1; bc >= 0; bc--)
                        {
                            for (int br = 0; br < map.BlockRows; br++)
                            {
                                for (int c = map.Columns - 1; c >= 0; c--)
                                {
                                    for (int r = 0; r < map.Rows; r++)
                                    {
                                        bool oddc = (c & 1) == 1;

                                        bool oddbc = (bc & 1) == 1;

                                        var unit = map.units[oddbc ? map.BlockRows - 1 - br : br, bc, oddc ? map.Rows - 1 - r : r, c];

                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class LBRSSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int br = map.BlockRows - 1; br >= 0; br--)
                        {
                            for (int bc = 0; bc < map.BlockColumns; bc++)
                            {
                                for (int r = map.Rows - 1; r >= 0; r--)
                                {
                                    for (int c = 0; c < map.Columns; c++)
                                    {
                                        bool oddr = (r & 1) == 1;

                                        bool oddbr = (br & 1) == 1;

                                        var unit = map.units[br, oddbr ? map.BlockColumns - 1 - bc : bc, r, oddr ? map.Columns - c - 1 : c];

                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class RBLSSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int br = map.BlockRows - 1; br >= 0; br--)
                        {
                            for (int bc = 0; bc < map.BlockColumns; bc++)
                            {
                                for (int r = map.Rows - 1; r >= 0; r--)
                                {
                                    for (int c = 0; c < map.Columns; c++)
                                    {
                                        bool oddr = (r & 1) == 0;

                                        bool oddbr = (br & 1) == 0;

                                        var unit = map.units[br, oddbr ? map.BlockColumns - 1 - bc : bc, r, oddr ? map.Columns - c - 1 : c];

                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }

                    }
                }
            }

            private class LTRZSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            for (int bc = 0; bc < map.BlockColumns; bc++)
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    for (int c = 0; c < map.Columns; c++)
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class RTLZSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            for (int bc = map.BlockColumns - 1; bc >= 0; bc--)
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    for (int c = map.Columns - 1; c >= 0; c--)
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class LTDZSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int bc = 0; bc < map.BlockColumns; bc++)
                        {
                            for (int br = 0; br < map.BlockRows; br++)
                            {
                                for (int c = 0; c < map.Columns; c++)
                                {
                                    for (int r = 0; r < map.Rows; r++)
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class RTDZSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int bc = map.BlockColumns - 1; bc >= 0; bc--)
                        {
                            for (int br = 0; br < map.BlockRows; br++)
                            {
                                for (int c = map.Columns - 1; c >= 0; c--)
                                {
                                    for (int r = 0; r < map.Rows; r++)
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class LBUZSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int bc = 0; bc < map.BlockColumns; bc++)
                        {
                            for (int br = map.BlockRows - 1; br >= 0; br--)
                            {
                                for (int c = 0; c < map.Columns; c++)
                                {
                                    for (int r = map.Rows - 1; r >= 0; r--)
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class RBUZSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int bc = map.BlockColumns - 1; bc >= 0; bc--)
                        {
                            for (int br = map.BlockRows - 1; br >= 0; br--)
                            {
                                for (int c = map.Columns - 1; c >= 0; c--)
                                {
                                    for (int r = map.Rows - 1; r >= 0; r--)
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class LBRZSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int br = map.BlockRows - 1; br >= 0; br--)
                        {
                            for (int bc = 0; bc < map.BlockColumns; bc++)
                            {
                                for (int r = map.Rows - 1; r >= 0; r--)
                                {
                                    for (int c = 0; c < map.Columns; c++)
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }

            private class RBLZSorter : Sorter
            {
                protected override void InternalSort(Map map)
                {
                    map.workUnits = new List<Unit>();
                    int index = 0;
                    if (map.IsMPW)
                    {
                        for (int br = 0; br < map.BlockRows; br++)
                        {
                            int bc = map.BlockColumns - 1, end = -1, step = -1;
                            if ((br & 1) == 1)
                            {
                                bc = 0;
                                end = map.BlockColumns;
                                step = 1;
                            }
                            do
                            {
                                for (int r = 0; r < map.Rows; r++)
                                {
                                    int c = map.Columns - 1, e = -1, dir = -1;
                                    if ((r & 1) == 1)
                                    {
                                        c = 0;
                                        e = map.Columns;
                                        dir = 1;
                                    }

                                    do
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }

                                        c = c + dir;
                                    } while (c != e);
                                }

                                bc = bc + step;
                            } while (bc != end);
                        }
                    }
                    else
                    {
                        for (int br = map.BlockRows - 1; br >= 0; br--)
                        {
                            for (int bc = map.BlockColumns - 1; bc >= 0; bc--)
                            {
                                for (int r = map.Rows - 1; r >= 0; r--)
                                {
                                    for (int c = map.Columns - 1; c >= 0; c--)
                                    {
                                        var unit = map.units[br, bc, r, c];
                                        var bin = unit?.Bin;
                                        if (map.IsWorkBin(bin))
                                        {
                                            unit.Index = index;
                                            map.workUnits.Add(unit);
                                            index++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}


