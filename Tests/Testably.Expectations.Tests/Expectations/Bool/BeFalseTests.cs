using Xunit;

namespace Testably.Expectations.Tests.Expectations.Bool;

public sealed class BeFalseTests
{
	[Fact]
	public void False_ShouldNotThrow()
	{
		const bool sut = false;

		Expect.That(sut, Should.Be.False());
	}

	[Fact]
	public void True_ShouldThrow()
	{
		const bool sut = true;

		void Act()
			=> Expect.That(sut, Should.Be.False());

		Expect.That(Act,
			Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo($"Expected {nameof(sut)} to be False, but found True.")));
	}
}
