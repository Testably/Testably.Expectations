using Xunit;

namespace Testably.Expectations.Tests.Expectations;

public sealed class BeEqualToTests
{
	[Fact]
	public void Null_ShouldBeEqualToNull()
	{
		Dummy? sut = null;

		Expect.That(sut, Should.Be.EqualTo((Dummy?)null));
	}

	[Fact]
	public void Null_ShouldNotBeEqualToOtherObject()
	{
		Dummy? sut = null;
		Dummy? expected = new()
		{
			Id = 1
		};

		void Act()
			=> Expect.That(sut, Should.Be.EqualTo(expected));

		Expect.That(Act,
			Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo(
					$"Expected {nameof(sut)} to be equal to Dummy#1, but found <null>.")));
	}

	[Fact]
	public void Object_ShouldNotBeEqualToOtherObject()
	{
		Dummy? sut = new()
		{
			Id = 1
		};
		Dummy? expected = new()
		{
			Id = 2
		};

		void Act()
			=> Expect.That(sut, Should.Be.EqualTo(expected));

		Expect.That(Act,
			Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo(
					$"Expected {nameof(sut)} to be equal to Dummy#2, but found Dummy#1.")));
	}

	[Fact]
	public void ShouldBeEqualToItself()
	{
		Dummy sut = new();

		Expect.That(sut, Should.Be.EqualTo(sut));
	}

	private class Dummy
	{
		public int Id { get; set; }

		/// <inheritdoc />
		public override string ToString()
			=> $"Dummy#{Id}";
	}
}
