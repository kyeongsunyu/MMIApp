using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMI
{
    public static class CRecipeCtl
    {
        public static FormMain frmMain = null;
        //
        public static CRcpMaterial CurMaterialRcp = new CRcpMaterial();
        public static CRcpMaterial EditMaterialRcp = new CRcpMaterial();

        // Highest DeviceData index MainRecipeLoad() reads is 157, in the last of the four
        // blocks (0.., 50.., 100.., 150..). LoadRcpMaterial() fills 200 on success.
        private const int DeviceDataUsed = 158;
 
        public static void SetMainForm(FormMain Frm)
        {
            frmMain = Frm;
        }

        public static void MainRecipeLoad() //현재 Recipe Load
        {
            MmiGV.InitData();
            frmMain.frmMotorSetting.LoadMotorSettingData();

            
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
            

            frmMain.frmMotorSetting.RefreshData();

            //---------------------------- Share Memory

            // LoadRcpMaterial() clears DeviceData and only refills it when the DEVICE row
            // is actually read. A missing DB file, a missing table and a query that matches
            // no row are all swallowed on that path, so the list stays empty and the first
            // index below threw ArgumentOutOfRangeException - three layers away from the
            // real problem. Material_NAME is null in exactly the same case, which is what
            // the guard further down already tests before writing to shared memory.
            if (CRecipeCtl.CurMaterialRcp.DeviceData.Count < DeviceDataUsed)
            {
                System.Windows.Forms.MessageBox.Show(
                    "현재 레시피를 읽지 못했습니다. 레시피 값을 공유 메모리에 반영하지 않습니다.\n\n"
                    + "DEVICE 테이블에서 읽은 항목: " + CRecipeCtl.CurMaterialRcp.DeviceData.Count.ToString()
                    + " (필요: " + DeviceDataUsed.ToString() + ")\n"
                    + "DB 경로: " + System.Windows.Forms.Application.StartupPath + "\\DB\\JetDB.db",
                    "RECIPE LOAD",
                    System.Windows.Forms.MessageBoxButtons.OK,
                    System.Windows.Forms.MessageBoxIcon.Warning);

                return;
            }

            //for (int i = 0; i < CRecipeCtl.CurMaterialRcp.DeviceData.Count; i++)
            {
                //MmiGV.pShMem.WRecipeData.    .dDeviceData[i] = CRecipeCtl.CurMaterialRcp.DeviceData[i];

                int cnt = 0;
                MmiGV.pShMem.WRecipeData.Unit_X_Size = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Unit_Y_Size = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Unit_X_Count = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Unit_Y_Count = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Unit_X_Pitch = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Unit_Y_Pitch = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Tray_X_Count = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Tray_Y_Count = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Vision_Snap_X_Count = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Vision_Snap_Y_Count = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Picker_Place_Vac_Off_Offset = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Picker_Angle = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;

                MmiGV.pShMem.WRecipeData.Pallet1_Receive_Vac_Value = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Pallet2_Receive_Vac_Value = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Pallet_First_Sort_Vac_Value = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Pallet_Middle_Sort_Vac_Value = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Pallet_Last_Sort_Vac_Value = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Pallet_First_Sort_PKG_Rate = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Pallet_Last_Sort_PKG_Rate = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;

                cnt = 50;
                MmiGV.pShMem.WRecipeData.Front_Picker_1_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Front_Picker_2_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Front_Picker_3_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Front_Picker_4_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Front_Picker_5_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Front_Picker_6_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Front_Picker_7_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Front_Picker_8_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Rear_Picker_1_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Rear_Picker_2_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Rear_Picker_3_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Rear_Picker_4_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Rear_Picker_5_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Rear_Picker_6_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Rear_Picker_7_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Rear_Picker_8_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Scrap_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;
                MmiGV.pShMem.WRecipeData.Sponge_Clean_Skip = CRecipeCtl.CurMaterialRcp.DeviceData[cnt] == 1 ? true : false; cnt++;

                cnt = 100;
                MmiGV.pShMem.WRecipeData.Saw_Picker_Sponge_Clean = Convert.ToInt32(CRecipeCtl.CurMaterialRcp.DeviceData[cnt]); cnt++;
                MmiGV.pShMem.WRecipeData.Water_Jet_Water_Clean = Convert.ToInt32(CRecipeCtl.CurMaterialRcp.DeviceData[cnt]); cnt++;
                MmiGV.pShMem.WRecipeData.Water_Jet_Air_Clean = Convert.ToInt32(CRecipeCtl.CurMaterialRcp.DeviceData[cnt]); cnt++;
                MmiGV.pShMem.WRecipeData.Saw_Picker_Flip_Y1_Air_Clean = Convert.ToInt32(CRecipeCtl.CurMaterialRcp.DeviceData[cnt]); cnt++;
                MmiGV.pShMem.WRecipeData.Saw_Picker_Flip_Y2_Air_Clean = Convert.ToInt32(CRecipeCtl.CurMaterialRcp.DeviceData[cnt]); cnt++;
                MmiGV.pShMem.WRecipeData.Flip_Y1_Air_Clean = Convert.ToInt32(CRecipeCtl.CurMaterialRcp.DeviceData[cnt]); cnt++;
                MmiGV.pShMem.WRecipeData.Flip_Y2_Air_Clean = Convert.ToInt32(CRecipeCtl.CurMaterialRcp.DeviceData[cnt]); cnt++;
                MmiGV.pShMem.WRecipeData.Pallet_Y1_Air_Clean = Convert.ToInt32(CRecipeCtl.CurMaterialRcp.DeviceData[cnt]); cnt++;
                MmiGV.pShMem.WRecipeData.Pallet_Y2_Air_Clean = Convert.ToInt32(CRecipeCtl.CurMaterialRcp.DeviceData[cnt]); cnt++;

                cnt = 150;
                MmiGV.pShMem.WRecipeData.Front_Picker_Air_Blow_Time = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Rear_Picker_Air_Blow_Time = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;

                MmiGV.pShMem.WRecipeData.Front_Picker_Vac_On_Time = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Rear_Picker_Vac_On_Time = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;

                MmiGV.pShMem.WRecipeData.Load_Picker_Air_Blow_Time = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Load_Picker_Vac_On_Time = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Saw_Picker_Air_Blow_Time = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
                MmiGV.pShMem.WRecipeData.Saw_Picker_Vac_On_Time = CRecipeCtl.CurMaterialRcp.DeviceData[cnt]; cnt++;
            }

            if (CRecipeCtl.CurMaterialRcp.Material_NAME != null)
            { 
                MmiGV.pShMem.SetRecipe();

                MmiGV.pShMem.WDeviceInfo.nDeviceNumber = CRecipeCtl.CurMaterialRcp.Material_IDX;  //MmiGV.iDevNo;
                MmiGV.pShMem.WDeviceInfo.strDeviceName = CRecipeCtl.CurMaterialRcp.Material_NAME; //MmiGV.strCurrentDevName;
                MmiGV.pShMem.SetDeviceInfo();
            }
        }

        public static void MainRecipeSelect(string RecipeNo)
        {
            string strSQL = "UPDATE DEVICE SET CURR_MARK = ' '";
            SQLiteDB.Execute(strSQL);

            strSQL = " UPDATE DEVICE SET ";
            strSQL += " CURR_MARK = '**'";
            strSQL += " WHERE IDX=" + RecipeNo.Trim();
            SQLiteDB.Execute(strSQL);
            //-------------

            MainRecipeLoad();
        }



        public static void CreateMainDevTable()
        {
            //string strKey = "";
            //string sSQL = "";// "DELETE FROM  DEVICE";
                             //SQLiteDB.Execute(sSQL);

            //sSQL = "DROP TABLE DEVICE";
            //SQLiteDB.Execute(sSQL);


            //return;
            /*
            sSQL = "CREATE TABLE DEVICE(IDX INT, DEVICE_NAME text, CURR_MARK text, DMS_GROUP_ID INT, DMS_GROUP_NAME text ,";

            for (int k = 1; k < 201; k++)
            {
                if (k == 200)
                    sSQL = sSQL + "DATA" + string.Format("{0:000}", k) + " real)";
                else
                    sSQL = sSQL + "DATA" + string.Format("{0:000}", k) + " real ,";
            }

            SQLiteDB.Execute(sSQL);
            //-------------------------

            for (int k = 1; k < 31; k++)
            {
                sSQL = "INSERT INTO DEVICE VALUES(" + k.ToString() + ", '  ' , '  ', 0 , '  ' ,";
                for (int m = 0; m < 200; m++)
                {
                    if (m == 199)
                    {
                        sSQL = sSQL + " 0)";
                        SQLiteDB.Execute(sSQL);
                    }
                    else
                    { 
                        sSQL = sSQL + " 0,";
                    }
                }

            }
            */

            /*
            sSQL = "CREATE TABLE DEVICE_ITEM(IDX INT, DEVICE_NAME text ,";

            for (int k = 1; k < 201; k++)
            {
                if (k == 200)
                    sSQL = sSQL + "ITEM" + string.Format("{0:000}", k) + " text)";
                else
                    sSQL = sSQL + "ITEM" + string.Format("{0:000}", k) + " text ,";
            }

            SQLiteDB.Execute(sSQL);
            //-------------------------

            for (int k = 1; k < 201; k++)
            {
                sSQL = "INSERT INTO DEVICE_ITEM VALUES(" + k.ToString() + ", '  ' , ";
                for (int m = 0; m < 200; m++)
                {
                    if (m == 199)
                    {
                        sSQL = sSQL + " '  ')";
                        SQLiteDB.Execute(sSQL);
                    }
                    else
                    {
                        sSQL = sSQL + "'  ',";
                    }
                }

            }*/
        }


    }
}
