using System;
using System.IO;
using Launcher.WindowsAPI;

namespace Launcher
{
    class Lineage
    {
        private static Kernel32.ProcessInformation _processInfo;

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
            _processInfo = new Kernel32.ProcessInformation();

            //TODO -- what to do if !success?
            var success = Kernel32.CreateProcess(binpath, string.Format("\"{0}\" {1} {2}", binpath.Trim(), ip, port),
                IntPtr.Zero, IntPtr.Zero, false,
                Kernel32.ProcessCreationFlags.CreateSuspended | Kernel32.ProcessCreationFlags.CreateDefaultErrorMode,
                IntPtr.Zero, null, ref startupInfo, out _processInfo);

            var tHandle = _processInfo.HThread;

            // TODO: need a better way to suspend the client after themida unpack
            var tries = 10;
            byte[] runtimeexpired = { 0x75, 0x3B };
            var buffer = new byte[2];
            const int bytesRead = 0;
            const int bytesWrite = 0;

            Kernel32.ResumeThread(tHandle);
            System.Threading.Thread.Sleep(500);

            while (tries > 0)
            {
                Kernel32.SuspendThread(tHandle);
                Kernel32.ReadProcessMemory(_processInfo.HProcess, (IntPtr)0x0045CF2F, buffer, (uint)buffer.Length, bytesRead);

                if (ByteArrayCompare(runtimeexpired, buffer))
                {
                    // Fix Runtime Expired
                    byte[] write1 = { 0xEB };
                    Kernel32.WriteProcessMemory(_processInfo.HProcess, (IntPtr)0x0045CF2F, write1, (uint)write1.Length, bytesWrite);

                    // Fix GameGuard
                    byte[] write2 = { 0x90, 0xE9 };
                    Kernel32.WriteProcessMemory(_processInfo.HProcess, (IntPtr)0x0045E3AC, write2, (uint)write2.Length, bytesWrite);

                    byte[] write3 = { 0x90, 0x90 };
                    Kernel32.WriteProcessMemory(_processInfo.HProcess, (IntPtr)0x004DE45A, write3, (uint)write3.Length, bytesWrite);

                    byte[] write4 = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
                    Kernel32.WriteProcessMemory(_processInfo.HProcess, (IntPtr)0x0045BA71, write4, (uint)write4.Length, bytesWrite);

                    byte[] write5 = { 0xEB };
                    Kernel32.WriteProcessMemory(_processInfo.HProcess, (IntPtr)0x0045EABA, write5, (uint)write5.Length, bytesWrite);

                    // Disable NPK Service
                    byte[] write6 = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x84, 0xC0, 0x5E, 0x5B, 0xEB };
                    Kernel32.WriteProcessMemory(_processInfo.HProcess, (IntPtr)0x00474AC4, write6, (uint)write6.Length, bytesWrite);

                    // Remove darkness
                    if (settings.DisableDark)
                    {
                        byte[] write7 = { 0x90, 0xE9 };
                        Kernel32.WriteProcessMemory(_processInfo.HProcess, (IntPtr)0x0046690B, write7, (uint)write7.Length, bytesWrite);
                    }

                    // Codepage??
                    byte[] write8 = { 0x90, 0x90, 0x90, 0x90, 0x90, 0x90 };
                    Kernel32.WriteProcessMemory(_processInfo.HProcess, (IntPtr)0x00483B8E, write8, (uint)write8.Length, bytesWrite);

                    Kernel32.ResumeThread(tHandle);
                    break;
                }

                Kernel32.ResumeThread(tHandle);
                System.Threading.Thread.Sleep(500);
                tries--;
            }

            var closeNpPath = Path.Combine(settings.ClientDirectory, "closenp.dll");

            //just in case the user doesnt copy closenp to their directory
            if (File.Exists(closeNpPath))
                DllInjector.GetInstance.BInject(_processInfo.DwProcessId, closeNpPath);

            System.Threading.Thread.Sleep(1000);
            Kernel32.ResumeThread(tHandle);
        }
    }
}
