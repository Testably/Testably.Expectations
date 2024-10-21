#if !NETSTANDARD2_0
using System;
using System.Text;

namespace Testably.Expectations.Core.Formatting.Formatters;

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
