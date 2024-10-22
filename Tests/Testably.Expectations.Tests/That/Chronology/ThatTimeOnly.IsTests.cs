#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatTimeOnly
{
	public sealed class IsTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldFail()
		{
			TimeOnly subject = CurrentTime();
			TimeOnly expected = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).Is(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldSucceed()
		{
			TimeOnly subject = CurrentTime();
			TimeOnly expected = subject;

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
#endif
