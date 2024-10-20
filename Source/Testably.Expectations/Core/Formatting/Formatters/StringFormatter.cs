using System.Text;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core.Formatting.Formatters;

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
