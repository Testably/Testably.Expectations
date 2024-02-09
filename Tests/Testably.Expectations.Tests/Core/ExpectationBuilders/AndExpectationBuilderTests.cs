using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Core.ExpectationBuilders;

public sealed class AndExpectationBuilderTests
{
	[Fact]
	public void WithFirstFailedTests_ShouldIncludeSingleFailureInMessage()
	{
		void Act()
			=> Expect.That(1,
				Should.Be.AFailedTest("to be A", "found C").And().Be.ASuccessfulTest());

		Expect.That(Act, Should.Throw.Exception().WhichMessage(
			Should.Be.EqualTo("Expected 1 to be A, but found C.")));
	}

	[Fact]
	public void WithSecondFailedTests_ShouldIncludeSingleFailureInMessage()
	{
		void Act()
			=> Expect.That(1,
				Should.Be.ASuccessfulTest().And().Be.AFailedTest("to be B", "found D"));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(
			Should.Be.EqualTo("Expected 1 to be B, but found D.")));
	}

	[Fact]
	public void WithTwoFailedTests_ShouldIncludeBothFailuresInMessage()
	{
		void Act()
			=> Expect.That(1,
				Should.Be.AFailedTest("to be A", "found C").And().Be
					.AFailedTest("to be B", "found D"));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(
			Should.Be.EqualTo("Expected 1 to be A and to be B, but found C and found D.")));
	}

	[Fact]
	public void WithTwoSuccessfulTests_ShouldNotThrow()
	{
		Expect.That(1, Should.Be.ASuccessfulTest().And().Be.ASuccessfulTest());
	}
}
