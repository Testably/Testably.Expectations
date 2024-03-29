﻿using System;
using Testably.Expectations.Tests.TestHelpers;
using Xunit;

namespace Testably.Expectations.Tests.Core.Nodes;

public sealed class OrNodeTests
{
	[Fact]
	public void WithFirstFailedTests_ShouldNotThrow()
	{
		Expect.That(1,
			Should.Be.AFailedTest("to be A", "found C").Or().Be.ASuccessfulTest("to be B"));
	}

	[Fact]
	public void WithSecondFailedTests_ShouldNotThrow()
	{
		Expect.That(1,
			Should.Be.ASuccessfulTest("to be A").Or().Be.AFailedTest("to be B", "found D"));
	}

	[Fact]
	public void WithTrailingOr_ShouldThrowInvalidOperationException()
	{
		void Act()
			=> Expect.That(1,
				Should.Be.AFailedTest("to be A", "found C").Or());

		Expect.That(Act, Should.Throw.TypeOf<InvalidOperationException>().WhichMessage(
			Should.Be.EqualTo(
				"The expectation is incomplete! Did you add a trailing `.And()` or `.Or()` without specifying a second expectation?")));
	}

	[Fact]
	public void WithTwoFailedTests_ShouldIncludeBothFailuresInMessage()
	{
		void Act()
			=> Expect.That(1,
				Should.Be.AFailedTest("to be A", "found C").Or().Be
					.AFailedTest("to be B", "found D"));

		Expect.That(Act, Should.Throw.Exception().WhichMessage(
			Should.Be.EqualTo("Expected 1 to be A or to be B, but found C and found D.")));
	}

	[Fact]
	public void WithTwoSuccessfulTests_ShouldNotThrow()
	{
		Expect.That(1, Should.Be.ASuccessfulTest("to be A").Or().Be.ASuccessfulTest("to be B"));
	}
}
