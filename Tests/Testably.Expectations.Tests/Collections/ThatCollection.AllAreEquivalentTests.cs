namespace Testably.Expectations.Tests.Collections;

public sealed partial class ThatCollection
{
	public sealed class AllAreEquivalentTests
	{
		[Fact]
		public async Task WhenCollectionContainsOtherValues_ShouldFail()
		{
			MyClass[] subject =
			[
				new() { Value = "Foo" },
				new() { Value = "Foo" },
				new() { Value = "Foo" },
				new() { Value = "Bar" }
			];

			MyClass expected = new() { Value = "Foo" };

			async Task Act()
				=> await Expect.That(subject).All().AreEquivalentTo(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has all items equivalent to expected,
				                  but only 3 of 4 items were equivalent
				                  at Expect.That(subject).All().AreEquivalentTo(expected)
				                  """);
		}

		[Fact]
		public async Task WhenCollectionOnlyContainsEqualValues_ShouldSucceed()
		{
			MyClass[] subject =
			[
				new() { Value = "Foo" },
				new() { Value = "Foo" },
				new() { Value = "Foo" }
			];

			MyClass expected = new() { Value = "Foo" };

			async Task Act()
				=> await Expect.That(subject).All().AreEquivalentTo(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
