namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatEnum
{
	public sealed class HasFlagTests
	{
		[Theory]
		[InlineData(MyColors.Blue | MyColors.Red, MyColors.Green)]
		[InlineData(MyColors.Green | MyColors.Yellow, MyColors.Blue)]
		public async Task WhenSubjectDoesNotHaveFlag_ShouldFail(MyColors subject, MyColors expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().HasFlag(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   has flag {expected},
				                   but found {subject}
				                   at Expect.That(subject).Should().HasFlag(expected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectHasFlag_ShouldSucceed(MyColors expected)
		{
			MyColors subject = MyColors.Yellow | MyColors.Red | expected;

			async Task Act()
				=> await Expect.That(subject).Should().HasFlag(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldSucceed(MyColors subject)
		{
			MyColors expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().HasFlag(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
