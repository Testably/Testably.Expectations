using Xunit;

namespace Testably.Expectations.Tests.Expectations;

public sealed class BeNullTests
{
	[Fact]
	public void Null_ShouldNotThrow()
	{
		Dummy? sut = null;

		Expect.That(sut, Should.Be.Null());
	}

	[Fact]
	public void True_ShouldThrow()
	{
		Dummy? sut = new();

		void Act()
			=> Expect.That(sut, Should.Be.Null());

		Expect.That(Act,
			Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo($"Expected {nameof(sut)} to be null, but found bar.")));
	}

	private class Dummy
	{
		/// <inheritdoc />
		public override string ToString()
			=> "bar";
	}
}
