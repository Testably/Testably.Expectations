#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatDateOnly
{
	public sealed class IsTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldFail()
		{
			DateOnly subject = CurrentTime();
			DateOnly expected = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).Should().Is(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldSucceed()
		{
			DateOnly subject = CurrentTime();
			DateOnly expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().Is(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
#endif
