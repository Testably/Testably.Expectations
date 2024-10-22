using Testably.Expectations.Formatting;

namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatTimeSpan
{
	public sealed class IsTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldFail()
		{
			TimeSpan subject = CurrentTime();
			TimeSpan expected = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {Formatter.Format(expected)},
				                   but found {Formatter.Format(subject)}
				                   at Expect.That(subject).Should().Is(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldSucceed()
		{
			TimeSpan subject = CurrentTime();
			TimeSpan expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
