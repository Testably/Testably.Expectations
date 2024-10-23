#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatTimeOnly
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			TimeOnly subject = CurrentTime();
			TimeOnly unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is not {unexpected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).Should().IsNot(unexpected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldSucceed()
		{
			TimeOnly subject = CurrentTime();
			TimeOnly unexpected = LaterTime();
			
			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
#endif
