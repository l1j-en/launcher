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
using System.Runtime.Serialization;

namespace Launcher.Models
{
    public enum ConfigType
    {
        Registry,
        FlatFile
    }

    [DataContract]
    public class LauncherConfig
    {
        public LauncherConfig() { }
        public LauncherConfig(string appPath)
        {
            this.InstallDir = appPath;
        }

        public string KeyName { get; private set; }
        public string InstallDir { get; set; }
        public ConfigType ConfigType { get; set; }

        [DataMember]
        public Uri LauncherUrl { get; set; }
        [DataMember]
        public Dictionary<string, Server> Servers { get; set; }
        [DataMember]
        public Uri WebsiteUrl { get; set; }
        [DataMember]
        public Uri NewsUrl { get; set; }
        [DataMember]
        public Uri VoteUrl { get; set; }
        [DataMember]
        public Uri UpdaterUrl { get; set; }
        [DataMember]
        public Uri VersionInfoUrl { get; set; }
        [DataMember]
        public Uri UpdaterFilesRoot { get; set; }
        [DataMember]
        public string PublicKey { get; set; }
    }
}
