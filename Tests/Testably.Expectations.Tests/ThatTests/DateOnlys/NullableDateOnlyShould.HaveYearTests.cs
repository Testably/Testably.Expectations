﻿#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.ThatTests.DateOnlys;

public sealed partial class NullableDateOnlyShould
{
	public sealed class HaveYearTests
	{
		[Fact]
		public async Task WhenExpectedIsNull_ShouldFail()
		{
			DateOnly? subject = new(2010, 11, 12);
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().HaveYear(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              have year of <null>,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenYearOfSubjectIsDifferent_ShouldFail()
		{
			DateOnly? subject = new(2010, 11, 12);
			int? expected = 2011;

			async Task Act()
				=> await That(subject).Should().HaveYear(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              have year of {Formatter.Format(expected)},
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenYearOfSubjectIsTheSame_ShouldSucceed()
		{
			DateOnly? subject = new(2010, 11, 12);
			int expected = 2010;

			async Task Act()
				=> await That(subject).Should().HaveYear(expected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectAndExpectedIsNull_ShouldFail()
		{
			DateOnly? subject = null;
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().HaveYear(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have year of <null>,
				             but found <null>
				             """);
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldFail()
		{
			DateOnly? subject = null;
			int? expected = 1;

			async Task Act()
				=> await That(subject).Should().HaveYear(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have year of 1,
				             but found <null>
				             """);
		}
	}

	public sealed class NotHaveYearTests
	{
		[Fact]
		public async Task WhenYearOfSubjectIsDifferent_ShouldSucceed()
		{
			DateOnly? subject = new(2010, 11, 12);
			int? unexpected = 2011;

			async Task Act()
				=> await That(subject).Should().NotHaveYear(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenYearOfSubjectIsTheSame_ShouldFail()
		{
			DateOnly? subject = new(2010, 11, 12);
			int unexpected = 2010;

			async Task Act()
				=> await That(subject).Should().NotHaveYear(unexpected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not have year of {Formatter.Format(unexpected)},
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenSubjectAndUnexpectedIsNull_ShouldSucceed()
		{
			DateOnly? subject = null;
			int? expected = null;

			async Task Act()
				=> await That(subject).Should().NotHaveYear(expected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNull_ShouldSucceed()
		{
			DateOnly? subject = null;
			int? expected = 1;

			async Task Act()
				=> await That(subject).Should().NotHaveYear(expected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenUnexpectedIsNull_ShouldSucceed()
		{
			DateOnly? subject = new(2010, 11, 12);
			int? unexpected = null;

			async Task Act()
				=> await That(subject).Should().NotHaveYear(unexpected);

			await That(Act).Should().NotThrow();
		}
	}
}
#endif
