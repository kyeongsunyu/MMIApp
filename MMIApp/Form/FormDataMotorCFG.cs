using C1.Win.C1FlexGrid;
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
    public partial class FormDataMotorCFG : Form
    {
        private FormMain frmMain = null;

        public FormDataMotorCFG()
        {
            InitializeComponent();
        }

        public FormDataMotorCFG(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormDataMotorCFG_Load(object sender, EventArgs e)
        {
            InitGridMotorCFG();
            LoadData();
        }
        private void FormDataMotorCFG_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void InitGridMotorCFG()
        {
            gdMotorCFG.Cols.DefaultSize = 100;

            gdMotorCFG.Cols[0].Width = 100;
            gdMotorCFG.Cols[1].Width = 500;
            gdMotorCFG.Cols[6].Width = 100;
            gdMotorCFG.Cols[7].Width = 100;

            gdMotorCFG.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            gdMotorCFG.Styles.Fixed.Font = new Font("Tahoma", 12, FontStyle.Bold);

            CellStyle csCellStyle = gdMotorCFG.Styles.Add("CellStyle");
            //csCellStyle.BackColor = Color.Bisque;                    // Cell의 바탕색 
            csCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);           // 글자 굵기 굴게
            CellRange crCellRange = gdMotorCFG.GetCellRange(2, 0, 61, 7);       // 적용할 Cell의 영역 설정
            crCellRange.Style = gdMotorCFG.Styles["CellStyle"];              // 설정된 Cell 영역에 Style 적용


            gdMotorCFG[0, 0] = "SERVO SETTING";
            gdMotorCFG[0, 2] = "Pulse \nRate \n(pulse/mm)";
            gdMotorCFG[0, 3] = "Max \nSpeed \n(pulse/s)";
            gdMotorCFG[0, 4] = "Jog \nSpeed \n(pulse/s)";
            gdMotorCFG[0, 5] = "Home \nSpeed \n(pulse/s)";
            gdMotorCFG[0, 6] = "Use \nSkip";
            gdMotorCFG[0, 7] = "Motor \nType";

            gdMotorCFG[1, 0] = "NO";
            gdMotorCFG[1, 1] = "MOTOR NAME";

            gdMotorCFG.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            CellRange rng = gdMotorCFG.GetCellRange(0, 0, 0, 1);
            gdMotorCFG.MergedRanges.Add(rng);
            rng.Data = "SERVO SETTING";

            rng = gdMotorCFG.GetCellRange(0, 2, 1, 2);
            gdMotorCFG.MergedRanges.Add(rng);

            rng = gdMotorCFG.GetCellRange(0, 3, 1, 3);
            gdMotorCFG.MergedRanges.Add(rng);

            rng = gdMotorCFG.GetCellRange(0, 4, 1, 4);
            gdMotorCFG.MergedRanges.Add(rng);

            rng = gdMotorCFG.GetCellRange(0, 5, 1, 5);
            gdMotorCFG.MergedRanges.Add(rng);

            rng = gdMotorCFG.GetCellRange(0, 6, 1, 6);
            gdMotorCFG.MergedRanges.Add(rng);

            rng = gdMotorCFG.GetCellRange(0, 7, 1, 7);
            gdMotorCFG.MergedRanges.Add(rng);

        }

        private void LoadData()
        {
            try
            {
                if (SQLiteDB.Select("SELECT * FROM MTCFG ORDER BY IDX ASC", ref SQLiteDB.ReaderMotorCFG))
                {
                    for (int i = 0; i < gdMotorCFG.Rows.Count; i++)  
                    {
                        if (SQLiteDB.ReaderMotorCFG.Read())
                        {
                            gdMotorCFG[i + 2, 0] = i + 1;
                            gdMotorCFG[i + 2, 1] = SQLiteDB.ReaderMotorCFG["ITEM"];
                            gdMotorCFG[i + 2, 2] = SQLiteDB.ReaderMotorCFG["RATE"];
                            gdMotorCFG[i + 2, 3] = SQLiteDB.ReaderMotorCFG["MAX_SPEED"];
                            gdMotorCFG[i + 2, 4] = SQLiteDB.ReaderMotorCFG["JOG_SPEED"];
                            gdMotorCFG[i + 2, 5] = SQLiteDB.ReaderMotorCFG["HOME_SPEED"];
                            gdMotorCFG[i + 2, 6] = (SQLiteDB.ReaderMotorCFG["USESKIP"].ToString() == "True") ? "T" : "F";
                            gdMotorCFG[i + 2, 7] = SQLiteDB.ReaderMotorCFG["MOTOR_TYPE"];
                        }
                    }
                    SQLiteDB.ReaderMotorCFG.Close();
                }
            }
            catch (Exception ex)
            {
                //    GV.AddMessage(ex.Message);
                ex.Message.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            btnSave.Enabled = false;
            string sSQL = "", sUseSkip = "";

            for (int i = 0; i < gdMotorCFG.Rows.Count - 2; i++)
            {
                if (gdMotorCFG[i + 2, 6] != null)
                {
                    sUseSkip = (gdMotorCFG[i + 2, 6].ToString() == "T" ? "True" : "False");
                    sSQL = "UPDATE MTCFG SET ";
                    sSQL += " ITEM       ='" + gdMotorCFG[i + 2, 1] + "', ";
                    sSQL += " RATE       = " + gdMotorCFG[i + 2, 2] + ", ";
                    sSQL += " MAX_SPEED  = " + gdMotorCFG[i + 2, 3] + ", ";
                    sSQL += " JOG_SPEED  = " + gdMotorCFG[i + 2, 4] + ", ";
                    sSQL += " HOME_SPEED = " + gdMotorCFG[i + 2, 5] + ", ";
                    sSQL += " USESKIP    = " + sUseSkip + ", ";
                    sSQL += " MOTOR_TYPE = " + gdMotorCFG[i + 2, 7];
                    sSQL += " WHERE IDX  = " + (i + 1).ToString();

                    SQLiteDB.Execute(sSQL);
                }
                else
                {
                    break;
                }
            }

            MmiGV.bInitSystem = false;
            frmMain.frm_SystemInit.SystemInitialize();

            btnSave.Enabled = true;
        }
    }
}
