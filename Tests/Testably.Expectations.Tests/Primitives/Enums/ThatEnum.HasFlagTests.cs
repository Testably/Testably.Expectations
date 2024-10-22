namespace Testably.Expectations.Tests.Primitives.Enums;

public sealed partial class ThatEnum
{
	public sealed class HasFlagTests
	{
		[Theory]
		[InlineData(MyColors.Blue | MyColors.Red, MyColors.Green)]
		[InlineData(MyColors.Green | MyColors.Yellow, MyColors.Blue)]
		public async Task WhenSubjectDoesNotHaveFlag_ShouldFail(MyColors value, MyColors expected)
		{
			async Task Act()
				=> await Expect.That(value).HasFlag(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   has flag {expected},
				                   but found {value}
				                   at Expect.That(value).HasFlag(expected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectHasFlag_ShouldSucceed(MyColors expected)
		{
			MyColors value = MyColors.Yellow | MyColors.Red | expected;

			async Task Act()
				=> await Expect.That(value).HasFlag(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenValuesAreTheSame_ShouldSucceed(MyColors value)
		{
			MyColors expected = value;

			async Task Act()
				=> await Expect.That(value).HasFlag(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
