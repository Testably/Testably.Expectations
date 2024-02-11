using System;
using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class AndNodeTests
{
	[Fact]
	public void WithFirstFailedTests_ShouldIncludeSingleFailureInMessage()
	{
		void Act()
			=> Expect.That(1,
				Should.Be.AFailedTest("to be A", "found C").And().Be.ASuccessfulTest("to be B"));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(
			Should.Be.EqualTo("Expected 1 to be A and to be B, but found C.")));
	}

	[Fact]
	public void WithSecondFailedTests_ShouldIncludeSingleFailureInMessage()
	{
		void Act()
			=> Expect.That(1,
				Should.Be.ASuccessfulTest("to be A").And().Be.AFailedTest("to be B", "found D"));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(
			Should.Be.EqualTo("Expected 1 to be A and to be B, but found D.")));
	}

	[Fact]
	public void WithTrailingAnd_ShouldThrowInvalidOperationException()
	{
		void Act()
			=> Expect.That(1,
				Should.Be.AFailedTest("to be A", "found C").And());

		Expect.That(Act, Should.Throw.TypeOf<InvalidOperationException>().WhichMessage(
			Should.Be.EqualTo(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?")));
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
		Expect.That(1, Should.Be.ASuccessfulTest("to be A").And().Be.ASuccessfulTest("to be B"));
	}
}
