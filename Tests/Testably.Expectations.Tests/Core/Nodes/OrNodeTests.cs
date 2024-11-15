namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class OrNodeTests
{
	[Fact]
	public async Task WithFirstFailedTests_ShouldNotThrow()
	{
		async Task Act()
			=> await That(true).Should().BeFalse().Or.BeTrue();

		await That(Act).Should().NotThrow();
	}

	[Fact]
	public async Task WithMultipleFailedTests_ShouldIncludeAllFailuresInMessage()
	{
		async Task Act()
			=> await That(true).Should().BeFalse().Or.BeFalse().Or.Imply(false);

		await That(Act).Should().ThrowException()
			.WithMessage("""
			             Expected true to
			             be False or be False or imply False,
			             but found True and it did not
			             """);
	}

	[Fact]
	public async Task WithSecondFailedTests_ShouldNotThrow()
	{
		async Task Act()
			=> await That(true).Should().BeTrue().Or.BeFalse();

		await That(Act).Should().NotThrow();
	}

	[Fact]
	public async Task WithTwoSuccessfulTests_ShouldNotThrow()
	{
		async Task Act()
			=> await That(true).Should().BeTrue().Or.NotBe(false);

		await That(Act).Should().NotThrow();
	}
}
