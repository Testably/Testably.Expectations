namespace Testably.Expectations.Tests.Primitives.Strings;

public sealed partial class ThatString
{
	public sealed class IsNotNullTests
	{
		[Fact]
		public async Task WhenActualIsEmpty_ShouldSucceed()
		{
			string actual = "";

			async Task Act()
				=> await Expect.That(actual).IsNotNull();

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[AutoData]
		public async Task WhenActualIsNotNull_ShouldSucceed(string? actual)
		{
			async Task Act()
				=> await Expect.That(actual).IsNotNull();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenActualIsNull_ShouldFail()
		{
			string? actual = null;

			async Task Act()
				=> await Expect.That(actual).IsNotNull();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  is not null,
				                  but it was
				                  at Expect.That(actual).IsNotNull()
				                  """);
		}
	}
}
