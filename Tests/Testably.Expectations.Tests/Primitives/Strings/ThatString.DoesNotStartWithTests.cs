namespace Testably.Expectations.Tests.Primitives.Strings;

public sealed partial class ThatString
{
	public class DoesNotStartWithTests
	{
		[Fact]
		public async Task WhenSubjectDoesNotStartWithExpected_ShouldSucceed()
		{
			string actual = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(actual).DoesNotStartWith(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesStartWithExpected_ShouldFail()
		{
			string actual = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(actual).DoesNotStartWith(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  does not start with "some",
				                  but found "some text"
				                  at Expect.That(actual).DoesNotStartWith(expected)
				                  """);
		}
	}
}
