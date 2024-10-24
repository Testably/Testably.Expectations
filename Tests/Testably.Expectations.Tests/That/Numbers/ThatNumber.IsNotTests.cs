﻿namespace Testably.Expectations.Tests.That.Numbers;

public sealed partial class ThatNumber
{
	public sealed class IsNotTests
	{
		[Theory]
		[AutoData]
		public async Task WhenSubjectIsTheSame_ShouldFail(int subject)
		{
			int expected = subject;

			async Task Act()
				=> await Expect.That(subject).Should().IsNot(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage($"""
				                   Expected subject to
				                   is not {expected},
				                   but found {subject}
				                   at Expect.That(subject).Should().IsNot(expected)
				                   """);
		}

		[Theory]
		[InlineData(1, 2)]
		[InlineData(5, -3)]
		public async Task WhenSubjectIsDifferent_ShouldSucceed(int subject, int expected)
		{
			async Task Act()
				=> await Expect.That(subject).Should().IsNot(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
