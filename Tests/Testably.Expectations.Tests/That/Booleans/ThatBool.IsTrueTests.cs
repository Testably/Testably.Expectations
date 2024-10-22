﻿namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatBool
{
	public sealed class IsTrueTests
	{
		[Fact]
		public async Task WhenFalse_ShouldFail()
		{
			bool subject = false;

			async Task Act()
				=> await Expect.That(subject).Should().IsTrue();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is True,
				                  but found False
				                  at Expect.That(subject).Should().IsTrue()
				                  """);
		}

		[Fact]
		public async Task WhenTrue_ShouldSucceed()
		{
			bool subject = true;

			async Task Act()
				=> await Expect.That(subject).Should().IsTrue();

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
