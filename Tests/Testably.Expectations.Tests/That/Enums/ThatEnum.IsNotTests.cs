namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatEnum
{
	public sealed class IsNotTests
	{
		[Theory]
		[InlineData(MyColors.Blue)]
		[InlineData(MyColors.Green)]
		public async Task WhenSubjectIsTheSame_ShouldFail(MyColors subject)
		{
			MyColors unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is not {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).Should().IsNot(unexpected)
				                   """);
		}

		[Theory]
		[InlineData(MyColors.Blue, MyColors.Green)]
		[InlineData(MyColors.Green, MyColors.Blue)]
		public async Task WhenSubjectIsDifferent_ShouldSucceed(MyColors subject, MyColors unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
