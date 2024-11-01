﻿namespace Testably.Expectations.Tests.ThatTests.Booleans;

public sealed partial class BoolShould
{
	public sealed class BeTrueTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool subject = false;

			async Task Act()
				=> await That(subject).Should().BeTrue();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             be True,
				             but found False
				             at Expect.That(subject).Should().BeTrue()
				             """);
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool subject = true;

			async Task Act()
				=> await That(subject).Should().BeTrue();

			await That(Act).Should().NotThrow();
		}
	}
}