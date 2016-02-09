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

namespace Launcher.Models
{
    [Serializable]
    public class Settings
    {
        public bool Windowed { get; set; }
        public bool Centred { get; set; }
        public bool Resize { get; set; }
        public bool DisableDark { get; set; }
        public bool EnableMobColours { get; set; }
        public bool CaptureMouse { get; set; }
        public bool BlurAc { get; set; }
        public bool BlurHpMp { get; set; }
        public bool BlurLevel { get; set; }
        public bool BlurHotKeys { get; set; }
        public bool BlurChat { get; set; }
        public string BlurSaveSetting { get; set; }

        public Resolution Resolution { get; set; }

        public string MusicType { get; set; }
        public string ClientDirectory { get; set; }
        public string ClientBin { get; set; }

        public bool BlurImage()
        {
            return BlurAc || BlurHpMp || BlurLevel || BlurHotKeys || BlurChat;
        }
    }
}
