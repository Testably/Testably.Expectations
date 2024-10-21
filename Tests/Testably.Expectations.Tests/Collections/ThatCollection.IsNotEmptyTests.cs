namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatCollection
{
	public sealed class IsNotEmptyTests
	{
		[Fact]
		public async Task WhenCollectionContainsValues_ShouldSucceed()
		{
			int[] collection = [1, 1, 2];

			async Task Act()
				=> await Expect.That(collection).IsNotEmpty();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenCollectionIsEmpty_ShouldFail()
		{
			int[] collection = [];

			async Task Act()
				=> await Expect.That(collection).IsNotEmpty();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that collection
				                  is not empty,
				                  but it was
				                  at Expect.That(collection).IsNotEmpty()
				                  """);
		}
	}
}
