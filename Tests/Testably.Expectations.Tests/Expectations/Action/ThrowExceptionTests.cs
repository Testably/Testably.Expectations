using System;
using Xunit;

namespace Testably.Expectations.Tests.Expectations.Action;

public sealed class ThrowExceptionTests
{
	[Fact]
	public void DifferentException()
	{
		void Sut()
		{
			throw new ArgumentException();
		}

		void Act()
			=> Expect.That(Sut, Should.Throw.TypeOf<NullReferenceException>());

		Expect.That(Act,
			Should.Throw.Exception().WhichMessage(
				Should.Start.With(
					$"Expected {nameof(Sut)} to throw a {nameof(NullReferenceException)}, but the thrown exception was an {nameof(ArgumentException)} with message")));
	}

	[Fact]
	public void NoException_Specified()
	{
		void Sut()
		{
		}

		void Act()
			=> Expect.That(Sut, Should.Throw.TypeOf<ArgumentException>());

		Expect.That(Act,
			Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo(
					$"Expected {nameof(Sut)} to throw an {nameof(ArgumentException)}, but none was thrown.")));
	}

	[Fact]
	public void NoException_Unspecified()
	{
		void Sut()
		{
		}

		void Act()
			=> Expect.That(Sut, Should.Throw.Exception());

		Expect.That(Act,
			Should.Throw.Exception().WhichMessage(
				Should.Be.EqualTo(
					$"Expected {nameof(Sut)} to throw an Exception, but none was thrown.")));
	}

	[Fact]
	public void Specified_ShouldCheckForMatchingThrownException()
	{
		void Sut()
		{
			throw new ArgumentException();
		}

		Expect.That(Sut, Should.Throw.TypeOf<ArgumentException>());
	}

	[Fact]
	public void Unspecified_ShouldCheckForAnyThrownException()
	{
		void Sut()
		{
			throw new ArgumentException();
		}

		Expect.That(Sut, Should.Throw.Exception());
	}
}
