#if NET6_0_OR_GREATER
using System.Net;
using System.Net.Http;

namespace Testably.Expectations.Tests.That.Http;

public sealed partial class HttpResponseMessageShould
{
	public sealed class HaveStatusCodeTests
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
				=> await Expect.That(subject).Should().HaveStatusCode(HttpStatusCode.OK);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				                  Expected subject to
				                  have StatusCode 200 OK,
				                  but found 400 BadRequest:
				                    HTTP/1.1 400 BadRequest
				                    some content
				                    The originating request was:
				                      GET https://example.com/ HTTP 1.1
				                      request content
				                  at Expect.That(subject).Should().HaveContent(HttpStatusCode.OK)
				                  """);
		}

		[Fact]
		public async Task WhenFailing_ShouldIncludeResponseContentAndStatusCodeInMessage()
		{
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(HttpStatusCode.BadRequest)
				.WithContent("some content");

			async Task Act()
				=> await Expect.That(subject).Should().HaveStatusCode(HttpStatusCode.OK);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage("""
				                  Expected subject to
				                  have StatusCode 200 OK,
				                  but found 400 BadRequest:
				                    HTTP/1.1 400 BadRequest
				                    some content
				                    The originating request was <null>
				                  at Expect.That(subject).Should().HaveContent(HttpStatusCode.OK)
				                  """);
		}

		[Fact]
		public async Task WhenStatusCodeDiffersFromExpected_ShouldFail()
		{
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(HttpStatusCode.BadRequest);

			async Task Act()
				=> await Expect.That(subject).Should().HaveStatusCode(HttpStatusCode.OK);

			await Expect.That(Act).Should().Throw<XunitException>();
		}

		[Theory]
		[MemberData(nameof(SuccessStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		[MemberData(nameof(RedirectStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		[MemberData(nameof(ClientErrorStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		[MemberData(nameof(ServerErrorStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		public async Task WhenStatusCodeIsExpected_ShouldSucceed(HttpStatusCode statusCode)
		{
			HttpStatusCode expected = statusCode;
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(subject).Should().HaveStatusCode(expected);

			await Expect.That(Act).Should().NotThrow();
		}
	}

	public sealed class NotHaveStatusCodeTests
	{
		[Fact]
		public async Task WhenStatusCodeDiffersFromExpected_ShouldSucceed()
		{
			HttpStatusCode unexpected = HttpStatusCode.OK;
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(HttpStatusCode.BadRequest);

			async Task Act()
				=> await Expect.That(subject).Should().NotHaveStatusCode(unexpected);

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[MemberData(nameof(SuccessStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		[MemberData(nameof(RedirectStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		[MemberData(nameof(ClientErrorStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		[MemberData(nameof(ServerErrorStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		public async Task WhenStatusCodeIsUnexpected_ShouldFail(HttpStatusCode statusCode)
		{
			HttpStatusCode unexpected = statusCode;
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(subject).Should().NotHaveStatusCode(unexpected);

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage(
					"*StatusCode different to*Expect.That(subject).Should().NotHaveStatusCode(unexpected)")
				.AsWildcard();
		}
	}
}
#endif
