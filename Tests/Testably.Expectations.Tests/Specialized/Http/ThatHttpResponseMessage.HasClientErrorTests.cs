#if NET6_0_OR_GREATER
using System.Net;
using System.Net.Http;

namespace Testably.Expectations.Tests.Specialized.Http;

public sealed partial class ThatHttpResponseMessage
{
	public sealed class HasClientErrorTests
	{
		[Theory]
		[MemberData(nameof(ClientErrorStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		public async Task WhenStatusCodeIsExpected_ShouldSucceed(HttpStatusCode statusCode)
		{
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(subject).HasClientError();

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[MemberData(nameof(SuccessStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(RedirectStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(ServerErrorStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		public async Task WhenStatusCodeIsUnexpected_ShouldFail(HttpStatusCode statusCode)
		{
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(subject).HasClientError();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage(
					"*client error (status code 4xx)*Expect.That(subject).HasClientError()")
				.AsWildcard();
		}
	}
}
#endif
