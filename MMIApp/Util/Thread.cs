using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MMI
{
    class ThreadParam
    {
        public int iValue1 = 0;
        public int iValue2 = 0;
    }
    class CThread
    {
        public static Thread ThreadMain = null;
        public static Thread ThreadSequence = null;
        public static Thread ThreadMotion1 = null;
        public static Thread ThreadMotion2 = null;
        public static Thread ThreadMotion3 = null;
        public static Thread ThreadMotion4 = null;

        public static Thread ThreadSeqLogMsg = null;
        public static Thread ThreadMMILogMsg = null;

        public static Thread[] TH = new Thread[20];

        public static void CreateThread(Thread thread, /*ThreadStart p,*/ ThreadPriority priority)
        {
            //    thread = new Thread(new ThreadStart(p));
            thread.IsBackground = true;
            thread.Priority = priority;
            thread.Start();
        }

        public static void Abort(Thread th)
        {
            th.Abort();
        }
    }
}
