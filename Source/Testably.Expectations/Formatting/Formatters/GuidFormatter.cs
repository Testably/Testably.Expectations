using System;
using System.Text;

namespace Testably.Expectations.Formatting.Formatters;

internal class GuidFormatter : FormatterBase<Guid>
{
	/// <inheritdoc />
	public override void Format(Guid value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value);
	}
}
