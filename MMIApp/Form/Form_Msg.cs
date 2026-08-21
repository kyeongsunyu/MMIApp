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
    public partial class Form_Msg : Form
    {
        private FormMain frmMain = null;

        bool bRtn;

        public Form_Msg()
        {
            InitializeComponent();
        }

        public Form_Msg(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
            this.TopLevel = true;
            this.TopMost = true;
        }

        private void Form_Msg_Load(object sender, EventArgs e)
        {
            
        }

        private void Form_Msg_Paint(object sender, PaintEventArgs e)
        {
            ControlPaint.DrawBorder(e.Graphics, ClientRectangle, Color.Gray, ButtonBorderStyle.Solid);
        }

        public bool ShowMessage(string strMsg)
        {
            bRtn = false;

            lblMsg.Text = strMsg;

            Visible = true;

            return bRtn;
        }

        public bool Display(string strMsg)
        {
            bRtn = false;
            lblMsg.Text = strMsg;

            ShowDialog();
            return bRtn;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            bRtn = true;
            Visible = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            bRtn = false;
            Visible = false;
        }
    }
}
