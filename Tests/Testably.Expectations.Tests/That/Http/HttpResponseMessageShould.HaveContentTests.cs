#if NET6_0_OR_GREATER
using System.Net.Http;

namespace Testably.Expectations.Tests.That.Http;

public sealed partial class HttpResponseMessageShould
{
	public sealed class HaveContentTests
	{
		[Fact]
		public async Task WhenContentDiffersFromExpected_ShouldFail()
		{
			string expected = "other content";
			HttpResponseMessage subject = ResponseBuilder
				.WithContent("some content");

			async Task Act()
				=> await Expect.That(subject).Should().HaveContent(expected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				                  Expected subject to
				                  have a string content equal to "other content",
				                  but found "some content" which differs at index 0:
				                     ↓ (actual)
				                    "some content"
				                    "other content"
				                     ↑ (expected)
				                  at Expect.That(subject).Should().HaveContent(expected)
				                  """);
		}

		[Fact]
		public async Task WhenContentEqualsExpected_ShouldSucceed()
		{
			string expected = "some content";
			HttpResponseMessage subject = ResponseBuilder
				.WithContent(expected);

			async Task Act()
				=> await Expect.That(subject).Should().HaveContent(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}
}
#endif
