/* This program is free software; you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation; either version 2 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License along
 * with this program; if not, write to the Free Software Foundation, Inc.,
 * 51 Franklin Street, Fifth Floor, Boston, MA 02110-1301 USA.
 */
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Launcher.Models;
using Launcher.WindowsAPI;

namespace Launcher
{
    public class LineageClient
    {
        //assorted constants needed
        private const int DispChangeSuccessful = 0;
        private const int EnumCurrentSettings = -1;
        private readonly string _processName;
        private static List<LineageClient> _hookedWindows;
        private static IntPtr _keyboardHookId = IntPtr.Zero;
        private const int MaxRetries = 10;
        private static Settings _appSettings = null;

        public Process Process { get; private set; }

        public LineageClient(string settingsKeyName, string processName, string clientDirectory, List<LineageClient> hookedWindows)
        {
            this._processName = processName;
            _hookedWindows = hookedWindows;
            _appSettings = Helpers.LoadSettings(settingsKeyName);
        }

        public static User32.DevMode ChangeDisplayColour(int bitCount)
        {
            return LineageClient.ChangeDisplaySettings(-1, -1, bitCount);
        }

        public static User32.DevMode ChangeDisplaySettings(User32.DevMode mode)
        {
            return LineageClient.ChangeDisplaySettings(mode.dmPelsWidth, mode.dmPelsHeight, mode.dmBitsPerPel);
        }

        public static List<Resolution> GetResolutions(bool isWin8OrHigher)
        {
            var currentResolution = new User32.DevMode();
            User32.EnumDisplaySettings(null, EnumCurrentSettings, ref currentResolution);

            var returnValue = new List<Resolution>();
            var i = 0;
            var displayDevice = new User32.DevMode();

            // if we are pre Win 8, then use 16 bit colours, otherwise we use 32 bit since 16 bit isn't supported
            var colourBit = isWin8OrHigher ? 32 : 16;

            while (User32.EnumDisplaySettings(null, i, ref displayDevice))
            {
                var colour = displayDevice.dmBitsPerPel;
                var width = displayDevice.dmPelsWidth;
                var height = displayDevice.dmPelsHeight;

                if (colour == colourBit && currentResolution.dmDisplayFrequency == displayDevice.dmDisplayFrequency
                    && displayDevice.dmDisplayFixedOutput == 0 && width >= 800 &&
                    (width != currentResolution.dmPelsWidth && height != currentResolution.dmPelsHeight))
                    returnValue.Add(new Resolution
                    {
                        Width = width,
                        Height = height,
                        Colour = colour
                    });

                i++;
            } //end while

            return returnValue.OrderByDescending(b => b.Width).ThenByDescending(b => b.Height).ToList();
        } 

        public static User32.DevMode ChangeDisplaySettings(int width, int height, int bitCount)
        {
            var originalMode = new User32.DevMode();
            originalMode.dmSize = (short)Marshal.SizeOf(originalMode);

            // Retrieving current settings
            // to edit them
            User32.EnumDisplaySettings(null, EnumCurrentSettings, ref originalMode);

            // Making a copy of the current settings
            // to allow reseting to the original mode
            var newMode = originalMode;

            // Changing the settings
            if (width != -1 && height != -1)
            {
                newMode.dmPelsHeight = height;
                newMode.dmPelsWidth = width;
            }
            
            newMode.dmBitsPerPel = bitCount;

            // Capturing the operation result
            var result = User32.ChangeDisplaySettings(ref newMode, 0);

            if (result != DispChangeSuccessful)
                MessageBox.Show(@"Resolution change failed. Unable to modify resolution.");

            return originalMode;
        } //end ChangeDisplaySettings

        public void Initialize()
        {
            var attempts = 0;

            while (attempts < MaxRetries)
            {
                var procs = Process.GetProcesses();
                foreach (var proc in procs)
                {
                    if (!proc.ProcessName.StartsWith(this._processName) || 
                        (_hookedWindows.Count > 0 && _hookedWindows.All(b => b.Process.Id == proc.Id)))
                        continue;

                    var pFoundWindow = proc.MainWindowHandle;
                    var procHandleId = pFoundWindow.ToInt32();
                    if (procHandleId > 0)
                    {
                        this.Process = proc;

                        if(_appSettings.Windowed)
                        {
                            var style = User32.GetWindowLong(pFoundWindow, (int)(User32.WindowLongFlags.GwlStyle));

                            var hmenu = User32.GetMenu(proc.MainWindowHandle);
                            var count = User32.GetMenuItemCount(hmenu);

                            for (var i = 0; i < count; i++)
                                User32.RemoveMenu(hmenu, 0, (int)(User32.MenuFlags.MfByposition | User32.MenuFlags.MfRemove));

                            //force a redraw
                            User32.DrawMenuBar(proc.MainWindowHandle);
                            User32.SetWindowLong(pFoundWindow, (int)User32.WindowLongFlags.GwlStyle, (style & ~(int)User32.WindowLongFlags.WsSysmenu));
                        }

                        return;
                    } //end if
                } //end foreach

                System.Threading.Thread.Sleep(500);
                attempts++;
            } //end while
        } //end Initialize

        private static void MoveWindowCallback(IntPtr hWinEventHook, uint iEvent, IntPtr hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime)
        {
            User32.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
            User32.RedrawWindow(hWinEventHook, IntPtr.Zero, IntPtr.Zero, User32.RedrawWindowFlags.UpdateNow);
        } //end MoveWindowCallback
    } //end class
} //end namespace
