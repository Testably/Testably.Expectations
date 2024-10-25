namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsNotBeforeTests
	{
		[Fact]
		public async Task WhenSubjectIsEarlier_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime();

			async Task Act()
				=> await Expect.That(subject).Should().IsNotBefore(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   is not before {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).Should().IsNotBefore(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = expected;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotBefore(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectsIsLater_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().IsNotBefore(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime(4);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotBefore(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   is not before {expected:O} ± 0:03,
				                   but found {subject:O}
				                   at Expect.That(subject).IsNotBefore(expected).Should().Within(TimeSpan.FromSeconds(3))
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime(3);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotBefore(expected).Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
