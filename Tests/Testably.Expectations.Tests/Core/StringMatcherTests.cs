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
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException().WithMessage($"*{expectedMessagePart}*")
				.AsWildcard();
		}

		[Theory]
		[InlineData("ThisLongTextIsUsedToCheckADifferenceAtTheEndO after 10 + 4 characters",
			"\"…eAtTheEndOfThe WordB")]
		// ReSharper disable once StringLiteralTypo
		[InlineData("ThisLongTextIsUsedToCheckADiffere after 10 + 16 characters",
			"\"…ckADifferenceAtTheEnd")]
		public async Task
			ShouldFallbackTo20CharactersIfNoWordBoundaryCanBeFoundAfterTheMismatchingIndex(
				string expected, string expectedMessagePart)
		{
			string subject =
				"ThisLongTextIsUsedToCheckADifferenceAtTheEndOfThe WordBoundaryAlgorithm";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException().WithMessage($"*{expectedMessagePart}*")
				.AsWildcard();
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
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException()
				.WithMessage($"""
				              Expected subject to
				              be equal to "@startuml{nl}Alice -> Bob :…",
				              but found "@startuml{nl}Alice -> Bob :…" which differs on line 5 and column 16 (index {expectedIndex}):
				                           ↓ (actual)
				                "…-> Bob : Another authentication Request{nl}Alice <-- Bob :…"
				                "…-> Bob : Invalid authentication Request{nl}Alice <-- Bob :…"
				                           ↑ (expected)
				              at Expect.That(subject).Should().Be(expected)
				              """);
		}

		[Theory]
		[InlineData("SomeVeryLongDummyTextWithMore_ThisLongTextIsUsedToCheckADifferenceAtTheEnd after 40 + 5 characters")]
		// ReSharper disable once StringLiteralTypo
		[InlineData("SomeVeryLongDummyTextWithMore_ThisLongTextIsUsedToCheckADifferen after 40 + 15 characters")]
		public async Task
			ShouldLookForAWordBoundaryBetween45And60CharactersAfterTheMismatchingIndexToHighlightTheMismatch(
				string expected)
		{
			string subject =
				"ThisLongTextIsUsedToCheckADifferenceAtTheEndOfThe WordBoundaryAlgorithm";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException().WithMessage("*AtTheEndOfThe…\"*")
				.AsWildcard();
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
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException()
				.WithMessage("*\"…CheckADifferenceInThe*").AsWildcard();
		}

		[Fact]
		public async Task ShouldOnlyAddEllipsisForLongTexts()
		{
			string subject = "this is a long text that differs";
			string expected = "this was too short";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException()
				.WithMessage("*\"this is a long text that…\"*").AsWildcard()
				.And.WithMessage("*\"this was too short\"*").AsWildcard();
		}

		[Fact]
		public async Task WhenBothValuesAreNull_ShouldSucceed()
		{
			string? subject = null;
			string? expected = null;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenBothValuesAreTheSame_ShouldSucceed()
		{
			string subject = "ABC";
			string expected = "ABC";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenStringsAreLong_ShouldHighlightTheDifferences()
		{
			string subject = "this is a long text that differs in between two words and has lot of text afterwards";
			string expected = "this is a long text which differs in between two words and has lot of text afterwards";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException()
				.WithMessage("""
				             Expected subject to
				             be equal to "this is a long text which…",
				             but found "this is a long text that…" which differs at index 20:
				                                ↓ (actual)
				               "…is a long text that differs in between two words and has lot…"
				               "…is a long text which differs in between two words and has…"
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
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException().WithMessage(@"*A\r\nB*A\r\nC*")
				.AsWildcard();
		}

		[Fact]
		public async Task
			WhenTheExpectedStringHasLeadingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = " ABC";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException()
				.WithMessage("*misses some whitespace (\" \" at the beginning)*").AsWildcard();
		}

		[Fact]
		public async Task
			WhenTheExpectedStringHasTrailingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = "ABC  ";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException()
				.WithMessage("*misses some whitespace (\"  \" at the end)*").AsWildcard();
		}

		[Fact]
		public async Task WhenTheExpectedStringIsEmpty_ShouldFailWithDescriptiveMessage()
		{
			string subject = "AB";
			string expected = "";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should()
				.ThrowException()
				.WithMessage("*length of 2 which is longer than the expected length of 0 and has superfluous*\"AB\"*")
				.AsWildcard();
		}

		[Fact]
		public async Task
			WhenTheExpectedStringIsLongerThanTheSubjectString_ShouldFailWithDescriptiveMessage()
		{
			string subject = "AB";
			string expected = "ABC";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should()
				.ThrowException()
				.WithMessage("*length of 2 which is shorter than the expected length of 3 and misses*\"C\"*")
				.AsWildcard();
		}

		[Fact]
		public async Task WhenTheExpectedStringIsNull_ShouldFailWithDescriptiveMessage()
		{
			string subject = "AB";
			string? expected = null;

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException().WithMessage("*equal to <null>*")
				.AsWildcard();
		}

		[Fact]
		public async Task
			WhenTheExpectedStringIsShorterThanTheSubjectString_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = "AB";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should()
				.ThrowException()
				.WithMessage("*length of 3 which is longer than the expected length of 2 and has superfluous*\"C\"*")
				.AsWildcard();
		}

		[Fact]
		public async Task WhenTheStringsDiffer_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = "AXC";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException().WithMessage("*differs at index 1*")
				.AsWildcard();
		}

		[Fact]
		public async Task WhenTheSubjectHasLeadingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "\t ABC";
			string expected = "ABC";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException()
				.WithMessage("*unexpected whitespace (\"\\t \" at the beginning)*").AsWildcard();
		}

		[Fact]
		public async Task WhenTheSubjectHasTrailingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC\t";
			string expected = "ABC";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException()
				.WithMessage("*unexpected whitespace (\"\\t\" at the end)*").AsWildcard();
		}

		[Fact]
		public async Task WhenTheSubjectStringIsEmpty_ShouldFailWithDescriptiveMessage()
		{
			string subject = "";
			string expected = "AB";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should()
				.ThrowException()
				.WithMessage("*length of 0 which is shorter than the expected length of 2 and misses*\"AB\"*")
				.AsWildcard();
		}

		[Fact]
		public async Task WhenTheSubjectStringIsNull_ShouldFailWithDescriptiveMessage()
		{
			string? subject = null;
			string expected = "AB";

			async Task Act()
				=> await That(subject).Should().Be(expected);

			await That(Act).Should().ThrowException().WithMessage("*but found <null>*")
				.AsWildcard();
		}
	}
}
