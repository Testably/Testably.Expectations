using System.Threading.Tasks;
using Xunit.Sdk;
using Xunit;

namespace Testably.Expectations.Tests.Primitives.Strings;

public sealed partial class ThatString
{
	public class DoesNotEndWithTests
	{
		[Fact]
		public async Task IgnoringCase_WhenSubjectDoesNotEndWithWithExpected_ShouldSucceed()
		{
			string actual = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(actual).DoesNotEndWith(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task IgnoringCase_WhenSubjectDoesEndWithExpected_ShouldFail()
		{
			string actual = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(actual).DoesNotEndWith(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  does not end with "text",
				                  but found "some text"
				                  at Expect.That(actual).DoesNotEndWith(expected)
				                  """);
		}
		[Fact]
		public async Task WhenSubjectDoesNotEndWithWithExpected_ShouldSucceed()
		{
			string actual = "some text";
			string expected = "some";

			async Task Act()
				=> await Expect.That(actual).DoesNotEndWith(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenSubjectDoesEndWithExpected_ShouldFail()
		{
			string actual = "some text";
			string expected = "text";

			async Task Act()
				=> await Expect.That(actual).DoesNotEndWith(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  does not end with "text",
				                  but found "some text"
				                  at Expect.That(actual).DoesNotEndWith(expected)
				                  """);
		}
	}
}
