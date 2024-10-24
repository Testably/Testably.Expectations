﻿namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatCollectionShould
{
	public sealed class AtMostTests
	{
		[Fact]
		public async Task WhenCollectionContainsSufficientlyFewEqualItems_ShouldSucceed()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expectations.ThatQuantifiableCollectionShould.Be(Expect.That(subject).Should().AtMost(3), 2);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenCollectionContainsTooManyEqualItems_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expectations.ThatQuantifiableCollectionShould.Be(Expect.That(subject).Should().AtMost(3), 1);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  have at most 3 items equal to 1,
				                  but 4 of 7 items were equal
				                  at Expect.That(subject).Should().AtMost(3).Be(1)
				                  """);
		}
	}
}