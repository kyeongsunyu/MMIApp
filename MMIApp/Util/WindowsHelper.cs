using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.IO;

namespace MMI
{
    public static class winapi
    {
        public delegate bool EnumWindowsProc(IntPtr hWnd, int lParam);

        public static IntPtr statusbar;

        #region WinApi Constants, Enums and structs

        public enum WindowShowStyle : uint
        {
            Hide = 0,
            ShowNormal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3,
            Maximize = 3,
            ShowNormalNoActivate = 4,
            Show = 5,
            Minimize = 6,
            ShowMinNoActivate = 7,
            ShowNoActivate = 8,
            Restore = 9,
            ShowDefault = 10,
            ForceMinimized = 11
        }

        public const int WM_GETICON = 0x7F;
        public const int WM_QUERYDRAGICON = 0x37;

        public const int ICON_SMALL = 0;
        public const int GCL_HICONSM = -34;

        public const int SMTO_ABORTIFHUNG = 0x2;

        [Flags]
        public enum WindowLongIndexFlags
        {
            GWL_EXSTYLE = -20,
            GWLP_HINSTANCE = -6,
            GWLP_HWNDPARENT = -8,
            GWL_ID = -12,
            GWLP_ID = GWL_ID,
            GWL_STYLE = -16,
            GWL_USERDATA = -21,
            GWLP_USERDATA = GWL_USERDATA,
            GWL_WNDPROC = -4,
            GWLP_WNDPROC = GWL_WNDPROC,
            DWLP_USER = 0x8,
            DWLP_MSGRESULT = 0x0,
            DWLP_DLGPROC = 0x4
        }

        [Flags]
        public enum SetWindowLongFlags : uint
        {
            WS_OVERLAPPED = 0,
            WS_POPUP = 0x80000000,
            WS_CHILD = 0x40000000,
            WS_MINIMIZE = 0x20000000,
            WS_VISIBLE = 0x10000000,
            WS_DISABLED = 0x8000000,
            WS_CLIPSIBLINGS = 0x4000000,
            WS_CLIPCHILDREN = 0x2000000,
            WS_MAXIMIZE = 0x1000000,
            WS_CAPTION = 0xC00000,
            WS_BORDER = 0x800000,
            WS_DLGFRAME = 0x400000,
            WS_VSCROLL = 0x200000,
            WS_HSCROLL = 0x100000,
            WS_SYSMENU = 0x80000,
            WS_THICKFRAME = 0x40000,
            WS_GROUP = 0x20000,
            WS_TABSTOP = 0x10000,
            WS_MINIMIZEBOX = 0x20000,
            WS_MAXIMIZEBOX = 0x10000,
            WS_TILED = WS_OVERLAPPED,
            WS_ICONIC = WS_MINIMIZE,
            WS_SIZEBOX = WS_THICKFRAME,

            WS_EX_DLGMODALFRAME = 0x0001,
            WS_EX_NOPARENTNOTIFY = 0x0004,
            WS_EX_TOPMOST = 0x0008,
            WS_EX_ACCEPTFILES = 0x0010,
            WS_EX_TRANSPARENT = 0x0020,
            WS_EX_MDICHILD = 0x0040,
            WS_EX_TOOLWINDOW = 0x0080,
            WS_EX_WINDOWEDGE = 0x0100,
            WS_EX_CLIENTEDGE = 0x0200,
            WS_EX_CONTEXTHELP = 0x0400,
            WS_EX_RIGHT = 0x1000,
            WS_EX_LEFT = 0x0000,
            WS_EX_RTLREADING = 0x2000,
            WS_EX_LTRREADING = 0x0000,
            WS_EX_LEFTSCROLLBAR = 0x4000,
            WS_EX_RIGHTSCROLLBAR = 0x0000,
            WS_EX_CONTROLPARENT = 0x10000,
            WS_EX_STATICEDGE = 0x20000,
            WS_EX_APPWINDOW = 0x40000,
            WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE,
            WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST,
            WS_EX_LAYERED = 0x00080000,
            WS_EX_NOINHERITLAYOUT = 0x00100000,
            WS_EX_LAYOUTRTL = 0x00400000,
            WS_EX_COMPOSITED = 0x02000000,
            WS_EX_NOACTIVATE = 0x08000000
        }

        public const int WM_HOTKEY = 0x0312;

        public const int WM_CLOSE = 0x10;
        public const int WM_DESTROY = 0x0002;


        public const uint SHGFI_ICON = 0x100;
        public const uint SHGFI_SMALLICON = 0x1;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public struct POINTAPI
        {
            public int x;
            public int y;
        }

        public struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public int showCmd;
            public POINTAPI ptMinPosition;
            public POINTAPI ptMaxPosition;
            public RECT rcNormalPosition;
        }

        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VMOperation = 0x00000008,
            VMRead = 0x00000010,
            VMWrite = 0x00000020,
            DupHandle = 0x00000040,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            Synchronize = 0x00100000
        }

        [Flags]
        public enum KeyModifiers : uint
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        public enum SysCommands
        {
            /// <summary>
            ///     Closes the window.
            /// </summary>
            SC_CLOSE = 0xF060,

            /// <summary>
            ///     Changes the cursor to a question mark with a pointer. If the user then clicks a control in the dialog box, the
            ///     control receives a WM_HELP message.
            /// </summary>
            SC_CONTEXTHELP = 0xF180,

            /// <summary>
            ///     Selects the default item; the user double-clicked the window menu.
            /// </summary>
            SC_DEFAULT = 0xF160,

            /// <summary>
            ///     Activates the window associated with the application-specified hot key. The lParam parameter identifies the window
            ///     to activate.
            /// </summary>
            SC_HOTKEY = 0xF150,

            /// <summary>
            ///     Scrolls horizontally.
            /// </summary>
            SC_HSCROLL = 0xF080,

            /// <summary>
            ///     Indicates whether the screen saver is secure.
            /// </summary>
            SCF_ISSECURE = 0x00000001,

            /// <summary>
            ///     Retrieves the window menu as a result of a keystroke. For more information, see the Remarks section.
            /// </summary>
            SC_KEYMENU = 0xF100,

            /// <summary>
            ///     Maximizes the window.
            /// </summary>
            SC_MAXIMIZE = 0xF030,

            /// <summary>
            ///     Minimizes the window.
            /// </summary>
            SC_MINIMIZE = 0xF020,

            /// <summary>
            ///     Sets the state of the display. This command supports devices that have power-saving features, such as a
            ///     battery-powered personal computer.
            ///     The lParam parameter can have the following values:
            ///     -1 (the display is powering on)
            ///     1 (the display is going to low power)
            ///     2 (the display is being shut off)
            /// </summary>
            SC_MONITORPOWER = 0xF170,

            /// <summary>
            ///     Retrieves the window menu as a result of a mouse click.
            /// </summary>
            SC_MOUSEMENU = 0xF090,

            /// <summary>
            ///     Moves the window.
            /// </summary>
            SC_MOVE = 0xF010,

            /// <summary>
            ///     Moves to the next window.
            /// </summary>
            SC_NEXTWINDOW = 0xF040,

            /// <summary>
            ///     Moves to the previous window.
            /// </summary>
            SC_PREVWINDOW = 0xF050,

            /// <summary>
            ///     Restores the window to its normal position and size.
            /// </summary>
            SC_RESTORE = 0xF120,

            /// <summary>
            ///     Executes the screen saver application specified in the [boot]
            ///     section of the System.ini file.
            /// </summary>
            SC_SCREENSAVE = 0xF140,

            /// <summary>
            ///     Sizes the window.
            /// </summary>
            SC_SIZE = 0xF000,

            /// <summary>
            ///     Activates the Start menu.
            /// </summary>
            SC_TASKLIST = 0xF130,

            /// <summary>
            ///     Scrolls vertically.
            /// </summary>
            SC_VSCROLL = 0xF070
        }

        #endregion

        #region WinApi functions

        #region kernel32

        [DllImport("kernel32.dll")]
        public static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess, bool bInheritHandle,
            uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool CloseHandle(IntPtr hHandle);

        #endregion

        #region User32

        [DllImport("User32.dll")]
        public static extern int GetClassLong(IntPtr hWnd, int index);

        [DllImport("User32.dll")]
        public static extern int SendMessageTimeout(IntPtr hWnd, int uMsg, int wParam, int lParam, int fuFlags,
            int uTimeout, out int lpdwResult);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPlacement(IntPtr hWnd,
            [In] ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, IntPtr dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetParent(IntPtr hWnd);


        [DllImport("user32.dll")]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth,
            int nHeight, bool bRepaint);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);


        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass,
            string lpszWindow);


        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);

        [DllImport("user32.dll")]
        public static extern int EnumWindows(EnumWindowsProc ewp, int lParam);

        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        [DllImport("user32.dll", EntryPoint = "DestroyIcon")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        public static extern bool DestroyIcon([InAttribute] IntPtr hIcon);

        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

        [DllImport("user32.dll")]
        public static extern int DeleteMenu(IntPtr hMenu, int nPosition, int wFlags);

        [DllImport("user32.dll")]
        public static extern int EnableMenuItem(IntPtr hMenu, int wIDEnableItem, int wEnable);

        [DllImport("user32.dll")]
        public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

        [DllImport("user32.dll")]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy,
            int uFlags);

        [DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        #endregion


        [DllImport("shell32.dll")]
        public static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes, ref SHFILEINFO psfi,
            uint cbSizeFileInfo, uint uFlags);

        [DllImport("Psapi.dll", SetLastError = true)]
        [PreserveSig]
        public static extern uint GetModuleFileNameEx([In] IntPtr hProcess, [In] IntPtr hModule,
            [Out] StringBuilder lpFilename,
            [In][MarshalAs(UnmanagedType.U4)] int nSize);

        #endregion
    }

    public class window
    {
        public window(IntPtr handle)
        {
            Handle = handle;

            Title = gettext();
            Parent = getparent();
            Style = getstyle();
            GetSizeandLocation();
        }

        public void SetParent(IntPtr ParentHandle)
        {
            previousparent = winapi.SetParent(Handle, ParentHandle);
            Parent = ParentHandle;
        }

        public IntPtr GetParent()
        {
            var ipParent = IntPtr.Zero;
            ipParent = winapi.GetParent(Handle);

            return ipParent;
        }

        public void RestoreParent()
        {
            Parent = previousparent;
            previousparent = winapi.SetParent(Handle, previousparent);
        }

        public void Move(Point Location, Size size, bool repaint)
        {
            winapi.MoveWindow(Handle, Location.X, Location.Y, size.Width, size.Height, repaint);
        }

        public void SetStyle(int index, IntPtr value)
        {
            PreviousStyle = winapi.SetWindowLong(Handle, index, value);
            Style = value.ToInt32();
        }

        public bool ShowWindow(winapi.WindowShowStyle showStyle)
        {
            var rtn = winapi.ShowWindow(Handle, showStyle);
            return rtn;
        }


        public void DeleteMenu(int nPosition, int wFlags)
        {
            winapi.DeleteMenu(winapi.GetSystemMenu(Handle, false), nPosition, wFlags);
        }

        public void EnableMenu(int wIDEnableItem, int wEnable)
        {
            winapi.DeleteMenu(winapi.GetSystemMenu(Handle, false), wIDEnableItem, wEnable);
        }

        public bool Close()
        {
            var result = winapi.PostMessage(Handle, winapi.WM_CLOSE, IntPtr.Zero, IntPtr.Zero);

            if (!result) result = winapi.PostMessage(Handle, winapi.WM_DESTROY, IntPtr.Zero, IntPtr.Zero);

            return result;
        }

        public void RestoreLocation()
        {
            winapi.SetWindowPlacement(Handle, ref placement);
        }

        public string GetExecutablePath()
        {
            uint dwProcessId;
            winapi.GetWindowThreadProcessId(Handle, out dwProcessId);
            var hProcess =
                winapi.OpenProcess(winapi.ProcessAccessFlags.VMRead | winapi.ProcessAccessFlags.QueryInformation, false,
                    dwProcessId);
            var path = new StringBuilder(1024);
            winapi.GetModuleFileNameEx(hProcess, IntPtr.Zero, path, 1024);
            winapi.CloseHandle(hProcess);
            return path.ToString();
        }

        public static List<window> GetOpenWindows()
        {
            openwnd = new List<window>();

            winapi.EnumWindowsProc callback = EnumWindows;
            winapi.EnumWindows(callback, 0);

            var result = new List<window>(openwnd);
            openwnd.Clear();

            result.RemoveAt(result.Count - 1);
            return result;
        }

        public static IntPtr FindWindow(string classname, string windowtitle)
        {
            return winapi.FindWindow(classname, windowtitle);
        }

        private static bool EnumWindows(IntPtr hWnd, int lParam)
        {
            if (!winapi.IsWindowVisible(hWnd) || hWnd == winapi.statusbar)
                return true;

            openwnd.Add(new window(hWnd));

            return true;
        }

        private string gettext()
        {
            var title = new StringBuilder(256);
            winapi.GetWindowText(Handle, title, 256);

            return title.ToString();
        }

        private IntPtr getparent()
        {
            return winapi.GetParent(Handle);
        }

        private int getstyle()
        {
            return winapi.GetWindowLong(Handle, (int)winapi.WindowLongIndexFlags.GWL_STYLE);
        }

        private void GetSizeandLocation()
        {
            placement.length = Marshal.SizeOf(placement);
            winapi.GetWindowPlacement(Handle, ref placement);
        }

        private Icon GetExecutableIcon()
        {
            Icon icon = null;
            var path = GetExecutablePath();
            if (File.Exists(path))
            {
                var info = new winapi.SHFILEINFO();
                winapi.SHGetFileInfo(path, 0, ref info, (uint)Marshal.SizeOf(info),
                    winapi.SHGFI_ICON | winapi.SHGFI_SMALLICON);

                var temp = Icon.FromHandle(info.hIcon);
                icon = (Icon)temp.Clone();
                winapi.DestroyIcon(temp.Handle);
            }

            return icon;
        }

        private Icon GetWindowIcon()
        {
            int result;

            winapi.SendMessageTimeout(Handle, winapi.WM_GETICON, winapi.ICON_SMALL, 0,
                winapi.SMTO_ABORTIFHUNG, 1000, out result);

            var IconHandle = new IntPtr(result);

            if (IconHandle == IntPtr.Zero)
            {
                result = winapi.GetClassLong(Handle, winapi.GCL_HICONSM);
                IconHandle = new IntPtr(result);
            }

            if (IconHandle == IntPtr.Zero)
            {
                winapi.SendMessageTimeout(Handle, winapi.WM_QUERYDRAGICON, 0, 0,
                    winapi.SMTO_ABORTIFHUNG, 1000, out result);
                IconHandle = new IntPtr(result);
            }

            if (IconHandle == IntPtr.Zero) return null;

            var temp = Icon.FromHandle(IconHandle);
            var icon = (Icon)temp.Clone();

            winapi.DestroyIcon(IconHandle);

            return icon;
        }

        #region private fields

        private winapi.WINDOWPLACEMENT placement;
        private IntPtr previousparent;

        private static List<window> openwnd;

        #endregion

        #region Properties

        public IntPtr Handle { get; }

        public string Title { get; }

        public int Style { get; private set; }

        public IntPtr Parent { get; private set; }

        public Size Size =>
            new Size(placement.rcNormalPosition.Right - placement.rcNormalPosition.Left,
                placement.rcNormalPosition.Bottom - placement.rcNormalPosition.Top);

        public Point Location => new Point(placement.rcNormalPosition.Left, placement.rcNormalPosition.Top);

        public int PreviousStyle { get; private set; }

        public Icon ExecutableIcon => GetExecutableIcon();

        public Icon WindowIcon => GetWindowIcon();

        #endregion
    }



}
