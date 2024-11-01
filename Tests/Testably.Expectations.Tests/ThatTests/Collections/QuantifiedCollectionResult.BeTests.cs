namespace Testably.Expectations.Tests.ThatTests.Collections;

public sealed partial class QuantifiedCollectionResult
{
	public sealed class BeTests
	{
		[Fact]
		public async Task WhenCollectionContainsOtherValues_ShouldFail()
		{
			object[] subject =
			[
				new MyClass(),
				new SubClass(),
				new OtherClass()
			];

			async Task Act()
				=> await That(subject).Should().All().Be<MyClass>();

			await That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             have all items of type MyClass,
				             but not all of 3 items were
				             at Expect.That(subject).Should().All().Be<MyClass>()
				             """);
		}

		[Fact]
		public async Task WhenCollectionOnlyContainsEqualValues_ShouldSucceed()
		{
			object[] subject =
			[
				new MyClass(),
				new SubClass(),
			];

			async Task Act()
				=> await That(subject).Should().All().Be<MyClass>();

			await That(Act).Should().NotThrow();
		}
	}
}
