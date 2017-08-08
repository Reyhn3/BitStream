using System;
using System.Text;


namespace BitStreams
{
	public static class BitStreamExtensions
	{
		public static string AsBitString(this BitStream stream)
		{
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			stream.Seek(0, 0);
			var sb = new StringBuilder();
			do
			{
				sb.Append((char)stream.ReadBit());
			} while (stream.Position < stream.Length && stream.BitPosition < 8);
			return sb.ToString();
		}

		public static Bit ReadBit(this BitStream stream, long offset, int bit)
		{
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			stream.Seek(offset, bit);
			return stream.ReadBit();
		}
	}
}