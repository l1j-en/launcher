using System;

namespace Launcher
{
    [Serializable]
    public class Settings
    {
        public bool Windowed { get; set; }
        public bool Centred { get; set; }
        public bool Resize { get; set; }
        public bool AutoPlay { get; set; }
        public bool DisableDark { get; set; }

        public Resolution Resolution { get; set; }

        public string MusicType { get; set; }
        public string ClientDirectory { get; set; }
        public string ClientBin { get; set; }
    }
}
