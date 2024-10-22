namespace Testably.Expectations.Tests.That.Exceptions;

public sealed partial class ThatException
{
	public sealed class HasMessageTests
	{
		[Fact]
		public async Task FailsForDifferentStrings()
		{
			string actual = "actual text";
			string expected = "expected other text";
			Exception subject = new(actual);

			async Task Act()
				=> await Expect.That(subject).HasMessage(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has Message equal to "expected other text",
				                  but found "actual text" which differs at index 0:
				                     ↓ (actual)
				                    "actual text"
				                    "expected other text"
				                     ↑ (expected)
				                  at Expect.That(subject).HasMessage(expected)
				                  """);
		}

		[Theory]
		[AutoData]
		public async Task SucceedsForSameStrings(string actual)
		{
			Exception subject = new(actual);

			async Task Act()
				=> await Expect.That(subject).HasMessage(actual);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
