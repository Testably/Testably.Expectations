namespace Testably.Expectations.Tests.Primitives.Strings;

public sealed partial class ThatString
{
	public class EndsWithTests
	{
		[Fact]
		public async Task WhenSubjectEndsWithExpected_ShouldSucceed()
		{
			string actual = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(actual).EndsWith(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesNotEndWithExpected_ShouldFail()
		{
			string actual = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(actual).EndsWith(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  ends with "some",
				                  but found "some text"
				                  at Expect.That(actual).EndsWith(expected)
				                  """);
		}
	}
}
