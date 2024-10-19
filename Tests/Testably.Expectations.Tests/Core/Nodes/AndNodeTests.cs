using System;
using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class AndNodeTests
{
	[Fact]
	public async Task WithFirstFailedTests_ShouldIncludeSingleFailureInMessage()
	{
		async Task Act()
			=> await That(true).IsFalse().And.IsTrue();

		await That(Act).ThrowsException()
			.Which.HasMessage("""
			                  Expected that true
			                  is False and is True,
			                  but found True
			                  at Expect.That(true).IsFalse().And.IsTrue()
			                  """);
	}

	[Fact]
	public async Task WithSecondFailedTests_ShouldIncludeSingleFailureInMessage()
	{
		async Task Act()
			=> await That(true).IsTrue().And.IsFalse();

		await That(Act).ThrowsException()
			.Which.HasMessage("""
			                  Expected that true
			                  is True and is False,
			                  but found True
			                  at Expect.That(true).IsTrue().And.IsFalse()
			                  """);
	}

	[Fact]
	public async Task WithTwoFailedTests_ShouldIncludeBothFailuresInMessage()
	{
		async Task Act()
			=> await That(true).IsFalse().And.Implies(false);

		await That(Act).ThrowsException()
			.Which.HasMessage("""
			                  Expected that true
			                  is False and implies False,
			                  but found True and it did not
			                  at Expect.That(true).IsFalse().And.Implies(false)
			                  """);
	}

	[Fact]
	public async Task WithTwoSuccessfulTests_ShouldNotThrow()
	{
		async Task Act()
			=> await That(true).IsTrue().And.IsNot(false);

		await That(Act).DoesNotThrow();
	}
}


