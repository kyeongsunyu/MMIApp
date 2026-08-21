using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMI
{
    public partial class Form_DataCopy : Form
    {
        private FormMain frmMain = null;
        string[] strDeviceCopyData = new string[MmiGV.NumOf_Device + 1];

        int iTarget;
        int iSource;

        public Form_DataCopy()
        {
            InitializeComponent();
        }
        public Form_DataCopy(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            cbSourceDevice.DropDownChange += comboDroDown;
        }

        private void Form_DataCopy_Load(object sender, EventArgs e)
        {
            InitScreen();
        }
        private void InitScreen()
        {
            int cnt = 1;
            cbSourceDevice.Items.Clear();

            string sSQL = "SELECT * FROM DEVICE ORDER BY IDX ASC";
            if(SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderDeviceData))
            {
                while (true)
                {
                    if (SQLiteDB.ReaderDeviceData.Read())
                    {
                        String sStr = string.Format("{0:D3} : ", cnt);
                        cbSourceDevice.Items.Add(sStr + SQLiteDB.ReaderDeviceData["DEVICE_NAME"].ToString());
                        cnt++;
                    }
                    else
                    {
                        break;
                    }
                }


                /*
                for (int iDev = 0; iDev < MmiGV.NumOf_Device; iDev++)
                {
                    if (SQLiteDB.ReaderDeviceData.Read())
                    {
                        if (iDev > 0)
                        {
                            String sStr = string.Format("{0:D3} : ", iDev);
                            cbSourceDevice.Items.Add(sStr + SQLiteDB.ReaderDeviceData["DEVICE_NAME"].ToString());
                        }
                    }
                }*/
            }

            SQLiteDB.ReaderDeviceData.Close();
            cbSourceDevice.SelectedIndex = 0;
            comboDroDown(cbSourceDevice, false);
        }

        private void cbSourceDevice_DropDownChange(object sender, bool Expanded)
        {
            comboDroDown(sender, Expanded);
        }
        private void comboDroDown(object sender, bool Expanded)
        {
            string sSQL;
            sSQL = "SELECT * FROM DEVICE WHERE IDX = ";
            sSQL += (cbSourceDevice.SelectedIndex + 1).ToString();

            if(SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderDeviceData))
            {
                if (SQLiteDB.ReaderDeviceData.Read())
                {
                    for (int iData = 0; iData < MmiGV.NumOf_DeviceData; iData++)
                    {
                        string id = string.Format("{0:D3}", iData + 1);
                        string str = SQLiteDB.ReaderDeviceData["DATA" + id].ToString();
                        if (str == "")
                        {
                            str = "0";
                        }
                        strDeviceCopyData[iData] = str;
                    }
                }
            }
            SQLiteDB.ReaderDeviceData.Close();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (txtTargetDeviceNo.Text.ToString() == "") return;
            
            try
            {
                iTarget = (int.TryParse(txtTargetDeviceNo.Text.ToString(), out iTarget)) ? iTarget : 0;
            }
            catch(FormatException ex)
            {
                MessageBox.Show(ex.Message + "\nTarget Device Number를 입력하세요");
            }

            iSource = cbSourceDevice.SelectedIndex + 1;

            CRecipeCtl.EditMaterialRcp.Material_IDX = iSource;
            CRecipeCtl.EditMaterialRcp.LoadRcpMaterial();

            CRecipeCtl.EditMaterialRcp.Material_IDX = iTarget;
            CRecipeCtl.EditMaterialRcp.Material_NAME = txtTargetDeviceName.Text.Trim();
            CRecipeCtl.EditMaterialRcp.SaveRcpMaterial();

            string sSQL = "";
            string sField = "";
            /*
            // 먼저 있는 레코드를 삭제하고

            sSQL = "DELETE FROM DEVICE WHERE IDX = ";
            sSQL += iTarget.ToString();
            SQLiteDB.Execute(sSQL);

            // DEVICE NAME 을 저장한다.
            sSQL = "INSERT INTO DEVICE (IDX, DEVICE_NAME) ";
            sSQL += " VALUES(" + iTarget.ToString() + ",";
            sSQL += "'" + txtTargetDeviceName.Text + "'" + ")";
            SQLiteDB.Execute(sSQL);
            //-------------------------------------------------------------------
            CRecipeCtl.EditMaterialRcp.Material_IDX = iSource;
            CRecipeCtl.EditMaterialRcp.LoadRcpMaterial();
            CRecipeCtl.EditMechRcp.Mech_IDX = iSource;
            CRecipeCtl.EditMechRcp.LoadData();

            // DEVICE DATA를 저장한다.

            sSQL = "";
            string[] strs = new string[8];

            strs[0] = CRecipeCtl.EditMaterialRcp.UnitXCnt.ToString();
            strs[1] = CRecipeCtl.EditMaterialRcp.UnitYCnt.ToString();
            strs[2] = CRecipeCtl.EditMaterialRcp.UnitXSize.ToString("F2");
            strs[3] = CRecipeCtl.EditMaterialRcp.UnitYSize.ToString("F2");
            strs[4] = CRecipeCtl.EditMaterialRcp.UnitXPitch.ToString("F2");
            strs[5] = CRecipeCtl.EditMaterialRcp.UnitYPitch.ToString("F2");
            strs[6] = CRecipeCtl.EditMaterialRcp.TrayXCnt.ToString();
            strs[7] = CRecipeCtl.EditMaterialRcp.TrayYCnt.ToString();

            for (int iDataNo = 0; iDataNo < 8; iDataNo++)
            {
                string strId = string.Format("{0:D3}", iDataNo + 1);
                sField += "DATA" + strId + "=" + "'" + strs[iDataNo] + "'" + ",";
            }
            sSQL = "UPDATE DEVICE SET ";
            sSQL += sField;
            sSQL += " CURR_MARK = '  '";
            sSQL += " WHERE IDX =" + iTarget.ToString();
            SQLiteDB.Execute(sSQL);
            */





            //-------------------------------------------------------------------------------------------------------------
            /*
            // MOTOR DATA를 삭제하고 저장한다
            sSQL = "";
            sSQL = "DELETE FROM MOTOR WHERE DEVICE = ";
            sSQL += iTarget.ToString();
            SQLiteDB.Execute(sSQL);
            */

            //-----------------------------------------------------
            sSQL = "DELETE FROM MOTOR" + iTarget.ToString();
            SQLiteDB.Execute(sSQL);

            //sSQL = "DROP TABLE MOTOR" + iTarget.ToString();
            //SQLiteDB.Execute(sSQL);

            sField = "";
            sSQL = "CREATE TABLE MOTOR" + iTarget.ToString() +" ( DEVICE INT, IDX INT,";

            for (int i = 1; i <= 60; i++)
            {
                string strId = string.Format("{0:D2}", i);
                sField += "ITEM" + strId + " text,";
            }

            for (int i = 1; i <= 60; i++)
            {
                string strId = string.Format("{0:D2}", i);
                sField += "POS" + strId + " real,";
            }

            for (int i = 1; i <= 60; i++)
            {
                string strId = string.Format("{0:D2}", i);
                sField += "SPD" + strId + " real,";
            }

            for (int i = 1; i <= 60; i++)
            {
                string strId = string.Format("{0:D2}", i);

                if (i == 60)
                {
                    sField += "ACC" + strId + " real)"; ;
                }
                else
                {
                    sField += "ACC" + strId + " real,";
                }
            }

            sSQL += sField;

            SQLiteDB.Execute(sSQL);


            //------
            string[] InsertData = new string[100];
            int cnt = 0;

    /*
            sSQL = "SELECT * FROM MOTOR WHERE DEVICE = " + iSource.ToString();
            sSQL += " ORDER BY DEVICE ASC, IDX ASC";
    */

            sSQL = "SELECT * FROM MOTOR" + iSource.ToString();
            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderMotor))
            {
                while(true)
                {
                    if (SQLiteDB.ReaderMotor.Read())
                    {
                        //cnt++;
                        InsertData[cnt] = " VALUES (" + iTarget.ToString() + "," + cnt.ToString() + ",";

                        for (int i = 1; i <= 60; i++)
                        {
                            string strId = string.Format("{0:D2}", i);
                            sField = "ITEM" + strId;

                            InsertData[cnt] += "'" + SQLiteDB.ReaderMotor[sField].ToString() + "',";
                        }

                        for (int i = 1; i <= 60; i++)
                        {
                            string strId = string.Format("{0:D2}", i);
                            sField = "POS" + strId;

                            InsertData[cnt] += SQLiteDB.ReaderMotor[sField].ToString() + ",";
                        }

                        for (int i = 1; i <= 60; i++)
                        {
                            string strId = string.Format("{0:D2}", i);
                            sField = "SPD" + strId;

                            InsertData[cnt] += SQLiteDB.ReaderMotor[sField].ToString() + ",";
                        }

                        for (int i = 1; i <= 60; i++)
                        {
                            string strId = string.Format("{0:D2}", i);
                            sField = "ACC" + strId;

                            if (i == 60)
                            {
                                InsertData[cnt] += SQLiteDB.ReaderMotor[sField].ToString() + "); ";
                            }
                            else
                            {
                                InsertData[cnt] += SQLiteDB.ReaderMotor[sField].ToString() + ",";
                            }
                        }
                        cnt++;
                    }
                    else
                    {
                        break;
                    }
                }
                SQLiteDB.ReaderMotor.Close();
            }
            sSQL = "";

            for (int k = 0; k < 100; k++)
            {
                sSQL = "INSERT INTO MOTOR" + iTarget.ToString() + " " + InsertData[k];

                SQLiteDB.Execute(sSQL);
            }
            
            frmMain.frm_Msg.ShowMessage("Copy Device Data Complete");
            this.Close();

            //sSQL = "INSERT ALL MOTOR1 SELECT * FROM MOTOR WHERE DEVICE = " + iSource.ToString();
            //sSQL += " ORDER BY DEVICE ASC, IDX ASC";
            //SQLiteDB.Execute(sSQL);

            //sSQL = "INSERT INTO MOTOR1  SELECT * FROM MOTOR  WHERE DEVICE = " + iSource.ToString();
            //SQLiteDB.Execute(sSQL);





            /*
            sField = "";
            string sVal = "";
            for (int i = 1; i <= 60; i++)
            {
                string strId = string.Format("{0:D2}", i);
                sField += "ITEM" + strId + ",";
                sVal += "' ',";
            }

            for (int i = 1; i <= 60; i++)
            {
                string strId = string.Format("{0:D2}", i);
                sField += "POS" + strId + ",";
                sVal   += "0,";
            }

            for (int i = 1; i <= 60; i++)
            {
                string strId = string.Format("{0:D2}", i);
                sField += "SPD" + strId + ",";
                sVal += "0,";
            }

            for (int i = 1; i <= 60; i++)
            {
                string strId = string.Format("{0:D2}", i);

                if (i == 60)
                { 
                    sField += "ACC" + strId;
                    sVal   += "0";
                }
                else
                { 
                    sField += "ACC" + strId + ",";
                    sVal   += "0,";
                }
            }


            //----------------------------------------------------------------------






            sSQL = "INSERT INTO MOTOR ( DEVICE, IDX, " + sField + " )";
            sSQL += " SELECT " + iTarget.ToString() + ", IDX, " + sField;
            sSQL += " FROM MOTOR";
            sSQL += " WHERE DEVICE = " + iSource.ToString();
            SQLiteDB.Execute(sSQL);
            */




            /*
            sField = "";
            for (int i = 1; i <= 60; i++)
            {
                string strId = string.Format("{0:D2}", i);
                sField += "ITEM" + strId + ",";
                sField += "POS" + strId + ",";
                sField += "SPD" + strId + ",";
                if (i == 60)
                {
                    sField += "ACC" + strId;
                }
                else
                {
                    sField += "ACC" + strId + ",";
                }
            }
            sSQL = "INSERT INTO MOTOR ( DEVICE, IDX, " + sField + " )";
            sSQL += " SELECT " + iTarget.ToString() + ", IDX, " + sField;
            sSQL += " FROM MOTOR";
            sSQL += " WHERE DEVICE = " + iSource.ToString();
            sSQL += " ORDER BY DEVICE ASC, IDX ASC";
            SQLiteDB.Execute(sSQL);*/
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
