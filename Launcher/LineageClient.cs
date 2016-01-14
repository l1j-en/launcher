using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
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
        private readonly string _captureDirectory;
        private static List<LineageClient> _hookedWindows;
        private static User32.KeyboardHookDelegate _keyboardListener = null;
        private static IntPtr _keyboardHookId = IntPtr.Zero;
        private static readonly Dictionary<int, User32.WinEventProc> WindowListeners = new Dictionary<int, User32.WinEventProc>();
        private const int MaxRetries = 10;

        public Process Process { get; private set; }

        public LineageClient(string processName, string clientDirectory, List<LineageClient> hookedWindows)
        {
            this._processName = processName;
            this._captureDirectory = Path.Combine(clientDirectory, @"Capture\Launcher\");
            _hookedWindows = hookedWindows;
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

                        var style = User32.GetWindowLong(pFoundWindow, (int)(User32.WindowLongFlags.GwlStyle));

                        var hmenu = User32.GetMenu(proc.MainWindowHandle);
                        var count = User32.GetMenuItemCount(hmenu);

                        for (var i = 0; i < count; i++)
                            User32.RemoveMenu(hmenu, 0, (int)(User32.MenuFlags.MfByposition | User32.MenuFlags.MfRemove));

                        //force a redraw
                        User32.DrawMenuBar(proc.MainWindowHandle);
                        User32.SetWindowLong(pFoundWindow, (int)User32.WindowLongFlags.GwlStyle, (style & ~(int)User32.WindowLongFlags.WsSysmenu));

                        WindowListeners.Add(proc.Id, MoveWindowCallback);

                        User32.SetWinEventHook((uint)User32.WinEventDelegateFlags.EventSystemMovesizeend, 
                            (uint)User32.WinEventDelegateFlags.EventSystemMovesizeend, IntPtr.Zero, WindowListeners[proc.Id], proc.Id, 0,
                            (uint)User32.WinEventDelegateFlags.WineventOutofcontext);

                        if (_keyboardListener == null)
                            _keyboardListener = KeyboardInputCallback;

                        _keyboardHookId = User32.SetWindowsHookEx((int)User32.KeyboardHooks.WH_KEYBOARD_LL, _keyboardListener, 
                            Kernel32.GetModuleHandle(proc.MainModule.ModuleName), 0);

                        //used to handle Windows XP not getting the handle properly
                        if (_keyboardHookId == IntPtr.Zero)
                            _keyboardHookId = User32.SetWindowsHookEx((int)User32.KeyboardHooks.WH_KEYBOARD_LL, _keyboardListener, 
                                Marshal.GetHINSTANCE(Assembly.GetExecutingAssembly().GetModules()[0]), 0);

                        if (!Directory.Exists(this._captureDirectory))
                            Directory.CreateDirectory((this._captureDirectory));

                        return;
                    } //end if
                } //end foreach

                System.Threading.Thread.Sleep(500);
                attempts++;
            } //end while
        } //end Initialize

        private IntPtr KeyboardInputCallback(int nCode, IntPtr wParam, ref User32.KbDllHookStruct lParam)
        {
            try
            {
                var windowHandle = User32.GetForegroundWindow();
                var windowTitle = new StringBuilder(256);
                User32.GetWindowText(windowHandle, windowTitle, 256);

                if (nCode >= 0 && windowTitle.ToString() == "Lineage Windows Client")
                {
                    if (wParam == (IntPtr) User32.KeyboardHooks.WM_KEYUP)
                    {
                        //if is print screen
                        if (lParam.vkCode == (int)User32.Keys.VK_PRINT)
                        {
                            
                            User32.Rect windowRect, clientRect;
                            User32.GetWindowRect(windowHandle, out windowRect);
                            User32.GetClientRect(windowHandle, out clientRect);

                            var windowHeight = windowRect.Bottom - windowRect.Top;
                            var windowWidth = windowRect.Right - windowRect.Left;

                            var clientWidth = clientRect.Right - clientRect.Left;
                            var clientHeight = clientRect.Bottom - clientRect.Top;

                            var heightDiff = windowHeight - clientHeight;
                            var widthDiff = windowWidth - clientWidth;

                            var borderSize = widthDiff / 2;

                            var screenshot = new Bitmap(clientWidth - borderSize, clientHeight - borderSize,
                                PixelFormat.Format32bppArgb);
                            var graphics = Graphics.FromImage(screenshot);

                            graphics.CopyFromScreen(windowRect.Left + borderSize, windowRect.Top + heightDiff, 0, 0,
                                new Size(clientWidth - borderSize, clientHeight - borderSize),
                                CopyPixelOperation.SourceCopy);

                            var outputFileName = Path.Combine(this._captureDirectory, DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss") + ".png");
                            using (var memory = new MemoryStream())
                            {
                                using (var fs = new FileStream(outputFileName, FileMode.Create, FileAccess.ReadWrite))
                                {
                                    screenshot.Save(memory, ImageFormat.Png);
                                    var bytes = memory.ToArray();
                                    fs.Write(bytes, 0, bytes.Length);
                                }
                            }

                            //Return a dummy value to trap the keystroke
                            return User32.CallNextHookEx(_keyboardHookId, nCode, IntPtr.Zero, ref lParam);
                        } //end if printscreen
                    } //end if keyup
                } //end if client check
            }
            catch (Exception){} //just in case so we don't crash if the screenshot fails

            //The event wasn't handled, pass it to next application
            return User32.CallNextHookEx(_keyboardHookId, nCode, wParam, ref lParam);
        } //end KeyboardInputCallback

        private static void MoveWindowCallback(IntPtr hWinEventHook, uint iEvent, IntPtr hWnd, int idObject, int idChild, int dwEventThread, int dwmsEventTime)
        {
            User32.InvalidateRect(IntPtr.Zero, IntPtr.Zero, true);
            User32.RedrawWindow(hWinEventHook, IntPtr.Zero, IntPtr.Zero, User32.RedrawWindowFlags.UpdateNow);
        } //end MoveWindowCallback

        public void SetCentred(int screenWidth, int screenHeight)
        {
            var startPointX = (screenWidth / 2) - 320;
            var startPointY = (screenHeight / 2) - 240;
            User32.SetWindowPosPtr(this.Process.MainWindowHandle, (IntPtr)0, startPointX, startPointY, 646, 508, (int)User32.SetWindowPosFlags.FrameChanged);
        } //end SetCentred
    } //end class
} //end namespace
