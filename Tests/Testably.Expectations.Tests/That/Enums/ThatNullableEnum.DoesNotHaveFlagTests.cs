namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatNullableEnum
{
	public sealed class DoesNotHaveFlagTests
	{
		[Theory]
		[InlineData(MyColors.Blue | MyColors.Green, MyColors.Green)]
		[InlineData(MyColors.Blue | MyColors.Yellow, MyColors.Blue)]
		public async Task WhenSubjectHasFlag_ShouldFail(MyColors? subject, MyColors unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).DoesNotHaveFlag(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   does not have flag {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).DoesNotHaveFlag(unexpected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectDoesNotHaveFlag_ShouldSucceed(MyColors unexpected)
		{
			MyColors? subject = MyColors.Yellow | MyColors.Red & ~unexpected;

			async Task Act()
				=> await Expect.That(subject).DoesNotHaveFlag(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldFail(MyColors unexpected)
		{
			MyColors? subject = unexpected;

			async Task Act()
				=> await Expect.That(subject).DoesNotHaveFlag(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   does not have flag {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).DoesNotHaveFlag(unexpected)
				                   """);
		}
	}
}
