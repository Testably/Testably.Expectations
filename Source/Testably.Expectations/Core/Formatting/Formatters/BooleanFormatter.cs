using System.Text;

namespace Testably.Expectations.Core.Formatting.Formatters;

internal class BooleanFormatter : FormatterBase<bool>
{
	/// <inheritdoc />
	public override void Format(bool value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value ? "True" : "False");
	}
}
