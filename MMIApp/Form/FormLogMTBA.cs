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
    public partial class FormLogMTBA : Form
    {
        private FormMain frmMain = null;
        
        private bool bNewDBSelection = false;
        public string sDBName;
        public string sCompare;
            
        public FormLogMTBA()
        {
            InitializeComponent();
        }

        public FormLogMTBA(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            btnStartDate.Text = DateTime.Now.AddMonths(-6).ToString("yyyy-MM-dd");
            btnEndDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void FormLogMTBA_Load(object sender, EventArgs e)
        {
            InitGrid();
            InitScreen();
        }

        void InitGrid()
        {
            #region gdMTBA
            gdMTBA[0, 0] = "CODE";
            gdMTBA[0, 1] = "MTBA COLLECTION";
            gdMTBA[1, 1] = "ERROR NAME";
            gdMTBA[1, 2] = "COUNT";
            gdMTBA[1, 3] = "TIME(SEC)";

            gdMTBA.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            CellRange rng = gdMTBA.GetCellRange(0, 0, 1, 0);
            gdMTBA.MergedRanges.Add(rng);

            rng = gdMTBA.GetCellRange(0, 1, 0, 3);
            gdMTBA.MergedRanges.Add(rng);

            gdMTBA.Cols[0].Width = 70;
            gdMTBA.Cols[1].Width = 400;
            gdMTBA.Cols[2].Width = 90;
            gdMTBA.Cols[3].Width = 140;
            #endregion gdMTBA

            #region gdMTBF
            gdMTBF[0, 0] = "CODE";
            gdMTBF[0, 1] = "MTBF COLLECTION";
            gdMTBF[1, 1] = "ERROR NAME";
            gdMTBF[1, 2] = "COUNT";
            gdMTBF[1, 3] = "TIME(SEC)";

            gdMTBF.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            rng = gdMTBF.GetCellRange(0, 0, 1, 0);
            gdMTBF.MergedRanges.Add(rng);

            rng = gdMTBF.GetCellRange(0, 1, 0, 3);
            gdMTBF.MergedRanges.Add(rng);

            gdMTBF.Cols[0].Width = 70;
            gdMTBF.Cols[1].Width = 400;
            gdMTBF.Cols[2].Width = 90;
            gdMTBF.Cols[3].Width = 140;
            #endregion gdMTBF

            #region gdRunLog
            gdRunLog[0, 0] = "RUN INFORMATION";
            gdRunLog[1, 0] = "ITEM";
            gdRunLog[1, 1] = "COUNT";
            gdRunLog[1, 2] = "TIME";
            gdRunLog[2, 0] = "RUN";
            gdRunLog[3, 0] = "STOP";
            gdRunLog[4, 0] = "ERROR";
            gdRunLog[5, 0] = "MTBA";
            gdRunLog[6, 0] = "MTTA";
            gdRunLog[7, 0] = "MTBF";
            gdRunLog[8, 0] = "MTTR";

            gdRunLog.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            rng = gdRunLog.GetCellRange(0, 0, 0, 2);
            gdRunLog.MergedRanges.Add(rng);

            gdRunLog.Cols[0].Width = 100;
            gdRunLog.Cols[1].Width = 100;
            gdRunLog.Cols[2].Width = 150;
            #endregion gdRunLog
        }

        void InitScreen()
        {
            CUtil util = CUtil.GetInstance;
            Debug.Assert(util != null);

            long lRunTime = 0, lMTBATime = 0, lMTBFTime = 0;

            string sSQL = "";
            sDBName = "TRACKING";

            rbNewDB.Checked = true;
            rbOldDB.Checked = false;

            if (!bNewDBSelection)
            {
                sDBName = "TRACKOLD";
            }

            for (int i = 0; i < 7; i++)
            {
                gdRunLog[i + 2, 1] = "";
                gdRunLog[i + 2, 2] = "";
            }

            sCompare = " (FORMAT(SDATE, 'YYYYMMDDHHNN') BETWEEN '" +
                        DateTime.Parse(btnStartDate.Text).ToString("yyyyMMdd") +
                        btnStartTime.Text.Substring(0, 2) + btnStartTime.Text.Substring(3, 2) +
                        "' AND '" +
                        DateTime.Parse(btnEndDate.Text).ToString("yyyyMMdd") +
                        btnEndTime.Text.Substring(0, 2) + btnEndTime.Text.Substring(3, 2) +
                        "') ";

            sSQL = "SELECT COUNT(RSTAT) AS TCOUNT, SUM(DTIME) AS TTIME";
            sSQL += " FROM " + sDBName + " AS TRACKING  INNER JOIN ERROR ON (TRACKING.RCODE=ERROR.IDX)";
            sSQL += " WHERE RSTAT IS NOT NULL AND SDATE IS NOT NULL AND EMARK IS NULL AND ";
            sSQL += sCompare;
            sSQL += " AND RSTAT = 'AR'";

            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderTracking))
            {
                SQLiteDB.ReaderTracking.Read();
                //lRunTime = Convert.ToInt32(SQLiteDB.ReaderTracking["TTIME"]);
                gdRunLog[2, 1] = Convert.ToInt32(SQLiteDB.ReaderTracking["TCOUNT"]);
                gdRunLog[2, 2] = util.GetReadableTimeByMs(lRunTime);
            }
            SQLiteDB.ReaderTracking.Close();

            sSQL = "SELECT COUNT(RSTAT) AS TCOUNT, SUM(DTIME) AS TTIME";
            sSQL += " FROM " + sDBName + " AS TRACKING  INNER JOIN ERROR ON (TRACKING.RCODE=ERROR.IDX)";
            sSQL += " WHERE RSTAT IS NOT NULL AND SDATE IS NOT NULL AND EMARK IS NULL AND ";
            sSQL += sCompare;
            sSQL += " AND RSTAT = 'ST' OR (RSTAT = 'ER' AND ERROR.MTBA = FALSE) OR (RCODE = 0 AND RSTAT = 'ER')";
            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderTracking))
            {
                SQLiteDB.ReaderTracking.Read();
                gdRunLog[3, 1] = SQLiteDB.ReaderTracking["TCOUNT"];// Convert.ToInt32(SQLiteDB.ReaderTracking["TCOUNT"]);
                long ltime = long.TryParse(SQLiteDB.ReaderTracking["TTIME"].ToString(), out ltime) ? ltime : 0;// Convert.ToInt32(SQLiteDB.ReaderTracking["TTIME"]);
                gdRunLog[3, 2] = util.GetReadableTimeByMs(ltime);
            }
            SQLiteDB.ReaderTracking.Close();

            sSQL = "SELECT COUNT(RSTAT) AS TCOUNT, SUM(DTIME) AS TTIME";
            sSQL += " FROM " + sDBName + " AS TRACKING  INNER JOIN ERROR ON (TRACKING.RCODE=ERROR.IDX)";
            sSQL += " WHERE RSTAT IS NOT NULL AND SDATE IS NOT NULL AND EMARK IS NULL AND ";
            sSQL += sCompare;
            sSQL += " AND RSTAT = 'ER' AND ERROR.MTBA = TRUE";
            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderTracking))
            {
                SQLiteDB.ReaderTracking.Read();
                gdRunLog[4, 1] = Convert.ToInt32(SQLiteDB.ReaderTracking["TCOUNT"]);
                long ltime = long.TryParse(SQLiteDB.ReaderTracking["TTIME"].ToString(), out ltime) ? ltime : 0;// Convert.ToInt32(SQLiteDB.ReaderTracking["TTIME"]);
                gdRunLog[4, 2] = util.GetReadableTimeByMs(ltime);
            }
            SQLiteDB.ReaderTracking.Close();

            sSQL = "SELECT COUNT(RSTAT) AS TCOUNT, SUM(DTIME) AS TTIME";
            sSQL += " FROM " + sDBName + " AS TRACKING  INNER JOIN ERROR ON (TRACKING.RCODE=ERROR.IDX)";
            sSQL += " WHERE RSTAT = 'ER' AND (DTIME/1000.0) < 30000 AND ";
            sSQL += " RCODE IS NOT NULL AND DTIME IS NOT NULL AND EMARK IS NULL AND ";
            sSQL += sCompare;
            sSQL += " AND ERROR.MTBA = TRUE";
            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderTracking))
            {
                SQLiteDB.ReaderTracking.Read();
                int iCount = Convert.ToInt32(SQLiteDB.ReaderTracking["TCOUNT"]);
                gdRunLog[5, 1] = iCount;
                gdRunLog[6, 1] = iCount;
                lMTBATime = ((iCount == 0) ? 0 : lRunTime / iCount);
                gdRunLog[5, 2] = util.GetReadableTimeByMs(lMTBATime);
                lMTBATime = ((iCount == 0) ? 0 : lMTBATime / iCount);
                gdRunLog[6, 2] = util.GetReadableTimeByMs(lMTBATime);
            }
            SQLiteDB.ReaderTracking.Close();

            sSQL = "SELECT COUNT(RSTAT) AS TCOUNT, SUM(DTIME) AS TTIME";
            sSQL += " FROM " + sDBName + " AS TRACKING  INNER JOIN ERROR ON (TRACKING.RCODE=ERROR.IDX)";
            sSQL += " WHERE RSTAT = 'ER' AND (DTIME/1000.0) >= 30000 AND ";
            sSQL += " RCODE IS NOT NULL AND DTIME IS NOT NULL  AND EMARK IS NULL AND ";
            sSQL += sCompare;
            sSQL += " AND ERROR.MTBA = TRUE";

            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderTracking))
            {
                SQLiteDB.ReaderTracking.Read();
                int iCount = Convert.ToInt32(SQLiteDB.ReaderTracking["TCOUNT"]);
                gdRunLog[7, 1] = iCount;
                gdRunLog[8, 1] = iCount;
                lMTBFTime = ((iCount == 0) ? 0 : lRunTime / iCount);
                gdRunLog[7, 2] = util.GetReadableTimeByMs(lMTBFTime);
                lMTBFTime = ((iCount == 0) ? 0 : lMTBATime / iCount);
                gdRunLog[8, 2] = util.GetReadableTimeByMs(lMTBFTime);
            }
            SQLiteDB.ReaderTracking.Close();

            sSQL = "SELECT RCODE, ERROR.ERR_NAME AS NAME, COUNT(RCODE) AS TCOUNT, SUM(DTIME) AS TTIME";
            sSQL += " FROM " + sDBName + " AS TRACKING  INNER JOIN ERROR ON (TRACKING.RCODE=ERROR.IDX)";
            sSQL += " WHERE RSTAT = 'ER' AND (DTIME/1000.0) < 30000 AND ";
            sSQL += " RCODE IS NOT NULL AND DTIME IS NOT NULL AND EMARK IS NULL AND ";
            sSQL += sCompare + " AND ERROR.MTBA = TRUE";
            sSQL += " GROUP BY RCODE, ERROR.IDX, ERROR.ERR_NAME ORDER BY RCODE";

            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderTracking))
            {
                int idx = 0;
                while (SQLiteDB.ReaderTracking.Read())
                {
                    gdMTBA.Rows.Count = idx + 3;

                    gdMTBA[idx + 2, 0] = SQLiteDB.ReaderTracking["RCODE"].ToString();
                    gdMTBA[idx + 2, 1] = SQLiteDB.ReaderTracking["NAME"].ToString();
                    gdMTBA[idx + 2, 2] = SQLiteDB.ReaderTracking["TCOUNT"].ToString();
                    long ltime = Convert.ToInt32(SQLiteDB.ReaderTracking["TTIME"]);
                    gdMTBA[idx + 2, 3] = util.GetReadableTimeByMs(ltime);

                    idx++;
                }
            }
            SQLiteDB.ReaderTracking.Close();

            sSQL = "SELECT RCODE, ERROR.ERR_NAME AS NAME, COUNT(RCODE) AS TCOUNT, SUM(DTIME) AS TTIME";
            sSQL += " FROM " + sDBName + " AS TRACKING INNER JOIN ERROR ON (TRACKING.RCODE=ERROR.IDX)";
            sSQL += " WHERE RSTAT = 'ER' AND (DTIME/1000.0) >= 30000 AND ";
            sSQL += " RCODE IS NOT NULL AND DTIME IS NOT NULL AND EMARK IS NULL AND ";
            sSQL += sCompare + " AND ERROR.MTBA = TRUE";
            sSQL += " GROUP BY RCODE, ERROR.IDX, ERROR.ERR_NAME ORDER BY RCODE";
            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderTracking))
            {
                int idx = 0;
                while (SQLiteDB.ReaderTracking.Read())
                {
                    gdMTBF.Rows.Count = idx + 3;

                    gdMTBF[idx + 2, 0] = SQLiteDB.ReaderTracking["RCODE"].ToString();
                    gdMTBF[idx + 2, 1] = SQLiteDB.ReaderTracking["NAME"].ToString();
                    gdMTBF[idx + 2, 2] = SQLiteDB.ReaderTracking["TCOUNT"].ToString();
                    long ltime = Convert.ToInt32(SQLiteDB.ReaderTracking["TTIME"]);
                    gdMTBF[idx + 2, 3] = util.GetReadableTimeByMs(ltime);

                    idx++;
                }
            }
            SQLiteDB.ReaderTracking.Close();
        }

        private void btnStartDate_Click(object sender, EventArgs e)
        {
            Form_Calendar frmCalendar = new Form_Calendar();

            btnStartDate.Text = frmCalendar.SHOW();
        }

        private void btnEndDate_Click(object sender, EventArgs e)
        {
            Form_Calendar frmCalendar = new Form_Calendar();

            btnEndDate.Text = frmCalendar.SHOW();
        }

        private void btnStartTime_Click(object sender, EventArgs e)
        {
            Form_TimeInput frmTimeInput = new Form_TimeInput();
            btnStartTime.Text = frmTimeInput.SHOW();
        }

        private void btnEndTime_Click(object sender, EventArgs e)
        {
            Form_TimeInput frmTimeInput = new Form_TimeInput();
            btnEndTime.Text = frmTimeInput.SHOW();
        }

        private void rbNewDB_Click(object sender, EventArgs e)
        {
            bNewDBSelection = true;
            InitScreen();
        }

        private void rbOldDB_Click(object sender, EventArgs e)
        {
            bNewDBSelection = false;
            InitScreen();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            string DirPath = @"C:\Work\OUT\";
            DirectoryInfo di = new DirectoryInfo(DirPath);
            if (di.Exists != true)
            {
                Directory.CreateDirectory(DirPath);
            }

            string strFileName = DirPath + DateTime.Now.ToString("yyyy_MM_dd_HH_ss")+".xls";
             
            gdMTBA.SaveExcel(strFileName, "MTBA", FileFlags.AsDisplayed | FileFlags.IncludeFixedCells);
            gdMTBF.SaveExcel(strFileName, "MTBF", FileFlags.AsDisplayed | FileFlags.IncludeFixedCells);
        }

        private void btnCLEAR_Click(object sender, EventArgs e)
        {
            if(frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
            {
                string sSQL = "";
                sSQL = "DELETE FROM " + sDBName;
                sSQL += " WHERE DTIME IS NULL OR ";
                sSQL += sCompare;

                SQLiteDB.Execute(sSQL);
            }
        }

        private void btnREFRESH_Click(object sender, EventArgs e)
        {
            InitScreen();
        }

        private void btnLogHistory_Click(object sender, EventArgs e)
        {
            frmMain.frmLogHistory.ShowDialog();
        }
    }
}
