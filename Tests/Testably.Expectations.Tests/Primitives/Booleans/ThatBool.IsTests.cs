﻿namespace Testably.Expectations.Tests.Primitives.Booleans;

public sealed partial class ThatBool
{
	public sealed class IsTests
	{
		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenValuesAreDifferent_ShouldFail(bool subject)
		{
			bool expected = !subject;

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   is {expected},
				                   but found {subject}
				                   at Expect.That(subject).Is(expected)
				                   """);
		}

		[Theory]
		[InlineData(true)]
		[InlineData(false)]
		public async Task WhenValuesAreTheSame_ShouldSucceed(bool subject)
		{
			bool expected = subject;

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
