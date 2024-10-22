namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatBool
{
	public sealed class IsTests
	{
		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenSubjectIsDifferent_ShouldFail(bool subject)
		{
			bool expected = !subject;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {expected},
				                   but found {subject}
				                   at Expect.That(subject).Should().Is(expected)
				                   """);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenSubjectIsTheSame_ShouldSucceed(bool subject)
		{
			bool expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
