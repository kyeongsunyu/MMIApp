using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMI
{
    public partial class Form_UserLogIn : Form
    {
        private FormMain frmMain = null;
        bool bRet = false;

        public Form_UserLogIn()
        {
            InitializeComponent();
        }

        public Form_UserLogIn(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }
        public bool DISPLAY(int iMode)
        {
            bRet = false;
            cbUser.Items.Clear();
            txtPassword.Text = string.Empty;
            string strSQL = "SELECT * FROM PWD ORDER BY USER_LEVEL ASC";

            int iRecordCount = SQLiteDB.RecCount("SELECT COUNT(USER_LEVEL) FROM PWD");
            if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderPassword))
            {
                for (int i = 0; i < iRecordCount; i++)
                {
                    if (SQLiteDB.ReaderPassword.Read())
                    {
                        cbUser.Items.Add(SQLiteDB.ReaderPassword["NAME"].ToString());
                    }
                }
            }
            if(iMode == (int)MmiGV.eFormShowMode.MODAL)
            {
                ShowDialog();
            }
            else if (iMode == (int)MmiGV.eFormShowMode.MODALLESS)
            {
                Show();
            }
            else
            {

            }
            return bRet;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string strSQL = "SELECT * FROM PWD WHERE NAME = '" + cbUser.Text.Trim() + "'";
            if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderPassword))
            {
                if (SQLiteDB.ReaderPassword.Read())
                {
                    string strPW = SQLiteDB.ReaderPassword["PWNO"].ToString();
                    if(txtPassword.Text.Trim() == strPW.Trim())
                    {
                        MmiGV.UserInfo.iUserLevel = int.Parse(SQLiteDB.ReaderPassword["USER_LEVEL"].ToString());
                        MmiGV.UserInfo.strUserName = SQLiteDB.ReaderPassword["NAME"].ToString();
                        MmiGV.UserInfo.strUserPassword = SQLiteDB.ReaderPassword["PWNO"].ToString();

                        
                        bRet = true;
                        Close();

                        // delegate 호출
                    }
                    else
                    {
                        MessageBox.Show("Invalid Password");
                        bRet = false;
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bRet = false;
            Close();
        }
    }
}
