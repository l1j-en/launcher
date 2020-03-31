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
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Launcher.Models;
using Microsoft.Win32;

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

        public static bool UpdateConfig(VersionInfo versionInfo)
        {
            var actuallyUpdated = false;

            var configKey = Registry.CurrentUser.OpenSubKey(@"Software\" + versionInfo.ServerName, true);

            if (configKey == null)
            {
                actuallyUpdated = true;
                configKey = Registry.CurrentUser.CreateSubKey(@"Software\" + versionInfo.ServerName);
            }

            if (!actuallyUpdated)
            {
                actuallyUpdated = (configKey.GetValue("Servers") == null || (configKey.GetValue("Servers").ToString() != versionInfo.Servers)) ||
                                  (configKey.GetValue("VersionInfoUrl") == null || configKey.GetValue("VersionInfoUrl").ToString() != versionInfo.VersionInfoUrl) ||
                                  (configKey.GetValue("VoteUrl") == null || configKey.GetValue("VoteUrl").ToString() != versionInfo.VoteUrl) ||
                                  (configKey.GetValue("WebsiteUrl") == null || configKey.GetValue("WebsiteUrl").ToString() != versionInfo.WebsiteUrl) ||
                                  (configKey.GetValue("NewsUrl") == null || configKey.GetValue("NewsUrl").ToString() != versionInfo.NewsUrl) ||
                                  (configKey.GetValue("UpdaterUrl") == null || configKey.GetValue("UpdaterUrl").ToString() != versionInfo.UpdaterUrl) ||
                                  (configKey.GetValue("LauncherUrl") == null || configKey.GetValue("LauncherUrl").ToString() != versionInfo.LauncherUrl) ||
                                  (configKey.GetValue("UpdaterFilesRoot") == null || configKey.GetValue("UpdaterFilesRoot").ToString() != versionInfo.UpdaterFilesRoot);
            }

            configKey.SetValue("Servers", versionInfo.Servers, RegistryValueKind.String);
            configKey.SetValue("VersionInfoUrl", versionInfo.VersionInfoUrl, RegistryValueKind.String);
            configKey.SetValue("VoteUrl", versionInfo.VoteUrl, RegistryValueKind.String);
            configKey.SetValue("WebsiteUrl", versionInfo.WebsiteUrl, RegistryValueKind.String);
            configKey.SetValue("NewsUrl", versionInfo.NewsUrl, RegistryValueKind.String);
            configKey.SetValue("UpdaterUrl", versionInfo.UpdaterUrl, RegistryValueKind.String);
            configKey.SetValue("LauncherUrl", versionInfo.LauncherUrl, RegistryValueKind.String);
            configKey.SetValue("UpdaterFilesRoot", versionInfo.UpdaterFilesRoot, RegistryValueKind.String);

            return actuallyUpdated;
        }

        public static LauncherConfig GetLauncherConfig(string keyName, string appPath)
        {
            try
            {
                var configKey = Registry.CurrentUser.OpenSubKey(@"Software\" + keyName, true);

                if(configKey != null)
                    return LoadFromRegistry(appPath, configKey);

                return LoadFromFlatFile(appPath);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static LauncherConfig LoadFromFlatFile(string appPath)
        {
            var configData = File.ReadAllText(Path.Combine(appPath, "l1jLauncher.cfg"));
            configData = Encoding.UTF8.GetString(Convert.FromBase64String(configData));

            var config = configData.JsonDeserialize<LauncherConfig>();
            config.InstallDir = appPath;
            config.ConfigType = ConfigType.FlatFile;

            return config;
        }

        private static LauncherConfig LoadFromRegistry(string appPath, RegistryKey configKey)
        {
            var config = new LauncherConfig(configKey.Name, appPath);
            var servers = configKey.GetValue("Servers").ToString().Split(',');
            config.Servers = new Dictionary<string, Server>();

            foreach (var server in servers)
            {
                var serverInfo = server.Split(':');

                config.Servers.Add(serverInfo[0].Trim(), new Server
                {
                    IpOrDns = serverInfo[1],
                    Port = int.Parse(serverInfo[2])
                });
            }

            config.UpdaterFilesRoot = new Uri(configKey.GetValue("UpdaterFilesRoot").ToString());
            config.UpdaterUrl = new Uri(configKey.GetValue("UpdaterUrl").ToString());
            config.VersionInfoUrl = new Uri(configKey.GetValue("VersionInfoUrl").ToString());
            config.VoteUrl = new Uri(configKey.GetValue("VoteUrl").ToString());
            config.WebsiteUrl = new Uri(configKey.GetValue("WebsiteUrl").ToString());

            var newsUrl = configKey.GetValue("NewsUrl");
            config.NewsUrl = new Uri(newsUrl == null ? "https://zelgo.net" : newsUrl.ToString());
            config.PublicKey = configKey.GetValue("PublicKey").ToString();
            config.ConfigType = ConfigType.Registry;

            return config;
        }

        public static List<string> GetAssociatedLaunchers(string appPath)
        {
            var associatedLaunchers = new List<string>();
            var settingsKey = Registry.CurrentUser.OpenSubKey(@"Software\LineageLauncher", true);

            if (settingsKey == null)
                return associatedLaunchers;

            foreach(var valueName in settingsKey.GetValueNames())
                if (string.Equals(settingsKey.GetValue(valueName).ToString(), appPath, StringComparison.CurrentCultureIgnoreCase))
                    associatedLaunchers.Add(valueName);

            return associatedLaunchers;
        }

        public static Settings LoadSettings(string keyOrDir, ConfigType configType)
        {
            try
            {
                if(configType == ConfigType.Registry)
                    return LoadSettingsFromRegistry(keyOrDir);

                return LoadSettingsFromFlatFile(keyOrDir);
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

        private static Settings LoadSettingsFromRegistry(string keyName)
        {
            var settingsKey = Registry.CurrentUser.OpenSubKey(@"Software\" + keyName, true);

            if (settingsKey == null)
                return new Settings();
            var settings = (byte[])settingsKey.GetValue("AppSettings");

            var ms = new MemoryStream((byte[])settingsKey.GetValue("AppSettings"));
            var settingsObject = DeserializeFromStream<Settings>(ms);

            return settingsObject;
        }

        public static void SaveSettings(string keyName, Settings settings, string clientDirectory, ConfigType configType)
        {

            if(configType == ConfigType.Registry)
            {
                SaveSettingsToRegistry(keyName, settings);
            } else
            {
                SaveSettingsToFlatFile(clientDirectory, settings);
            }

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
                        case "400 X 300":
                            stream.WriteByte(0xa0);
                            stream.WriteByte(0xb2);

                            stream.Seek(0x102, SeekOrigin.Begin);
                            stream.WriteByte(0x04); // 6 for 1200, 5 for 800, 5 for 400, 7 for 1600
                            break;
                        case "1200 X 900":
                            stream.WriteByte(0x45);
                            stream.WriteByte(0x85);

                            stream.Seek(0x102, SeekOrigin.Begin);
                            stream.WriteByte(0x06);
                            break;
                        case "1600 X 1200":
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
            using (var fs = new FileStream(
                Path.Combine(clientDirectory, "l1jSettings.cfg"),
                FileMode.Truncate,
                FileAccess.Write))
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

        private static void SaveSettingsToRegistry(string keyName, Settings settings)
        {
            var existingKey = Registry.CurrentUser.GetValue(@"Software\" + keyName);

            if (existingKey == null)
                existingKey = Registry.CurrentUser.CreateSubKey(@"Software\" + keyName);

            ((RegistryKey)existingKey).SetValue("AppSettings", Serialize(settings), RegistryValueKind.Binary);
        }

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

        public static VersionInfo GetVersionInfo(Uri versionInfoUrl, string pubKey)
        {
            try
            {
                var rsa = new RSACryptoServiceProvider();
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
                var result = rsa.VerifyData(Encoding.UTF8.GetBytes(json), CryptoConfig.MapNameToOID("SHA1"), signature); 

                if (result)
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

            using (var stream = File.OpenRead(file))
                using (var md5 = MD5.Create())
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", "").ToUpper();
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

        public static bool HasUpdates(string expectedUpdaterChecksum, long lastUpdated, LauncherConfig config)
        {
            var appDataPath = Directory.GetParent(Application.UserAppDataPath).ToString();
            var updaterLocation = Path.Combine(appDataPath, "Updater.exe");
            var updaterChecksum = Helpers.GetChecksum(updaterLocation);

            if (!File.Exists(updaterLocation) || updaterChecksum != expectedUpdaterChecksum)
                return true;

            var versionInfo = Helpers.GetVersionInfo(config.VersionInfoUrl, config.PublicKey);
            var launcherKey = Registry.CurrentUser.OpenSubKey(@"Software\" + config.KeyName, true);
            var lastUpdatedCheck = launcherKey.GetValue("LastUpdated");
            var updatesLastRun = (int?)lastUpdatedCheck ?? 0;

            if (updatesLastRun < lastUpdated)
                return true;

            return false;
        }
    } //end class
} //end namespace
