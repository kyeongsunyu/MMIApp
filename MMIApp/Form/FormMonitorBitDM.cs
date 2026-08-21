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
using System.Diagnostics;
using static C1.Util.Win.Win32;

namespace MMI
{
    public partial class FormMonitorBitDM : Form
    {
        private FormMain frmMain = null;

        bool[] bForcedBitOut = new bool[16];
        bool[] bDMSave = new bool[300];

        ushort uBitStatus = 0;
        ushort bfBitStatus = 0;
        public FormMonitorBitDM()
        {
            InitializeComponent();
        }

        public FormMonitorBitDM(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormMonitorBitDM_Load(object sender, EventArgs e)
        {
            InitGridBit();
            cbBit.SelectedIndex = 0;
            LoadBitItem();


            InitGridDM();
            cbDM.SelectedIndex = 0;
            LoadDMItem();
            //DisplayDM(2, 0);
        }

        private void FormMonitorBitDM_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }
        private void InitGridBit()
        {
            gdBit.BeginUpdate();

            gdBit.Cols[0].Width = 40;
            gdBit.Cols[1].Width = 100;
            gdBit.Cols[2].Width = 540;

            gdBit[0, 0] = " ";
            gdBit[0, 1] = "BIT FLAG STATUS";
            gdBit[1, 2] = "BIT NAME";

            gdBit.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            gdBit.Styles.Fixed.Font = new Font("Tahoma", 14, FontStyle.Bold);
            gdBit.Styles.Fixed.ForeColor = Color.Black;

            CellStyle csCellStyle = gdBit.Styles.Add("CellStyle");
            //csCellStyle.BackColor = Color.Bisque;                    // Cell의 바탕색 
            csCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);           // 글자 굵기 굴게
            CellRange crCellRange = gdBit.GetCellRange(0, 0, 17, 2);       // 적용할 Cell의 영역 설정
            crCellRange.Style = gdBit.Styles["CellStyle"];              // 설정된 Cell 영역에 Style 적용


            gdBit.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            gdBit.Cols[2].TextAlign = TextAlignEnum.LeftCenter;

            gdBit.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            CellRange rng = gdBit.GetCellRange(0, 0, 1, 0);
            gdBit.MergedRanges.Add(rng);

            rng = gdBit.GetCellRange(0, 1, 0, 2);
            gdBit.MergedRanges.Add(rng);


            for (int row = 2; row < gdBit.Rows.Count; row++)
            {
                gdBit.SetCellImage(row, 0, imageBit.Images[0]);
            }
            gdBit.EndUpdate();

            gdBit.Controls.Add(cbBit);
            cbBit.Width = gdBit.Cols[1].Width;
            cbBit.Height = gdBit.Rows[1].Height;
            cbBit.Left = gdBit.Cols[1].Left;
            cbBit.Top = gdBit.Rows[1].Top;

            for (int i = 0; i < 26; i++)
            {
                string str = string.Format("CH {0:D2}", i);
                cbBit.Items.Add(str);
            }
            cbBit.SelectedIndex = 0;
        }
        private void LoadBitItem()
        {
            string strSQL = "";

            strSQL = "SELECT * FROM BITDATA ";
            if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderBit))
            {
                if (SQLiteDB.ReaderBit.Read())
                {
                    for (int i = 0; i < 16; i++)
                    {
                        string sId = string.Format("{0:D2}", i);
                        gdBit[i + 2, 1] = string.Format("{0:D2}", cbBit.SelectedIndex) + sId;
                        gdBit[i + 2, 2] = SQLiteDB.ReaderBit["ITEM" + sId].ToString();
                    }
                }
                SQLiteDB.ReaderBit.Close();
            }
        }
        private void gdBit_OwnerDrawCell(object sender, OwnerDrawCellEventArgs e)
        {
            if (e.Row >= 2)
            {
                if (e.Col == 0 )
                {
                    gdBit.Cols[e.Col].ImageAlign = ImageAlignEnum.CenterCenter;
                    gdBit.Cols[e.Col].ImageAlign = C1.Win.C1FlexGrid.ImageAlignEnum.TileStretch;
                }
            }
        }

        private void gdBit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CUtil Util = CUtil.GetInstance;
            Debug.Assert(Util != null);

            if (gdBit.MouseRow >= 2)
            {
                if (gdBit.MouseCol == 0)
                {
                    ushort uData = MmiGV.pShMem.GetBit(cbBit.SelectedIndex);
                    uData = (ushort)Util.BITChange(uData, gdBit.MouseRow - 2);
                    MmiGV.pShMem.SetBit(cbBit.SelectedIndex, uData);
                }
            }
        }

        private void cbBit_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQL = "";

            strSQL = "SELECT * FROM BITDATA WHERE IDX=";
            strSQL += cbBit.SelectedIndex.ToString();

            if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderBit))
            {
                if (SQLiteDB.ReaderBit.Read())
                {
                    for(int i = 0; i < 16; i++)
                    {
                        string sId = string.Format("{0:D2}", i);
                        gdBit[i + 2, 1] = string.Format("{0:D2}", cbBit.SelectedIndex) + sId;
                        gdBit[i + 2, 2] = SQLiteDB.ReaderBit["ITEM" + sId].ToString();
                    }
                }
                SQLiteDB.ReaderBit.Close();
            }
        }

        private void gdBit_AfterEdit(object sender, RowColEventArgs e)
        {
            string strSQL = "";
            strSQL = "UPDATE BITDATA SET ";
            strSQL += "ITEM" + string.Format("{0:D2}", e.Row-2) + "= '";
            strSQL += gdBit[e.Row,2].ToString() + "'";
            strSQL += " WHERE IDX=" + cbBit.SelectedIndex.ToString();
            SQLiteDB.Execute(strSQL);
        }

        public void BitRefresh()
        {
            CUtil Util = CUtil.GetInstance;
            Debug.Assert(Util != null);

            if (MmiGV.pShMem.IsGetBit())
            {
                gdBit.Invoke(new Action(() =>
                {
                    uBitStatus = MmiGV.pShMem.GetBit(cbBit.SelectedIndex);
                    if (uBitStatus != bfBitStatus)
                    {
                        for (int i = 0; i < 16; i++)
                        {
                            if (Util.BIT(uBitStatus, i))
                            {
                                gdBit.SetCellImage(i + 2, 0, imageBit.Images[1]);
                            }
                            else
                            {
                                gdBit.SetCellImage(i + 2, 0, imageBit.Images[0]);
                            }
                        }
                        bfBitStatus = uBitStatus;
                    }
                }));
            }
        }


        private void InitGridDM()
        {
            gdDM.BeginUpdate();

            gdDM.Cols[0].Width = 100;
            gdDM.Cols[1].Width = 100;
            gdDM.Cols[2].Width = 400;
            gdDM.Cols[3].Width = 65;


            gdDM[0, 0] = "DATA MEMORY STATUS";
            gdDM[1, 1] = "VALUE";
            gdDM[1, 2] = "DM NAME";
            gdDM[1, 3] = "SAVE";

            gdDM.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            gdDM.Styles.Fixed.Font = new Font("Tahoma", 14, FontStyle.Bold);

            CellStyle csCellStyle = gdDM.Styles.Add("CellStyle");
            //csCellStyle.BackColor = Color.Bisque;                    // Cell의 바탕색 
            csCellStyle.Font = new Font("Tahoma", 14, FontStyle.Bold);           // 글자 굵기 굴게
            CellRange crCellRange = gdDM.GetCellRange(0, 0, 11, 3);       // 적용할 Cell의 영역 설정
            crCellRange.Style = gdDM.Styles["CellStyle"];              // 설정된 Cell 영역에 Style 적용


            gdDM.Cols[1].TextAlign = TextAlignEnum.CenterCenter;
            gdDM.Cols[2].TextAlign = TextAlignEnum.LeftCenter;


            gdDM.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Custom;
            CellRange rng = gdDM.GetCellRange(0, 0, 0, 3);
            gdDM.MergedRanges.Add(rng);

            gdDM.EndUpdate();

            gdDM.Controls.Add(cbDM);
            cbDM.Width = gdDM.Cols[0].Width;
            cbDM.Height = gdDM.Rows[1].Height;
            cbDM.Left = gdDM.Cols[0].Left;
            cbDM.Top = gdDM.Rows[1].Top;

            for (int i = 0; i < 30; i++)
            {
                string str = string.Format("CH {0:D2}", i);
                cbDM.Items.Add(str);
            }
            cbDM.SelectedIndex = 0;
        }

        private void LoadDMItem()
        {
            string strSQL = "";

            strSQL = "SELECT * FROM DATAMEM ";

            if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderDM))
            {
                for(int i= 0; i < 10; i++)
                {
                    if (SQLiteDB.ReaderDM.Read())
                    {
                        string str;
                        gdDM[i + 2, 0] = string.Format("{0:D4}", cbDM.SelectedIndex * 10 + i);
                        str = SQLiteDB.ReaderDM["DMVALUE"].ToString();
                        gdDM[i + 2, 1] = string.IsNullOrEmpty(str) ? "0" : str;
                        
                        str = SQLiteDB.ReaderDM["DMNAME"].ToString();
                        gdDM[i + 2, 2] = SQLiteDB.ReaderDM["DMNAME"].ToString();

                        str = SQLiteDB.ReaderDM["DMSAVE"].ToString();
                        gdDM[i + 2, 3] = string.IsNullOrEmpty(str) ? "0" : str;
                    }
                }
                SQLiteDB.ReaderDM.Close();
            }
        }

        private void cbDM_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strSQL="";

            for (int i = 0; i < 10; i++)
            {
                strSQL = "SELECT * FROM DATAMEM WHERE IDX = ";
                strSQL += (cbDM.SelectedIndex * 10 + i).ToString();
                if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderDM))
                {
                    if (SQLiteDB.ReaderDM.Read())
                    {
                        //gdDM[i + 2, 0] = string.Format("{0:D4}", cbDM.SelectedIndex * 10 + i);
                        //gdDM[i + 2, 1] = SQLiteDB.ReaderDM["DMVALUE"].ToString();
                        //gdDM[i + 2, 2] = SQLiteDB.ReaderDM["DMNAME"].ToString();
                        //gdDM[i + 2, 3] = SQLiteDB.ReaderDM["DMSAVE"].ToString();

                        string str;
                        gdDM[i + 2, 0] = string.Format("{0:D4}", cbDM.SelectedIndex * 10 + i);
                        str = SQLiteDB.ReaderDM["DMVALUE"].ToString();
                        gdDM[i + 2, 1] = string.IsNullOrEmpty(str) ? "0" : str;

                        str = SQLiteDB.ReaderDM["DMNAME"].ToString();
                        gdDM[i + 2, 2] = SQLiteDB.ReaderDM["DMNAME"].ToString();

                        str = SQLiteDB.ReaderDM["DMSAVE"].ToString();
                        gdDM[i + 2, 3] = string.IsNullOrEmpty(str) ? "0" : str;
                    }
                }
                SQLiteDB.ReaderDM.Close();
            }

            DisplayDM(gdDM.Row,1);
        }

        private void gdDM_Click(object sender, EventArgs e)
        {
            if (gdDM.Row > 1)
            {
                DisplayDM(gdDM.Row, 1);
            }
        }

        private void gdDM_AfterEdit(object sender, RowColEventArgs e)
        {
            string strSQL = "";
            switch(e.Col) 
            {
                case 1:
                    break;
                case 2:
                    strSQL = "UPDATE DATAMEM SET ";
                    strSQL += "DMNAME= '";
                    strSQL += gdDM[e.Row, e.Col].ToString() + "'";
                    strSQL += " WHERE IDX=" + (cbDM.SelectedIndex * 10 + e.Row - 2).ToString();
                    SQLiteDB.Execute(strSQL);
                    break;
                case 3:
                    strSQL = "UPDATE DATAMEM SET ";
                    strSQL += "DMSAVE= '";
                    strSQL += gdDM[e.Row, e.Col].ToString() + "'";
                    strSQL += " WHERE IDX=" + (cbDM.SelectedIndex * 10 + e.Row - 2).ToString();
                    SQLiteDB.Execute(strSQL);
                    break;
            }
        }

        public void DisplayDM(int Row, int Col)
        {
            UInt32 uData;

            lblIndexNO.Text = gdDM[Row, 0].ToString();
            uData = Convert.ToUInt32(gdDM[Row, Col].ToString());

            lblDeviceValue.Text = gdDM[Row, Col].ToString();
            lblHexValue.Text = string.Format("{0:X8}", uData);
            lblBinValue.Text = Convert.ToString(uData, 2).PadLeft(32, '0');

            //    Console.WriteLine("lbl_DecValue.Text={0}", lbl_DecValue.Text);
        }

        private void lblDeviceValue_DoubleClick(object sender, EventArgs e)
        {
            if (frmMain.frm_NumPad.Display())
            {
                uint val = (uint)frmMain.frm_NumPad.GetValue();
                int dmno = Convert.ToInt32(lblIndexNO.Text);

                //SeqGV.dm.Data[dmno] = val;
                MmiGV.dmData.DMValue[dmno] = val;
                MmiGV.pShMem.SetDM(dmno, val);
            }
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            btnSAVE.Enabled = false;

            string strSQL = "";

            strSQL = "SELECT * FROM DATAMEM ";
            if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderDM))
            {
                for (int i = 0; i < 300; i++)
                {
                    if (SQLiteDB.ReaderDM.Read())
                    {
                        bDMSave[i] = (SQLiteDB.ReaderDM["DMSAVE"].ToString() == "1") ? true : false;
                    }
                }
                SQLiteDB.ReaderDM.Close();
            }

            for (int iIdx = 0; iIdx < 300; iIdx++)
            {
                if (bDMSave[iIdx])
                {
                    strSQL = "UPDATE DATAMEM SET ";
                    strSQL += "DMVALUE= ";
                    strSQL += MmiGV.dmData.DMValue[iIdx].ToString();
                    strSQL += " WHERE IDX=" + iIdx.ToString();

                    if (SQLiteDB.Execute(strSQL))
                    {
                        // MessageBox.Show("저장되었습니다");
                    }
                }
            }

            btnSAVE.Enabled = true;
        }

        public void DMRefresh()
        {
            int dmIdx=0;
            uint dmData;
            for (int i = 0; i < 10; i++)
            {
                cbDM.Invoke(new Action(() => { dmIdx = cbDM.SelectedIndex * 10 + i; }));

                dmData = MmiGV.pShMem.GetDM(dmIdx);
                if (gdDM[i + 2, 1].ToString() != dmData.ToString())
                {
                    gdDM.Invoke(new Action(() => 
                    { 
                        gdDM[i + 2, 1] = dmData.ToString(); 
                    }));

                    if ((i + 2) == gdDM.Row)
                    {
                        lblDeviceValue.Invoke(new Action(() => 
                        { 
                            lblDeviceValue.Text = $"{dmData}"; 
                        }));

                        lblHexValue.Invoke(new Action(() => 
                        {
                            lblHexValue.Text = $"{dmData:X8}"; 
                        }));

                        lblBinValue.Invoke(new Action(() =>
                        {
                            lblBinValue.Text = Convert.ToString(dmData, 2).PadLeft(32, '0');
                        }));

                    }
                }
            }
        }
    }
}
