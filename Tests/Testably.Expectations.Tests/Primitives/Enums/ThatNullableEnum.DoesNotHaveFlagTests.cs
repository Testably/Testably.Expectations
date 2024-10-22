namespace Testably.Expectations.Tests.Primitives.Enums;

public sealed partial class ThatNullableEnum
{
	public sealed class DoesNotHaveFlagTests
	{
		[Theory]
		[InlineData(MyColors.Blue | MyColors.Green, MyColors.Green)]
		[InlineData(MyColors.Blue | MyColors.Yellow, MyColors.Blue)]
		public async Task WhenSubjectHasFlag_ShouldFail(MyColors? value, MyColors unexpected)
		{
			async Task Act()
				=> await Expect.That(value).DoesNotHaveFlag(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   does not have flag {unexpected},
				                   but found {value}
				                   at Expect.That(value).DoesNotHaveFlag(unexpected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectDoesNotHaveFlag_ShouldSucceed(MyColors unexpected)
		{
			MyColors? value = MyColors.Yellow | MyColors.Red & ~unexpected;

			async Task Act()
				=> await Expect.That(value).DoesNotHaveFlag(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenValuesAreTheSame_ShouldFail(MyColors unexpected)
		{
			MyColors? value = unexpected;

			async Task Act()
				=> await Expect.That(value).DoesNotHaveFlag(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   does not have flag {unexpected},
				                   but found {value}
				                   at Expect.That(value).DoesNotHaveFlag(unexpected)
				                   """);
		}
	}
}
