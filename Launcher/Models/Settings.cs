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
    [Serializable]
    public class Settings
    {
        public Settings(int delay)
        {
            this.WindowedDelay = delay;
            this.LoginDelay = delay;
        }

        public Settings() { }

        public bool Windowed { get; set; }
        public bool Resize { get; set; }
        public bool DisableDark { get; set; }
        public bool EnableMobColours { get; set; }
        public bool DisableUnderwater { get; set; }

        public Resolution Resolution { get; set; }

        public string MusicType { get; set; }
        public string ClientBin { get; set; }

        public bool UseProxy { get; set; }

        public bool DisableServerUpdate { get; set; }
        public int WindowedDelay { get; set; }
        public int LoginDelay { get; set; }
    }
}
