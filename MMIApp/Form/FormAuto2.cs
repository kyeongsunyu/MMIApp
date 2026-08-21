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
    public partial class FormAuto2 : Form
    {
        private FormMain frmMain = null;
        public FormAuto2()
        {
            InitializeComponent();
        }

        public FormAuto2(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
        }
    }
}
