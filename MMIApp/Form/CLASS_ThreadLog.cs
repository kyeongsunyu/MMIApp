using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Diagnostics;

namespace MMI
{
    class CThreadMMILog
    {
        #region SINGLETON
        private static readonly Lazy<CThreadMMILog> instance = new Lazy<CThreadMMILog>(() => new CThreadMMILog());

        public static CThreadMMILog GetInstance
        {
            get { return instance.Value; }
        }

        #endregion SINGLETON
        public void AddMMILog(string msg,
            [CallerFilePath] string fileName = "",
            [CallerMemberName] string funcName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            AddMMILogMsg(fileName, funcName, lineNumber, msg);
        }

        public static void AddMMILogMsg(string strSourceFile, string strFunc, int LineNo, string msg)
        {
            string strBuffer;
            strBuffer = string.Format("{0}, USER = {1}, DEVICE = {2}, [TRACE], Call = {3}, Line = {4}, {5}",
                DateTime.Now.ToString("yyyy_MM_dd, HH:mm:ss:fff"),
                MmiGV.UserInfo.strUserName,
                MmiGV.strCurrentDevName,
                strFunc,
                LineNo,
                msg);

            if (strBuffer.Length > 0)
            {
                MmiGV.MmiLogQueue.Enqueue(strBuffer);
            }
        }

        public void AddMMILogError(int errcode, string msg,
            [CallerFilePath] string fileName = "",
            [CallerMemberName] string funcName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            AddMMIErrorMsg(fileName, funcName, lineNumber, errcode, msg);
        }

        public static void AddMMIErrorMsg(string strSourceFile, string strFunc, int LineNo, int errcode, string msg)
        {
            string strBuffer;
            strBuffer = string.Format("{0}, USER = {1}, DEVICE = {2}, [ERROR], Call = {3}, " +
                                      "Line = {4}, ERROR CODE={5}, {6}",
                DateTime.Now.ToString("yyyy_MM_dd,HH:mm:ss:fff"),
                MmiGV.UserInfo.strUserName,
                MmiGV.strCurrentDevName,
                strFunc,
                LineNo,
                errcode,
                msg);

            if (strBuffer.Length > 0)
            {
                MmiGV.MmiLogQueue.Enqueue(strBuffer);
            }
        }

        public void AddMMILogWarning(int errcode, string msg,
            [CallerFilePath] string fileName = "",
            [CallerMemberName] string funcName = "",
            [CallerLineNumber] int lineNumber = 0)
        {
            AddMMIWarningMsg(fileName, funcName, lineNumber, errcode, msg);
        }

        public static void AddMMIWarningMsg(string strSourceFile, string strFunc, int LineNo, int errcode, string msg)
        {
            string strBuffer;
            strBuffer = string.Format("{0}, USER = {1}, DEVICE = {2}, [WARNING], Call = {3}, " +
                                      "Line = {4}, ERROR CODE={5}, {6}",
                DateTime.Now.ToString("yyyy_MM_dd,HH:mm:ss:fff"),
                MmiGV.UserInfo.strUserName,
                MmiGV.strCurrentDevName,
                strFunc,
                LineNo,
                errcode,
                msg);

            if (strBuffer.Length > 0)
            {
                MmiGV.MmiLogQueue.Enqueue(strBuffer);
            }
        }


        public static string GetMMILog()
        {
            var sRtn = "";
            if (!MmiGV.MmiLogQueue.IsEmpty || MmiGV.MmiLogQueue.Count > 0)
                MmiGV.MmiLogQueue.TryDequeue(out sRtn);
            return sRtn;
        }


        public void AddSEQLog(string msg)
        {
            MmiGV.SeqLogQueue.Enqueue(msg);
        }

        public static string GetSEQLog()
        {
            var sRtn = "";
            if (!MmiGV.SeqLogQueue.IsEmpty || MmiGV.SeqLogQueue.Count > 0)
                MmiGV.SeqLogQueue.TryDequeue(out sRtn);
            return sRtn;
        }

        public void ExcuteMMILogMsg()
        {
            var sMessage = "";

            while (!MmiGV.bProgramExit)
            {
                //-- 큐 카운트가 0이 아니라면, 뭔가 들었다면.
                //-- 메시지를 가져오고 로거에 기록한다.
                if (MmiGV.MmiLogQueue.Count > 0)
                {
                    sMessage = GetMMILog();
                    if (sMessage.Length > 0)
                    {
                        UpdateMMILogMsg(sMessage);
                        CFileLog.Log_Process("MMI",sMessage);
                        //if (sMessage.Contains("[ERROR]") || sMessage.Contains("[WARNING]"))
                        //{
                        //    UpdateMMIErrorLogMsg(sMessage);
                        //    CFileLog.Log_Error("MMI",sMessage);
                        //}
                    }
                }

                if (MmiGV.SeqLogQueue.Count > 0)
                {
                    sMessage = GetSEQLog();
                    if (sMessage.Length > 0)
                    {
                        UpdateSEQLogMsg(sMessage);
                    }
                    if (sMessage.Contains("ERROR") || sMessage.Contains("WARNING"))
                    {
                        UpdateSEQErrorLogMsg(sMessage);
                    }
                }
                Thread.Sleep(10);
            }
            Trace.WriteLine("Log Thread Close..");
        }

        private delegate void delegateUpdateMMI(string str);
        private void UpdateMMILogMsg(string str)
        {
            try
            {
                if (MmiGV.frmMain.frmLog.lvMMI.InvokeRequired)
                {
                    var dgt = new delegateUpdateMMI(UpdateMMILogMsg);
                    MmiGV.frmMain.frmLog.lvMMI.Invoke(dgt, str);
                }
                else
                {
                    MmiGV.frmMain.frmLog.lvMMI.BeginUpdate();

                    if (MmiGV.frmMain.frmLog.lvMMI.Items.Count > 10000)
                    {
                        MmiGV.frmMain.frmLog.lvMMI.Items.RemoveAt(0);
                    }
                    MmiGV.frmMain.frmLog.lvMMI.Items.Insert(0, str);

                    MmiGV.frmMain.frmLog.lvMMI.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                AddMMILog(ex.Message);
            }
        }

        private void UpdateMMIErrorLogMsg(string str)
        {
            try
            {
                if (MmiGV.frmMain.frmLog.lvError.InvokeRequired)
                {
                    var dgt = new delegateUpdateMMI(UpdateMMIErrorLogMsg);
                    MmiGV.frmMain.frmLog.lvError.Invoke(dgt, str);
                }
                else
                {
                    MmiGV.frmMain.frmLog.lvError.BeginUpdate();

                    if (MmiGV.frmMain.frmLog.lvError.Items.Count > 10000)
                    {
                        MmiGV.frmMain.frmLog.lvError.Items.RemoveAt(0);
                    }
                    MmiGV.frmMain.frmLog.lvError.Items.Insert(0, str);

                    MmiGV.frmMain.frmLog.lvError.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                AddMMILog(ex.Message);
            }
        }

        private delegate void delegateUpdateSEQ(string str);
        private void UpdateSEQLogMsg(string str)
        {
            try
            {
                if (MmiGV.frmMain.frmLog.lvSEQ.InvokeRequired)
                {
                    var dgt = new delegateUpdateMMI(UpdateSEQLogMsg);
                    MmiGV.frmMain.frmLog.lvSEQ.Invoke(dgt, str);
                }
                else
                {
                    MmiGV.frmMain.frmLog.lvSEQ.BeginUpdate();

                    if (MmiGV.frmMain.frmLog.lvSEQ.Items.Count > 10000)
                    {
                        MmiGV.frmMain.frmLog.lvSEQ.Items.RemoveAt(0);
                    }
                    MmiGV.frmMain.frmLog.lvSEQ.Items.Insert(0, str);

                    MmiGV.frmMain.frmLog.lvSEQ.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                AddMMILog(ex.Message);
            }
        }

        private void UpdateSEQErrorLogMsg(string str)
        {
            try
            {
                if (MmiGV.frmMain.frmLog.lvError.InvokeRequired)
                {
                    var dgt = new delegateUpdateMMI(UpdateSEQErrorLogMsg);
                    MmiGV.frmMain.frmLog.lvError.Invoke(dgt, str);
                }
                else
                {
                    MmiGV.frmMain.frmLog.lvError.BeginUpdate();

                    if (MmiGV.frmMain.frmLog.lvError.Items.Count > 10000)
                    {
                        MmiGV.frmMain.frmLog.lvError.Items.RemoveAt(0);
                    }
                    MmiGV.frmMain.frmLog.lvError.Items.Insert(0, str);

                    MmiGV.frmMain.frmLog.lvError.EndUpdate();
                }
            }
            catch (Exception ex)
            {
                AddMMILog(ex.Message);
            }
        }


    }
}
