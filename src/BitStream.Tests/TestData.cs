namespace BitStream.Tests
{
	internal static class TestData
	{
		public const byte Data5 = 5; // 00000101 (MSB), 10100000 (LSB)
		public static readonly bool[] Data5Msb = {false, false, false, false, false, true, false, true};
		public static readonly bool[] Data5Lsb = {true, false, true, false, false, false, false, false};
		public const string Data5MsbString = "00000101";
		public const string Data5LsbString = "10100000";

		public const byte Data18 = 0x12; // 00010010 (MSB), 01001000 (LSB)
		public static readonly bool[] Data18Msb = {false, false, false, true, false, false, true, false};
		public static readonly bool[] Data18Lsb = {false, true, false, false, true, false, false, false};
		public const string Data18MsbString = "00010010";
		public const string Data18LsbString = "01001000";
	}
}