namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsNotOnOrBeforeTests
	{
		[Fact]
		public async Task WhenSubjectIsEarlier_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime();

			async Task Act()
				=> await Expect.That(subject).Should().IsNotOnOrBefore(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not on or before {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).Should().IsNotOnOrBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = expected;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotOnOrBefore(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not on or before {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).Should().IsNotOnOrBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectsIsLater_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().IsNotOnOrBefore(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime(3);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotOnOrBefore(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not on or before {expected:O} ± 0:03,
				                   but found {subject:O}
				                   at Expect.That(subject).IsNotOnOrBefore(expected).Should().Within(TimeSpan.FromSeconds(3))
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime(2);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotOnOrBefore(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
