using System;
using System.Text;

namespace Testably.Expectations.Formatting.Formatters;

internal class TimeSpanFormatter : FormatterBase<TimeSpan>
{
	/// <inheritdoc />
	public override void Format(TimeSpan value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		string formatString;
		if (value.Days != 0)
		{
			formatString = @"d\.hh\:mm\:ss";
		}
		else if (value.Hours != 0)
		{
			formatString = @"h\:mm\:ss";
		}
		else
		{
			formatString = @"m\:ss";
		}

		if (value.Milliseconds > 0)
		{
			formatString += @"\.fff";
		}

		if (value < TimeSpan.Zero)
		{
			stringBuilder.Append('-');
		}

		stringBuilder.Append(value.ToString(formatString));
	}
}
