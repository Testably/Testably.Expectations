﻿using Testably.Expectations.Core;

namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class AndNodeTests
{
	[Fact]
	public async Task ToString_ShouldCombineAllNodes()
	{
		IThat<bool> that = That(true).Should();
		that.BeTrue().And.BeFalse().And.Imply(false);

		string expectedResult = "be True and be False and imply False";

		string? result = that.ExpectationBuilder.ToString();

		await That(result).Should().Be(expectedResult);
	}

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
			             """);
	}

	[Fact]
	public async Task WithMultipleFailedTests_ShouldIncludeAllFailuresInMessage()
	{
		async Task Act()
			=> await That(true).Should().BeFalse().And.BeFalse().And.Imply(false);

		await That(Act).Should().ThrowException()
			.WithMessage("""
			             Expected true to
			             be False and be False and imply False,
			             but found True and it did not
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
