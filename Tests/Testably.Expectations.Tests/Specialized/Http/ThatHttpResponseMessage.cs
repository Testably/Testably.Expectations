using System;
using System.Net;
using System.Net.Http;

namespace Testably.Expectations.Tests.Specialized.Http;

public sealed partial class ThatHttpResponseMessage
{
	private static HttpResponseBuilder ResponseBuilder => new();

	private class HttpResponseBuilder
	{
		private HttpContent? _content;
		private HttpRequestBuilder? _requestBuilder;
		private HttpStatusCode _statusCode = HttpStatusCode.OK;

		/// <summary>
		///     Implicitly converts the <paramref name="builder" /> to a <see cref="HttpResponseMessage" />.
		/// </summary>
		public static implicit operator HttpResponseMessage(HttpResponseBuilder builder)
			=> builder.Build();

		public HttpRequestBuilder WithRequest(HttpMethod method, string uri)
		{
			_requestBuilder = new HttpRequestBuilder(this, method, uri);
			return _requestBuilder;
		}

		public HttpResponseBuilder WithStatusCode(HttpStatusCode statusCode)
		{
			_statusCode = statusCode;
			return this;
		}

		public HttpResponseBuilder WithContent(string content)
		{
			_content = new StringContent(content);
			return this;
		}

		private HttpResponseMessage Build()
		{
			HttpResponseMessage httpResponseMessage = new();
			httpResponseMessage.StatusCode = _statusCode;
			httpResponseMessage.Content = _content ?? new StringContent("");
			if (_requestBuilder != null)
			{
				httpResponseMessage.RequestMessage = _requestBuilder;
			}

			return httpResponseMessage;
		}

		public class HttpRequestBuilder
		{
			private HttpContent? _content;
			private readonly HttpMethod _method;
			private readonly HttpResponseBuilder _responseBuilder;
			private readonly string _uri;

			public HttpRequestBuilder(HttpResponseBuilder responseBuilder, HttpMethod method,
				string uri)
			{
				_responseBuilder = responseBuilder;
				_method = method;
				_uri = uri;
			}

			/// <summary>
			///     Implicitly converts the <paramref name="builder" /> to a <see cref="HttpResponseMessage" />.
			/// </summary>
			public static implicit operator HttpRequestMessage(HttpRequestBuilder builder)
				=> builder.Build();

			/// <summary>
			///     Implicitly converts the <paramref name="builder" /> to a <see cref="HttpResponseMessage" />.
			/// </summary>
			public static implicit operator HttpResponseMessage(HttpRequestBuilder builder)
				=> builder._responseBuilder.Build();

			public HttpRequestBuilder WithRequestContent(string content)
			{
				_content = new StringContent(content);
				return this;
			}

			private HttpRequestMessage Build()
			{
				HttpRequestMessage httpResponseMessage = new();
				httpResponseMessage.Method = _method;
				httpResponseMessage.RequestUri = new Uri(_uri);
				httpResponseMessage.Content = _content;
				return httpResponseMessage;
			}
		}
	}
}
