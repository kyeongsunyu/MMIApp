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
using static System.Collections.Specialized.BitVector32;
using C1.Win.C1FlexGrid;

namespace MMI
{
    public partial class FormManualList : Form
    {
        private FormMain frmMain = null;

        public FormManualList()
        {
            InitializeComponent();
        }

        public FormManualList(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            
        }

        private void FormManualList_Load(object sender, EventArgs e)
        {
            InitGRidTenKeySection();
            InitGridTenKey();

            LoadSection();
        }
        private void gdTenKey_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.DarkGray, ButtonBorderStyle.Solid);
        }

        private void InitGRidTenKeySection()
        {
            gdTenKeySection.BeginUpdate();
            gdTenKeySection[0, 0] = "NO";
            gdTenKeySection[0, 1] = "SECTION";

            gdTenKeySection.Cols[0].Width = 100;
            gdTenKeySection.Cols[1].Width = 440;

            gdTenKeySection.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            gdTenKeySection.Styles.Fixed.Font = new Font("Tahoma", 12, FontStyle.Bold);
            gdTenKeySection.AllowEditing = false;

            gdTenKeySection.EndUpdate();
        }
        private void InitGridTenKey()
        {
            gdTenKey.BeginUpdate();
            gdTenKey[0, 0] = "NO";
            gdTenKey[0, 1] = "MANUAL TENKEY LIST";

            gdTenKey.Cols[0].Width = 100;
            gdTenKey.Cols[1].Width = 560;

            gdTenKey.Styles.Fixed.TextAlign = TextAlignEnum.CenterCenter;
            gdTenKey.Styles.Fixed.Font = new Font("Tahoma", 12, FontStyle.Bold);
            gdTenKey.AllowEditing = false;

            gdTenKey.Cols[0].TextAlign = TextAlignEnum.CenterCenter;

            for (int i = 1; i < gdTenKey.Rows.Count; i++)
            {
                gdTenKey[i, 0] = "";
                gdTenKey[i, 1] = "";
            }

            gdTenKey.EndUpdate();
        }

        private void LoadSection()
        {
            try
            {
                if (SQLiteDB.Select("SELECT * FROM TENKEYSEC ORDER BY IDX ASC", ref SQLiteDB.ReaderTENKEYSEC))
                {
                    for (int i = 0; i < gdTenKeySection.Rows.Count; i++)
                    {
                        if (SQLiteDB.ReaderTENKEYSEC.Read())
                        {
                            gdTenKeySection[i + 1, 0] = string.Format("{0:00}", SQLiteDB.ReaderTENKEYSEC["IDX"]);
                            gdTenKeySection[i + 1, 1] = string.Format("{0:00}", SQLiteDB.ReaderTENKEYSEC["SEC_NAME"]);
                        }
                    }
                    SQLiteDB.ReaderTENKEYSEC.Close();
                    LoadTenKey();
                }
            }
            catch(Exception ex)
            {
            //    GV.AddMessage(ex.Message);
                ex.Message.ToString();
            }
        }

        private void LoadTenKey()
        {
            string strSectionNo;
            string strSQL;
            int iMaxRec = 0;
            int iCol = 0;
            int iRow = 0;
            int iIdx = 0;

            InitGridTenKey();

            strSectionNo = gdTenKeySection[gdTenKeySection.Row, 0].ToString();

            strSQL = "SELECT * FROM TENKEY WHERE SECIDX=" + strSectionNo;

            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderTENKEY))
            {
                DataTable dTable = new DataTable("TenKey");
                DataRow row = dTable.NewRow();

                dTable.Load(SQLiteDB.ReaderTENKEY);
                
                iMaxRec = dTable.Rows.Count;

                for (int i = 0; i < iMaxRec; i++)
                {
                    iCol = int.Parse(dTable.Rows[i]["XPOS"].ToString());
                    if (iCol < 0 || iCol > 5) return;

                    iRow = int.Parse(dTable.Rows[i]["YPOS"].ToString());
                    if (iRow < 0 || iRow > gdTenKey.Rows.Count) return;

                    iIdx = int.Parse(dTable.Rows[i]["IDX"].ToString());
                    gdTenKey[i + 1, 0] = iIdx;
                    gdTenKey[i + 1, 1] = dTable.Rows[i]["ITEMS"].ToString();
                }
                SQLiteDB.ReaderTENKEY.Close();
            }
        }

        private void gdTenKeySection_Click(object sender, EventArgs e)
        {
            LoadTenKey();
        }

        private void gdTenKey_DoubleClick(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            int Row = gdTenKey.Row;
            int Col = gdTenKey.Col;
            uint nTenKeyNo = 0;
            if (gdTenKey.Row > 0)
            {
                string str = gdTenKey[gdTenKey.Row, 0].ToString();
                if (gdTenKey[gdTenKey.Row, 0].ToString() != "")
                {
                    nTenKeyNo = uint.Parse(str.ToString());
                    MmiGV.pShMem.SetTenKey(nTenKeyNo);
                }
            }
        }
    }
}
