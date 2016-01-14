using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using Launcher.Models;
using Launcher.Properties;

namespace Launcher.Utilities
{
    public static class PakTools
    {
        private static readonly byte[] Map1;
        private static readonly byte[] Map2;
        private static readonly byte[] Map5;
        private static readonly byte[] Map4;
        private static readonly byte[] Map3;

        static PakTools()
		{
            PakTools.Map1 = Resources.Map1;
            PakTools.Map2 = Resources.Map2;
            PakTools.Map5 = Resources.Map5;
            PakTools.Map4 = Resources.Map4;
            PakTools.Map3 = Resources.Map3;
		} //end constructor

		private static byte[] Coder(byte[] src, int index, bool isEncode)
		{
            var numArray = new byte[(int)src.Length - index];

			if ((int)numArray.Length >= 8)
			{
                var numArray1 = new byte[8];
                var length = (int)numArray.Length / 8;
                var num = 0;
				while (length > 0)
				{
					Array.Copy(src, num + index, numArray1, 0, 8);
					if (!isEncode)
						Array.Copy(PakTools.sub_403220(numArray1), 0, numArray, num, 8);
					else
						Array.Copy(PakTools.sub_403160(numArray1), 0, numArray, num, 8);

					num = num + 8;

					length--;
				}
			}

            var length1 = (int)numArray.Length % 8;

			if (length1 > 0)
			{
                var num1 = (int)numArray.Length - length1;
				Array.Copy(src, num1 + index, numArray, num1, length1);
			}

			return numArray;
		} //end Coder

		public static byte[] Decode(byte[] src, int index)
		{
			return PakTools.Coder(src, index, false);
		} //end Decode

		public static PakTools.IndexRecord Decode_Index_FirstRecord(byte[] src)
		{
            var numArray = new byte[36];
			Array.Copy(src, numArray, (int)numArray.Length);
			return new PakTools.IndexRecord(PakTools.Decode(numArray, 4), 0);
		} //end Decode_Index_FirstRecord

		public static byte[] Encode(byte[] src, int index)
		{
			return PakTools.Coder(src, index, true);
		} //end Encode

		private static byte[] sub_403160(byte[] src)
		{
            var numArray = new byte[17][];
			numArray[0] = PakTools.sub_4032E0(src, PakTools.Map1);
            var num = 0;
            var num1 = 0;

			while (num1 <= 15)
			{
				numArray[num + 1] = PakTools.sub_403340(num1, numArray[num]);
				num1++;
				num++;
			}

            var numArray1 = new byte[] { numArray[16][4], numArray[16][5], numArray[16][6], numArray[16][7], numArray[16][0], numArray[16][1], numArray[16][2], numArray[16][3] };
			return PakTools.sub_4032E0(numArray1, PakTools.Map2);
		} //end sub_403160

		private static byte[] sub_403220(byte[] src)
		{
            var numArray = new byte[17][];
			numArray[0] = PakTools.sub_4032E0(src, PakTools.Map1);
            var num = 0;
            var num1 = 15;

			while (num1 >= 0)
			{
				numArray[num + 1] = PakTools.sub_403340(num1, numArray[num]);
				num1--;
				num++;
			}

            var numArray1 = new byte[] { numArray[16][4], numArray[16][5], numArray[16][6], numArray[16][7], numArray[16][0], numArray[16][1], numArray[16][2], numArray[16][3] };
			return PakTools.sub_4032E0(numArray1, PakTools.Map2);
		} //end sub_403220

		private static byte[] sub_4032E0(byte[] a1, byte[] a2)
		{
            var numArray = new byte[8];
            var num = 0;
            var num1 = 0;
			while (num1 < 16)
			{
				var num2 = a1[num];
                var num3 = num2 >> 4;
                var num4 = num2 % 16;
                for (var i = 0; i < 8; i++)
				{
                    var num5 = num1 * 128 + i;
					numArray[i] = (byte)(numArray[i] | (byte)(a2[num5 + num3 * 8] | a2[num5 + (16 + num4) * 8]));
				}
				num1 = num1 + 2;
				num++;
			}
			return numArray;
		} //end sub_4032E0

		private static byte[] sub_403340(int a1, byte[] a2)
		{
			var numArray = new byte[4];
			Array.Copy(a2, 4, numArray, 0, 4);
			var numArray1 = PakTools.sub_4033B0(numArray, a1);
			var numArray2 = new byte[] { a2[4], a2[5], a2[6], a2[7], (byte)(numArray1[0] ^ a2[0]), (byte)(numArray1[1] ^ a2[1]), (byte)(numArray1[2] ^ a2[2]), (byte)(numArray1[3] ^ a2[3]) };
			return numArray2;
		} //end sub_403340

		private static byte[] sub_4033B0(byte[] a1, int a2)
		{
			var numArray = PakTools.sub_403450(a1);
			var num = a2 * 6;
			var map5 = new byte[] { (byte)(numArray[0] ^ PakTools.Map5[num]), (byte)(numArray[1] ^ PakTools.Map5[num + 1]), (byte)(numArray[2] ^ PakTools.Map5[num + 2]), (byte)(numArray[3] ^ PakTools.Map5[num + 3]), (byte)(numArray[4] ^ PakTools.Map5[num + 4]), (byte)(numArray[5] ^ PakTools.Map5[num + 5]) };
			return PakTools.sub_4035A0(PakTools.sub_403520(map5));
		} //end sub_4033B0

		private static byte[] sub_403450(byte[] a1)
		{
			var numArray = new byte[] { (byte)(a1[3] << 7 | (a1[0] & 249 | a1[0] >> 2 & 6) >> 1), (byte)((a1[0] & 1 | a1[0] << 2) << 3 | (a1[1] >> 2 | a1[1] & 135) >> 3), (byte)(a1[2] >> 7 | (a1[1] & 31 | (a1[1] & 248) << 2) << 1), (byte)(a1[1] << 7 | (a1[2] & 249 | a1[2] >> 2 & 6) >> 1), (byte)((a1[2] & 1 | a1[2] << 2) << 3 | (a1[3] >> 2 | a1[3] & 135) >> 3), (byte)(a1[0] >> 7 | (a1[3] & 31 | (a1[3] & 248) << 2) << 1) };
			return numArray;
		} //end sub_403450

		private static byte[] sub_403520(byte[] a1)
		{
			var map4 = new byte[] { PakTools.Map4[a1[0] * 16 | a1[1] >> 4], PakTools.Map4[4096 + (a1[2] | a1[1] % 16 * 256)], PakTools.Map4[8192 + (a1[3] * 16 | a1[4] >> 4)], PakTools.Map4[12288 + (a1[5] | a1[4] % 16 * 256)] };
			return map4;
		} //end sub_403520

		private static byte[] sub_4035A0(byte[] a1)
		{
			var map3 = new byte[4];
			for (var i = 0; i < 4; i++)
			{
				var num = (i * 256 + a1[i]) * 4;
				map3[0] = (byte)(map3[0] | PakTools.Map3[num]);
				map3[1] = (byte)(map3[1] | PakTools.Map3[num + 1]);
				map3[2] = (byte)(map3[2] | PakTools.Map3[num + 2]);
				map3[3] = (byte)(map3[3] | PakTools.Map3[num + 3]);
			}
			return map3;
		} //end sub_4035A0

		public struct IndexRecord
		{
			public int Offset;

			public string FileName;

			public int FileSize;

			public IndexRecord(byte[] data, int index)
			{
				this.Offset = BitConverter.ToInt32(data, index);
				this.FileName = Encoding.Default.GetString(data, index + 4, 20).TrimEnd(new char[1]);
				this.FileSize = BitConverter.ToInt32(data, index + 24);
			}

			public IndexRecord(string filename, int size, int offset)
			{
				this.Offset = offset;
				this.FileName = filename;
				this.FileSize = size;
			}
		} //end struct

        public static byte[] LoadIndexData(string indexFile)
        {
            var numArray = File.ReadAllBytes(indexFile);
            var length = ((int)numArray.Length - 4) / 28;

            if ((int)numArray.Length < 32 || ((int)numArray.Length - 4) % 28 != 0)
                return null;

            if (BitConverter.ToUInt32(numArray, 0) != length)
                return null;

            if (!Regex.IsMatch(Encoding.Default.GetString(numArray, 8, 20), "^([a-zA-Z0-9_\\-\\.']+)", RegexOptions.IgnoreCase))
            {
                if (!Regex.IsMatch(PakTools.Decode_Index_FirstRecord(numArray).FileName, "^([a-zA-Z0-9_\\-\\.']+)", RegexOptions.IgnoreCase))
                    return null;

                numArray = PakTools.Decode(numArray, 4);
            }

            return numArray;
        } //end LoadIndexData

        public static PakTools.IndexRecord[] CreateIndexRecords(byte[] indexData, bool isPackFileProtected)
        {
            if (indexData == null)
                return null;

            var num = (isPackFileProtected ? 0 : 4);
            var length = ((int)indexData.Length - num) / 28;
            var indexRecord = new PakTools.IndexRecord[length];

            for (var i = 0; i < length; i++)
                indexRecord[i] = new PakTools.IndexRecord(indexData, num + i * 28);

            return indexRecord;
        } //end CreateIndexRecords

        public static IndexRecord[] RebuildPak(string pakFileName, List<PakFile> files, bool isPackFileProtected)
        {
            var pakIndex = PakTools.CreateIndexRecords(PakTools.LoadIndexData(pakFileName.Replace(".pak", ".idx")), true);

            var fileStream = File.OpenWrite(pakFileName);
            foreach (var pakFile in files)
            {
                var bytes = Encoding.Default.GetBytes(pakFile.Content);
                bytes = PakTools.Encode(bytes, 0);

                var num = pakFile.Id - 1;
                pakIndex[num].Offset = (int)fileStream.Seek((long)0, SeekOrigin.End);
                fileStream.Write(bytes, 0, (int)bytes.Length);
            }

            fileStream.Close();

            return pakIndex;
        } //end RebuildPak

        public static void RebuildIndex(string indexFile, IndexRecord[] indexRecords, bool isPackFileProtected)
        {
            var numArray = new byte[4 + indexRecords.Length * 28];
            Array.Copy(BitConverter.GetBytes(indexRecords.Length), 0, numArray, 0, 4);

            for (var i = 0; i < indexRecords.Length; i++)
            {
                var num = 4 + i * 28;
                Array.Copy(BitConverter.GetBytes(indexRecords[i].Offset), 0, numArray, num, 4);
                Encoding.Default.GetBytes(indexRecords[i].FileName, 0, indexRecords[i].FileName.Length, numArray, num + 4);
                Array.Copy(BitConverter.GetBytes(indexRecords[i].FileSize), 0, numArray, num + 24, 4);
            }

            if (isPackFileProtected)
                Array.Copy(PakTools.Encode(numArray, 4), 0, numArray, 4, (int)numArray.Length - 4);

            File.WriteAllBytes(indexFile, numArray);
        } //end RebuildIndex
    } //end class
} //end namespace
