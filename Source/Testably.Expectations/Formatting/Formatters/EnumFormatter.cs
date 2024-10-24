﻿using System;
using System.Text;

namespace Testably.Expectations.Formatting.Formatters;

internal class EnumFormatter : FormatterBase<Enum>
{
	/// <inheritdoc />
	public override void Format(Enum value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value);
	}
}
