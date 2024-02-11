using Xunit;

namespace Testably.Expectations.Tests.Expectations;

public sealed class BeOfTypeTests
{
	[Fact]
	public void NullableType_ShouldBeOfType()
	{
		Dummy? sut = new();

		Expect.That(sut, Should.Be.OfType<Dummy>());
	}

	[Fact]
	public void NullDummy_ShouldNotBeOfTypeDummy()
	{
		Dummy? sut = null;

		void Act()
			=> Expect.That(sut, Should.Be.OfType<Dummy>());

		Expect.That(Act,
			Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo(
					$"Expected {nameof(sut)} to be of type Dummy, but found <null>.")));
	}

	[Fact]
	public void Object_ShouldNotBeOfTypeDummy()
	{
		object sut = new();

		void Act()
			=> Expect.That(sut, Should.Be.OfType<Dummy>());

		Expect.That(Act,
			Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo(
					$"Expected {nameof(sut)} to be of type Dummy, but it was of type Object.")));
	}

	private class Dummy
	{
		public int Id { get; }

		/// <inheritdoc />
		public override string ToString()
			=> $"Dummy#{Id}";
	}
}
