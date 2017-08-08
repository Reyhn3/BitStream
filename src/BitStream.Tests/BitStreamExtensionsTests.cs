using System;
using BitStreams;
using NUnit.Framework;
using Shouldly;


namespace BitStream.Tests
{
	public class BitStreamExtensionsTests
	{
		private const byte Data5 = 5; // 00000101 (MSB), 10100000 (LSB)
		private const byte Data18 = 0x12; // 0010010 (MSB), 0100100 (LSB)

		[TestCase(true, "0000010100010010")]
		[TestCase(false, "1010000001001000")]
		public void AsBitString_shall_return_a_string_representation_of_the_bits(bool msb, string expected)
		{
			var buffer = new byte[2];
			var stream = new BitStreams.BitStream(buffer, msb);

			stream.WriteByte(Data5);
			stream.WriteByte(Data18);

			var result = stream.AsBitString();

			Console.WriteLine(result);
			result.ShouldBe(expected);
		}

		[Test]
		public void ReadBit_shall_read_the_bit_at_the_specified_position()
		{
			var buffer = new byte[2];
			var stream = new BitStreams.BitStream(buffer, true);

			stream.WriteByte(Data5);
			stream.WriteByte(Data18);

			// Read the second byte, third bit.
			var result = stream.ReadBit(1, 2);

//TODO: This should work.
			result.AsInt().ShouldBe(1);
		}
	}
}