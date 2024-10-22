namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatCollection
{
	public sealed class AtLeastAreTests
	{
		[Fact]
		public async Task WhenCollectionContainsEnoughEqualItems_ShouldSucceed()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).AtLeast(3).Are(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenCollectionContainsTooFewEqualItems_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).AtLeast(5).Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has at least 5 items equal to 1,
				                  but only 4 of 7 items were equal
				                  at Expect.That(subject).AtLeast(5).Are(1)
				                  """);
		}
	}
}
