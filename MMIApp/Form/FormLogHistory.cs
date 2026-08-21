using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using C1.Win.C1FlexGrid;

namespace MMI
{
    public partial class FormLogHistory : Form
    {
        private FormMain frmMain = null;
        
        public FormLogHistory()
        {
            InitializeComponent();
        }

        public FormLogHistory(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormLogHistory_Load(object sender, EventArgs e)
        {
            rbErrorOnly.Checked = true;
            rbFullLog.Checked = false;

            rbErrorOnly.CheckedChanged += new System.EventHandler(CheckChanged);
            rbFullLog.CheckedChanged += new System.EventHandler(CheckChanged);

            gdLogHistory.Clear();
            InitGrid();
            DisplayHistory();
        }

        void InitGrid()
        {
            gdLogHistory[0, 0] = "LOG HISTORY";
            gdLogHistory[0, 3] = "DATE & TIME";
            gdLogHistory[1, 0] = "CODE";
            gdLogHistory[1, 1] = "LOG NAME";
            gdLogHistory[1, 2] = "TIME";

            gdLogHistory.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            CellRange rng = gdLogHistory.GetCellRange(0, 0, 0, 2);
            gdLogHistory.MergedRanges.Add(rng);
            
            rng = gdLogHistory.GetCellRange(0, 3, 1, 3);
            gdLogHistory.MergedRanges.Add(rng);

            gdLogHistory.Cols[0].Width = 80;
            gdLogHistory.Cols[1].Width = 540;
            gdLogHistory.Cols[2].Width = 120;
            gdLogHistory.Cols[3].Width = 270;

        }

        void DisplayHistory()
        {
            CUtil util = CUtil.GetInstance;
            Debug.Assert(util != null);

            string sSQL = "";
            uint[] uErr = Enumerable.Repeat<uint>(0, 1000).ToArray<uint>();

            sSQL = "SELECT RCODE, RSTAT, ERROR.ERR_NAME AS NAME, (DTIME) AS DN_TIME , SDATE";
            if(rbErrorOnly.Checked)
            {
                sSQL += " FROM " + frmMain.frmLogMTBA.sDBName + " AS TRACKING  INNER JOIN ERROR ON (TRACKING.RCODE = ERROR.IDX) ";
                sSQL += " WHERE RSTAT = 'ER' AND EMARK IS NULL AND ";
            }
            else if(rbFullLog.Checked)
            {
                sSQL += " FROM " + frmMain.frmLogMTBA.sDBName + " AS TRACKING  INNER JOIN ERROR ON (TRACKING.RCODE = ERROR.IDX) ";
                sSQL += " WHERE EMARK IS NULL AND ";
            }

            sSQL += frmMain.frmLogMTBA.sCompare;
            sSQL += " ORDER BY SDATE DESC";

            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderTracking))
            {
                int idx = 0;
                while (SQLiteDB.ReaderTracking.Read())
                {
                    gdLogHistory.Rows.Count = idx + 3;
                    int iVal = Convert.ToInt32(SQLiteDB.ReaderTracking["RCODE"]);
                    if (iVal > 9000)
                    {
                        gdLogHistory[idx + 2, 0] = "";
                    }
                    else
                    {
                        uErr[iVal]++;
                        gdLogHistory[idx + 2, 0] = iVal;
                    }
                    gdLogHistory[idx + 2, 1] = SQLiteDB.ReaderTracking["NAME"].ToString();
                    long ltime = Convert.ToInt32(SQLiteDB.ReaderTracking["DN_TIME"]);
                    gdLogHistory[idx + 2, 2] = util.GetReadableTimeByMs(ltime);
                    gdLogHistory[idx + 2, 3] = SQLiteDB.ReaderTracking["SDATE"].ToString(); 

                    idx++;
                }
                SQLiteDB.ReaderTracking.Close();
            }
        }

        private void CheckChanged(object sender, EventArgs e)
        {
            InitGrid();
            DisplayHistory();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            string DirPath = @"C:\Work\OUT\";
            DirectoryInfo di = new DirectoryInfo(DirPath);
            if (di.Exists != true)
            {
                Directory.CreateDirectory(DirPath);
            }

            string strFileName = DirPath + 
                frmMain.frmLogMTBA.btnStartDate.Text +"_" + 
                frmMain.frmLogMTBA.btnEndDate.Text+ 
                ".xls";
            gdLogHistory.SaveExcel(strFileName, "History", FileFlags.AsDisplayed | FileFlags.IncludeFixedCells);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
