using System;
using System.Linq;
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

			if (stream.IsMostSignificantBitFirst)
			{
				stream.Seek(stream.Length - 1, 0);
				do
				{
					var readByte = stream.ReadByte();
					sb.Append(Convert.ToString(readByte, 2).PadLeft(8, '0').Reverse().ToArray());

					if (stream.Position == 1)
						break;

					stream.Seek(stream.Position - 2, 0);
				} while (stream.Position >= 0 && stream.BitPosition < 8);
			}
			else
			{
				do
				{
					var readBit = (char)stream.ReadBit();
					sb.Append(readBit);
				} while (stream.Position < stream.Length && stream.BitPosition < 8);
			}

			return sb.ToString();
		}

		public static Bit ReadBit(this BitStream stream, long bytePosition, int bitPosition)
		{
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			stream.Seek(bytePosition, bitPosition);
			return stream.ReadBit();
		}

		public static Bit ReadBit(this BitStream stream, long bitPosition)
		{
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			stream.Seek(bitPosition / 8, (int)bitPosition % 8);
			return stream.ReadBit();
		}

		public static void SetBit(this BitStream stream, long bytePosition, int bitPosition, Bit value)
		{
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			stream.Seek(bytePosition, bitPosition);
			stream.WriteBit(value);
		}

		public static void SetBit(this BitStream stream, long bitPosition, Bit value)
		{
			if (stream == null)
				throw new ArgumentNullException(nameof(stream));

			stream.Seek(bitPosition / 8, (int)bitPosition % 8);
			stream.WriteBit(value);
		}
	}
}