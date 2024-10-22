using System.Text;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Formatting.Formatters;

internal class StringFormatter : FormatterBase<string>
{
	/// <inheritdoc />
	public override void Format(string value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append('\"');
		stringBuilder.Append(value.ToSingleLineIf(!options.UseLineBreaks));
		stringBuilder.Append('\"');
	}
}
