using System;
using System.Diagnostics;


namespace BitStreams
{
	[DebuggerDisplay("Bit {_value}")]
	[Serializable]
	public struct Bit
	{
		private readonly byte _value;

		private Bit(int value)
		{
//TODO: Is this really the expected operation? Shouldn't value > 0 be 1?
			_value = (byte)(value & 1);
		}

		public static implicit operator Bit(int value)
		{
			return new Bit(value);
		}

		public static implicit operator Bit(bool value)
		{
			return new Bit(value ? 1 : 0);
		}

		public static implicit operator int(Bit bit)
		{
			return bit._value;
		}

		public static implicit operator byte(Bit bit)
		{
			return bit._value;
		}

		public static implicit operator bool(Bit bit)
		{
			return bit._value == 1;
		}

		public static Bit operator &(Bit x, Bit y)
		{
			return x._value & y._value;
		}

		public static Bit operator |(Bit x, Bit y)
		{
			return x._value | y._value;
		}

		public static Bit operator ^(Bit x, Bit y)
		{
			return x._value ^ y._value;
		}

		public static Bit operator ~(Bit bit)
		{
			return ~bit._value & 1;
		}

		public static implicit operator string(Bit bit)
		{
			return bit._value.ToString();
		}

		public static implicit operator Bit(string bit)
		{
			if (bit == "0") return new Bit(0);
			if (bit == "1") return new Bit(1);

			throw new ArgumentOutOfRangeException(nameof(bit), bit, "The string representation must be exactly \"0\" or \"1\".");
		}

		public static implicit operator char(Bit bit)
		{
			return bit._value == 0 ? '0' : '1';
		}

		public static implicit operator Bit(char bit)
		{
			if (bit == '0') return new Bit(0);
			if (bit == '1') return new Bit(1);

			throw new ArgumentOutOfRangeException(nameof(bit), bit, "The char representation must be exactly '0' or '1'.");
		}

		public override string ToString()
		{
			return _value.ToString();
		}

		public int AsInt()
		{
			return _value;
		}

		public bool AsBool()
		{
			return _value == 1;
		}

		public char AsChar()
		{
			return _value == 0 ? '0' : '1';
		}

		public static Bit Zero = new Bit(0);
		public static Bit One = new Bit(1);
	}
}