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
using System.Drawing;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Launcher.Models;
using Microsoft.Win32;

namespace Launcher
{
    public static class Helpers
    {
        //this is a delegate used to access the UI from another thread
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), control, propertyName, propertyValue);
            else
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new[] { propertyValue });
        }//end SetControlPropertyThreadSafe

        public static Settings LoadSettings()
        {
            try
            {
                var settingsKey = Registry.CurrentUser.OpenSubKey(@"Software\LineageLauncher", true);

                if (settingsKey == null)
                    return new Settings();

                var ms = new MemoryStream((byte[])((RegistryKey)settingsKey).GetValue("AppSettings"));
                return DeserializeFromStream<Settings>(ms);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SaveSettings(Settings settings, bool isWin8OrHigher)
        {
            var existingKey = Registry.CurrentUser.GetValue(@"Software\LineageLauncher");

            if (existingKey == null)
                existingKey = Registry.CurrentUser.CreateSubKey(@"Software\LineageLauncher");

            ((RegistryKey)existingKey).SetValue("AppSettings", Serialize(settings), RegistryValueKind.Binary);

            //set the windowed flag in the lineage.cfg file
            if (isWin8OrHigher && settings.Windowed)
            {
                var compatRegKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                if (compatRegKey != null)
                    ((RegistryKey)compatRegKey).SetValue(Path.Combine(settings.ClientDirectory, settings.ClientBin),
                        "~ DWM8And16BitMitigation 16BITCOLOR WINXPSP3", RegistryValueKind.String);
            }

            var lincfgPath = Path.Combine(settings.ClientDirectory, "lineage.cfg");

            if (!File.Exists(lincfgPath))
            {
                MessageBox.Show(@"Lineage.cfg file not found. Unable to update Windowed settings.");
                return;
            }

            using (var cfgFile = File.Open(lincfgPath, FileMode.Open))
            {
                var windowedByte = settings.Windowed ? (byte)0 : (byte)1;

                cfgFile.Seek(0xe4, SeekOrigin.Begin);
                cfgFile.WriteByte(windowedByte);
                cfgFile.Close();
            }
           
            var musicFilePath = Path.Combine(settings.ClientDirectory, "music.cfg");

            if (!File.Exists(musicFilePath))
                using (File.Create(musicFilePath)){ }

            File.WriteAllText(musicFilePath, (settings.MusicType == "Original Midi Music" ? "1" : "0"));
        } //end SaveSettings

        public static byte[] Serialize(object objectToSerialize)
        {
            using (var ms = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(ms, objectToSerialize);
                return ms.ToArray();
            }
        } //end Serialize

        public static T DeserializeFromStream<T>(MemoryStream stream)
        {
            IFormatter formatter = new BinaryFormatter();
            stream.Seek(0, SeekOrigin.Begin);

            return (T)formatter.Deserialize(stream);
        } //end DeserializeFromStream

        public static VersionInfo GetVersionInfo()
        {
            try
            {
                const string pubKey =
                    "<RSAKeyValue><Modulus>l5mJTTO/MHTnaLbzkr0bfbOvY6qC9jWa39IIOtujP1mAPqhdEG2dIbtx20QEZ5P/9hg0KP16RvYj6BSwU4/Ees90mKpXV/7PzTp9uSRZuKNo+uoku7oqar4ruWmpcpPErKVGqD0i7908C/833VzSxdBxnqFqgF1nAk1iRJsnjxC8hseimjfe/E1EvO+Uk/NcA9VFR7YRPknuMLWMoLyl0EN6lJ4z5xLZKhPqGpMdIjDRmW2PdQxSFs5FIsVK9jYnqW/M6o+PiL1uj1py3EaBgIOkOMSUhEAHlgNkqdYlXHkqQ4W3HTuNkQmVLL8oZd6NXrflcF3PDEr1JtbTd+X+DQ==</Modulus><Exponent>JQ==</Exponent></RSAKeyValue>";

                var rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(pubKey);

                var request = (HttpWebRequest) WebRequest.Create("http://launcher.travis-smith.ca/VersionInfo.php");
                request.Timeout = 2000;
                request.Proxy = null;
                request.UserAgent = "L1J Launcher";

                var response = request.GetResponse();
                var data = response.GetResponseStream();
                var signature = Convert.FromBase64String(response.Headers["Verify-Hash"]);
                string json;

                using (var sr = new StreamReader(data))
                    json = sr.ReadToEnd();

                //needed to drop this to SHA1 because WinXP doesn't always support higher by default
                var result = rsa.VerifyData(Encoding.UTF8.GetBytes(json), CryptoConfig.MapNameToOID("SHA1"), signature); 
                if (result)
                    return json.JsonDeserialize<VersionInfo>();

                return null;
            }
            catch (Exception)
            {
                return null;
            }
        } //end GetVersionInfo

        public static string GetChecksum(string file)
        {
            if (!File.Exists(file))
                return "";

            using (var stream = File.OpenRead(file))
                using (var md5 = MD5.Create())
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToUpper();
        } //end GetChecksum

        public static bool IsWin8OrHigher(out string versionName)
        {
            var win8Version = new Version(6, 2, 9200, 0);
            versionName = "Windows 8";

            if (Environment.OSVersion.Version.Major >= 10)
                versionName = "Windows 10";

            return Environment.OSVersion.Platform == PlatformID.Win32NT &&
                   Environment.OSVersion.Version >= win8Version;
        } //end IsWin8OrHigher

        public static bool IsWin8Orhigher()
        {
            string versionName;
            return IsWin8OrHigher(out versionName);
        } //end IsWin8OrHigher

        public static Bitmap BlurImage(Bitmap imageToBlur, bool level, bool hpmp, bool ac, bool hotkeys, bool chat)
        {
            var screenshot = (Bitmap)imageToBlur.Clone();

            using (var g = Graphics.FromImage(screenshot))
            {
                if(level)
                    g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(33, 387, 78, 9));

                if (hpmp)
                {
                    g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(33, 404, 78, 12)); //hp
                    g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(33, 423, 78, 12)); //mp 
                }
                
                if(ac)
                    g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(30, 445, 24, 9));

                if(hotkeys)
                    g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(500, 386, 136, 67));

                if (chat)
                {
                    var checkColor = Color.FromArgb(231, 219, 222);
                    var level2 = screenshot.GetPixel(325, 333) == checkColor;
                    var level3 = screenshot.GetPixel(325, 299) == checkColor;
                    var level4 = screenshot.GetPixel(325, 265) == checkColor;

                    if (level4)
                        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(136, 283, 332, 177));
                    else if (level3)
                        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(136, 318, 332, 141));
                    else if (level2)
                        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(136, 354, 332, 105));
                    else
                        g.FillRectangle(new SolidBrush(Color.Black), new Rectangle(136, 389, 332, 71));                    
                }  
            }

            return screenshot;
        } //end BlurImage

        public static void SaveScreenshot(string fileName, Bitmap screenshot)
        {
            using (var memory = new MemoryStream())
            {
                using (var fs = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
                {
                    screenshot.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                    var bytes = memory.ToArray();
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
        } //end SaveScreenshot
    } //end class
} //end namespace
