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
    public partial class FormManualMenu : Form
    {
        private FormMain frmMain = null;

        private DevComponents.DotNetBar.ButtonX p_Button = null;
        private DevComponents.DotNetBar.ButtonX p_bfButton = null;

        private int ibfButtonTag = 21;

        public FormManualMenu()
        {
            InitializeComponent();
        }

        public FormManualMenu(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            p_bfButton = btnMenuList;

            btnMenuList.Checked = true;
            
        }

        private void btnMenuClick(object sender, EventArgs e)
        {
            p_Button = sender as DevComponents.DotNetBar.ButtonX;

            if (ibfButtonTag == Convert.ToInt16(p_Button.Tag))
                return;

            MmiGV.bfViewManualForm.Visible = false;

            int nTag = Convert.ToInt16(p_Button.Tag);

            switch (nTag)
            {
                case (int)MmiGV.eSCRNO.MANUAL_LIST:
                    MmiGV.ViewManualForm = frmMain.frmManualList;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.MANUAL_LIST;
                    frmMain.frmManualList.BringToFront();
                    break;
                case (int)MmiGV.eSCRNO.MANUAL_OP:
                    MmiGV.ViewManualForm = frmMain.frmManualOP;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.MANUAL_OP;
                    frmMain.frmManualOP.BringToFront();
                    break;
            }
            MmiGV.pShMem.SetDM(7, (uint)MmiGV.iScreenNo);

            MmiGV.ViewManualForm.Visible = true;
            MmiGV.bfViewManualForm = MmiGV.ViewManualForm;

            p_bfButton.Checked = false;
            p_Button.Checked = true;

            p_bfButton = p_Button;
            ibfButtonTag = nTag;
        }
    }
}
