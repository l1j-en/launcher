using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Launcher.Utilities
{
    public class PacketWriter : BinaryWriter
    {
        private readonly MemoryStream _ms;

        public PacketWriter()
            : base()
        {
            _ms = new MemoryStream();
            OutStream = _ms;
        }

        public byte[] GetBytes()
        {
            Close();
            var data = _ms.ToArray();
            return data;
        }
    }

    public class PacketReader : BinaryReader
    {
        public PacketReader(byte[] data)
            : base(new MemoryStream(data))
        {

        }

        public string ReadNullTerminatedString()
        {
            var _string = new List<byte>();

            while (PeekChar() != 0)
            {
                _string.Add(ReadByte());
            }

            return Encoding.UTF8.GetString(_string.ToArray());
        }
    }
}
