using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Collections.Specialized.BitVector32;
using C1.Win.C1FlexGrid;

namespace MMI
{
    public partial class FormManualOP : Form
    {
        private FormMain frmMain = null;
        private DevComponents.DotNetBar.ButtonX p_Button = null;

        public FormManualOP()
        {
            InitializeComponent();
        }

        public FormManualOP(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormManualOP_Load(object sender, EventArgs e)
        {
            InitGRidTenKeySection();

            LoadSection();

            tabControl1.SelectedTabIndex = 0;
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
                }
            }
            catch (Exception ex)
            {
                //    GV.AddMessage(ex.Message);
                ex.Message.ToString();
            }
        }

        private void gdTenKeySection_Click(object sender, EventArgs e)
        {
            String strSectionNo = gdTenKeySection[gdTenKeySection.Row, 0].ToString();
            String strSection = "tabSection" + strSectionNo;

            tabControl1.SelectedTabIndex = int.Parse(strSectionNo)-1;
        }

        private void TenKey(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            p_Button = sender as DevComponents.DotNetBar.ButtonX;

            int nTag = int.TryParse(p_Button.Tag.ToString(), out nTag) ? nTag : -1;
            if (nTag >= 0)
            {
                MmiGV.pShMem.SetTenKey((uint)nTag);
            }
        }
    }
}
