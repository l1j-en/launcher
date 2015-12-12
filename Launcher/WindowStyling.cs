using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Launcher.WindowsAPI;

namespace Launcher
{
    public class WindowStyling
    {
        //assorted constants needed
        private const int DispChangeSuccessful = 0;
        private const int EnumCurrentSettings = -1;

        private const int MaxRetries = 10;

        public static User32.DevMode ChangeDisplayColour(int bitCount)
        {
            return WindowStyling.ChangeDisplaySettings(-1, -1, bitCount);
        }

        public static User32.DevMode ChangeDisplaySettings(User32.DevMode mode)
        {
            return WindowStyling.ChangeDisplaySettings(mode.DmPelsHeight, mode.DmDisplayFlags, mode.DmPelsWidth);
        }

        public static User32.DevMode ChangeDisplaySettings(int width, int height, int bitCount)
        {
            var originalMode = new User32.DevMode();
            originalMode.DmSize = (short)Marshal.SizeOf(originalMode);

            // Retrieving current settings
            // to edit them
            User32.EnumDisplaySettings(null, EnumCurrentSettings, ref originalMode);

            // Making a copy of the current settings
            // to allow reseting to the original mode
            var newMode = originalMode;

            // Changing the settings
            if (width != -1 && height != -1)
            {
                newMode.DmPelsHeight = width;
                newMode.DmDisplayFlags = height;
            }
            
            newMode.DmPelsWidth = bitCount;

            // Capturing the operation result
            var result = User32.ChangeDisplaySettings(ref newMode, 0);

            if (result != DispChangeSuccessful)
                MessageBox.Show(@"Resolution change failed. Unable to modify resolution.");

            return originalMode;
        } //end ChangeDisplaySettings

        public static int SetWindowed(string processName, List<int> alreadyHookedProcs)
        {
            var attempts = 0;

            while (attempts < MaxRetries)
            {
                var procs = Process.GetProcesses();
                foreach (var proc in procs)
                {
                    if (!proc.ProcessName.StartsWith(processName))
                        continue;

                    var pFoundWindow = proc.MainWindowHandle;
                    var procHandleId = pFoundWindow.ToInt32();
                    if (procHandleId > 0 && alreadyHookedProcs.IndexOf(proc.Id) == -1)
                    {
                        var style = User32.GetWindowLong(pFoundWindow, (int)User32.WindowLongFlags.GwlStyle);

                        var hmenu = User32.GetMenu(proc.MainWindowHandle);
                        var count = User32.GetMenuItemCount(hmenu);

                        for (var i = 0; i < count; i++)
                            User32.RemoveMenu(hmenu, 0, (int)(User32.MenuFlags.MfByposition | User32.MenuFlags.MfRemove));

                        //force a redraw
                        User32.DrawMenuBar(proc.MainWindowHandle);
                        User32.SetWindowLong(pFoundWindow, (int)User32.WindowLongFlags.GwlStyle, (style & ~(int)User32.WindowLongFlags.WsSysmenu));

                        return proc.Id;
                    }
                } //end for

                System.Threading.Thread.Sleep(500);
                attempts++;
            } //end while

            return -1;
        } //end SetWindowed

        public static int SetCentred(string processName, int screenWidth, int screenHeight, int procId = -1)
        {
            var attempts = 0;

            while (attempts < MaxRetries)
            {
                var procs = Process.GetProcesses();
                foreach (var proc in procs)
                {
                    if (!proc.ProcessName.StartsWith(processName))
                        continue;

                    var pFoundWindow = proc.MainWindowHandle;
                    var foundProcHandleId = pFoundWindow.ToInt32();
                    if ((proc.Id == procId) || (foundProcHandleId > 0 && procId == -1))
                    {
                        var startPointX = (screenWidth / 2) - 320;
                        var startPointY = (screenHeight / 2) - 240;
                        User32.SetWindowPosPtr(pFoundWindow, (IntPtr)0, startPointX, startPointY, 646, 508, (int)User32.SetWindowPosFlags.FrameChanged);

                        return proc.Id;
                    }
                } //end for

                System.Threading.Thread.Sleep(500);
                attempts++;
            } //end while

            return procId;
        } //end WindowRestyle
    } //end class
} //end namespace
