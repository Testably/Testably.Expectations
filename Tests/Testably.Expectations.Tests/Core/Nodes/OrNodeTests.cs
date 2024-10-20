using System.Threading.Tasks;
using Xunit;

namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class OrNodeTests
{
	[Fact]
	public async Task WithFirstFailedTests_ShouldNotThrow()
	{
		async Task Act()
			=> await Expect.That(true).IsFalse().Or.IsTrue();

		await Expect.That(Act).DoesNotThrow();
	}

	[Fact]
	public async Task WithSecondFailedTests_ShouldNotThrow()
	{
		async Task Act()
			=> await Expect.That(true).IsTrue().Or.IsFalse();

		await Expect.That(Act).DoesNotThrow();
	}

	[Fact]
	public async Task WithTwoFailedTests_ShouldIncludeBothFailuresInMessage()
	{
		async Task Act()
			=> await Expect.That(true).IsFalse().Or.Implies(false);

		await Expect.That(Act).ThrowsException()
			.Which.HasMessage("""
			                  Expected that true
			                  is False or implies False,
			                  but found True and it did not
			                  at Expect.That(true).IsFalse().Or.Implies(false)
			                  """);
	}

	[Fact]
	public async Task WithTwoSuccessfulTests_ShouldNotThrow()
	{
		async Task Act()
			=> await Expect.That(true).IsTrue().Or.IsNot(false);

		await Expect.That(Act).DoesNotThrow();
	}
}
