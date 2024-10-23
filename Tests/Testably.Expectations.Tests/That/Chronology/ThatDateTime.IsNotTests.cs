namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldSucceed()
		{
			DateTime subject = CurrentTime();
			DateTime unexpected = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(unexpected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			DateTime subject = CurrentTime();
			DateTime unexpected = subject;

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
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldSucceed()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime(4);

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldFail()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime(3);

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is not {expected:O} ± 0:03,
				                   but found {subject:O}
				                   at Expect.That(subject).IsNot(expected).Should().Within(TimeSpan.FromSeconds(3))
				                   """);
		}
	}
}
