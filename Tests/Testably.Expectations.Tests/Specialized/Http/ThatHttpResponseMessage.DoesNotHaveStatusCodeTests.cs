﻿#if NET6_0_OR_GREATER
using System.Net;
using System.Net.Http;

namespace Testably.Expectations.Tests.Specialized.Http;

public sealed partial class ThatHttpResponseMessage
{
	public sealed class DoesNotHaveStatusCodeTests
	{
		[Theory]
		[MemberData(nameof(SuccessStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(RedirectStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(ClientErrorStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(ServerErrorStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		public async Task WhenStatusCodeIsUnexpected_ShouldFail(HttpStatusCode statusCode)
		{
			HttpStatusCode unexpected = statusCode;
			HttpResponseMessage sut = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(sut).DoesNotHaveStatusCode(unexpected);

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage(
					"*StatusCode different to*Expect.That(sut).DoesNotHaveStatusCode(unexpected)")
				.AsWildcard();
		}

		[Fact]
		public async Task WhenStatusCodeDiffersFromExpected_ShouldSucceed()
		{
			HttpStatusCode unexpected = HttpStatusCode.OK;
			HttpResponseMessage sut = ResponseBuilder
				.WithStatusCode(HttpStatusCode.BadRequest);

			async Task Act()
				=> await Expect.That(sut).DoesNotHaveStatusCode(unexpected);

			await Expect.That(Act).DoesNotThrow();
		}
	}
}
#endif
