namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class OrNodeTests
{
	[Fact]
	public async Task WithFirstFailedTests_ShouldNotThrow()
	{
		async Task Act()
			=> await Expect.That(true).Should().IsFalse().Or.IsTrue();

		await Expect.That(Act).Should().DoesNotThrow();
	}

	[Fact]
	public async Task WithSecondFailedTests_ShouldNotThrow()
	{
		async Task Act()
			=> await Expect.That(true).Should().IsTrue().Or.IsFalse();

		await Expect.That(Act).Should().DoesNotThrow();
	}

	[Fact]
	public async Task WithTwoFailedTests_ShouldIncludeBothFailuresInMessage()
	{
		async Task Act()
			=> await Expect.That(true).Should().IsFalse().Or.Implies(false);

		await Expect.That(Act).Should().ThrowsException()
			.Which.HasMessage("""
			                  Expected that true
			                  is False or implies False,
			                  but found True and it did not
			                  at Expect.That(true).Should().IsFalse().Or.Implies(false)
			                  """);
	}

	[Fact]
	public async Task WithTwoSuccessfulTests_ShouldNotThrow()
	{
		async Task Act()
			=> await Expect.That(true).Should().IsTrue().Or.IsNot(false);

		await Expect.That(Act).Should().DoesNotThrow();
	}
}


