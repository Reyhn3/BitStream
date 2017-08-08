using System;
using BitStreams;
using NUnit.Framework;
using Shouldly;


namespace BitStream.Tests
{
	public class BitTests
	{
		[Test]
		public void Static_property_Zero_should_have_value_zero()
		{
			var result = Bit.Zero;
			result.AsInt().ShouldBe(0);
		}

		[Test]
		public void Static_property_One_should_have_value_one()
		{
			var result = Bit.One;
			result.AsInt().ShouldBe(1);
		}

		[Test]
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

		[TestCase("0", 0)]
		[TestCase("1", 1)]
		public void Implicit_operator_Bit_from_String_shall_return_a_Bit_with_the_specified_value(string value, int expected)
		{
			Bit bit = value;
			bit.AsInt().ShouldBe(expected);
		}

		[Test]
		public void Implicit_operator_Bit_from_String_shall_throw_exception_if_the_string_is_not_a_bit_value()
		{
			Assert.Throws<ArgumentOutOfRangeException>(
				() =>
					{
						Bit bit = "2";
					});
		}

		[TestCase(0, "0")]
		[TestCase(1, "1")]
		public void ToString_shall_return_the_string_representation_of_the_value(int value, string expected)
		{
			Bit bit = value;
			bit.ToString().ShouldBe(expected);
		}

		[TestCase(0, '0')]
		[TestCase(1, '1')]
		public void Implicit_operator_Char_shall_return_the_char_representation_of_the_value(int value, char expected)
		{
			Bit bit = value;
			char result = bit;
			result.ShouldBe(expected);
		}

		[TestCase('0', 0)]
		[TestCase('1', 1)]
		public void Implicit_operator_Bit_from_Char_shall_return_a_Bit_with_the_specified_value(char value, int expected)
		{
			Bit bit = value;
			bit.AsInt().ShouldBe(expected);
		}

		[Test]
		public void Implicit_operator_Bit_from_Char_shall_throw_exception_if_the_char_is_not_a_bit_value()
		{
			Assert.Throws<ArgumentOutOfRangeException>(
				() =>
					{
						Bit bit = 'a';
					});
		}

		[TestCase(0, '0')]
		[TestCase(1, '1')]
		public void AsChar_shall_return_the_char_representation_of_the_value(int value, char expected)
		{
			Bit bit = value;
			bit.AsChar().ShouldBe(expected);
		}
	}
}