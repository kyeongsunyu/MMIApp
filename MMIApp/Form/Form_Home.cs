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
    enum HomeState
    {
        ALARM = 0,
        READY = 1,
        HOMMING = 2,
        COMPLETE = 3,
    }
    public partial class Form_Home : Form
    {
        private DevComponents.DotNetBar.ButtonX p_Button = null;

        private DevComponents.DotNetBar.ButtonX[] btnMTAxis;
        public Form_Home()
        {
            InitializeComponent();
            btnMTAxis = new DevComponents.DotNetBar.ButtonX[50];

            btnMTAxis[0] = btnAxis00;
            btnMTAxis[1] = btnAxis01;
            btnMTAxis[2] = btnAxis02;
            btnMTAxis[3] = btnAxis03;
            btnMTAxis[4] = btnAxis04;
            btnMTAxis[5] = btnAxis05;
            btnMTAxis[6] = btnAxis06;
            btnMTAxis[7] = btnAxis07;
            btnMTAxis[8] = btnAxis08;
            btnMTAxis[9] = btnAxis09;
            btnMTAxis[10] = btnAxis10;
            btnMTAxis[11] = btnAxis11;
            btnMTAxis[12] = btnAxis12;
            btnMTAxis[13] = btnAxis13;
            btnMTAxis[14] = btnAxis14;
            btnMTAxis[15] = btnAxis15;
            btnMTAxis[16] = btnAxis16;
            btnMTAxis[17] = btnAxis17;
            btnMTAxis[18] = btnAxis18;
            btnMTAxis[19] = btnAxis19;
            btnMTAxis[20] = btnAxis20;
            btnMTAxis[21] = btnAxis21;
            btnMTAxis[22] = btnAxis22;
            btnMTAxis[23] = btnAxis23;
            btnMTAxis[24] = btnAxis24;
            btnMTAxis[25] = btnAxis25;
            btnMTAxis[26] = btnAxis26;
            btnMTAxis[27] = btnAxis27;
            btnMTAxis[28] = btnAxis28;
            btnMTAxis[29] = btnAxis29;
            btnMTAxis[30] = btnAxis30;
            btnMTAxis[31] = btnAxis31;
            btnMTAxis[32] = btnAxis32;
            btnMTAxis[33] = btnAxis33;
            btnMTAxis[34] = btnAxis34;
            btnMTAxis[35] = btnAxis35;
            btnMTAxis[36] = btnAxis36;
            btnMTAxis[37] = btnAxis37;
            btnMTAxis[38] = btnAxis38;
            btnMTAxis[39] = btnAxis39;
            btnMTAxis[40] = btnAxis40;
            btnMTAxis[41] = btnAxis41;
            btnMTAxis[42] = btnAxis42;
            btnMTAxis[43] = btnAxis43;
            btnMTAxis[44] = btnAxis44;
        }
        private void Form_Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            MmiGV.bFormHomeShow = false;
        }

        private void btnAllHome_Click(object sender, EventArgs e)
        {
            MmiGV.pShMem.SetTenKey(99);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHome(object sender, EventArgs e)
        {
            p_Button = sender as DevComponents.DotNetBar.ButtonX;

            int nTag = int.TryParse(p_Button.Tag.ToString(), out nTag) ? nTag:-1;
            if (nTag >= 0)
            {
                MmiGV.pShMem.SetServoHome(nTag);
            }
        }

        private void tmRefresh_Tick(object sender, EventArgs e)
        {
            for(int i=0;i<45;i++)
            {
                if (MmiGV.pShMem.RMachineStatus.HomeState[i] == (int)HomeState.ALARM)
                {
                    btnMTAxis[i].BackColor = Color.Maroon;
                }
                else if (MmiGV.pShMem.RMachineStatus.HomeState[i] == (int)HomeState.READY)
                {
                    btnMTAxis[i].BackColor = Color.Black;
                }
                else if (MmiGV.pShMem.RMachineStatus.HomeState[i] == (int)HomeState.HOMMING)
                {
                    btnMTAxis[i].BackColor = Color.Green;
                }
                else if (MmiGV.pShMem.RMachineStatus.HomeState[i] == (int)HomeState.COMPLETE)
                {
                    btnMTAxis[i].BackColor = Color.Blue;
                }
            }
            
        }

        
    }
}
