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
    public partial class Form_PM : Form
    {
        private FormMain frmMain = null;

        public Form_PM()
        {
            InitializeComponent();
        }
        public Form_PM(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
            {
                Close();
            }
        }
    }
}
