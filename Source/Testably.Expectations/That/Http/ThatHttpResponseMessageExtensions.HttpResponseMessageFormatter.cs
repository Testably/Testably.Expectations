#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Testably.Expectations.Core.Helpers;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatHttpResponseMessageExtensions
{
	private static class HttpResponseMessageFormatter
	{
		public static async Task<string> Format(HttpResponseMessage response, string indentation)
		{
			StringBuilder messageBuilder = new StringBuilder();

			messageBuilder.Append(indentation)
				.Append("HTTP/").Append(response.Version)
				.Append(" ").Append((int)response.StatusCode).Append(" ").Append(response.StatusCode)
				.AppendLine();

			AppendHeaders(messageBuilder, response.Headers, indentation);
			await AppendContent(messageBuilder, response.Content, indentation);

			HttpRequestMessage? request = response.RequestMessage;
			if (request == null)
			{
				messageBuilder.Append(indentation).AppendLine("The originating request was <null>");
			}
			else
			{
				messageBuilder.Append(indentation).AppendLine("The originating request was:");
				messageBuilder.Append(indentation).Append(indentation).Append(request.Method.ToString().ToUpper()).Append(" ")
					.Append(request.RequestUri).Append(" HTTP ").Append(request.Version).AppendLine();

				AppendHeaders(messageBuilder, request.Headers, indentation);
				if (request.Content != null)
				{
					await AppendContent(messageBuilder, request.Content, indentation + indentation);
				}
			}

			return messageBuilder.ToString().TrimEnd();
		}

		private static async Task AppendContent(StringBuilder messageBuilder,
			HttpContent content,
			string indentation)
		{
			if (content is StringContent)
			{
				var stringContent = await content.ReadAsStringAsync();
				messageBuilder.AppendLine(stringContent.Indent(indentation));
			}
			else if (content is FormUrlEncodedContent)
			{
				var stringContent = await content.ReadAsStringAsync();
				messageBuilder.AppendLine(stringContent.Indent(indentation));
			}
			else
			{
				messageBuilder.Append(indentation).AppendLine("Content is binary");
			}
		}

		private static void AppendHeaders(
			StringBuilder messageBuilder,
			HttpHeaders headers,
			string indentation)
		{
			foreach (KeyValuePair<string, IEnumerable<string>> header in headers
				.OrderBy(x => x.Key == "Content-Length"))
			{
				foreach (string headerValue in header.Value)
				{
					messageBuilder.Append(indentation).Append(indentation)
						.Append(header.Key).Append(": ").AppendLine(headerValue);
				}
			}
		}
	}
}
#endif
