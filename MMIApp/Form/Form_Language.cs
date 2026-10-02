using System;
using System.Windows.Forms;

namespace MMI
{
    // Lang on the top bar: pick English, Korean or Chinese for this session.
    // The captions themselves come from Language\<code>.lang through
    // CLanguage; this only asks which one.
    public partial class Form_Language : Form
    {
        private FormMain frmMain = null;

        private string strChosen = null;

        public Form_Language()
        {
            InitializeComponent();
        }

        public Form_Language(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }

        // Shows the choice with the current language marked. False when the
        // pop-up was closed without a choice.
        public bool Choose(string strCurrent, out string strLanguage)
        {
            strChosen = null;
            btnEN.Checked = (strCurrent == "EN");
            btnKO.Checked = (strCurrent == "KO");
            btnZH.Checked = (strCurrent == "ZH");

            ShowDialog(frmMain);

            strLanguage = strChosen;
            return strChosen != null;
        }

        private void btnLanguage_Click(object sender, EventArgs e)
        {
            strChosen = Convert.ToString(((Control)sender).Tag);
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
