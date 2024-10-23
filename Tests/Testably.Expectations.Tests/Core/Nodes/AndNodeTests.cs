namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class AndNodeTests
{
	[Fact]
	public async Task WithFirstFailedTests_ShouldIncludeSingleFailureInMessage()
	{
		async Task Act()
			=> await Expect.That(true).Should().BeFalse().And.BeTrue();

		await Expect.That(Act).Should().ThrowsException()
			.Which.HasMessage("""
			                  Expected that true
			                  is False and is True,
			                  but found True
			                  at Expect.That(true).Should().IsFalse().And.IsTrue()
			                  """);
	}

	[Fact]
	public async Task WithSecondFailedTests_ShouldIncludeSingleFailureInMessage()
	{
		async Task Act()
			=> await Expect.That(true).Should().BeTrue().And.BeFalse();

		await Expect.That(Act).Should().ThrowsException()
			.Which.HasMessage("""
			                  Expected that true
			                  is True and is False,
			                  but found True
			                  at Expect.That(true).Should().IsTrue().And.IsFalse()
			                  """);
	}

	[Fact]
	public async Task WithTwoFailedTests_ShouldIncludeBothFailuresInMessage()
	{
		async Task Act()
			=> await Expect.That(true).Should().BeFalse().And.Imply(false);

		await Expect.That(Act).Should().ThrowsException()
			.Which.HasMessage("""
			                  Expected that true
			                  is False and implies False,
			                  but found True and it did not
			                  at Expect.That(true).Should().IsFalse().And.Implies(false)
			                  """);
	}

	[Fact]
	public async Task WithTwoSuccessfulTests_ShouldNotThrow()
	{
		async Task Act()
			=> await Expect.That(true).Should().BeTrue().And.NotBe(false);

		await Expect.That(Act).Should().DoesNotThrow();
	}
}


