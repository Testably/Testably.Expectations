namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatCollection
{
	public sealed class AtMostAreTests
	{
		[Fact]
		public async Task WhenCollectionContainsSufficientlyFewEqualItems_ShouldSucceed()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).AtMost(3).Are(2);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenCollectionContainsTooManyEqualItems_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).AtMost(3).Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has at most 3 items equal to 1,
				                  but 4 of 7 items were equal
				                  at Expect.That(subject).AtMost(3).Are(1)
				                  """);
		}
	}
}
