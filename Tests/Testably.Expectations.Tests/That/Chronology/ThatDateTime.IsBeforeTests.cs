namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsBeforeTests
	{
		[Fact]
		public async Task WhenSubjectIsLater_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().IsBefore(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   is before {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).Should().IsBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = expected;

			async Task Act()
				=> await Expect.That(subject).Should().IsBefore(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   is before {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).Should().IsBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectsIsEarlier_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime();

			async Task Act()
				=> await Expect.That(subject).Should().IsBefore(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime(3);

			async Task Act()
				=> await Expect.That(subject).Should().IsBefore(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   is before {expected:O} ± 0:03,
				                   but found {subject:O}
				                   at Expect.That(subject).IsBefore(expected).Should().Within(TimeSpan.FromSeconds(3))
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime(2);

			async Task Act()
				=> await Expect.That(subject).Should().IsBefore(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
