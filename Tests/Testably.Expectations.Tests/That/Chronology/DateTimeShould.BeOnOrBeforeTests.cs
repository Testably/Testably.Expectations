﻿namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class DateTimeShould
{
	public sealed class BeOnOrBeforeTests
	{
		[Fact]
		public async Task WhenSubjectIsLater_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().BeOnOrBefore(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be on or before {expected:O},
				              but found {subject:O}
				              at Expect.That(subject).Should().BeOnOrBefore(expected)
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = expected;

			async Task Act()
				=> await Expect.That(subject).Should().BeOnOrBefore(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectsIsEarlier_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime();

			async Task Act()
				=> await Expect.That(subject).Should().BeOnOrBefore(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime(4);

			async Task Act()
				=> await Expect.That(subject).Should().BeOnOrBefore(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be on or before {expected:O} ± 0:03,
				              but found {subject:O}
				              at Expect.That(subject).Should().BeOnOrBefore(expected).Within(TimeSpan.FromSeconds(3))
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime(3);

			async Task Act()
				=> await Expect.That(subject).Should().BeOnOrBefore(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeOnOrBeforeTests
	{
		[Fact]
		public async Task WhenSubjectIsEarlier_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime();

			async Task Act()
				=> await Expect.That(subject).Should().NotBeOnOrBefore(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be on or before {expected:O},
				              but found {subject:O}
				              at Expect.That(subject).Should().NotBeOnOrBefore(expected)
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = expected;

			async Task Act()
				=> await Expect.That(subject).Should().NotBeOnOrBefore(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be on or before {expected:O},
				              but found {subject:O}
				              at Expect.That(subject).Should().NotBeOnOrBefore(expected)
				              """);
		}

		[Fact]
		public async Task WhenSubjectsIsLater_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime();

			async Task Act()
				=> await Expect.That(subject).Should().NotBeOnOrBefore(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime(3);

			async Task Act()
				=> await Expect.That(subject).Should().NotBeOnOrBefore(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be on or before {expected:O} ± 0:03,
				              but found {subject:O}
				              at Expect.That(subject).Should().NotBeOnOrBefore(expected).Within(TimeSpan.FromSeconds(3))
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime(2);

			async Task Act()
				=> await Expect.That(subject).Should().NotBeOnOrBefore(expected)
					.Within(TimeSpan.FromSeconds(3));

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
