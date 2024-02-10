using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Core.ExpectationBuilders;

public sealed class NotExpectationBuilderTests
{
	[Fact]
	public void ShouldAlsoWorkWithAndCombinations()
	{
		object sut = new();

		void Act()
			=> Expect.That(sut,
				Should.Not.Be.Null().And().Not.Be.ASuccessfulTest("to be A"));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(
			Should.Be.EqualTo("Expected sut not to be null and not to be A, but it did.")));
	}

	[Fact]
	public void WithANegatedFailedTest_ShouldNotThrow()
	{
		object sut = new();

		Expect.That(sut, Should.Not.Be.AFailedTest("to be A", "test failed"));
	}

	[Fact]
	public void WithANegatedSuccessfulTest_ShouldThrow()
	{
		object sut = new();

		void Act()
			=> Expect.That(sut,
				Should.Not.Be.ASuccessfulTest("to be A"));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(
			Should.Be.EqualTo("Expected sut not to be A, but it did.")));
	}
}
