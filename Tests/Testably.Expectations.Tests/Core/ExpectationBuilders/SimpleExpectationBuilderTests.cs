using System;
using Testably.Expectations.Core;
using Xunit;

namespace Testably.Expectations.Tests.Core.ExpectationBuilders;

public sealed class SimpleExpectationBuilderTests
{
	[Fact]
	public void CanOnlyAddASingleExpectation()
	{
		ShouldBe shouldBe = Should.Be;
		shouldBe.True();

		void Act()
			=> shouldBe.True();

		Expect.That(Act,
			Should.Throw.TypeOf<InvalidOperationException>().WhichMessage(
				Should.Be.EqualTo(
					"Cannot add multiple expectations to a SimpleExpectationBuilder")));
	}
	[Fact]
	public void WhenTypeDoesNotMatch_ShouldThrowInvalidOperationException()
	{
		int value = 4;

		void Act()
			=> Expect.That(value, Should.Be.True().And().Be.GreaterThan(1));

		Expect.That(Act,
			Should.Throw.TypeOf<InvalidOperationException>().WhichMessage(
				Should.Be.EqualTo(
					"The expectation does not support Int32 4")));

	}
}
