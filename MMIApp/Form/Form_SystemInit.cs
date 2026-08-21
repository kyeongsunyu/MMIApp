using DevComponents.DotNetBar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static C1.Util.Win.Win32;

namespace MMI
{
    public partial class Form_SystemInit : Form
    {
        private FormMain frmMain = null;
        int iPercent = 0;

        public Form_SystemInit()
        {
            InitializeComponent();
        }
        public Form_SystemInit(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
            this.TopMost = true;
            this.TopLevel = true;

        }

        public void SystemInitialize()
        {
            MethodInvoker miShow = new MethodInvoker(this.Show);
            frmMain.Invoke(miShow);

            frmMain.lblError.Invoke(new Action(() =>
            {
                frmMain.lblError.Text = " System Initializing...";
            }));
            Application.DoEvents();

            iPercent = 0;
            UpdateProgressBar(iPercent);

            #region MACHINE_PARAM
            UpdateTitle("MACHINE PARAMETER Loading");
            string strSQL_MachineParam = "SELECT * FROM MACHINEPARAM ORDER BY IDX ASC";
            if (SQLiteDB.Select(strSQL_MachineParam, ref SQLiteDB.ReaderMachineParam))
            {
                while (SQLiteDB.ReaderMachineParam.Read())
                {
                    int idx = Convert.ToInt32(SQLiteDB.ReaderMachineParam["IDX"]);
                    string name = string.Format("{0}", SQLiteDB.ReaderMachineParam["ITEM"]);
                    double val = Convert.ToDouble(SQLiteDB.ReaderMachineParam["DATA"]);

                    MmiGV.pShMem.WSystemData.dData[idx] = val;
                }
                MmiGV.pShMem.SetSystemData();
            }
            SQLiteDB.ReaderMachineParam.Close();
            iPercent += 5;
            UpdateProgressBar(iPercent);

            #endregion MACHINE_PARAM

            #region RECIPE_DATA_INIT
            UpdateTitle("RECIPE DATA Loading");
            //string strSQL_Recipe = "SELECT * FROM DEVICE WHERE CURR_MARK = '**' ORDER BY IDX ASC";
            //string strSQL_Recipe = "SELECT FROM DEVICE WHERE CURR_MARK = '**' ORDER BY IDX ASC";
            //if (SQLiteDB.Select(strSQL_Recipe, ref SQLiteDB.ReaderDeviceData))
            //{
            //    if (SQLiteDB.ReaderDeviceData.Read())
            //    {
            //        MmiGV.iDevNo =  int.TryParse(SQLiteDB.ReaderDeviceData["IDX"].ToString(), out MmiGV.iDevNo ) ? MmiGV.iDevNo : 0;
            //        MmiGV.strCurrentDevName = (string)SQLiteDB.ReaderDeviceData["DEVICE_NAME"];
            //        for (int i = 0; i < MmiGV.NumOf_DeviceData; i++)
            //        {
            //            string id = string.Format("{0:D3}", i + 1);
            //            MmiGV.strDeviceData[MmiGV.iDevNo, i] = SQLiteDB.ReaderDeviceData["DATA" + id].ToString();
            //            double numResult;
            //            MmiGV.dDeviceData[MmiGV.iDevNo, i] = (double.TryParse(SQLiteDB.ReaderDeviceData["DATA" + id].ToString(), out numResult)) ? numResult : 0.0;
            //        }
            //    }
            //    SQLiteDB.ReaderDeviceData.Close();

            //    frmMain.lblDevice.Invoke(new Action(() =>
            //    {
            //        frmMain.lblDevice.Text = $"[{MmiGV.iDevNo:D2}] {MmiGV.strCurrentDevName}";
            //    }));

            //    MmiGV.pShMem.WDeviceInfo.nDeviceNumber = MmiGV.iDevNo;
            //    MmiGV.pShMem.WDeviceInfo.strDeviceName = MmiGV.strCurrentDevName;
            //    MmiGV.pShMem.SetDeviceInfo();
            //}
            CRecipeCtl.MainRecipeLoad();
            //WriteRecipeData();
            iPercent += 15;
            UpdateProgressBar(iPercent);
            #endregion RECIPE_DATA_INIT

            #region MOTOR_CONFIG_INIT
            UpdateTitle("MOTOR CONFIG DATA Loading");
            string strSQL_MotorCFG = "SELECT * FROM MTCFG ORDER BY IDX ASC";

            //string strSQL_MotorCFG = "SELECT FROM MTCFG ORDER BY IDX ASC";
            if (SQLiteDB.Select(strSQL_MotorCFG, ref SQLiteDB.ReaderMotorCFG))
            {
                var ord_ITEM = SQLiteDB.ReaderMotorCFG.GetOrdinal("ITEM");
                var ord_RATE = SQLiteDB.ReaderMotorCFG.GetOrdinal("RATE");

                for (int iAxis=0;iAxis < 60; iAxis++)
                {
                    if (SQLiteDB.ReaderMotorCFG.Read())
                    {
                        MmiGV.mtConfigData[iAxis].uUse = (SQLiteDB.ReaderMotorCFG["USESKIP"].ToString() == "True") ? (uint)1 : 0;
                        if (MmiGV.mtConfigData[iAxis].uUse == 1)
                        {
                            MmiGV.mtConfigData[iAxis].uAxisNo = (uint)iAxis;
                            MmiGV.strAxisName[iAxis] = SQLiteDB.ReaderMotorCFG["ITEM"].ToString();
                            MmiGV.mtConfigData[iAxis].uPulseRate = Convert.ToUInt32(SQLiteDB.ReaderMotorCFG["RATE"].ToString());
                            MmiGV.mtConfigData[iAxis].uMaxSpeed = Convert.ToUInt32(SQLiteDB.ReaderMotorCFG["MAX_SPEED"].ToString());
                            MmiGV.mtConfigData[iAxis].uJogVel = Convert.ToUInt32(SQLiteDB.ReaderMotorCFG["JOG_SPEED"].ToString());
                            MmiGV.mtConfigData[iAxis].uHomeVel = Convert.ToUInt32(SQLiteDB.ReaderMotorCFG["HOME_SPEED"].ToString());
                            MmiGV.mtConfigData[iAxis].uMotorType = Convert.ToUInt32(SQLiteDB.ReaderMotorCFG["MOTOR_TYPE"].ToString());
                        }
                    }
                }
                SQLiteDB.ReaderMotorCFG.Close();
            }

            WriteMotorConfigData();
            iPercent += 15;
            UpdateProgressBar(iPercent);
            #endregion MOTOR_CONFIG_INIT

            #region MOTOR_DATA
            UpdateTitle("MOTOR DATA Loading");
            string strSQL_MotorData = "SELECT * FROM MOTOR" + MmiGV.iDevNo.ToString();
            strSQL_MotorData += " ORDER BY IDX ASC";
            if (SQLiteDB.Select(strSQL_MotorData, ref SQLiteDB.ReaderMotor))
            {
                for (int iPosNo = 0; iPosNo < 50; iPosNo++)
                {
                    if (SQLiteDB.ReaderMotor.Read())
                    {
                        for (int iAxis = 0; iAxis < 60; iAxis++)
                        {
                            String id = string.Format("{0:D2}", iAxis + 1);
                            MmiGV.mtData[iAxis].PosName[iPosNo] = SQLiteDB.ReaderMotor["ITEM" + id].ToString();
                            double dPos = double.Parse(SQLiteDB.ReaderMotor["POS" + id].ToString()) * MmiGV.mtConfigData[iAxis].uPulseRate;
                            MmiGV.mtData[iAxis].iPosArray[iPosNo] = dPos;
                            double dSpeed = double.Parse(SQLiteDB.ReaderMotor["SPD" + id].ToString()) * MmiGV.mtConfigData[iAxis].uPulseRate;
                            MmiGV.mtData[iAxis].iSpeedArray[iPosNo] = dSpeed;

                        }
                    }
                }
                SQLiteDB.ReaderMotor.Close();
            }

            string strSQL_MotorCommonData = "SELECT * FROM MOTOR_COMMON ORDER BY IDX ASC";
            if (SQLiteDB.Select(strSQL_MotorCommonData, ref SQLiteDB.ReaderMotor))
            {
                for (int iPosNo = 0; iPosNo < 50; iPosNo++)
                {
                    if (SQLiteDB.ReaderMotor.Read())
                    {
                        for (int iAxis = 0; iAxis < 60; iAxis++)
                        {
                            String id = string.Format("{0:D2}", iAxis + 1);
                            MmiGV.mtData[iAxis].PosName[iPosNo + 50] = SQLiteDB.ReaderMotor["ITEM" + id].ToString();
                            double dPos = double.Parse(SQLiteDB.ReaderMotor["POS" + id].ToString()) * MmiGV.mtConfigData[iAxis].uPulseRate;
                            MmiGV.mtData[iAxis].iPosArray[iPosNo + 50] = (int)dPos;
                            double dSpeed = double.Parse(SQLiteDB.ReaderMotor["SPD" + id].ToString()) * MmiGV.mtConfigData[iAxis].uPulseRate;
                            MmiGV.mtData[iAxis].iSpeedArray[iPosNo + 50] = (int)dSpeed;
                        }
                    }
                }
                SQLiteDB.ReaderMotor.Close();
            }

            WriteMotorData();

            iPercent += 20;
            UpdateProgressBar(iPercent);
            #endregion MOTOR_DATA

            #region DM_DATA
            UpdateTitle("DATA MEMORY Loading");
            string strSQL_DM = "SELECT * FROM DATAMEM ORDER BY IDX ASC";
            if (SQLiteDB.Select(strSQL_DM, ref SQLiteDB.ReaderDM))
            {
                for (int i = 0; i < 300; i++)
                {
                    if (SQLiteDB.ReaderDM.Read())
                    {
                        MmiGV.dmData.DMName[i] = SQLiteDB.ReaderDM["DMNAME"].ToString();
                        uint numResult=0;
                        MmiGV.dmData.DMSave[i] = (uint.TryParse(SQLiteDB.ReaderDM["DMSAVE"].ToString(), out numResult)) ? numResult : 0;
                        if (SQLiteDB.ReaderDM["DMSAVE"].ToString() == "1")
                        {
                            string str = SQLiteDB.ReaderDM["DMVALUE"].ToString();
                            if (str == null || str == "")
                            {
                                MmiGV.dmData.DMValue[i] = 0;
                            }
                            else
                            {
                                MmiGV.dmData.DMValue[i] = Convert.ToUInt32(SQLiteDB.ReaderDM["DMVALUE"].ToString());
                            }
                        }
                    }
                }
                SQLiteDB.ReaderDM.Close();
            }

            WriteDMData();
            iPercent += 15;
            UpdateProgressBar(iPercent);
            #endregion DM_DATA

            #region USE_SKIP_INIT
            UpdateTitle("USE SKIP Data Loading");

            //string strSQL_USESKIP = "SELECT * FROM USESKIP";
            string strSQL_USESKIP = "SELECT * FROM USESKIP";
            if(SQLiteDB.Select(strSQL_USESKIP, ref SQLiteDB.ReaderUseSkip))
            {
                if (SQLiteDB.ReaderUseSkip.Read())
                {
                    uint uUseSkip1 = uint.TryParse(SQLiteDB.ReaderUseSkip["USESKIP1"].ToString(), out uUseSkip1) ? uUseSkip1 : 0;
                    var mINArray1 = new BitArray(BitConverter.GetBytes(uUseSkip1));
                    mINArray1.CopyTo(MmiGV.UseSkipData.bUseSkip1,0);
                    MmiGV.dmData.DMValue[16] = uUseSkip1;

                    uint uUseSkip2 = uint.TryParse(SQLiteDB.ReaderUseSkip["USESKIP2"].ToString(), out uUseSkip2) ? uUseSkip2 : 0;
                    var mINArray2 = new BitArray(BitConverter.GetBytes(uUseSkip2));
                    mINArray2.CopyTo(MmiGV.UseSkipData.bUseSkip2, 0);
                    MmiGV.dmData.DMValue[17] = uUseSkip2;
                }
                SQLiteDB.ReaderUseSkip.Close();
            }

            WriteUseSkipData();
            iPercent += 15;
            UpdateProgressBar(iPercent);
            #endregion USE_SKIP_INIT

            #region LAMP_BUZZER_INIT
            UpdateTitle("LAMP BUZZER Data Loading");
            string strSQL_LampBuzzer = "SELECT * FROM LAMPBUZZER ORDER BY IDX ASC";
            if (SQLiteDB.Select(strSQL_LampBuzzer, ref SQLiteDB.ReaderLampBuzzer))
            {
                int i = 0;
                while (SQLiteDB.ReaderLampBuzzer.Read())
                {
                    string str = SQLiteDB.ReaderLampBuzzer["IDX"].ToString();
                    if (str == "999")
                    {
                        MmiGV.LampBuzzerData[998, 0] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_RED"].ToString());
                        MmiGV.LampBuzzerData[998, 1] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_YELLOW"].ToString());
                        MmiGV.LampBuzzerData[998, 2] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_GREEN"].ToString());
                        MmiGV.LampBuzzerData[998, 3] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_COUNT"].ToString());
                        MmiGV.LampBuzzerData[998, 4] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_ONTIME"].ToString());
                        MmiGV.LampBuzzerData[998, 5] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_OFFTIME"].ToString());
                    }
                    else if (str == "1000")
                    {
                        MmiGV.LampBuzzerData[999, 0] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_RED"].ToString());
                        MmiGV.LampBuzzerData[999, 1] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_YELLOW"].ToString());
                        MmiGV.LampBuzzerData[999, 2] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_GREEN"].ToString());
                        MmiGV.LampBuzzerData[999, 3] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_COUNT"].ToString());
                        MmiGV.LampBuzzerData[999, 4] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_ONTIME"].ToString());
                        MmiGV.LampBuzzerData[999, 5] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_OFFTIME"].ToString());
                    }
                    else
                    {
                        MmiGV.LampBuzzerData[i, 0] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_RED"].ToString());
                        MmiGV.LampBuzzerData[i, 1] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_YELLOW"].ToString());
                        MmiGV.LampBuzzerData[i, 2] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["LAMP_GREEN"].ToString());
                        MmiGV.LampBuzzerData[i, 3] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_COUNT"].ToString());
                        MmiGV.LampBuzzerData[i, 4] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_ONTIME"].ToString());
                        MmiGV.LampBuzzerData[i, 5] = Convert.ToUInt32(SQLiteDB.ReaderLampBuzzer["BUZZER_OFFTIME"].ToString());
                    }
                    i++;
                }

                SQLiteDB.ReaderLampBuzzer.Close();
            }

            WriteLampBuzzerData();
            iPercent += 20;
            UpdateProgressBar(iPercent);
            #endregion LAMP_BUZZER_INIT

            #region ERROR_LIST_INIT
            UpdateTitle("ERROR LIST Data Loading");

            string strSQL = "SELECT * FROM ERROR ORDER BY IDX ASC";
            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderAlarm))
            {
                while (SQLiteDB.ReaderAlarm.Read())
                {
                    var code = Convert.ToInt32(SQLiteDB.ReaderAlarm["IDX"]);
                    var name = string.Format("{0}", SQLiteDB.ReaderAlarm["ERR_NAME"]);
                    var msg1 = string.Format("{0}", SQLiteDB.ReaderAlarm["ERR_DEBUG1"]);
                    var msg2 = string.Format("{0}", SQLiteDB.ReaderAlarm["ERR_DEBUG2"]);
                    var type = Convert.ToBoolean(SQLiteDB.ReaderAlarm["TYPE"]);
                    var mtba = Convert.ToBoolean(SQLiteDB.ReaderAlarm["MTBA"]);

                    var errbuf = new MmiGV.TErrorBuff();
                    errbuf.name = name;
                    errbuf.msg1 = msg1;
                    errbuf.msg2 = msg2;
                    errbuf.type = type;
                    errbuf.mtba = mtba;

                    MmiGV.dicErrorList.TryAdd(code, errbuf);
                }
            }
            iPercent += 5;
            UpdateProgressBar(iPercent);

            #endregion

            frmMain.lblError.Invoke(new Action(() =>
            {
                frmMain.lblError.Text = "";
            }));

            MmiGV.pShMem.WUserInfo.strUserName = MmiGV.UserInfo.strUserName;
            MmiGV.pShMem.SetUserInfo();

            MmiGV.bInitSystem = true;
            MmiGV.pShMem.SetDM(6, 0);
            Application.DoEvents();
            Thread.Sleep(1000);
            MethodInvoker miClose = new MethodInvoker(this.Hide);
            frmMain.Invoke(miClose);
        }

        private void UpdateTitle(string strTitle)
        {
            lblTitle.Invoke(new Action(() => 
            { 
                lblTitle.Text = strTitle; 
            }));
            Application.DoEvents();
        }

        private void UpdateProgressBar(int per)
        {
            progressBar.Invoke(new Action(() =>
            { 
                progressBar.Value = (per * 100) / 100; 
            }));
            Application.DoEvents();
        }

        private void WriteRecipeData()
        {
            /*
            for (int i = 0; i < 100; i++)
            {
                MmiGV.pShMem.WRecipeData.dData[i] = MmiGV.dDeviceData[MmiGV.iDevNo, i];
            }
            MmiGV.pShMem.SetRecipe();
            */
        }

        private void WriteMotorConfigData()
        {
            for(int i = 0; i < 60; i++)
            {
                if (MmiGV.mtConfigData[i].uUse == 1)
                {
                    MmiGV.pShMem.WMTConfig.uAxisNo = MmiGV.mtConfigData[i].uAxisNo;
                    MmiGV.pShMem.WMTConfig.uRate = MmiGV.mtConfigData[i].uPulseRate;
                    MmiGV.pShMem.WMTConfig.uMaxVel = MmiGV.mtConfigData[i].uMaxSpeed;
                    MmiGV.pShMem.WMTConfig.uJogVel = MmiGV.mtConfigData[i].uJogVel;
                    MmiGV.pShMem.WMTConfig.uHomeVel = MmiGV.mtConfigData[i].uHomeVel;
                    MmiGV.pShMem.WMTConfig.uMotorType = MmiGV.mtConfigData[i].uMotorType;
                    MmiGV.pShMem.SetMotorConfig();
                }
            }
        }
        private void WriteMotorData()
        {
            for(int i = 0; i < 60; i++)
            {
                if (MmiGV.mtConfigData[i].uUse == 1)
                {
                    MmiGV.pShMem.WMotorData.uAxisNo = i;
                    MmiGV.pShMem.WMotorData.uPos = MmiGV.mtData[i].iPosArray;
                    MmiGV.pShMem.WMotorData.uVel = MmiGV.mtData[i].iSpeedArray;
                    MmiGV.pShMem.SetMotorData();
                }
            }
        }

        private void WriteDMData()
        {
            MmiGV.pShMem.SetDM(0, 300, MmiGV.dmData.DMValue);
        }

        private void WriteUseSkipData()
        {
            MmiGV.pShMem.SetDM(16, MmiGV.dmData.DMValue[16]);
            MmiGV.pShMem.SetDM(17, MmiGV.dmData.DMValue[17]);
        }

        private void WriteLampBuzzerData()
        {
            MmiGV.pShMem.WLampBuzzer.uLampBuzzer = MmiGV.LampBuzzerData;
            MmiGV.pShMem.SetLampBuzzer();
        }
    }
}
