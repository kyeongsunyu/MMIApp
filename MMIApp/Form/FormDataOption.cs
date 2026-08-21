using C1.Win.C1FlexGrid;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MMI
{
    public partial class FormDataOption : Form
    {
        private FormMain frmMain = null;

        private CellRange rng;

        public FormDataOption()
        {
            InitializeComponent();
        }

        public FormDataOption(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormDataOption_Load(object sender, EventArgs e)
        {
            InitGrid();
            LoadData();
        }

        private void FormDataOption_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }
        private void InitGrid()
        {
            gdOption.BeginUpdate();

            gdOption[0, 0] = "NO";
            gdOption[0, 1] = "USE/SKIP1";
            gdOption[1, 1] = "ITEM";
            gdOption[1, 2] = "SKIP";

            gdOption[0, 3] = "NO";
            gdOption[0, 4] = "USE/SKIP2";
            gdOption[1, 4] = "ITEM";
            gdOption[1, 5] = "SKIP";


            gdOption.Cols[0].Width = 55;
            gdOption.Cols[1].Width = 470;
            gdOption.Cols[2].Width = 100;
            gdOption.Cols[3].Width = 55;
            gdOption.Cols[4].Width = 470;
            gdOption.Cols[5].Width = 100;

            gdOption.Cols[0].AllowEditing = false;
            gdOption.Cols[1].AllowEditing = false;
            gdOption.Cols[2].AllowEditing = false;
            gdOption.Cols[3].AllowEditing = false;
            gdOption.Cols[4].AllowEditing = false;
            gdOption.Cols[5].AllowEditing = false;

            gdOption.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            gdOption.Styles.Fixed.Font = new Font("Tahoma", 12, FontStyle.Bold);

            CellStyle csCellStyle = gdOption.Styles.Add("CellStyle");
            //csCellStyle.BackColor = Color.Bisque;                    // Cell의 바탕색 
            csCellStyle.Font = new Font("Tahoma", 12, FontStyle.Bold);           // 글자 굵기 굴게
            CellRange crCellRange = gdOption.GetCellRange(2, 0, 26, 5);       // 적용할 Cell의 영역 설정
            crCellRange.Style = gdOption.Styles["CellStyle"];              // 설정된 Cell 영역에 Style 적용


            gdOption.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            gdOption.Cols[2].TextAlign = TextAlignEnum.CenterCenter;

            gdOption.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
            gdOption.Cols[5].TextAlign = TextAlignEnum.CenterCenter;


            gdOption.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            rng = gdOption.GetCellRange(0, 0, 1, 0);
            gdOption.MergedRanges.Add(rng);
            rng.Data = "NO";

            rng = gdOption.GetCellRange(0, 1, 0, 2);
            gdOption.MergedRanges.Add(rng);
            rng.Data = "USE/SKIP1";

            rng = gdOption.GetCellRange(0, 3, 1, 3);
            gdOption.MergedRanges.Add(rng);
            rng.Data = "NO";

            rng = gdOption.GetCellRange(0, 4, 0, 5);
            gdOption.MergedRanges.Add(rng);
            rng.Data = "USE/SKIP2";

            gdOption.Cols[0].StyleNew.BackColor = Color.Gray;
            gdOption.Cols[1].StyleNew.BackColor = Color.Bisque;
            gdOption.Cols[2].StyleNew.BackColor = Color.Honeydew;

            gdOption.Cols[3].StyleNew.BackColor = Color.Gray;
            gdOption.Cols[4].StyleNew.BackColor = Color.Bisque;
            gdOption.Cols[5].StyleNew.BackColor = Color.Honeydew;

            for (int row = 0; row < gdOption.Rows.Count; row++)
            {
                gdOption[row + 2, 0] = string.Format("{0:D2}", row + 1);
                gdOption[row + 2, 2] = "OFF";
                
                gdOption[row + 2, 3] = string.Format("{0:D2}", row + 1);
                gdOption[row + 2, 5] = "OFF";

            }

            gdOption.EndUpdate();
        }

        private void LoadData()
        {
            string strSQL = "SELECT * FROM USESKIP";
            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderOption)) {
                for (int row = 0; row < gdOption.Rows.Count; row++)
                {
                    if(SQLiteDB.ReaderOption.Read())
                    {
                        gdOption[row + 2, 1] = SQLiteDB.ReaderOption["ITEM1"];
                        gdOption[row + 2, 4] = SQLiteDB.ReaderOption["ITEM2"];
                    }
                }
            }
            if (SQLiteDB.ReaderOption == null) return;

            SQLiteDB.ReaderOption.Close();
        }

        private void gdOption_AfterEdit(object sender, RowColEventArgs e)
        {
            string sSQL = "";
            string sStr = "";
            if (gdOption.Row > 0)
            {
                sStr = gdOption[gdOption.Row, gdOption.Col].ToString().ToUpper();

                if (gdOption.Col == 1)
                {
                    sSQL = "UPDATE USESKIP SET ";
                    sSQL += "ITEM1 = '";
                    sSQL += sStr + "'";
                    sSQL += " WHERE IDX=" + (gdOption.Row - 1).ToString();
                }
                else if (gdOption.Col == 4)
                {
                    sSQL = "UPDATE USESKIP SET ";
                    sSQL += "ITEM2 = '";
                    sSQL += sStr + "'";
                    sSQL += " WHERE IDX=" + (gdOption.Row - 1).ToString();
                }

                if (!string.IsNullOrEmpty(sSQL))
                {
                    SQLiteDB.Execute(sSQL);
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (btnEdit.Checked == false)
            {
                btnEdit.Checked = true;

                gdOption.Cols[1].AllowEditing = true;
                gdOption.Cols[4].AllowEditing = true;

                gdOption.Cols[1].StyleNew.BackColor = Color.White;
                gdOption.Cols[4].StyleNew.BackColor = Color.White;
            }
            else if(btnEdit.Checked == true)
            {
                btnEdit.Checked = false;

                gdOption.Cols[1].AllowEditing = false;
                gdOption.Cols[4].AllowEditing = false;

                gdOption.Cols[1].StyleNew.BackColor = Color.Bisque;
                gdOption.Cols[4].StyleNew.BackColor = Color.Bisque;
            }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            CUtil Util = CUtil.GetInstance;
            Debug.Assert(Util != null);

            uint uUseSkip1 = 0, uUseSkip2 = 0;
            String sSQL = "";

            for (int i = 0; i < gdOption.Rows.Count - 2; i++)
            {
                string str = gdOption[i + 2, 2].ToString();
                if (gdOption[i + 2, 2].ToString().Trim() == "ON")
                {
                    uUseSkip1 = Util.BITONOFF(uUseSkip1, i, true);
                }
                else
                {
                    uUseSkip1 = Util.BITONOFF(uUseSkip1, i, false);
                }

                if (gdOption[i + 2, 5].ToString().Trim() == "ON")
                {
                    uUseSkip2 = Util.BITONOFF(uUseSkip2, i, true);
                }
                else
                {
                    uUseSkip2 = Util.BITONOFF(uUseSkip2, i, false);
                }
            }

            sSQL = "UPDATE USESKIP SET ";
            sSQL += " USESKIP1 =" + uUseSkip1.ToString() + ",";
            sSQL += " USESKIP2 =" + uUseSkip2.ToString();
            sSQL += " WHERE IDX =1";

            if (SQLiteDB.Execute(sSQL))
            {
                // MessageBox.show("저장되었습니다");
            }

            gdOption.Cols[1].AllowEditing = false;
            gdOption.Cols[4].AllowEditing = false;

            gdOption.Cols[1].StyleNew.BackColor = Color.Bisque;
            gdOption.Cols[4].StyleNew.BackColor = Color.Bisque;

            MmiGV.pShMem.SetDM(16, uUseSkip1);
            MmiGV.pShMem.SetDM(17, uUseSkip2);

            btnEdit.Checked = false;
        }

        private void gdOption_DoubleClick(object sender, EventArgs e)
        {
            CUtil Util = CUtil.GetInstance;
            Debug.Assert(Util != null);

            int Row = gdOption.Row;
            int Col = gdOption.Col;

            if (Row > 1)
            {
                if (Col == 2)
                {
                    if (gdOption[Row, 2].ToString().Trim() == "ON")
                    {
                        gdOption[Row, 2] = "OFF";
                        uint data = MmiGV.pShMem.GetDM(16);
                        data = Util.BITChange(data, Row - 2);
                        MmiGV.pShMem.SetDM(16, data);
                    }
                    else if (gdOption[Row, 2].ToString().Trim() == "OFF")
                    {
                        gdOption[Row, 2] = "ON";
                        uint data = MmiGV.pShMem.GetDM(16);
                        data = Util.BITChange(data, Row - 2);
                        MmiGV.pShMem.SetDM(16, data);
                    }
                }
                if (Col == 5)
                {
                    if (gdOption[Row, 5].ToString().Trim() == "ON")
                    {
                        gdOption[Row, 5] = "OFF";
                        uint data = MmiGV.pShMem.GetDM(17);
                        data = Util.BITChange(data, Row - 2);
                        MmiGV.pShMem.SetDM(17, data);
                    }
                    else
                    {
                        gdOption[Row, 5] = "ON";
                        uint data = MmiGV.pShMem.GetDM(17);
                        data = Util.BITChange(data, Row - 2);
                        MmiGV.pShMem.SetDM(17, data);
                    }
                }
            }
        }
    }
}
