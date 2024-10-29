namespace Testably.Expectations.Tests.That.Strings;

public sealed partial class StringShould
{
	public class StartWithTests
	{
		[Theory]
		[InlineData(false)]
		[InlineData(true)]
		public async Task
			IgnoringCase_WhenSubjectStartsWithDifferentCase_ShouldFailUnlessCaseIsIgnored(
				bool ignoreCase)
		{
			string subject = "some arbitrary text";
			string expected = "SOME";

			async Task Act()
				=> await Expect.That(subject).Should().StartWith(expected)
					.IgnoringCase(ignoreCase);

			await Expect.That(Act).Should().Throw<XunitException>()
				.OnlyIf(!ignoreCase)
				.WithMessage("""
				             Expected subject to
				             start with "SOME",
				             but found "some arbitrary text"
				             at Expect.That(subject).Should().StartWith(expected).IgnoringCase(ignoreCase)
				             """);
		}

		[Fact]
		public async Task
			IgnoringCase_WhenSubjectStartsWithDifferentString_ShouldIncludeIgnoringCaseInMessage()
		{
			string subject = "some arbitrary text";
			string expected = "TEXT";

			async Task Act()
				=> await Expect.That(subject).Should().StartWith(expected).IgnoringCase();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             start with "TEXT" ignoring case,
				             but found "some arbitrary text"
				             at Expect.That(subject).Should().StartWith(expected).IgnoringCase()
				             """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectStartsWithIncorrectMatchAccordingToComparer_ShouldIncludeComparerInMessage()
		{
			string subject = "some arbitrary text";
			string expected = "SOME";

			async Task Act()
				=> await Expect.That(subject).Should().StartWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             start with "SOME" using IgnoreCaseForVocalsComparer,
				             but found "some arbitrary text"
				             at Expect.That(subject).Should().StartWith(expected).Using(new IgnoreCaseForVocalsComparer())
				             """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectStartsWithMatchAccordingToComparer_ShouldSucceed()
		{
			string subject = "some arbitrary text";
			string expected = "sOmE";

			async Task Act()
				=> await Expect.That(subject).Should().StartWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesNotStartWithExpected_ShouldFail()
		{
			string subject = "some arbitrary text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).Should().StartWith(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             start with "text",
				             but found "some arbitrary text"
				             at Expect.That(subject).Should().StartWith(expected)
				             """);
		}

		[Fact]
		public async Task WhenSubjectStartsWithExpected_ShouldSucceed()
		{
			string subject = "some arbitrary text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).Should().StartWith(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public class NotStartWithTests
	{
		[Fact]
		public async Task IgnoringCase_WhenSubjectDoesNotStartWithWithExpected_ShouldSucceed()
		{
			string subject = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).Should().NotStartWith(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task IgnoringCase_WhenSubjectDoesStartWithExpected_ShouldFail()
		{
			string subject = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).Should().NotStartWith(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not start with "some",
				             but found "some text"
				             at Expect.That(subject).Should().NotStartWith(expected)
				             """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectDoesNotStartWithWithExpected_ShouldSucceed()
		{
			string subject = "some arbitrary text";
			string expected = "SOME";

			async Task Act()
				=> await Expect.That(subject).Should().NotStartWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task
			Using_WhenSubjectDoesStartWithExpected_ShouldFail()
		{
			string subject = "some arbitrary text";
			string expected = "sOmE";

			async Task Act()
				=> await Expect.That(subject).Should().NotStartWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not start with "sOmE" using IgnoreCaseForVocalsComparer,
				             but found "some arbitrary text"
				             at Expect.That(subject).Should().NotStartWith(expected).Using(new IgnoreCaseForVocalsComparer())
				             """);
		}

		[Fact]
		public async Task WhenSubjectDoesNotStartWithExpected_ShouldSucceed()
		{
			string subject = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).Should().NotStartWith(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesStartWithExpected_ShouldFail()
		{
			string subject = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).Should().NotStartWith(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				             Expected subject to
				             not start with "some",
				             but found "some text"
				             at Expect.That(subject).Should().NotStartWith(expected)
				             """);
		}
	}
}
