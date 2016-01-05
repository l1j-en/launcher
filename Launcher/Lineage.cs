using System;
using System.IO;
using Launcher.WindowsAPI;

namespace Launcher
{
    class Lineage
    {
        private static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (var i = 0; i < a1.Length; i++)
                if (a1[i] != a2[i])
                    return false;

            return true;
        }

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

           
            const int bytesRead = 0;
            const int bytesWrite = 0;

            DllInjector.GetInstance.BInject(processInfo.DwProcessId, Path.Combine(settings.ClientDirectory, "login.dll"));

            Kernel32.ResumeThread(tHandle);
            System.Threading.Thread.Sleep(500);
            // Remove darkness
            if (settings.DisableDark)
            {
                byte[] write7 = { 0x90, 0xE9 };
                Kernel32.WriteProcessMemory(processInfo.HProcess, (IntPtr)0x0046690B, write7, (uint)write7.Length, bytesWrite);

                Kernel32.CloseHandle(processInfo.HProcess);
                Kernel32.ResumeThread(tHandle);

            }

            var closeNpPath = Path.Combine(settings.ClientDirectory, "closenp.dll");

            //just in case the user doesnt copy closenp to their directory
            if (File.Exists(closeNpPath))
                DllInjector.GetInstance.BInject(processInfo.DwProcessId, closeNpPath);

            System.Threading.Thread.Sleep(1000);
            Kernel32.ResumeThread(tHandle);
        }
    }
}
