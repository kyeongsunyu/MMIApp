using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace MMI
{
 
    public class SQLiteDB
    {
        //-- Transaction은 기록 전용 : 큐에 다수의 SQL들을 AddTransaction()으로 등록한 후 RunTransaction()으로 실행.
        private static readonly ConcurrentQueue<string> TransactionQueue = new ConcurrentQueue<string>();

        //--
        //public static string strConReadWrite =
        //    $@"Data Source='d:\exe\JetDb.db';Mode=ReadWriteCreate;Cache=private";
        public static string strConReadWrite =
        $@"Data Source='{System.Windows.Forms.Application.StartupPath}\DB\JetDB.db';Mode=ReadWriteCreate;Cache=private";

        public static bool IsConnection;

        public static SQLiteConnection SQLConnection;

        #region SQLITE_DATA_READER
        public static SQLiteDataReader ReaderTENKEYSEC = null;
        public static SQLiteDataReader ReaderTENKEY = null;

        public static SQLiteDataReader ReaderMotorCFG = null;
        public static SQLiteDataReader ReaderMotor = null;
        public static SQLiteDataReader ReaderMachineParam = null;
        public static SQLiteDataReader ReaderDeviceData = null;
        public static SQLiteDataReader ReaderOption = null;
        public static SQLiteDataReader ReaderLampBuzzer = null;
        public static SQLiteDataReader ReaderPassword = null;
        public static SQLiteDataReader ReaderPasswordLevel = null;
        public static SQLiteDataReader ReaderIO = null;
        public static SQLiteDataReader ReaderBit = null;
        public static SQLiteDataReader ReaderDM = null;
        public static SQLiteDataReader ReaderAlarm = null;
        public static SQLiteDataReader ReaderUseSkip = null;
        public static SQLiteDataReader ReaderTracking = null;
        #endregion 

        ~SQLiteDB()
        {
            Close();
        }
        public static bool Open()
        {
            try
            {
                if (SQLConnection == null || SQLConnection.State != ConnectionState.Open)
                {
                    SQLConnection = new SQLiteConnection(strConReadWrite);
                    SQLConnection.Open();
                    IsConnection = SQLConnection.State == ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                //    MmiGV.AddMessage(ex.Message);
                ex.Message.ToString();
            }

            return IsConnection;
        }

        //-- MDB Disconnection
        public static void Close()
        {
            try
            {
                if (SQLConnection == null) return;
                if (SQLConnection.State == ConnectionState.Open) SQLConnection.Dispose();
            }
            catch (Exception ex)
            {
                //    MmiGV.AddMessage(ex.Message);
                ex.Message.ToString();
            }
        }
        //-- SQL Record Count
        public static int RecCount(string strQuery)
        {
            var nRecCount = -1;
            try
            {
                if (SQLConnection.State == ConnectionState.Open)
                {
                    var sSqlCommand = strQuery.Trim();//.ToUpper();
                    if (strQuery.Contains(";") == false) sSqlCommand = $"{sSqlCommand};";
                    //
                    var cmd = new SQLiteCommand(sSqlCommand, SQLConnection);
                    // ExecuteScalar
                    nRecCount = Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.Dispose();
                }
            }
            catch (Exception ex)
            {
                //    MmiGV.AddMessage(ex.Message);
                ex.Message.ToString();
            }

            return nRecCount;
        }

        //-- SQL (Select 결과를 반환해야 하는 경우)
        public static bool Select(string strQuery, ref SQLiteDataReader SQL)
        {
            var bRtn = false;
            if (SQLConnection.State == ConnectionState.Open)
            {
                try
                {
                    var sSqlCommand = strQuery.Trim();//.ToUpper();
                    if (strQuery.Contains(";") == false) sSqlCommand = $"{sSqlCommand};";
                    //
                    var cmd = new SQLiteCommand(sSqlCommand, SQLConnection);
                    // SqlDataReader 객체를 리턴
                    SQL = cmd.ExecuteReader();
                    bRtn = SQL.HasRows;
                }
                catch (Exception ex)
                {
                    //    MmiGV.AddMessage(ex.Message);
                    ex.Message.ToString();
                }
            }
            return bRtn;
        }

        //-- SQL (Update or Insert 등 결과 반환이 없는 경우)
        //-- SQL 1문장 실행.
        public static bool Execute(string strQuery)
        {
            var bRtn = false;

            if (SQLConnection.State == ConnectionState.Open)
            {
                //-- DROP 명령어는 SQLiteTransaction을 사용할수 없다.
                if (strQuery.Trim().ToUpper().Contains("DROP"))
                {
                    try
                    {
                        var sSqlCommand = strQuery.Trim();//.ToUpper();
                        if (strQuery.Contains(";") == false) sSqlCommand = $"{sSqlCommand};";
                        //
                        using (var cmd = new SQLiteCommand(sSqlCommand, SQLConnection))
                        {
                            cmd.ExecuteNonQuery();
                        }

                        bRtn = true;
                    }
                    catch (Exception ex)
                    {
                        //    MmiGV.AddMessage(ex.Message);
                        ex.Message.ToString();
                    }
                }
                else
                {
                    //-- DROP을 제외한 일반 명령어들.
                    using (var tran = SQLConnection.BeginTransaction())
                    {
                        try
                        {
                            var sSqlCommand = strQuery.Trim();//.ToUpper();
                            if (strQuery.Contains(";") == false) sSqlCommand = $"{sSqlCommand};";
                            //
                            using (var cmd = new SQLiteCommand(sSqlCommand, SQLConnection))
                            {
                                cmd.Transaction = tran;
                                cmd.ExecuteNonQuery();
                            }

                            tran.Commit();
                            bRtn = true;
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            //    MmiGV.AddMessage(ex.Message);
                            ex.Message.ToString();
                        }
                    }
                }
            }

            return bRtn;
        }

        //-- 큐에 다수의 SQL을 등록
        public static bool AddTransaction(string strQuery)
        {
            var bRtn = false;

            if (strQuery.Trim() == string.Empty) return false;

            try
            {
                var sSqlCommand = strQuery.Trim();//.ToUpper();
                if (strQuery.Contains(";") == false) sSqlCommand = $"{sSqlCommand};";
                //-- ConcurrentQueue에 SQL을 Adding
                TransactionQueue.Enqueue(sSqlCommand.Trim().ToUpper());
                bRtn = true;
            }
            catch (Exception ex)
            {
                //    MmiGV.AddMessage(ex.Message);
                ex.Message.ToString();
            }

            return bRtn;
        }

        //-- 트랜잭션 실행 큐가 다 비워질때까지 실행 한다.
        public static bool RunTransaction()
        {
            var bRtn = false;
            try
            {
                if (SQLConnection.State == ConnectionState.Open)
                {
                    using (var tran = SQLConnection.BeginTransaction())
                    {
                        try
                        {
                            while (!TransactionQueue.IsEmpty)
                            {
                                if (TransactionQueue.Count > 0)
                                {
                                    try
                                    {
                                        var sSqlCommand = "";
                                        TransactionQueue.TryDequeue(out sSqlCommand);
                                        using (var cmd = new SQLiteCommand(sSqlCommand, SQLConnection))
                                        {
                                            cmd.Transaction = tran;
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        tran.Rollback();
                                        //   MmiGV.AddMessage(ex.Message);
                                        ex.Message.ToString();
                                    }
                                }
                            }

                            bRtn = true;
                            tran.Commit();
                        }
                        catch (Exception ex)
                        {
                            tran.Rollback();
                            //    MmiGV.AddMessage(ex.Message);
                            ex.Message.ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //   MmiGV.AddMessage(ex.Message);
                ex.Message.ToString();
            }

            return bRtn;
        }

    }
}
