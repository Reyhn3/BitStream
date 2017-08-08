using System;


namespace BitStreams
{
	/// <summary>
	///     Represents a 24-bit unsigned integer
	/// </summary>
	[Serializable]
	public struct UInt24
	{
		private readonly byte _b0;
		private readonly byte _b1;
		private readonly byte _b2;

		private UInt24(uint value)
		{
			_b0 = (byte)(value & 0xFF);
			_b1 = (byte)((value >> 8) & 0xFF);
			_b2 = (byte)((value >> 16) & 0xFF);
		}

		public static implicit operator UInt24(uint value)
		{
			return new UInt24(value);
		}

		public static implicit operator uint(UInt24 i)
		{
			return (uint)(i._b0 | (i._b1 << 8) | (i._b2 << 16));
		}

		public Bit GetBit(int index)
		{
			return (byte)(this >> index);
		}
	}
}