using System.Threading.Tasks;
using Testably.Expectations.Tests.TestHelpers;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Core;

public class StringMatcherTests
{
	public class ExactMatch
	{
		[Fact]
		public async Task WhenTheExpectedStringIsLongerThanTheSubjectString_ShouldFailWithDescriptiveMessage()
		{
			string subject = "AB";
			string expected = "ABC";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*length of 2 which is shorter than the expected length of 3*");
		}
		[Fact]
		public async Task WhenTheExpectedStringIsShorterThanTheSubjectString_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = "AB";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*length of 3 which is longer than the expected length of 2*");
		}
		[Fact]
		public async Task WhenTheStringsDiffer_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string expected = "AXC";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*differs at index 1*");
		}

		[Fact]
		public async Task WhenBothValuesAreTheSame_ShouldSucceed()
		{
			string subject = "ABC";
			string expected = "ABC";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenBothValuesAreNull_ShouldSucceed()
		{
			string? subject = null;
			string? expected = null;

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenTheSubjectStringIsEmpty_ShouldFailWithDescriptiveMessage()
		{
			string subject = "";
			string expected = "AB";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*length of 0 which is shorter than the expected length of 2*");
		}

		[Fact]
		public async Task WhenTheExpectedStringIsEmpty_ShouldFailWithDescriptiveMessage()
		{
			string subject = "AB";
			string expected = "";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*length of 2 which is longer than the expected length of 0*");
		}

		[Fact]
		public async Task WhenTheSubjectStringIsNull_ShouldFailWithDescriptiveMessage()
		{
			string? subject = null;
			string expected = "AB";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*but found <null>*");
		}

		[Fact]
		public async Task WhenTheExpectedStringIsNull_ShouldFailWithDescriptiveMessage()
		{
			string subject = "AB";
			string? expected = null;

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*equal to <null>*");
		}

		[Fact]
		public async Task WhenTheSubjectHasTrailingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC	";
			string? expected = "ABC";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*unexpected whitespace at the end*");
		}

		[Fact]
		public async Task WhenTheSubjectHasLeadingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "	 ABC";
			string? expected = "ABC";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*unexpected whitespace at the beginning*");
		}

		[Fact]
		public async Task WhenTheSubjectHasTrailingAndLeadingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = " ABC	";
			string? expected = "ABC";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*differs in whitespace*");
		}

		[Fact]
		public async Task WhenTheExpectedStringHasTrailingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string? expected = "ABC  ";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*misses some whitespace at the end*");
		}

		[Fact]
		public async Task WhenStringsDifferAndAreMultiline_ShouldFailWithNewlinesReplacedInTheMessage()
		{
			string subject = "A\r\nB";
			string? expected = "A\r\nC";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage(@"*A\r\nB*A\r\nC*");
		}

		[Fact]
		public async Task WhenStringsAreLong_ShouldHighlightTheDifferences()
		{
			string subject = "this is a long text that differs in between two words";
			string expected = "this is a long text which differs in between two words";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsException()
				.Which.HasMessage("""
				                  Expected that subject
				                  is equal to "this is a long text which differs in between two words",
				                  but found "this is a long text that differs in between two words" which differs at index 20:
				                                     ↓ (actual)
				                    "…is a long text that…"
				                    "…is a long text which…"
				                                     ↑ (expected)
				                  """);
		}

		[Fact]
		public async Task WhenTheExpectedStringHasLeadingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string? expected = " ABC";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*misses some whitespace at the beginning*");
		}

		[Fact]
		public async Task WhenTheExpectedStringHasTrailingAndLeadingWhitespace_ShouldFailWithDescriptiveMessage()
		{
			string subject = "ABC";
			string? expected = "	ABC ";

			async Task Act()
				=> await Expect.That(subject).Is(expected);

			await Expect.That(Act).ThrowsWithMessage("*differs in whitespace*");
		}
	}
}
