using Testably.Expectations.Formatting;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatTimeSpan
{
	public sealed class IsTests
	{
		[Fact]
		public async Task WhenValuesAreDifferent_ShouldFail()
		{
			TimeSpan subject = CurrentTime();
			TimeSpan expected = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {Formatter.Format(expected)},
				                   but found {Formatter.Format(subject)}
				                   at Expect.That(subject).Is(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesAreTheSame_ShouldSucceed()
		{
			TimeSpan subject = CurrentTime();
			TimeSpan expected = subject;

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
