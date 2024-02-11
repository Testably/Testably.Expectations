using System.Text;

namespace Testably.Expectations.Core.Formatting;

internal abstract class FormatterBase<T> : IValueFormatter<T>
{
	#region IValueFormatter Members

	public bool TryFormat(object? value, StringBuilder stringBuilder, FormattingOptions options)
	{
		if (value is T match)
		{
			Format(match, stringBuilder, options);
			return true;
		}

		return false;
	}

	#endregion

	public abstract void Format(T value, StringBuilder stringBuilder,
		FormattingOptions options);
}
