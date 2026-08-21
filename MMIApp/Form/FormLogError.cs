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
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;

using C1.Win.C1FlexGrid;
namespace MMI
{
    public partial class FormLogError : Form
    {
        private FormMain frmMain = null;

        DateTime StartDate;
        DateTime EndDate;

        List<String> rowList = new List<string>();
        Dictionary<String, String> rowDic = new Dictionary<string, string>();

        int nErrorHistoryRowCnt;

        public FormLogError()
        {
            InitializeComponent();
        }

        public FormLogError(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormLogError_Load(object sender, EventArgs e)
        {
            CalendarStart.Value = DateTime.Now.AddDays(-1);
            CalendaEnd.Value = DateTime.Now;
        }

        void InitGridErrorHistory()
        {
            gdErrorHistory[0, 0] = "CODE";
            gdErrorHistory[0, 1] = "DEVICE NAME";
            gdErrorHistory[0, 2] = "ERROR NAME";
            gdErrorHistory[0, 3] = "DATE";
            gdErrorHistory[0, 4] = "TIME";

            gdErrorHistory.Cols[0].Width = 100;
            gdErrorHistory.Cols[1].Width = 150;
            gdErrorHistory.Cols[2].Width = 1100;
            gdErrorHistory.Cols[3].Width = 200;
            gdErrorHistory.Cols[4].Width = 150;

            gdErrorHistory.Cols[0].TextAlign = TextAlignEnum.CenterCenter;

            gdErrorHistory.Cols[0].AllowResizing = true;
            gdErrorHistory.Cols[1].AllowResizing = true;
            gdErrorHistory.Cols[2].AllowResizing = true;
            gdErrorHistory.Cols[3].AllowResizing = true;
            gdErrorHistory.Cols[4].AllowResizing = true;

        }
        void InitGridErrorCount()
        {
            gdErrorCount[0, 0] = "CODE";
            gdErrorCount[0, 1] = "DEVICE NAME";
            gdErrorCount[0, 2] = "ERROR NAME";
            gdErrorCount[0, 3] = "COUNT";

            gdErrorCount.Cols[0].Width = 100;
            gdErrorCount.Cols[1].Width = 150;
            gdErrorCount.Cols[2].Width = 800;
            gdErrorCount.Cols[3].Width = 200;

            gdErrorCount.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            gdErrorCount.Cols[3].TextAlign = TextAlignEnum.CenterCenter;

            gdErrorCount.Cols[0].AllowResizing = true;
            gdErrorCount.Cols[1].AllowResizing = true;
            gdErrorCount.Cols[2].AllowResizing = true;
            gdErrorCount.Cols[3].AllowResizing = true;
        }
        private void CalendarStart_ValueChanged(object sender, EventArgs e)
        {
            StartDate = CalendarStart.Value;
        }

        private void CalendaEnd_ValueChanged(object sender, EventArgs e)
        {
            EndDate = CalendaEnd.Value;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            gdErrorHistory.Clear();
            InitGridErrorHistory();

            gdErrorHistory.Rows.Count = 2;
            nErrorHistoryRowCnt = 1;

            rowList.Clear();
            rowDic.Clear();

            if (StartDate > EndDate)
            {
                DateTime tmpDate;
                tmpDate = StartDate;
                StartDate = EndDate;
                EndDate = tmpDate;
            }

            String strDir = "C:\\Work\\LOG\\SEQ\\";
            FindLogFile(strDir);

            InitGridErrorCount();
            GetErrorCount();
            DrawChart();
        }

        void FindLogFile(String dir)
        {
            WIN32Helper.Win32FindData FindFileData;
            IntPtr hFind;
            String strDir1;
            String strDir2;

            strDir1 = dir + "*";

            hFind = WIN32Helper.FindFirstFile(strDir1, out FindFileData);
            if (hFind != null)
            {
                do
                {
                    if ((FindFileData.cFileName != ".") && (FindFileData.cFileName != ".."))
                    {
                        if (FindFileData.dwFileAttributes.HasFlag(FileAttributes.ReadOnly))
                        {
                            File.SetAttributes(FindFileData.cFileName, FindFileData.dwFileAttributes & ~FileAttributes.ReadOnly);
                        }
                        if (FindFileData.dwFileAttributes.HasFlag(FileAttributes.Directory))
                        {
                            strDir2 = dir + FindFileData.cFileName + "\\";
                            //Console.WriteLine($"strDir2={strDir2}");
                            FindLogFile(strDir2);
                        }
                        else
                        {
                            if (strDir1.Contains("ERROR"))
                            {
                                string strName = FindFileData.cFileName;
                                string strFileDate = Path.GetFileNameWithoutExtension(FindFileData.cFileName);
                                if (strFileDate.Length > 0)
                                {
                                    string[] strDate = strFileDate.Split('_');
                                    DateTime dtFile = Convert.ToDateTime(strDate[0] + "-" + strDate[1] + "-" + strDate[2]);
                                    TimeSpan nDay1 = StartDate - dtFile;
                                    TimeSpan nDay2 = EndDate - dtFile;
                                    if (nDay1.Days <= 0 && nDay2.Days >= 0)
                                    {
                                        string strReadFile = dir + strName;
                                        //    Console.WriteLine($"strReadFile = {strReadFile}");
                                        ReadFile(strReadFile);

                                    }
                                }

                            }
                        }
                    }
                }
                while (WIN32Helper.FindNextFile(hFind, out FindFileData));
                WIN32Helper.FindClose(hFind);
            }
        }
        void ReadFile(string filename)
        {
            CFileLog FileLog = CFileLog.GetInstance;
            Debug.Assert(FileLog != null);

            string getStr;
            string[] ReadLineData = null;
            if (CFileLog.ReadFileLine(filename,ref ReadLineData ))
            {
                foreach(string str in ReadLineData)
                {
                    if (!str.Contains("RESET"))
                    {
                        string[] strSplit = str.Split(',');
                        string[] subSplit1 = strSplit[7].Split('=');
                        gdErrorHistory[nErrorHistoryRowCnt, 0] = subSplit1[1];// Code;
                        string[] subSplit2 = strSplit[3].Split('=');
                        gdErrorHistory[nErrorHistoryRowCnt, 1] = subSplit2[1]; // Device Name;
                        gdErrorHistory[nErrorHistoryRowCnt, 2] = strSplit[9]; // Error Name;
                        gdErrorHistory[nErrorHistoryRowCnt, 3] = strSplit[0]; // Date;
                        gdErrorHistory[nErrorHistoryRowCnt, 4] = strSplit[1]; // Time;

                        getStr = gdErrorHistory[nErrorHistoryRowCnt, 0].ToString().Trim() + "," +
                                    gdErrorHistory[nErrorHistoryRowCnt, 1].ToString().Trim() + "," +
                                    gdErrorHistory[nErrorHistoryRowCnt, 2].ToString().Trim();
                        rowList.Add(getStr);
                        if (rowDic.ContainsKey(getStr) == false)
                        {
                            rowDic.Add(getStr, gdErrorHistory[nErrorHistoryRowCnt, 0].ToString().Trim());
                        }
                        nErrorHistoryRowCnt++;
                        gdErrorHistory.Rows.Count = nErrorHistoryRowCnt + 1;
                    }
                }
            }
        }

        void GetErrorCount()
        {
            gdErrorCount.Rows.Count = rowDic.Count + 1;

            int gdRow = 1;
            int errCount = 0;

            foreach (KeyValuePair<string, string> item in rowDic)
            {
                for(int i = 1; i< gdErrorHistory.Rows.Count-1; i++)
                {
                    string str = gdErrorHistory[i, 0].ToString().Trim() + "," +
                                    gdErrorHistory[i, 1].ToString().Trim() + "," +
                                    gdErrorHistory[i, 2].ToString().Trim();
                    if (item.Key == str)
                    {
                        errCount++;
                        gdErrorCount[gdRow, 0] = gdErrorHistory[i, 0];
                        gdErrorCount[gdRow, 1] = gdErrorHistory[i, 1];
                        gdErrorCount[gdRow, 2] = gdErrorHistory[i, 2];
                        //Console.WriteLine($"{gdErrorHistory[i, 2]}");
                        gdErrorCount[gdRow, 3] = errCount;

                    }
                }
                errCount = 0;
                gdRow++;
            }

            gdErrorCount.Sort(C1.Win.C1FlexGrid.SortFlags.Descending, 3);

        }

        void DrawChart()
        {
            //reset your chart series and legends
            chart.Series.Clear();
            chart.Legends.Clear();

            //Add a new Legend(if needed) and do some formating
            chart.Legends.Add("Legend");
            chart.Legends[0].LegendStyle = LegendStyle.Table;
            chart.Legends[0].Docking = Docking.Bottom;
            chart.Legends[0].Alignment = StringAlignment.Center;
            chart.Legends[0].Title = "Top5 Error";
            chart.Legends[0].BorderColor = Color.Black;

            //Add a new chart-series
            string seriesname = "SeriesName";
            chart.Series.Add(seriesname);
            //set the chart-type to "Pie"
            chart.Series[seriesname].ChartType = SeriesChartType.Pie;
            //Add some datapoints so the series. in this case you can pass the values to this method
            for (int i = 1; i <= 5; i++)
            {
                if ((gdErrorCount.Rows.Count > 1) && (gdErrorCount[i, 0] != null))
                {
                    //string str = "Code=" + gdErrorCount[i, 0].ToString();
                    int ival = int.TryParse(gdErrorCount[i, 3].ToString(), out ival) ? ival : 0;
                    string str = $"CODE[{gdErrorCount[i, 0].ToString().Trim()}]:{ival} ";

                    chart.Series[seriesname].Points.AddXY(str, ival);
                }
            }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            string DirPath = "C:\\Work\\LOG\\MMI\\Excel\\";
            DirectoryInfo di = new DirectoryInfo(DirPath);
            if (di.Exists != true)
            {
                Directory.CreateDirectory(DirPath);
            }
            string FileName = DirPath + DateTime.Today.ToString("yyyy_MM_dd") + "_Error.XLS";

            gdErrorHistory.SaveExcel(FileName, "History", FileFlags.AsDisplayed | FileFlags.IncludeFixedCells);
            gdErrorCount.SaveExcel(FileName, "ErrorCount", FileFlags.AsDisplayed | FileFlags.IncludeFixedCells);


            chart.SaveImage(@"C:\Work\LOG\MMI\Excel\chart.png", ChartImageFormat.Png);

            // Excel 파일 열기
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Open(FileName);

            // Worksheet 선택
            Excel.Worksheet worksheet = workbook.Worksheets["ErrorCount"];

            // 이미지 삽입
            //Bitmap image = new Bitmap(@"C:\Work\LOG\MMI\Excel\image.jpg");
            Excel.Range range = worksheet.Range["F5"];
            Excel.Pictures pictures = worksheet.Pictures(Type.Missing) as Excel.Pictures;
            Excel.Picture picture = pictures.Insert(@"C:\Work\LOG\MMI\Excel\chart.png", Type.Missing);
            picture.Left = (double)range.Left;
            picture.Top = (double)range.Top;
            picture.Width = 300;// (double)range.Width;
            picture.Height = 300;// (double)range.Height;

            // Excel 파일 저장하고 닫기
            workbook.Save();
            workbook.Close();
             
        }

        private void gdErrorCount_Click(object sender, EventArgs e)
        {
            if (gdErrorCount.Row > 0)
            {
                if (gdErrorCount[gdErrorCount.Row, 2] != null)
                {
                    lblErrorName.Text = gdErrorCount[gdErrorCount.Row, 2].ToString();
                }
            }
        }
    }
}
