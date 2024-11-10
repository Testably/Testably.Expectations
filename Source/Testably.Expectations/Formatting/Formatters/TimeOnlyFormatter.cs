#if NET6_0_OR_GREATER
using System;
using System.Text;

namespace Testably.Expectations.Formatting.Formatters;

internal class TimeOnlyFormatter : FormatterBase<TimeOnly>
{
	/// <inheritdoc />
	public override void Format(TimeOnly value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value.ToString("o"));
	}
}
#endif
