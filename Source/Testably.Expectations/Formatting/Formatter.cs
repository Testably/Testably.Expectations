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
		new NumberFormatter<int>(),
		new NumberFormatter<uint>(),
		new NumberFormatter<byte>(),
		new NumberFormatter<sbyte>(),
		new NumberFormatter<short>(),
		new NumberFormatter<ushort>(),
		new NumberFormatter<long>(),
		new NumberFormatter<ulong>(),
		new NumberFormatter<float>(),
		new NumberFormatter<double>(),
		new NumberFormatter<decimal>(),
		new EnumFormatter(),
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
