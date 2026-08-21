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
    public partial class FormMotorView : Form
    {
        private FormMain frmMain = null;

        public FormMotorView()
        {
            InitializeComponent();
        }
        public FormMotorView(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }
    }
}
