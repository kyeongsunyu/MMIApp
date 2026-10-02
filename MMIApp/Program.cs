using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MMI
{
    internal static class Program
    {
        // One MMI per PC: a second would talk to SEQ on the same shared memory
        // and write the same DB. A named mutex holds even when the exe has been
        // renamed or copied, which the old process-name check did not.
        private const string InstanceMutexName = "MMI_Application";

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            bool bCreated;
            using (Mutex instance = new Mutex(true, InstanceMutexName, out bCreated))
            {
                if (!bCreated)
                {
                    BringRunningToFront();
                    MessageBox.Show("프로그램이 이미 실행되고 있습니다.");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new FormMain());

                GC.KeepAlive(instance);
            }
        }

        // The copy already running is usually behind something or minimised;
        // put it in front so the operator sees which one to use.
        private static void BringRunningToFront()
        {
            Process self = Process.GetCurrentProcess();
            foreach (Process p in Process.GetProcessesByName(self.ProcessName))
            {
                if (p.Id == self.Id || p.MainWindowHandle == IntPtr.Zero) continue;
                winapi.ShowWindow(p.MainWindowHandle, winapi.WindowShowStyle.Restore);
                winapi.SetForegroundWindow(p.MainWindowHandle);
                return;
            }
        }
    }
}
