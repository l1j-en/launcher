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

namespace Launcher
{
    class Lineage
    {
        private static uint localHost = (uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(IPAddress.Parse("127.0.0.1").GetAddressBytes(), 0));
        private static byte[] runtimeExpired = { 0x75, 0x3B };

        public static bool Run(Settings settings, string clientDirectory, string bin, ushort port, IPAddress serverIp)
        {
            var binpath = Path.Combine(clientDirectory, bin);
            uint connectionIp;

            if (serverIp == null)
                connectionIp = localHost;
            else
                connectionIp = (uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(serverIp.GetAddressBytes(), 0));

            var startupInfo = new Win32Api.Startupinfo();
            var processInfo = new Win32Api.ProcessInformation();

            var success = Win32Api.CreateProcess(binpath, string.Format("\"{0}\" {1} {2}", binpath.Trim(), connectionIp, port),
                IntPtr.Zero, IntPtr.Zero, false,
                Win32Api.ProcessCreationFlags.CreateSuspended | Win32Api.ProcessCreationFlags.CreateDefaultErrorMode,
                IntPtr.Zero, null, ref startupInfo, out processInfo);

            var tHandle = processInfo.HThread;
            var buffer = new byte[2];

            System.Threading.Thread.Sleep(settings.LoginDelay);
            Injector.GetInstance.BInject(processInfo.DwProcessId, Path.Combine(clientDirectory, "login.dll"));
            Win32Api.ResumeThread(tHandle);

            for (var tries = 0; tries < 20; tries++)
            {
                Win32Api.ReadProcessMemory(processInfo.HProcess, (IntPtr)0x0045CF2F, buffer, (uint)buffer.Length, 0);
                if (Helpers.ByteArrayCompare(runtimeExpired, buffer))
                {
                    // gameguard and runtime expired
                    Win32Api.WriteProcessMemory(processInfo.HProcess, (IntPtr)0x0045CF2F, new byte[] { 0xEB }, 1, 0);
                    Win32Api.WriteProcessMemory(processInfo.HProcess, (IntPtr)0x0045E3AC, new byte[] { 0x90, 0xE9 }, 2, 0);
                    Win32Api.WriteProcessMemory(processInfo.HProcess, (IntPtr)0x004DE45A, new byte[] { 0x90, 0x90 }, 2, 0);
                    Win32Api.WriteProcessMemory(processInfo.HProcess, (IntPtr)0x0045BA71, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, 6, 0);
                    Win32Api.WriteProcessMemory(processInfo.HProcess, (IntPtr)0x0045EABA, new byte[] { 0xEB }, 1, 0);
                    Win32Api.WriteProcessMemory(processInfo.HProcess, (IntPtr)0x00474AC4, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x84, 0xC0, 0x5E, 0x5B, 0xEB }, 10, 0);
                    break;
                }

                System.Threading.Thread.Sleep(100);
            }

            Win32Api.ResumeThread(tHandle);
            Win32Api.CloseHandle(tHandle);

            // open the process after it is created so we can add the appropriate flags to write to the process
            var hndProc = Win32Api.OpenProcess((uint)(Win32Api.ProcessAccessFlags.CreateProcess | Win32Api.ProcessAccessFlags.VirtualMemoryOperation
                                                | Win32Api.ProcessAccessFlags.VirtualMemoryRead | Win32Api.ProcessAccessFlags.VirtualMemoryWrite
                                                | Win32Api.ProcessAccessFlags.QueryInformation), 0, processInfo.DwProcessId);

                
            Win32Api.SuspendThread(hndProc);

            var process = Process.GetProcessById((int)processInfo.DwProcessId);
            var timeSpan = DateTime.Now - process.StartTime;

            try
            {
                var i = 0;
                var maxIterations = 600;
                // wait for the window to initialize before continuing the injection process
                while (i <= maxIterations && process.MainWindowTitle != "Lineage Windows Client")
                {
                    System.Threading.Thread.Sleep(5);
                    process.Refresh();
                    i++;
                }

                if(i == maxIterations)
                {
                    return false;
                }
            } catch(Exception) {
                return false;
            }

            // Remove darkness
            if (settings.DisableDark)
            {
                Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x0046690B, new byte[] { 0x90, 0xE9 }, 2, 0);
            }
                
            // Mob level highlight toggle
            if (settings.EnableMobColours)
            {
                Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x0046786E, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, 6, 0);
            }

            // Needed to get the lance master poly working properly
            var zelgoPak = File.ReadAllBytes(Path.Combine(clientDirectory, "zelgo.pak"));
            Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x004B6CE0, new byte[] { 0xEB }, 1, 0);
            Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x00504538, zelgoPak, (uint)zelgoPak.Length - 1, 0);
            Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x006DA508, new byte[] { 0x0F, 0x27 }, 2, 0);
            Win32Api.ResumeThread(hndProc);

            Win32Api.CloseHandle(hndProc);
            hndProc = IntPtr.Zero;

            return true;
        }
    }
}
