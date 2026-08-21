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
    public partial class Form_TimeInput : Form
    {
        private FormMain frmMain = null;

        public Form_TimeInput()
        {
            InitializeComponent();
        }

        public Form_TimeInput(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            InitControl();
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
            btn_DOT.Paint += ButtonPaint;
            btn_DEL.Paint += ButtonPaint;
            btn_Enter.Paint += ButtonPaint;

            lblNum.Text = "        ";
        }

        private void ButtonPaint(object sender, PaintEventArgs e)
        {
            ///<버튼 테두리 Color>
            base.OnPaint(e);
            Color borderColor = Color.Gray;
            int borderWidth = 1;

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid,
                borderColor, borderWidth, ButtonBorderStyle.Solid);
            ///</버튼 테두리 Color>


            ///<버튼 모양r>
            Button btn = sender as Button;
            IntPtr ip = WIN32Helper.CreateRoundRectRgn(0, 0, btn.Width, btn.Height, 30, 30);
            int i = WIN32Helper.SetWindowRgn(btn.Handle, ip, true);
            ///</버튼 모양r>

        }


        private void TimeInputClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int iKeyNo = int.Parse(btn.Tag.ToString());
            String sVal = "        " + lblNum.Text;

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
                    break;
                case 10:    // DOT
                    sVal += ":";
                    break;
                case 11:    // DEL
                    sVal = sVal.Remove(sVal.Length - 1, 1);
                    break;
                case 12:    // ENTER Key
                    Close();
                    break;
            }

            sVal = sVal.Substring(Math.Abs(8 - sVal.Length), 8);
            lblNum.Text = sVal;
        }

        public string SHOW()
        {
            lblNum.Text = "          ";
            ShowDialog();
            return lblNum.Text.Trim();
        }
    }
}
