namespace Testably.Expectations.Tests.That.Strings;

public sealed partial class ThatString
{
	public class DoesNotStartWithTests
	{
		[Fact]
		public async Task IgnoringCase_WhenSubjectDoesStartWithExpected_ShouldFail()
		{
			string subject = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotStartWith(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  does not start with "some",
				                  but found "some text"
				                  at Expect.That(subject).Should().DoesNotStartWith(expected)
				                  """);
		}

		[Fact]
		public async Task IgnoringCase_WhenSubjectDoesNotStartWithWithExpected_ShouldSucceed()
		{
			string subject = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotStartWith(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task
			Using_WhenSubjectDoesStartWithExpected_ShouldFail()
		{
			string subject = "some arbitrary text";
			string expected = "sOmE";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotStartWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  does not start with "sOmE" using IgnoreCaseForVocalsComparer,
				                  but found "some arbitrary text"
				                  at Expect.That(subject).DoesNotStartWith(expected).Should().Using(new IgnoreCaseForVocalsComparer())
				                  """);
		}

		[Fact]
		public async Task
			Using_WhenSubjectDoesNotStartWithWithExpected_ShouldSucceed()
		{
			string subject = "some arbitrary text";
			string expected = "SOME";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotStartWith(expected)
					.Using(new IgnoreCaseForVocalsComparer());

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesNotStartWithExpected_ShouldSucceed()
		{
			string subject = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotStartWith(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesStartWithExpected_ShouldFail()
		{
			string subject = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(subject).Should().DoesNotStartWith(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  does not start with "some",
				                  but found "some text"
				                  at Expect.That(subject).Should().DoesNotStartWith(expected)
				                  """);
		}
	}
}
