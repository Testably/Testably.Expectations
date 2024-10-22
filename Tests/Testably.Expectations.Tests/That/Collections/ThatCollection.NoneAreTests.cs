namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatCollection
{
	public sealed class NoneAreTests
	{
		[Fact]
		public async Task WhenCollectionContainsEqualValues_ShouldFail()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).None().Are(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has no items equal to 1,
				                  but 4 items were equal
				                  at Expect.That(subject).None().Are(1)
				                  """);
		}

		[Fact]
		public async Task WhenCollectionOnlyContainsDifferentValues_ShouldSucceed()
		{
			int[] subject = [1, 1, 1, 1, 2, 2, 3];

			async Task Act()
				=> await Expect.That(subject).None().Are(42);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
