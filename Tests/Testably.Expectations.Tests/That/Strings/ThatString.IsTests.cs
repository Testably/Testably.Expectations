namespace Testably.Expectations.Tests.That.Strings;

public sealed partial class ThatString
{
	public class IsTests
	{
		[Theory]
		[InlineData("some message", "*me me*", true)]
		[InlineData("some message", "*ME ME*", false)]
		[InlineData("some message", "some?message", true)]
		[InlineData("some message", "some*message", true)]
		[InlineData("some message", "some me?age", false)]
		[InlineData("some message", "some me??age", true)]
		public async Task AsWildcard_ShouldDefaultToCaseSensitiveMatch(
			string subject, string pattern, bool expectMatch)
		{
			async Task Act()
				=> await Expect.That(subject).Is(pattern).AsWildcard();

			await Expect.That(Act).ThrowsException().OnlyIf(!expectMatch);
		}

		[Theory]
		[AutoData]
		public async Task WhenStringsAreTheSame_ShouldSucceed(string subject)
		{
			string expected = subject;

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Act();
		}

		[Fact]
		public async Task WhenStringsDiffer_ShouldFail()
		{
			string subject = "actual text";
			string expected = "expected other text";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  is equal to "expected other text",
				                  but found "actual text" which differs at index 0:
				                     ↓ (actual)
				                    "actual text"
				                    "expected other text"
				                     ↑ (expected)
				                  at Expect.That(subject).Is(expected)
				                  """);
		}
	}
}
