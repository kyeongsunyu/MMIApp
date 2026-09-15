using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMI
{
    public class CRcpMaterial
    {
        public List<double> DeviceData = new List<double>();
        public int Material_IDX;
        public string Material_NAME;

        // Scan trigger settings, in the units the operator types on the panel:
        // mm, mm, um, kHz. They are named columns rather than DATAxxx slots
        // because FormDataRecipe.Save_Device() rebuilds all 200 slots from its
        // own screen and writes 0 into every one it does not own - anything
        // parked in a spare slot is erased the next time a recipe is saved.
        public double ScanStart;
        public double ScanEnd;
        public double ScanPixelRes;
        public double ScanLineRate;

        // Machines built before the scan trigger have a DEVICE table without
        // these columns. Adding them is idempotent, so this can run at every
        // start; it must run before the first LoadRcpMaterial().
        public static void EnsureScanTriggerColumns()
        {
            List<string> cols = new List<string>();

            if (SQLiteDB.Select("PRAGMA table_info(DEVICE)", ref SQLiteDB.ReaderDeviceData))
            {
                while (SQLiteDB.ReaderDeviceData.Read())
                {
                    cols.Add(SQLiteDB.ReaderDeviceData["name"].ToString());
                }
            }
            if (SQLiteDB.ReaderDeviceData != null) SQLiteDB.ReaderDeviceData.Close();

            if (cols.Count == 0) return;      // no table to migrate

            foreach (string strCol in ScanTriggerColumns)
            {
                if (cols.Contains(strCol)) continue;
                SQLiteDB.Execute("ALTER TABLE DEVICE ADD COLUMN " + strCol + " REAL DEFAULT 0");
            }
        }

        private static readonly string[] ScanTriggerColumns =
            { "SCAN_START", "SCAN_END", "SCAN_PIXEL_RES", "SCAN_LINE_RATE" };

        private static double ReadDouble(System.Data.SQLite.SQLiteDataReader r, string strCol)
        {
            object o = r[strCol];
            if (o == null || o == DBNull.Value) return 0.0;

            // A REAL column comes back boxed, so take it straight and skip the
            // string round trip, which would be at the mercy of the locale.
            if (o is double) return (double)o;

            double dValue;
            return double.TryParse(o.ToString(), NumberStyles.Float,
                                   CultureInfo.InvariantCulture, out dValue) ? dValue : 0.0;
        }

        // Only the four scan columns. SaveRcpMaterial() rewrites all 200 DATA
        // values from memory, which is more than this needs to touch and would
        // carry back whatever else is stale in the list.
        public void SaveScanTrigger()
        {
            // InvariantCulture, or a locale with a comma decimal separator writes
            // "SCAN_START = 10,0000" and the statement is silently rejected.
            CultureInfo ci = CultureInfo.InvariantCulture;

            string strSQL = " UPDATE DEVICE SET "
                          + " SCAN_START = "      + ScanStart.ToString("F4", ci)
                          + ", SCAN_END = "       + ScanEnd.ToString("F4", ci)
                          + ", SCAN_PIXEL_RES = " + ScanPixelRes.ToString("F4", ci)
                          + ", SCAN_LINE_RATE = " + ScanLineRate.ToString("F4", ci)
                          + " WHERE IDX = "       + Material_IDX.ToString(ci);

            SQLiteDB.Execute(strSQL);
        }


        public void LoadRcpMaterial(bool CurChk = false)
        {
            string sSQL = "";
            int iDevNo;
            DeviceData.Clear();
            double dData = 0;

            if (CurChk)
                sSQL = "SELECT * FROM DEVICE WHERE CURR_MARK = '**' ";// ORDER BY IDX ASC";
            else
                sSQL = "SELECT * FROM DEVICE WHERE IDX = " + Material_IDX.ToString();


            string strKey = "";

            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderDeviceData))
            {
                if (SQLiteDB.ReaderDeviceData.Read())
                {
                    Material_IDX = int.TryParse(SQLiteDB.ReaderDeviceData["IDX"].ToString(), out iDevNo) ? iDevNo : 1;
                    Material_NAME = SQLiteDB.ReaderDeviceData["DEVICE_NAME"].ToString();

                    ScanStart     = ReadDouble(SQLiteDB.ReaderDeviceData, "SCAN_START");
                    ScanEnd       = ReadDouble(SQLiteDB.ReaderDeviceData, "SCAN_END");
                    ScanPixelRes  = ReadDouble(SQLiteDB.ReaderDeviceData, "SCAN_PIXEL_RES");
                    ScanLineRate  = ReadDouble(SQLiteDB.ReaderDeviceData, "SCAN_LINE_RATE");

                    for (int k = 1; k < 201; k++)
                    {
                        strKey = "DATA" + String.Format("{0:000}", k);
                        dData = Convert.ToDouble(SQLiteDB.ReaderDeviceData[strKey].ToString());
                        DeviceData.Add(dData);
                    }
                }
                SQLiteDB.ReaderDeviceData.Close();
            }
        }    
        public void SaveRcpMaterial()
        {
            string strSQL = " UPDATE DEVICE SET ";
            string strKey = "";

            for (int k = 1; k < 201; k++)
            {
                strKey = "DATA" + String.Format("{0:000}", k);
                strSQL += strKey + " = " + DeviceData[k-1].ToString("F2") + ",";
            }

            strSQL += " DEVICE_NAME = '" + Material_NAME.Trim() + "'  ";    //"',";  //"' ";  
            // strSQL += " CURR_MARK = '  '";
            strSQL += " WHERE IDX= " + Material_IDX.ToString();
            SQLiteDB.Execute(strSQL);
        }
    }
}
