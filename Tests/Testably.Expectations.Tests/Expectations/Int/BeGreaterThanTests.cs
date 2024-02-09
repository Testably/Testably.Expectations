using Xunit;

namespace Testably.Expectations.Tests.Expectations.Int;

public sealed class BeGreaterThanTests
{
	[Fact]
	public void OneShouldBeGreaterThanZero()
	{
		int sut = 1;

		Expect.That(sut, Should.Be.GreaterThan(0));
	}

	[Fact]
	public void OneShouldNotBeGreaterThanTwo()
	{
		int sut = 1;

		void Act()
			=> Expect.That(sut, Should.Be.GreaterThan(2));

		Expect.That(Act,
			Should.Throw.Exception().Which(
				p => p.Message,
				Should.Be.EqualTo("Expected sut to be greater than 2, but found 1.")));

	}

	[Fact]
	public void OneShouldNotBeGreaterThanOne()
	{
		int sut = 1;

		void Act()
			=> Expect.That(sut, Should.Be.GreaterThan(sut));

		Expect.That(Act,
			Should.Throw.Exception().Which(
				p => p.Message,
				Should.Be.EqualTo("Expected sut to be greater than 1, but found 1.")));

	}
}
