using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
namespace MMI
{
    public partial class Form_Calendar : Form
    {
        [DllImport("uxtheme.dll", ExactSpelling = true, CharSet = CharSet.Unicode)]
        static extern int SetWindowTheme(IntPtr hwnd, string pszSubAppName, string pszSubIdList);

        private FormMain frmMain = null;

        public Form_Calendar()
        {
            InitializeComponent();
        }

        public Form_Calendar(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            Calendar.HandleCreated += (sender, e) =>
            {
                SetWindowTheme(Handle, string.Empty, string.Empty);
                base.OnHandleCreated(e);
            };
        }

        private void Form_Calendar_Load(object sender, EventArgs e)
        {
            btnDATE.Text = DateTime.Today.ToString("yyyy-MM-dd");
        }

        public string SHOW()
        {
            this.ShowDialog();
            return btnDATE.Text;
        }

        public void CLOSE()
        {
            this.Close();
        }

        private void Calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime dt = Calendar.SelectionStart;
            btnDATE.Text = dt.ToString("yyyy-MM-dd");
            Close();
        }
    }
}
