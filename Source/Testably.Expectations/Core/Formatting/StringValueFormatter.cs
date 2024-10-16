using System.Text;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core.Formatting;

internal class StringValueFormatter : FormatterBase<string>
{
	/// <inheritdoc />
	public override void Format(string value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append('\"');
		stringBuilder.Append(value.TruncateWithEllipsis(100));
		stringBuilder.Append('\"');
	}
}
