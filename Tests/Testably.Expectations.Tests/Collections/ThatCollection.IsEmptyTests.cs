namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatCollection
{
	public sealed class IsEmptyTests
	{
		[Fact]
		public async Task WhenCollectionContainsValues_ShouldFail()
		{
			int[] subject = [1, 1, 2];

			async Task Act()
				=> await Expect.That(subject).IsEmpty();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is empty,
				                  but found [1, 1, 2]
				                  at Expect.That(subject).IsEmpty()
				                  """);
		}

		[Fact]
		public async Task WhenCollectionIsEmpty_ShouldSucceed()
		{
			int[] subject = [];

			async Task Act()
				=> await Expect.That(subject).IsEmpty();

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
