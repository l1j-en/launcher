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
using System.IO;
using Launcher.Models;
using Launcher.Utilities;
using System.Net;
using System.Diagnostics;
using System.Linq;

namespace Launcher
{
    class Lineage
    {
        public static bool Run(Settings settings, string bin)
        {
            var startupInfo = new Win32Api.Startupinfo();
            /*var processInfo = new Win32Api.ProcessInformation();

          var success = Win32Api.CreateProcess(binpath, string.Format("\"{0}\" {1} {2}", binpath.Trim(), connectionIp, port),
               IntPtr.Zero, IntPtr.Zero, false,
               Win32Api.ProcessCreationFlags.CreateSuspended | Win32Api.ProcessCreationFlags.CreateDefaultErrorMode,
               IntPtr.Zero, null, ref startupInfo, out processInfo);

            var tHandle = processInfo.HThread;
            var buffer = new byte[2];

            System.Threading.Thread.Sleep(settings.LoginDelay);
            Injector.GetInstance.BInject(processInfo.DwProcessId, Path.Combine(clientDirectory, "login.dll"));
            Win32Api.ResumeThread(tHandle);*/

            var startProcess = Process.GetProcesses().FirstOrDefault(b => b.ProcessName.Contains(bin));
            Win32Api.SuspendThread(startProcess.Handle);
            System.Threading.Thread.Sleep(1000);

            // open the process after it is created so we can add the appropriate flags to write to the process
            var hndProc = Win32Api.OpenProcess((uint)(Win32Api.ProcessAccessFlags.CreateThread | Win32Api.ProcessAccessFlags.VirtualMemoryOperation
                                    | Win32Api.ProcessAccessFlags.VirtualMemoryRead | Win32Api.ProcessAccessFlags.VirtualMemoryWrite
                                    | Win32Api.ProcessAccessFlags.QueryInformation), 0, (uint)startProcess.Id);


            Win32Api.CloseHandle(startProcess.Handle);
            Win32Api.SuspendThread(hndProc);

            var process = Process.GetProcesses().FirstOrDefault(b => b.MainWindowTitle.Contains("Lineage Windows Client"));
            //var timeSpan = DateTime.Now - process.StartTime;

            try
            {
                var i = 0;
                var maxIterations = 6000;
                // wait for the window to initialize before continuing the injection process
                while (i <= maxIterations && process == null)
                {
                    System.Threading.Thread.Sleep(5);
                    process = Process.GetProcesses().FirstOrDefault(b => b.MainWindowTitle.Contains("Lineage Windows Client")); ;
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

            // Remove darkness
            if (settings.DisableDark)
            {
                //TODO -- check what this address looks like before it changes!!!
                Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x004E4320, new byte[] { 0x90, 0xE9 }, 2, 0);
            }

            // Mob level highlight toggle
            if (settings.EnableMobColours)
            {
                Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x004E5D94 , new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, 6, 0);
            }

            Win32Api.CloseHandle(hndProc);
            hndProc = IntPtr.Zero;

            System.Threading.Thread.Sleep(1000);
            return true;
        }
    }
}
