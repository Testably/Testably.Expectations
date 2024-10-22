namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenValuesAreDifferent_ShouldSucceed()
		{
			DateTime subject = CurrentTime();
			DateTime unexpected = LaterTime();

			async Task Act()
				=> await Expect.That(subject).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenValuesAreTheSame_ShouldFail()
		{
			DateTime subject = CurrentTime();
			DateTime unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).IsNot(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not {unexpected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).IsNot(unexpected)
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldSucceed()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime(4);

			async Task Act()
				=> await Expect.That(subject).IsNot(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldFail()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime(3);

			async Task Act()
				=> await Expect.That(subject).IsNot(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not {expected:O} ± 0:03,
				                   but found {subject:O}
				                   at Expect.That(subject).IsNot(expected).Within(TimeSpan.FromSeconds(3))
				                   """);
		}
	}
}
