using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace MMI
{
    public class ConsoleHelper
    {

        #region SINGLETON
        private static readonly Lazy<ConsoleHelper> instance = new Lazy<ConsoleHelper>(() => new ConsoleHelper());

        public static ConsoleHelper GetInstance
        {
            get { return instance.Value; }
        }
        #endregion SINGLETON

        private const int FixedWidthTrueType = 54;
        private const int StandardOutputHandle = -11;

        private const uint SC_MINIMIZE = 0xF020;
        private const uint SC_MAXIMIZE = 0xF030;
        private const uint SC_CLOSE = 0xf060;

        private const uint MF_BYCOMMAND = 0x00000000;
        private const uint MF_BYPOSITION = 0x00000400;

        private const uint MF_ENABLED = 0x00000000;
        private const uint MF_GRAYED = 0x00000001;
        private const uint MF_DISABLED = 0x00000002;

        private const int STD_INPUT_HANDLE = -10;
        private const int STD_OUTPUT_HANDLE = -11;
        private const int STD_ERROR_HANDLE = -12;

        private const int GWL_WNDPROC = -4;
        private const int GWL_HINSTANCE = -6;
        private const int GWL_HWNDPARENT = -8;
        private const int GWL_STYLE = -16;
        private const int GWL_EXSTYLE = -20;
        private const int GWL_USERDATA = -21;
        private const int GWL_ID = -12;

        private const int WS_EX_TRANSPARENT = 0x20;
        private const int WS_EX_LAYERED = 0x00080000;

        private const uint ENABLE_PROCESSED_INPUT = 0x0001;
        private const uint ENABLE_LINE_INPUT = 0x0002;
        private const uint ENABLE_ECHO_INPUT = 0x0004;
        private const uint ENABLE_WINDOW_INPUT = 0x0008;
        private const uint ENABLE_MOUSE_INPUT = 0x0010;
        private const uint ENABLE_INSERT_MODE = 0x0020;
        private const uint ENABLE_QUICK_EDIT_MODE = 0x0040;
        private const uint ENABLE_EXTENDED_FLAGS = 0x0080;
        private const uint ENABLE_AUTO_POSITION = 0x0100;
        private enum LayeredWindowAttributes
        {
            /// <summary> Use bAlpha to determine the opacity of the layered window.</summary>
            LWA_COLORKEY = 0x1,
            /// <summary> Use crKey as the transparency color. </summary>
            LWA_ALPHA = 0x2
        }

        const int ATTACH_PARENT_PROCESS = -1;

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool AllocConsole();


        [DllImport("kernel32.dll")] static extern bool AttachConsole(int dwProcessId);
        [DllImport("kernel32.dll")] private static extern bool SetConsoleTitle(string lpConsoleTitle);

        [DllImport("kernel32.dll", SetLastError = true)] internal static extern IntPtr GetStdHandle(int nStdHandle);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool SetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool MaximumWindow, ref FontInfo ConsoleCurrentFontEx);

        [return: MarshalAs(UnmanagedType.Bool)]
        [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        internal static extern bool GetCurrentConsoleFontEx(IntPtr hConsoleOutput, bool MaximumWindow, ref FontInfo ConsoleCurrentFontEx);

        [DllImport("kernel32.dll", SetLastError = true)] static extern IntPtr GetConsoleWindow();
        [DllImport("kernel32.dll", SetLastError = true)] static extern bool SetConsoleTextAttribute(IntPtr h_ConsoleOutput, Int16 u16_Attributes);

        [DllImport("kernel32.dll")] static extern bool GetConsoleMode(IntPtr hConsoleHandle, out uint lpMode);
        [DllImport("kernel32.dll")] static extern bool SetConsoleMode(IntPtr hConsoleHandle, uint dwMode);

        [DllImport("Kernel32")] private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);
        private delegate bool EventHandler(CtrlType sig);

        static EventHandler _handler;


        [DllImport("user32")] private static extern int ShowWindow(IntPtr windowHandle, int command);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 1;

        enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }
        [DllImport("user32.dll")] static extern IntPtr GetSystemMenu(IntPtr windowHandle, bool revert);
        [DllImport("user32.dll")] static extern bool EnableMenuItem(IntPtr menuHandle, uint menuItemID, uint enabled);
        [DllImport("user32.dll")] static extern bool DeleteMenu(IntPtr menuHandle, uint menuItemID, uint enabled);
        [DllImport("user32.dll")] static extern bool MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
        [DllImport("user32.dll")] static extern bool DrawMenuBar(IntPtr hWnd);
        [DllImport("user32.dll")] static extern Int32 SetWindowLong(IntPtr hWnd, Int32 nIndex, Int32 dwNewLong);
        [DllImport("user32.dll")] static extern bool SetLayeredWindowAttributes(IntPtr hWnd, int crKey, byte alpha, LayeredWindowAttributes dwFlags);

        private static readonly IntPtr ConsoleOutputHandle = GetStdHandle(StandardOutputHandle);

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct FontInfo
        {
            internal int cbSize;
            internal int FontIndex;
            internal short FontWidth;
            public short FontSize;
            public int FontFamily;
            public int FontWeight;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 32)]
            //[MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.wc, SizeConst = 32)]
            public string FontName;
        }

        public static FontInfo[] SetCurrentFont(string font, short fontSize = 0)
        {
            //Console.WriteLine("Set Current Font: " + font);

            FontInfo before = new FontInfo
            {
                cbSize = Marshal.SizeOf<FontInfo>()
            };

            if (GetCurrentConsoleFontEx(ConsoleOutputHandle, false, ref before))
            {

                FontInfo set = new FontInfo
                {
                    cbSize = Marshal.SizeOf<FontInfo>(),
                    FontIndex = 0,
                    FontFamily = FixedWidthTrueType,
                    FontName = font,
                    FontWeight = 400,
                    FontSize = fontSize > 0 ? fontSize : before.FontSize
                };

                // Get some settings from current font.
                if (!SetCurrentConsoleFontEx(ConsoleOutputHandle, false, ref set))
                {
                    var ex = Marshal.GetLastWin32Error();
                    Console.WriteLine("Set error " + ex);
                    throw new System.ComponentModel.Win32Exception(ex);
                }

                FontInfo after = new FontInfo
                {
                    cbSize = Marshal.SizeOf<FontInfo>()
                };
                GetCurrentConsoleFontEx(ConsoleOutputHandle, false, ref after);

                return new[] { before, set, after };
            }
            else
            {
                var er = Marshal.GetLastWin32Error();
                Console.WriteLine("Get error " + er);
                throw new System.ComponentModel.Win32Exception(er);
            }
        }

        public static void InitConsole()
        {
            // 콘솔 출력을 위해서 프로젝트 속성 => 출력형식 : 콘솔 어플리케이션으로 변경
            SetConsoleTitle("SEQ Running LOG");
            SetCurrentFont("Tahoma", 22);

            IntPtr consoleWindowHandle = GetConsoleWindow();
            IntPtr systemMenuHandle = GetSystemMenu(consoleWindowHandle, false);

            // Maximize 아이콘이 보이기는 하지만 작동하지 않음
            EnableMenuItem(systemMenuHandle, SC_MAXIMIZE, MF_BYCOMMAND);
            DeleteMenu(systemMenuHandle, SC_MAXIMIZE, MF_BYCOMMAND);
            // Close 아이콘이 보이기는 하지만 Disable 됨
            EnableMenuItem(systemMenuHandle, SC_CLOSE, MF_BYCOMMAND);
            DeleteMenu(systemMenuHandle, SC_CLOSE, MF_BYCOMMAND);

            DrawMenuBar(consoleWindowHandle);

            // 글씨 color 변경
            SetConsoleRGB(2);
            // 콘솔창 크기 변경
            Console.SetWindowSize(100, 30);
            // 콘솔창 버퍼 설정
            Console.SetBufferSize(100, 1000);

            // OS version
            Console.WriteLine("Operating System");
            OperatingSystem os = Environment.OSVersion;
            Console.WriteLine("OS Version: " + os.Version.ToString());
            Console.WriteLine("OS Platoform: " + os.Platform.ToString());
            Console.WriteLine("OS SP: " + os.ServicePack.ToString());
            Console.WriteLine("OS Version String: " + os.VersionString.ToString());

            //Version ver = os.Version;
            //Console.WriteLine("Major version: " + ver.Major);
            //Console.WriteLine("Major Revision: " + ver.MajorRevision);
            //Console.WriteLine("Minor version: " + ver.Minor);
            //Console.WriteLine("Minor Revision: " + ver.MinorRevision);
            //Console.WriteLine("Build: " + ver.Build);

            // 투명도 적용 Win7이상 적용 가능	
            SetWindowLong(consoleWindowHandle, GWL_EXSTYLE, WS_EX_LAYERED);
            SetLayeredWindowAttributes(consoleWindowHandle, 0, 140, LayeredWindowAttributes.LWA_ALPHA);

            // 컨트롤 핸들러, 키보드 입력 처리
            SetConsoleMode(GetStdHandle(STD_OUTPUT_HANDLE), ENABLE_PROCESSED_INPUT | ENABLE_LINE_INPUT | ENABLE_ECHO_INPUT | ENABLE_MOUSE_INPUT);
            SetConsoleMode(GetStdHandle(STD_OUTPUT_HANDLE), ~ENABLE_INSERT_MODE | ~ENABLE_QUICK_EDIT_MODE);

            _handler += new EventHandler(ContrlHandler);
            bool ret = SetConsoleCtrlHandler(_handler, true);
            if (!ret)
            {
                Console.WriteLine("Could not set CtrlHandler");
            }

            UInt32 prevMode = 0;
            IntPtr ConsoleInputHandle = GetStdHandle(STD_INPUT_HANDLE);
            GetConsoleMode(ConsoleInputHandle, out prevMode);
            SetConsoleMode(ConsoleInputHandle, prevMode & ~ENABLE_QUICK_EDIT_MODE);

        }
        static void SetConsoleRGB(int color)
        {
            #region Console Color
            const int FOREGROUND_BLUE = 0x0001;
            const int FOREGROUND_GREEN = 0x0002;
            const int FOREGROUND_RED = 0x0004;
            const int FOREGROUND_INTENSITY = 0x0008;

            const int BACKGROUND_BLUE = 0x0010;
            const int BACKGROUND_GREEN = 0x0020;
            const int BACKGROUND_RED = 0x0040;
            const int BACKGROUND_INTENSITY = 0x0080;
            #endregion

            switch (color)
            {
                case 0:    // White on Black
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_INTENSITY |
                        FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
                    break;
                case 1:    // Red on Black
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_INTENSITY |
                        FOREGROUND_RED);
                    break;
                case 2:    // Green on Black
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_INTENSITY |
                        FOREGROUND_GREEN);
                    break;
                case 3:    // Yellow on Black
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_INTENSITY |
                        FOREGROUND_RED | FOREGROUND_GREEN);
                    break;
                case 4:    // Blue on Black
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_INTENSITY |
                        FOREGROUND_BLUE);
                    break;
                case 5:    // Magenta on Black
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_INTENSITY |
                        FOREGROUND_RED | FOREGROUND_BLUE);
                    break;
                case 6:    // Cyan on Black
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_INTENSITY |
                        FOREGROUND_GREEN | FOREGROUND_BLUE);
                    break;
                case 7:    // Black on Gray
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), BACKGROUND_INTENSITY |
                        BACKGROUND_INTENSITY);
                    break;
                case 8:    // Black on White
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), BACKGROUND_INTENSITY |
                        FOREGROUND_INTENSITY |
                        BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE);
                    break;
                case 9:    // Red on White
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), BACKGROUND_INTENSITY |
                        FOREGROUND_INTENSITY |
                        BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE |
                        FOREGROUND_RED);
                    break;
                case 10:    // Green on White
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), BACKGROUND_INTENSITY | FOREGROUND_INTENSITY |
                        BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE |
                        FOREGROUND_GREEN);
                    break;
                case 11:    // Yellow on White
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), BACKGROUND_INTENSITY | FOREGROUND_INTENSITY |
                        BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE |
                        FOREGROUND_RED | FOREGROUND_GREEN);
                    break;
                case 12:    // Blue on White
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), BACKGROUND_INTENSITY | FOREGROUND_INTENSITY |
                        BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE |
                        FOREGROUND_BLUE);
                    break;
                case 13:    // Magenta on White
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), BACKGROUND_INTENSITY | FOREGROUND_INTENSITY |
                        BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE |
                        FOREGROUND_RED | FOREGROUND_BLUE);
                    break;
                case 14:    // Cyan on White SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), BACKGROUND_INTENSITY | FOREGROUND_INTENSITY | BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE | FOREGROUND_GREEN | FOREGROUND_BLUE); break; case 15: // White on White
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), BACKGROUND_INTENSITY | FOREGROUND_INTENSITY |
                        BACKGROUND_RED | BACKGROUND_GREEN | BACKGROUND_BLUE |
                        FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
                    break;
                default:    // White on Black
                    SetConsoleTextAttribute(GetStdHandle(STD_OUTPUT_HANDLE), FOREGROUND_INTENSITY |
                        FOREGROUND_RED | FOREGROUND_GREEN | FOREGROUND_BLUE);
                    break;
            }
        }
        static bool ContrlHandler(CtrlType sig)
        {
            switch (sig)
            {
                case CtrlType.CTRL_C_EVENT:
                    Console.Clear();
                    return true;
                case CtrlType.CTRL_BREAK_EVENT:
                    return true;
                case CtrlType.CTRL_CLOSE_EVENT:
                    return true;
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                    return true;
                case CtrlType.CTRL_LOGOFF_EVENT:
                    return true;
                default:
                    return false;
            }
        }

        public static void ShowConsole()
        {
            ShowWindow(GetConsoleWindow(), SW_SHOW);
        }
        public static void HideConsole()
        {
            ShowWindow(GetConsoleWindow(), SW_HIDE);
        }
    }
}
