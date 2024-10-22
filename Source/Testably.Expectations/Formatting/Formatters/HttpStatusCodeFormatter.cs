using System.Net;
using System.Text;
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Formatting.Formatters;

internal class HttpStatusCodeFormatter : FormatterBase<HttpStatusCode>
{
	/// <inheritdoc />
	public override void Format(HttpStatusCode value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append($"{(int)value} {value}");
	}
}
