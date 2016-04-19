namespace Launcher.Utilities
{
    public class OpCodes
    {
        public enum ClientOpCodes : byte
        {
            KeepAlive = 4,
            LoginPacket = 57,
            ClientVersion = 127
        }

        public enum ServerOpCodes : byte
        {
            InitPacket = 161
        }
    }
}
