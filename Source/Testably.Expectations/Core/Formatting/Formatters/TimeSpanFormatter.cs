using System;
using System.Text;

namespace Testably.Expectations.Core.Formatting.Formatters;

internal class TimeSpanFormatter : FormatterBase<TimeSpan>
{
	/// <inheritdoc />
	public override void Format(TimeSpan value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value.ToString("g"));
	}
}
