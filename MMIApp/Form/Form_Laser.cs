using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;

namespace MMI
{
    public partial class Form_Laser : Form
    {
        private readonly string sProcName = "sirius";
        private IntPtr hSirius = IntPtr.Zero;
        private bool IsDocking;
        private Process procSirius;
        private window win;

        public Form_Laser()
        {
            InitializeComponent();
        }

        private void Form_Laser_Load(object sender, EventArgs e)
        {
            //SiriusLoad();
        }

        private void SiriusLoad()
        {
            try
            {
                #region Sirius Kill

                var proclist = Process.GetProcessesByName(sProcName);
                if (proclist.Length > 0)
                {
                    foreach (var pro in proclist)
                    {
                        pro.Kill();
                    }
                }

                #endregion

                #region Sirius Load

                lock (proclist)
                {
                    procSirius = new Process();
                    procSirius.StartInfo.CreateNoWindow = true;
                    procSirius.StartInfo.FileName = $"{sProcName}.exe";
                    procSirius.StartInfo.WorkingDirectory = @"d:/exe/";
                    procSirius.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                    procSirius.StartInfo.UseShellExecute = true;

                    procSirius.Start();

                    while (procSirius.WaitForInputIdle(100) == false) 
                        Thread.Sleep(10);
                }

                #endregion

                //if (procSirius != null) tmRefresh.Enabled = true;
            }
            catch (Exception e)
            {
                CThreadMMILog MMILog = CThreadMMILog.GetInstance;
                Debug.Assert(MMILog != null);

                MMILog.AddMMILog($"Sirius Loading Error - {e.Message}");
            }
        }

        public void CheckDocking()
        {
            if (win != null)
            {
                var size = Size.Empty;
                var loc = Point.Empty;
                loc.X = 0;
                loc.Y = 0;

                size.Height = 790;
                size.Width = 860;

                if (IsDocking)
                {
                    if (MmiGV.frmMain.frm_PWD.GetPassWord(MmiGV.iScreenNo))
                    {
                        win.RestoreParent();
                        win.Move(loc, size, true);
                        IsDocking = false;
                    }
                }
                else
                {
                    win.RestoreParent();
                    win.Move(pnLaser.Location, pnLaser.Size, true);
                    IsDocking = true;
                }

                return;
            }

            win = new window(procSirius.MainWindowHandle);
            win.SetParent(pnLaser.Handle);
            win.Move(pnLaser.Location, pnLaser.Size, true);
            IsDocking = true;
        }

        private void pnLaser_DoubleClick(object sender, EventArgs e)
        {
            //CheckDocking();
        }


    }

    
}
