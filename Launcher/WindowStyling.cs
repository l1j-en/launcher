using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Launcher
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
        public int dmDisplayOrientation;
    }

    public class WindowStyling
    {
        #region Constants
        //Finds a window by class name

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
        static extern IntPtr GetMenu(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int GetMenuItemCount(IntPtr hMenu);

        [DllImport("user32.dll")]
        static extern bool DrawMenuBar(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool RemoveMenu(IntPtr hMenu, uint uPosition, uint uFlags);

        [DllImport("user32.dll", EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPosPtr(IntPtr hWnd, IntPtr hMenu, int x, int y, int cx, int cy, uint uFlags);

        [DllImport("user32.dll")]
        static extern bool EnumDisplaySettings(string lpszDeviceName, int iModeNum, ref DevMode lpDevMode);

        [DllImport("user32.dll")]
        public static extern int ChangeDisplaySettings([In, Out]ref DevMode lpDevMode, [param: MarshalAs(UnmanagedType.U4)] uint dwflags);

        //assorted constants needed
        private const uint MfByposition = 0x400;
        private const uint MfRemove = 0x1000;
        private const int GwlStyle = -16;
        private const int WsBorder = 0x00800000; //window with border
        private const int WsDlgframe = 0x00400000; //window with double border but no title
        private const int WsCaption = WsBorder | WsDlgframe; //window with a title bar 
        private const int WsSysmenu = 0x00080000; //window menu 
        private const int CS_NOCLOSE = 0x0200; // close icon

        private const int SwpFramechanged = 0x0020;

        private const int DISP_CHANGE_SUCCESSFUL = 0;

        private const int ENUM_CURRENT_SETTINGS = -1;

        private const int MaxRetries = 10;
        #endregion

        public static DevMode ChangeDisplayColour(int bitCount)
        {
            return ChangeDisplaySettings(-1, -1, bitCount);
        }

        public static DevMode ChangeDisplaySettings(int width, int height, int bitCount)
        {
            var originalMode = new DevMode();
            originalMode.dmSize = (short)Marshal.SizeOf(originalMode);

            // Retrieving current settings
            // to edit them
            EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref originalMode);

            // Making a copy of the current settings
            // to allow reseting to the original mode
            var newMode = originalMode;

            // Changing the settings
            if (width != -1 && height != -1)
            {
                newMode.dmPelsHeight = width;
                newMode.dmDisplayFlags = height;
            }
            
            newMode.dmPelsWidth = bitCount;

            // Capturing the operation result
            var result = ChangeDisplaySettings(ref newMode, 0);

            if (result != DISP_CHANGE_SUCCESSFUL)
                MessageBox.Show("Resolution change failed. Unable to modify resolution.");

            return originalMode;
        } //end ChangeDisplaySettings

        public static void SetWindowed(string processName)
        {
            var processFound = false;
            var attempts = 0;

            while (!processFound && attempts < MaxRetries)
            {
                var procs = Process.GetProcesses();
                foreach (var proc in procs)
                {
                    if (!proc.ProcessName.StartsWith(processName))
                        continue;

                    var pFoundWindow = proc.MainWindowHandle;
                    if (pFoundWindow.ToInt32() > 0)
                    {
                        processFound = true;

                        var style = GetWindowLong(pFoundWindow, GwlStyle);

                        //get menu
                        var hmenu = GetMenu(proc.MainWindowHandle);
                        //get item count
                        var count = GetMenuItemCount(hmenu);
                        //loop & remove
                        for (var i = 0; i < count; i++)
                            RemoveMenu(hmenu, 0, (MfByposition | MfRemove));

                        //force a redraw
                        DrawMenuBar(proc.MainWindowHandle);
                        SetWindowLong(pFoundWindow, GwlStyle, (style & ~WsSysmenu));
                        style = GetWindowLong(pFoundWindow, GwlStyle);
                    }
                } //end for

                System.Threading.Thread.Sleep(500);
                attempts++;
            } //end while
        } //end SetWindowed

        public static void SetCentred(string processName, int screenWidth, int screenHeight)
        {
            var processFound = false;
            var attempts = 0;

            while (!processFound && attempts < MaxRetries)
            {
                var procs = Process.GetProcesses();
                foreach (var proc in procs)
                {
                    if (!proc.ProcessName.StartsWith(processName))
                        continue;

                    var pFoundWindow = proc.MainWindowHandle;

                    if (pFoundWindow.ToInt32() > 0)
                    {
                        processFound = true;

                        var startPointX = (screenWidth / 2) - 320;
                        var startPointY = (screenHeight / 2) - 240;
                        SetWindowPosPtr(pFoundWindow, (IntPtr)0, startPointX, startPointY, 645, 507, SwpFramechanged);
                    }
                } //end for

                System.Threading.Thread.Sleep(500);
                attempts++;
            } //end while
        } //end WindowRestyle
    } //end class
} //end namespace
