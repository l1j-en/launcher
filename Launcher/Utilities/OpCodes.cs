namespace Launcher.Utilities
{
    public class OpCodes
    {
        public enum ClientOpCodes : byte
        {
            Attack = 5,
            LoginPacket = 57,
            ClientVersion = 127
        }

        public enum ServerOpCodes : byte
        {
            InitPacket = 161,
            AttackPacket = 35
        }
    }
}
