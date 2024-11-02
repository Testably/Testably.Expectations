using System;
using System.Text;

namespace Testably.Expectations.Formatting.Formatters;

internal class NumberFormatter<T>(Func<T, string> formatter) : FormatterBase<T>
	where T : struct, IComparable<T>
{
	/// <inheritdoc />
	public override void Format(T value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(formatter(value));
	}
}

internal class NumberFormatter : IValueFormatter
{
	#region IValueFormatter Members

	/// <inheritdoc />
	public bool TryFormat(object value, StringBuilder stringBuilder, FormattingOptions options)
	{
		if (value is nint nint)
		{
			stringBuilder.Append(nint.ToString());
			return true;
		}

		if (value is nuint nuint)
		{
			stringBuilder.Append(nuint.ToString());
			return true;
		}

		return false;
	}

	#endregion
}
