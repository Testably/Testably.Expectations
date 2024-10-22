using Testably.Expectations.Formatting;

namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatTimeSpan
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			TimeSpan subject = CurrentTime();
			TimeSpan unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not {Formatter.Format(unexpected)},
				                   but found {Formatter.Format(subject)}
				                   at Expect.That(subject).Should().IsNot(unexpected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldSucceed()
		{
			TimeSpan subject = CurrentTime();
			TimeSpan unexpected = LaterTime();
			
			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
