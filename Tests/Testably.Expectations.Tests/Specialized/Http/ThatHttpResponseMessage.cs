using System.Net;
using System.Net.Http;

namespace Testably.Expectations.Tests.Specialized.Http;

public sealed partial class ThatHttpResponseMessage
{
	private static HttpResponseMessage Create(string content,
		HttpStatusCode statusCode = HttpStatusCode.OK)
	{
		HttpResponseMessage httpResponseMessage = new HttpResponseMessage(statusCode);
		httpResponseMessage.Content = new StringContent(content);
		return httpResponseMessage;
	}
}
