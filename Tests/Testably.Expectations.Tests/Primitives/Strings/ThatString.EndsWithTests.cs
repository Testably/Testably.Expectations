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
			string subject = "some arbitrary text";
			string expected = "TEXT";

			async Task Act()
				=> await Expect.That(subject).EndsWith(expected).IgnoringCase(ignoreCase);

			await Expect.That(Act).Throws<XunitException>()
				.OnlyIf(!ignoreCase)
				.Which.HasMessage("""
				                  Expected that subject
				                  ends with "TEXT",
				                  but found "some arbitrary text"
				                  at Expect.That(subject).EndsWith(expected).IgnoringCase(ignoreCase)
				                  """);
		}

		[Fact]
		public async Task
			IgnoringCase_WhenSubjectEndsWithDifferentString_ShouldIncludeIgnoringCaseInMessage()
		{
			string subject = "some arbitrary text";
			string expected = "SOME";

			async Task Act()
				=> await Expect.That(subject).EndsWith(expected).IgnoringCase();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  ends with "SOME" ignoring case,
				                  but found "some arbitrary text"
				                  at Expect.That(subject).EndsWith(expected).IgnoringCase()
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectEndsWithIncorrectMatchAccordingToComparer_ShouldIncludeComparerInMessage()
		{
			string subject = "some arbitrary text";
			string expected = "TEXT";

			async Task Act()
				=> await Expect.That(subject).EndsWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  ends with "TEXT" using IgnoreCaseForVocalsComparer,
				                  but found "some arbitrary text"
				                  at Expect.That(subject).EndsWith(expected).Using(new IgnoreCaseForVocalsComparer())
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectEndsWithMatchAccordingToComparer_ShouldSucceed()
		{
			string subject = "some arbitrary text";
			string expected = "tExt";

			async Task Act()
				=> await Expect.That(subject).EndsWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesNotEndWithExpected_ShouldFail()
		{
			string subject = "some arbitrary text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).EndsWith(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  ends with "some",
				                  but found "some arbitrary text"
				                  at Expect.That(subject).EndsWith(expected)
				                  """);
		}

		[Fact]
		public async Task WhenSubjectEndsWithExpected_ShouldSucceed()
		{
			string subject = "some arbitrary text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).EndsWith(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
