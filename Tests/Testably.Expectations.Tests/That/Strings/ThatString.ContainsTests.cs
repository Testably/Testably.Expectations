﻿namespace Testably.Expectations.Tests.That.Strings;

public sealed partial class ThatString
{
	public class ContainsTests
	{
		[Fact]
		public async Task AtLeast_WhenExpectedStringOccursEnoughTimes_ShouldSucceed()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).AtLeast(3);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task AtLeast_WhenExpectedStringOccursFewerTimes_ShouldFail()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).AtLeast(5);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "in" at least 5 times,
				                  but found it 3 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).AtLeast(5)
				                  """);
		}

		[Fact]
		public async Task AtLeast_WhenExpectedStringOccursNever_ShouldFail()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "text that does not occur";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).AtLeast(1);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "text that does not occur" at least once,
				                  but found it 0 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).AtLeast(1)
				                  """);
		}

		[Fact]
		public async Task AtLeast_WhenMinimumIsLessThanZero_ShouldThrowArgumentOutOfRangeException()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).AtLeast(-1);

			await Expect.That(Act).ThrowsExactly<ArgumentOutOfRangeException>().Which
				.HasMessage("*'minimum'*").AsWildcard().And
				.HasParamName("minimum");
		}

		[Fact]
		public async Task AtMost_WhenExpectedStringOccursMoreTimes_ShouldFail()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).AtMost(2);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "in" at most 2 times,
				                  but found it 3 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).AtMost(2)
				                  """);
		}

		[Fact]
		public async Task AtMost_WhenExpectedStringOccursNever_ShouldSucceed()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "text that does not occur";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).AtMost(1);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task AtMost_WhenExpectedStringSufficientlyFewTimes_ShouldSucceed()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).AtMost(3);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task AtMost_WhenMaximumIsLessThanZero_ShouldThrowArgumentOutOfRangeException()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).AtMost(-1);

			await Expect.That(Act).ThrowsExactly<ArgumentOutOfRangeException>().Which
				.HasMessage("*'maximum'*").AsWildcard().And
				.HasParamName("maximum");
		}

		[Fact]
		public async Task Between_WhenExpectedStringOccursFewerTimes_ShouldFail()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Between(4).And(9);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "in" between 4 and 9 times,
				                  but found it 3 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).Between(4).And(9)
				                  """);
		}

		[Fact]
		public async Task Between_WhenExpectedStringOccursMoreTimes_ShouldFail()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Between(1).And(2);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "in" between 1 and 2 times,
				                  but found it 3 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).Between(1).And(2)
				                  """);
		}

		[Fact]
		public async Task Between_WhenExpectedStringOccursSufficientTimes_ShouldSucceed()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Between(1).And(4);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Between_WhenMaximumIsLessThanZero_ShouldThrowArgumentOutOfRangeException()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Between(1).And(-3);

			await Expect.That(Act).ThrowsExactly<ArgumentOutOfRangeException>().Which
				.HasMessage("*'maximum'*").AsWildcard().And
				.HasParamName("maximum");
		}

		[Fact]
		public async Task Between_WhenMinimumEqualsMaximum_ShouldBehaveLikeExactly()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Between(3).And(3);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Between_WhenMinimumIsGreaterThanMaximum_ShouldThrowArgumentException()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Between(4).And(3);

			await Expect.That(Act).ThrowsExactly<ArgumentException>().Which
				.HasMessage("*'maximum'*greater*'minimum'*").AsWildcard();
		}

		[Fact]
		public async Task Between_WhenMinimumIsLessThanZero_ShouldThrowArgumentOutOfRangeException()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Between(-1).And(3);

			await Expect.That(Act).ThrowsExactly<ArgumentOutOfRangeException>().Which
				.HasMessage("*'minimum'*").AsWildcard().And
				.HasParamName("minimum");
		}

		[Fact]
		public async Task
			Exactly_WhenExpectedIsLessThanZero_ShouldThrowArgumentOutOfRangeException()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Exactly(-1);

			await Expect.That(Act).ThrowsExactly<ArgumentOutOfRangeException>().Which
				.HasMessage("*'expected'*").AsWildcard().And
				.HasParamName("expected");
		}

		[Fact]
		public async Task Exactly_WhenExpectedStringOccursCorrectlyOften_ShouldSucceed()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Exactly(3);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Exactly_WhenExpectedStringOccursFewerTimes_ShouldFail()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Exactly(4);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "in" exactly 4 times,
				                  but found it 3 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).Exactly(4)
				                  """);
		}

		[Fact]
		public async Task Exactly_WhenExpectedStringOccursMoreTimes_ShouldFail()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Exactly(2);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "in" exactly 2 times,
				                  but found it 3 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).Exactly(2)
				                  """);
		}

		[Fact]
		public async Task IgnoringCase_ShouldIncludeSettingInExpectationText()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).AtLeast(7).IgnoringCase();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "in" at least 7 times ignoring case,
				                  but found it 5 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).AtLeast(7).IgnoringCase()
				                  """);
		}

		[Fact]
		public async Task
			IgnoringCase_WhenExpectedStringOccursEnoughTimesCaseInsensitive_ShouldSucceed()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).AtLeast(5).IgnoringCase();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Never_WhenExpectedStringDoesNotOccur_ShouldSucceed()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "detective";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Never();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Never_WhenExpectedStringOccursMoreTimes_ShouldFail()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "investigator";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Never();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  does not contain "investigator",
				                  but found it 1 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).Never()
				                  """);
		}

		[Fact]
		public async Task Once_WhenExpectedStringOccursExactly1Times_ShouldSucceed()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "investigator";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Once();

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task Once_WhenExpectedStringOccursFewerTimes_ShouldFail()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "detective";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Once();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "detective" exactly once,
				                  but found it 0 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).Once()
				                  """);
		}

		[Fact]
		public async Task Once_WhenExpectedStringOccursMoreTimes_ShouldFail()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "word";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Once();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "word" exactly once,
				                  but found it 2 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).Once()
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenExpectedStringOccursEnoughTimesForTheComparer_ShouldSucceed()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Exactly(4)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task
			Using_WhenExpectedStringOccursIncorrectTimesForTheComparer_ShouldIncludeComparerInMessage()
		{
			string subject =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "in";

			async Task Act()
				=> await Expect.That(subject).Contains(expected).Exactly(5)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "in" exactly 5 times using IgnoreCaseForVocalsComparer,
				                  but found it 4 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(subject).Contains(expected).Exactly(5).Using(new IgnoreCaseForVocalsComparer())
				                  """);
		}

		[Fact]
		public async Task WhenExpectedStringIsContained_ShouldSucceed()
		{
			string subject = "some text";
			string expected = "me";

			async Task Act()
				=> await Expect.That(subject).Contains(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenExpectedStringIsNotContained_ShouldFail()
		{
			string subject = "some text";
			string expected = "not";

			async Task Act()
				=> await Expect.That(subject).Contains(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  contains "not" at least once,
				                  but found it 0 times in "some text"
				                  at Expect.That(subject).Contains(expected)
				                  """);
		}
	}
}
