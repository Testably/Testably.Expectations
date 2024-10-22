namespace Testably.Expectations.Tests.Primitives.Strings;

public sealed partial class ThatString
{
	public class StartsWithTests
	{
		[Theory]
		[InlineData(false)]
		[InlineData(true)]
		public async Task
			IgnoringCase_WhenSubjectStartsWithDifferentCase_ShouldFailUnlessCaseIsIgnored(
				bool ignoreCase)
		{
			string actual = "some arbitrary text";
			string expected = "SOME";

			async Task Act()
				=> await Expect.That(actual).StartsWith(expected).IgnoringCase(ignoreCase);

			await Expect.That(Act).Throws<XunitException>()
				.OnlyIf(!ignoreCase)
				.Which.HasMessage("""
				                  Expected that actual
				                  starts with "SOME",
				                  but found "some arbitrary text"
				                  at Expect.That(actual).StartsWith(expected).IgnoringCase(ignoreCase)
				                  """);
		}

		[Fact]
		public async Task
			IgnoringCase_WhenSubjectStartsWithDifferentString_ShouldIncludeIgnoringCaseInMessage()
		{
			string actual = "some arbitrary text";
			string expected = "TEXT";

			async Task Act()
				=> await Expect.That(actual).StartsWith(expected).IgnoringCase();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  starts with "TEXT" ignoring case,
				                  but found "some arbitrary text"
				                  at Expect.That(actual).StartsWith(expected).IgnoringCase()
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectStartsWithIncorrectMatchAccordingToComparer_ShouldIncludeComparerInMessage()
		{
			string actual = "some arbitrary text";
			string expected = "SOME";

			async Task Act()
				=> await Expect.That(actual).StartsWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  starts with "SOME" using IgnoreCaseForVocalsComparer,
				                  but found "some arbitrary text"
				                  at Expect.That(actual).StartsWith(expected).Using(new IgnoreCaseForVocalsComparer())
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectStartsWithMatchAccordingToComparer_ShouldSucceed()
		{
			string actual = "some arbitrary text";
			string expected = "sOmE";

			async Task Act()
				=> await Expect.That(actual).StartsWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesNotStartWithExpected_ShouldFail()
		{
			string actual = "some arbitrary text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(actual).StartsWith(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  starts with "text",
				                  but found "some arbitrary text"
				                  at Expect.That(actual).StartsWith(expected)
				                  """);
		}

		[Fact]
		public async Task WhenSubjectStartsWithExpected_ShouldSucceed()
		{
			string actual = "some arbitrary text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(actual).StartsWith(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
