﻿namespace Testably.Expectations.Tests.That.Enums;

public sealed partial class ThatEnum
{
	public sealed class DoesNotHaveValueTests
	{
		[Theory]
		[InlineData(MyNumbers.One, 2L)]
		[InlineData(MyNumbers.Two, -7)]
		[InlineData(MyNumbers.Three, 0)]
		public async Task WhenSubjectDoesNotHaveUnexpectedValue_ShouldSucceed(MyNumbers subject,
			long unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).DoesNotHaveValue(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[InlineData(MyNumbers.One, 1)]
		[InlineData(MyNumbers.Two, 2)]
		[InlineData(MyNumbers.Three, 3)]
		public async Task WhenSubjectHasUnexpectedValue_ShouldFail(MyNumbers subject, long unexpected)
		{
			async Task Act()
				=> await Expect.That(subject).DoesNotHaveValue(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that subject
				                   does not have value {unexpected},
				                   but found {subject}
				                   at Expect.That(subject).DoesNotHaveValue(unexpected)
				                   """);
		}
	}
}
