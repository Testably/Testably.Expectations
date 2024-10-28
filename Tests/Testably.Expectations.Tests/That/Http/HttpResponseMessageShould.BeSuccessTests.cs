#if NET6_0_OR_GREATER
using System.Net;
using System.Net.Http;

namespace Testably.Expectations.Tests.That.Http;

public sealed partial class HttpResponseMessageShould
{
	public sealed class BeSuccessTests
	{
		[Theory]
		[MemberData(nameof(SuccessStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		public async Task WhenStatusCodeIsExpected_ShouldSucceed(HttpStatusCode statusCode)
		{
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(subject).Should().BeSuccess();

			await Expect.That(Act).Should().NotThrow();
		}

		[Theory]
		[MemberData(nameof(RedirectStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		[MemberData(nameof(ClientErrorStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		[MemberData(nameof(ServerErrorStatusCodes), MemberType = typeof(HttpResponseMessageShould))]
		public async Task WhenStatusCodeIsUnexpected_ShouldFail(HttpStatusCode statusCode)
		{
			HttpResponseMessage subject = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(subject).Should().BeSuccess();

			await Expect.That(Act).Should().Throw<XunitException>()
				.WithMessage(
					"*be success (status code 2xx)*Expect.That(subject).Should().BeSuccess()")
				.AsWildcard();
		}
	}
}
#endif
