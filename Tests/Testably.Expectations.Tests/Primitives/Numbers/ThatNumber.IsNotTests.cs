namespace Testably.Expectations.Tests.Primitives.Numbers;

public sealed partial class ThatNumber
{
	public sealed class IsNotTests
	{
		[Theory]
		[AutoData]
		public async Task WhenValuesAreTheSame_ShouldFail(int value)
		{
			int expected = value;

			async Task Act()
				=> await Expect.That(value).IsNot(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is not {expected},
				                   but found {value}
				                   at Expect.That(value).IsNot(expected)
				                   """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(5, -3)]
		public async Task WhenValuesAreDifferent_ShouldSucceed(int value, int expected)
		{
			async Task Act()
				=> await Expect.That(value).IsNot(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
