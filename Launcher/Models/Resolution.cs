using System;

namespace Launcher.Models
{
    [Serializable]
    public class Resolution
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public int Colour { get; set; }

        public override string ToString()
        {
            return string.Format("{0}x{1} {2}bit colour", this.Width, this.Height, this.Colour);
        }
    }
}
