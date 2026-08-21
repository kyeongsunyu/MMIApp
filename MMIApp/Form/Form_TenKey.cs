using DevComponents.Instrumentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMI
{
    public partial class Form_TenKey : Form
    {
        private FormMain frmMain = null;
        int iTenkeyValue;

        public Form_TenKey()
        {
            InitializeComponent();
            this.TopLevel = true;
            this.TopMost = true;
        }
        public Form_TenKey(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            InitControl();

            this.TopLevel = true;
            this.TopMost = true;
        }

        private void Form_TenKey_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }
        private void InitControl()
        {
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
            btn_SHARP.Paint += ButtonPaint;
            btn_STAR.Paint += ButtonPaint;

            lblTenKey.Text = "000";
        }
        public void DISPLAY()
        {
            Show();
        }
        private void btnTenKey_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int iKeyNo = int.Parse(btn.Tag.ToString());
            string sVal = string.Format("{0:D3}", lblTenKey.Text);

            switch (iKeyNo)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                case 7:
                case 8:
                case 9:
                    sVal += iKeyNo.ToString();
                    sVal = sVal.Substring(Math.Abs(4 - sVal.Length) + 1, 3);
                    break;
                default:
                    sVal = "000";
                    break;
            }
            int iDummy = int.Parse(sVal.ToString());
            if (iDummy > 399)
            {
                iDummy = iDummy % 100;
                if (iDummy == 0)
                {
                    sVal = "000";
                }
                else
                {
                    sVal = "00" + iDummy.ToString();
                }
            }

            lblTenKey.Text = sVal;

            iTenkeyValue = int.Parse(sVal.ToString());

            if (iTenkeyValue != 0)
            {
                string strSQL = "SELECT * FROM TENKEY WHERE IDX=" + iTenkeyValue;
                if(SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderTENKEY))
                {
                    if (SQLiteDB.ReaderTENKEY.Read())
                    {
                        lblItem.Text = SQLiteDB.ReaderTENKEY["ITEMS"].ToString();
                    }
                    SQLiteDB.ReaderTENKEY.Close();
                }
                else
                {
                    lblItem.Text = "";
                }
            }
            else
            {
                lblItem.Text = "";
            }
        }

        private void btn_SHARP_Click(object sender, EventArgs e)
        {
            btn_SHARP.Enabled = false;
            //SeqGV.ManualNumber = (uint)iTenkeyValue;
            //CSEQ.ManualTenkeyOperation();

            MmiGV.pShMem.SetTenKey((uint)iTenkeyValue);

            btn_SHARP.Enabled = true;
        }
        private void ButtonPaint(object sender, PaintEventArgs e)
        {
            ///<버튼 테두리 Color>
            #region 버튼테두리 Color
            base.OnPaint(e);
            Color borderColor = Color.Gray;
            int borderWidth = 1;

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid);
            #endregion 버튼테두리 Color


            #region 버튼 모양
            Button btn = sender as Button;
            IntPtr ip = WIN32Helper.CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 30, 30);
            int i = WIN32Helper.SetWindowRgn(btn.Handle, ip, true);
            #endregion 버튼 모양

        }
    }
}
