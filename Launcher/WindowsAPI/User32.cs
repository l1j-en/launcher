using System;
using System.Runtime.InteropServices;

namespace Launcher.WindowsAPI
{
    public static class User32
    {
        public struct DevMode
        {
            private const int Cchdevicename = 0x20;
            private const int Cchformname = 0x20;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string DmDeviceName;
            public short DmSpecVersion;
            public short DmDriverVersion;
            public short DmSize;
            public short DmDriverExtra;
            public int DmFields;
            public int DmPositionX;
            public int DmPositionY;
            public int DmDisplayFixedOutput;
            public short DmColor;
            public short DmDuplex;
            public short DmYResolution;
            public short DmTtOption;
            public short DmCollate;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x20)]
            public string DmFormName;
            public short DmLogPixels;
            public int DmBitsPerPel;
            public int DmPelsWidth;
            public int DmPelsHeight;
            public int DmDisplayFlags;
            public int DmDisplayFrequency;
            public int DmIcmMethod;
            public int DmIcmIntent;
            public int DmMediaType;
            public int DmDitherType;
            public int DmReserved1;
            public int DmReserved2;
            public int DmPanningWidth;
            public int DmPanningHeight;
            public int DmDisplayOrientation;
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

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        //Sets a window to be a child window of another window
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

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
    }
}
