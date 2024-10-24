namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatEnum
{
	public sealed class DoesNotHaveFlagTests
	{
		[Theory]
		[InlineData(MyColors.Blue | MyColors.Green, MyColors.Green)]
		[InlineData(MyColors.Blue | MyColors.Yellow, MyColors.Blue)]
		public async Task WhenSubjectHasFlag_ShouldFail(MyColors subject, MyColors unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHaveFlag(unexpected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   does not have flag {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).Should().DoesNotHaveFlag(unexpected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectDoesNotHaveFlag_ShouldSucceed(MyColors unexpected)
		{
			MyColors subject = MyColors.Yellow | MyColors.Red & ~unexpected;

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHaveFlag(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldFail(MyColors subject)
		{
			MyColors unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotHaveFlag(unexpected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   does not have flag {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).Should().DoesNotHaveFlag(unexpected)
				                   """);
		}
	}
}
