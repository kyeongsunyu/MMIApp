using C1.Win.C1FlexGrid;
using DevComponents.Instrumentation;
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
using System.Diagnostics;

using static C1.Util.Win.Win32;

namespace MMI
{
    public partial class FormMonitorIO : Form
    {
        private FormMain frmMain = null;

        int iInputCh;
        int iOutputCh;
        ushort iInputStatus = 0;
        ushort bfInputStatus = 0;
        ushort iOutputStatus = 0;
        ushort bfOutputStatus = 0;

        bool[] bForcedOut;

        public FormMonitorIO()
        {
            InitializeComponent();
        }

        public FormMonitorIO(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            bForcedOut = new bool[16];
        }

        private void FormMonitorIO_Load(object sender, EventArgs e)
        {
            InitGrid();
            InitControl();
            LoadItem();
        }

        private void FormMonitorIO_Paint(object sender, PaintEventArgs e)
        {
        //    ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }
        private void InitGrid()
        {
            gdIO.BeginUpdate();

            gdIO.Cols[0].AllowEditing = false;  // input no
            gdIO.Cols[1].AllowEditing = false;  // input tag
            gdIO.Cols[2].AllowEditing = false;  // input name
            gdIO.Cols[3].AllowEditing = false;  // input status
            gdIO.Cols[4].AllowEditing = false;  // output no
            gdIO.Cols[5].AllowEditing = false;  // ouput tag
            gdIO.Cols[6].AllowEditing = false;  // ouput name
            gdIO.Cols[7].AllowEditing = false;  // ouput status


            gdIO[0, 1] = "INPUT";
            gdIO[1, 1] = "TAG";
            gdIO[1, 2] = "  INPUT NAME";
            gdIO[1, 3] = "";

            gdIO[0, 5] = "OUTPUT";
            gdIO[1, 5] = "TAG";
            gdIO[1, 6] = "  OUTPUT NAME";
            gdIO[1, 7] = "";

            // INPUT
            gdIO.Cols[0].Width = 70;
            gdIO.Cols[1].Width = 100;
            gdIO.Cols[2].Width = 480;
            gdIO.Cols[3].Width = 40;

            // OUTPUT
            gdIO.Cols[4].Width = 70;
            gdIO.Cols[5].Width = 100;
            gdIO.Cols[6].Width = 480;
            gdIO.Cols[7].Width = 40;


            gdIO.Rows[0].Height = 35;
            gdIO.Rows[1].Height = 35;

            gdIO.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            gdIO.Styles.Fixed.Font = new Font("Tahoma", 14, FontStyle.Bold);

            gdIO.Cols[0].TextAlign = TextAlignEnum.CenterCenter;
            gdIO.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            gdIO.Cols[2].TextAlign = TextAlignEnum.LeftCenter;
            gdIO.Cols[3].TextAlign = TextAlignEnum.CenterCenter;
            
            gdIO.Cols[4].TextAlign = TextAlignEnum.CenterCenter;
            gdIO.Cols[5].TextAlign = TextAlignEnum.CenterCenter;
            gdIO.Cols[6].TextAlign = TextAlignEnum.LeftCenter;
            gdIO.Cols[7].TextAlign = TextAlignEnum.CenterCenter;


            CellStyle csCellStyle = gdIO.Styles.Add("CellStyle");
            //csCellStyle.BackColor = Color.Bisque;                     // Cell의 바탕색 
            csCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);  // 글자 굵기 굴게
            CellRange crCellRange = gdIO.GetCellRange(2, 0, 17, 7);     // 적용할 Cell의 영역 설정
            crCellRange.Style = gdIO.Styles["CellStyle"];              // 설정된 Cell 영역에 Style 적용

            gdIO.Cols[1].AllowEditing = false;
            gdIO.Cols[2].AllowEditing = false;
            gdIO.Cols[4].AllowEditing = false;
            gdIO.Cols[5].AllowEditing = false;


            gdIO.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            CellRange rng = gdIO.GetCellRange(0, 0, 1, 0);
            gdIO.MergedRanges.Add(rng);

            rng = gdIO.GetCellRange(0, 1, 0, 3);
            gdIO.MergedRanges.Add(rng);

            rng = gdIO.GetCellRange(0, 4, 1, 4);
            gdIO.MergedRanges.Add(rng);

            rng = gdIO.GetCellRange(0, 5, 0, 7);
            gdIO.MergedRanges.Add(rng);

            for (int row = 2; row < gdIO.Rows.Count; row++)
            {
                gdIO.SetCellImage(row, 3, imageIO.Images[0]);
                gdIO.SetCellImage(row, 7, imageIO.Images[0]);
            }
            gdIO.EndUpdate();
        }
        private void InitControl()
        {
            gdIO.Controls.Add(lblInCh);
            gdIO.Controls.Add(lblOutCh);
            gdIO.Controls.Add(cbInputCh);
            gdIO.Controls.Add(cbOutputCh);

            lblInCh.Left = gdIO.Cols[0].Left;
            lblInCh.Top = gdIO.Rows[0].Top;

            lblOutCh.Left = gdIO.Cols[4].Left;
            lblOutCh.Top = gdIO.Rows[0].Top;

            cbInputCh.Left = gdIO.Cols[1].Left;
            cbInputCh.Top = gdIO.Rows[0].Top;

            cbOutputCh.Left = gdIO.Cols[5].Left;
            cbOutputCh.Top = gdIO.Rows[0].Top;

            for (int i = 0; i < 2; i++)
            {
                cbInputCh.Items.Add("CH:" + string.Format("{0:D2}", i));
            }
            cbInputCh.SelectedIndex = 0;

            for (int i = 0; i < 2; i++)
            {
                cbOutputCh.Items.Add("CH:" + string.Format("{0:D2}", i));
            }
            cbOutputCh.SelectedIndex = 0;

            iInputCh = 0;
            iOutputCh = iInputCh + cbInputCh.Items.Count;
        }

        private void LoadItem()
        {
            string strSQL = "";

            iInputCh = int.Parse(lblInCh.Text);
            iOutputCh = int.Parse(lblOutCh.Text) + cbInputCh.Items.Count;
            
            strSQL = "SELECT * FROM SENSOR WHERE IDX = ";
            strSQL += iInputCh.ToString();
            if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderIO))
            {
                if (SQLiteDB.ReaderIO.Read())
                {
                    for (int i = 0; i < 16; i++)
                    {
                        string sId = string.Format("{0:D2}", i);
                        gdIO[i + 2, 0] = sId;
                        gdIO[i + 2, 1] = SQLiteDB.ReaderIO["TAG" + sId].ToString();
                        gdIO[i + 2, 2] = SQLiteDB.ReaderIO["ITEM" + sId].ToString();
                    }
                }
                SQLiteDB.ReaderIO.Close();
            }
            

            strSQL = "SELECT * FROM SENSOR WHERE IDX = ";
            strSQL += iOutputCh.ToString();
            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderIO))
            {
                if (SQLiteDB.ReaderIO.Read())
                {
                    for (int i = 0; i < 16; i++)
                    {
                        string sId = string.Format("{0:D2}", i);
                        gdIO[i + 2, 4] = sId;
                        gdIO[i + 2, 5] = SQLiteDB.ReaderIO["TAG" + sId].ToString();
                        gdIO[i + 2, 6] = SQLiteDB.ReaderIO["ITEM" + sId].ToString();
                    }
                }
                SQLiteDB.ReaderIO.Close();
            }
        }

        private void cbInputCh_DropDownChange(object sender, bool Expanded)
        {
            //indi_IN.Value = cbInputCh.SelectedIndex;
            //indi_IN.Text = string.Format("{0:D2}", (int)indi_IN.Value);
            lblInCh.Text = string.Format("{0:D2}", cbInputCh.SelectedIndex);

            LoadItem();
        }

        private void cbInputCh_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblInCh.Text = string.Format("{0:D2}", (int)cbInputCh.SelectedIndex);
            LoadItem();
        }

        private void cbOutputCh_DropDownChange(object sender, bool Expanded)
        {
            lblOutCh.Text = string.Format("{0:D2}", (int)cbOutputCh.SelectedIndex);
            LoadItem();
        }

        private void cbOutputCh_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblOutCh.Text = string.Format("{0:D2}", cbOutputCh.SelectedIndex);
            LoadItem();
        }

        private void gdIO_AfterEdit(object sender, RowColEventArgs e)
        {
            string strSQL = "", sStr = "";

            if (gdIO[e.Row, e.Col].ToString() == "")
            {
                sStr = " ";
            }
            else
            {
                sStr = gdIO[e.Row, e.Col].ToString();
            }

            if (e.Row > 0 && (e.Col == 1 || e.Col == 2 || e.Col == 5 || e.Col==6))
            {
                switch (e.Col)
                {
                    case 1:
                        strSQL = "UPDATE SENSOR SET ";
                        strSQL += " TAG" + string.Format("{0:D2}", e.Row - 2) + "='" + sStr + "'";
                        strSQL += " WHERE IDX=" + iInputCh.ToString();
                        break;
                    case 2:
                        strSQL = "UPDATE SENSOR SET ";
                        strSQL += " ITEM" + string.Format("{0:D2}", e.Row - 2) + "='" + sStr + "'";
                        strSQL += " WHERE IDX=" + iInputCh.ToString();
                        break;
                    case 5:
                        strSQL = "UPDATE SENSOR SET ";
                        strSQL += " TAG" + string.Format("{0:D2}", e.Row - 2) + "='" + sStr + "'";
                        strSQL += " WHERE IDX=" + iOutputCh.ToString();
                        break;
                    case 6:
                        strSQL = "UPDATE SENSOR SET ";
                        strSQL += " ITEM" + string.Format("{0:D2}", e.Row - 2) + "='" + sStr + "'";
                        strSQL += " WHERE IDX=" + iOutputCh.ToString();
                        break;
                }

                if (SQLiteDB.Execute(strSQL))
                {
                    // MessageBox.Show("저장되었습니다");
                }
            }
        }

 

        private void gdIO_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Row >= 2)
            {
                if (e.Col == 3 || e.Col == 7)
                {
                    gdIO.Cols[e.Col].ImageAlign = ImageAlignEnum.CenterCenter;
                    gdIO.Cols[e.Col].ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.TileStretch;
                }
            }
        }
        private void gdIO_MouseClick(object sender, MouseEventArgs e)
        {

        }
        private void gdIO_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CUtil Util = CUtil.GetInstance;
            Debug.Assert(Util != null);

            if (gdIO.Row >= 2)
            {
                if (gdIO.MouseCol == 7)
                {
                    if (btnOutControl.Checked)
                    {
                        ushort uData = MmiGV.pShMem.GetIO(iOutputCh);
                        uData = (ushort)Util.BITChange(uData, gdIO.Row - 2);
                        MmiGV.pShMem.SetOutput(iOutputCh, uData);
                    }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Checked)
            {
                btnEdit.Checked = false;

                gdIO.Cols[1].AllowEditing = false;
                gdIO.Cols[2].AllowEditing = false;

                gdIO.Cols[5].AllowEditing = false;
                gdIO.Cols[6].AllowEditing = false;

                gdIO.Cols[1].StyleNew.BackColor = Color.PowderBlue;
                gdIO.Cols[2].StyleNew.BackColor = Color.Bisque;

                gdIO.Cols[5].StyleNew.BackColor = Color.PowderBlue;
                gdIO.Cols[6].StyleNew.BackColor = Color.Bisque;
            }
            else
            {
                if (frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
                {
                    btnEdit.Checked = true;

                    gdIO.Cols[1].AllowEditing = true;
                    gdIO.Cols[2].AllowEditing = true;

                    gdIO.Cols[5].AllowEditing = true;
                    gdIO.Cols[6].AllowEditing = true;

                    gdIO.Cols[1].StyleNew.BackColor = Color.White;
                    gdIO.Cols[2].StyleNew.BackColor = Color.White;

                    gdIO.Cols[5].StyleNew.BackColor = Color.White;
                    gdIO.Cols[6].StyleNew.BackColor = Color.White;
                }
            }
        }

        private void btnOutControl_Click(object sender, EventArgs e)
        {
            if (btnOutControl.Checked)
            {
                btnOutControl.Checked = false;
            }
            else
            {
                if (frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo)){
                    btnOutControl.Checked = true;
                }
            }
        }

        public void IORefresh()
        {
            CUtil Util = CUtil.GetInstance;
            Debug.Assert(Util != null);

            gdIO.Invoke(new Action(() =>
            {
                iInputStatus = MmiGV.pShMem.GetIO(iInputCh);
                if (iInputStatus != bfInputStatus)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if (Util.BIT(iInputStatus, i))
                        {
                            gdIO.SetCellImage(i + 2, 3, imageIO.Images[1]);
                        }
                        else
                        {
                            gdIO.SetCellImage(i + 2, 3, imageIO.Images[0]);
                        }
                    }
                    bfInputStatus = iInputStatus;
                }

                iOutputStatus = MmiGV.pShMem.GetIO(iOutputCh);
                if (iOutputStatus != bfOutputStatus)
                {
                    for (int i = 0; i < 16; i++)
                    {
                        if (Util.BIT(iOutputStatus, i))
                        {
                            gdIO.SetCellImage(i + 2, 7, imageIO.Images[2]);
                        }
                        else
                        {
                            gdIO.SetCellImage(i + 2, 7, imageIO.Images[0]);
                        }
                    }
                    bfOutputStatus = iOutputStatus;
                }
                
            }));
        }
    }
}
