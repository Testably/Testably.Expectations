namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsAfterTests
	{
		[Fact]
		public async Task WhenValueIsEarlier_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime();

			async Task Act()
				=> await Expect.That(subject).IsAfter(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is after {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).IsAfter(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValueIsSame_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = expected;

			async Task Act()
				=> await Expect.That(subject).IsAfter(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is after {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).IsAfter(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValuesIsLater_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime();

			async Task Act()
				=> await Expect.That(subject).IsAfter(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime(3);

			async Task Act()
				=> await Expect.That(subject).IsAfter(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is after {expected:O} ± 0:03,
				                   but found {subject:O}
				                   at Expect.That(subject).IsAfter(expected).Within(TimeSpan.FromSeconds(3))
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime(2);

			async Task Act()
				=> await Expect.That(subject).IsAfter(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
