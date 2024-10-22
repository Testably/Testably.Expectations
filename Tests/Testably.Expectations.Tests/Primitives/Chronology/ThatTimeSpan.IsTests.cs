using Testably.Expectations.Formatting;

namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatTimeSpan
{
	public sealed class IsTests
	{
		[Fact]
		public async Task WhenValuesAreDifferent_ShouldFail()
		{
			TimeSpan value = CurrentTime();
			TimeSpan expected = LaterTime();

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that value
				                   is {Formatter.Format(expected)},
				                   but found {Formatter.Format(value)}
				                   at Expect.That(value).Is(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesAreTheSame_ShouldSucceed()
		{
			TimeSpan value = CurrentTime();
			TimeSpan expected = value;

			async Task Act()
				=> await Expect.That(value).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
