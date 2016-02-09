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
using Launcher.WindowsAPI;

namespace Launcher
{
    class Lineage
    {
        public static void Run(Settings settings, string bin, long ip, ushort port)
        {
            var binpath = Path.Combine(settings.ClientDirectory, bin);

            var startupInfo = new Kernel32.Startupinfo();
            var processInfo = new Kernel32.ProcessInformation();

            //TODO -- what to do if !success?
            var success = Kernel32.CreateProcess(binpath, string.Format("\"{0}\" {1} {2}", binpath.Trim(), ip, port),
                IntPtr.Zero, IntPtr.Zero, false,
                Kernel32.ProcessCreationFlags.CreateSuspended | Kernel32.ProcessCreationFlags.CreateDefaultErrorMode,
                IntPtr.Zero, null, ref startupInfo, out processInfo);

            var tHandle = processInfo.HThread;
            const int bytesWrite = 0;

            DllInjector.GetInstance.BInject(processInfo.DwProcessId, Path.Combine(settings.ClientDirectory, "login.dll"));
            Kernel32.ResumeThread(tHandle);
            System.Threading.Thread.Sleep(1000);

            // open the process after it is created so we can add the appropriate flags to write to the process
            var hndProc = Kernel32.OpenProcess((uint)(Kernel32.ProcessAccessFlags.CreateThread | Kernel32.ProcessAccessFlags.VirtualMemoryOperation
                                              | Kernel32.ProcessAccessFlags.VirtualMemoryRead | Kernel32.ProcessAccessFlags.VirtualMemoryWrite
                                              | Kernel32.ProcessAccessFlags.QueryInformation), 0, processInfo.DwProcessId);

            Kernel32.CloseHandle(tHandle);

            // Remove darkness
            if (settings.DisableDark)
            {
                Kernel32.SuspendThread(hndProc);
                Kernel32.WriteProcessMemory(hndProc, (IntPtr)0x0046690B, new byte[] { 0x90, 0xE9 }, 2, bytesWrite);
                Kernel32.ResumeThread(hndProc);
            }

            // Mob level highlight toggle
            if (settings.EnableMobColours)
            {
                Kernel32.SuspendThread(hndProc);
                Kernel32.WriteProcessMemory(hndProc, (IntPtr)0x0046786E, new byte[] { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 }, 6, 0);
                Kernel32.ResumeThread(hndProc);
            }
                
            // Don't know if the constant suspend/resume is needed, but WinXP was being funnky and this works
            // Needed to get the lance master poly working properly
            var zelgoPak = File.ReadAllBytes(Path.Combine(settings.ClientDirectory, "zelgo.pak"));
            Kernel32.SuspendThread(hndProc);
            Kernel32.WriteProcessMemory(hndProc, (IntPtr)0x004B6CE0, new byte[] { 0xEB }, 1, 0);
            Kernel32.ResumeThread(hndProc);
            
            Kernel32.SuspendThread(hndProc);
            Kernel32.WriteProcessMemory(hndProc, (IntPtr)0x00504538, zelgoPak, (uint)zelgoPak.Length - 1, 0);
            System.Threading.Thread.Sleep(1000);
            Kernel32.ResumeThread(hndProc);

            Kernel32.SuspendThread(hndProc);
            Kernel32.WriteProcessMemory(hndProc, (IntPtr)0x006DA508, new byte[] { 0x0F, 0x27 }, 2, 0);
            Kernel32.ResumeThread(hndProc);

            Kernel32.CloseHandle(hndProc);

            System.Threading.Thread.Sleep(1000);
        }
    }
}
