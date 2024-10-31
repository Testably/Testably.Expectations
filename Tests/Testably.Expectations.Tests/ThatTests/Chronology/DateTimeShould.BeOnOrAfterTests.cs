namespace Testably.Expectations.Tests.ThatTests.Chronology;

public sealed partial class DateTimeShould
{
	public sealed class BeOnOrAfterTests
	{
		[Fact]
		public async Task WhenSubjectIsEarlier_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime();

			async Task Act()
				=> await That(subject).Should().BeOnOrAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be on or after {expected:O},
				              but found {subject:O}
				              at Expect.That(subject).Should().BeOnOrAfter(expected)
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = expected;

			async Task Act()
				=> await That(subject).Should().BeOnOrAfter(expected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectsIsLater_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime();

			async Task Act()
				=> await That(subject).Should().BeOnOrAfter(expected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime(4);

			async Task Act()
				=> await That(subject).Should().BeOnOrAfter(expected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be on or after {expected:O} ± 0:03,
				              but found {subject:O}
				              at Expect.That(subject).Should().BeOnOrAfter(expected).Within(TimeSpan.FromSeconds(3))
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime(3);

			async Task Act()
				=> await That(subject).Should().BeOnOrAfter(expected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeOnOrAfterTests
	{
		[Fact]
		public async Task WhenSubjectIsLater_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime();

			async Task Act()
				=> await That(subject).Should().NotBeOnOrAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be on or after {expected:O},
				              but found {subject:O}
				              at Expect.That(subject).Should().NotBeOnOrAfter(expected)
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = expected;

			async Task Act()
				=> await That(subject).Should().NotBeOnOrAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be on or after {expected:O},
				              but found {subject:O}
				              at Expect.That(subject).Should().NotBeOnOrAfter(expected)
				              """);
		}

		[Fact]
		public async Task WhenSubjectsIsEarlier_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = EarlierTime();

			async Task Act()
				=> await That(subject).Should().NotBeOnOrAfter(expected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime(3);

			async Task Act()
				=> await That(subject).Should().NotBeOnOrAfter(expected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be on or after {expected:O} ± 0:03,
				              but found {subject:O}
				              at Expect.That(subject).Should().NotBeOnOrAfter(expected).Within(TimeSpan.FromSeconds(3))
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime expected = CurrentTime();
			DateTime subject = LaterTime(2);

			async Task Act()
				=> await That(subject).Should().NotBeOnOrAfter(expected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().NotThrow();
		}
	}
}
