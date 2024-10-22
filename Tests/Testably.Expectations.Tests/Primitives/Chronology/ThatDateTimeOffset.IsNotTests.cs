﻿namespace Testably.Expectations.Tests.Primitives.Chronology;

public sealed partial class ThatDateTimeOffset
{
	public sealed class IsNotTests
	{
		[Fact]
		public async Task WhenValuesAreTheSame_ShouldFail()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset unexpected = subject;

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
		public async Task WhenValuesAreDifferent_ShouldSucceed()
		{
			DateTimeOffset subject = CurrentTime();
			DateTimeOffset unexpected = LaterTime();
			
			async Task Act()
				=> await Expect.That(subject).IsNot(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
