using System;
using System.Collections.Generic;
using System.Linq;
using BitStreams;
using NUnit.Framework;
using Shouldly;


namespace BitStream.Tests
{
	public class BitStreamExtensionsTests
	{
		[TestCase(true, TestData.Data18LsbString + TestData.Data5LsbString)]
		[TestCase(false, TestData.Data5LsbString + TestData.Data18LsbString)]
		public void AsBitString_shall_return_a_string_representation_of_the_bits(bool msb, string expected)
		{
			var buffer = new byte[2];
			var stream = new BitStreams.BitStream(buffer, msb);

			stream.WriteByte(TestData.Data5);
			stream.WriteByte(TestData.Data18);

			var result = stream.AsBitString();

			Console.WriteLine(result);
			result.ShouldBe(expected);
		}

		[Test]
		public void ReadBit_shall_read_the_bit_at_the_specified_position()
		{
			var buffer = new byte[2];
			var stream = new BitStreams.BitStream(buffer, true);

			stream.WriteByte(TestData.Data5);
			stream.WriteByte(TestData.Data18);

			var results = new List<Bit>(buffer.Length * 8);

			for (var bytePos = 0; bytePos < buffer.Length; bytePos++)
			{
				for (var bitPos = 0; bitPos < 8; bitPos++)
				{
					var result = stream.ReadBit(bytePos, bitPos);
					results.Add(result);

					Console.WriteLine("[Byte {0}, Bit {1}]\t{2}", bytePos, bitPos, result);
				}

				Console.WriteLine();
			}

			results.Select(b => b.AsBool()).ShouldBe(TestData.Data5Msb.Concat(TestData.Data18Msb));
		}

		[Test]
		public void ReadBit_shall_read_the_bit_at_the_specified_bit_position()
		{
			var buffer = new byte[2];
			var stream = new BitStreams.BitStream(buffer, true);

			stream.WriteByte(TestData.Data5);
			stream.WriteByte(TestData.Data18);

			var results = new List<Bit>(buffer.Length * 8);

			for (var bitPos = 0; bitPos < 8 * buffer.Length; bitPos++)
			{
				var result = stream.ReadBit(bitPos);
				results.Add(result);

				if (bitPos > 0 && bitPos % 8 == 0)
					Console.WriteLine();

				Console.WriteLine("[Byte {0}, Bit {1,2}]\t{2}", bitPos / 8, bitPos, result);
			}

			results.Select(b => b.AsBool()).ShouldBe(TestData.Data5Msb.Concat(TestData.Data18Msb));
		}

		[Test]
		public void SetBit_shall_set_the_bit_at_the_specified_position()
		{
			var buffer = new byte[1];
			var stream = new BitStreams.BitStream(buffer);
			stream.WriteBit(1);
			stream.WriteBit(0);
			stream.WriteBit(1);


			// Set bit 2 to 1.
			stream.SetBit(0, 1, true);


			var result = stream.AsBitString();
			Console.WriteLine(result);
			result.ShouldBe("00000111");
		}

		[Test]
		public void SetBit_shall_set_the_bit_at_the_specified_bit_position()
		{
			var buffer = new byte[2];
			var stream = new BitStreams.BitStream(buffer);

			stream.WriteByte(TestData.Data5);
			stream.WriteByte(TestData.Data18);


			// Set bit 15 to 1.
			stream.SetBit(15, true);


			var result = stream.AsBitString();
			Console.WriteLine(result);
			result.ShouldBe(TestData.Data5MsbString + "10010010");
		}
	}
}