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
    public partial class FormAlarmMenu : Form
    {
        private FormMain frmMain = null;

        private DevComponents.DotNetBar.ButtonX p_Button = null;
        private DevComponents.DotNetBar.ButtonX p_bfButton = null;

        private int ibfButtonTag = 61;

        public FormAlarmMenu()
        {
            InitializeComponent();
        }

        public FormAlarmMenu(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            p_bfButton = btnMenuAlarm;

            btnMenuAlarm.Checked = true;
        }

        private void btnMenuClick(object sender, EventArgs e)
        {
            p_Button = sender as DevComponents.DotNetBar.ButtonX;

            if (ibfButtonTag == Convert.ToInt16(p_Button.Tag))
                return;

            MmiGV.bfViewAlarmForm.Visible = false;

            int nTag = Convert.ToInt16(p_Button.Tag);

            switch (nTag)
            {
                case (int)MmiGV.eSCRNO.ALARM_LIST:
                    MmiGV.ViewAlarmForm = frmMain.frmAlarmList;
                    MmiGV.iScreenNo = (int)MmiGV.eSCRNO.ALARM_LIST;
                    frmMain.frmAlarmList.BringToFront();
                    break;
            }

            MmiGV.ViewAlarmForm.Visible = true;
            MmiGV.bfViewAlarmForm = MmiGV.ViewAlarmForm;

            p_bfButton.Checked = false;
            p_Button.Checked = true;

            p_bfButton = p_Button;
            ibfButtonTag = nTag;


        }
    }
}
