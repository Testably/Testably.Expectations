﻿namespace Testably.Expectations.Tests.That.Strings;

public sealed partial class StringShould
{
	public class EndWithTests
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
				=> await Expect.That(subject).Should().EndWith(expected).IgnoringCase(ignoreCase);

			await Expect.That(Act).Should().Throw<XunitException>()
				.OnlyIf(!ignoreCase)
				.Which.HaveMessage("""
				                  Expected subject to
				                  end with "TEXT",
				                  but found "some arbitrary text"
				                  at Expect.That(subject).Should().EndWith(expected).IgnoringCase(ignoreCase)
				                  """);
		}

		[Fact]
		public async Task
			IgnoringCase_WhenSubjectEndsWithDifferentString_ShouldIncludeIgnoringCaseInMessage()
		{
			string subject = "some arbitrary text";
			string expected = "SOME";

			async Task Act()
				=> await Expect.That(subject).Should().EndWith(expected).IgnoringCase();

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  end with "SOME" ignoring case,
				                  but found "some arbitrary text"
				                  at Expect.That(subject).Should().EndWith(expected).IgnoringCase()
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectEndsWithIncorrectMatchAccordingToComparer_ShouldIncludeComparerInMessage()
		{
			string subject = "some arbitrary text";
			string expected = "TEXT";

			async Task Act()
				=> await Expect.That(subject).Should().EndWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  end with "TEXT" using IgnoreCaseForVocalsComparer,
				                  but found "some arbitrary text"
				                  at Expect.That(subject).Should().EndWith(expected).Using(new IgnoreCaseForVocalsComparer())
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectEndsWithMatchAccordingToComparer_ShouldSucceed()
		{
			string subject = "some arbitrary text";
			string expected = "tExt";

			async Task Act()
				=> await Expect.That(subject).Should().EndWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesNotEndWithExpected_ShouldFail()
		{
			string subject = "some arbitrary text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).Should().EndWith(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  end with "some",
				                  but found "some arbitrary text"
				                  at Expect.That(subject).Should().EndWith(expected)
				                  """);
		}

		[Fact]
		public async Task WhenSubjectEndsWithExpected_ShouldSucceed()
		{
			string subject = "some arbitrary text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).Should().EndWith(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public class NotEndWithTests
	{
		[Fact]
		public async Task IgnoringCase_WhenSubjectDoesEndWithExpected_ShouldFail()
		{
			string subject = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).Should().NotEndWith(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  not end with "text",
				                  but found "some text"
				                  at Expect.That(subject).Should().NotEndWith(expected)
				                  """);
		}

		[Fact]
		public async Task IgnoringCase_WhenSubjectDoesNotEndWithWithExpected_ShouldSucceed()
		{
			string subject = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).Should().NotEndWith(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task
			Using_WhenSubjectDoesEndWithExpected_ShouldFail()
		{
			string subject = "some arbitrary text";
			string expected = "tExt";

			async Task Act()
				=> await Expect.That(subject).Should().NotEndWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  not end with "tExt" using IgnoreCaseForVocalsComparer,
				                  but found "some arbitrary text"
				                  at Expect.That(subject).Should().NotEndWith(expected).Using(new IgnoreCaseForVocalsComparer())
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectDoesNotEndWithWithExpected_ShouldSucceed()
		{
			string subject = "some arbitrary text";
			string expected = "TEXT";

			async Task Act()
				=> await Expect.That(subject).Should().NotEndWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesEndWithExpected_ShouldFail()
		{
			string subject = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).Should().NotEndWith(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HaveMessage("""
				                  Expected subject to
				                  not end with "text",
				                  but found "some text"
				                  at Expect.That(subject).Should().NotEndWith(expected)
				                  """);
		}

		[Fact]
		public async Task WhenSubjectDoesNotEndWithWithExpected_ShouldSucceed()
		{
			string subject = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).Should().NotEndWith(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}