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
    public partial class FormMonitorMenu : Form
    {
        private FormMain frmMain = null;

        private DevComponents.DotNetBar.ButtonX p_Button = null;
        private DevComponents.DotNetBar.ButtonX p_bfButton = null;

        private int ibfButtonTag = 51;

        public FormMonitorMenu()
        {
            InitializeComponent();
        }
        public FormMonitorMenu(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            p_bfButton = btnMenuIO;

            btnMenuIO.Checked = true;
        }

        private void btnMenuClick(object sender, EventArgs e)
        {
            p_Button = sender as DevComponents.DotNetBar.ButtonX;

            if (ibfButtonTag == Convert.ToInt16(p_Button.Tag))
                return;

            MmiGV.bfViewMonitorForm.Visible = false;

            int nTag = Convert.ToInt16(p_Button.Tag);

            switch (nTag)
            {
                case (int)MmiGV.eSCRNO.MONITOR_IO:
                    MmiGV.ViewMonitorForm = frmMain.frmMonitorIO;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.MONITOR_IO;
                    frmMain.frmMonitorIO.BringToFront();
                    break;
                case (int)MmiGV.eSCRNO.MONITOR_DMBIT:
                    MmiGV.ViewMonitorForm = frmMain.frmMonitorBitDM;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.MONITOR_DMBIT;
                    frmMain.frmMonitorBitDM.BringToFront();
                    break;
            }
            MmiGV.pShMem.SetDM(7, (uint)MmiGV.iScreenNo);

            MmiGV.ViewMonitorForm.Visible = true;
            MmiGV.bfViewMonitorForm = MmiGV.ViewMonitorForm;

            p_bfButton.Checked = false;
            p_Button.Checked = true;

            p_bfButton = p_Button;
            ibfButtonTag = nTag;
        }
    }
}
