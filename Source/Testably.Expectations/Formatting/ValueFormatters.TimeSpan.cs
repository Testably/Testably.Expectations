using System;
using System.Text;

namespace Testably.Expectations.Formatting;

public static partial class ValueFormatters
{
	/// <summary>
	///     Returns the according to the <paramref name="options" /> formatted <paramref name="value" />.
	/// </summary>
	public static string Format(
		this ValueFormatter _,
		TimeSpan value,
		FormattingOptions? options = null)
	{
		string formatString = CreateTimeSpanFormatString(value);

		if (value < TimeSpan.Zero)
		{
			return $"-{value.ToString(formatString)}";
		}

		return value.ToString(formatString);
	}

	/// <summary>
	///     Appends the according to the <paramref name="options" /> formatted <paramref name="value" />
	///     to the <paramref name="stringBuilder" />
	/// </summary>
	public static void Format(
		this ValueFormatter formatter,
		StringBuilder stringBuilder,
		TimeSpan value,
		FormattingOptions? options = null)
	{
		string formatString = CreateTimeSpanFormatString(value);

		if (value < TimeSpan.Zero)
		{
			stringBuilder.Append('-');
		}

		stringBuilder.Append(value.ToString(formatString));
	}

	/// <summary>
	///     Returns the according to the <paramref name="options" /> formatted <paramref name="value" />.
	/// </summary>
	public static string Format(
		this ValueFormatter formatter,
		TimeSpan? value,
		FormattingOptions? options = null)
	{
		if (value == null)
		{
			return ValueFormatter.NullString;
		}

		return Format(formatter, value.Value, options);
	}

	/// <summary>
	///     Appends the according to the <paramref name="options" /> formatted <paramref name="value" />
	///     to the <paramref name="stringBuilder" />
	/// </summary>
	public static void Format(
		this ValueFormatter formatter,
		StringBuilder stringBuilder,
		TimeSpan? value,
		FormattingOptions? options = null)
	{
		if (value == null)
		{
			stringBuilder.Append(ValueFormatter.NullString);
			return;
		}

		Format(formatter, stringBuilder, value.Value, options);
	}

	private static string CreateTimeSpanFormatString(TimeSpan value)
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

		return formatString;
	}
}
