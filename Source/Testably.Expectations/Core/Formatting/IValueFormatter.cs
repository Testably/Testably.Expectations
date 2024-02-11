using System.Text;

namespace Testably.Expectations.Core.Formatting;

internal interface IValueFormatter<in T> : IValueFormatter
{
	void Format(T value, StringBuilder stringBuilder, FormattingOptions options);
}

internal interface IValueFormatter
{
	bool TryFormat(object? value, StringBuilder stringBuilder, FormattingOptions options);
}
