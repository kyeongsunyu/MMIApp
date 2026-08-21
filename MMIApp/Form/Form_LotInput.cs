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
    public partial class Form_LotInput : Form
    {
        private bool bRtn = false;

        public Form_LotInput()
        {
            InitializeComponent();
        }

        public bool Display()
        {
            bRtn = false;
            txtLotID.Text = MmiGV.LotInfo.strLotID;
            txtLotCount.Text = MmiGV.LotInfo.LotCnt.ToString();

            //this.Visible = true;
            ShowDialog();
            return bRtn;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            int ival = 0;
            MmiGV.LotInfo.strLotID = txtLotID.Text;
            ival = (int.TryParse(txtLotCount.Text, out ival)) ? ival : 0;
            MmiGV.LotInfo.LotCnt = ival;

            Close();
            bRtn = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            bRtn = false;
        }
    }
}
