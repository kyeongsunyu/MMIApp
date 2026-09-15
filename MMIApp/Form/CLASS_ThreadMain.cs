using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Diagnostics;

namespace MMI
{
    class CThreadMain
    {
        enum eSCR : int
        {
            SCREEN_AUTO1 = 11,
            SCREEN_AUTO2 = 12,

            SCREEN_MANUAL_LIST = 21,
            SCREEN_MANUAL_OP = 22,

            SCREEN_MOTOR_SETTING = 31,

            SCREEN_DATA = 41,
            SCREEN_SYSTEM_PARAM = 42,
            SCREEN_USE_SKIP = 43,
            SCREEN_LAMP_BUZZER = 44,
            SCREEN_USER_REGIST = 45,
            SCREEN_MOTOR_CFG = 46,

            SCREEN_IO = 51,
            SCREEN_DM_BIT = 52,

            SCREEN_ALARM = 61,
        }

        private static uint m_iLampStatus = 0;
        private static uint m_iRunning = 0;
        private static uint m_iDeviceNo = 0;
        private static uint bfUseSkip1 = 0;
        private static uint bfUseSkip2 = 0;

        private static int m_iCurrIndex = 0;
        private static double m_dCurrPos = 0.0;
        private static int m_iNextIndex = 0;
        private static double m_dNextPos = 0.0;

        
        public static void ExecuteMainThred()
        {
            while (!MmiGV.bProgramExit)
            {
                if (CommonRoutine())
                {
                    if (MmiGV.bMMIReady && MmiGV.bInitSystem)
                    {
                        ScreenRefresh();
                    }
                }
                Thread.Sleep(1);
            }
            Trace.WriteLine("GUI Main Thread Close..");
        }

        private static bool CommonRoutine()
        {
            bool bRet = false;

            if (MmiGV.pShMem.IsGetDM() && MmiGV.pShMem.GetDM(0, 300, MmiGV.dmData.DMValue))
            {
                #region SYSTEM_INITIALIZE
                if (MmiGV.pShMem.GetDM(6)==1 || MmiGV.bMMIReady == false)
                {
                    if(MmiGV.iScreenNo==11 || MmiGV.iScreenNo == 12)
                    {
                        MmiGV.frmMain.frm_SystemInit.SystemInitialize();

                        MmiGV.pShMem.SetDM(6, 0);
                        MmiGV.bMMIReady = true;

                        MmiGV.iScreenNo = 11;
                        MmiGV.pShMem.SetDM(7, (uint)MmiGV.iScreenNo);

                    }
                    else
                    {
                        MmiGV.frmMain.btnMenuAuto.Invoke(new Action(() =>
                        {
                            MmiGV.frmMain.btnMenuAuto.PerformClick();
                        }));
                    }
                }
                #endregion SYSTEM_INITIALIZE

                #region LAMP_STATUS_REFRESH
                if (MmiGV.dmData.DMValue[1] != m_iLampStatus)
                {
                    try
                    {
                        LampStatusRefresh();
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }
                }
                m_iLampStatus = MmiGV.dmData.DMValue[1];
                #endregion LAMP_STATUS_REFRESH

                #region ERROR_CODE_REFRESH
                MmiGV.iErrorCode = MmiGV.pShMem.GetDM(3);
                if (MmiGV.iPrevErrorCode != MmiGV.iErrorCode)
                {
                    try

                    {
                        ErrorRefresh();
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }
                }
                MmiGV.iPrevErrorCode = MmiGV.iErrorCode;
                #endregion ERROR_CODE_REFRESH

                #region MTBA_COLLECTION_REFRESH
                if (MmiGV.dmData.DMValue[5] != m_iRunning)
                {
                    try
                    {
                        MTBACollectionRefresh();
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }
                }

                m_iRunning = MmiGV.dmData.DMValue[5];
                #endregion MTBA_COLLECTION_REFRESH

                #region DEVICE_SELECTION_REFRESH

                if (MmiGV.dmData.DMValue[10] != m_iDeviceNo)
                {
                    try
                    {
                        DeviceSelectionRefresh();
                    }
                    catch (Exception e)
                    {
                        e.Message.ToString();
                    }
                }
                m_iDeviceNo = MmiGV.dmData.DMValue[10];
                #endregion DEVICE_SELECTION_REFRESH

                #region MACHINE_STATUS_REFRESH
                try
                {
                    MachineStatusRefresh();
                }
                catch (Exception e)
                {
                    e.Message.ToString();
                }
                #endregion MACHINE_STATUS_REFRESH

            }
            bRet = true;
            return bRet;
        }

        private static void LampStatusRefresh()
        {

        }
        private static void ErrorRefresh()
        {
            if (MmiGV.frmMain.lblError.InvokeRequired)
            {
                MmiGV.frmMain.lblError.Invoke(new Action(() => { MmiGV.frmMain.lblError.Text = ""; }));
            }
            else
            {
                MmiGV.frmMain.lblError.Text = "";
            }

            if (MmiGV.iErrorCode > 0)
            {
                var errbuff = new MmiGV.TErrorBuff();
                if (MmiGV.dicErrorList.TryGetValue((int)MmiGV.iErrorCode, out errbuff))
                {
                    MmiGV.frmMain.lblError.Invoke(new Action(() =>
                    {
                        MmiGV.frmMain.lblError.Text = $@"[{MmiGV.iErrorCode:000}] {errbuff.name}";
                        MmiGV.frmMain.lblError.BackgroundStyle.BackColor = Color.Sienna;
                        MmiGV.frmMain.lblError.BackgroundStyle.BackColor2 = SystemColors.Info;
                    }));
                }
            }
            else
            {
                MmiGV.frmMain.lblError.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.lblError.Text = $@"[{MmiGV.iErrorCode:000}]";
                    MmiGV.frmMain.lblError.BackgroundStyle.BackColor = Color.Silver;
                    MmiGV.frmMain.lblError.BackgroundStyle.BackColor2 = SystemColors.Info;
                }));
            }
        }

        private static void MTBACollectionRefresh()
        {
            string strSQL;

            strSQL = $"UPDATE TRACKING SET DTIME ={MmiGV.tmDownTime.Elapsed}, EMARK = NULL WHERE EMARK = '**';";
            SQLiteDB.Execute(strSQL);

            strSQL = "INSERT INTO TRACKING (RCODE, RSTAT, LOTNO, SDATE, DTIME, EMARK) ";
            strSQL += " VALUES (";
            switch (MmiGV.dmData.DMValue[5])
            {
                case 1: //-- Start
                    strSQL += "9998, 'AR'";
                    break;
                case 2: //-- Error
                    if (m_iRunning == 1)  //-- 이전 상태가 AutoRun
                    {
                        string sSQL1 = "SELECT * FROM ERROR WHERE IDX = " + MmiGV.iErrorCode.ToString();
                        if (SQLiteDB.Select(sSQL1, ref SQLiteDB.ReaderAlarm))
                        {
                            strSQL += MmiGV.iErrorCode.ToString() + ",'ER'";
                        }
                        else
                        {
                            strSQL += "9999, 'ST'";
                        }
                    }
                    else
                    {   //-- Stop이 먼저 발생한후 발생한 에러는 집계하지 않는다.
                        strSQL += "9999, 'ST'";
                    }
                    break;
                default:
                    strSQL += "9999, 'ST'";
                    break;
            }
            strSQL += ", '  ', NOW(), 0, '**')";
            SQLiteDB.Execute(strSQL);

            MmiGV.tmDownTime.SetTime();

            strSQL = "SELECT RSTAT, SDATE FROM TRACKING";
            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderTracking))
            {
                int iRecordCount = SQLiteDB.RecCount("SELECT COUNT(IDX) FROM TRACKING;");
                if (iRecordCount >= MmiGV.iMTBAMaxRec)
                {
                    SQLiteDB.Execute("DELETE FROM TRACKOLD");

                    strSQL = "INSERT INTO TRACKOLD (IDX, RCODE, RSTAT, SDATE, DTIME)";
                    strSQL += "SELECT IDX, RCODE, RSTAT, SDATE, DTIME FROM TRACKING";
                    SQLiteDB.Execute(strSQL);

                    SQLiteDB.ReaderTracking.Read();
                    DateTime dt = DateTime.Parse(SQLiteDB.ReaderTracking["SDATE"].ToString());

                    strSQL = "DELETE FROM TRACKING WHERE";
                    strSQL += " FORMAT(SDATE, 'yyyyMMddHHmmss') < ";
                    strSQL += " " + string.Format("{0:yyyyMMddHHmmss}", dt) + "";
                    SQLiteDB.Execute(strSQL);
                }
            }
        }

        private static void DeviceSelectionRefresh()
        {
            if (MmiGV.frmMain.lblDevice.InvokeRequired)
            {
                MmiGV.frmMain.lblDevice.Invoke(new Action(() => { MmiGV.frmMain.lblDevice.Text = ""; }));
            }
            else
            {
                MmiGV.frmMain.lblDevice.Text = " ";
            }

            string strSQL = "SELECT * FROM DEVICE WHERE IDX =" + MmiGV.iDevNo.ToString();
            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderDeviceData))
            {
                if (SQLiteDB.ReaderDeviceData.Read())
                {
                    string strName = SQLiteDB.ReaderDeviceData["DEVICE_NAME"].ToString();
                    string strDev = $"[{MmiGV.iDevNo:D2}]" + strName;

                    MmiGV.frmMain.lblDevice.Invoke(new Action(() =>
                    {
                        MmiGV.frmMain.lblDevice.Text = strDev;
                    }));
                }
            }
        }

        private static void MachineStatusRefresh()
        {
            CThreadMMILog MMILog = CThreadMMILog.GetInstance;
            Debug.Assert(MMILog != null);

            if (MmiGV.pShMem.GetMachineStatus())
            {
                MmiGV.frmMain.frmAuto1.lblUPH.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmAuto1.lblUPH.Text = $"{MmiGV.pShMem.RMachineStatus.UPH}" ;
                }));    
            }
        }

        private static void ScreenRefresh()
        {
            switch (MmiGV.iScreenNo)
            {
                case (int)eSCR.SCREEN_AUTO1:
                    Auto1Refresh();
                    break;
                case (int)eSCR.SCREEN_AUTO2:
                    break;
                case (int)eSCR.SCREEN_MANUAL_LIST:
                    break;
                case (int)eSCR.SCREEN_MANUAL_OP:
                    break;
                case (int)eSCR.SCREEN_MOTOR_SETTING:
                    MmiGV.pShMem.GetMotorData(MmiGV.iCurrAxis);
                    MmiGV.pShMem.GetMotorStatus(MmiGV.iCurrAxis);
                    MotorDataRefresh();
                    break;
                case (int)eSCR.SCREEN_DATA:
                    break;
                case (int)eSCR.SCREEN_SYSTEM_PARAM:
                    break;
                case (int)eSCR.SCREEN_USE_SKIP:
                    UseSkipRefresh();
                    break;
                case (int)eSCR.SCREEN_LAMP_BUZZER:
                    break;
                case (int)eSCR.SCREEN_USER_REGIST:
                    break;
                case (int)eSCR.SCREEN_MOTOR_CFG:
                    break;
                case (int)eSCR.SCREEN_IO:
                    if (MmiGV.pShMem.IsGetIO())
                    {
                        IORefresh();
                    }
                    break;
                case (int)eSCR.SCREEN_DM_BIT:
                    DMBitRefresh();
                    break;
                case (int)eSCR.SCREEN_ALARM:
                    break;
            }
        }

        private static void Auto1Refresh()
        {
            if (MmiGV.dmData.DMValue[1] == 1)
            {   // Start
                MmiGV.frmMain.frmAuto1.swRun.Start();
                MmiGV.frmMain.frmAuto1.swStop.Stop();
            }
            else if (MmiGV.dmData.DMValue[1] == 0)
            {   // Stop
                MmiGV.frmMain.frmAuto1.swRun.Stop();
                MmiGV.frmMain.frmAuto1.swStop.Start();
            }

            MmiGV.frmMain.frmAuto1.lblAir1.Invoke(new Action(() =>
            {
                MmiGV.frmMain.frmAuto1.lblAir1.Text = $"{MmiGV.pShMem.RMachineStatus.AirPressure1:0.00}";
            }));

            MmiGV.frmMain.frmAuto1.lblAir2.Invoke(new Action(() =>
            {
                MmiGV.frmMain.frmAuto1.lblAir2.Text = $"{MmiGV.pShMem.RMachineStatus.AirPressure2:0.00}";
            }));

            MmiGV.frmMain.frmAuto1.lblAir3.Invoke(new Action(() =>
            {
                MmiGV.frmMain.frmAuto1.lblAir3.Text = $"{MmiGV.pShMem.RMachineStatus.AirPressure3:0.00}";
            }));

            MmiGV.frmMain.frmAuto1.lblUPH.Invoke(new Action(() =>
            {
                MmiGV.frmMain.frmAuto1.lblUPH.Text = MmiGV.pShMem.RMachineStatus.UPH.ToString();
            }));

            if (MmiGV.iTragetUPH > 0 )
            {
                double dRatio = ((double)MmiGV.pShMem.RMachineStatus.UPH / (double)MmiGV.iTragetUPH) * 100;
                MmiGV.frmMain.frmAuto1.lblRate.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmAuto1.lblRate.Text = $"{dRatio:F2} %";
                }));
            }

            MmiGV.frmMain.frmAuto1.lblPanelInCount.Invoke(new Action(() =>
            {
                MmiGV.frmMain.frmAuto1.lblPanelInCount.Text = $"{MmiGV.pShMem.RMachineStatus.PanelInCount}";
            }));

            MmiGV.frmMain.frmAuto1.lblInCount.Invoke(new Action(() =>
            {
                MmiGV.frmMain.frmAuto1.lblInCount.Text = $"{MmiGV.pShMem.RMachineStatus.UnitInCnt}";
            }));

            MmiGV.frmMain.frmAuto1.lblOutCount.Invoke(new Action(() =>
            {
                MmiGV.frmMain.frmAuto1.lblOutCount.Text = $"{MmiGV.pShMem.RMachineStatus.UnitOutCnt}";
            }));

            MmiGV.frmMain.frmAuto1.lblGoodCount.Invoke(new Action(() =>
            {
                MmiGV.frmMain.frmAuto1.lblGoodCount.Text = $"{MmiGV.pShMem.RMachineStatus.UnitGoodCnt}";
            }));

            MmiGV.frmMain.frmAuto1.lblReworkCount.Invoke(new Action(() =>
            {
                MmiGV.frmMain.frmAuto1.lblReworkCount.Text = $"{MmiGV.pShMem.RMachineStatus.UnitReworkCnt}";
            }));

            MmiGV.frmMain.frmAuto1.lblNGCount.Invoke(new Action(() =>
            {
                MmiGV.frmMain.frmAuto1.lblNGCount.Text = $"{MmiGV.pShMem.RMachineStatus.UnitNGCnt}";
            }));

            MmiGV.pShMem.GetFlip1Map();
            MmiGV.pShMem.GetFlip2Map();
            MmiGV.pShMem.GetPallet1Map();
            MmiGV.pShMem.GetPallet2Map();
            MmiGV.pShMem.GetGoodTray1Map();
            MmiGV.pShMem.GetGoodTray2Map();
            MmiGV.pShMem.GetReworkTrayMap();
            MmiGV.pShMem.GetNGTrayMap();

            MmiGV.pShMem.GetFlip1VisionResult();
            MmiGV.pShMem.GetFlip2VisionResult();
            MmiGV.pShMem.GetPallet1VisionResult();
            MmiGV.pShMem.GetPallet2VisionResult();
            MmiGV.pShMem.GetFrontPickerVisionResult();
            MmiGV.pShMem.GetRearPickerVisionResult();
            MmiGV.pShMem.GetGoodTray1VisionResult();
            MmiGV.pShMem.GetGoodTray2VisionResult();
            MmiGV.pShMem.GetReworkTrayVisionResult();
            MmiGV.pShMem.GetNGTrayVisionResult();
        }

        
        private static void MotorDataRefresh()
        {
            double[] fPos = new double[2];
            double[] fVel = new double[2];
            double[] fPosCommon = new double[2];
            double[] fVelCommon = new double[2];

            for (int i = 1; i < 50; i++)
            {
                fPos[0] = (double)MmiGV.pShMem.RMotorData[MmiGV.iCurrAxis].uPos[i] / (double)MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
                fVel[0] = (double)MmiGV.pShMem.RMotorData[MmiGV.iCurrAxis].uVel[i] / (double)MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
                fPos[1] = (double.TryParse(MmiGV.frmMain.frmMotorSetting.gdMotor[i + 1, 4].ToString(), out fPos[1])) ? fPos[1] : 0.0;
                fVel[1] = (double.TryParse(MmiGV.frmMain.frmMotorSetting.gdMotor[i + 1, 5].ToString(), out fVel[1])) ? fVel[1] : 0.0;

                if ((Math.Abs(fPos[0] - fPos[1]) >= 0.005) ||
                    (Math.Abs(fVel[0] - fVel[1]) >= 1))
                {
                    MmiGV.frmMain.frmMotorSetting.gdMotor.Invoke(new Action(() =>
                    {
                        MmiGV.frmMain.frmMotorSetting.gdMotor[i + 1, 4] = $"{fPos[0]:F3}";
                        MmiGV.frmMain.frmMotorSetting.gdMotor[i + 1, 5] = $"{fVel[0]:F0}";
                    }));
                }
            }
            for (int i = 0; i < 50; i++)
            {
                fPosCommon[0] = (double)MmiGV.pShMem.RMotorData[MmiGV.iCurrAxis].uPos[i + 50] / (double)MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
                fVelCommon[0] = (double)MmiGV.pShMem.RMotorData[MmiGV.iCurrAxis].uVel[i + 50] / (double)MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
                fPosCommon[1] = (double.TryParse(MmiGV.frmMain.frmMotorSetting.gdMotorCommon[i + 2, 4].ToString(), out fPosCommon[1])) ? fPosCommon[1] : 0.0;
                fVelCommon[1] = (double.TryParse(MmiGV.frmMain.frmMotorSetting.gdMotorCommon[i + 2, 5].ToString(), out fVelCommon[1])) ? fVelCommon[1] : 0.0;


                if ((Math.Abs(fPosCommon[0] - fPosCommon[1]) >= 0.005) ||
                    (Math.Abs(fVelCommon[0] - fVelCommon[1]) >= 1))
                {
                    MmiGV.frmMain.frmMotorSetting.gdMotorCommon.Invoke(new Action(() =>
                    {
                        MmiGV.frmMain.frmMotorSetting.gdMotorCommon[i + 2, 4] = $"{fPosCommon[0]:F3}";
                        MmiGV.frmMain.frmMotorSetting.gdMotorCommon[i + 2, 5] = $"{fVelCommon[0]:F0}";
                    }));
                }
            }
            //for (int i = 0; i < 50; i++)
            //{
            //    fPos[0] = (double)MmiGV.pShMem.RMotorData[MmiGV.iCurrAxis].uPos[i] / (double)MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
            //    fVel[0] = (double)MmiGV.pShMem.RMotorData[MmiGV.iCurrAxis].uVel[i] / (double)MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
            //    fPos[1] = (double.TryParse(MmiGV.frmMain.frmMotorSetting.gdMotor[i + 1, 4].ToString(), out fPos[1])) ? fPos[1] : 0.0;
            //    fVel[1] = (double.TryParse(MmiGV.frmMain.frmMotorSetting.gdMotor[i + 1, 5].ToString(), out fVel[1])) ? fVel[1] : 0.0;

            //    fPosCommon[0] = (double)MmiGV.pShMem.RMotorData[MmiGV.iCurrAxis].uPos[i + 50] / (double)MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
            //    fVelCommon[0] = (double)MmiGV.pShMem.RMotorData[MmiGV.iCurrAxis].uVel[i + 50] / (double)MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
            //    fPosCommon[1] = (double.TryParse(MmiGV.frmMain.frmMotorSetting.gdMotorCommon[i + 2, 4].ToString(), out fPosCommon[1])) ? fPosCommon[1] : 0.0;
            //    fVelCommon[1] = (double.TryParse(MmiGV.frmMain.frmMotorSetting.gdMotorCommon[i + 2, 5].ToString(), out fVelCommon[1])) ? fVelCommon[1] : 0.0;

            //    if ((Math.Abs(fPos[0] - fPos[1]) >= 0.005) ||
            //        (Math.Abs(fVel[0] - fVel[1]) >= 1))
            //    {
            //        MmiGV.frmMain.frmMotorSetting.gdMotor.Invoke(new Action(() =>
            //        {
            //            MmiGV.frmMain.frmMotorSetting.gdMotor[i + 1, 4] = $"{fPos[0]:F3}";
            //            MmiGV.frmMain.frmMotorSetting.gdMotor[i + 1, 5] = $"{fVel[0]:F0}";
            //        }));
            //    }

            //    if ((Math.Abs(fPosCommon[0] - fPosCommon[1]) >= 0.005) ||
            //        (Math.Abs(fVelCommon[0] - fVelCommon[1]) >= 1))
            //    {
            //        MmiGV.frmMain.frmMotorSetting.gdMotorCommon.Invoke(new Action(() =>
            //        {
            //            MmiGV.frmMain.frmMotorSetting.gdMotorCommon[i + 1, 4] = $"{fPosCommon[0]:F3}";
            //            MmiGV.frmMain.frmMotorSetting.gdMotorCommon[i + 1, 5] = $"{fVelCommon[0]:F0}";
            //        }));
            //    }
            //}





            m_iCurrIndex = MmiGV.pShMem.RMTStatus.CurrentIndex;
            if (MmiGV.frmMain.frmMotorSetting.lblCurrentIndex.Text != m_iCurrIndex.ToString())
            {
                MmiGV.frmMain.frmMotorSetting.lblCurrentIndex.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.lblCurrentIndex.Text = m_iCurrIndex.ToString();
                }));
            }

            m_dCurrPos = MmiGV.pShMem.RMTStatus.CurrentPosition/
                         MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;

            if (MmiGV.frmMain.frmMotorSetting.lblCurrentPosition.Text != m_dCurrPos.ToString())
            {
                MmiGV.frmMain.frmMotorSetting.lblCurrentPosition.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.lblCurrentPosition.Text = $"{m_dCurrPos:0.000}";
                }));
            }

            m_iNextIndex = MmiGV.pShMem.RMTStatus.NextIndex;
            if (MmiGV.frmMain.frmMotorSetting.lblNextIndex.Text != m_iNextIndex.ToString())
            {
                MmiGV.frmMain.frmMotorSetting.lblNextIndex.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.lblNextIndex.Text = m_iNextIndex.ToString();
                }));
            }

            m_dNextPos = MmiGV.pShMem.RMTStatus.NextPosition /
                         MmiGV.mtConfigData[MmiGV.iCurrAxis].uPulseRate;
            if (MmiGV.frmMain.frmMotorSetting.lblNextPosition.Text != m_dNextPos.ToString())
            {
                MmiGV.frmMain.frmMotorSetting.lblNextPosition.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.lblNextPosition.Text = $"{m_dNextPos:0.000}";
                }));
            }

            if (MmiGV.pShMem.RMTStatus.HOME)
            {
                MmiGV.frmMain.frmMotorSetting.btnMTS_HOME.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btnMTS_HOME.BackColor = Color.Blue;
                }));
            }
            else
            {
                MmiGV.frmMain.frmMotorSetting.btnMTS_HOME.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btnMTS_HOME.BackColor = Color.Black;
                }));
            }

            if (MmiGV.pShMem.RMTStatus.Busy)
            {
                MmiGV.frmMain.frmMotorSetting.btnMTS_MOVING.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btnMTS_MOVING.BackColor = Color.Blue;
                }));
            }
            else
            {
                MmiGV.frmMain.frmMotorSetting.btnMTS_MOVING.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btnMTS_MOVING.BackColor = Color.Black;
                }));
            }

            if (MmiGV.pShMem.RMTStatus.CW)
            {
                MmiGV.frmMain.frmMotorSetting.btnMTS_CW.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btnMTS_CW.BackColor = Color.Red;
                }));
            }
            else
            {
                MmiGV.frmMain.frmMotorSetting.btnMTS_CW.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btnMTS_CW.BackColor = Color.Black;
                }));
            }

            if (MmiGV.pShMem.RMTStatus.CCW)
            {
                MmiGV.frmMain.frmMotorSetting.btnMTS_CCW.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btnMTS_CCW.BackColor = Color.Red;
                }));
            }
            else
            {
                MmiGV.frmMain.frmMotorSetting.btnMTS_CCW.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btnMTS_CCW.BackColor = Color.Black;
                }));
            }

            if (MmiGV.pShMem.RMTStatus.Org)
            {
                MmiGV.frmMain.frmMotorSetting.btnMTS_ORG.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btnMTS_ORG.BackColor = Color.Brown;
                }));
            }
            else
            {
                MmiGV.frmMain.frmMotorSetting.btnMTS_ORG.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btnMTS_ORG.BackColor = Color.Black;
                }));
            }

            if (MmiGV.pShMem.RMTStatus.SVON)
            {
                MmiGV.frmMain.frmMotorSetting.btmMTS_SERVO.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btmMTS_SERVO.BackColor = Color.Blue;
                }));
            }
            else
            {
                MmiGV.frmMain.frmMotorSetting.btmMTS_SERVO.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.btmMTS_SERVO.BackColor = Color.Black;
                }));
            }

            if (MmiGV.pShMem.RMTStatus.ALM)
            {
                MmiGV.frmMain.frmMotorSetting.bntMTS_ALARM.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.bntMTS_ALARM.BackColor = Color.Red;
                }));
            }
            else
            {
                MmiGV.frmMain.frmMotorSetting.bntMTS_ALARM.Invoke(new Action(() =>
                {
                    MmiGV.frmMain.frmMotorSetting.bntMTS_ALARM.BackColor = Color.Black;
                }));
            }
        }
        private static void UseSkipRefresh()
        {
            CUtil Util = CUtil.GetInstance;
            Debug.Assert(Util != null);

            MmiGV.frmMain.frmDataOption.gdOption.Invoke(new Action(() =>
            {
                if (bfUseSkip1 != MmiGV.pShMem.GetDM(16))
                {
                    for (int i = 0; i < MmiGV.frmMain.frmDataOption.gdOption.Rows.Count - 1; i++)
                    {
                        if(Util.BIT(MmiGV.pShMem.GetDM(16), i))
                        {
                            MmiGV.frmMain.frmDataOption.gdOption[i + 2, 2] = "ON";
                        }
                        else
                        {
                            MmiGV.frmMain.frmDataOption.gdOption[i + 2, 2] = "OFF";
                        }
                    }
                    bfUseSkip1 = MmiGV.pShMem.GetDM(16);
                }

                if (bfUseSkip2 != MmiGV.pShMem.GetDM(17))
                {
                    for (int i = 0; i < MmiGV.frmMain.frmDataOption.gdOption.Rows.Count - 1; i++)
                    {
                        if (Util.BIT(MmiGV.pShMem.GetDM(17), i))
                        {
                            MmiGV.frmMain.frmDataOption.gdOption[i + 2, 5] = "ON";
                        }
                        else
                        {
                            MmiGV.frmMain.frmDataOption.gdOption[i + 2, 5] = "OFF";
                        }
                    }
                    bfUseSkip2 = MmiGV.pShMem.GetDM(17);
                }
            }));
        }

        private static void IORefresh()
        {
            MmiGV.frmMain.frmMonitorIO.IORefresh();
        }

        private static void DMBitRefresh()
        {
            MmiGV.frmMain.frmMonitorBitDM.BitRefresh();
            MmiGV.frmMain.frmMonitorBitDM.DMRefresh();

        }
    }
}
