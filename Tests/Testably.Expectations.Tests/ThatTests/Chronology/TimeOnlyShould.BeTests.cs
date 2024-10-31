﻿#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.ThatTests.Chronology;

public sealed partial class TimeOnlyShould
{
	public sealed class BeTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldFail()
		{
			TimeOnly subject = CurrentTime();
			TimeOnly expected = LaterTime();

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				                    Expected subject to
				                    be {expected:O},
				                    but found {subject:O}
				                    at Expect.That(subject).Should().Be(expected)
				                    """);
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldSucceed()
		{
			TimeOnly subject = CurrentTime();
			TimeOnly expected = subject;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeTests
	{
		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldSucceed()
		{
			TimeOnly subject = CurrentTime();
			TimeOnly unexpected = LaterTime();

			async Task Act()
				=> await That(subject).Should().NotBe(unexpected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			TimeOnly subject = CurrentTime();
			TimeOnly unexpected = subject;

			async Task Act()
				=> await That(subject).Should().NotBe(unexpected);

			await That(Act).Should().Throw<XunitException>()
				.WithMessage($"""
				                    Expected subject to
				                    not be {unexpected:O},
				                    but found {subject:O}
				                    at Expect.That(subject).Should().NotBe(unexpected)
				                    """);
		}
	}
}
#endif
