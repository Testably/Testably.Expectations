using System.Net;
using System.Text;

namespace Testably.Expectations.Core.Formatting.Formatters;

internal class HttpStatusCodeFormatter : FormatterBase<HttpStatusCode>
{
	/// <inheritdoc />
	public override void Format(HttpStatusCode value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append($"{(int)value} {value}");
	}
}
