namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatDateTimeOffset
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset unexpected = subject;

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
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset unexpected = LaterTime();
			
			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
