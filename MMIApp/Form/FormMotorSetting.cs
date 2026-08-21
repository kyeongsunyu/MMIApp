using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Text;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using DevComponents.Instrumentation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace MMI
{
    public partial class FormMotorSetting : Form
    {
        private FormMain frmMain = null;

        private int iTagBackup = -1;
        private bool bJogMode = false;
        private bool bModify = false;
        private bool bgdMotorSelected = false;
	    private bool bgdMotorCommonSelected = false;

        public bool bTenkeyJogMode = false;


        public FormMotorSetting()
        {
            InitializeComponent();
        }
        public FormMotorSetting(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            lblUnitValue.Text = "0000";
            lblIdx.Text = "000";
        }

        private void FormMotorSetting_Load(object sender, EventArgs e)
        {
            InitGridMotor();
            InitGridMotorCommon();

            InitScreen();
            //Disable by chs
            //LoadMotorSettingData();
            //RefreshData();
        }

        private void FormMotorSetting_Shown(object sender, EventArgs e)
        {
            bTenkeyJogMode = false;
            btnTenkeyJog.Checked = false;
        }

        private void FormMotorSetting_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void InitGridMotor()
        {
            gdMotor[0, 0] = "NO";
            gdMotor[0, 1] = "DEVICE POSITION NAME";
            gdMotor[0, 2] = "SETTING";
            gdMotor[1, 2] = "POSITION";
            gdMotor[1, 3] = "VELOCITY";
            gdMotor[0, 4] = "CURRENT";
            gdMotor[1, 4] = "POSITION";
            gdMotor[1, 5] = "VELOCITY";

            gdMotor.Cols[0].Width = 50;
            gdMotor.Cols[1].Width = 585;
            gdMotor.Cols[2].Width = 150;
            gdMotor.Cols[3].Width = 150;
            gdMotor.Cols[4].Width = 150;
            gdMotor.Cols[5].Width = 150;

            gdMotor.Cols[0].AllowEditing = false;
            gdMotor.Cols[1].AllowEditing = false;
            gdMotor.Cols[2].AllowEditing = false;
            gdMotor.Cols[3].AllowEditing = false;
            gdMotor.Cols[4].AllowEditing = false;
            gdMotor.Cols[5].AllowEditing = false;

            gdMotor.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            CellRange rng = gdMotor.GetCellRange(0, 0, 1, 0);
            gdMotor.MergedRanges.Add(rng);
            rng.Data = "\nNO";

            rng = gdMotor.GetCellRange(0, 1, 1, 1);
            gdMotor.MergedRanges.Add(rng);
            rng.Data = "\nDEVICE POSITION NAME";

            rng = gdMotor.GetCellRange(0, 2, 0, 3);
            gdMotor.MergedRanges.Add(rng);
            //     rng.Data = "SETTING";

            //   rng = gdMotor.GetCellRange(0, 4, 0, 5);
            gdMotor.MergedRanges.Add(gdMotor.GetCellRange(0, 4, 0, 5));
            //      rng.Data = "CURRENT";

            gdMotor.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            gdMotor.Styles.Fixed.Font = new Font("Tahoma", 12, FontStyle.Bold);

            CellStyle csCellStyle = gdMotor.Styles.Add("CellStyle");
            //csCellStyle.BackColor = Color.Bisque;                    // Cell의 바탕색 
            csCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);           // 글자 굵기 굴게
            CellRange crCellRange = gdMotor.GetCellRange(2, 0, 50, 5); ;// (2, 0, 101, 5);       // 적용할 Cell의 영역 설정
            crCellRange.Style = gdMotor.Styles["CellStyle"];              // 설정된 Cell 영역에 Style 적용


            gdMotor.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            gdMotor.Cols[1].TextAlign = TextAlignEnum.LeftCenter;
            gdMotor.Cols[2].TextAlign = TextAlignEnum.RightCenter;
            gdMotor.Cols[3].TextAlign = TextAlignEnum.RightCenter;
            gdMotor.Cols[4].TextAlign = TextAlignEnum.RightCenter;
            gdMotor.Cols[5].TextAlign = TextAlignEnum.RightCenter;

            for (int row = 1; row < gdMotor.Rows.Count; row++)
            {
                gdMotor[row + 1, 0] = row;
                gdMotor[row + 1, 1] = " ";
                gdMotor[row + 1, 2] = "0.000";
                gdMotor[row + 1, 3] = "0";
                gdMotor[row + 1, 4] = "0.000";
                gdMotor[row + 1, 5] = "0";
            }
        }
        private void InitGridMotorCommon()
        {
            //gdMotorCommon.AllowEditing = false;
            gdMotorCommon[0, 0] = "NO";
            gdMotorCommon[0, 1] = "COMMON POSITION NAME";
            gdMotorCommon[0, 2] = "SETTING";
            gdMotorCommon[1, 2] = "POSITION";
            gdMotorCommon[1, 3] = "VELOCITY";
            gdMotorCommon[0, 4] = "CURRENT";
            gdMotorCommon[1, 4] = "POSITION";
            gdMotorCommon[1, 5] = "VELOCITY";

            gdMotorCommon.Cols[0].Width = 50;
            gdMotorCommon.Cols[1].Width = 585;
            gdMotorCommon.Cols[2].Width = 150;
            gdMotorCommon.Cols[3].Width = 150;
            gdMotorCommon.Cols[4].Width = 150;
            gdMotorCommon.Cols[5].Width = 150;

            gdMotorCommon.Cols[0].AllowEditing = false;
            gdMotorCommon.Cols[1].AllowEditing = false;
            gdMotorCommon.Cols[2].AllowEditing = false;
            gdMotorCommon.Cols[3].AllowEditing = false;
            gdMotorCommon.Cols[4].AllowEditing = false;
            gdMotorCommon.Cols[5].AllowEditing = false;

            gdMotorCommon.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            CellRange rng = gdMotorCommon.GetCellRange(0, 0, 1, 0);
            gdMotorCommon.MergedRanges.Add(rng);
            rng.Data = "\nNO";

            rng = gdMotorCommon.GetCellRange(0, 1, 1, 1);
            gdMotorCommon.MergedRanges.Add(rng);
            rng.Data = "\nCOMMON POSITION NAME";

            rng = gdMotorCommon.GetCellRange(0, 2, 0, 3);
            gdMotorCommon.MergedRanges.Add(rng);
            //     rng.Data = "SETTING";

            //   rng = gdMotorCommon.GetCellRange(0, 4, 0, 5);
            gdMotorCommon.MergedRanges.Add(gdMotor.GetCellRange(0, 4, 0, 5));
            //      rng.Data = "CURRENT";

            gdMotorCommon.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            gdMotorCommon.Styles.Fixed.Font = new Font("Tahoma", 12, FontStyle.Bold);

            CellStyle csCellStyle = gdMotorCommon.Styles.Add("CellStyle");
            //csCellStyle.BackColor = Color.Bisque;                    // Cell의 바탕색 
            csCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);           // 글자 굵기 굴게
            CellRange crCellRange = gdMotorCommon.GetCellRange(2, 0, 51, 5);       // 적용할 Cell의 영역 설정
            crCellRange.Style = gdMotorCommon.Styles["CellStyle"];              // 설정된 Cell 영역에 Style 적용

            gdMotorCommon.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            gdMotorCommon.Cols[1].TextAlign = TextAlignEnum.LeftCenter;
            gdMotorCommon.Cols[2].TextAlign = TextAlignEnum.RightCenter;
            gdMotorCommon.Cols[3].TextAlign = TextAlignEnum.RightCenter;
            gdMotorCommon.Cols[4].TextAlign = TextAlignEnum.RightCenter;
            gdMotorCommon.Cols[5].TextAlign = TextAlignEnum.RightCenter;

            for (int row = 0; row < gdMotorCommon.Rows.Count; row++)
            {
                gdMotorCommon[row + 2, 0] = row + 50;
                gdMotorCommon[row + 2, 1] = " ";
                gdMotorCommon[row + 2, 2] = "0.000";
                gdMotorCommon[row + 2, 3] = "0";
                gdMotorCommon[row + 2, 4] = "0.000";
                gdMotorCommon[row + 2, 5] = "0";
            }
        }

        private void InitScreen()
        {
            bool bAxisUse;
            string cbAxisName;

            if (SQLiteDB.Select("SELECT * FROM MTCFG", ref SQLiteDB.ReaderMotorCFG))
            {
                for (int iAxis = 0; iAxis < 60; iAxis++)
                {
                    if (SQLiteDB.ReaderMotorCFG.Read())
                    {
                        bAxisUse = (SQLiteDB.ReaderMotorCFG["USESKIP"].ToString() == "True") ? true : false;

                        cbAxisName = string.Format("{0:D2} : {1} ", iAxis + 1, SQLiteDB.ReaderMotorCFG["ITEM"].ToString());
                        if (bAxisUse)
                        {
                            cbMotor.Items.Add(cbAxisName);
                        }
                    }
                }
                cbMotor.SelectedIndex = 0;
                MmiGV.iCurrAxis = cbMotor.SelectedIndex;
                SQLiteDB.ReaderMotorCFG.Close();
            }

            grbJog.Enabled = false;
            pnUNIT.Enabled = false;

            bJogMode = false;
            bModify = false;
        }

        public void LoadMotorSettingData()
        {
            string sSQL1;

            /*
            sSQL1 = "SELECT * FROM MOTOR WHERE DEVICE = ";
            sSQL1 += MmiGV.iDevNo.ToString();
            sSQL1 += " ORDER BY DEVICE ASC, IDX ASC";
            */
            sSQL1 = "SELECT * FROM MOTOR" + MmiGV.iDevNo.ToString();
            sSQL1 += " ORDER BY IDX ASC";
            if (SQLiteDB.Select(sSQL1, ref SQLiteDB.ReaderMotor))
            {
                //while (SQLiteDB.ReaderMotor.Read())
                //{
                //    int iPosNo = int.TryParse(SQLiteDB.ReaderMotor["IDX"].ToString(), out iPosNo) ? iPosNo : 0;
                //    for (int iAxis = 0; iAxis < 60; iAxis++)
                //    {
                //        String id = string.Format("{0:D2}", iAxis + 1);
                //        MmiGV.mtSettingData[iAxis].PosName[iPosNo] = SQLiteDB.ReaderMotor["ITEM" + id].ToString();

                //        double numResult1 = (double.TryParse(SQLiteDB.ReaderMotor["POS" + id].ToString(), out numResult1)) ? numResult1 : 0;
                //        MmiGV.mtSettingData[iAxis].dPosArray[iPosNo] = numResult1;

                //        double numResult2 = (double.TryParse(SQLiteDB.ReaderMotor["SPD" + id].ToString(), out numResult2)) ? numResult2 : 0;
                //        MmiGV.mtSettingData[iAxis].dSpeedArray[iPosNo] = numResult2;
                //    }
                //}

                /////
                for (int iPosNo = 0; iPosNo < 50; iPosNo++)
                {
                    if (SQLiteDB.ReaderMotor.Read())
                    {
                        for (int iAxis = 0; iAxis < 60; iAxis++)
                        {
                            String id = string.Format("{0:D2}", iAxis + 1);

                            MmiGV.mtSettingData[iAxis].PosName[iPosNo]  = SQLiteDB.ReaderMotor["ITEM" + id].ToString();
                            
                            double numResult1 = (double.TryParse(SQLiteDB.ReaderMotor["POS" + id].ToString(), out numResult1)) ? numResult1 : 0;
                            MmiGV.mtSettingData[iAxis].dPosArray[iPosNo] = numResult1;
                            
                            double numResult2 = (double.TryParse(SQLiteDB.ReaderMotor["SPD" + id].ToString(), out numResult2)) ? numResult2 : 0;
                            MmiGV.mtSettingData[iAxis].dSpeedArray[iPosNo] = numResult2;
                        }
                    }
                    else
                    {
                        string sSQL2;
                        sSQL2 = "INSERT INTO MOTOR (DEVICE, IDX) ";
                        sSQL2 += " VALUES (" + (MmiGV.iDevNo).ToString() + "," + (iPosNo).ToString() + ")";

                        SQLiteDB.Execute(sSQL2);
                    }
                }
            }
            else
            {
                string sSQL = "";
                string sField = "";
                sSQL = "CREATE TABLE MOTOR" + MmiGV.iDevNo.ToString() + " ( DEVICE INT, IDX INT,";

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

                //---------------------------------------------------
                string[] InsertData = new string[100];
                int cnt = 0;


                for (cnt = 0; cnt <= 50; cnt++)
                {
                    InsertData[cnt] = " VALUES (" + MmiGV.iDevNo.ToString() + "," + cnt.ToString() + ",";

                    for (int i = 1; i <= 60; i++)
                    {
                        //string strId = string.Format("{0:D2}", i);
                        //sField = "ITEM" + strId;

                        InsertData[cnt] += "'" + " " + "',";
                    }

                    for (int i = 1; i <= 60; i++)
                    {
                        //string strId = string.Format("{0:D2}", i);
                        //sField = "POS" + strId;

                        InsertData[cnt] += "0" + ",";
                    }

                    for (int i = 1; i <= 60; i++)
                    {
                        //string strId = string.Format("{0:D2}", i);
                        //sField = "SPD" + strId;

                        InsertData[cnt] += "0" + ",";
                    }

                    for (int i = 1; i <= 60; i++)
                    {
                        //string strId = string.Format("{0:D2}", i);
                        //sField = "ACC" + strId;

                        if (i == 60)
                        {
                            InsertData[cnt] += "0" + "); ";
                        }
                        else
                        {
                            InsertData[cnt] += "0" + ",";
                        }
                    }

                    sSQL = "INSERT INTO MOTOR" + MmiGV.iDevNo.ToString() + " " + InsertData[cnt];
                    SQLiteDB.Execute(sSQL);
                }
                //------------------------------------------
                /*
                for (int iPosNo = 1; iPosNo < 50; iPosNo++) //(int iPosNo = 0; iPosNo < 50; iPosNo++)
                {
                    string sSQL2;
                    sSQL2 = "INSERT INTO MOTOR (DEVICE, IDX) ";
                    sSQL2 += " VALUES (" + (MmiGV.iDevNo).ToString() + "," + (iPosNo).ToString() + ")";

                    SQLiteDB.Execute(sSQL2);
                }*/
            }


            string sSQL_COMMON;

            sSQL_COMMON = "SELECT * FROM MOTOR_COMMON ORDER BY IDX ASC";
            if (SQLiteDB.Select(sSQL_COMMON, ref SQLiteDB.ReaderMotor))
            {
                for (int iPosNo = 0; iPosNo < 50; iPosNo++)
                {
                    if (SQLiteDB.ReaderMotor.Read())
                    {
                        for (int iAxis = 0; iAxis < 60; iAxis++)
                        {
                            String id = string.Format("{0:D2}", iAxis + 1);

                            MmiGV.mtSettingData[iAxis].PosName[iPosNo + 50] = SQLiteDB.ReaderMotor["ITEM" + id].ToString();

                            double numResult1 = (double.TryParse(SQLiteDB.ReaderMotor["POS" + id].ToString(), out numResult1)) ? numResult1 : 0;
                            MmiGV.mtSettingData[iAxis].dPosArray[iPosNo + 50] = numResult1;
                            double numResult2 = (double.TryParse(SQLiteDB.ReaderMotor["SPD" + id].ToString(), out numResult2)) ? numResult2 : 0;
                            MmiGV.mtSettingData[iAxis].dSpeedArray[iPosNo + 50] = numResult2;
                        }
                    }
                    else
                    {
                        string sSQL2;
                        sSQL2 = "INSERT INTO MOTOR_COMMON (IDX) ";
                        sSQL2 += " VALUES ("  + iPosNo.ToString() + ")";

                        SQLiteDB.Execute(sSQL2);
                    }
                }
            }
            else
            {
                for (int iPosNo = 0; iPosNo < 49; iPosNo++)
                {
                    string sSQL2;
                    sSQL2 = "INSERT INTO MOTOR_COMMON (IDX) ";
                    sSQL2 += " VALUES (" + iPosNo.ToString() + ")";

                    SQLiteDB.Execute(sSQL2);
                }
            }
        }

        public void RefreshData()
        {
            for (int i = 1; i < 50; i++)
            {
                gdMotor[i+1, 1] = MmiGV.mtSettingData[MmiGV.iCurrAxis].PosName[i];
                gdMotor[i+1, 2] = string.Format("{0:F3}", MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[i]);
                gdMotor[i+1, 3] = MmiGV.mtSettingData[MmiGV.iCurrAxis].dSpeedArray[i];
            }


            for (int i = 0; i < 50; i++)
            {
                gdMotorCommon[i + 2, 1] = MmiGV.mtSettingData[MmiGV.iCurrAxis].PosName[i+50];
                gdMotorCommon[i + 2, 2] = string.Format("{0:F3}", MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[i + 50]);
                gdMotorCommon[i + 2, 3] = MmiGV.mtSettingData[MmiGV.iCurrAxis].dSpeedArray[i + 50];
            }
        }

        public void SaveData()
        {
            for (int i = 1; i < 50; i++)//50
            {
                MmiGV.mtSettingData[MmiGV.iCurrAxis].PosName[i] = gdMotor[i + 1, 1].ToString();

                //    Console.WriteLine("{0}", gdMotor[i + 2, 1].ToString());
                double numResult1 = (double.TryParse(gdMotor[i + 1, 2].ToString(), out numResult1)) ? numResult1 : 0;
                MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[i] = numResult1;

                double numResult2 = (double.TryParse(gdMotor[i + 1, 3].ToString(), out numResult2)) ? numResult2 : 0;
                MmiGV.mtSettingData[MmiGV.iCurrAxis].dSpeedArray[i] = numResult2;
            }
            for (int i = 0; i < 50; i++)
            {
                MmiGV.mtSettingData[MmiGV.iCurrAxis].PosName[i + 50] = gdMotorCommon[i + 2, 1].ToString();

                //    Console.WriteLine("{0}", gdMotor[i + 2, 1].ToString());
                double numResult3 = (double.TryParse(gdMotorCommon[i + 2, 2].ToString(), out numResult3)) ? numResult3 : 0;
                MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[i+50] = numResult3;

                double numResult4 = (double.TryParse(gdMotorCommon[i + 2, 3].ToString(), out numResult4)) ? numResult4 : 0;
                MmiGV.mtSettingData[MmiGV.iCurrAxis].dSpeedArray[i + 50] = numResult4;
            }

            string strSQL1;
            for (int i = 1; i < 50; i++)//50
            {
                string id = string.Format("{0:D2}", i);
                string sAxis = string.Format("{0:D2}", MmiGV.iCurrAxis + 1);
                string sPosName = MmiGV.mtSettingData[MmiGV.iCurrAxis].PosName[i].ToString();

                string sPos = MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[i].ToString();
                string sSpd = MmiGV.mtSettingData[MmiGV.iCurrAxis].dSpeedArray[i].ToString();


                strSQL1 = "UPDATE MOTOR" + MmiGV.iDevNo.ToString() + " SET ";
                strSQL1 += " ITEM" + sAxis + "=";
                strSQL1 += "'" + sPosName + "'" + ",";
                strSQL1 += " POS" + sAxis + "=";
                strSQL1 += "'" + sPos + "'" + ",";
                strSQL1 += " SPD" + sAxis + "=";
                strSQL1 += "'" + sSpd + "'";
                strSQL1 += " WHERE DEVICE=" + MmiGV.iDevNo.ToString();
                strSQL1 += " AND IDX=" + i.ToString();

                SQLiteDB.Execute(strSQL1);
            }

            string strSQL2;
            for (int i = 0; i < 50; i++)
            {
                string id2 = string.Format("{0:D2}", i + 50);
                string sAxis2 = string.Format("{0:D2}", MmiGV.iCurrAxis + 1);
                string sPosName2 = MmiGV.mtSettingData[MmiGV.iCurrAxis].PosName[i + 50].ToString();

                string sPos2 = MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[i + 50].ToString();
                string sSpd2 = MmiGV.mtSettingData[MmiGV.iCurrAxis].dSpeedArray[i + 50].ToString();

                strSQL2 = "UPDATE MOTOR_COMMON SET ";
                strSQL2 += " ITEM" + sAxis2 + "=";
                strSQL2 += "'" + sPosName2 + "'" + ",";
                strSQL2 += " POS" + sAxis2 + "=";
                strSQL2 += "'" + sPos2 + "'" + ",";
                strSQL2 += " SPD" + sAxis2 + "=";
                strSQL2 += "'" + sSpd2 + "'";
                strSQL2 += " WHERE IDX=" + i.ToString();

                SQLiteDB.Execute(strSQL2);
            }

            for (int i = 0; i < 100; i++)
            {
                double dPos = MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[i] * MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
                MmiGV.mtData[MmiGV.iCurrAxis].iPosArray[i] = dPos;
                    
                double dSpeed = MmiGV.mtSettingData[MmiGV.iCurrAxis].dSpeedArray[i] * MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
                MmiGV.mtData[MmiGV.iCurrAxis].iSpeedArray[i] = dSpeed;
            }
            MmiGV.pShMem.WMotorData.uAxisNo = MmiGV.iCurrAxis;
            MmiGV.pShMem.WMotorData.uPos = MmiGV.mtData[MmiGV.iCurrAxis].iPosArray;
            MmiGV.pShMem.WMotorData.uVel = MmiGV.mtData[MmiGV.iCurrAxis].iSpeedArray;
            MmiGV.pShMem.SetMotorData();
            RefreshData();

        }
        

        private void cbMotor_DropDownChange(object sender, bool Expanded)
        {
            MmiGV.iCurrAxis = cbMotor.SelectedIndex;
            LoadMotorSettingData();
            RefreshData();
        }

        private void cbMotor_SelectedIndexChanged(object sender, EventArgs e)
        {
            MmiGV.iCurrAxis = cbMotor.SelectedIndex;
            
            bTenkeyJogMode = false;
            btnTenkeyJog.Checked = false;

            LoadMotorSettingData();
            RefreshData();
        }

        private void btnUnitEnable_Click(object sender, EventArgs e)
        {
            pnUNIT.Enabled = true;

            btnUnitEnable.Checked = true;
            btnJogEnable.Checked = false;
        }
        private void btnJogEnable_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            pnUNIT.Enabled = false;

            btnUnitEnable.Checked = false;
            btnJogEnable.Checked = true;
        }

        private void btnUnitPlusClick(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            DevComponents.DotNetBar.ButtonX btn = sender as DevComponents.DotNetBar.ButtonX;

            int iTag = int.Parse(btn.Tag.ToString());

            double dStepVal = double.Parse(lblUnitValue.Text);

            if (iTagBackup != iTag)
            {
                dStepVal = 0.0;
            }
            switch (iTag)
            {
                case 0:     // +0.01
                    dStepVal += 0.01;
                    if (dStepVal > 0.09)
                    {
                        dStepVal = 0.01;
                    }
                    break;
                case 1:     // +0.1
                    dStepVal += 0.10;
                    if (dStepVal > 0.9)
                    {
                        dStepVal = 0.1;
                    }
                    break;
                case 2:     // +1.0
                    dStepVal += 1.00;
                    if (dStepVal > 9.0)
                    {
                        dStepVal = 1.0;
                    }
                    break;
                case 3:     // +10.0
                    dStepVal += 10.0;
                    if (dStepVal > 90.0)
                    {
                        dStepVal = 10.0;
                    }
                    break;
                case 4:     // +100.0
                    dStepVal += 100.0;
                    if (dStepVal > 900.0)
                    {
                        dStepVal = 100.0;
                    }
                    break;
            }
            lblUnitValue.Text = string.Format("{0:F2}", dStepVal);
            iTagBackup = iTag;
        }

        private void btnUnitMinusClick(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            DevComponents.DotNetBar.ButtonX btn = sender as DevComponents.DotNetBar.ButtonX;

            int iTag = int.Parse(btn.Tag.ToString());

            double dStepVal = double.Parse(lblUnitValue.Text);

            if (iTagBackup != iTag)
            {
                dStepVal = 0.0;
            }

            switch (iTag)
            {
                case 0:     // -0.01
                    dStepVal -= 0.01;
                    if (dStepVal < 0.01)
                    {
                        dStepVal = 0.09;
                    }
                    break;
                case 1:     // -0.1
                    dStepVal -= 0.10;
                    if (dStepVal < 0.1)
                    {
                        dStepVal = 0.9;
                    }
                    break;
                case 2:     // -1.0
                    dStepVal -= 1.00;
                    if (dStepVal < 1.0)
                    {
                        dStepVal = 9.0;
                    }
                    break;
                case 3:     // -10.0
                    dStepVal -= 10.0;
                    if (dStepVal < 10.0)
                    {
                        dStepVal = 90.0;
                    }
                    break;
                case 4:     // -100.0
                    dStepVal -= 100.0;
                    if (dStepVal < 100.0)
                    {
                        dStepVal = 900.0;
                    }
                    break;
            }
            lblUnitValue.Text = string.Format("{0:F2}", dStepVal);
            iTagBackup = iTag;
        }

        private void btnJogMode_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            btnJogMode.Checked = !btnJogMode.Checked;

            bJogMode = btnJogMode.Checked;

            if (!bJogMode)
            {
                grbJog.Enabled = false;
            }
            else
            {
                grbJog.Enabled = true;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            btnEdit.Checked = !btnEdit.Checked;

            bModify = btnEdit.Checked;

            if (bModify)
            {
                gdMotor.Cols[1].AllowEditing = true;
                gdMotor.Cols[1].StyleNew.BackColor = Color.White;
                gdMotor.Cols[2].StyleNew.BackColor = Color.White;
                gdMotor.Cols[3].StyleNew.BackColor = Color.White;

                gdMotorCommon.Cols[1].AllowEditing = true;
                gdMotorCommon.Cols[1].StyleNew.BackColor = Color.White;
                gdMotorCommon.Cols[2].StyleNew.BackColor = Color.White;
                gdMotorCommon.Cols[3].StyleNew.BackColor = Color.White;
            }
            else
            {
                gdMotor.Cols[1].AllowEditing = false;
                gdMotor.Cols[1].StyleNew.BackColor = Color.Bisque;
                gdMotor.Cols[2].StyleNew.BackColor = Color.Bisque;
                gdMotor.Cols[3].StyleNew.BackColor = Color.Bisque;

                gdMotorCommon.Cols[1].AllowEditing = false;
                gdMotorCommon.Cols[1].StyleNew.BackColor = Color.Bisque;
                gdMotorCommon.Cols[2].StyleNew.BackColor = Color.Bisque;
                gdMotorCommon.Cols[3].StyleNew.BackColor = Color.Bisque;
            }

            gdMotor.Refresh();
            gdMotorCommon.Refresh();
        }

        private void btnSavePos_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            btnSavePos.Enabled = false;
            SaveData();
            btnEdit.Checked = true;
            btnEdit.PerformClick();
            btnSavePos.Enabled = true;
        }
        
        private void btnMoveMouseDown(object sender, MouseEventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (bTenkeyJogMode)
            {
                frmMain.frm_Msg.Display("Ten Key Jog Button Checked.\n Uncheck Ten Key Jog Button");
                return;
            }

            DevComponents.DotNetBar.ButtonX pButton;
            pButton = sender as DevComponents.DotNetBar.ButtonX;

            int iTag = int.Parse(pButton.Tag.ToString());

            uint Velocity = uint.TryParse(txtVelocity.Text, out Velocity) ? Velocity : 10;
            txtVelocity.Text = Velocity.ToString();

            if (bJogMode)
            {
                if (btnJogEnable.Checked)
                {
                    //MmiGV.pShMem.SetMotorVelocityMove(MmiGV.iCurrAxis, iTag, MmiGV.mtConfigData[MmiGV.iCurrAxis].uJogVel);
                    MmiGV.pShMem.SetMotorVelocityMove(MmiGV.iCurrAxis, iTag, Velocity);
                }
                else if (btnUnitEnable.Checked)
                {
                    double dPos = double.Parse(lblUnitValue.Text) * MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
                    if (iTag == 0)
                    {
                        dPos *= (-1.0);
                    }
                    //MmiGV.pShMem.SetMotorRelativeMove(MmiGV.iCurrAxis, (int)dPos, MmiGV.mtConfigData[MmiGV.iCurrAxis].uJogVel);
                    MmiGV.pShMem.SetMotorRelativeMove(MmiGV.iCurrAxis, (int)dPos, Velocity);
                }
            }
        }

        private void btnMoveMouseUp(object sender, MouseEventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (btnJogEnable.Checked)
            {
                MmiGV.pShMem.SetMotorStop(MmiGV.iCurrAxis);
            }
        }

        private void btnMoveMMouseLeave(object sender, EventArgs e)
        {
            if (btnJogEnable.Checked)
            {
                MmiGV.pShMem.SetMotorStop(MmiGV.iCurrAxis);
            }
        }

        private void btmMTS_SERVO_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            //if (bJogMode)
            {
                MmiGV.pShMem.SetServoOnOff(MmiGV.iCurrAxis);
            }
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            frmMain.frm_MotorCalc.ShowDialog(this);
        }

        private void gdMotor_Click(object sender, EventArgs e)
        {
            if (gdMotor.Row >= 2)
            {
                lblIdx.Text = string.Format("{0:D2}", int.Parse(gdMotor[gdMotor.Row, 0].ToString()));
            }
            bgdMotorSelected = true;
            bgdMotorCommonSelected = false;
        }
        private void gdMotor_DoubleClick(object sender, EventArgs e)
        {
            double dPosData = 0.0;
            double dVelData = 0.0;

            if (gdMotor.Row >= 2)
            {
                lblIdx.Text = string.Format("{0:D2}", int.Parse(gdMotor[gdMotor.Row, 0].ToString()));
            }

            if (bModify)
            {
                switch (gdMotor.Col)
                {
                    case 2:     // Motor Position 수정
                        dPosData = double.Parse(gdMotor[gdMotor.Row, 2].ToString());
                        if (frmMain.frm_NumAdd.Display(dPosData))
                        {
                            String str = string.Format("{0:F3}", frmMain.frm_NumAdd.GetValue());
                            gdMotor[gdMotor.Row, 2] = str;
                        }
                        break;
                    case 3:     // Motor Speed 수정
                        if (frmMain.frm_NumPad.Display())
                        {
                            dVelData = frmMain.frm_NumPad.GetValue();
                            //if(dVelData >= GV.mtcfg[GV.iCurrAxis].MaxVel)
                            //{
                            //    dVelData = GV.mtcfg[GV.iCurrAxis].MaxVel;
                            //}
                            gdMotor[gdMotor.Row, 3] = (int)dVelData;
                        }
                        break;
                }
            }
            gdMotor.Refresh();
        }

        private void gdMotorCommon_Click(object sender, EventArgs e)
        {
            if (gdMotorCommon.Row >= 2)
            {
                lblIdx.Text = string.Format("{0:D2}", int.Parse(gdMotorCommon[gdMotorCommon.Row, 0].ToString()));
            }
            bgdMotorSelected = false;
            bgdMotorCommonSelected = true;
        }

        private void gdMotorCommon_DoubleClick(object sender, EventArgs e)
        {
            double dPosData = 0.0;
            double dVelData = 0.0;

            if (gdMotorCommon.Row >= 2)
            {
                lblIdx.Text = string.Format("{0:D2}", int.Parse(gdMotorCommon[gdMotorCommon.Row, 0].ToString()));
            }

            if (bModify)
            {
                switch (gdMotorCommon.Col)
                {
                    case 2:     // Motor Position 수정
                        dPosData = double.Parse(gdMotorCommon[gdMotorCommon.Row, 2].ToString());
                        if (frmMain.frm_NumAdd.Display(dPosData))
                        {
                            String str = string.Format("{0:F3}", frmMain.frm_NumAdd.GetValue());
                            gdMotorCommon[gdMotorCommon.Row, 2] = str;
                        }
                        break;
                    case 3:     // Motor Speed 수정
                        if (frmMain.frm_NumPad.Display())
                        {
                            dVelData = frmMain.frm_NumPad.GetValue();
                            //if(dVelData >= GV.mtcfg[GV.iCurrAxis].MaxVel)
                            //{
                            //    dVelData = GV.mtcfg[GV.iCurrAxis].MaxVel;
                            //}
                            gdMotorCommon[gdMotorCommon.Row, 3] = (int)dVelData;
                        }
                        break;
                }
            }
            gdMotorCommon.Refresh();
        }

        private void btnTenkeyJog_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (bTenkeyJogMode || MmiGV.frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
            {
                bTenkeyJogMode = !bTenkeyJogMode;
                btnTenkeyJog.Checked = bTenkeyJogMode;

                MmiGV.pShMem.SetTenKeyJog(MmiGV.iCurrAxis, bTenkeyJogMode);
            }
        }

        private void btnIDXWrite_Click(object sender, EventArgs e)
        {
            double dData = Convert.ToDouble(lblCurrentPosition.Text);

            if (MmiGV.frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
            {
                if (bgdMotorSelected)
                {
                    int idx = Convert.ToInt32(lblIdx.Text);
                    MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[idx - 1] = dData;
                    gdMotor[gdMotor.Row, 2] = $"{dData:0.000}";
                }
                else if(bgdMotorCommonSelected)
                {
                    int idx = Convert.ToInt32(lblIdx.Text);
                    MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[idx - 1] = dData;
                    gdMotorCommon[gdMotorCommon.Row, 2] = $"{dData:0.000}";
                }
            }
        }

        private void btnMoveIndex_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (bTenkeyJogMode)
            {
                frmMain.frm_Msg.Display("Ten Key Jog Button Checked.\n Uncheck Ten Key Jog Button");
                return;
            }

            if (frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
            {
                if (bJogMode)
                {
                    int idx = Convert.ToInt32(lblIdx.Text);
                    if (idx > 0 && idx < 100)
                    {
                        MmiGV.pShMem.SetMotorAbsoluteMove(MmiGV.iCurrAxis, idx);
                    }
                }
            }
        }

        private void txtVelocity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsDigit(e.KeyChar)|| e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }     
        }

        private void btnMTS_HOME_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (bTenkeyJogMode)
            {
                frmMain.frm_Msg.Display("Ten Key Jog Button Checked.\n Uncheck Ten Key Jog Button");
                return;
            }
            MmiGV.pShMem.SetServoHome(MmiGV.iCurrAxis);
        }

        private void bntMTS_ALARM_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            MmiGV.pShMem.SetServoAlarmClear(MmiGV.iCurrAxis);
        }

        
    }
}
