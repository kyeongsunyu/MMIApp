using DevComponents.Instrumentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace MMI
{
    public partial class Form_MotorCalc : Form
    {
        private FormMain frmMain = null;
        private int iCol = 0;
        private int iRow = 0;
        private int iStartNo = 0;
        private int iEndNo = 0;
        private int iSpeed = 0;
        private int iAccel = 0;
        private double dBaseSet;
        private double dOffSet;
        public Form_MotorCalc()
        {
            InitializeComponent();
        }
        public Form_MotorCalc(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

        }

        private void Form_MotorCalc_Load(object sender, EventArgs e)
        {
            InitGrid();
            InitScreen();
        }

        private void InitGrid()
        {
            gdCalc.Cols[0].Width = 150;
            gdCalc.Cols[1].Width = 150;

            gdCalc[0, 0] = "START RECORD";
            gdCalc[1, 0] = "END RECORD";
            gdCalc[2, 0] = "BASE (mm)";
            gdCalc[3, 0] = "OFFSET (mm)";
            gdCalc[4, 0] = "SPEED(PPS)";
            //gdCalc[5, 0] = "Accel/Decel";
        }
        private void InitScreen()
        {
            iCol = frmMain.frmMotorSetting.gdMotor.Col;
            string str = frmMain.frmMotorSetting.gdMotor[frmMain.frmMotorSetting.gdMotor.Row,0].ToString();
            iRow = int.Parse(frmMain.frmMotorSetting.gdMotor[frmMain.frmMotorSetting.gdMotor.Row,0].ToString());

            gdCalc[0,1] = iRow;
            gdCalc[1,1] = 49;
            gdCalc[2, 1] = string.Format("{0:F3}", MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[iRow]);
            gdCalc[3,1] = "0";
            gdCalc[4, 1] = string.Format("{0:F3}", MmiGV.mtSettingData[MmiGV.iCurrAxis].dSpeedArray[iRow]);

            gdCalc[5,1] = "0";

            rd1.Checked = true;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            double dTmp = 0.0;

            iStartNo    = (int.TryParse(gdCalc[0,1].ToString(), out iStartNo)) ? iStartNo : 0;
            iEndNo      = (int.TryParse(gdCalc[1,1].ToString(), out iEndNo)) ? iEndNo : 0;
            dBaseSet    = (double.TryParse(gdCalc[2,1].ToString(), out dBaseSet)) ? dBaseSet : 0;
            dOffSet     = (double.TryParse(gdCalc[3,1].ToString(), out dOffSet)) ? dOffSet : 0;
            iSpeed      = (int.TryParse(gdCalc[4,1].ToString(), out iSpeed)) ? iSpeed : 0;  
            iAccel      = (int.TryParse(gdCalc[5,1].ToString(), out iAccel)) ? iAccel : 0;

            if (rd1.Checked)    //-- base + offset  
            {   
                for(int i=iStartNo;i<=iEndNo; i++)
                {
                    MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[i] = dBaseSet + dTmp;
                    dTmp += dOffSet;
                }
            }
            else if(rd2.Checked)    //-- current + offset
            {
                for (int i = iStartNo; i <= iEndNo; i++)
                {
                    MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[i] = MmiGV.mtSettingData[MmiGV.iCurrAxis].dPosArray[i - 1] + dOffSet;
                }
            }
            else if (rd3.Checked)   //-- Speed
            {
                for (int i = iStartNo; i <= iEndNo; i++)
                {
                    MmiGV.mtSettingData[MmiGV.iCurrAxis].dSpeedArray[i] = iSpeed;
                }
            }
            else if(rd4.Checked)    //-- Accel/Decel
            {
                for (int i = iStartNo; i <= iEndNo; i++)
                {
                    MmiGV.mtSettingData[MmiGV.iCurrAxis].dAccelArray[i] = iAccel;
                    MmiGV.mtSettingData[MmiGV.iCurrAxis].dDecelArray[i] = iAccel;
                }
            }
            else if (rd5.Checked)
            {
                int iIndex = 0;
                string sSQL = "", sTitle = "";
                for (int i = iStartNo; i <= iEndNo; i++)
                {
                    iIndex++;
                    if (!string.IsNullOrEmpty(txtItem.Text))
                    {
                        sTitle = txtItem.Text + " " + string.Format("{0:D2}", iIndex);
                        MmiGV.strPosName[MmiGV.iCurrAxis, i] = sTitle;

                        sSQL = "UPDATE MOTOR SET ";
                        sSQL += "ITEM" + string.Format("{0:D2}", MmiGV.iCurrAxis + 1) + "='";
                        sSQL += sTitle + " '";
                        sSQL += " WHERE DEVICE = " + MmiGV.iDevNo.ToString();
                        sSQL += " AND IDX=" + i.ToString();
                        SQLiteDB.Execute(sSQL);
                    }
                }
            }
            frmMain.frmMotorSetting.RefreshData();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void gdCalc_Click(object sender, EventArgs e)
        {
            int iStartRow = 0;
            if (gdCalc.Col == 1)
            {
                switch (gdCalc.Row)
                {
                    case 0: // START RECORD
                        if (frmMain.frm_NumPad.Display())
                        {
                            gdCalc[gdCalc.Row, gdCalc.Col] = frmMain.frm_NumPad.GetValue();
                            iStartRow = int.TryParse(gdCalc[gdCalc.Row, gdCalc.Col].ToString(), out iStartRow) ? iStartRow : 1;
                        }
                        break;
                    case 1: // END RECORD
                        if (frmMain.frm_NumPad.Display())
                        {
                            gdCalc[gdCalc.Row, gdCalc.Col] = frmMain.frm_NumPad.GetValue();
                        }
                        break;
                    case 2: // BASE (mm)
                        if (frmMain.frm_NumPad.Display())
                        {
                            gdCalc[gdCalc.Row, gdCalc.Col] = frmMain.frm_NumPad.GetValue();
                        }
                        break;
                    case 3: // OFFSET (mm)
                        if (frmMain.frm_NumPad.Display())
                        {
                            gdCalc[gdCalc.Row, gdCalc.Col] = frmMain.frm_NumPad.GetValue();
                        }
                        break;
                    case 4: // SPEED(mm/s)
                        if (frmMain.frm_NumPad.Display())
                        {
                            gdCalc[gdCalc.Row, gdCalc.Col] = frmMain.frm_NumPad.GetValue();
                        }
                        break;
                }
            }
        }
    }
}
