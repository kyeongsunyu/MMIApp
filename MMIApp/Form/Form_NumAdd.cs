using DevComponents.Instrumentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMI
{
    public partial class Form_NumAdd : Form
    {
        bool bRtn;
        double dRetVal;

        private FormMain frmMain = null;

        public Form_NumAdd()
        {
            InitializeComponent();
        }
        public Form_NumAdd(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            InitControl();
        }

        private void Form_NumAdd_Paint(object sender, PaintEventArgs e)
        {
        //    ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        public bool Display(double dCurrent)
        {
            bRtn = false;
            dRetVal = 0.0;

            lblCurrent.Text = string.Format("{0:F3}", dCurrent);
            lblNum.Text = "        ";

            ShowDialog();

            Console.WriteLine("dRetVal={0}", dRetVal);
            return bRtn;
        }

        public double GetValue()
        {
            return dRetVal + double.Parse(lblCurrent.Text);
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
            btn_SIGN.Paint += ButtonPaint;
            btn_Enter.Paint += ButtonPaint;

            lblNum.Text = "        ";
            lblCurrent.Text = "        ";

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

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int iKeyNo = int.Parse(btn.Tag.ToString());
            //String sVal = "          " + indi_NUM.Text;
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
                    if (sVal.IndexOf(".") > 0)
                    {
                        if (Math.Abs(sVal.Length - sVal.IndexOf(".")) >= 3)
                        {
                            sVal.Remove(sVal.Length-1, 1);
                        }
                    }
                    sVal += iKeyNo.ToString();
                    break;
                case 10:    // DOT
                    while (sVal.IndexOf(".") > 0)
                    {
                        sVal = sVal.Remove(sVal.IndexOf("."), 1);
                    }
                    sVal += ".";
                    break;
                case 11:    // DEL
                    sVal = sVal.Remove(sVal.Length - 1, 1);
                    break;
                case 12:    // ENTER Key
                    bRtn = true;
                    Close();
                    break;
                case 13:
                    int idx2 = sVal.Trim().IndexOf("-");
                    if (idx2 >= 0)
                    {
                        sVal = sVal.Trim().Remove(idx2, 1);
                    }
                    else
                    {
                        sVal = sVal.Trim().Insert(0, "-");
                    }
                    sVal = "          " + sVal;
                    break;
            }

            sVal = sVal.Substring(Math.Abs(8 - sVal.Length), 8);

            try
            {
                dRetVal = double.Parse(sVal);
            }
            catch (FormatException ex)
            {
                dRetVal = 0.0;
                Console.WriteLine("ex.Message = {0}", ex.Message);
            }
            lblNum.Text = sVal;
        }

        private void lblCurrent_Click(object sender, EventArgs e)
        {
            lblCurrent.Text = string.Format("{0:F3}", 0);
        }
    }
}
