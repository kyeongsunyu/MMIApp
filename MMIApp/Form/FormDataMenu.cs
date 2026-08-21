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
    public partial class FormDataMenu : Form
    {
        private FormMain frmMain = null;

        private DevComponents.DotNetBar.ButtonX p_Button = null;
        private DevComponents.DotNetBar.ButtonX p_bfButton = null;

        private int ibfButtonTag = 41;
        public FormDataMenu()
        {
            InitializeComponent();
        }
        public FormDataMenu(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            p_bfButton = btnMenuRecipe;

            btnMenuRecipe.Checked = true;
        }

        private void btnMenuClick(object sender, EventArgs e)
        {
            p_Button = sender as DevComponents.DotNetBar.ButtonX;

            if (ibfButtonTag == Convert.ToInt16(p_Button.Tag))
                return;

            MmiGV.bfViewDataForm.Visible = false;

            int nTag = Convert.ToInt16(p_Button.Tag);

            switch (nTag)
            {
                case (int)MmiGV.eSCRNO.DATA_RECIPE:
                    MmiGV.ViewDataForm = frmMain.frmDataRecipe;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_RECIPE;
                    frmMain.frmDataRecipe.BringToFront();
                    break;
                case (int)MmiGV.eSCRNO.DATA_SYSTEMPARAM:
                    MmiGV.ViewDataForm = frmMain.frmDataSysParam;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_SYSTEMPARAM;
                    frmMain.frmDataSysParam.BringToFront();
                    break;
                case (int)MmiGV.eSCRNO.DATA_OPTION:
                    MmiGV.ViewDataForm = frmMain.frmDataOption;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_OPTION;
                    frmMain.frmDataOption.BringToFront();
                    break;
                case (int)MmiGV.eSCRNO.DATA_LAMPBUZZER:
                    MmiGV.ViewDataForm = frmMain.frmDataLampBuzzer;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_LAMPBUZZER;
                    frmMain.frmDataLampBuzzer.BringToFront();
                    break;
                case (int)MmiGV.eSCRNO.DATA_USERREGIST:
                    MmiGV.ViewDataForm = frmMain.frmDataUserRegist;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_USERREGIST;
                    frmMain.frmDataUserRegist.BringToFront();
                    break;
                case (int)MmiGV.eSCRNO.DATA_MOTOR_CONFIG:
                    MmiGV.bfViewDataForm.Visible = true;
                    if (MmiGV.frmMain.frm_NumPad.Display())
                    {
                        if (MmiGV.frmMain.frm_NumPad.GetValue() == 4899)
                        {
                            MmiGV.bfViewDataForm.Visible = false;
                            MmiGV.ViewDataForm = frmMain.frmDataMotorCFG;
                            MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_MOTOR_CONFIG;
                            frmMain.frmDataMotorCFG.Visible = true;
                            frmMain.frmDataMotorCFG.BringToFront();
                        }
                        else
                        {
                            MmiGV.ViewDataForm = frmMain.frmDataMotorCFG;
                            MmiGV.iScreenNo = (int)MmiGV.eSCRNO.DATA_MOTOR_CONFIG;
                            frmMain.frmDataMotorCFG.Visible = false;
                            //frmMain.frmDataMotorCFG.BringToFront();
                        }
                    }
                    break;
            }
            MmiGV.pShMem.SetDM(7, (uint)MmiGV.iScreenNo);

            MmiGV.ViewDataForm.Visible = true;
            MmiGV.bfViewDataForm = MmiGV.ViewDataForm;

            p_bfButton.Checked = false;
            p_Button.Checked = true;

            p_bfButton = p_Button;
            ibfButtonTag = nTag;
        }
    }
}
