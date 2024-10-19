﻿using System;
using System.Text;

namespace Testably.Expectations.Core.Formatting;

internal class TypeValueFormatter : FormatterBase<Type>
{
	/// <inheritdoc />
	public override void Format(Type value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		stringBuilder.Append(value.Name);
	}
}
