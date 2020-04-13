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
    [DataContract]
    public class VersionInfo
    {
        [DataMember]
        public string Version { get; set; }

        [DataMember]
        public bool Required { get; set; }

        [DataMember]
        public string VersionDetails { get; set; }

        [DataMember]
        public long LastUpdated { get; set; }

        [DataMember]
        public Dictionary<string, FileData> Files { get; set; } 

        [DataMember]
        public string ServerName { get; set; }

        [DataMember]
        public Dictionary<string, Server> Servers { get; set; }

        [DataMember]
        public string VersionInfoUrl { get; set; }

        [DataMember]
        public string VoteUrl { get; set; }

        [DataMember]
        public string WebsiteUrl { get; set; }

        [DataMember]
        public string NewsUrl { get; set; }

        [DataMember]
        public string UpdaterUrl { get; set; }

        [DataMember]
        public string LauncherUrl { get; set; }

        [DataMember]
        public string UpdaterFilesRoot { get; set; }

        public static implicit operator LauncherConfig(VersionInfo versionInfo)
        {
            return new LauncherConfig
            {
                LauncherUrl = string.IsNullOrEmpty(versionInfo.LauncherUrl) ? null : new Uri(versionInfo.LauncherUrl),
                Servers = versionInfo.Servers,
                NewsUrl = string.IsNullOrEmpty(versionInfo.NewsUrl) ? null : new Uri(versionInfo.NewsUrl),
                //PublicKey = versionInfo.PublicKey,
                UpdaterFilesRoot = string.IsNullOrEmpty(versionInfo.UpdaterFilesRoot) ? null : new Uri(versionInfo.UpdaterFilesRoot),
                UpdaterUrl = string.IsNullOrEmpty(versionInfo.UpdaterUrl) ? null : new Uri(versionInfo.UpdaterUrl),
                VersionInfoUrl = string.IsNullOrEmpty(versionInfo.VersionInfoUrl) ? null : new Uri(versionInfo.VersionInfoUrl),
                VoteUrl = string.IsNullOrEmpty(versionInfo.VoteUrl) ? null : new Uri(versionInfo.VoteUrl),
                WebsiteUrl = string.IsNullOrEmpty(versionInfo.WebsiteUrl) ? null : new Uri(versionInfo.WebsiteUrl)
            };
        }
    }
}
