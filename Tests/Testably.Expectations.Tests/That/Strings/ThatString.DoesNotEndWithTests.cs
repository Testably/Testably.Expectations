namespace Testably.Expectations.Tests.That.Strings;

public sealed partial class ThatString
{
	public class DoesNotEndWithTests
	{
		[Fact]
		public async Task IgnoringCase_WhenSubjectDoesEndWithExpected_ShouldFail()
		{
			string subject = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotEndWith(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  does not end with "text",
				                  but found "some text"
				                  at Expect.That(subject).Should().DoesNotEndWith(expected)
				                  """);
		}

		[Fact]
		public async Task IgnoringCase_WhenSubjectDoesNotEndWithWithExpected_ShouldSucceed()
		{
			string subject = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotEndWith(expected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task
			Using_WhenSubjectDoesEndWithExpected_ShouldFail()
		{
			string subject = "some arbitrary text";
			string expected = "tExt";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotEndWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  does not end with "tExt" using IgnoreCaseForVocalsComparer,
				                  but found "some arbitrary text"
				                  at Expect.That(subject).DoesNotEndWith(expected).Should().Using(new IgnoreCaseForVocalsComparer())
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectDoesNotEndWithWithExpected_ShouldSucceed()
		{
			string subject = "some arbitrary text";
			string expected = "TEXT";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotEndWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().NotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesEndWithExpected_ShouldFail()
		{
			string subject = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotEndWith(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  does not end with "text",
				                  but found "some text"
				                  at Expect.That(subject).Should().DoesNotEndWith(expected)
				                  """);
		}

		[Fact]
		public async Task WhenSubjectDoesNotEndWithWithExpected_ShouldSucceed()
		{
			string subject = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotEndWith(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
