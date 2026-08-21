using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;
using System.IO;
namespace MMI
{
    [Flags]
    public enum SendMessageTimeoutFlags : uint
    {
        SMTO_NORMAL = 0x0,
        SMTO_BLOCK = 0x1,
        SMTO_ABORTIFHUNG = 0x2,
        SMTO_NOTIMEOUTIFNOTHUNG = 0x8,
        SMTO_ERRORONEXIT = 0x0020
    }

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct CSHARP_TEST
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 128)]
        public string strLotID;

        [MarshalAs(UnmanagedType.I4)]
        public int nLotCount;
    };

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct SEQ_NOTIFY_MSG
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 512)]
        public string strMsg;
    };

    public class WIN32Helper
    {
        #region SINGLETON
        private static readonly Lazy<WIN32Helper> instance = new Lazy<WIN32Helper>(() => new WIN32Helper());
        public static WIN32Helper GetInstance
        {
            get { return instance.Value; }
        }
        #endregion SINGLETON

        public enum eMessageTarget
        {
            SEQ_MODULE = 0x00,
            MMI_MODULE = 0x01,
            COMM_MODULE = 0x02,
            ALL_MODULE = 0x03,
        };

        #region MESSAGE_DEFINE
        public static uint WM_COPYDATA = 74;

        public static uint WM_APP = 0x8000;
        
        public static uint WM_APP_LINK_REQ = (WM_APP + 101);
        public static uint WM_APP_LINK_RSP = (WM_APP + 102);
        
        public static uint WM_SEQ_EXIT_REQ = (WM_APP + 1003);
        public static uint WM_SEQ_EXIT_RSP = (WM_APP + 1004);

        public static uint WM_USER_LOG_IN_REQ = (WM_APP + 1005);
        public static uint WM_USER_LOG_IN_RSP = (WM_APP + 1006);

        public static uint WM_USER_LOG_OUT_REQ = (WM_APP + 1007);
        public static uint WM_USER_LOG_OUT_RSP = (WM_APP + 1008);

        public static uint WM_SEQ_TO_MMI_NOTIFY = (WM_APP + 2001);

        #endregion MESSAGE_DEFINE

        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public static extern IntPtr FindWindow(String lpClassName, String lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, ref COPYDATASTRUCT lParam);

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessageTimeout(
             IntPtr hWnd,
             uint Msg,
             IntPtr wParam,
             ref COPYDATASTRUCT lParam,
             SendMessageTimeoutFlags flags,
             uint timeout,
             out IntPtr result);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        static extern IntPtr PostMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("gdi32.dll")] 
        public static extern IntPtr CreateRoundRectRgn(int x1, int y1, int x2, int y2, int cx, int cy);
        [DllImport("user32.dll")]
        public static extern int SetWindowRgn(IntPtr hWnd, IntPtr hRgn, bool bRedraw);

        [DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceFrequency(out long lpFrequency);

        [DllImport("Kernel32.dll")]
        public static extern bool QueryPerformanceCounter(out long lpPerformanceCount);


        //from swhistlesoft
        public static IntPtr IntPtrAlloc<T>(T param)
        {
            IntPtr retval = Marshal.AllocHGlobal(Marshal.SizeOf(param));
            Marshal.StructureToPtr(param, retval, false);
            return (retval);
        }

        //from swhistlesoft
        public static void IntPtrFree(IntPtr preAllocated)
        {
            if (IntPtr.Zero == preAllocated) throw (new Exception("Go Home"));
            Marshal.FreeHGlobal(preAllocated);
            preAllocated = IntPtr.Zero;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct COPYDATASTRUCT
        {
            public uint dwData;
            public int cbData;
            public IntPtr lpData;
        }

        public static void SendPostMessage(uint msgno, uint target)
        {
            IntPtr targetHWND = IntPtr.Zero;

            if (target == (uint)eMessageTarget.SEQ_MODULE)
            {
                targetHWND = FindWindow(null, "SEQApp");
                if (targetHWND != null)
                {
                    PostMessage(targetHWND, msgno, IntPtr.Zero, IntPtr.Zero);
                }
            }
            else if (target == (uint)eMessageTarget.MMI_MODULE)
            {
                targetHWND = FindWindow(null, "Machine");
                if (targetHWND != null)
                {
                    PostMessage(targetHWND, msgno, IntPtr.Zero, IntPtr.Zero);
                }
            }

        }

        public static void SendCopyData(uint msg, Object obj)
        {
            IntPtr targetWindowHandle = WIN32Helper.FindWindow(null, "SEQApp");
            IntPtr pData = Marshal.AllocHGlobal(Marshal.SizeOf(obj));
            Marshal.StructureToPtr(obj, pData, false);

            WIN32Helper.COPYDATASTRUCT cds2 = new WIN32Helper.COPYDATASTRUCT();
            cds2.dwData = msg;// WIN32Helper.WM_SEQ_EXIT_REQ;
            cds2.cbData = Marshal.SizeOf(obj);
            cds2.lpData = pData;
            IntPtr ptrResult;
            WIN32Helper.SendMessageTimeout(targetWindowHandle, WIN32Helper.WM_COPYDATA, new IntPtr(), ref cds2, 0, 3000, out ptrResult);

        }


        public const int MAX_PATH = 260;
        public const int MAX_ALTERNATE = 14;

        [StructLayout(LayoutKind.Sequential)]
        public struct FileTime
        {
            public uint dwLowDateTime;
            public uint dwHighDateTime;
        };

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct Win32FindData
        {
            public FileAttributes dwFileAttributes;
            public FileTime ftCreationTime;
            public FileTime ftLastAccessTime;
            public FileTime ftLastWriteTime;
            public uint nFileSizeHigh;
            public uint nFileSizeLow;
            public uint dwReserved0;
            public uint dwReserved1;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string cFileName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
            public string cAlternateFileName;
        }

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern IntPtr FindFirstFile(string lpFileName, out Win32FindData lpFindFileData);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
        public static extern bool FindNextFile(IntPtr hFindFile, out Win32FindData lpFindFileData);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool FindClose(IntPtr hFindFile);
    }
}
