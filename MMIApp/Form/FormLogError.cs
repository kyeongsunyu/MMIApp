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
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

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

                        getStr = Convert.ToString(gdErrorHistory[nErrorHistoryRowCnt, 0]).Trim() + "," +
                                    Convert.ToString(gdErrorHistory[nErrorHistoryRowCnt, 1]).Trim() + "," +
                                    Convert.ToString(gdErrorHistory[nErrorHistoryRowCnt, 2]).Trim();
                        rowList.Add(getStr);
                        if (rowDic.ContainsKey(getStr) == false)
                        {
                            rowDic.Add(getStr, Convert.ToString(gdErrorHistory[nErrorHistoryRowCnt, 0]).Trim());
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
                    string str = Convert.ToString(gdErrorHistory[i, 0]).Trim() + "," +
                                    Convert.ToString(gdErrorHistory[i, 1]).Trim() + "," +
                                    Convert.ToString(gdErrorHistory[i, 2]).Trim();
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

            gdErrorCount.Sort(SortFlags.Descending, 3);

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
                    //string str = "Code=" + Convert.ToString(gdErrorCount[i, 0]);
                    int ival = int.TryParse(Convert.ToString(gdErrorCount[i, 3]), out ival) ? ival : 0;
                    string str = $"CODE[{Convert.ToString(gdErrorCount[i, 0]).Trim()}]:{ival} ";

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
            string ChartName = DirPath + "chart.png";

            //-- 표는 C1FlexGrid가 직접 쓴다. Excel이 깔려 있을 필요가 없다.
            gdErrorHistory.SaveExcel(FileName, "History", FileFlags.AsDisplayed | FileFlags.IncludeFixedCells);
            gdErrorCount.SaveExcel(FileName, "ErrorCount", FileFlags.AsDisplayed | FileFlags.IncludeFixedCells);

            chart.SaveImage(ChartName, ChartImageFormat.Png);

            //-- 차트 그림을 시트 안에 넣는 것만 Excel이 필요하다. 없는 PC에서는
            //   표와 chart.png는 그대로 남고 삽입만 건너뛴다.
            string strWhy;
            if (!InsertChartIntoWorkbook(FileName, "ErrorCount", ChartName, out strWhy))
            {
                MessageBox.Show(
                    "표는 저장했습니다:\r\n" + FileName +
                    "\r\n\r\n차트는 시트 안에 넣지 못했습니다. 그림 파일로 남아 있습니다:\r\n" + ChartName +
                    "\r\n\r\n" + strWhy,
                    Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Excel을 늦은 바인딩(late binding)으로 부른다.
        //
        // 예전에는 Microsoft.Office.Interop.Excel COM 참조를 걸고 컴파일했다.
        // 그래서 Excel이 등록되지 않은 PC에서는 빌드 자체가 ResolveComReference
        // 에서 깨졌다 - 설비 HMI PC에 Office를 깔아야 빌드가 되는 셈이었고,
        // 실제로 쓰는 것은 아래 그림 한 장을 시트에 붙이는 일뿐이었다.
        //
        // ProgID로 찾아 호출하면 참조가 사라져 어느 PC에서나 빌드되고, Excel이
        // 깔린 PC에서는 전과 똑같이 동작한다. 없으면 false를 돌려주고 호출한
        // 쪽이 그 사실을 화면에 알린다.
        //
        // 로캘도 같이 해결된다. 한국어 Windows에서 Excel을 늦은 바인딩으로
        // 부르면 0x800A03EC로 거절당하는 일이 있어, 호출 문화권을 en-US로
        // 고정한다.
        private static bool InsertChartIntoWorkbook(string strWorkbook, string strSheet,
                                                    string strImage, out string strWhy)
        {
            strWhy = "";

            Type tExcel = Type.GetTypeFromProgID("Excel.Application");
            if (tExcel == null)
            {
                strWhy = "이 PC에 Excel이 설치되어 있지 않습니다.";
                return false;
            }

            object excel = null, books = null, book = null, sheets = null, sheet = null;
            object range = null, pictures = null, picture = null;
            bool bOpened = false;
            try
            {
                excel = Activator.CreateInstance(tExcel);
                Set(excel, "Visible", false);
                Set(excel, "DisplayAlerts", false);

                books = Get(excel, "Workbooks");
                book = Call(books, "Open", strWorkbook);
                bOpened = true;

                sheets = Get(book, "Worksheets");
                sheet = Get(sheets, "Item", strSheet);

                range = Get(sheet, "Range", "F5");
                pictures = Call(sheet, "Pictures", Type.Missing);
                picture = Call(pictures, "Insert", strImage, Type.Missing);

                Set(picture, "Left", Convert.ToDouble(Get(range, "Left")));
                Set(picture, "Top", Convert.ToDouble(Get(range, "Top")));
                Set(picture, "Width", 300.0);
                Set(picture, "Height", 300.0);

                Call(book, "Save");
                return true;
            }
            catch (Exception ex)
            {
                //-- COMException, TargetInvocationException, 파일 잠김 ... 무엇이든
                //   로그 저장을 실패로 끝낼 이유는 안 된다. 표는 이미 저장됐다.
                strWhy = (ex.InnerException != null ? ex.InnerException.Message : ex.Message);
                return false;
            }
            finally
            {
                //-- 닫고 끝내지 않으면 EXCEL.EXE가 보이지 않는 채로 남는다.
                //   예전 코드가 Quit()을 부르지 않아 저장할 때마다 하나씩 쌓였다.
                try { if (bOpened) Call(book, "Close", false); } catch (Exception) { }
                try { if (excel != null) Call(excel, "Quit"); } catch (Exception) { }

                Release(picture); Release(pictures); Release(range);
                Release(sheet); Release(sheets); Release(book);
                Release(books); Release(excel);
            }
        }

        private const BindingFlags GetFlags = BindingFlags.GetProperty | BindingFlags.InvokeMethod;
        private static readonly CultureInfo ExcelCulture = CultureInfo.GetCultureInfo("en-US");

        private static object Get(object o, string strName, params object[] args)
        {
            return o.GetType().InvokeMember(strName, GetFlags, null, o, args, ExcelCulture);
        }

        private static object Call(object o, string strName, params object[] args)
        {
            return o.GetType().InvokeMember(strName, BindingFlags.InvokeMethod, null, o, args, ExcelCulture);
        }

        private static void Set(object o, string strName, object value)
        {
            o.GetType().InvokeMember(strName, BindingFlags.SetProperty, null, o, new object[] { value }, ExcelCulture);
        }

        private static void Release(object o)
        {
            if (o == null || !Marshal.IsComObject(o)) return;
            try { Marshal.ReleaseComObject(o); } catch (Exception) { }
        }

        private void gdErrorCount_Click(object sender, EventArgs e)
        {
            if (gdErrorCount.Row > 0)
            {
                if (gdErrorCount[gdErrorCount.Row, 2] != null)
                {
                    lblErrorName.Text = Convert.ToString(gdErrorCount[gdErrorCount.Row, 2]);
                }
            }
        }
    }
}
