namespace Testably.Expectations.Tests.That.Exceptions;

public sealed partial class ExceptionShould
{
	public sealed class HaveMessageTests
	{
		[Fact]
		public async Task FailsForDifferentStrings()
		{
			string actual = "actual text";
			string expected = "expected other text";
			Exception subject = new(actual);

			async Task Act()
				=> await Expect.That(subject).Should().HaveMessage(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				                   Expected subject to
				                   have Message equal to "expected other text",
				                   but found "actual text" which differs at index 0:
				                      ↓ (actual)
				                     "actual text"
				                     "expected other text"
				                      ↑ (expected)
				                   at Expect.That(subject).Should().HaveMessage(expected)
				                   """);
		}

		[Theory]
		[AutoData]
		public async Task SucceedsForSameStrings(string actual)
		{
			Exception subject = new(actual);

			async Task Act()
				=> await Expect.That(subject).Should().HaveMessage(actual);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
