using BitStreams;
using NUnit.Framework;
using Shouldly;


namespace BitStream.Tests
{
	public class BitTests
	{
		public void Implicit_operator_Int32_shall_set_Bit_to_zero_if_value_is_zero()
		{
			Bit result = 0;
			result.AsInt().ShouldBe(0);
		}

		[Test]
		public void Implicit_operator_Int32_shall_set_Bit_to_one_if_value_is_one()
		{
			Bit result = 1;
			result.AsInt().ShouldBe(1);
		}

		[TestCase(2, 0)]
		[TestCase(3, 1)]
		public void Implicit_operator_Int32_shall_set_Bit_to_the_value_of_the_lowest_bit_of_the_integer_value(int value, int expected)
		{
			Bit result = value;
			result.AsInt().ShouldBe(expected);
		}

		[TestCase(0, "0")]
		[TestCase(1, "1")]
		public void Implicit_operator_String_shall_return_the_string_representation_of_the_value(int value, string expected)
		{
			Bit bit = value;
			string result = bit;
			result.ShouldBe(expected);
		}
	}
}