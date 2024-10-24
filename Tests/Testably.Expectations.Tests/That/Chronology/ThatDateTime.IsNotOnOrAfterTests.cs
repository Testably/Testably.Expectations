﻿namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatDateTime
{
	public sealed class IsNotOnOrAfterTests
	{
		[Fact]
		public async Task WhenSubjectIsLater_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().IsNotOnOrAfter(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is not on or after {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).Should().IsNotOnOrAfter(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = expected;

			async Task Act()
				=> await Expect.That(subject).Should().IsNotOnOrAfter(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is not on or after {expected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).Should().IsNotOnOrAfter(expected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectsIsEarlier_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime();

			async Task Act()
				=> await Expect.That(subject).Should().IsNotOnOrAfter(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime(3);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotOnOrAfter(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is not on or after {expected:O} ± 0:03,
				                   but found {subject:O}
				                   at Expect.That(subject).IsNotOnOrAfter(expected).Should().Within(TimeSpan.FromSeconds(3))
				                   """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime(2);

			async Task Act()
				=> await Expect.That(subject).Should().IsNotOnOrAfter(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
