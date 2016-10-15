using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Launcher.Utilities
{
    public class Win32Api
    {
        #region VirtualAllocEx flags
        [Flags]
        public enum AllocationType
        {
            Commit = 0x1000,
            Reserve = 0x2000,
            Decommit = 0x4000,
            Release = 0x8000,
            Reset = 0x80000,
            Physical = 0x400000,
            TopDown = 0x100000,
            WriteWatch = 0x200000,
            LargePages = 0x20000000
        }

        [Flags]
        public enum MemoryProtection
        {
            Execute = 0x10,
            ExecuteRead = 0x20,
            ExecuteReadWrite = 0x40,
            ExecuteWriteCopy = 0x80,
            NoAccess = 0x01,
            ReadOnly = 0x02,
            ReadWrite = 0x04,
            WriteCopy = 0x08,
            GuardModifierflag = 0x100,
            NoCacheModifierflag = 0x200,
            WriteCombineModifierflag = 0x400
        }
        #endregion

        #region OpenProcess flags
        [Flags]
        public enum ProcessAccessFlags : uint
        {
            All = 0x001F0FFF,
            Terminate = 0x00000001,
            CreateThread = 0x00000002,
            VirtualMemoryOperation = 0x00000008,
            VirtualMemoryRead = 0x00000010,
            VirtualMemoryWrite = 0x00000020,
            DuplicateHandle = 0x00000040,
            CreateProcess = 0x000000080,
            SetQuota = 0x00000100,
            SetInformation = 0x00000200,
            QueryInformation = 0x00000400,
            QueryLimitedInformation = 0x00001000,
            Synchronize = 0x00100000
        }
        #endregion

        /* PINVOKE  */
        public struct Startupinfo
        {
            public uint Cb;
            public string LpReserved;
            public string LpDesktop;
            public string LpTitle;
            public uint DwX;
            public uint DwY;
            public uint DwXSize;
            public uint DwYSize;
            public uint DwXCountChars;
            public uint DwYCountChars;
            public uint DwFillAttribute;
            public uint DwFlags;
            public short WShowWindow;
            public short CbReserved2;
            public IntPtr LpReserved2;
            public IntPtr HStdInput;
            public IntPtr HStdOutput;
            public IntPtr HStdError;
        }

        public struct ProcessInformation
        {
            public IntPtr HProcess;
            public IntPtr HThread;
            public uint DwProcessId;
            public uint DwThreadId;
        }

        [Flags]
        public enum ProcessCreationFlags : uint
        {
            CreateDefaultErrorMode = 0x04000000,
            CreateSuspended = 0x00000004
        }

        public const int HSHELL_WINDOWCREATED = 1;

        public struct DevMode
        {
            private const int CCHDEVICENAME = 0x20;
            private const int CCHFORMNAME = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;
            public int dmPositionX;
            public int dmPositionY;
            public ScreenOrientation dmDisplayOrientation;
            public int dmDisplayFixedOutput;
            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string dmFormName;
            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        [Flags]
        public enum WindowLongFlags
        {
            WsClipsiblings = 0x04000000,
            WsClipchildren = 0x02000000,
            WsVisible = 0x10000000,
            WsDisabled = 0x08000000,
            WsMinimize = 0x20000000,
            WsMaximize = 0x01000000,
            WsCaption = 0x00C00000,
            WsBorder = 0x00800000,
            WsDlgframe = 0x00400000,
            WsVscroll = 0x00200000,
            WsHscroll = 0x00100000,
            WsSysmenu = 0x00080000,
            WsThickframe = 0x00040000,
            WsMinimizebox = 0x00020000,
            WsMaximizebox = 0x00010000,
            GwlStyle = -16
        }

        [Flags]
        public enum MenuFlags
        {
            MfRemove = 0x1000,
            MfByposition = 0x400
        }

        [Flags]
        public enum SetWindowPosFlags : uint
        {
            NoSize = 0x0001,
            NoMove = 0x0002,
            NoZOrder = 0x0004,
            NoRedraw = 0x0008,
            NoActivate = 0x0010,
            DrawFrame = 0x0020,
            FrameChanged = 0x0020,
            ShowWindow = 0x0040,
            HideWindow = 0x0080,
            NoCopyBits = 0x0100,
            NoOwnerZOrder = 0x0200,
            NoReposition = 0x0200,
            NoSendChanging = 0x0400,
            DeferErase = 0x2000,
            AsyncWindowPos = 0x4000
        }

        [Flags]
        public enum RedrawWindowFlags : uint
        {
            Invalidate = 0x1,
            InternalPaint = 0x2,
            Erase = 0x4,
            Validate = 0x8,
            NoInternalPaint = 0x10,
            NoErase = 0x20,
            NoChildren = 0x40,
            AllChildren = 0x80,
            UpdateNow = 0x100,
            EraseNow = 0x200,
            Frame = 0x400,
            NoFrame = 0x800
        }

        [Flags]
        public enum WinEventDelegateFlags : uint
        {
            WineventOutofcontext = 0x0000, // Events are ASYNC
            WineventSkipownthread = 0x0001, // Don't call back for events on installer's thread
            WineventSkipownprocess = 0x0002, // Don't call back for events on installer's process
            WineventIncontext = 0x0004, // Events are SYNC, this causes your dll to be injected into every process
            EventMin = 0x00000001,
            EventMax = 0x7FFFFFFF,
            EventSystemSound = 0x0001,
            EventSystemAlert = 0x0002,
            EventSystemForeground = 0x0003,
            EventSystemMenustart = 0x0004,
            EventSystemMenuend = 0x0005,
            EventSystemMenupopupstart = 0x0006,
            EventSystemMenupopupend = 0x0007,
            EventSystemCapturestart = 0x0008,
            EventSystemCaptureend = 0x0009,
            EventSystemMovesizestart = 0x000A,
            EventSystemMovesizeend = 0x000B,
            EventSystemContexthelpstart = 0x000C,
            EventSystemContexthelpend = 0x000D,
            EventSystemDragdropstart = 0x000E,
            EventSystemDragdropend = 0x000F,
            EventSystemDialogstart = 0x0010,
            EventSystemDialogend = 0x0011,
            EventSystemScrollingstart = 0x0012,
            EventSystemScrollingend = 0x0013,
            EventSystemSwitchstart = 0x0014,
            EventSystemSwitchend = 0x0015,
            EventSystemMinimizestart = 0x0016,
            EventSystemMinimizeend = 0x0017,
            EventSystemDesktopswitch = 0x0020,
            EventSystemEnd = 0x00FF,
            EventOemDefinedStart = 0x0101,
            EventOemDefinedEnd = 0x01FF,
            EventUiaEventidStart = 0x4E00,
            EventUiaEventidEnd = 0x4EFF,
            EventUiaPropidStart = 0x7500,
            EventUiaPropidEnd = 0x75FF,
            EventConsoleCaret = 0x4001,
            EventConsoleUpdateRegion = 0x4002,
            EventConsoleUpdateSimple = 0x4003,
            EventConsoleUpdateScroll = 0x4004,
            EventConsoleLayout = 0x4005,
            EventConsoleStartApplication = 0x4006,
            EventConsoleEndApplication = 0x4007,
            EventConsoleEnd = 0x40FF,
            EventObjectCreate = 0x8000, // hwnd ID idChild is created item
            EventObjectDestroy = 0x8001, // hwnd ID idChild is destroyed item
            EventObjectShow = 0x8002, // hwnd ID idChild is shown item
            EventObjectHide = 0x8003, // hwnd ID idChild is hidden item
            EventObjectReorder = 0x8004, // hwnd ID idChild is parent of zordering children
            EventObjectFocus = 0x8005, // hwnd ID idChild is focused item
            EventObjectSelection = 0x8006, // hwnd ID idChild is selected item (if only one), or idChild is OBJID_WINDOW if complex
            EventObjectSelectionadd = 0x8007, // hwnd ID idChild is item added
            EventObjectSelectionremove = 0x8008, // hwnd ID idChild is item removed
            EventObjectSelectionwithin = 0x8009, // hwnd ID idChild is parent of changed selected items
            EventObjectStatechange = 0x800A, // hwnd ID idChild is item w/ state change
            EventObjectLocationchange = 0x800B, // hwnd ID idChild is moved/sized item
            EventObjectNamechange = 0x800C, // hwnd ID idChild is item w/ name change
            EventObjectDescriptionchange = 0x800D, // hwnd ID idChild is item w/ desc change
            EventObjectValuechange = 0x800E, // hwnd ID idChild is item w/ value change
            EventObjectParentchange = 0x800F, // hwnd ID idChild is item w/ new parent
            EventObjectHelpchange = 0x8010, // hwnd ID idChild is item w/ help change
            EventObjectDefactionchange = 0x8011, // hwnd ID idChild is item w/ def action change
            EventObjectAcceleratorchange = 0x8012, // hwnd ID idChild is item w/ keybd accel change
            EventObjectInvoked = 0x8013, // hwnd ID idChild is item invoked
            EventObjectTextselectionchanged = 0x8014, // hwnd ID idChild is item w? test selection change
            EventObjectContentscrolled = 0x8015,
            EventSystemArrangmentpreview = 0x8016,
            EventObjectEnd = 0x80FF,
            EventAiaStart = 0xA000,
            EventAiaEnd = 0xAFFF,
        }

        public struct Rect
        {
            public int Left;        // x position of upper-left corner
            public int Top;         // y position of upper-left corner
            public int Right;       // x position of lower-right corner
            public int Bottom;      // y position of lower-right corner
        }

        public struct KbDllHookStruct
        {
            public int vkCode;
            int scanCode;
            public int flags;
            int time;
            int dwExtraInfo;
        }

        public enum KeyboardHooks
        {
            //Keyboard API constants
            WH_KEYBOARD_LL = 13,
            WM_KEYUP = 0x0101
        }

        public enum Keys
        {
            //Modifier key constants
            VK_PRINT = 0x2C
        }

        public static string GetClassName(IntPtr hwnd)
        {
            var sb = new StringBuilder(1024);
            GetClassName(hwnd, sb, sb.Capacity);
            return sb.ToString();
        }

        #region kernel32

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr OpenProcess(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int CloseHandle(IntPtr hObject);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetProcAddress(IntPtr hModule, string lpProcName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, IntPtr dwSize, uint flAllocationType, uint flProtect);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern int WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, byte[] buffer, uint size, int lpNumberOfBytesWritten);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttribute, IntPtr dwStackSize, IntPtr lpStartAddress,
            IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

        [DllImport("kernel32.dll")]
        public static extern bool CreateProcess(string lpApplicationName,
               string lpCommandLine, IntPtr lpProcessAttributes,
               IntPtr lpThreadAttributes,
               bool bInheritHandles, ProcessCreationFlags dwCreationFlags,
               IntPtr lpEnvironment, string lpCurrentDirectory,
               ref Startupinfo lpStartupInfo,
               out ProcessInformation lpProcessInformation);

        [DllImport("kernel32.dll")]
        public static extern uint ResumeThread(IntPtr hThread);

        [DllImport("kernel32.dll")]
        public static extern uint SuspendThread(IntPtr hThread);
        #endregion

        #region user32
        //Sets window attributes
        [DllImport("user32.dll")]
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

        //Gets window attributes
        [DllImport("user32.dll")]
        public static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        public static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport("user32.dll")]
        public static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DevMode lpDevMode);

        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings([In, Out]ref DevMode lpDevMode, [param: MarshalAs(UnmanagedType.U4)] uint dwflags);

        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll")]
        public static extern uint GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);

        [DllImport("user32.dll")]
        public static extern int RegisterWindowMessage(string lpString);

        [DllImport("user32.dll")]
        public static extern int RegisterShellHookWindow(IntPtr Hwnd);

        [DllImport("user32.dll")]
        public static extern int GetClassName(System.IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);
        #endregion
    }
}
