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
using System.Net.Sockets;
using System.Net;

namespace Launcher
{
    class Lineage
    {
        private static uint localHost = (uint)IPAddress.NetworkToHostOrder(BitConverter.ToInt32(IPAddress.Parse("127.0.0.1").GetAddressBytes(), 0));

        public static void Run(Settings settings, string clientDirectory, string bin, ushort port)
        {
            var binpath = Path.Combine(clientDirectory, bin);

            var startupInfo = new Win32Api.Startupinfo();
            var processInfo = new Win32Api.ProcessInformation();

            //TODO -- what to do if !success?
            var success = Win32Api.CreateProcess(binpath, string.Format("\"{0}\" {1} {2}", binpath.Trim(), localHost, port),
                IntPtr.Zero, IntPtr.Zero, false,
                Win32Api.ProcessCreationFlags.CreateSuspended | Win32Api.ProcessCreationFlags.CreateDefaultErrorMode,
                IntPtr.Zero, null, ref startupInfo, out processInfo);

            var tHandle = processInfo.HThread;

            Injector.GetInstance.BInject(processInfo.DwProcessId, Path.Combine(clientDirectory, "login.dll"));
            Win32Api.ResumeThread(tHandle);
            System.Threading.Thread.Sleep(1000);

            // open the process after it is created so we can add the appropriate flags to write to the process
            var hndProc = Win32Api.OpenProcess((uint)(Win32Api.ProcessAccessFlags.CreateThread | Win32Api.ProcessAccessFlags.VirtualMemoryOperation
                                              | Win32Api.ProcessAccessFlags.VirtualMemoryRead | Win32Api.ProcessAccessFlags.VirtualMemoryWrite
                                              | Win32Api.ProcessAccessFlags.QueryInformation), 0, processInfo.DwProcessId);

            Win32Api.CloseHandle(tHandle);

            Win32Api.SuspendThread(hndProc);

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
                
            // Don't know if the constant suspend/resume is needed, but WinXP was being funnky and this works
            // Needed to get the lance master poly working properly
            var zelgoPak = File.ReadAllBytes(Path.Combine(clientDirectory, "zelgo.pak"));
            Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x004B6CE0, new byte[] { 0xEB }, 1, 0);
            Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x00504538, zelgoPak, (uint)zelgoPak.Length - 1, 0);
            Win32Api.WriteProcessMemory(hndProc, (IntPtr)0x006DA508, new byte[] { 0x0F, 0x27 }, 2, 0);
            Win32Api.ResumeThread(hndProc);

            Win32Api.CloseHandle(hndProc);
            hndProc = IntPtr.Zero;

            System.Threading.Thread.Sleep(1000);
        }
    }
}
