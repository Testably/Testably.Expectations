using System;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Strings;

public sealed partial class ThatString
{
	public class DoesNotContainTests
	{
		[Fact]
		public async Task WhenExpectedStringIsNotContained_ShouldSucceed()
		{
			string actual = "some text";
			string expected = "not";

			async Task Act()
				=> await Expect.That(actual).DoesNotContain(expected);

			await Expect.That(Act).DoesNotThrow();
		}

		[Fact]
		public async Task WhenExpectedStringIsContained_ShouldFail()
		{
			string actual = "some text";
			string expected = "me";

			async Task Act()
				=> await Expect.That(actual).DoesNotContain(expected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  does not contain "me",
				                  but found it 1 times in "some text"
				                  at Expect.That(actual).DoesNotContain(expected)
				                  """);
		}
	}
}
