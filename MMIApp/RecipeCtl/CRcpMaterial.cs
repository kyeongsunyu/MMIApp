using System;
using System.Collections.Generic;
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
