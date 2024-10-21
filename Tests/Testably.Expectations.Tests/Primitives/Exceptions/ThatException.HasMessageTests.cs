namespace Testably.Expectations.Tests.Primitives.Exceptions;

public sealed partial class ThatException
{
	public sealed class HasMessageTests
	{
		[Fact]
		public async Task FailsForDifferentStrings()
		{
			string actual = "actual text";
			string expected = "expected other text";
			Exception sut = new(actual);

			async Task Act()
				=> await Expect.That(sut).HasMessage(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that sut
				                  has Message equal to "expected other text",
				                  but found "actual text" which differs at index 0:
				                     ↓ (actual)
				                    "actual text"
				                    "expected other text"
				                     ↑ (expected)
				                  at Expect.That(sut).HasMessage(expected)
				                  """);
		}

		[Theory]
		[AutoData]
		public async Task SucceedsForSameStrings(string actual)
		{
			Exception sut = new(actual);

			async Task Act()
				=> await Expect.That(sut).HasMessage(actual);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
