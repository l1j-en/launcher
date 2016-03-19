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
        public Dictionary<string, string> FileChecksums { get; set; } 

        [DataMember]
        public Dictionary<string, List<PakFile>> PakFiles { get; set; }

        [DataMember]
        public string ServerName { get; set; }

        [DataMember]
        public string Servers { get; set; }

        [DataMember]
        public string VersionInfoUrl { get; set; }

        [DataMember]
        public string VoteUrl { get; set; }

        [DataMember]
        public string WebsiteUrl { get; set; }

        [DataMember]
        public string UpdaterUrl { get; set; }

        [DataMember]
        public string LauncherUrl { get; set; }

        [DataMember]
        public string UpdaterFilesRoot { get; set; }

        [DataMember]
        public string PublicKey { get; set; }
    }
}
