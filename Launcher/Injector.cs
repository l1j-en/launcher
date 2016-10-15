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
using System.Diagnostics;
using System.IO;
using System.Text;
using Launcher.Utilities;

namespace Launcher
{
    public enum InjectionResult
    {
        DllNotFound,
        GameProcessNotFound,
        InjectionFailed,
        Success
    }

    public sealed class Injector
    {
        static readonly IntPtr IntptrZero = (IntPtr)0;

        static Injector _instance;

        public static Injector GetInstance
        {
            get { return _instance ?? (_instance = new Injector()); }
        }

        Injector() { }

        public InjectionResult Inject(string sProcName, string sDllPath)
        {
            if (!File.Exists(sDllPath))
                return InjectionResult.DllNotFound;

            uint procId = 0;

            var procs = Process.GetProcesses();
            for (var i = 0; i < procs.Length; i++)
            {
                if (procs[i].ProcessName == sProcName)
                {
                    procId = (uint)procs[i].Id;
                    break;
                }
            }

            if (procId == 0)
                return InjectionResult.GameProcessNotFound;

            if (!this.BInject(procId, sDllPath))
                return InjectionResult.InjectionFailed;

            return InjectionResult.Success;
        }

        public bool BInject(uint pToBeInjected, string sDllPath)
        {
            var hndProc = Win32Api.OpenProcess((uint) (Win32Api.ProcessAccessFlags.CreateThread | Win32Api.ProcessAccessFlags.VirtualMemoryOperation
                                              | Win32Api.ProcessAccessFlags.VirtualMemoryRead | Win32Api.ProcessAccessFlags.VirtualMemoryWrite
                                              | Win32Api.ProcessAccessFlags.QueryInformation), 1, pToBeInjected);
            if (hndProc == IntptrZero)
                return false;

            var lpLlAddress = Win32Api.GetProcAddress(Win32Api.GetModuleHandle("kernel32.dll"), "LoadLibraryA");
            if (lpLlAddress == IntptrZero)
                return false;

            var lpAddress = Win32Api.VirtualAllocEx(hndProc, (IntPtr)null, (IntPtr)sDllPath.Length, 
                (int)(Win32Api.AllocationType.Commit | Win32Api.AllocationType.Reserve), (int)Win32Api.MemoryProtection.ExecuteReadWrite);
            if (lpAddress == IntptrZero)
                return false;

            var bytes = Encoding.ASCII.GetBytes(sDllPath);

            if (Win32Api.WriteProcessMemory(hndProc, lpAddress, bytes, (uint)bytes.Length, 0) == 0)
                return false;

            if (Win32Api.CreateRemoteThread(hndProc, (IntPtr)null, IntptrZero, lpLlAddress, lpAddress, 0, (IntPtr)null) == IntptrZero)
                return false;

            Win32Api.CloseHandle(hndProc);

            return true;
        }
    } 
}
