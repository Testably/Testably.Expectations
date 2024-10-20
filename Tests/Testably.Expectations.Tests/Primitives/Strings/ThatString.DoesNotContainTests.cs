using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Primitives.Strings;

public sealed partial class ThatString
{
	public class DoesNotContainTests
	{
		[Fact]
		public async Task IgnoringCase_ShouldIncludeSettingInExpectationText()
		{
			string actual =
				"In this text in between the word an investigator should find the word 'IN' multiple times.";
			string expected = "INVESTIGATOR";

			async Task Act()
				=> await Expect.That(actual).DoesNotContain(expected).IgnoringCase();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that actual
				                  does not contain "INVESTIGATOR" ignoring case,
				                  but found it 1 times in "In this text in between the word an investigator should find the word 'IN' multiple times."
				                  at Expect.That(actual).DoesNotContain(expected).IgnoringCase()
				                  """);
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

		[Fact]
		public async Task WhenExpectedStringIsNotContained_ShouldSucceed()
		{
			string actual = "some text";
			string expected = "not";

			async Task Act()
				=> await Expect.That(actual).DoesNotContain(expected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
