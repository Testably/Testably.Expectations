using System;
using System.Text;
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Formatting.Formatters;

internal class DateTimeOffsetFormatter : FormatterBase<DateTimeOffset>
{
	/// <inheritdoc />
	public override void Format(DateTimeOffset value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value.ToString("o"));
	}
}
