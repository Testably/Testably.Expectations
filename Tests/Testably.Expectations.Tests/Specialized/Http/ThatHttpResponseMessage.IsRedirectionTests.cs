﻿#if NET6_0_OR_GREATER
using System.Net;
using System.Net.Http;

namespace Testably.Expectations.Tests.Specialized.Http;

public sealed partial class ThatHttpResponseMessage
{
	public sealed class IsRedirectionTests
	{
		[Theory]
		[MemberData(nameof(RedirectStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		public async Task WhenStatusCodeIsExpected_ShouldSucceed(HttpStatusCode statusCode)
		{
			HttpResponseMessage sut = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(sut).IsRedirection();

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[MemberData(nameof(SuccessStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(ClientErrorStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(ServerErrorStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		public async Task WhenStatusCodeIsUnexpected_ShouldFail(HttpStatusCode statusCode)
		{
			HttpResponseMessage sut = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(sut).IsRedirection();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage(
					"*is redirection (status code 3xx)*Expect.That(sut).IsRedirection()")
				.AsWildcard();
		}
	}
}
#endif
