using System;

namespace Launcher.Utilities
{
    public static class Encryption
    {
        /// <summary>
        /// Decrypt packet
        /// </summary>
        /// <param name="packet">Packet to be decrypted</param>
        /// <returns>Decrypted packet</returns>
        public static byte[] Decrypt(byte[] packet, byte[] key)
        {
            var decryptedPacket = new byte[packet.Length - 2];
            Array.Copy(packet, 2, decryptedPacket, 0, decryptedPacket.Length);

            var b3 = decryptedPacket[3];
            decryptedPacket[3] ^= key[2];

            var b2 = decryptedPacket[2];
            decryptedPacket[2] ^= (byte)(b3 ^ key[3]);

            var b1 = decryptedPacket[1];
            decryptedPacket[1] ^= (byte)(b2 ^ key[4]);

            var k = (byte)(decryptedPacket[0] ^ b1 ^ key[5]);
            decryptedPacket[0] = (byte)(k ^ key[0]);

            for (var i = 1; i < decryptedPacket.Length; i++)
            {
                var t = decryptedPacket[i];
                decryptedPacket[i] ^= (byte)(key[i & 7] ^ k);
                k = t;
            }

            return decryptedPacket;
        }

        /// <summary>
        /// Encrypt packet
        /// </summary>
        /// <param name="packet">Packet to be decrypted</param>
        /// <returns>Encrypted packet</returns>
        public static byte[] Encrypt(byte[] packet, byte[] key)
        {
            var encryptedPacket = new byte[packet.Length + 2];
            var packetSize = new byte[2];
            packetSize[0] = (byte)(encryptedPacket.Length & 0xFF);
            packetSize[1] = (byte)((encryptedPacket.Length >> 8) & 0xFF);
            packetSize.CopyTo(encryptedPacket, 0);
            packet.CopyTo(encryptedPacket, 2);

            encryptedPacket[2] ^= key[0];

            for (var i = 3; i < encryptedPacket.Length; i++)
                encryptedPacket[i] ^= (byte)(key[(i - 2) & 7] ^ encryptedPacket[i - 1]);

            encryptedPacket[5] ^= key[2];
            encryptedPacket[4] ^= (byte)(key[3] ^ encryptedPacket[5]);
            encryptedPacket[3] ^= (byte)(key[4] ^ encryptedPacket[4]);
            encryptedPacket[2] ^= (byte)(key[5] ^ encryptedPacket[3]);

            return encryptedPacket;
        }

        /// <summary>
        /// Initialize encryption keys
        /// </summary>
        /// <param name="seed">Seed to compute the keys</param>
        /// <returns></returns>
        public static byte[] InitKeys(uint seed)
        {
            var initKey = new byte[8];
            const uint key = 0x930FD7E2;
            var bigKey = new uint[2];
            bigKey[0] = seed;
            bigKey[1] = key;

            var rotrParam = bigKey[0] ^ 0x9C30D539;
            bigKey[0] = (rotrParam >> 13) | (rotrParam << 19); //rotate right by 13 bits
            bigKey[1] = bigKey[0] ^ bigKey[1] ^ 0x7C72E993;

            initKey[0] = (byte)((bigKey[0]) & 0xFF);
            initKey[1] = (byte)((bigKey[0] >> 8) & 0xFF);
            initKey[2] = (byte)((bigKey[0] >> 16) & 0xFF);
            initKey[3] = (byte)((bigKey[0] >> 24) & 0xFF);
            initKey[4] = (byte)((bigKey[1]) & 0xFF);
            initKey[5] = (byte)((bigKey[1] >> 8) & 0xFF);
            initKey[6] = (byte)((bigKey[1] >> 16) & 0xFF);
            initKey[7] = (byte)((bigKey[1] >> 24) & 0xFF);

            return initKey;
        }

        /// <summary>
        /// Update encryption key
        /// </summary>
        /// <param name="seed">Byte[4] array to compute the new key</param>
        /// <returns></returns>
        public static byte[] UpdateKey(byte[] key, byte[] seed)
        {
            key[0] ^= seed[0];
            key[1] ^= seed[1];
            key[2] ^= seed[2];
            key[3] ^= seed[3];

            var temp = ((uint)key[4]) |
                        (uint)key[5] << 8 |
                        (uint)key[6] << 16 |
                        (uint)key[7] << 24;

            temp += 0x287EFFC3;

            key[4] = (byte)(temp & 0xFF);
            key[5] = (byte)(temp >> 8 & 0xFF);
            key[6] = (byte)(temp >> 16 & 0xFF);
            key[7] = (byte)(temp >> 24 & 0xFF);

            return key;
        }
    }
}
