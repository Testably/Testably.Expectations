namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatCollection
{
	public sealed class BetweenAreTests
	{
		[Fact]
		public async Task WhenCollectionContainsSufficientlyEqualItems_ShouldSucceed()
		{
			int[] collection = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(collection).Between(3, 4).Are(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenCollectionContainsTooFewEqualItems_ShouldFail()
		{
			int[] collection = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(collection).Between(3, 4).Are(2);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that collection
				                  has between 3 and 4 items equal to 2,
				                  but only 2 items were equal
				                  at Expect.That(collection).Between(3, 4).Are(2)
				                  """);
		}

		[Fact]
		public async Task WhenCollectionContainsTooManyEqualItems_ShouldFail()
		{
			int[] collection = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(collection).Between(1, 3).Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that collection
				                  has between 1 and 3 items equal to 1,
				                  but 4 items were equal
				                  at Expect.That(collection).Between(1, 3).Are(1)
				                  """);
		}
	}
}
