namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatCollection
{
	public sealed class BetweenAreTests
	{
		[Fact]
		public async Task WhenCollectionContainsSufficientlyEqualItems_ShouldSucceed()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).Between(3).And(4).Are(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenCollectionContainsTooFewEqualItems_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).Between(3).And(4).Are(2);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has between 3 and 4 items equal to 2,
				                  but only 2 items were equal
				                  at Expect.That(subject).Between(3).And(4).Are(2)
				                  """);
		}

		[Fact]
		public async Task WhenCollectionContainsTooManyEqualItems_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).Between(1).And(3).Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has between 1 and 3 items equal to 1,
				                  but 4 items were equal
				                  at Expect.That(subject).Between(1).And(3).Are(1)
				                  """);
		}
	}
}
