namespace Testably.Expectations.Tests.That.Collections;

public sealed partial class QuantifiableCollectionItems
{
	public sealed class AreEquivalentTests
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
				=> await Expect.That(subject).Should().All().BeEquivalentTo(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have all items equivalent to expected,
				             but only 3 of 4 items were equivalent
				             at Expect.That(subject).Should().All().BeEquivalentTo(expected)
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
				=> await Expect.That(subject).Should().All().BeEquivalentTo(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
