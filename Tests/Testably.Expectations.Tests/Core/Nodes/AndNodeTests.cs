namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class AndNodeTests
{
	[Fact]
	public async Task WithFirstFailedTests_ShouldIncludeSingleFailureInMessage()
	{
		async Task Act()
			=> await That(true).Should().BeFalse().And.BeTrue();

		await That(Act).Should().ThrowException()
			.WithMessage("""
			             Expected true to
			             be False and be True,
			             but found True
			             at Expect.That(true).Should().BeFalse().And.BeTrue()
			             """);
	}

	[Fact]
	public async Task WithSecondFailedTests_ShouldIncludeSingleFailureInMessage()
	{
		async Task Act()
			=> await That(true).Should().BeTrue().And.BeFalse();

		await That(Act).Should().ThrowException()
			.WithMessage("""
			             Expected true to
			             be True and be False,
			             but found True
			             at Expect.That(true).Should().BeTrue().And.BeFalse()
			             """);
	}

	[Fact]
	public async Task WithTwoFailedTests_ShouldIncludeBothFailuresInMessage()
	{
		async Task Act()
			=> await That(true).Should().BeFalse().And.Imply(false);

		await That(Act).Should().ThrowException()
			.WithMessage("""
			             Expected true to
			             be False and imply False,
			             but found True and it did not
			             at Expect.That(true).Should().BeFalse().And.Imply(false)
			             """);
	}

	[Fact]
	public async Task WithTwoSuccessfulTests_ShouldNotThrow()
	{
		async Task Act()
			=> await That(true).Should().BeTrue().And.NotBe(false);

		await That(Act).Should().NotThrow();
	}
}
