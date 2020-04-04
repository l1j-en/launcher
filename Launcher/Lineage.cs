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
using Launcher.Models;
using Launcher.Utilities;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Launcher
{
    class Lineage
    {
        private static List<int> InjectedProcesses = new List<int>();
        private const int maxIterations = 6000;
        public static bool Run(Settings settings, string bin, string chosenServer)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = "Login.exe",
                WindowStyle = ProcessWindowStyle.Hidden,
                CreateNoWindow = true,
                UseShellExecute = false
            };

            var loginProcess = Process.Start(startInfo);
            for (var i = 0; loginProcess.MainWindowTitle != "Login" && i < maxIterations; i++)
            {
                System.Threading.Thread.Sleep(5);
                loginProcess.Refresh();
            }

            if (loginProcess.MainWindowTitle != "Login")
                return false;

            Win32Api.ShowWindow(loginProcess.MainWindowHandle, 0);

            var buttonHandle = Win32Api.FindWindowEx(loginProcess.MainWindowHandle, IntPtr.Zero, "Button", chosenServer);
            Win32Api.SendMessage(buttonHandle, 0x0201, IntPtr.Zero, IntPtr.Zero);
            Win32Api.SendMessage(buttonHandle, 0x0202, IntPtr.Zero, IntPtr.Zero);

            var startProcess = Process.GetProcesses().FirstOrDefault(b => b.ProcessName.Contains(bin) && !InjectedProcesses.Contains(b.Id));
            while(startProcess == null)
            {
                startProcess = Process.GetProcesses().FirstOrDefault(b => b.ProcessName.Contains(bin) && !InjectedProcesses.Contains(b.Id));
                System.Threading.Thread.Sleep(50);
            }

            Win32Api.SuspendThread(startProcess.Handle);

            // open the process after it is created so we can add the appropriate flags to write to the process
            var hndProc = Win32Api.OpenProcess((uint)(Win32Api.ProcessAccessFlags.CreateThread | Win32Api.ProcessAccessFlags.VirtualMemoryOperation
                                    | Win32Api.ProcessAccessFlags.VirtualMemoryRead | Win32Api.ProcessAccessFlags.VirtualMemoryWrite
                                    | Win32Api.ProcessAccessFlags.QueryInformation), 0, (uint)startProcess.Id);


            Win32Api.SuspendThread(hndProc);
            var process = Process.GetProcesses().FirstOrDefault(b => b.MainWindowTitle.Contains("Lineage Windows Client") && !InjectedProcesses.Contains(b.Id));

            try
            {
                var i = 0;
                // wait for the window to initialize before continuing the injection process
                while (i <= maxIterations && process == null)
                {
                    System.Threading.Thread.Sleep(5);
                    process = Process.GetProcesses().FirstOrDefault(b => b.MainWindowTitle.Contains("Lineage Windows Client") && !InjectedProcesses.Contains(b.Id));
                    i++;
                }

                if (i == maxIterations)
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }

            // Mob level highlight toggle
            if (settings.EnableMobColours)
            {
                Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x004E5D94 , new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, 6, 0);
            }

            if (settings.DisableUnderwater)
            {
                Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x0051E948, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, 7, 0);
                Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x0051E96B, new byte[] { 0x75 }, 1, 0);
            }

            //TODO -- probably a better way to do this than a hard-coded sleep
            // have to sleep to ensure the darkness toggle is done after the login.exe sets it
            // because in 363 it seems to disable darkness by default
            System.Threading.Thread.Sleep(1000);
            // Remove darkness
            if (settings.DisableDark)
            {
                Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x004E4320, new byte[] { 0x90, 0xE9 }, 2, 0);
            }
            else
            {
                Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x004E4320, new byte[] { 0x0F, 0x8D }, 2, 0);
            }

            InjectedProcesses.Add(process.Id);
            Win32Api.ResumeThread(hndProc);

            return true;
        }
    }
}
