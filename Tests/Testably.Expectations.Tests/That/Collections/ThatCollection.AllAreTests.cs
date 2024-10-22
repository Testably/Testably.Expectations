namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatCollection
{
	public sealed class AllAreTests
	{
		[Fact]
		public async Task WhenCollectionContainsOtherValues_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).All().Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has all items equal to 1,
				                  but only 4 of 7 items were equal
				                  at Expect.That(subject).All().Are(1)
				                  """);
		}

		[Fact]
		public async Task WhenCollectionOnlyContainsEqualValues_ShouldSucceed()
		{
			int[] subject = [1, 1, 1, 1];

			async Task Act()
				=> await Expect.That(subject).All().Are(1);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
