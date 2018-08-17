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
        public Uri NewsUrl { get; set; }
        public Uri VoteUrl { get; set; }
        public Uri UpdaterUrl { get; set; }
        public Uri VersionInfoUrl { get; set; }
        public Uri UpdaterFilesRoot { get; set; }
        public string PublicKey { get; set; }
        public string InstallDir { get; private set; }
    }
}
