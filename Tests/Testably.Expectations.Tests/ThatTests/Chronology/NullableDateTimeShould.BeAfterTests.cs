namespace Testably.Expectations.Tests.ThatTests.Chronology;

public sealed partial class NullableDateTimeShould
{
	public sealed class BeAfterTests
	{
		[Fact]
		public async Task WhenExpectedIsNull_ShouldFail()
		{
			DateTime? subject = CurrentTime();
			DateTime? expected = null;

			async Task Act()
				=> await That(subject).Should().BeAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be after <null>,
				              but found {subject:O}
				              at Expect.That(subject).Should().BeAfter(expected)
				              """);
		}

		[Fact]
		public async Task WhenSubjectAndExpectedAreMaxValue_ShouldFail()
		{
			DateTime? subject = DateTime.MaxValue;
			DateTime? expected = DateTime.MaxValue;

			async Task Act()
				=> await That(subject).Should().BeAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be after 9999-12-31T23:59:59.9999999,
				             but found 9999-12-31T23:59:59.9999999
				             at Expect.That(subject).Should().BeAfter(expected)
				             """);
		}

		[Fact]
		public async Task WhenSubjectAndExpectedAreMinValue_ShouldFail()
		{
			DateTime? subject = DateTime.MinValue;
			DateTime? expected = DateTime.MinValue;

			async Task Act()
				=> await That(subject).Should().BeAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be after 0001-01-01T00:00:00.0000000,
				             but found 0001-01-01T00:00:00.0000000
				             at Expect.That(subject).Should().BeAfter(expected)
				             """);
		}

		[Fact]
		public async Task WhenSubjectIsEarlier_ShouldFail()
		{
			DateTime? subject = EarlierTime();
			DateTime? expected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().BeAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be after {expected:O},
				              but found {subject:O}
				              at Expect.That(subject).Should().BeAfter(expected)
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldFail()
		{
			DateTime? subject = CurrentTime();
			DateTime? expected = subject;

			async Task Act()
				=> await That(subject).Should().BeAfter(expected)
					.Because("we want to test the failure");

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be after {expected:O}, because we want to test the failure,
				              but found {subject:O}
				              at Expect.That(subject).Should().BeAfter(expected).Because("we want to test the failure")
				              """);
		}

		[Fact]
		public async Task WhenSubjectsIsLater_ShouldSucceed()
		{
			DateTime? subject = LaterTime();
			DateTime? expected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().BeAfter(expected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenExpectedValueIsOutsideTheTolerance_ShouldFail()
		{
			DateTime? subject = CurrentTime();
			DateTime expected = EarlierTime(-3);

			async Task Act()
				=> await That(subject).Should().BeAfter(expected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be after {expected:O} ± 0:03,
				              but found {subject:O}
				              at Expect.That(subject).Should().BeAfter(expected).Within(TimeSpan.FromSeconds(3))
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime? subject = EarlierTime(3);
			DateTime? expected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().BeAfter(expected)
					.Within(TimeSpan.FromSeconds(3))
					.Because("we want to test the failure");

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be after {expected:O} ± 0:03, because we want to test the failure,
				              but found {subject:O}
				              at Expect.That(subject).Should().BeAfter(expected).Within(TimeSpan.FromSeconds(3)).Because("we want to test the failure")
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime? subject = EarlierTime(2);
			DateTime? expected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().BeAfter(expected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeAfterTests
	{
		[Fact]
		public async Task WhenSubjectAndExpectedAreMaxValue_ShouldSucceed()
		{
			DateTime? subject = DateTime.MaxValue;
			DateTime? unexpected = DateTime.MaxValue;

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectAndExpectedAreMinValue_ShouldSucceed()
		{
			DateTime? subject = DateTime.MinValue;
			DateTime? unexpected = DateTime.MinValue;

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsLater_ShouldFail()
		{
			DateTime? subject = LaterTime();
			DateTime? unexpected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be after {unexpected:O},
				              but found {subject:O}
				              at Expect.That(subject).Should().NotBeAfter(unexpected)
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldSucceed()
		{
			DateTime? subject = CurrentTime();
			DateTime? unexpected = subject;

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectsIsEarlier_ShouldSucceed()
		{
			DateTime? subject = EarlierTime();
			DateTime? unexpected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenUnexpectedIsNull_ShouldFail()
		{
			DateTime? subject = CurrentTime();
			DateTime? unexpected = null;

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected)
					.Because("we want to test the failure");

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be after <null>, because we want to test the failure,
				              but found {subject:O}
				              at Expect.That(subject).Should().NotBeAfter(unexpected).Because("we want to test the failure")
				              """);
		}

		[Fact]
		public async Task Within_WhenUnexpectedValueIsOutsideTheTolerance_ShouldFail()
		{
			DateTime? subject = CurrentTime();
			DateTime unexpected = EarlierTime(4);

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected)
					.Within(TimeSpan.FromSeconds(3))
					.Because("we want to test the failure");

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be after {unexpected:O} ± 0:03, because we want to test the failure,
				              but found {subject:O}
				              at Expect.That(subject).Should().NotBeAfter(unexpected).Within(TimeSpan.FromSeconds(3)).Because("we want to test the failure")
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTime? subject = LaterTime(4);
			DateTime? unexpected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be after {unexpected:O} ± 0:03,
				              but found {subject:O}
				              at Expect.That(subject).Should().NotBeAfter(unexpected).Within(TimeSpan.FromSeconds(3))
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTime? subject = LaterTime(3);
			DateTime? unexpected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().NotThrow();
		}
	}
}
