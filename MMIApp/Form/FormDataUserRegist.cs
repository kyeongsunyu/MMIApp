using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMI
{
    public partial class FormDataUserRegist : Form
    {
        private FormMain frmMain = null;

        public FormDataUserRegist()
        {
            InitializeComponent();
        }

        public FormDataUserRegist(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        private void FormDataUserRegist_Load(object sender, EventArgs e)
        {
            InitGrid();
        }

        private void InitGrid()
        {
            gdUser[0, 0] = "NO";
            gdUser[0, 1] = "USER";
            gdUser[0, 2] = "USER LEVEL";
            gdUser[0, 3] = "PASSWORD";

            for (int i = 1; i < gdUser.Rows.Count; i++)
            {
                gdUser[i, 0] = i;
                gdUser[i, 1] = "";
                gdUser[i, 2] = 0;
                gdUser[i, 3] = 0;
            }
        }

        private void FormDataUserRegist_Shown(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            string sSQL;
            int iLevel = 0;
            int iRecordCount = 0;

            InitGrid();

            sSQL = "SELECT * FROM PWD WHERE USER_LEVEL <= 4 ORDER BY USER_LEVEL DESC";

            if (SQLiteDB.Select(sSQL, ref SQLiteDB.ReaderPassword))
            {
                iRecordCount = SQLiteDB.RecCount("SELECT COUNT(USER_LEVEL) FROM PWD;");
                for (int i = 0; i < iRecordCount; i++)
                {
                    if (SQLiteDB.ReaderPassword.Read())
                    {
                        gdUser[i + 1, 0] = i + 1;
                        gdUser[i + 1, 1] = SQLiteDB.ReaderPassword["NAME"].ToString();
                        gdUser[i + 1, 2] = SQLiteDB.ReaderPassword["USER_LEVEL"].ToString();
                        gdUser[i + 1, 3] = SQLiteDB.ReaderPassword["PWNO"].ToString();
                    }
                }
            }

            if (SQLiteDB.ReaderPassword == null) return;
            SQLiteDB.ReaderPassword.Close();

            iLevel = int.Parse(gdUser[gdUser.Row, 2].ToString());
            switch (iLevel)
            {
                case 1:
                    rdOperator.Checked = true;
                    break;
                case 2:
                    rdMaintenance.Checked = true;
                    break;
                case 3:
                    rdEngineer.Checked = true;
                    break;
                case 4:
                    rdMaster.Checked = true;
                    break;
            }
            txtPassword.Text = gdUser[gdUser.Row, 3].ToString();
            txtConfirm.Text = gdUser[gdUser.Row, 3].ToString();
        }
        private void gdUser_Click(object sender, EventArgs e)
        {
            int iLevel;
            iLevel = int.TryParse(gdUser[gdUser.Row, 2].ToString(), out iLevel) ? iLevel : 0;

            switch (iLevel)
            {
                case 1:
                    rdOperator.Checked = true;
                    break;
                case 2:
                    rdMaintenance.Checked = true;
                    break;
                case 3:
                    rdEngineer.Checked = true;
                    break;
                case 4:
                    rdMaster.Checked = true;
                    break;
                default:
                    rdOperator.Checked = false;
                    rdMaintenance.Checked = false;
                    rdEngineer.Checked = false;
                    rdMaster.Checked = false;
                    break;
            }
            if (iLevel == 1 || iLevel==2 || iLevel==3 || iLevel == 4)
            {
                txtPassword.Text = gdUser[gdUser.Row, 3].ToString();
                txtConfirm.Text = gdUser[gdUser.Row, 3].ToString();
            }
            else
            {
                txtPassword.Text = "";
                txtConfirm.Text = "";
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            string strSQL = "";
            string strName = "";
            string strPwd = "";
            string strLevel = "";

            int iRow = gdUser.Row;

            strName = gdUser[iRow, 1].ToString();
            strLevel = gdUser[iRow, 2].ToString();
            strPwd = gdUser[iRow, 3].ToString();

            strSQL = "DELETE FROM PWD WHERE NAME = '" + strName +
                    "' AND USER_LEVEL= " + strLevel + 
                    " AND PWNO = '" + strPwd + "'";
            SQLiteDB.Execute(strSQL);

            LoadData();
        }

        private void btnSAVE_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            string strSQL = "";
            strSQL = "DELETE FROM PWD WHERE USER_LEVEL <= 4";

            SQLiteDB.Execute(strSQL);

            if(txtPassword.Text == txtConfirm.Text)
            {
                for(int iRow=1; iRow<gdUser.Rows.Count; iRow++)
                {
                    if (!string.IsNullOrEmpty(gdUser[iRow, 1].ToString()))
                    {
                        strSQL = "INSERT INTO PWD (NAME, USER_LEVEL, PWNO)";
                        strSQL += " VALUES ('";
                        strSQL += gdUser[iRow, 1].ToString() + "',";
                        strSQL += gdUser[iRow, 2].ToString() + ",'";
                        strSQL += gdUser[iRow, 3].ToString() + "')";
                        SQLiteDB.Execute(strSQL);
                    }
                }
                LoadData();
            }
            else
            {
                // "Password가 일치하지 않습니다"
            }
        }

        private void rdLevelClick(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;

            int iLevel = Convert.ToInt16(radioButton.Tag);
            int iRow = gdUser.Row;

            gdUser[iRow, 2] = iLevel;

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            int iRow = gdUser.Row;  
            if(txtPassword.Text == txtConfirm.Text)
            {
                gdUser[iRow, 3] = txtPassword.Text;
            }
        }

        private void txtConfirm_TextChanged(object sender, EventArgs e)
        {
            int iRow = gdUser.Row;
            if (txtPassword.Text == txtConfirm.Text)
            {
                gdUser[iRow, 3] = txtPassword.Text;
            }
        }
    }
}
