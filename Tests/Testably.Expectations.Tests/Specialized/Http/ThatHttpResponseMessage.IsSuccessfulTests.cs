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
		//2xx
		[InlineData(HttpStatusCode.OK)]
		[InlineData(HttpStatusCode.Created)]
		[InlineData(HttpStatusCode.Accepted)]
		[InlineData(HttpStatusCode.NonAuthoritativeInformation)]
		[InlineData(HttpStatusCode.NoContent)]
		[InlineData(HttpStatusCode.ResetContent)]
		[InlineData(HttpStatusCode.PartialContent)]
		public async Task WhenStatusCodeIsExpected_ShouldSucceed(HttpStatusCode statusCode)
		{
			HttpResponseMessage sut = ResponseBuilder
				.WithStatusCode(statusCode);

			async Task Act()
				=> await Expect.That(sut).IsSuccessful();

			await Expect.That(Act).DoesNotThrow();
		}

		[Theory]
		//3xx
		[InlineData(HttpStatusCode.MultipleChoices)]
		[InlineData(HttpStatusCode.MovedPermanently)]
		[InlineData(HttpStatusCode.Redirect)]
		[InlineData(HttpStatusCode.SeeOther)]
		[InlineData(HttpStatusCode.NotModified)]
		[InlineData(HttpStatusCode.UseProxy)]
		[InlineData(HttpStatusCode.Unused)]
		[InlineData(HttpStatusCode.TemporaryRedirect)]
		//4xx
		[InlineData(HttpStatusCode.BadRequest)]
		[InlineData(HttpStatusCode.Unauthorized)]
		[InlineData(HttpStatusCode.PaymentRequired)]
		[InlineData(HttpStatusCode.Forbidden)]
		[InlineData(HttpStatusCode.NotFound)]
		[InlineData(HttpStatusCode.MethodNotAllowed)]
		[InlineData(HttpStatusCode.NotAcceptable)]
		[InlineData(HttpStatusCode.ProxyAuthenticationRequired)]
		[InlineData(HttpStatusCode.RequestTimeout)]
		[InlineData(HttpStatusCode.Conflict)]
		[InlineData(HttpStatusCode.Gone)]
		[InlineData(HttpStatusCode.LengthRequired)]
		[InlineData(HttpStatusCode.PreconditionFailed)]
		[InlineData(HttpStatusCode.RequestEntityTooLarge)]
		[InlineData(HttpStatusCode.RequestUriTooLong)]
		[InlineData(HttpStatusCode.UnsupportedMediaType)]
		[InlineData(HttpStatusCode.RequestedRangeNotSatisfiable)]
		[InlineData(HttpStatusCode.ExpectationFailed)]
		//5xx
		[InlineData(HttpStatusCode.InternalServerError)]
		[InlineData(HttpStatusCode.NotImplemented)]
		[InlineData(HttpStatusCode.BadGateway)]
		[InlineData(HttpStatusCode.ServiceUnavailable)]
		[InlineData(HttpStatusCode.GatewayTimeout)]
		[InlineData(HttpStatusCode.HttpVersionNotSupported)]
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
