﻿#if NET6_0_OR_GREATER
namespace Testably.Expectations.Tests.That.Chronology;

public sealed partial class ThatDateOnly
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenSubjectIsTheSame_ShouldFail()
		{
			DateOnly subject = CurrentTime();
			DateOnly unexpected = subject;

			async Task Act()
				=> await Expect.That(subject).IsNot(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is not {unexpected:O},
				                   but found {subject:O}
				                   at Expect.That(subject).IsNot(unexpected)
				                   """);
		}

		[Fact]
		public async Task WhenSubjectIsDifferent_ShouldSucceed()
		{
			DateOnly subject = CurrentTime();
			DateOnly unexpected = LaterTime();
			
			async Task Act()
				=> await Expect.That(subject).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
#endif
