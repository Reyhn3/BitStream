using System;


namespace BitStreams
{
	/// <summary>
	///     Represents a 24-bit signed integer
	/// </summary>
	[Serializable]
	public struct Int24
	{
		private readonly byte _b0;
		private readonly byte _b1;
		private readonly byte _b2;
		private readonly Bit _sign;

		private Int24(int value)
		{
			_b0 = (byte)(value & 0xFF);
			_b1 = (byte)((value >> 8) & 0xFF);
			_b2 = (byte)((value >> 16) & 0x7F);
			_sign = (byte)((value >> 23) & 1);
		}

		public static implicit operator Int24(int value)
		{
			return new Int24(value);
		}

		public static implicit operator int(Int24 i)
		{
			var value = i._b0 | (i._b1 << 8) | (i._b2 << 16);
			return -(i._sign << 23) + value;
		}

		public Bit GetBit(int index)
		{
			return this >> index;
		}
	}
}