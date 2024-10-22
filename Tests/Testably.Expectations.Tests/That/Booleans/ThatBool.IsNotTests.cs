namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatBool
{
	public sealed class IsNotTests
	{
		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenSubjectIsDifferent_ShouldSucceed(bool subject)
		{
			bool unexpected = !subject;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenSubjectIsTheSame_ShouldFail(bool subject)
		{
			bool unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).Should().IsNot(unexpected)
				                   """);
		}
	}
}
