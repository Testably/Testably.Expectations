using System.Globalization;
using System.Linq;
using System.Text;
using Testably.Expectations.Core.Ambient;
using Testably.Expectations.Formatting.Formatters;

namespace Testably.Expectations.Formatting;

/// <summary>
///     Formatter for arbitrary objects in exception messages.
/// </summary>
public class Formatter
{
	internal const string NullString = "<null>";

	private readonly IValueFormatter _defaultFormatter = new DefaultFormatter();

	private readonly IValueFormatter[] _internalValueFormatters =
	[
		new BooleanFormatter(),
		new StringFormatter(),
		new TypeFormatter(),
		new CollectionFormatter(),
		new HttpStatusCodeFormatter(),
		new DateTimeFormatter(),
		new DateTimeOffsetFormatter(),
		new TimeSpanFormatter(),
#if !NETSTANDARD2_0
		new DateOnlyFormatter(),
		new TimeOnlyFormatter(),
#endif
		new GuidFormatter(),
		new EnumFormatter(),
		new NumberFormatter<int>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter<uint>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter<byte>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter<sbyte>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter<short>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter<ushort>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter<long>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter<ulong>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter<float>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter<double>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter<decimal>(v => v.ToString(CultureInfo.InvariantCulture)),
		new NumberFormatter(),
	];

	/// <summary>
	///     Formats the <paramref name="value" /> according to the formatting <paramref name="options" />.
	/// </summary>
	public static string Format<T>(T? value, FormattingOptions? options = null)
	{
		StringBuilder stringBuilder = new();
		options ??= FormattingOptions.Default;
		Initialization.State.Value.Formatter.Format(value, stringBuilder, options);
		return stringBuilder.ToString();
	}

	private void Format<T>(T? value, StringBuilder stringBuilder, FormattingOptions options)
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

		_defaultFormatter.TryFormat(value, stringBuilder, options);
	}
}
