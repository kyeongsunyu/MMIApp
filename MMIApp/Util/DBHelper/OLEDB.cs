using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Data.Common;
using System.Collections.Concurrent;
using System.Diagnostics;

namespace MMI
{

    class OLEDBConn
    {
        //static string connectionString =
        //        "Provider=Microsoft.Ace.OLEDB.12.0;User ID=Admin;Data Source=" +
        //         AppDomain.CurrentDomain.BaseDirectory + "\\DB\\JetDB.mdb;Mode=ReadWrite";
        static string connectionString =
                "Provider=Microsoft.Jet.OLEDB.4.0;User ID=Admin;Data Source=" +
                 AppDomain.CurrentDomain.BaseDirectory + "DB\\JetDB.mdb;Mode=ReadWrite";
        //for ASP.NET
        //string connectionString = WebConfigurationManager.ConnectionStrings["haksa"].ConnectionString;

        public static bool IsConnection;
        public static OleDbConnection SQLConnection;

        private static readonly ConcurrentQueue<string> TransactionQueue = new ConcurrentQueue<string>();

        #region OLE_DB_DATA_READER
        public static OleDbDataReader ReaderTENKEYSEC = null;
        public static OleDbDataReader ReaderTENKEY = null;

        public static OleDbDataReader ReaderMotorCFG = null;
        public static OleDbDataReader ReaderMotor = null;
        public static OleDbDataReader ReaderMachineParam = null;
        public static OleDbDataReader ReaderDeviceData = null;
        public static OleDbDataReader ReaderOption = null;
        public static OleDbDataReader ReaderLampBuzzer = null;
        public static OleDbDataReader ReaderPassword = null;
        public static OleDbDataReader ReaderPasswordLevel = null;
        public static OleDbDataReader ReaderIO = null;
        public static OleDbDataReader ReaderBit = null;
        public static OleDbDataReader ReaderDM = null;
        public static OleDbDataReader ReaderAlarm = null;
        public static OleDbDataReader ReaderUseSkip = null;
        public static OleDbDataReader ReaderTracking = null;

        #endregion OLE_DB_DATA_READER

        public OLEDBConn()
        {
           
            
        }

        public static bool Open()
        {
            //SQLConnection = new OleDbConnection(connectionString);
            //SQLConnection.Open();

            try
            {
                if (SQLConnection == null || SQLConnection.State != ConnectionState.Open)
                {
                    SQLConnection = new OleDbConnection(connectionString);
                    SQLConnection.Open();
                    IsConnection = SQLConnection.State == ConnectionState.Open;
                }
            }
            catch (Exception ex)
            {
                CThreadMMILog MMILog = CThreadMMILog.GetInstance;
                Debug.Assert(MMILog != null);
                MMILog.AddMMILog(ex.Message);
            }

            return IsConnection;
        }

        public static void Close()
        {
            try
            {
                //conn.Close();

                if (SQLConnection == null) return;
                if (SQLConnection.State == ConnectionState.Open)
                {
                    SQLConnection.Dispose();
                }
            }
            catch(Exception ex)
            {
                //    MmiGV.AddMessage(ex.Message);
                ex.Message.ToString();
            }   
           
        }

        public OleDbConnection GetConn()
        {
            return SQLConnection;
        }

        public void ExecuteNonQuery(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, SQLConnection);
            cmd.ExecuteNonQuery();
        }

        public OleDbDataReader ExecuteReader(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, SQLConnection);
            return cmd.ExecuteReader();
        }

        public object ExecuteScalar(string sql)
        {
            OleDbCommand cmd = new OleDbCommand(sql, SQLConnection);
            
            return cmd.ExecuteScalar();
        }

        public DataSet GetDataSet(string sql)
        {
            OleDbDataAdapter adapter = new OleDbDataAdapter();
            adapter.SelectCommand = new OleDbCommand(sql, SQLConnection);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
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
                        var sSqlCommand = strQuery.Trim().ToUpper();
                        if (strQuery.Contains(";") == false) sSqlCommand = $"{sSqlCommand};";
                        //
                        using (var cmd = new OleDbCommand(sSqlCommand, SQLConnection))
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
                            var sSqlCommand = strQuery.Trim().ToUpper();
                            if (strQuery.Contains(";") == false) sSqlCommand = $"{sSqlCommand};";
                            //
                            using (var cmd = new OleDbCommand(sSqlCommand, SQLConnection))
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
                            //MmiGV.AddMessage(ex.Message);
                            ex.Message.ToString();
                        }
                    }
                }
            }
            return bRtn;
        }

        //-- SQL Record Count
        public static int RecCount(string strQuery)
        {
            var nRecCount = -1;
            try
            {
                if (SQLConnection.State == ConnectionState.Open)
                {
                    var sSqlCommand = strQuery.Trim().ToUpper();
                    if (strQuery.Contains(";") == false) sSqlCommand = $"{sSqlCommand};";
                    //
                    var cmd = new OleDbCommand(sSqlCommand, SQLConnection);
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
        public static bool Select(string strQuery, ref OleDbDataReader SQL)
        {
            var bRtn = false;
            if (SQLConnection.State == ConnectionState.Open)
            {
                try
                {
                    var sSqlCommand = strQuery.Trim().ToUpper();
                    //if (strQuery.Contains(";") == false) sSqlCommand = $"{sSqlCommand};";
                    //
                    var cmd = new OleDbCommand(sSqlCommand, SQLConnection);
                    
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
    

        //-- 큐에 다수의 SQL을 등록
        public static bool AddTransaction(string strQuery)
        {
            var bRtn = false;

            if (strQuery.Trim() == string.Empty) return false;

            try
            {
                var sSqlCommand = strQuery.Trim().ToUpper();
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
                                        using (var cmd = new OleDbCommand(sSqlCommand, SQLConnection))
                                        {
                                            cmd.Transaction = tran;
                                            cmd.ExecuteNonQuery();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        tran.Rollback();
                                        //    MmiGV.AddMessage(ex.Message);
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
                            //   MmiGV.AddMessage(ex.Message);
                            ex.Message.ToString();
                        }
                    }
            }
            catch (Exception ex)
            {
                //    MmiGV.AddMessage(ex.Message);
                ex.Message.ToString();
            }

            return bRtn;
        }
    }
}
