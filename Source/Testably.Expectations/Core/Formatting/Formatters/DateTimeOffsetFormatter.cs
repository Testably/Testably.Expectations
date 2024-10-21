using System;
using System.Text;

namespace Testably.Expectations.Core.Formatting.Formatters;

internal class DateTimeOffsetFormatter : FormatterBase<DateTimeOffset>
{
	/// <inheritdoc />
	public override void Format(DateTimeOffset value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value.ToString("o"));
	}
}
