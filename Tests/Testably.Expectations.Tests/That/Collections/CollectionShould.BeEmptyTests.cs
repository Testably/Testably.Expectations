namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class CollectionShould
{
	public sealed class BeEmptyTests
	{
		[Fact]
		public async Task WhenCollectionContainsValues_ShouldFail()
		{
			int[] subject = [1, 1, 2];

			async Task Act()
				=> await Expectations.ThatCollectionShould.BeEmpty(Expect.That(subject).Should());

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				                  Expected subject to
				                  be empty,
				                  but found [1, 1, 2]
				                  at Expect.That(subject).Should().BeEmpty()
				                  """);
		}

		[Fact]
		public async Task WhenCollectionIsEmpty_ShouldSucceed()
		{
			int[] subject = [];

			async Task Act()
				=> await Expectations.ThatCollectionShould.BeEmpty(Expect.That(subject).Should());

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotBeEmptyTests
	{
		[Fact]
		public async Task WhenCollectionContainsValues_ShouldSucceed()
		{
			int[] subject = [1, 1, 2];

			async Task Act()
				=> await Expectations.ThatCollectionShould.NotBeEmpty(Expect.That(subject)
					.Should());

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenCollectionIsEmpty_ShouldFail()
		{
			int[] subject = [];

			async Task Act()
				=> await Expectations.ThatCollectionShould.NotBeEmpty(Expect.That(subject)
					.Should());

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				                  Expected subject to
				                  not be empty,
				                  but it was
				                  at Expect.That(subject).Should().NotBeEmpty()
				                  """);
		}
	}
}
