#if NET6_0_OR_GREATER
using System.Net.Http;

namespace Testably.Expectations.Tests.That.Http;

public sealed partial class ThatHttpResponseMessage
{
	public sealed class HasContentTests
	{
		[Fact]
		public async Task WhenContentDiffersFromExpected_ShouldFail()
		{
			string expected = "other content";
			HttpResponseMessage subject = ResponseBuilder
				.WithContent("some content");

			async Task Act()
				=> await Expect.That(subject).Should().HasContent(expected);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected that subject
				                  has a string content equal to "other content",
				                  but found "some content" which differs at index 0:
				                     ↓ (actual)
				                    "some content"
				                    "other content"
				                     ↑ (expected)
				                  at Expect.That(subject).Should().HasContent(expected)
				                  """);
		}

		[Fact]
		public async Task WhenContentEqualsExpected_ShouldSucceed()
		{
			string expected = "some content";
			HttpResponseMessage subject = ResponseBuilder
				.WithContent(expected);

			async Task Act()
				=> await Expect.That(subject).Should().HasContent(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
#endif
