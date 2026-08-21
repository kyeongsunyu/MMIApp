using DevComponents.Instrumentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMI
{
    public partial class Form_PWD : Form
    {
        private FormMain frmMain = null;

        int iPwdLevel;
        int iLastPwdLevel;
        int iInputCount = 0;

        bool bResult;

        public Form_PWD()
        {
            InitializeComponent();
        }

        public Form_PWD(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            InitControl();
        }
        private void Form_PWD_Load(object sender, EventArgs e)
        {

        }
        private void Form_PWD_Paint(object sender, PaintEventArgs e)
        {
            //ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        private void InitControl()
        {
            txtPassword.Text = "";

            btnNO_0.Paint += ButtonPaint;
            btnNO_1.Paint += ButtonPaint;
            btnNO_2.Paint += ButtonPaint;
            btnNO_3.Paint += ButtonPaint;
            btnNO_4.Paint += ButtonPaint;
            btnNO_5.Paint += ButtonPaint;
            btnNO_6.Paint += ButtonPaint;
            btnNO_7.Paint += ButtonPaint;
            btnNO_8.Paint += ButtonPaint;
            btnNO_9.Paint += ButtonPaint;
            btn_DEL.Paint += ButtonPaint;
            btn_Enter.Paint += ButtonPaint;
        }
        private void ButtonPaint(object sender, PaintEventArgs e)
        {
            #region <버튼 테두리 Color>
            base.OnPaint(e);
            Color borderColor = Color.Gray;
            int borderWidth = 1;

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid);
            #endregion <버튼 테두리 Color>

            #region <버튼 모양r>
            Button btn = sender as Button;
            IntPtr ip = WIN32Helper.CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 30, 30);
            int i = WIN32Helper.SetWindowRgn(btn.Handle, ip, true);
            #endregion <버튼 모양r>

        }

        public bool GetPassWord(int iSeceen)
        {
            string strSQL;
            strSQL =  "SELECT * FROM PWDLEVEL";
            strSQL += " WHERE SCR_INDEX = " + iSeceen.ToString();

            iPwdLevel = 0;
            bResult = false;
            txtPassword.Text = "";

            int iRecordCount = SQLiteDB.RecCount("SELECT COUNT(SCR_INDEX) FROM PWDLEVEL;");
            if (MmiGV.bPasswordSkip)
            {
                bResult = true;
            }
            else
            {
                if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderPasswordLevel))
                {
                    if (iRecordCount > 0)
                    {
                        if (SQLiteDB.ReaderPasswordLevel.Read())
                        {
                            iPwdLevel = int.Parse(SQLiteDB.ReaderPasswordLevel["USER_LEVEL"].ToString());
                            iInputCount = 0;
                            ShowDialog();
                        }
                    }
                }
            }
            return bResult;
        }

        private void DecodePassword()
        {
            string strSQL;
            strSQL = "SELECT * FROM PWD ORDER BY USER_LEVEL, NAME DESC";

            int iRecordCount = SQLiteDB.RecCount("SELECT COUNT(NAME) FROM PWD;");

            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderPassword))
            {
                iInputCount++;
                for(int i = 0; i<iRecordCount; i++)
                {
                    if (SQLiteDB.ReaderPassword.Read())
                    {
                        if (SQLiteDB.ReaderPassword["PWNO"].ToString().Trim() == txtPassword.Text.Trim())
                        {
                            iLastPwdLevel = (int.TryParse(SQLiteDB.ReaderPassword["USER_LEVEL"].ToString(), out iLastPwdLevel)) ? iLastPwdLevel : 1;
                            if (iLastPwdLevel >= iPwdLevel)
                            {
                                bResult = true;
                                // Password input succeed
                                break;
                            }
                        }
                    }
                }
                SQLiteDB.ReaderPassword.Close();
            }

            if (!bResult)
            {
                MessageBox.Show("INVALID PASSWORD!");
            }
        }

        private void btnNoClick(object sender, EventArgs e)
        {
            string strPWD = txtPassword.Text;
            int iKeyNo;

            Button pButton = sender as Button;
            iKeyNo = int.Parse(pButton.Tag.ToString());

            if (strPWD.Length > 10)
            {
                strPWD.Remove(1, 1);
            }
            strPWD += iKeyNo.ToString();
            txtPassword.Text = strPWD;
        }

        private void btn_Enter_Click(object sender, EventArgs e)
        {
            if (iInputCount > 3)
            {
                MessageBox.Show("TOO MUCH WRONG PASSWORD INPUT...");
                Close();
            }
            else
            {
                DecodePassword();
                if (bResult)
                {
                    Close();
                }
            }
            txtPassword.Text = "";
        }

        private void btn_DEL_Click(object sender, EventArgs e)
        {
            txtPassword.Text = "";
        }
    }
}
