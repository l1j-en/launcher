using System;
using System.IO;
using System.Runtime.InteropServices;

namespace Launcher
{
    class Lineage
    {
        private static ProcessInformation _processInfo;

        /* PINVOKE  */
        private struct Startupinfo
        {
            public uint Cb;
            public string LpReserved;
            public string LpDesktop;
            public string LpTitle;
            public uint DwX;
            public uint DwY;
            public uint DwXSize;
            public uint DwYSize;
            public uint DwXCountChars;
            public uint DwYCountChars;
            public uint DwFillAttribute;
            public uint DwFlags;
            public short WShowWindow;
            public short CbReserved2;
            public IntPtr LpReserved2;
            public IntPtr HStdInput;
            public IntPtr HStdOutput;
            public IntPtr HStdError;
        }

        private struct ProcessInformation
        {
            public IntPtr HProcess;
            public IntPtr HThread;
            public uint DwProcessId;
            public uint DwThreadId;
        }

        [Flags]
        private enum ProcessCreationFlags : uint
        {
            CreateDefaultErrorMode = 0x04000000,
            CreateSuspended = 0x00000004
        }

        [DllImport("kernel32.dll")]
        private static extern bool CreateProcess(string lpApplicationName,
               string lpCommandLine, IntPtr lpProcessAttributes,
               IntPtr lpThreadAttributes,
               bool bInheritHandles, ProcessCreationFlags dwCreationFlags,
               IntPtr lpEnvironment, string lpCurrentDirectory,
               ref Startupinfo lpStartupInfo,
               out ProcessInformation lpProcessInformation);

        [DllImport("kernel32.dll")]
        private static extern uint ResumeThread(IntPtr hThread);

        public static void Run(string clientFolder, string bin, long ip, ushort port)
        {
            var binpath = Path.Combine(clientFolder, bin);

            var startupInfo = new Startupinfo();
            _processInfo = new ProcessInformation();

            //TODO -- what to do if !success?
            var success = CreateProcess(binpath, string.Format("\"{0}\" {1} {2}", binpath.Trim(), ip, port),
                IntPtr.Zero, IntPtr.Zero, false,
                ProcessCreationFlags.CreateSuspended | ProcessCreationFlags.CreateDefaultErrorMode,
                IntPtr.Zero, null, ref startupInfo, out _processInfo);

            var logindllpath = Path.Combine(clientFolder, "Login.dll");
            DllInjector.GetInstance.BInject(_processInfo.DwProcessId, logindllpath);

            var closeNpPath = Path.Combine(clientFolder, "closenp.dll");

            //just in case the user doesnt copy closenp to their directory
            if (File.Exists(closeNpPath))
                DllInjector.GetInstance.BInject(_processInfo.DwProcessId, closeNpPath);

            System.Threading.Thread.Sleep(1000);

            var tHandle = _processInfo.HThread;
            ResumeThread(tHandle);
        }
    }
}
