#if NET6_0_OR_GREATER
using System;
using System.Text;

namespace Testably.Expectations.Formatting.Formatters;

internal class DateOnlyFormatter : FormatterBase<DateOnly>
{
	/// <inheritdoc />
	public override void Format(DateOnly value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value.ToString("o"));
	}
}
#endif
