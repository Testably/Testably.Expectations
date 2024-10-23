#if NET6_0_OR_GREATER
using System.Net;
using System.Net.Http;

namespace Testably.Expectations.Tests.That.Http;

public sealed partial class ThatHttpResponseMessage
{
	public sealed class HasStatusCodeTests
	{
		[Fact]
		public async Task WhenFailing_ShouldIncludeRequestInMessage()
		{
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(HttpStatusCode.BadRequest)
				.WithContent("some content")
				.WithRequest(HttpMethod.Get, "https://example.com")
				.WithRequestContent("request content");

			async Task Act()
				=> await Expect.That(subject).Should().HasStatusCode(HttpStatusCode.OK);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  has StatusCode 200 OK,
				                  but found 400 BadRequest:
				                    HTTP/1.1 400 BadRequest
				                    some content
				                    The originating request was:
				                      GET https://example.com/ HTTP 1.1
				                      request content
				                  at Expect.That(subject).Should().HasContent(HttpStatusCode.OK)
				                  """);
		}

		[Fact]
		public async Task WhenFailing_ShouldIncludeResponseContentAndStatusCodeInMessage()
		{
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(HttpStatusCode.BadRequest)
				.WithContent("some content");

			async Task Act()
				=> await Expect.That(subject).Should().HasStatusCode(HttpStatusCode.OK);

			await Expect.That(Act).Should().Throws<XunitException>()
				.Which.HasMessage("""
				                  Expected subject to
				                  has StatusCode 200 OK,
				                  but found 400 BadRequest:
				                    HTTP/1.1 400 BadRequest
				                    some content
				                    The originating request was <null>
				                  at Expect.That(subject).Should().HasContent(HttpStatusCode.OK)
				                  """);
		}

		[Fact]
		public async Task WhenStatusCodeDiffersFromExpected_ShouldFail()
		{
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(HttpStatusCode.BadRequest);

			async Task Act()
				=> await Expect.That(subject).Should().HasStatusCode(HttpStatusCode.OK);

			await Expect.That(Act).Should().Throws<XunitException>();
		}

		[Theory]
		[MemberData(nameof(SuccessStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(RedirectStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(ClientErrorStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(ServerErrorStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		public async Task WhenStatusCodeIsExpected_ShouldSucceed(HttpStatusCode statusCode)
		{
			HttpStatusCode expected = statusCode;
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(subject).Should().HasStatusCode(expected);

			await Expect.That(Act).Should().DoesNotThrow();
		}
	}
}
#endif
