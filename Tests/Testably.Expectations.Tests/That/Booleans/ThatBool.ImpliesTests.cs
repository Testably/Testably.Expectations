﻿namespace Testably.Expectations.Tests.That.Booleans;

public sealed partial class ThatBool
{
	public sealed class ImpliesTests
	{
		[Fact]
		public async Task WhenAntecedentDoesNotImplyConsequent_ShouldFail()
		{
			bool antecedent = true;
			bool consequent = false;

			async Task Act()
				=> await Expect.That(antecedent).Should().Implies(consequent);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage($"""
				                   Expected that antecedent
				                   implies {consequent},
				                   but it did not
				                   at Expect.That(antecedent).Should().Implies(consequent)
				                   """);
		}

		[Theory]
		[InlineData(false, false)]
		[InlineData(false, true)]
		[InlineData(true, true)]
		public async Task WhenAntecedentImpliesConsequent_ShouldSucceed(bool antecedent,
			bool consequent)
		{
			async Task Act()
				=> await Expect.That(antecedent).Should().Implies(consequent);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
