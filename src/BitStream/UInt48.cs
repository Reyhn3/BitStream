using System;


namespace BitStreams
{
	/// <summary>
	///     Represents a 48-bit unsigned integer
	/// </summary>
	[Serializable]
	public struct UInt48
	{
		private readonly byte _b0;
		private readonly byte _b1;
		private readonly byte _b2;
		private readonly byte _b3;
		private readonly byte _b4;
		private readonly byte _b5;

		private UInt48(ulong value)
		{
			_b0 = (byte)(value & 0xFF);
			_b1 = (byte)((value >> 8) & 0xFF);
			_b2 = (byte)((value >> 16) & 0xFF);
			_b3 = (byte)((value >> 24) & 0xFF);
			_b4 = (byte)((value >> 32) & 0xFF);
			_b5 = (byte)((value >> 40) & 0xFF);
		}

		public static implicit operator UInt48(ulong value)
		{
			return new UInt48(value);
		}

		public static implicit operator ulong(UInt48 i)
		{
			var value = i._b0 + ((ulong)i._b1 << 8) + ((ulong)i._b2 << 16) + ((ulong)i._b3 << 24) + ((ulong)i._b4 << 32) + ((ulong)i._b5 << 40);
			return value;
		}

		public Bit GetBit(int index)
		{
			return (byte)(this >> index);
		}
	}
}