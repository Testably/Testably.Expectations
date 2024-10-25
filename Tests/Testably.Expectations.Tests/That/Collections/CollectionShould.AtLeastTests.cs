﻿namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class CollectionShould
{
	public sealed class AtLeastTests
	{
		[Fact]
		public async Task WhenCollectionContainsEnoughEqualItems_ShouldSucceed()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).Should().AtLeast(3).Be(1);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenCollectionContainsTooFewEqualItems_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).Should().AtLeast(5).Be(1);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  have at least 5 items equal to 1,
				                  but only 4 of 7 items were equal
				                  at Expect.That(subject).Should().AtLeast(5).Be(1)
				                  """);
		}
	}
}