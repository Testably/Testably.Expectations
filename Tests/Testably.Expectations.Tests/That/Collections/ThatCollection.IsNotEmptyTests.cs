namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatCollection
{
	public sealed class IsNotEmptyTests
	{
		[Fact]
		public async Task WhenCollectionContainsValues_ShouldSucceed()
		{
			int[] subject = [1, 1, 2];

			async Task Act()
				=> await Expect.That(subject).Should().IsNotEmpty();

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenCollectionIsEmpty_ShouldFail()
		{
			int[] subject = [];

			async Task Act()
				=> await Expect.That(subject).Should().IsNotEmpty();

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is not empty,
				                  but it was
				                  at Expect.That(subject).Should().IsNotEmpty()
				                  """);
		}
	}
}
