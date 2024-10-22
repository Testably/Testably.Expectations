namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsTests
	{
		[Fact]
		public async Task WhenValuesAreDifferent_ShouldFail()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime();

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
		public async Task WhenValuesAreTheSame_ShouldSucceed()
		{
			DateTime subject = CurrentTime();
			DateTime expected = subject;

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime(4);

			async Task Act()
				=> await Expect.That(subject).Is(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {expected:O} ± 0:03,
				                   but found {subject:O}
				                   at Expect.That(subject).Is(expected).Within(TimeSpan.FromSeconds(3))
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime subject = CurrentTime();
			DateTime expected = LaterTime(3);

			async Task Act()
				=> await Expect.That(subject).Is(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
