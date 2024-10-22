namespace Testably.Expectations.Tests.Primitives.Strings;

public sealed partial class ThatString
{
	public class EndsWithTests
	{
		[Theory]
		[InlineData(false)]
		[InlineData(true)]
		public async Task
			IgnoringCase_WhenSubjectEndsWithDifferentCase_ShouldFailUnlessCaseIsIgnored(
				bool ignoreCase)
		{
			string actual = "some arbitrary text";
			string expected = "TEXT";

			async Task Act()
				=> await Expect.That(actual).EndsWith(expected).IgnoringCase(ignoreCase);

			await Expect.That(Act).Throws<XunitException>()
				.OnlyIf(!ignoreCase)
				.Which.HasMessage("""
				                  Expected that actual
				                  ends with "TEXT",
				                  but found "some arbitrary text"
				                  at Expect.That(actual).EndsWith(expected).IgnoringCase(ignoreCase)
				                  """);
		}

		[Fact]
		public async Task
			IgnoringCase_WhenSubjectEndsWithDifferentString_ShouldIncludeIgnoringCaseInMessage()
		{
			string actual = "some arbitrary text";
			string expected = "SOME";

			async Task Act()
				=> await Expect.That(actual).EndsWith(expected).IgnoringCase();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  ends with "SOME" ignoring case,
				                  but found "some arbitrary text"
				                  at Expect.That(actual).EndsWith(expected).IgnoringCase()
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectEndsWithIncorrectMatchAccordingToComparer_ShouldIncludeComparerInMessage()
		{
			string actual = "some arbitrary text";
			string expected = "TEXT";

			async Task Act()
				=> await Expect.That(actual).EndsWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  ends with "TEXT" using IgnoreCaseForVocalsComparer,
				                  but found "some arbitrary text"
				                  at Expect.That(actual).EndsWith(expected).Using(new IgnoreCaseForVocalsComparer())
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectEndsWithMatchAccordingToComparer_ShouldSucceed()
		{
			string actual = "some arbitrary text";
			string expected = "tExt";

			async Task Act()
				=> await Expect.That(actual).EndsWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesNotEndWithExpected_ShouldFail()
		{
			string actual = "some arbitrary text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(actual).EndsWith(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  ends with "some",
				                  but found "some arbitrary text"
				                  at Expect.That(actual).EndsWith(expected)
				                  """);
		}

		[Fact]
		public async Task WhenSubjectEndsWithExpected_ShouldSucceed()
		{
			string actual = "some arbitrary text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(actual).EndsWith(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
