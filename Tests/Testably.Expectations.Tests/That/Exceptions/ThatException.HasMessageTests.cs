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
				=> await Expect.That(subject).Should().HasMessage(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  has Message equal to "expected other text",
				                  but found "actual text" which differs at index 0:
				                     ↓ (actual)
				                    "actual text"
				                    "expected other text"
				                     ↑ (expected)
				                  at Expect.That(subject).Should().HasMessage(expected)
				                  """);
		}

		[Theory]
		[AutoData]
		public async Task SucceedsForSameStrings(string actual)
		{
			Exception subject = new(actual);

			async Task Act()
				=> await Expect.That(subject).Should().HasMessage(actual);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
