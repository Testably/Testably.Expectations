using System.Linq;
using System.Text;
using Testably.Expectations.Core.Ambient;

namespace Testably.Expectations.Core.Formatting;

internal class Formatter
{
	public const string NullString = "<null>";

	private readonly IValueFormatter[] _internalValueFormatters =
	[
		new StringValueFormatter()
	];

	public static string Format<T>(T? value, FormattingOptions? options = null)
	{
		StringBuilder stringBuilder = new();
		options ??= FormattingOptions.Default;
		Initialization.State.Value.Formatter.Format(value, stringBuilder, options);
		return stringBuilder.ToString();
	}

	public void Format<T>(T? value, StringBuilder stringBuilder, FormattingOptions options)
	{
		if (value is null)
		{
			stringBuilder.Append(NullString);
			return;
		}

		IValueFormatter<T>? matchingFormatter = _internalValueFormatters
			.OfType<IValueFormatter<T>>()
			.FirstOrDefault();
		if (matchingFormatter != null)
		{
			matchingFormatter.Format(value, stringBuilder, options);
			return;
		}

		foreach (IValueFormatter formatter in _internalValueFormatters)
		{
			if (formatter.TryFormat(value, stringBuilder, options))
			{
				return;
			}
		}

		stringBuilder.Append(value);
	}
}
