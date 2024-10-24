namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class ThatCollection
{
	public sealed class IsEmptyTests
	{
		[Fact]
		public async Task WhenCollectionContainsValues_ShouldFail()
		{
			int[] subject = [1, 1, 2];

			async Task Act()
				=> await Expect.That(subject).Should().IsEmpty();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  is empty,
				                  but found [1, 1, 2]
				                  at Expect.That(subject).Should().IsEmpty()
				                  """);
		}

		[Fact]
		public async Task WhenCollectionIsEmpty_ShouldSucceed()
		{
			int[] subject = [];

			async Task Act()
				=> await Expect.That(subject).Should().IsEmpty();

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
