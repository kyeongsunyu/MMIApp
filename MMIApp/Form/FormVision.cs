using System.Windows.Forms;

namespace MMI
{
    // Auto > VISION (screen 13, engineer level).
    //
    // The place for GrabDemo, the eGrabber (Coaxlink, CoaXPress) line scan
    // viewer with its centre line profile and six-section MTF. It is a
    // placeholder until that program is migrated: the cards show where the
    // image, the acquisition buttons, the profile and the MTF will go, and the
    // buttons stay disabled.
    public partial class FormVision : Form
    {
        private FormMain frmMain = null;

        public FormVision()
        {
            InitializeComponent();
        }

        public FormVision(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }
    }
}
