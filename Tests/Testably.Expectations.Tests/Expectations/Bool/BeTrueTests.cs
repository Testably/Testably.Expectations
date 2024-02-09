using Xunit;

namespace Testably.Expectations.Tests.Expectations.Bool;

public sealed class BeTrueTests
{
	[Fact]
	public void False_ShouldThrow()
	{
		const bool sut = false;

		void Act()
			=> Expect.That(sut, Should.Be.True());

		Expect.That(Act,
			Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo($"Expected {nameof(sut)} to be True, but found False.")));
	}

	[Fact]
	public void True_ShouldNotThrow()
	{
		const bool sut = true;

		Expect.That(sut, Should.Be.True());
	}
}
