using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Xunit.Sdk;

namespace Testably.Expectations.Tests.Specialized.Http;

public sealed partial class ThatHttpResponseMessage
{
	public sealed class IsSuccessfulTests
	{
		[Theory]
		[MemberData(nameof(SuccessStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		public async Task WhenStatusCodeIsExpected_ShouldSucceed(HttpStatusCode statusCode)
		{
			HttpResponseMessage sut = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(sut).IsSuccessful();

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		[MemberData(nameof(RedirectStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(ClientErrorStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		[MemberData(nameof(ServerErrorStatusCodes), MemberType = typeof(ThatHttpResponseMessage))]
		public async Task WhenStatusCodeIsUnexpected_ShouldFail(HttpStatusCode statusCode)
		{
			HttpResponseMessage sut = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(sut).IsSuccessful();

			await Expect.That(Act).Throws<XunitException>()
				.Which.HasMessage(
					"*is successful (status code 2xx)*Expect.That(sut).IsSuccessful()")
				.AsWildcard();
		}
	}
}
