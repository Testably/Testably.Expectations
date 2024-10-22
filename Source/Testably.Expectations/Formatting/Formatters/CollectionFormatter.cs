using System.Collections;
using System.Text;

namespace Testably.Expectations.Formatting.Formatters;

internal class CollectionFormatter : FormatterBase<IEnumerable>
{
	/// <inheritdoc />
	public override void Format(IEnumerable value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		int maxCount = 10;
		int count = maxCount;
		stringBuilder.Append("[");
		bool hasMoreValues = false;
		foreach (object? v in value)
		{
			if (count < maxCount)
			{
				stringBuilder.Append(", ");
			}

			if (count-- <= 0)
			{
				hasMoreValues = true;
				break;
			}

			stringBuilder.Append(Formatter.Format(v, options));
		}

		if (hasMoreValues)
		{
			const char ellipsis = '\u2026';
			stringBuilder.Append(ellipsis);
		}

		stringBuilder.Append("]");
	}
}
