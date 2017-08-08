using System;
using NUnit.Framework;


namespace BitStream.Tests
{
	public class BitStreamTests
	{
		[Test]
		public void SetBit_shall_set_the_bit_at_the_specified_position()
		{
			var buffer = new byte[1];
			var stream = new BitStreams.BitStream(buffer);
			stream.WriteBit(1);
			stream.WriteBit(0);
			stream.WriteBit(1);


			//stream.SetBit(1, 1);


			//var result = stream.ReadBit()
			throw new NotImplementedException();
		}
	}
}