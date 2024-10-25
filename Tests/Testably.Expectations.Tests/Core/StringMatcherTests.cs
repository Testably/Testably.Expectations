using Testably.Expectations.Tests.TestHelpers;

namespace Testably.Expectations.Tests.Core;

public class StringMatcherTests
{
	public class ExactMatch
	{
		[Theory]
		// ReSharper disable once StringLiteralTypo
		[InlineData("ThisIsUsedTo Chec k a difference after 4 characters",
			// ReSharper disable once StringLiteralTypo
			"\"…sedTo CheckADifferen")]
		[InlineData("ThisIsUsedTo CheckADifference after 16 characters", "\"…Difference")]
		public async Task
			ShouldFallbackTo10CharactersIfNowWordBoundaryCanBeFoundBeforeTheMismatchingIndex(
				string expected, string expectedMessagePart)
		{
			string subject = "ThisIsUsedTo CheckADifferenceInThe WordBoundaryAlgorithm";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage($"*{expectedMessagePart}*");
		}

		[Theory]
		[InlineData("ThisLongTextIsUsedToCheckADifferenceAtTheEndO after 10 + 4 characters",
			"eAtTheEndOfThe WordB…\"")]
		// ReSharper disable once StringLiteralTypo
		[InlineData("ThisLongTextIsUsedToCheckADiffere after 10 + 16 characters",
			"ckADifferenceAtTheEn…\"")]
		public async Task
			ShouldFallbackTo20CharactersIfNoWordBoundaryCanBeFoundAfterTheMismatchingIndex(
				string expected, string expectedMessagePart)
		{
			string subject =
				"ThisLongTextIsUsedToCheckADifferenceAtTheEndOfThe WordBoundaryAlgorithm";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage($"*{expectedMessagePart}*");
		}

		[Fact]
		public async Task ShouldIncludeTheLineNumberForMismatchesInMultilineTexts()
		{
			int expectedIndex = 100 + (4 * Environment.NewLine.Length);
			string nl = Environment.NewLine.Replace("\n", "\\n").Replace("\r", "\\r");

			string subject = """
			                 @startuml
			                 Alice -> Bob : Authentication Request
			                 Bob --> Alice : Authentication Response

			                 Alice -> Bob : Another authentication Request
			                 Alice <-- Bob : Another authentication Response
			                 @enduml
			                 """;

			string expected = """
			                  @startuml
			                  Alice -> Bob : Authentication Request
			                  Bob --> Alice : Authentication Response

			                  Alice -> Bob : Invalid authentication Request
			                  Alice <-- Bob : Another authentication Response
			                  @enduml
			                  """;

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowException()
				.Which.HaveMessage($"""
				                   Expected subject to
				                   be equal to "@startuml{nl}Alice -> Bob :…",
				                   but found "@startuml{nl}Alice -> Bob :…" which differs on line 5 and column 16 (index {expectedIndex}):
				                                ↓ (actual)
				                     "…-> Bob : Another…"
				                     "…-> Bob : Invalid…"
				                                ↑ (expected)
				                   at Expect.That(subject).Should().Be(expected)
				                   """);
		}

		[Theory]
		[InlineData("ThisLongTextIsUsedToCheckADifferenceAtTheEnd after 10 + 5 characters")]
		// ReSharper disable once StringLiteralTypo
		[InlineData("ThisLongTextIsUsedToCheckADifferen after 10 + 15 characters")]
		public async Task
			ShouldLookForAWordBoundaryBetween15And25CharactersAfterTheMismatchingIndexToHighlightTheMismatch(
				string expected)
		{
			string subject =
				"ThisLongTextIsUsedToCheckADifferenceAtTheEndOfThe WordBoundaryAlgorithm";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*AtTheEndOfThe…\"*");
		}

		[Theory]
		[InlineData("ThisIsUsedTo Check a difference after 5 characters")]
		// ReSharper disable once StringLiteralTypo
		[InlineData("ThisIsUsedTo CheckADifferenc e after 15 characters")]
		public async Task
			ShouldLookForAWordBoundaryBetween5And15CharactersBeforeTheMismatchingIndexToHighlightTheMismatch(
				string expected)
		{
			string subject = "ThisIsUsedTo CheckADifferenceInThe WordBoundaryAlgorithm";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*\"…CheckADifferenceInThe*");
		}

		[Fact]
		public async Task ShouldOnlyAddEllipsisForLongTexts()
		{
			string subject = "this is a long text that differs";
			string expected = "this was too short";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*\"this is a long text that…\"*")
				.AndWithMessage("*\"this was too short\"*");
		}

		[Fact]
		public async Task WhenBothValuesAreNull_ShouldSucceed()
		{
			string? subject = null;
			string? expected = null;

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenBothValuesAreTheSame_ShouldSucceed()
		{
			string subject = "ABC";
			string expected = "ABC";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenStringsAreLong_ShouldHighlightTheDifferences()
		{
			string subject = "this is a long text that differs in between two words";
			string expected = "this is a long text which differs in between two words";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowException()
				.Which.HaveMessage("""
				                  Expected subject to
				                  be equal to "this is a long text which…",
				                  but found "this is a long text that…" which differs at index 20:
				                                     ↓ (actual)
				                    "…is a long text that…"
				                    "…is a long text which…"
				                                     ↑ (expected)
				                  at Expect.That(subject).Should().Be(expected)
				                  """);
		}

		[Fact]
		public async Task
			WhenStringsDifferAndAreMultiline_ShouldFailWithNewlinesReplacedInTheMessage()
		{
			string subject = "A\r\nB";
			string expected = "A\r\nC";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage(@"*A\r\nB*A\r\nC*");
		}

		[Fact]
		public async Task
			WhenTheExpectedStringHasLeadingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = " ABC";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*misses some whitespace at the beginning*");
		}

		[Fact]
		public async Task
			WhenTheExpectedStringHasTrailingAndLeadingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = "	ABC ";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*differs in whitespace*");
		}

		[Fact]
		public async Task
			WhenTheExpectedStringHasTrailingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = "ABC  ";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*misses some whitespace at the end*");
		}

		[Fact]
		public async Task WhenTheExpectedStringIsEmpty_ShouldFailWithDescriptiveMessage()
		{
			string subject = "AB";
			string expected = "";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should()
				.ThrowWithMessage("*length of 2 which is longer than the expected length of 0*");
		}

		[Fact]
		public async Task
			WhenTheExpectedStringIsLongerThanTheSubjectString_ShouldFailWithDescriptiveMessage()
		{
			string subject = "AB";
			string expected = "ABC";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should()
				.ThrowWithMessage("*length of 2 which is shorter than the expected length of 3*");
		}

		[Fact]
		public async Task WhenTheExpectedStringIsNull_ShouldFailWithDescriptiveMessage()
		{
			string subject = "AB";
			string? expected = null;

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*equal to <null>*");
		}

		[Fact]
		public async Task
			WhenTheExpectedStringIsShorterThanTheSubjectString_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = "AB";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should()
				.ThrowWithMessage("*length of 3 which is longer than the expected length of 2*");
		}

		[Fact]
		public async Task WhenTheStringsDiffer_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = "AXC";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*differs at index 1*");
		}

		[Fact]
		public async Task WhenTheSubjectHasLeadingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "	 ABC";
			string expected = "ABC";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*unexpected whitespace at the beginning*");
		}

		[Fact]
		public async Task
			WhenTheSubjectHasTrailingAndLeadingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = " ABC	";
			string expected = "ABC";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*differs in whitespace*");
		}

		[Fact]
		public async Task WhenTheSubjectHasTrailingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC	";
			string expected = "ABC";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*unexpected whitespace at the end*");
		}

		[Fact]
		public async Task WhenTheSubjectStringIsEmpty_ShouldFailWithDescriptiveMessage()
		{
			string subject = "";
			string expected = "AB";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should()
				.ThrowWithMessage("*length of 0 which is shorter than the expected length of 2*");
		}

		[Fact]
		public async Task WhenTheSubjectStringIsNull_ShouldFailWithDescriptiveMessage()
		{
			string? subject = null;
			string expected = "AB";

			async Task Act()
				=> await Expect.That(subject).Should().Be(expected);

			await Expect.That(Act).Should().ThrowWithMessage("*but found <null>*");
		}
	}
}
