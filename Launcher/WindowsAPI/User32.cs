using System;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace Launcher.WindowsAPI
{
    public static class User32
    {
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

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPosPtr(IntPtr hWnd, IntPtr hMenu, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        public static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DevMode lpDevMode);

        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings([In, Out]ref DevMode lpDevMode, [param: MarshalAs(UnmanagedType.U4)] uint dwflags);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventProc lpfnWinEventProc, int idProcess, int idThread, uint dwflags);
        public delegate void WinEventProc(IntPtr hWinEventHook, uint iEvent, IntPtr hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime);

        [DllImport("user32.dll")]
        public static extern bool RedrawWindow(IntPtr hWnd, IntPtr lprcUpdate, IntPtr hrgnUpdate, RedrawWindowFlags flags);

        [DllImport("user32.dll")]
        public static extern bool InvalidateRect(IntPtr hWnd, IntPtr lpRect, bool bErase);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        public static extern bool AllowSetForegroundWindow(int dwProcessId);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetWindowRect(IntPtr hwnd, out Rect lpRect);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool GetClientRect(IntPtr hwnd, out Rect lpRect);

        public delegate IntPtr KeyboardHookDelegate(int nCode, IntPtr wParam, ref KbDllHookStruct lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SetWindowsHookEx(int idHook, KeyboardHookDelegate lpfn, IntPtr hMod, int dwThreadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, ref KbDllHookStruct lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);

        [DllImport("user32.dll")]
        public static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

    }
}
