﻿namespace Testably.Expectations.Tests.ThatTests.DateTimeOffsets;

public sealed partial class DateTimeOffsetShould
{
	public sealed class BeAfterTests
	{
		[Fact]
		public async Task WhenExpectedIsNull_ShouldFail()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset? expected = null;

			async Task Act()
				=> await That(subject).Should().BeAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be after <null>,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenSubjectAndExpectedAreMaxValue_ShouldFail()
		{
			DateTimeOffset subject = DateTimeOffset.MaxValue;
			DateTimeOffset expected = DateTimeOffset.MaxValue;

			async Task Act()
				=> await That(subject).Should().BeAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be after 9999-12-31T23:59:59.9999999+00:00,
				             but found 9999-12-31T23:59:59.9999999+00:00
				             """);
		}

		[Fact]
		public async Task WhenSubjectAndExpectedAreMinValue_ShouldFail()
		{
			DateTimeOffset subject = DateTimeOffset.MinValue;
			DateTimeOffset expected = DateTimeOffset.MinValue;

			async Task Act()
				=> await That(subject).Should().BeAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be after 0001-01-01T00:00:00.0000000+00:00,
				             but found 0001-01-01T00:00:00.0000000+00:00
				             """);
		}

		[Fact]
		public async Task WhenSubjectIsEarlier_ShouldFail()
		{
			DateTimeOffset subject = EarlierTime();
			DateTimeOffset expected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().BeAfter(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be after {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldFail()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset expected = subject;

			async Task Act()
				=> await That(subject).Should().BeAfter(expected)
					.Because("we want to test the failure");

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be after {Formatter.Format(expected)}, because we want to test the failure,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenSubjectsIsLater_ShouldSucceed()
		{
			DateTimeOffset subject = LaterTime();
			DateTimeOffset expected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().BeAfter(expected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task Within_WhenNullableExpectedValueIsOutsideTheTolerance_ShouldFail()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset? expected = EarlierTime(-3);

			async Task Act()
				=> await That(subject).Should().BeAfter(expected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be after {Formatter.Format(expected)} ± 0:03,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTimeOffset subject = EarlierTime(3);
			DateTimeOffset expected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().BeAfter(expected)
					.Within(TimeSpan.FromSeconds(3))
					.Because("we want to test the failure");

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be after {Formatter.Format(expected)} ± 0:03, because we want to test the failure,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTimeOffset subject = EarlierTime(2);
			DateTimeOffset expected = CurrentTime();

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
			DateTimeOffset subject = DateTimeOffset.MaxValue;
			DateTimeOffset unexpected = DateTimeOffset.MaxValue;

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectAndExpectedAreMinValue_ShouldSucceed()
		{
			DateTimeOffset subject = DateTimeOffset.MinValue;
			DateTimeOffset unexpected = DateTimeOffset.MinValue;

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsLater_ShouldFail()
		{
			DateTimeOffset subject = LaterTime();
			DateTimeOffset unexpected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be after {Formatter.Format(unexpected)},
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsSame_ShouldSucceed()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset unexpected = subject;

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectsIsEarlier_ShouldSucceed()
		{
			DateTimeOffset subject = EarlierTime();
			DateTimeOffset unexpected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenUnexpectedIsNull_ShouldFail()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset? unexpected = null;

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected)
					.Because("we want to test the failure");

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be after <null>, because we want to test the failure,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task Within_WhenNullableUnexpectedValueIsOutsideTheTolerance_ShouldFail()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset? unexpected = EarlierTime(4);

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected)
					.Within(TimeSpan.FromSeconds(3))
					.Because("we want to test the failure");

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be after {Formatter.Format(unexpected)} ± 0:03, because we want to test the failure,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreOutsideTheTolerance_ShouldFail()
		{
			DateTimeOffset subject = LaterTime(4);
			DateTimeOffset unexpected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be after {Formatter.Format(unexpected)} ± 0:03,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task Within_WhenValuesAreWithinTheTolerance_ShouldSucceed()
		{
			DateTimeOffset subject = LaterTime(3);
			DateTimeOffset unexpected = CurrentTime();

			async Task Act()
				=> await That(subject).Should().NotBeAfter(unexpected)
					.Within(TimeSpan.FromSeconds(3));

			await That(Act).Should().NotThrow();
		}
	}
}