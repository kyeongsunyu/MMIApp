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
    public partial class FormLog : Form
    {
        private FormMain frmMain = null;

        public FormLog()
        {
            InitializeComponent();
        }
        public FormLog(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;

            InitListView();
        }

        private void InitListView()
        {
            lvSEQ.View = View.Details;
            lvSEQ.HeaderStyle = ColumnHeaderStyle.None;
            ColumnHeader h1= new ColumnHeader();
            h1.Width = 2048;// lvSEQ.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            lvSEQ.Columns.Add(h1);

            lvMMI.View = View.Details;
            lvMMI.HeaderStyle = ColumnHeaderStyle.None;
            ColumnHeader h2 = new ColumnHeader();
            h2.Width = 2048;// lvMMI.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            lvMMI.Columns.Add(h2);

            lvError.View = View.Details;
            lvError.HeaderStyle = ColumnHeaderStyle.None;
            ColumnHeader h3 = new ColumnHeader();
            h3.Width = 2048;// lvError.ClientSize.Width - SystemInformation.VerticalScrollBarWidth;
            lvError.Columns.Add(h3);
        }

        private void btnClear1_Click(object sender, EventArgs e)
        {
            if (tabLOG.SelectedTab == tabLOG.Tabs[0])
            {
                lvSEQ.Items.Clear();
            }
            else if(tabLOG.SelectedTab == tabLOG.Tabs[1])
            {
                lvMMI.Items.Clear();
            }
        }
        private void btnClear2_Click(object sender, EventArgs e)
        {
            lvError.Items.Clear();
        }


    }
}
