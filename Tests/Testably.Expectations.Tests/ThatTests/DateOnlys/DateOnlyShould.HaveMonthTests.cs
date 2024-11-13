﻿#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.ThatTests.DateOnlys;

public sealed partial class DateOnlyShould
{
	public sealed class HaveMonthTests
	{
		[Fact]
		public async Task WhenExpectedIsNull_ShouldFail()
		{
			DateOnly subject = new(2010, 11, 12);
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().HaveMonth(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              have month of <null>,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenMonthOfSubjectIsDifferent_ShouldFail()
		{
			DateOnly subject = new(2010, 11, 12);
			int? expected = 12;

			async Task Act()
				=> await That(subject).Should().HaveMonth(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              have month of {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenMonthOfSubjectIsTheSame_ShouldSucceed()
		{
			DateOnly subject = new(2010, 11, 12);
			int expected = 11;

			async Task Act()
				=> await That(subject).Should().HaveMonth(expected);

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotHaveMonthTests
	{
		[Fact]
		public async Task WhenMonthOfSubjectIsDifferent_ShouldSucceed()
		{
			DateOnly subject = new(2010, 11, 12);
			int? unexpected = 12;

			async Task Act()
				=> await That(subject).Should().NotHaveMonth(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenMonthOfSubjectIsTheSame_ShouldFail()
		{
			DateOnly subject = new(2010, 11, 12);
			int unexpected = 11;

			async Task Act()
				=> await That(subject).Should().NotHaveMonth(unexpected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not have month of {Formatter.Format(unexpected)},
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenUnexpectedIsNull_ShouldSucceed()
		{
			DateOnly subject = new(2010, 11, 12);
			int? unexpected = null;

			async Task Act()
				=> await That(subject).Should().NotHaveMonth(unexpected);

			await That(Act).Should().NotThrow();
		}
	}
}
#endif
