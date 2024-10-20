using System;
using System.Text;

namespace Testably.Expectations.Core.Formatting.Formatters;

internal class NumberFormatter<T> : FormatterBase<T>
	where T : struct, IComparable<T>
{
	/// <inheritdoc />
	public override void Format(T value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value.ToString());
	}
}
