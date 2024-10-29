﻿namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class CollectionShould
{
	public sealed class BetweenTests
	{
		[Fact]
		public async Task WhenCollectionContainsSufficientlyEqualItems_ShouldSucceed()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).Should().Between(3).And(4).Be(1);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenCollectionContainsTooFewEqualItems_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).Should().Between(3).And(4).Be(2);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have between 3 and 4 items equal to 2,
				             but only 2 items were equal
				             at Expect.That(subject).Should().Between(3).And(4).Be(2)
				             """);
		}

		[Fact]
		public async Task WhenCollectionContainsTooManyEqualItems_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).Should().Between(1).And(3).Be(1);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have between 1 and 3 items equal to 1,
				             but 4 items were equal
				             at Expect.That(subject).Should().Between(1).And(3).Be(1)
				             """);
		}
	}
}
