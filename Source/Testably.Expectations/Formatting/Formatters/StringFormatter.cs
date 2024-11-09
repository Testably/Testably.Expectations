using System.Text;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Formatting.Formatters;

internal class StringFormatter : FormatterBase<string>
{
	/// <inheritdoc />
	public override void Format(string value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append('\"');
		if (options.UseLineBreaks)
		{
			stringBuilder.Append(value);
		}
		else
		{
			stringBuilder.Append(value.DisplayWhitespace().TruncateWithEllipsis(100));
		}
		stringBuilder.Append('\"');
	}
}
