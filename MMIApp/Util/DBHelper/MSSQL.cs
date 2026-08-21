using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMI
{
    class MSSQLConn
    {
        // LocalDB	
        string connectionString = "Server=(LocalDB)\\MSSQLLocalDb;database=haksa;integrated security=true";

        // SQL Server, Express
        // string connectionString = "Server=192.168.xxx.xxx;uid="xxx";pwd="xxx";Database=xxx";

        // for ASP.NET, OleDb - .mdb,.accdb, ...
        // string connectionString = WebConfigurationManager.ConnectionStrings["haksa"].ConnectionString;

        public SqlConnection conn;

        public MSSQLConn()
        {
            conn = new SqlConnection(connectionString);
            conn.Open();
        }

        public void Close()
        {
            conn.Close();
        }

        public SqlConnection GetConn()
        {
            return conn;
        }

        public int ExecuteNonQuery(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteNonQuery();
        }

        public SqlDataReader ExecuteReader(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteReader();
        }

        public object ExecuteScalar(string sql)
        {
            SqlCommand cmd = new SqlCommand(sql, conn);
            return cmd.ExecuteScalar();
        }

        public DataSet GetDataSet(string sql)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = new SqlCommand(sql, conn);

            DataSet ds = new DataSet();
            adapter.Fill(ds);
            return ds;
        }
    }
}
