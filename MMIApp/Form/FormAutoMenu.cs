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
    public partial class FormAutoMenu : Form
    {
        private FormMain frmMain = null;

        private DevComponents.DotNetBar.ButtonX p_Button = null;
        private DevComponents.DotNetBar.ButtonX p_bfButton = null;

        private int ibfButtonTag = 11;


        public FormAutoMenu()
        {
            InitializeComponent();
        }

        public FormAutoMenu(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            p_bfButton = btnMenuAuto1;

            btnMenuAuto1.Checked = true;
        }

        private void btnMenuClick(object sender, EventArgs e)
        {
            p_Button = sender as DevComponents.DotNetBar.ButtonX;

            if (ibfButtonTag == Convert.ToInt16(p_Button.Tag))
                return;

            MmiGV.bfViewAutoForm.Visible = false;

            int nTag = Convert.ToInt16(p_Button.Tag);

            switch (nTag)
            {
                case (int)MmiGV.eSCRNO.AUTO1:
                    MmiGV.ViewAutoForm = frmMain.frmAuto1;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.AUTO1;
                    frmMain.frmAuto1.BringToFront();
                    break;
                case (int)MmiGV.eSCRNO.AUTO2:
                    MmiGV.ViewAutoForm = frmMain.frmAuto2;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.AUTO2;
                    frmMain.frmAuto2.BringToFront();
                    break;

            }

            MmiGV.pShMem.SetDM(7, (uint)MmiGV.iScreenNo);

            MmiGV.ViewAutoForm.Visible = true;
            MmiGV.bfViewAutoForm = MmiGV.ViewAutoForm;

            p_bfButton.Checked = false;
            p_Button.Checked = true;

            p_bfButton = p_Button;
            ibfButtonTag = nTag;
        }
    }
}
