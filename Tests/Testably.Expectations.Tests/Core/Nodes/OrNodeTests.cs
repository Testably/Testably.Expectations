namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class OrNodeTests
{
	[Fact]
	public async Task WithFirstFailedTests_ShouldNotThrow()
	{
		async Task Act()
			=> await Expect.That(true).Should().BeFalse().Or.BeTrue();

		await Expect.That(Act).Should().NotThrow();
	}

	[Fact]
	public async Task WithSecondFailedTests_ShouldNotThrow()
	{
		async Task Act()
			=> await Expect.That(true).Should().BeTrue().Or.BeFalse();

		await Expect.That(Act).Should().NotThrow();
	}

	[Fact]
	public async Task WithTwoFailedTests_ShouldIncludeBothFailuresInMessage()
	{
		async Task Act()
			=> await Expect.That(true).Should().BeFalse().Or.Imply(false);

		await Expect.That(Act).Should().ThrowException()
			.WithMessage("""
			                  Expected true to
			                  be False or imply False,
			                  but found True and it did not
			                  at Expect.That(true).Should().BeFalse().Or.Imply(false)
			                  """);
	}

	[Fact]
	public async Task WithTwoSuccessfulTests_ShouldNotThrow()
	{
		async Task Act()
			=> await Expect.That(true).Should().BeTrue().Or.NotBe(false);

		await Expect.That(Act).Should().NotThrow();
	}
}


