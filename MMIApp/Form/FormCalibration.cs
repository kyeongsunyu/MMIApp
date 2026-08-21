using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;

namespace MMI
{
    public partial class FormCalibration : Form
    {
        private FormMain frmMain = null;
        private C1.Win.C1FlexGrid.C1FlexGrid[] gd_F;
        private C1.Win.C1FlexGrid.C1FlexGrid[] gd_R;
        private DevComponents.DotNetBar.Controls.ComboBoxEx[] SelectUnit;
        private CDev3Point dev3P;
        private CDevPckCen devCen;

        private DevComponents.DotNetBar.PanelEx[] F_Panel;
        private DevComponents.DotNetBar.PanelEx F_BfPanel;
        private DevComponents.DotNetBar.PanelEx[] R_Panel;
        private DevComponents.DotNetBar.PanelEx R_BfPanel;

        private C1.Win.C1FlexGrid.C1FlexGrid[] Grid_Cen;

        //0:Front, 1:Rear, 2:BTM Y
        private int MoveBtnTag;

        public FormCalibration(FormMain frm)
        {
            InitializeComponent();

            dev3P = new CDev3Point();
            devCen = new CDevPckCen();
            this.frmMain = frm;
            InitGrid();
        }

        public void Load3Point()
        {
            MoveBtnTag = -1;
            devCen.F_GetPckCen();
            devCen.R_GetPckCen();

            for (int k = 1; k < 9; k++)
            {
                Grid_Cen[0][k, 1] = devCen.FrontCen[k - 1].mX.ToString("F2");
                Grid_Cen[0][k, 2] = devCen.FrontCen[k - 1].mY.ToString("F2");
                Grid_Cen[1][k, 1] = devCen.RearCen[k - 1].mX.ToString("F2");
                Grid_Cen[1][k, 2] = devCen.RearCen[k - 1].mY.ToString("F2");

                Grid_Cen[0][k, 3] = "0";
                Grid_Cen[0][k, 4] = "0";
                Grid_Cen[1][k, 3] = "0";
                Grid_Cen[1][k, 4] = "0";
            }
            //--------------------------
            dev3P.F_Get3Point();
            dev3P.R_Get3Point();

            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    gd_F[j][2, k + 1] = gd_F[j][2, k + 4] = dev3P.Front3P[j][k].mX.ToString("F2");
                    gd_F[j][3, k + 1] = gd_F[j][3, k + 4] = dev3P.Front3P[j][k].mY.ToString("F2");

                    gd_R[j][2, k + 1] = gd_R[j][2, k + 4] = dev3P.Rear3P[j][k].mX.ToString("F2");
                    gd_R[j][3, k + 1] = gd_R[j][3, k + 4] = dev3P.Rear3P[j][k].mY.ToString("F2");
                }
            }
        }

        private void SavePckCen_F()
        {
            for (int k = 1; k < 9; k++)
            {
                devCen.FrontCen[k - 1].mX = Convert.ToDouble(Grid_Cen[0][k, 1]);
                devCen.FrontCen[k - 1].mY = Convert.ToDouble(Grid_Cen[0][k, 2]);
            }

            devCen.F_SetPckCen();

            SaveSql(16);
            SaveSql(15);
        }

        private void SavePckCen_R()
        {
            for (int k = 1; k < 9; k++)
            {
                devCen.RearCen[k - 1].mX = Convert.ToDouble(Grid_Cen[1][k, 1]);
                devCen.RearCen[k - 1].mY = Convert.ToDouble(Grid_Cen[1][k, 2]);
            }

            devCen.R_SetPckCen();

            SaveSql(15);
            SaveSql(23);
        }



        private void Save3Point()
        {
            for (int j = 0; j < 6; j++)
            {
                for (int k = 0; k < 3; k++)
                {
                    gd_F[j][2, k + 1] = gd_F[j][2, k + 1 + 3];
                    gd_F[j][3, k + 1] = gd_F[j][3, k + 1 + 3];

                    gd_R[j][2, k + 1] = gd_R[j][2, k + 1 + 3];
                    gd_R[j][3, k + 1] = gd_R[j][3, k + 1 + 3];

                    //---------
                    dev3P.Front3P[j][k].mX = Convert.ToDouble(gd_F[j][2, k + 1]);
                    dev3P.Front3P[j][k].mY = Convert.ToDouble(gd_F[j][3, k + 1]);

                    dev3P.Rear3P[j][k].mX = Convert.ToDouble(gd_R[j][2, k + 1]);
                    dev3P.Rear3P[j][k].mY = Convert.ToDouble(gd_R[j][3, k + 1]);
                }
            }

            dev3P.F_Set3Point();
            dev3P.R_Set3Point();
            //-------------------------

            SaveSql(16); //Front pck
            SaveSql(23); //Rear pck
            SaveSql(9);  //Pallette 1
            SaveSql(10); //Pallette 2
            SaveSql(30); //Good Tray 1
            SaveSql(31); //Good Tray 2
            SaveSql(32); //Rework 
            SaveSql(33); //NG

            CRecipeCtl.MainRecipeLoad();
        }

        private void SaveSql(int nAxis)
        {
            string strSQL1 = "";
            for (int i = 1; i < 30; i++)//50
            {
                string id = string.Format("{0:D2}", i);
                string sAxis = string.Format("{0:D2}", nAxis + 1);
                string sPosName = MmiGV.mtSettingData[nAxis].PosName[i].ToString();

                string sPos = MmiGV.mtSettingData[nAxis].dPosArray[i].ToString();
                string sSpd = MmiGV.mtSettingData[nAxis].dSpeedArray[i].ToString();


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
        }

        private void InitGrid()
        {
            Grid_Cen = new C1FlexGrid[2];
            Grid_Cen[0] = Grid_F_Center;
            Grid_Cen[1] = Grid_R_Center;
            string str = "";

            for (int k = 0; k < 2; k++)
            {
                Grid_Cen[k][0, 0] = "No";
                Grid_Cen[k][0, 1] = "Head(X)";
                Grid_Cen[k][0, 2] = "Align(Y)";
                Grid_Cen[k][0, 3] = "Offset X";
                Grid_Cen[k][0, 4] = "Offset Y";

                for (int Ycnt = 1; Ycnt < 9; Ycnt++)
                {
                    str = "Z" + Ycnt.ToString();
                    Grid_Cen[k][Ycnt, 0] = str;
                }
            }

            //--------------------------
            gd_F = new C1.Win.C1FlexGrid.C1FlexGrid[6];
            gd_R = new C1.Win.C1FlexGrid.C1FlexGrid[6];

            F_Panel = new DevComponents.DotNetBar.PanelEx[6];
            R_Panel = new DevComponents.DotNetBar.PanelEx[6];

            SelectUnit = new DevComponents.DotNetBar.Controls.ComboBoxEx[2];

            gd_F[0] = gd_F_Pal1;
            gd_F[1] = gd_F_Pal2;
            gd_F[2] = gd_F_Good1;
            gd_F[3] = gd_F_Good2;
            gd_F[4] = gd_F_Rework;
            gd_F[5] = gd_F_NG;
            F_Panel[0] = F_pn1;
            F_Panel[1] = F_pn2;
            F_Panel[2] = F_pn3;
            F_Panel[3] = F_pn4;
            F_Panel[4] = F_pn5;
            F_Panel[5] = F_pn6;
            F_BfPanel = F_Panel[0];

            gd_R[0] = gd_R_Pal1;
            gd_R[1] = gd_R_Pal2;
            gd_R[2] = gd_R_Good1;
            gd_R[3] = gd_R_Good2;
            gd_R[4] = gd_R_Rework;
            gd_R[5] = gd_R_NG;
            R_Panel[0] = R_pn1;
            R_Panel[1] = R_pn2;
            R_Panel[2] = R_pn3;
            R_Panel[3] = R_pn4;
            R_Panel[4] = R_pn5;
            R_Panel[5] = R_pn6;
            R_BfPanel = R_Panel[0];

            SelectUnit[0] = Unit_F_CmbBox;
            SelectUnit[1] = Unit_R_CmbBox;

            for (int k = 0; k < 2; k++)
            {
                SelectUnit[k].Items.Clear();
                SelectUnit[k].Items.Add("PALLETTE Y1");
                SelectUnit[k].Items.Add("PALLETTE Y2");
                SelectUnit[k].Items.Add("GOOD TRAY Y1");
                SelectUnit[k].Items.Add("GOOD TRAY Y2");
                SelectUnit[k].Items.Add("REWORK TRAY");
                SelectUnit[k].Items.Add("NG TRAY");
            }


            //-------------------------------------------
            CellRange rng;
            CellRange crCellRange;
            CellStyle csCellStyle;

            for (int k = 0; k < 6; k++)
            {
                csCellStyle = gd_F[k].Styles.Add("CellStyle");
                csCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);           // 글자 굵기 굴게
                crCellRange = gd_F[k].GetCellRange(2, 0, 3, 6);         // (2, 0, 101, 5);       // 적용할 Cell의 영역 설정
                crCellRange.Style = gd_F[k].Styles["CellStyle"];              // 설정된 Cell 영역에 Style 적용
                gd_F[k].Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
                gd_F[k].Styles.Fixed.Font = new Font("Tahoma", 14, FontStyle.Bold);


                csCellStyle = gd_R[k].Styles.Add("CellStyle");
                csCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);           // 글자 굵기 굴게
                crCellRange = gd_R[k].GetCellRange(2, 0, 3, 6);         // (2, 0, 101, 5);       // 적용할 Cell의 영역 설정
                crCellRange.Style = gd_R[k].Styles["CellStyle"];              // 설정된 Cell 영역에 Style 적용
                gd_R[k].Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
                gd_R[k].Styles.Fixed.Font = new Font("Tahoma", 14, FontStyle.Bold);

                gd_F[k].Cols[5].StyleFixed.Font = gd_R[k].Cols[5].StyleFixed.Font = new Font("Tahoma", 14, FontStyle.Bold);

                gd_F[k].Cols[0].Width = gd_R[k].Cols[0].Width = 160;

                for (int m = 1; m < 7; m++)
                {
                    gd_F[k].Cols[m].Width = gd_R[k].Cols[m].Width = 140;

                    if (4 > m)
                    { gd_F[k].Cols[m].AllowEditing = gd_R[k].Cols[m].AllowEditing = false; }
                }

                gd_F[k].AllowMerging = gd_R[k].AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;

                rng = gd_F[k].GetCellRange(0, 1, 0, 3);
                gd_F[k].MergedRanges.Add(rng);
                rng.Data = "SETTING";
                rng = gd_F[k].GetCellRange(0, 4, 0, 6);
                gd_F[k].MergedRanges.Add(rng);
                rng.Data = "CURRENT";

                rng = gd_R[k].GetCellRange(0, 1, 0, 3);
                gd_R[k].MergedRanges.Add(rng);
                rng.Data = "SETTING";
                rng = gd_R[k].GetCellRange(0, 4, 0, 6);
                gd_R[k].MergedRanges.Add(rng);
                rng.Data = "CURRENT";

                gd_F[k][1, 1] = gd_F[k][1, 4] = "P1";
                gd_F[k][1, 2] = gd_F[k][1, 5] = "P2";
                gd_F[k][1, 3] = gd_F[k][1, 6] = "P3";

                gd_R[k][1, 1] = gd_R[k][1, 4] = "P1";
                gd_R[k][1, 2] = gd_R[k][1, 5] = "P2";
                gd_R[k][1, 3] = gd_R[k][1, 6] = "P3";

                gd_F[k][2, 0] = "Front Pk X";
                gd_R[k][2, 0] = "Rear Pk X";
            }

            gd_F[0][3, 0] = gd_R[0][3, 0] = "PALLETTE Y1";
            gd_F[1][3, 0] = gd_R[1][3, 0] = "PALLETTE Y2";
            gd_F[2][3, 0] = gd_R[2][3, 0] = "GOOD TRAY Y1";
            gd_F[3][3, 0] = gd_R[3][3, 0] = "GOOD TRAY Y2";
            gd_F[4][3, 0] = gd_R[4][3, 0] = "REWORK TRAY";
            gd_F[5][3, 0] = gd_R[5][3, 0] = "NG TRAY";
        }

        private void btn_F_Apply_Click(object sender, EventArgs e)
        {
            Save3Point();
        }

        private void btn_R_Apply_Click(object sender, EventArgs e)
        {
            Save3Point();
        }
        private void Unit_F_CmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            F_BfPanel.Style.BackColor1.Color = Color.White;
            F_BfPanel.Style.BackColor2.Color = Color.White;

            int idx = Unit_F_CmbBox.SelectedIndex;
            F_Panel[idx].Style.BackColor1.Color = Color.Lime;
            F_Panel[idx].Style.BackColor2.Color = Color.Lime;

            F_BfPanel = F_Panel[idx];
        }

        private void Unit_R_CmbBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            R_BfPanel.Style.BackColor1.Color = Color.White;
            R_BfPanel.Style.BackColor2.Color = Color.White;

            int idx = Unit_R_CmbBox.SelectedIndex;
            R_Panel[idx].Style.BackColor1.Color = Color.Lime;
            R_Panel[idx].Style.BackColor2.Color = Color.Lime;

            R_BfPanel = R_Panel[idx];
        }

        private void Do3Point_Click(object sender, EventArgs e)
        {
            DevComponents.DotNetBar.ButtonX pButton = sender as DevComponents.DotNetBar.ButtonX;

            int pktype = -1;
            int target = -1;
            int point = -1;
            if (tabControlPicker.SelectedIndex == 0)    //Front Picker
            {
                pktype = 0;
                target = Unit_F_CmbBox.SelectedIndex + 2;
                point = int.Parse(pButton.Tag.ToString());
            }
            else if (tabControlPicker.SelectedIndex == 1)    //Front Picker
            {
                pktype = 1;
                target = Unit_R_CmbBox.SelectedIndex + 2;
                point = int.Parse(pButton.Tag.ToString());
            }

            if (target < 0)
            {
                frmMain.frm_Msg.ShowMessage("Select Target");
                return;
            }

            MmiGV.pShMem.Set3Point(pktype, target, point);
        }

        /*
        private void RefreshMotorData()
        {
            //Front Picker
            MmiGV.pShMem.GetMotorData(16);
            MmiGV.pShMem.GetMotorStatus(16);
            int cnt = 0;

            for (int k = 19; k <= 26; k++)
            {
                CurPos[0,cnt] = (double)MmiGV.pShMem.RMotorData[16].uPos[k] 
                    / (double)MmiGV.mtConfigData[16].uPulseRate;
                cnt++;
            }
            CurIdx[0] = MmiGV.pShMem.RMTStatus.CurrentIndex;

            //Rear Picker
            cnt = 0;
            MmiGV.pShMem.GetMotorData(23);
            MmiGV.pShMem.GetMotorStatus(23);

            for (int k = 19; k <= 26; k++)
            {
                CurPos[2, cnt] = (double)MmiGV.pShMem.RMotorData[23].uPos[k]
                    / (double)MmiGV.mtConfigData[23].uPulseRate;
                cnt++;
            }

            CurIdx[1] = MmiGV.pShMem.RMTStatus.CurrentIndex;

            //BTM Y
            MmiGV.pShMem.GetMotorData(15);
            MmiGV.pShMem.GetMotorStatus(15);

            cnt = 0;
            for (int k = 1; k <= 8; k++)
            {
                CurPos[1, cnt] = (double)MmiGV.pShMem.RMotorData[15].uPos[k]
                    / (double)MmiGV.mtConfigData[15].uPulseRate;
                cnt++;
            }

            cnt = 0;
            for (int k = 9; k <= 16; k++)
            {
                CurPos[3, cnt] = (double)MmiGV.pShMem.RMotorData[15].uPos[k]
                    / (double)MmiGV.mtConfigData[15].uPulseRate;
                cnt++;
            }
            CurIdx[2] = MmiGV.pShMem.RMTStatus.CurrentIndex;
        }
        */


        private bool chk_Z_ALL_UP()
        {
            bool chk = true;
            int[] Z_idx = new int[8];
            int cnt = 0;

            for (int k = 17; k <= 20; k++)
            {
                MmiGV.pShMem.GetMotorData(k);
                MmiGV.pShMem.GetMotorStatus(k);
                Z_idx[cnt] = MmiGV.pShMem.RMTStatus.CurrentIndex;
                cnt++;
            }

            for (int k = 24; k <= 27; k++)
            {
                MmiGV.pShMem.GetMotorData(k);
                MmiGV.pShMem.GetMotorStatus(k);
                Z_idx[cnt] = MmiGV.pShMem.RMTStatus.CurrentIndex;
                cnt++;
            }

            for (int k = 0; k < 8; k++)
            {
                if (Z_idx[k] != 50)
                {
                    chk = false;
                    break;
                }
            }

            return chk;
        }


        private void btn_F_Cen_Save_Click(object sender, EventArgs e)
        {
            SavePckCen_F();
        }

        private void btn_R_Cen_Save_Click(object sender, EventArgs e)
        {
            SavePckCen_R();
        }


        private void GetIdxTag(object sender, ref int idx, ref int row, ref int tag)
        {
            System.Windows.Forms.Button btn = sender as System.Windows.Forms.Button;

            tag = Convert.ToInt32(btn.Tag);
            string str;

            if (tag < 20) { idx = 0; }  //1~8 , 11~18 
            else { idx = 1; }           //21~28 ,31~38

            if (tag >= 10)
            {
                str = tag.ToString();
                str = str.Substring(1, 1);
                row = Convert.ToInt32(str);
            }
            else
            {
                row = tag;
            }
        }

        private void MoveAlign(object sender)
        {
            int idx = 0;
            int row = 0;
            int tag = 0;

            GetIdxTag(sender, ref idx, ref row, ref tag);
            MoveBtnTag = tag;

            double mX, mY, alignX, alignY;
            mX = Convert.ToDouble(Grid_Cen[idx][row, 1]);
            mY = Convert.ToDouble(Grid_Cen[idx][row, 2]);
            alignX = Convert.ToDouble(Grid_Cen[idx][row, 3]);
            alignY = Convert.ToDouble(Grid_Cen[idx][row, 4]);

            mX = mX + alignX;
            mY = mY + alignY;

            Grid_Cen[idx][row, 1] = mX.ToString("F2");
            Grid_Cen[idx][row, 2] = mY.ToString("F2");
            Grid_Cen[idx][row, 3] = Grid_Cen[idx][row, 4] = "0";

            //Send Seq
            int PkNo = row - 1;
            MmiGV.pShMem.W_PkCenMove.PkType = idx;
            MmiGV.pShMem.W_PkCenMove.PkNo = PkNo;
            MmiGV.pShMem.W_PkCenMove.X_Pos[PkNo] = mX;
            MmiGV.pShMem.W_PkCenMove.Y_Pos[PkNo] = mY;

            MmiGV.pShMem.SetPkCenterMove();
        }
        private void GetAlign(object sender)
        {
            if (MoveBtnTag == -1)
            {
                MessageBox.Show("Press Click Move Button at First!!");
                return;
            }

            int idx = 0;
            int row = 0;
            int tag = 0;
            GetIdxTag(sender, ref idx, ref row, ref tag);

            if (tag != (MoveBtnTag - 10))
            {
                string str1, str2, strMsg = "";

                str1 = MoveBtnTag < 20 ? "Front Picker" : "Rear Picker";
                str2 = MoveBtnTag.ToString().Substring(1, 1);
                strMsg = "Press Click " + str1 + " Z" + str2 + " !!";

                MessageBox.Show(strMsg);
                return;
            }

            //Send Seq
            MmiGV.pShMem.SetPkCenterTrig();
        }

        private void btn_F_Get_Z1_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_F_Get_Z2_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_F_Get_Z3_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_F_Get_Z4_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_F_Get_Z5_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_F_Get_Z6_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_F_Get_Z7_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_F_Get_Z8_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_R_Get_Z1_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_R_Get_Z2_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_R_Get_Z3_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_R_Get_Z4_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_R_Get_Z5_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_R_Get_Z6_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_R_Get_Z7_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_R_Get_Z8_Click(object sender, EventArgs e)
        {
            GetAlign(sender);
        }

        private void btn_F_Move_Z1_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_F_Move_Z2_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_F_Move_Z3_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_F_Move_Z4_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_F_Move_Z6_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_F_Move_Z5_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_F_Move_Z7_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_F_Move_Z8_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_R_Move_Z1_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_R_Move_Z2_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_R_Move_Z3_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_R_Move_Z4_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_R_Move_Z5_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_R_Move_Z6_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }


        private void chk_timer_Tick(object sender, EventArgs e)
        {
            GetAlignApply();
        }

        private void GetAlignApply()
        {
            if (MmiGV.pShMem.GetDM(40) == 1)
            {
                MmiGV.pShMem.SetDM(40, 0);
                if (MmiGV.pShMem.GetFrontPkCenOffset())
                {
                    for (int m = 0; m < 8; m++)
                    {
                        Grid_Cen[0][m + 1, 3] = MmiGV.pShMem.R_FPk_CenOffset.X_Offset[m].ToString("F2");
                        Grid_Cen[0][m + 1, 4] = MmiGV.pShMem.R_FPk_CenOffset.Y_Offset[m].ToString("F2");
                    }
                }
            }
            else if (MmiGV.pShMem.GetDM(41) == 1)
            {
                MmiGV.pShMem.SetDM(41, 0);
                if (MmiGV.pShMem.GetRearPkCenOffset())
                {
                    for (int m = 0; m < 8; m++)
                    {
                        Grid_Cen[1][m + 1, 3] = MmiGV.pShMem.R_RPk_CenOffset.X_Offset[m].ToString("F2");
                        Grid_Cen[1][m + 1, 4] = MmiGV.pShMem.R_RPk_CenOffset.Y_Offset[m].ToString("F2");
                    }
                }
            }
            else if (MmiGV.pShMem.GetDM(42) == 1)
            {
                MmiGV.pShMem.SetDM(42, 0);
                if (MmiGV.pShMem.Get3PointOffset())
                {
                    //MmiGV.pShMem.RSet3Point.target;
                    //MmiGV.pShMem.RSet3Point.pktype;
                    //MmiGV.pShMem.RSet3Point.pointno;

                    //MmiGV.pShMem.RSet3Point.offsetX;
                    //MmiGV.pShMem.RSet3Point.offsetY;
                }
            }
        }

        private void SetAutoCalib(int PkType)
        {
            double mX, mY, alignX, alignY;

            for (int k = 0; k < 8; k++)
            {
                mX = Convert.ToDouble(Grid_Cen[PkType][k + 1, 1]);
                mY = Convert.ToDouble(Grid_Cen[PkType][k + 1, 2]);
                alignX = Convert.ToDouble(Grid_Cen[PkType][k + 1, 3]);
                alignY = Convert.ToDouble(Grid_Cen[PkType][k + 1, 4]);

                mX = mX + alignX;
                mY = mY + alignY;

                Grid_Cen[PkType][k + 1, 3] = "0";
                Grid_Cen[PkType][k + 1, 4] = "0";

                MmiGV.pShMem.W_PkCenMove.X_Pos[k] = mX;
                MmiGV.pShMem.W_PkCenMove.Y_Pos[k] = mY;
            }

            MmiGV.pShMem.W_PkCenMove.PkType = PkType;
            MmiGV.pShMem.SetPkAutoCal();
        }



        private void btn_F_CalStart_Click(object sender, EventArgs e)
        {
            SetAutoCalib(0);
        }

        private void btn_R_CalStart_Click(object sender, EventArgs e)
        {
            SetAutoCalib(1);
        }

        private void btn_R_Move_Z7_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }

        private void btn_R_Move_Z8_Click(object sender, EventArgs e)
        {
            MoveAlign(sender);
        }
    }
}
