using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Numbers;

public sealed partial class ThatNumber
{
	public sealed class IsNaNTests
	{
		[Fact]
		public async Task NaN_is_equal_to_NaN_when_its_a_double()
		{
			double value = double.NaN;

			async Task Act() => await Expect.That(value).IsNaN();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task NaN_is_equal_to_NaN_when_its_a_float()
		{
			float value = float.NaN;

			async Task Act()
				=> await Expect.That(value).IsNaN();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Should_chain_when_asserting_NaN_as_double()
		{
			double value = double.NaN;

			async Task Act()
				=> await Expect.That(value).IsNaN()
					.And.Is(value);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Should_chain_when_asserting_NaN_as_float()
		{
			float value = float.NaN;

			async Task Act() => await Expect.That(value).IsNaN()
				.And.Is(value);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[InlineData(-1d)]
		[InlineData(0d)]
		[InlineData(1d)]
		[InlineData(double.MinValue)]
		[InlineData(double.MaxValue)]
		[InlineData(double.Epsilon)]
		[InlineData(double.NegativeInfinity)]
		[InlineData(double.PositiveInfinity)]
		public async Task Should_fail_when_asserting_normal_double_value_to_be_NaN(double value)
		{
			async Task Act()
				=> await Expect.That(value).IsNaN();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is NaN,
				                   but found {value}
				                   at Expect.That(value).IsNaN()
				                   """);
		}

		[Theory]
		[InlineData(-1f)]
		[InlineData(0f)]
		[InlineData(1f)]
		[InlineData(float.MinValue)]
		[InlineData(float.MaxValue)]
		[InlineData(float.Epsilon)]
		[InlineData(float.NegativeInfinity)]
		[InlineData(float.PositiveInfinity)]
		public async Task Should_fail_when_asserting_normal_float_value_to_be_NaN(float value)
		{
			async Task Act()
				=> await Expect.That(value).IsNaN();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is NaN,
				                   but found {value}
				                   at Expect.That(value).IsNaN()
				                   """);
		}
	}
}
