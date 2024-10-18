using AutoFixture.Xunit2;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Expectations.Numbers;

public sealed partial class ThatNumber
{
	public sealed class IsTests
	{
		[Theory]
		[AutoData]
		public async Task A_double_number_is_equal_to_the_same_floating_number(float expected)
		{
			double value = expected;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task A_floating_number_is_equal_to_the_same_nullable_value(float value)
		{
			float? expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task A_floating_number_is_equal_to_the_same_value(float value)
		{
			float expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[InlineData(1.0, 2.1)]
		[InlineData(5.8, -3.03)]
		public async Task A_floating_number_is_not_equal_to_a_different_value(float value,
			float expected)
		{
			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is {expected},
				                   but found {value}
				                   at Expect.That(value).Is(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task A_floating_number_is_not_equal_to_null(float value)
		{
			float? expected = null;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is <null>,
				                   but found {value}
				                   at Expect.That(value).Is(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task A_long_number_is_equal_to_the_same_integer_number(int expected)
		{
			long value = expected;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task An_integer_number_is_equal_to_the_same_nullable_value(int value)
		{
			int? expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task An_integer_number_is_equal_to_the_same_value(int value)
		{
			int expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(5, -3)]
		public async Task An_integer_number_is_not_equal_to_a_different_value(int value,
			int expected)
		{
			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is {expected},
				                   but found {value}
				                   at Expect.That(value).Is(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task An_integer_number_is_not_equal_to_null(int value)
		{
			int? expected = null;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is <null>,
				                   but found {value}
				                   at Expect.That(value).Is(expected)
				                   """);
		}
	}
}
