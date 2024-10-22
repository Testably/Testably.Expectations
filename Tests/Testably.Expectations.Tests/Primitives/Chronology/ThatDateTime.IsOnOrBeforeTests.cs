namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsOnOrBeforeTests
	{
		[Fact]
		public async Task WhenValueIsLater_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime();

			async Task Act()
				=> await Expect.That(subject).IsOnOrBefore(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is on or before {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).IsOnOrBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenValueIsSame_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = expected;

			async Task Act()
				=> await Expect.That(subject).IsOnOrBefore(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenValuesIsEarlier_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime();

			async Task Act()
				=> await Expect.That(subject).IsOnOrBefore(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime(4);

			async Task Act()
				=> await Expect.That(subject).IsOnOrBefore(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is on or before {expected:O} ± 0:03,
				                   but found {subject:O}
				                   at Expect.That(subject).IsOnOrBefore(expected).Within(TimeSpan.FromSeconds(3))
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime(3);

			async Task Act()
				=> await Expect.That(subject).IsOnOrBefore(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
