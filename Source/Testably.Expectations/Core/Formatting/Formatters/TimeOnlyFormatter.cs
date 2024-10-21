#if !NETSTANDARD2_0
using System;
using System.Text;

namespace Testably.Expectations.Core.Formatting.Formatters;

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
