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

        public static bool UpdateConfig(VersionInfo versionInfo, bool ignoreServers = false)
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
                actuallyUpdated = (configKey.GetValue("Servers") == null || (configKey.GetValue("Servers").ToString() != versionInfo.Servers && !ignoreServers)) ||
                                  (configKey.GetValue("VersionInfoUrl") == null || configKey.GetValue("VersionInfoUrl").ToString() != versionInfo.VersionInfoUrl) ||
                                  (configKey.GetValue("VoteUrl") == null || configKey.GetValue("VoteUrl").ToString() != versionInfo.VoteUrl) ||
                                  (configKey.GetValue("WebsiteUrl") == null || configKey.GetValue("WebsiteUrl").ToString() != versionInfo.WebsiteUrl) ||
                                  (configKey.GetValue("NewsUrl") == null || configKey.GetValue("NewsUrl").ToString() != versionInfo.NewsUrl) ||
                                  (configKey.GetValue("UpdaterUrl") == null || configKey.GetValue("UpdaterUrl").ToString() != versionInfo.UpdaterUrl) ||
                                  (configKey.GetValue("LauncherUrl") == null || configKey.GetValue("LauncherUrl").ToString() != versionInfo.LauncherUrl) ||
                                  (configKey.GetValue("UpdaterFilesRoot") == null || configKey.GetValue("UpdaterFilesRoot").ToString() != versionInfo.UpdaterFilesRoot);
            }

            if(!ignoreServers)
            {
                configKey.SetValue("Servers", versionInfo.Servers, RegistryValueKind.String);
            }
            
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

        public static Settings LoadSettings(string keyName)
        {
            try
            {
                var settingsKey = Registry.CurrentUser.OpenSubKey(@"Software\" + keyName, true);

                if (settingsKey == null)
                    return new Settings();
                var settings = (byte[])settingsKey.GetValue("AppSettings");

                var ms = new MemoryStream((byte[])settingsKey.GetValue("AppSettings"));
                var settingsObject = DeserializeFromStream<Settings>(ms);

                var settingsString = Encoding.UTF8.GetString(settings).ToLower();
                // TODO -- temporary fix because the delays didn't exist before and I don't want to use
                // a nullable int
                if(settingsString.IndexOf("windoweddelay") == -1)
                {
                    settingsObject.WindowedDelay = 500;
                }

                if (settingsString.IndexOf("logindelay") == -1)
                {
                    settingsObject.LoginDelay = 500;
                }

                return settingsObject;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static void SaveSettings(string keyName, Settings settings, string clientDirectory, bool isWin8OrHigher)
        {
            var existingKey = Registry.CurrentUser.GetValue(@"Software\" + keyName);

            if (existingKey == null)
                existingKey = Registry.CurrentUser.CreateSubKey(@"Software\" + keyName);

            ((RegistryKey)existingKey).SetValue("AppSettings", Serialize(settings), RegistryValueKind.Binary);

            //set the windowed flag in the lineage.cfg file
            if (isWin8OrHigher && settings.Windowed)
            {
                var compatRegKey = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows NT\CurrentVersion\AppCompatFlags\Layers");
                if (compatRegKey != null)
                    ((RegistryKey)compatRegKey).SetValue(Path.Combine(clientDirectory, settings.ClientBin),
                        "~ DWM8And16BitMitigation 16BITCOLOR WINXPSP3", RegistryValueKind.String);
            }

            var lincfgPath = Path.Combine(clientDirectory, "lineage.cfg");

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

            var musicFilePath = Path.Combine(clientDirectory, "music.cfg");

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

        public static bool IsWin8OrHigher(out string versionName)
        {
            var win8Version = new Version(6, 2, 9200, 0);
            versionName = WindowsVersion.Windows8;

            if (Environment.OSVersion.Version.Major >= 10)
                versionName = WindowsVersion.Windows10;

            return Environment.OSVersion.Platform == PlatformID.Win32NT &&
                   Environment.OSVersion.Version >= win8Version;
        } //end IsWin8OrHigher

        public static bool IsWin8OrHigher()
        {
            string versionName;
            return IsWin8OrHigher(out versionName);
        } //end IsWin8OrHigher 

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
