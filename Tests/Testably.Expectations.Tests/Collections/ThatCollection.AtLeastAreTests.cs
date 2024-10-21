namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatCollection
{
	public sealed class AtLeastAreTests
	{
		[Fact]
		public async Task WhenCollectionContainsEnoughEqualItems_ShouldSucceed()
		{
			int[] collection = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(collection).AtLeast(3).Are(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenCollectionContainsTooFewEqualItems_ShouldFail()
		{
			int[] collection = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(collection).AtLeast(5).Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that collection
				                  has at least 5 items equal to 1,
				                  but only 4 of 7 items were equal
				                  at Expect.That(collection).AtLeast(5).Are(1)
				                  """);
		}
	}
}
