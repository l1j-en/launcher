using System;
using System.Collections.Generic;

namespace Launcher.Models
{
    public class LauncherConfig
    {
        public LauncherConfig(string keyName, string appPath)
        {
            this.KeyName = keyName;
            this.InstallDir = appPath;
        }

        public string KeyName { get; private set; }
        public Dictionary<string, Server> Servers { get; set; }
        public Uri WebsiteUrl { get; set; }
        public Uri VoteUrl { get; set; }
        public Uri UpdaterUrl { get; set; }
        public Uri VersionInfoUrl { get; set; }
        public Uri UpdaterFilesRoot { get; set; }
        public string PublicKey { get; set; }
        public string InstallDir { get; private set; }
    }
}
