using C1.Win.C1FlexGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Xml.Linq;

namespace MMI
{
    public partial class FormDataRecipe : Form
    {
       // int x, y;

        private FormMain frmMain = null;
        private int iSelectedDevice;

        DevComponents.DotNetBar.LabelX[] dDev;
        DevComponents.DotNetBar.LabelX[] dCnt;
        DevComponents.DotNetBar.LabelX[] dDelay;
        DevComponents.DotNetBar.Controls.CheckBoxX[] dbool;

        private void InitUi()
        {
            //cmb_Degree.Items.Clear();
            //cmb_Degree.Items.Add("0");
            //cmb_Degree.Items.Add("90");
            //cmb_Degree.Items.Add("180");
            //cmb_Degree.Items.Add("270");
            

            dDev = new DevComponents.DotNetBar.LabelX[18];
            dbool = new DevComponents.DotNetBar.Controls.CheckBoxX[18];
            dCnt = new DevComponents.DotNetBar.LabelX[9];
            dDelay = new DevComponents.DotNetBar.LabelX[8];

            int cnt =0;
            dDev[cnt] = lblDev001; cnt++;
            dDev[cnt] = lblDev002; cnt++;
            dDev[cnt] = lblDev003; cnt++;
            dDev[cnt] = lblDev004; cnt++;
            dDev[cnt] = lblDev005; cnt++;
            dDev[cnt] = lblDev006; cnt++;
            dDev[cnt] = lblDev007; cnt++;
            dDev[cnt] = lblDev008; cnt++;
            dDev[cnt] = lblDev009; cnt++;
            dDev[cnt] = lblDev010; cnt++;
            dDev[cnt] = lblDev011; cnt++;
            dDev[cnt] = lblDev012; cnt++;
            dDev[cnt] = lblDev013; cnt++;
            dDev[cnt] = lblDev014; cnt++;
            dDev[cnt] = lblDev015; cnt++;
            dDev[cnt] = lblDev016; cnt++;
            dDev[cnt] = lblDev017; cnt++;
            dDev[cnt] = lblDev018; cnt++;

            cnt = 0;
            dbool[cnt] = chkDev051; cnt++;
            dbool[cnt] = chkDev052; cnt++;
            dbool[cnt] = chkDev053; cnt++;
            dbool[cnt] = chkDev054; cnt++;
            dbool[cnt] = chkDev055; cnt++;
            dbool[cnt] = chkDev056; cnt++;
            dbool[cnt] = chkDev057; cnt++;
            dbool[cnt] = chkDev058; cnt++;
            dbool[cnt] = chkDev059; cnt++;
            dbool[cnt] = chkDev060; cnt++;
            dbool[cnt] = chkDev061; cnt++;
            dbool[cnt] = chkDev062; cnt++;
            dbool[cnt] = chkDev063; cnt++;
            dbool[cnt] = chkDev064; cnt++;
            dbool[cnt] = chkDev065; cnt++;
            dbool[cnt] = chkDev066; cnt++;
            dbool[cnt] = chkDev067; cnt++;
            dbool[cnt] = chkDev068; cnt++;

            cnt = 0;
            dCnt[cnt] = lblDev101; cnt++;
            dCnt[cnt] = lblDev102; cnt++;
            dCnt[cnt] = lblDev103; cnt++;
            dCnt[cnt] = lblDev104; cnt++;
            dCnt[cnt] = lblDev105; cnt++;
            dCnt[cnt] = lblDev106; cnt++;
            dCnt[cnt] = lblDev107; cnt++;
            dCnt[cnt] = lblDev108; cnt++;
            dCnt[cnt] = lblDev109; cnt++;

            cnt = 0;
            dDelay[cnt] = lblDev151; cnt++;
            dDelay[cnt] = lblDev152; cnt++;
            dDelay[cnt] = lblDev153; cnt++;
            dDelay[cnt] = lblDev154; cnt++;
            dDelay[cnt] = lblDev155; cnt++;
            dDelay[cnt] = lblDev156; cnt++;
            dDelay[cnt] = lblDev157; cnt++;
            dDelay[cnt] = lblDev158; cnt++;
        }

        public FormDataRecipe()
        {
            InitializeComponent();
            InitUi();
        }




        public FormDataRecipe(FormMain frm)
        {
            InitializeComponent();
            this.frmMain = frm;
            InitUi();
        }

        private void FormDataRecipe_Load(object sender, EventArgs e)
        {
            InitGridDevice();
            LoadData();
            Load_Device(1);
        }

        private void FormDataRecipe_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }
        private void InitGridDevice()
        {
            gdDevice.BeginUpdate();
            gdDevice[0, 0] = "DEVICE NO";
            gdDevice[0, 1] = "DEVICE NAME";

            gdDevice.Cols[0].Width = 150;
            gdDevice.Cols[1].Width = 250;

            gdDevice.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            gdDevice.Styles.Fixed.Font = new Font("Tahoma", 14, FontStyle.Bold);
            gdDevice.AllowEditing = true;
            gdDevice.EndUpdate();
        }

        private void SelectLoadData()
        {
            iSelectedDevice = gdDevice.Row;
            Load_Device(iSelectedDevice);
        }


        private void LoadData()
        {
            string strSQL = "SELECT * FROM DEVICE ORDER BY IDX ASC";
            int iMaxRec = 0;
            double numResult;

            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderDeviceData))
            {
                DataTable dTable = new DataTable("DeviceData");
                DataRow row = dTable.NewRow();
                dTable.Load(SQLiteDB.ReaderDeviceData);
                iMaxRec = dTable.Rows.Count;

                //for (int iDev = 0; iDev < iMaxRec; iDev++)
                for (int iDev = 1; iDev <= iMaxRec; iDev++)
                {
                    /*
                    if (iDev == 0)
                    {
                        MmiGV.strDeviceName[iDev] = dTable.Rows[iDev]["DEVICE_NAME"].ToString();

                        for (int iDataNo = 0; iDataNo < MmiGV.NumOf_DeviceData; iDataNo++)
                        {
                            string id = string.Format("{0:D3}", iDataNo + 1);
                            MmiGV.strDeviceData[iDev, iDataNo] = dTable.Rows[iDev]["DATA" + id].ToString();
                            numResult = (double.TryParse(dTable.Rows[iDev]["DATA" + id].ToString(), out numResult)) ? numResult : 0;
                            MmiGV.dDeviceData[iDev, iDataNo] = numResult;
                        }
                    }
                    else*/
                    {
                        MmiGV.strDeviceName[iDev] = dTable.Rows[iDev-1]["DEVICE_NAME"].ToString();
                        gdDevice[iDev, 0] = iDev.ToString();
                        gdDevice[iDev, 1] = dTable.Rows[iDev - 1]["DEVICE_NAME"].ToString();
                        //gdDevice[iDev, 2] = dTable.Rows[iDev]["DATA001"].ToString();
                        //gdDevice[iDev, 3] = dTable.Rows[iDev]["DATA002"].ToString();
                        //gdDevice[iDev, 4] = dTable.Rows[iDev]["DATA003"].ToString();
                        //gdDevice[iDev, 5] = dTable.Rows[iDev]["DATA004"].ToString();
                        //gdDevice[iDev, 6] = dTable.Rows[iDev]["DATA005"].ToString();
                        //gdDevice[iDev, 7] = dTable.Rows[iDev]["DATA006"].ToString();
                        //gdDevice[iDev, 8] = dTable.Rows[iDev]["DATA007"].ToString();

                        for (int iDataNo = 0; iDataNo < MmiGV.NumOf_DeviceData; iDataNo++)
                        {
                            string id = string.Format("{0:D3}", iDataNo + 1);
                            MmiGV.strDeviceData[iDev, iDataNo] = dTable.Rows[iDev - 1]["DATA" + id].ToString();
                            numResult = (double.TryParse(dTable.Rows[iDev - 1]["DATA" + id].ToString(), out numResult)) ? numResult : 0;
                            MmiGV.dDeviceData[iDev, iDataNo] = numResult;
                        }
                    }
                }
            }

            if (SQLiteDB.ReaderDeviceData == null) return;

            SQLiteDB.ReaderDeviceData.Close();
        }


        private void gdDevice_AfterEdit(object sender, RowColEventArgs e)
        {/*
            try
            {
                if (e.Col == 1)
                {
                    string strSQL = $"UPDATE DEVICE SET DEVICE_NAME = '{gdDevice[e.Row,e.Col].ToString()}' WHERE IDX = {e.Row}";
                    SQLiteDB.Execute(strSQL);
                }
            }
            catch(Exception ex)
            {
                ex.Message.ToString();
            }
            LoadData();
            DataRefresh();*/
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            //CRecipeCtl.CreateMainDevTable();
            //return;

            btnApply.Enabled = false;
            //if (frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo)) 
            {
                WriteData();
            }
            btnApply.Enabled = true;

        }
        private void WriteData()
        {
            iSelectedDevice = gdDevice.Row;
            Save_Device(iSelectedDevice, gdDevice[iSelectedDevice, 1].ToString());

            /*
            #region DEVICE_DATA_SAVE
            string strSQL = "UPDATE DEVICE SET CURR_MARK = ' '";
            SQLiteDB.Execute(strSQL);

            strSQL = " UPDATE DEVICE SET ";
            strSQL += " DATA001 = " + textBox1.Text + ",";
            strSQL += " DATA002 = " + textBox2.Text + ",";
            strSQL += " DATA003 = " + textBox3.Text + ",";
            strSQL += " DATA004 = " + textBox4.Text + ",";
            //strSQL += " DATA005 = " + lblDeiceData04->Text + ",";
            //strSQL += " DATA006 = " + lblDeiceData05->Text + ",";
            //strSQL += " DATA007 = " + lblDeiceData06->Text + ",";
            strSQL += " CURR_MARK = '**'";
            strSQL += " WHERE IDX=" + iSelectedDevice.ToString();
            SQLiteDB.Execute(strSQL);

            
            MmiGV.strDeviceData[iSelectedDevice, 0] = lblDeiceData01.Text.ToString();
            MmiGV.dDeviceData[iSelectedDevice, 0] = double.Parse(lblDeiceData01.Text.ToString());

            MmiGV.strDeviceData[iSelectedDevice, 1] = lblDeiceData02.Text.ToString();
            MmiGV.dDeviceData[iSelectedDevice, 1] = double.Parse(lblDeiceData02.Text.ToString());

            for (int i = 0; i < 100; i++)
            {
                MmiGV.pShMem.WRecipeData.dData[i] = MmiGV.dDeviceData[iSelectedDevice, i];
            }
            MmiGV.pShMem.SetRecipe();

            #endregion DEVICE_DATA_SAVE

            #region MOTOR_DATA_LOADING
            strSQL = "SELECT * FROM MOTOR WHERE DEVICE = ";
            strSQL += iSelectedDevice.ToString();
            strSQL += " ORDER BY IDX ASC";

            if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderMotor))
            {
                for (int iPosNo = 0; iPosNo < 50; iPosNo++)
                {
                    if (SQLiteDB.ReaderMotor.Read())
                    {
                        for (int iAxis = 0; iAxis < 60; iAxis++)
                        {
                            String id = string.Format("{0:D2}", iAxis + 1);
                            //    Console.WriteLine("{0}", double.Parse(GV.DBReader_MotorData["POS" + id].ToString()));

                            MmiGV.mtData[iAxis].PosName[iPosNo] = SQLiteDB.ReaderMotor["ITEM" + id].ToString();
                            double dPos = double.Parse(SQLiteDB.ReaderMotor["POS" + id].ToString()) * MmiGV.mtConfigData[iAxis].uPulseRate;
                            MmiGV.mtData[iAxis].iPosArray[iPosNo] = (int)dPos;
                            double dSpeed = double.Parse(SQLiteDB.ReaderMotor["SPD" + id].ToString()) * MmiGV.mtConfigData[iAxis].uPulseRate;
                            MmiGV.mtData[iAxis].iSpeedArray[iPosNo] = (int)dSpeed;
                        }
                    }
                }
                SQLiteDB.ReaderMotor.Close();
            }
            else
            {
                for (int iPosNo = 0; iPosNo < 50; iPosNo++)
                {
                    string strSQL2;
                    strSQL2 = "INSERT INTO MOTOR (DEVICE, IDX) ";
                    strSQL2 += " VALUES (" + iSelectedDevice.ToString() + "," + (iPosNo).ToString() + ")";
                    SQLiteDB.Execute(strSQL2);

                    for (int iAxis = 0; iAxis < 60; iAxis++)
                    {
                        String id = string.Format("{0:D2}", iAxis + 1);
                        //    Console.WriteLine("{0}", double.Parse(GV.DBReader_MotorData["POS" + id].ToString()));
                        MmiGV.strPosName[iAxis, iPosNo] = "";

                        MmiGV.mtData[iAxis].PosName[iPosNo] = "";
                        MmiGV.mtData[iAxis].iPosArray[iPosNo] = 0;
                        MmiGV.mtData[iAxis].iSpeedArray[iPosNo] = 0;

                    }
                }
            }

            strSQL = "SELECT * FROM MOTOR_COMMON ORDER BY IDX ASC";

            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderMotor))
            {
                for (int iPosNo = 0; iPosNo < 48; iPosNo++)
                {
                    if (SQLiteDB.ReaderMotor.Read())
                    {
                        for (int iAxis = 0; iAxis < 60; iAxis++)
                        {
                            String id = string.Format("{0:D2}", iAxis + 1);
                            //    Console.WriteLine("{0}", double.Parse(GV.DBReader_MotorData["POS" + id].ToString()));

                            MmiGV.mtData[iAxis].PosName[iPosNo+51] = SQLiteDB.ReaderMotor["ITEM" + id].ToString();
                            double dPos = double.Parse(SQLiteDB.ReaderMotor["POS" + id].ToString()) * MmiGV.mtConfigData[iAxis].uPulseRate;
                            MmiGV.mtData[iAxis].iPosArray[iPosNo + 51] = (int)dPos;
                            double dSpeed = double.Parse(SQLiteDB.ReaderMotor["SPD" + id].ToString()) * MmiGV.mtConfigData[iAxis].uPulseRate;
                            MmiGV.mtData[iAxis].iSpeedArray[iPosNo + 51] = (int)dSpeed;
                        }
                    }
                }
                SQLiteDB.ReaderMotor.Close();
            }
            else
            {
                for (int iPosNo = 0; iPosNo < 48; iPosNo++)
                {
                    string strSQL2;
                    strSQL2 = "INSERT INTO MOTOR_COMMON (IDX) ";
                    strSQL2 += " VALUES (" + (iPosNo).ToString() + ")";
                    SQLiteDB.Execute(strSQL2);

                    for (int iAxis = 0; iAxis < 60; iAxis++)
                    {
                        String id = string.Format("{0:D2}", iAxis + 1);
                        //    Console.WriteLine("{0}", double.Parse(GV.DBReader_MotorData["POS" + id].ToString()));
                        MmiGV.strPosName[iAxis, iPosNo+51] = "";

                        MmiGV.mtData[iAxis].PosName[iPosNo+51] = "";
                        MmiGV.mtData[iAxis].iPosArray[iPosNo+51] = 0;
                        MmiGV.mtData[iAxis].iSpeedArray[iPosNo+51] = 0;

                    }
                }
            }

            MmiGV.iDevNo = iSelectedDevice;
            //MmiGV.WriteDM(10, MmiGV.iDevNo);
            MmiGV.pShMem.SetDM(10, (uint)MmiGV.iDevNo);

            for (int i = 0; i < 60; i++)
            {
                if (MmiGV.mtConfigData[i].uUse == 1)
                {
                    MmiGV.pShMem.WMotorData.uAxisNo = i;
                    MmiGV.pShMem.WMotorData.uPos = MmiGV.mtData[i].iPosArray;
                    MmiGV.pShMem.WMotorData.uVel = MmiGV.mtData[i].iSpeedArray;
                    MmiGV.pShMem.SetMotorData();
                }
            }

            frmMain.frmMotorSetting.LoadMotorSettingData();
            frmMain.frmMotorSetting.RefreshData();
            frmMain.lblDevice.Text = string.Format("[{0:D2}] : ", MmiGV.iDevNo) + MmiGV.strDeviceName[MmiGV.iDevNo];

            MmiGV.pShMem.WDeviceInfo.nDeviceNumber = (int)iSelectedDevice;
            MmiGV.pShMem.WDeviceInfo.strDeviceName = MmiGV.strDeviceName[MmiGV.iDevNo];
            MmiGV.pShMem.SetDeviceInfo();

            //SeqGV.DeviceInfo.iDeviceNumber = iSelectedDevice;
            //SeqGV.DeviceInfo.strDeviceName = MmiGV.strDeviceName[MmiGV.iDevNo];

            #endregion MOTOR_DATA_LOADING

            */
        }

        private void btnDeviceCopy_Click(object sender, EventArgs e)
        {
            frmMain.frm_DataCopy.ShowDialog();
            LoadData();
        }

        private void btnDeviceData01_Click(object sender, EventArgs e)
        {
            // Tray X Count
            uint uData;
            if (frmMain.frm_NumPad.Display())
            {
                uData = (uint)frmMain.frm_NumPad.GetValue();
                if ((uData > 0) && (uData <= 50))
                {
                    lbl_Tray_X_count.Text = uData.ToString();
                    gdDevice[gdDevice.Row, 2] = uData.ToString();
                }
                else
                {
                    MessageBox.Show("You Should Input 1 ~ 50 ");
                    if (uData < 1) uData = 1;
                    else if (uData > 50) uData = 50;
                    lbl_Tray_X_count.Text = uData.ToString();
                    gdDevice[gdDevice.Row, 2] = uData.ToString();
                }
            }
        }

        /*
        private void btnDeviceData02_Click(object sender, EventArgs e)
        {
            // Tray Y Count
            uint uData;
            if (frmMain.frm_NumPad.Display())
            {
                uData = (uint)frmMain.frm_NumPad.GetValue();
                if ((uData > 0) && (uData <= 50))
                {
                    lbl_Tray_Y_count.Text = uData.ToString();
                    gdDevice[gdDevice.Row, 3] = uData.ToString();
                }
                else
                {
                    MessageBox.Show("You Should Input 1 ~ 50 ");
                    if (uData < 1) uData = 1;
                    else if (uData > 50) uData = 50;
                    lbl_Tray_Y_count.Text = uData.ToString();
                    gdDevice[gdDevice.Row, 3] = uData.ToString();
                }
            }
        }*/

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            btnSelect.Enabled = false;
            //if (frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
            {
                iSelectedDevice = gdDevice.Row;
                CRecipeCtl.MainRecipeSelect(iSelectedDevice.ToString());
            }

            Load_Device(iSelectedDevice);
            btnSelect.Enabled = true;
        }

        private void gdDevice_SelChange(object sender, EventArgs e)
        {
            SelectLoadData();
        }


        private void Load_Device(int idx)
        {
            CRecipeCtl.EditMaterialRcp.Material_IDX = idx;
            CRecipeCtl.EditMaterialRcp.LoadRcpMaterial();

            //for (int k = 0; k < dDev.Length; k++)
            //{
            //    dDev[k].Text = CRecipeCtl.EditMaterialRcp.DeviceData[k].ToString("F2");
            //}

            //cmb_Degree.SelectedIndex = (int)CRecipeCtl.EditMaterialRcp.DeviceData[dDev.Length];

            //int cnt = 50;
            //for (int k = 0; k < dbool.Length; k++)
            //{
            //    if (CRecipeCtl.EditMaterialRcp.DeviceData[cnt + k] == 1)
            //    { dbool[k].Checked = true; }
            //    else
            //    { dbool[k].Checked = false; }
            //}

            //cnt = 100;
            //for (int k = 0; k < dCnt.Length; k++)
            //{
            //    dCnt[k].Text = CRecipeCtl.EditMaterialRcp.DeviceData[cnt+k].ToString("F0");
            //}

            //cnt = 150;
            //for (int k = 0; k < dDelay.Length; k++)
            //{
            //    dDelay[k].Text = CRecipeCtl.EditMaterialRcp.DeviceData[cnt + k].ToString("F2");
            //}


            // Device
            // Unit X Size
            lblDev001.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[0]:0.00}";
            // Unit Y Size
            lblDev002.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[1]:0.00}";
            // Unit X Count
            lblDev003.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[2]:0}";
            // Unit Y Count
            lblDev004.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[3]:0}";
            // Unit X Pitch
            lblDev005.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[4]:0.00}";
            // Unit Y Pitch
            lblDev006.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[5]:0.00}";
            // Tray X Count
            lblDev007.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[6]:0}";
            // Tray Y Count
            lblDev008.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[7]:0}";
            // Vision Snap X
            lblDev009.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[8]:0}";
            // Vision Snap Y
            lblDev010.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[9]:0}";
            // Place Vacuum Off Offset
            lblDev011.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[10]:0.00}";
            // Picker Angle
            cmb_Degree.SelectedIndex = (int)CRecipeCtl.EditMaterialRcp.DeviceData[11];
            // Pallet 1 Unit Receive Vacuum Value
            lblDev012.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[12]:0}";
            // Pallet 2 Unit Receive Vacuum Value
            lblDev013.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[13]:0}";
            // Pallet First Sort Vacuum Value   
            lblDev014.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[14]:0}";
            // Pallet Middle Sort Vacuum Value
            lblDev015.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[15]:0}";
            // Pallet Last Sort Vacuum Value
            lblDev016.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[16]:0}";
            // Pallet First Sort Pkg Rate
            lblDev017.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[17]:0.0}";
            // Pallet Last Sort Pkg Rate
            lblDev018.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[18]:0.0}";




            // use/skip
            // Front Picker1 Skip
            chkDev051.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[50] == 1) ? true : false;
            // Front Picker2 Skip
            chkDev052.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[51] == 1) ? true : false;
            // Front Picker3 Skip
            chkDev053.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[52] == 1) ? true : false;
            // Front Picker4 Skip
            chkDev054.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[53] == 1) ? true : false;
            // Front Picker5 Skip
            chkDev055.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[54] == 1) ? true : false;
            // Front Picker6 Skip
            chkDev056.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[55] == 1) ? true : false;
            // Front Picker7 Skip
            chkDev057.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[56] == 1) ? true : false;
            // Front Picker8 Skip
            chkDev058.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[57] == 1) ? true : false;

            // Rear Picker1 Skip
            chkDev059.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[58] == 1) ? true : false;
            // Rear Picker2 Skip
            chkDev060.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[59] == 1) ? true : false;
            // Rear Picker3 Skip
            chkDev061.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[60] == 1) ? true : false;
            // Rear Picker4 Skip
            chkDev062.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[61] == 1) ? true : false;
            // Rear Picker5 Skip
            chkDev063.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[62] == 1) ? true : false;
            // Rear Picker6 Skip
            chkDev064.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[63] == 1) ? true : false;
            // Rear Picker7 Skip
            chkDev065.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[64] == 1) ? true : false;
            // Rear Picker8 Skip
            chkDev066.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[65] == 1) ? true : false;
            // Scrap Skip
            chkDev067.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[66] == 1) ? true : false;
            // Sponge Clean Skip
            chkDev068.Checked = (CRecipeCtl.EditMaterialRcp.DeviceData[67] == 1) ? true : false;

            // Count
            // Saw Picker Sponge Clean
            lblDev101.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[100]:0}";
            // WaterJet Water Clean
            lblDev102.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[101]:0}";
            // WaterJet Air Clean
            lblDev103.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[102]:0}";
            // Saw Picker Flip1 Clean
            lblDev104.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[103]:0}";
            // Saw Picker Flip2 Clean
            lblDev105.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[104]:0}";
            // Flip1 Air Clean
            lblDev106.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[105]:0}";
            // Flip2 Air Clean
            lblDev107.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[106]:0}";
            // Pallet1 Air Clean
            lblDev108.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[107]:0}";
            // Pallet2 Air Clean
            lblDev109.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[108]:0}";

            // delay
            // Front Picker Air Blow
            lblDev151.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[150]:0}";
            // Rear Picker Air Blow
            lblDev152.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[151]:0}";

            // Front Picker Vac On
            lblDev153.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[152]:0}";
            // Rear Picker Vac On
            lblDev154.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[153]:0}";

            // Load Picker Air Blow
            lblDev155.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[154]:0}";
            // Load Picker Vac On
            lblDev156.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[155]:0}";

            // Saw Picker Air Blow
            lblDev157.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[156]:0}";
            // Saw Picker Vac On
            lblDev158.Text = $"{CRecipeCtl.EditMaterialRcp.DeviceData[157]:0}";



            SizeCheckData();
        }

        private void Save_Device(int idx, string devName)
        {
            CRecipeCtl.EditMaterialRcp.Material_IDX = idx;
            CRecipeCtl.EditMaterialRcp.Material_NAME = devName;

            double dData = 0;
            CRecipeCtl.EditMaterialRcp.DeviceData.Clear();
            SizeCheckData();
            //--------------------------------------------------------
            int cnt = 0;
            for (int k = 0; k < 50; k++)
            {
                if (k == 11) //dDev.Length
                {
                    dData = cmb_Degree.SelectedIndex;
                    CRecipeCtl.EditMaterialRcp.DeviceData.Add(dData);
                }
                else if (cnt < dDev.Length)
                {
                    dData = GetDouble(dDev[cnt]);
                    CRecipeCtl.EditMaterialRcp.DeviceData.Add(dData);
                    cnt++;
                }
                else
                {
                    CRecipeCtl.EditMaterialRcp.DeviceData.Add(0);
                }
            }
            for (int k = 0; k < 50; k++)
            {
                if (k < dbool.Length)
                {
                    dData = GetBool(dbool[k]);
                    CRecipeCtl.EditMaterialRcp.DeviceData.Add(dData);
                }
                else
                {
                    CRecipeCtl.EditMaterialRcp.DeviceData.Add(0);
                }
            }
            for (int k = 0; k < 50; k++)
            {
                if (k < dCnt.Length)
                {
                    dData = GetDouble(dCnt[k]);
                    CRecipeCtl.EditMaterialRcp.DeviceData.Add(dData);
                }
                else
                {
                    CRecipeCtl.EditMaterialRcp.DeviceData.Add(0);
                }
            }
            for (int k = 0; k < 50; k++)
            {
                if (k < dDelay.Length)
                {
                    dData = GetDouble(dDelay[k]);
                    CRecipeCtl.EditMaterialRcp.DeviceData.Add(dData);
                }
                else
                {
                    CRecipeCtl.EditMaterialRcp.DeviceData.Add(0);
                }
            }

            CRecipeCtl.EditMaterialRcp.SaveRcpMaterial();
        }


        private void SetSizeCheckData(bool[] enable)
        {
            for (int k = 0; k < enable.Length; k++)
            {
                if (enable[k])  //true : 사용
                {
                    dbool[k].TextColor = Color.Blue;
                    dbool[k].Checked = false; dbool[k].Enabled = true;
                }
                else  //false : 미사용
                {
                    dbool[k].TextColor = Color.Gray;
                    dbool[k].Checked = true; dbool[k].Enabled = false;
                }
            }      
        }
        private void SizeCheckData()
        {
            double dDataX = GetDouble(dDev[0]);
            double dDataY = GetDouble(dDev[1]);
            double dMaxSize = Math.Max(dDataX, dDataY);

            bool[] chkPick = new bool[16];

            if ((3 <= dMaxSize && dMaxSize <= 17))//Z1~Z8
            {
                for (int k = 0; k < 16; k++)
                {
                    chkPick[k] = true;
                }

                SetSizeCheckData(chkPick);
            }
            else if ((18 <= dMaxSize && dMaxSize <= 35))//Z1,Z3,Z5,Z7
            {
                chkPick[0] =  chkPick[8 + 0] =true;   //Z1
                chkPick[1] =  chkPick[8 + 1] =false;  //Z2
                chkPick[2] =  chkPick[8 + 2] =true;   //Z3
                chkPick[3] =  chkPick[8 + 3] =false;  //Z4
                chkPick[4] =  chkPick[8 + 4] =true;   //Z5 
                chkPick[5] =  chkPick[8 + 5] =false;  //Z6
                chkPick[6] =  chkPick[8 + 6] =true;   //Z7  
                chkPick[7] =  chkPick[8 + 7] =false;  //Z8

                SetSizeCheckData(chkPick);
            }
            else if ((16 <= dMaxSize && dMaxSize <= 54)) //Z1,Z4,Z7
            {
                chkPick[0] = chkPick[8 + 0] = true;   //Z1
                chkPick[1] = chkPick[8 + 1] = false;  //Z2
                chkPick[2] = chkPick[8 + 2] = false;  //Z3
                chkPick[3] = chkPick[8 + 3] = true;   //Z4
                chkPick[4] = chkPick[8 + 4] = false;  //Z5 
                chkPick[5] = chkPick[8 + 5] = false;  //Z6
                chkPick[6] = chkPick[8 + 6] = true;   //Z7  
                chkPick[7] = chkPick[8 + 7] = false;  //Z8

                SetSizeCheckData(chkPick);
            }
            else //Z1, Z8
            {
                chkPick[0] = chkPick[8 + 0] = true;   //Z1
                chkPick[1] = chkPick[8 + 1] = false;  //Z2
                chkPick[2] = chkPick[8 + 2] = false;  //Z3
                chkPick[3] = chkPick[8 + 3] = false;   //Z4
                chkPick[4] = chkPick[8 + 4] = false;  //Z5 
                chkPick[5] = chkPick[8 + 5] = false;  //Z6
                chkPick[6] = chkPick[8 + 6] = false;  //Z7  
                chkPick[7] = chkPick[8 + 7] = true;   //Z8

                SetSizeCheckData(chkPick);
            }

            this.Refresh();
        }


        private double GetBool(DevComponents.DotNetBar.Controls.CheckBoxX chkBox)
        {
            double result = chkBox.Checked == true ? 1 : 0; 
            return result;
        }
        private double GetDouble(DevComponents.DotNetBar.LabelX btn)
        {
            if(btn.Text == "") return 0;

            double result = 0;
            result = Convert.ToDouble(btn.Text);
            return result;
        }

        private void lbl_Tray_X_count_Click(object sender, EventArgs e)
        {
            if (frmMain.frm_NumPad.Display())
            {
                int result = Convert.ToInt32(frmMain.frm_NumPad.GetValue());
                lbl_Tray_X_count.Text = result.ToString();
            }
        }


        private void lbl_Tray_Y_count_Click(object sender, EventArgs e)
        {
            if (frmMain.frm_NumPad.Display())
            {
                int result = Convert.ToInt32(frmMain.frm_NumPad.GetValue());
                lbl_Tray_Y_count.Text = result.ToString();
            }
        }

        private void lblDev001_Click(object sender, EventArgs e)
        {
            GetValue(sender);
        }

        private void GetValue(object sender, bool isFloat = true)
        {
            double dVelData = 0;

            if (frmMain.frm_NumPad.Display())
            {
                dVelData = frmMain.frm_NumPad.GetValue();

                if (isFloat)
                { ((DevComponents.DotNetBar.LabelX)sender).Text = dVelData.ToString("F2"); }
                else
                { ((DevComponents.DotNetBar.LabelX)sender).Text = dVelData.ToString("F0"); }
            }
        }

        private void lblDev002_Click(object sender, EventArgs e)
        {
            GetValue(sender);
        }

        private void lblDev003_Click(object sender, EventArgs e)
        {
            GetValue(sender,false);
        }

        private void lblDev004_Click(object sender, EventArgs e)
        {
            GetValue(sender,false);
        }

        private void lblDev005_Click(object sender, EventArgs e)
        {
            GetValue(sender);
        }

        private void lblDev006_Click(object sender, EventArgs e)
        {
            GetValue(sender);
        }

        private void lblDev007_Click(object sender, EventArgs e)
        {
            GetValue(sender,false);
        }

        private void lblDev008_Click(object sender, EventArgs e)
        {
            GetValue(sender,false);
        }

        private void lblDev009_Click(object sender, EventArgs e)
        {
            GetValue(sender,false);
        }

        private void lblDev010_Click(object sender, EventArgs e)
        {
            GetValue(sender,false);
        }

        private void lblDev011_Click(object sender, EventArgs e)
        {
            GetValue(sender,false);
        }

        private void lblDev012_Click(object sender, EventArgs e)
        {
            GetValue(sender,false);
        }

        private void lblDev013_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev014_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev015_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev016_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }
        private void lblDev017_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev018_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev101_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev102_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev103_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev104_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev105_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev106_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev107_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev108_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev109_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev110_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev111_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev151_Click(object sender, EventArgs e)
        {
            GetValue(sender,false);
        }

        private void lblDev152_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev153_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev154_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }



        private void lblDev155_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev156_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev157_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblDev158_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        
    }
}
