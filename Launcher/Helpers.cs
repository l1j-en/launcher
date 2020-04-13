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
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Launcher.Models;
using Microsoft.Win32;
using System.Linq;

namespace Launcher
{
    public static class Helpers
    {
        public struct WindowsVersion
        {
            public static string Windows8 { get { return "Windows 8"; } private set { } }
            public static string Windows10 { get { return "Windows 10"; } private set { } }
        };

        //this is a delegate used to access the UI from another thread
        private delegate void SetControlPropertyThreadSafeDelegate(Control control, string propertyName, object propertyValue);
        public static void SetControlPropertyThreadSafe(Control control, string propertyName, object propertyValue)
        {
            if (control.InvokeRequired)
                control.Invoke(new SetControlPropertyThreadSafeDelegate(SetControlPropertyThreadSafe), control, propertyName, propertyValue);
            else
                control.GetType().InvokeMember(propertyName, BindingFlags.SetProperty, null, control, new[] { propertyValue });
        }//end SetControlPropertyThreadSafe

        public static bool LauncherInLineageDirectory(string directory)
        {
            return File.Exists(Path.Combine(directory, "Login.dll"));
        }

        public static void SetConfigValue(string serverName, string field, string value, bool append = false)
        {
            var configKey = Registry.CurrentUser.OpenSubKey(@"Software\" + serverName, true);

            var newValue = value;
            if(append)
            {
                newValue = configKey.GetValue(field).ToString() + value;
            }

            configKey.SetValue(field, newValue, RegistryValueKind.String);
        }

        public static bool UpdateConfig(VersionInfo versionInfo, string appPath)
        {
            var actuallyUpdated = false;
            var launcherConfig = GetLauncherConfig(appPath);

            if ((launcherConfig.NewsUrl?.ToString() ?? string.Empty) != versionInfo.NewsUrl ||
               (launcherConfig.VoteUrl?.ToString() ?? string.Empty) != versionInfo.VoteUrl ||
               (launcherConfig.WebsiteUrl?.ToString() ?? string.Empty) != versionInfo.WebsiteUrl ||
               (launcherConfig.UpdaterUrl?.ToString() ?? string.Empty) != versionInfo.UpdaterUrl ||
               (launcherConfig.LauncherUrl?.ToString() ?? string.Empty) != versionInfo.LauncherUrl ||
               launcherConfig.UpdaterFilesRoot.ToString() != versionInfo.UpdaterFilesRoot ||
               launcherConfig.Servers.Count != versionInfo.Servers.Count)
            {
                actuallyUpdated = true;
            }
            
            // if nothing else has changed, make sure the servers have not changed
            if(!actuallyUpdated)
            {
                foreach(var currentServer in launcherConfig.Servers)
                {
                    if(!versionInfo.Servers.ContainsKey(currentServer.Key))
                    {
                        actuallyUpdated = true;
                        break;
                    }

                    var matchedServer = launcherConfig.Servers[currentServer.Key];
                    if(matchedServer.IpOrDns != currentServer.Value.IpOrDns || matchedServer.Port != currentServer.Value.Port)
                    {
                        actuallyUpdated = true;
                        break;
                    }
                }

                foreach (var newServer in versionInfo.Servers)
                {
                    if (!launcherConfig.Servers.ContainsKey(newServer.Key))
                    {
                        actuallyUpdated = true;
                        break;
                    }

                    var matchedServer = launcherConfig.Servers[newServer.Key];
                    if (matchedServer.IpOrDns != newServer.Value.IpOrDns || matchedServer.Port != newServer.Value.Port)
                    {
                        actuallyUpdated = true;
                        break;
                    }
                }
            }

            // actual changes were made, so write them to the config
            if(actuallyUpdated)
            {
                SaveLauncherConfig(appPath, (LauncherConfig)versionInfo);
            }

            return actuallyUpdated;
        }

        public static LauncherConfig GetLauncherConfig(string appPath)
        {
            try
            {
                var configData = File.ReadAllText(Path.Combine(appPath, "l1jLauncher.cfg"));
                configData = Encoding.UTF8.GetString(Convert.FromBase64String(configData));

                var config = configData.JsonDeserialize<LauncherConfig>();
                config.InstallDir = appPath;
                config.ConfigType = ConfigType.FlatFile;

                return config;
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to read l1jLauncher.cfg. Please ensure it is in your Lineage directory.");
            }
        }

        public static void SaveLauncherConfig(string appDir, LauncherConfig config)
        {
            using (var fs = new FileStream(
                Path.Combine(appDir, "l1jLauncher.cfg"),
                FileMode.Truncate,
                FileAccess.ReadWrite))
            {
                using (var ms = new MemoryStream())
                {
                    var serializer = new DataContractJsonSerializer(config.GetType(),
                        new List<Type> { typeof(Server) });

                    serializer.WriteObject(ms, config);
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

                    var bytes = new byte[ms.Length];
                    ms.Read(bytes, 0, (int)ms.Length);

                    // To anyone using this, this is not any form of encryption or security!
                    // This is only being done so the average user won't try to edit it and
                    // possibly crap out their settings!
                    var base64Bytes = Encoding.UTF8.GetBytes(Convert.ToBase64String(bytes));
                    fs.Write(base64Bytes, 0, base64Bytes.Length);
                }
            }
        }

        public static Settings LoadSettings(string directory)
        {
            try
            {
                return LoadSettingsFromFlatFile(directory);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static Settings LoadSettingsFromFlatFile(string installDir)
        {
            var configData = File.ReadAllText(Path.Combine(installDir, "l1jSettings.cfg"));
            var config = configData.JsonDeserialize<Settings>();
            return config;
        }

        public static void SaveSettings(Settings settings, string clientDirectory)
        {
            SaveSettingsToFlatFile(clientDirectory, settings);
            var lincfgPath = Path.Combine(clientDirectory, "lineage.cfg");

            if (!File.Exists(lincfgPath))
            {
                MessageBox.Show(@"Lineage.cfg file not found. Unable to update Window settings.");
                return;
            }

            using (var stream = new FileStream(lincfgPath, FileMode.Open, FileAccess.ReadWrite))
            {
                if(settings.Windowed)
                {
                    stream.Seek(0xa5, SeekOrigin.Begin);
                    stream.WriteByte(0);

                    stream.Seek(0x99, SeekOrigin.Begin);

                    switch(settings.WindowSize)
                    {
                        case "400x300":
                            stream.WriteByte(0xa0);
                            stream.WriteByte(0xb2);

                            stream.Seek(0x102, SeekOrigin.Begin);
                            stream.WriteByte(0x04);
                            break;
                        case "1200x900":
                            stream.WriteByte(0x45);
                            stream.WriteByte(0x85);

                            stream.Seek(0x102, SeekOrigin.Begin);
                            stream.WriteByte(0x06);
                            break;
                        case "1600x1200":
                            stream.WriteByte(0x9e);
                            stream.WriteByte(0x6d);

                            stream.Seek(0x102, SeekOrigin.Begin);
                            stream.WriteByte(0x07);
                            break;
                        default:
                            stream.WriteByte(0x60);
                            stream.WriteByte(0xb9);

                            stream.Seek(0x102, SeekOrigin.Begin);
                            stream.WriteByte(0x05);
                            break;
                    }

                    stream.Seek(0xe4, SeekOrigin.Begin);
                    stream.WriteByte(0x00);
                } else {
                    stream.Seek(0xa5, SeekOrigin.Begin);
                    stream.WriteByte(1);

                    stream.Seek(0x99, SeekOrigin.Begin);
                    stream.WriteByte(0x9b);
                    stream.WriteByte(0x97);

                    stream.Seek(0xe4, SeekOrigin.Begin);
                    stream.WriteByte(0x01);

                    stream.Seek(0x102, SeekOrigin.Begin);
                    stream.WriteByte(0x05);
                }

                stream.Close();
            }

        } //end SaveSettings

        private static void SaveSettingsToFlatFile(string clientDirectory, Settings settings)
        {
            if (!File.Exists(Path.Combine(clientDirectory, "l1jSettings.cfg")))
            {
                using (var settingsFile = File.Create(Path.Combine(clientDirectory, "l1jSettings.cfg")))
                    settingsFile.Close();
            }
                
            using (var fs = new FileStream(
                Path.Combine(clientDirectory, "l1jSettings.cfg"),
                FileMode.Truncate,
                FileAccess.ReadWrite))
            {
                using (var ms = new MemoryStream())
                {
                    var serializer = new DataContractJsonSerializer(settings.GetType(),
                        new List<Type> { typeof(Resolution) });

                    serializer.WriteObject(ms, settings);
                    ms.Flush();
                    ms.Seek(0, SeekOrigin.Begin);

                    var bytes = new byte[ms.Length];
                    ms.Read(bytes, 0, (int)ms.Length);
                    fs.Write(bytes, 0, bytes.Length);
                    fs.Close();
                }
            }
        }

        public static VersionInfo GetVersionInfo(Uri versionInfoUrl, string pubKey)
        {
            try
            {
                var rsa = new RSACryptoServiceProvider();

                if(pubKey != null)
                    rsa.FromXmlString(pubKey);

                var request = (HttpWebRequest) WebRequest.Create(versionInfoUrl);
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
                var verifiedData = true; 
                if(pubKey != null)
                    verifiedData = rsa.VerifyData(Encoding.UTF8.GetBytes(json), CryptoConfig.MapNameToOID("SHA1"), signature); 

                if (verifiedData)
                    return json.JsonDeserialize<VersionInfo>();

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        } //end GetVersionInfo

        public static string GetChecksum(string file)
        {
            if (!File.Exists(file))
                return "";

            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(file))
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
            }
        } //end GetChecksum

        public static bool ByteArrayCompare(byte[] a1, byte[] a2)
        {
            if (a1.Length != a2.Length)
                return false;

            for (int i = 0; i < a1.Length; i++)
            {
                if (a1[i] != a2[i])
                    return false;
            }
            return true;
        }

        public static int StringToNumber(string versionNumber)
        {
            return int.Parse(versionNumber.Replace(".", ""));
        }
    } //end class
} //end namespace
