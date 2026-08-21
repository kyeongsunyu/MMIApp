using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.Contracts;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MMI
{
    class CFileLog
    {
        #region SINGLETON
        private static readonly Lazy<CFileLog> instance = new Lazy<CFileLog>(() => new CFileLog());

        public static CFileLog GetInstance
        {
            get { return instance.Value; }
        }
        #endregion SINGLETON

        public int __LINE__([CallerLineNumber] int lineNumber = 0)
        {
            return lineNumber;  //-- 호출자의 라인번호
        }

        public string __FILE__([CallerFilePath] string fileName = "")
        {
            return fileName;    //-- 호출자의 화일명
        }

        public string __FUNC__([CallerMemberName] string funcName = "")
        {
            return funcName;    //-- 호출자의 함수명
        }

        public void LOG_TRACE(string strMsg)
        {
            LOG_MSG( __FILE__(), __FUNC__(), __LINE__(), strMsg);
        }
        public void LOG_ERROR(int ErrCode, string strMsg)
        {
            LOG_MSG_ERROR( __FILE__(), __FUNC__(), __LINE__(), ErrCode, strMsg);
        }

        /// Process Log
        public void LOG_MSG(string strSourceFile, string strFunc, int LineNo, string msg)
        {
            string FilePath = Directory.GetCurrentDirectory() + @"\LOG\Process\" + DateTime.Today.ToString("yyyy_MM_dd") + ".txt";
            string DirPath = Directory.GetCurrentDirectory() + @"\LOG\Process";
            string strBuffer;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);
            try
            {
                if (di.Exists != true) Directory.CreateDirectory(DirPath);
                if (fi.Exists != true)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        strBuffer = string.Format("{0}, USER = {1}, DEVICE = {2}, {3}",
                            DateTime.Now.ToString("HH:mm:ss"),
                            MmiGV.UserInfo.strUserName, MmiGV.strCurrentDevName,
                            msg);

                        sw.WriteLine(strBuffer);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        strBuffer = string.Format("{0}, USER = {1}, DEVICE = {2}, {3}",
                           DateTime.Now.ToString("HH:mm:ss"),
                           MmiGV.UserInfo.strUserName, MmiGV.strCurrentDevName,
                           msg);

                        sw.WriteLine(strBuffer);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }

        public void LOG_MSG_ERROR(string strSourceFile, string strFunc, int LineNo, int ErrCode, string msg)
        {
            string FilePath = Directory.GetCurrentDirectory() + @"\LOG\Error\" + DateTime.Today.ToString("yyyy_MM_dd") + ".txt";
            string DirPath = Directory.GetCurrentDirectory() + @"\LOG\Error";
            string strBuffer;

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);
            try
            {
                if (di.Exists != true) Directory.CreateDirectory(DirPath);
                if (fi.Exists != true)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        strBuffer = string.Format("{0}, USER = {1}, DEVICE = {2}, CODE={3}, {4}",
                            DateTime.Now.ToString("HH:mm:ss"),
                            MmiGV.UserInfo.strUserName, MmiGV.strCurrentDevName,
                            ErrCode,
                            msg);

                        sw.WriteLine(strBuffer);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        strBuffer = string.Format("{0}, USER = {1}, DEVICE = {2}, CODE={3}, {4}",
                            DateTime.Now.ToString("HH:mm:ss"),
                            MmiGV.UserInfo.strUserName, MmiGV.strCurrentDevName,
                            ErrCode,
                            msg);

                        sw.WriteLine(strBuffer);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }

        }


        public static void Log_Process(string target, string msg)
        {
            string FilePath="";
            string DirPath="";
            if (target == "SEQ")
            {
                //FilePath = Directory.GetCurrentDirectory() + @"\LOG\SEQ\PROCESS\" +
                //                  DateTime.Today.ToString("yyyy_MM_dd") + @"\" +
                //                  SeqGV.DeviceInfo.strDeviceName + @"\" +
                //                  DateTime.Today.ToString("yyyy_MM_dd") + ".txt";
                //DirPath = Directory.GetCurrentDirectory() + @"\LOG\SEQ\PROCESS\" +
                //                 DateTime.Today.ToString("yyyy_MM_dd") + @"\" +
                //                 SeqGV.DeviceInfo.strDeviceName;
                //deleteFolder(@"\LOG\SEQ\PROCESS\");
            }
            else if (target == "MMI")
            {
                FilePath = Directory.GetCurrentDirectory() + @"\LOG\MMI\PROCESS\" +
                           DateTime.Today.ToString("yyyy_MM_dd") + @"\" +
                           MmiGV.DeviceInfo.strDeviceName + @"\" +
                           DateTime.Today.ToString("yyyy_MM_dd") + ".txt";
                DirPath = Directory.GetCurrentDirectory() + @"\LOG\MMI\PROCESS\" +
                          DateTime.Today.ToString("yyyy_MM_dd") + @"\" +
                          MmiGV.DeviceInfo.strDeviceName;
                deleteFolder(@"\LOG\MMI\PROCESS\");
            }

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            try
            {
                if (di.Exists != true) Directory.CreateDirectory(DirPath);
                if (fi.Exists != true)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        sw.WriteLine(msg);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        sw.WriteLine(msg);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        public static void Log_Error(string target, string msg)
        {
            string FilePath = "";
            string DirPath = "";
            if (target == "SEQ")
            {
                //FilePath = Directory.GetCurrentDirectory() + @"\LOG\SEQ\PROCESS\" +
                //           DateTime.Today.ToString("yyyy_MM_dd") + @"\" +
                //           SeqGV.DeviceInfo.strDeviceName + @"\" +
                //           DateTime.Today.ToString("yyyy_MM_dd") + ".txt";
                //DirPath = Directory.GetCurrentDirectory() + @"\LOG\SEQ\PROCESS\" +
                //          DateTime.Today.ToString("yyyy_MM_dd") + @"\" +
                //          SeqGV.DeviceInfo.strDeviceName;
            }
            else if (target == "MMI")
            {
                FilePath = Directory.GetCurrentDirectory() + @"\LOG\MMI\PROCESS\" +
                           DateTime.Today.ToString("yyyy_MM_dd") + @"\" +
                           MmiGV.DeviceInfo.strDeviceName + @"\" +
                           DateTime.Today.ToString("yyyy_MM_dd") + ".txt";
                DirPath = Directory.GetCurrentDirectory() + @"\LOG\MMI\PROCESS\" +
                          DateTime.Today.ToString("yyyy_MM_dd") + @"\" +
                          MmiGV.DeviceInfo.strDeviceName;
            }

            DirectoryInfo di = new DirectoryInfo(DirPath);
            FileInfo fi = new FileInfo(FilePath);

            try
            {
                if (di.Exists != true) Directory.CreateDirectory(DirPath);
                if (fi.Exists != true)
                {
                    using (StreamWriter sw = new StreamWriter(FilePath))
                    {
                        sw.WriteLine(msg);
                        sw.Close();
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(FilePath))
                    {
                        sw.WriteLine(msg);
                        sw.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }

        public static void deleteFolder(string folderDir)
        {
            try
            {
                int deleteDay = 60;
                DirectoryInfo di = new DirectoryInfo(folderDir);
                if (di.Exists)
                {
                    DirectoryInfo[] dirInfo = di.GetDirectories();
                    string IDate = DateTime.Today.AddDays(- deleteDay).ToString("yyyyMMdd");

                    foreach (DirectoryInfo dir in dirInfo)
                    {
                        if (IDate.CompareTo(dir.LastWriteTime.ToString("yyyMMdd")) > 0)
                        {
                            // 폴더 속성에 읽기, 쓰기 설정에 따라 삭제가 안될 수 있음
                            // 때문에 미리 속성 Normal 로 설정
                            dir.Attributes = FileAttributes.Normal;
                            dir.Delete(true);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
        }

        public static void DelFile(string delPath)
        {
            int deleteDay = 60;
            DateTime fileCreatedTime;
            string strDate = DateTime.Now.AddDays(-deleteDay).ToString("yyyyMMdd");

            DateTime cmpTime = DateTime.ParseExact(strDate, "yyyyMMdd", null);
            DirectoryInfo dirInfo = new DirectoryInfo(delPath);
            foreach (FileInfo file in dirInfo.GetFiles())
            {
                fileCreatedTime = file.CreationTime;

                //파일생성날짜가 strDate보다 이전이면 파일을 삭제한다. 예제에서는 7일전이면 삭제
                if (DateTime.Compare(fileCreatedTime, cmpTime) > 0)
                {
                    File.Delete(file.FullName);
                }
            }
        }

        //파일 복사 함수 
        public static bool FileCopy(string strOriginFile, string strCopyFile)
        {
            FileInfo fi = new FileInfo(strOriginFile);
            long iSize = 0;
            long iTotalSize = fi.Length;
            //1024 버퍼 사이즈 임의로... 
            byte[] bBuf = new byte[1024];
            //동일 파일이 존재하면 삭제 하고 다시하기 위해... 
            if (File.Exists(strCopyFile))
            {
                File.Delete(strCopyFile);
            }
            //원본 파일 열기... 
            FileStream fsIn = new FileStream(strOriginFile, FileMode.Open, FileAccess.Read, FileShare.Read);
            //대상 파일 만들기... 
            FileStream fsOut = new FileStream(strCopyFile, FileMode.Create, FileAccess.Write);
            while (iSize < iTotalSize)
            {
                try
                {
                    int iLen = fsIn.Read(bBuf, 0, bBuf.Length);
                    iSize += iLen; fsOut.Write(bBuf, 0, iLen);
                }
                catch (Exception ex)
                {
                    //파일 연결 해제... 
                    fsOut.Flush(); fsOut.Close(); fsIn.Close();
                    //에러시 삭제... 
                    if (File.Exists(strCopyFile))
                    {
                        File.Delete(strCopyFile);
                    }
                    Debug.WriteLine(ex.ToString());
                    return false;
                }
            }
            //파일 연결 해제... 
            fsOut.Flush();
            fsOut.Close();
            fsIn.Close();
            return true;
        }

        public static bool ReadFileLine(string filename, ref string[] lines)
        {
            string[] readlines = null;
            try
            {
                if (File.Exists(filename.Trim()))
                {
                    readlines = File.ReadAllLines(filename.Trim());
                }
                lines = readlines;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            //finally
            //{
            //    Console.WriteLine("Executing finally block.");
            //}

            return lines != null;
        }
    }
}
