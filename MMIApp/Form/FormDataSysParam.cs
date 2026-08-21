using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using C1.Win.C1FlexGrid;

namespace MMI
{
    public partial class FormDataSysParam : Form
    {
        private FormMain frmMain = null;
        DevComponents.DotNetBar.LabelX[] dSys;

        public FormDataSysParam()
        {
            InitializeComponent();
        }
        public FormDataSysParam(FormMain frm)
        {
            InitializeComponent();

            this.frmMain = frm;
            dSys = new DevComponents.DotNetBar.LabelX[21];

            int cnt = 0;
            dSys[cnt] = lblSys001; cnt++;
            dSys[cnt] = lblSys002; cnt++;
            dSys[cnt] = lblSys003; cnt++;
            dSys[cnt] = lblSys004; cnt++;
            dSys[cnt] = lblSys005; cnt++;
            dSys[cnt] = lblSys006; cnt++;
            dSys[cnt] = lblSys007; cnt++;
            dSys[cnt] = lblSys008; cnt++;
            dSys[cnt] = lblSys009; cnt++;
            dSys[cnt] = lblSys010; cnt++;
            dSys[cnt] = lblSys011; cnt++;
            dSys[cnt] = lblSys012; cnt++;
            dSys[cnt] = lblSys013; cnt++;
            dSys[cnt] = lblSys014; cnt++;
            dSys[cnt] = lblSys015; cnt++;
            dSys[cnt] = lblSys016; cnt++;
            dSys[cnt] = lblSys017; cnt++;
            dSys[cnt] = lblSys018; cnt++;
            dSys[cnt] = lblSys019; cnt++;
            dSys[cnt] = lblSys020; cnt++;
            dSys[cnt] = lblSys021;
        }
        private void FormDataSysParam_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            int cnt = 0;
            string strSQL = "SELECT * FROM MACHINEPARAM ORDER BY IDX ASC";
            if (SQLiteDB.Select(strSQL, ref SQLiteDB.ReaderMachineParam))
            {
                while (SQLiteDB.ReaderMachineParam.Read())
                {
                    int idx = Convert.ToInt32(SQLiteDB.ReaderMachineParam["IDX"]);
                    string name = string.Format("{0}", SQLiteDB.ReaderMachineParam["ITEM"]);
                    double val = Convert.ToDouble(SQLiteDB.ReaderMachineParam["DATA"]);
                    string unit = string.Format("{0}", SQLiteDB.ReaderMachineParam["UNIT"]);

                    dSys[cnt].Text = $"{(int)val:N0}";// val.ToString("F0");
                    cnt++;
                    if (cnt >= dSys.Length) break;

                    /*
                    gdSystem[idx + 1, 0] = idx + 1;
                    gdSystem[idx + 1, 1] = name;
                    gdSystem[idx + 1, 2] = val;
                    gdSystem[idx + 1, 3] = unit;
                    */
                }
            }

            if (SQLiteDB.ReaderMachineParam == null) return;
            SQLiteDB.ReaderMachineParam.Close();
            
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            /*
            btnEdit.Checked = !btnEdit.Checked;

            if (!btnEdit.Checked)
            {
                gdSystem.AllowEditing = false;
            }
            else
            {
                if (MmiGV.frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
                {
                    gdSystem.AllowEditing = true;
                }
            }*/
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (MmiGV.frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
            {
                string strSQL;
                for(int i=0;i< dSys.Length; i++)
                {
                    //string name = gdSystem[i+1, 1].ToString();
                    double dVal = double.TryParse( dSys[i].Text.ToString(), out dVal) ? dVal : 0.0;
                    //string unit = gdSystem[i+1, 3].ToString();

                    strSQL = "UPDATE MACHINEPARAM SET ";
                    //strSQL += " ITEM=";
                    //strSQL += "'" + name + "'" + ",";
                    strSQL += " DATA=";
                    strSQL += "'" + dVal.ToString() + "'";  // + ",";
                    //strSQL += " UNIT=";
                    //strSQL += "'" + unit + "'";
                    strSQL += " WHERE IDX=" + i.ToString();

                    MmiGV.pShMem.WSystemData.dData[i] = dVal;
                    SQLiteDB.Execute(strSQL);
                }

                MmiGV.pShMem.SetSystemData();

                btnEdit.Checked = false;
                //gdSystem.AllowEditing = false;

                LoadData();
            }
        }

        private void lblSys001_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void GetValue(object sender, bool isFloat = true)
        {
            double dVelData = 0;

            if (frmMain.frm_NumPad.Display())
            {
                dVelData = frmMain.frm_NumPad.GetValue();

                if (isFloat)
                { ((DevComponents.DotNetBar.LabelX)sender).Text = dVelData.ToString("F2"); }
                else
                { ((DevComponents.DotNetBar.LabelX)sender).Text = dVelData.ToString("F0"); }
            }
        }

        private void lblSys002_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys003_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys004_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys005_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys006_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys007_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys008_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys009_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys010_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys011_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys012_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys013_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys014_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys015_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys016_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys017_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }
        private void tmUpdate_Tick(object sender, EventArgs e)
        {
            for(int i = 0; i < dSys.Length; i++)//17
            {
                uint LifeTimeCnt = MmiGV.pShMem.GetDM(100 + i);
                string name = "lblCurrVal" + $"{i+1:000}";

                DevComponents.DotNetBar.LabelX lbl = (DevComponents.DotNetBar.LabelX)this.Controls.Find(name, true)[0];
                if (lbl != null)
                {
                    lbl.Text = $"{LifeTimeCnt:N000}";
                }
            }
        }

        private void lbl_DoubleClick(object sender, EventArgs e)
        {
            if (MmiGV.dmData.DMValue[1] == 1) return;

            if (frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
            {
                string lblname = ((DevComponents.DotNetBar.LabelX)sender).Name;
                string result = Regex.Replace(lblname, @"[^0-9]", "");
                int dmnum = 100 + int.Parse(result) - 1;
                MmiGV.pShMem.SetDM( dmnum, 0);
            }
        }

        private void lblSys018_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys019_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys020_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }

        private void lblSys021_Click(object sender, EventArgs e)
        {
            GetValue(sender, false);
        }
    }
}
