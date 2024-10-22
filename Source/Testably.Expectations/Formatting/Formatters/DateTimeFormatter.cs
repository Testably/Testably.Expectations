using System;
using System.Text;
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Formatting.Formatters;

internal class DateTimeFormatter : FormatterBase<DateTime>
{
	/// <inheritdoc />
	public override void Format(DateTime value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value.ToString("o"));
	}
}
