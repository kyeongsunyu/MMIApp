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
    public partial class FormMotorMenu : Form
    {
        private FormMain frmMain = null;

        private DevComponents.DotNetBar.ButtonX p_Button = null;
        private DevComponents.DotNetBar.ButtonX p_bfButton = null;

        private int ibfButtonTag = 31;

        public FormMotorMenu()
        {
            InitializeComponent();
        }
        public FormMotorMenu(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            p_bfButton = btnMenuMotorSetting;

            btnMenuMotorSetting.Checked = true;
        }

        private void btnMenuClick(object sender, EventArgs e)
        {
            p_Button = sender as DevComponents.DotNetBar.ButtonX;

            if (ibfButtonTag == Convert.ToInt16(p_Button.Tag))
                return;

            MmiGV.bfViewMotorForm.Visible = false;

            int nTag = Convert.ToInt16(p_Button.Tag);

            switch (nTag)
            {
                case (int)MmiGV.eSCRNO.MOTOR_SETTING:
                    MmiGV.ViewMotorForm = frmMain.frmMotorSetting;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.MOTOR_SETTING;
                    frmMain.frmAuto1.BringToFront();
                    break;
                case 32:

                    break;

            }
            MmiGV.pShMem.SetDM(7, (uint)MmiGV.iScreenNo);

            MmiGV.ViewMotorForm.Visible = true;
            MmiGV.bfViewMotorForm = MmiGV.ViewMotorForm;

            p_bfButton.Checked = false;
            p_Button.Checked = true;

            p_bfButton = p_Button;
            ibfButtonTag = nTag;
        }
    }
}
