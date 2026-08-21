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
    public partial class FormLogMenu : Form
    {
        private FormMain frmMain = null;

        private DevComponents.DotNetBar.ButtonX p_Button = null;
        private DevComponents.DotNetBar.ButtonX p_bfButton = null;

        private int ibfButtonTag = 71;

        public FormLogMenu()
        {
            InitializeComponent();
        }

        public FormLogMenu(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            p_bfButton = btnMenuLog;

            btnMenuLog.Checked = true;
        }

        private void btnMenuClick(object sender, EventArgs e)
        {
            p_Button = sender as DevComponents.DotNetBar.ButtonX;

            if (ibfButtonTag == Convert.ToInt16(p_Button.Tag))
                return;

            MmiGV.bfViewLogForm.Visible = false;

            int nTag = Convert.ToInt16(p_Button.Tag);

            switch (nTag)
            {
                case (int)MmiGV.eSCRNO.LOG:
                    MmiGV.ViewLogForm = frmMain.frmLog;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.LOG;
                    frmMain.frmLog.BringToFront();
                    break;
                case (int)MmiGV.eSCRNO.LOG_ERROR:
                    MmiGV.ViewLogForm = frmMain.frmLogError;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.LOG_ERROR;
                    frmMain.frmLogError.BringToFront();
                    break;
                case (int)MmiGV.eSCRNO.LOG_MTBAMTBF:
                    MmiGV.ViewLogForm = frmMain.frmLogMTBA;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.LOG_MTBAMTBF;
                    frmMain.frmLogMTBA.BringToFront();
                    break;
            }
            MmiGV.pShMem.SetDM(7, (uint)MmiGV.iScreenNo);

            MmiGV.ViewLogForm.Visible = true;
            MmiGV.bfViewLogForm = MmiGV.ViewLogForm;

            p_bfButton.Checked = false;
            p_Button.Checked = true;

            p_bfButton = p_Button;
            ibfButtonTag = nTag;
        }
    }
}
