﻿namespace Testably.Expectations.Tests.ThatTests.TimeSpans;

public sealed partial class TimeSpanShould
{
	public sealed class BePositiveTests
	{
		[Fact]
		public async Task WhenSubjectIsMaxValue_ShouldSucceed()
		{
			TimeSpan subject = TimeSpan.MaxValue;

			async Task Act()
				=> await That(subject).Should().BePositive();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsMinValue_ShouldFail()
		{
			TimeSpan subject = TimeSpan.MinValue;

			async Task Act()
				=> await That(subject).Should().BePositive();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be positive,
				             but found -10675199.02:48:05
				             """);
		}

		[Fact]
		public async Task WhenSubjectIsNegative_ShouldFail()
		{
			TimeSpan subject = TimeSpan.FromSeconds(-1);

			async Task Act()
				=> await That(subject).Should().BePositive();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be positive,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsPositive_ShouldSucceed()
		{
			TimeSpan subject = TimeSpan.FromSeconds(1);

			async Task Act()
				=> await That(subject).Should().BePositive();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsZero_ShouldFail()
		{
			TimeSpan subject = TimeSpan.Zero;

			async Task Act()
				=> await That(subject).Should().BePositive();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              be positive,
				              but found {Formatter.Format(subject)}
				              """);
		}
	}

	public sealed class NotBePositiveTests
	{
		[Fact]
		public async Task WhenSubjectIsMaxValue_ShouldFail()
		{
			TimeSpan subject = TimeSpan.MaxValue;

			async Task Act()
				=> await That(subject).Should().NotBePositive();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not be positive,
				             but found 10675199.02:48:05.477
				             """);
		}

		[Fact]
		public async Task WhenSubjectIsMinValue_ShouldSucceed()
		{
			TimeSpan subject = TimeSpan.MinValue;

			async Task Act()
				=> await That(subject).Should().NotBePositive();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsNegative_ShouldSucceed()
		{
			TimeSpan subject = TimeSpan.FromSeconds(-1);

			async Task Act()
				=> await That(subject).Should().NotBePositive();

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsPositive_ShouldFail()
		{
			TimeSpan subject = TimeSpan.FromSeconds(1);

			async Task Act()
				=> await That(subject).Should().NotBePositive();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				              Expected subject to
				              not be positive,
				              but found {Formatter.Format(subject)}
				              """);
		}

		[Fact]
		public async Task WhenSubjectIsZero_ShouldSucceed()
		{
			TimeSpan subject = TimeSpan.Zero;

			async Task Act()
				=> await That(subject).Should().NotBePositive();

			await That(Act).Should().NotThrow();
		}
	}
}
