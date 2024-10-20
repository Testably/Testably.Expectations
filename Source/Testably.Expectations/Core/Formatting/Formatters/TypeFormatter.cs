using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Testably.Expectations.Core.Formatting.Formatters;

internal class TypeFormatter : FormatterBase<Type>
{
	private static readonly Dictionary<Type, string> Aliases = new()
	{
		{ typeof(byte), "byte" },
		{ typeof(sbyte), "sbyte" },
		{ typeof(short), "short" },
		{ typeof(ushort), "ushort" },
		{ typeof(int), "int" },
		{ typeof(uint), "uint" },
		{ typeof(long), "long" },
		{ typeof(ulong), "ulong" },
		{ typeof(float), "float" },
		{ typeof(double), "double" },
		{ typeof(decimal), "decimal" },
		{ typeof(object), "object" },
		{ typeof(bool), "bool" },
		{ typeof(char), "char" },
		{ typeof(string), "string" },
		{ typeof(void), "void" },
		{ typeof(nint), "nint" },
		{ typeof(nuint), "nuint" },
	};

	/// <inheritdoc />
	public override void Format(Type value, StringBuilder stringBuilder,
		FormattingOptions options)
	{
		if (FindPrimitiveAlias(value, out string? alias))
		{
			stringBuilder.Append(alias);
		}
		else
		{
			stringBuilder.Append(value.Name);
		}
	}

	private static bool FindPrimitiveAlias(Type value, [NotNullWhen(true)] out string? alias)
	{
		if (Aliases.TryGetValue(value, out string? typeAlias))
		{
			alias = typeAlias;
			return true;
		}

		Type? underlyingType = Nullable.GetUnderlyingType(value);

		if (underlyingType != null &&
		    Aliases.TryGetValue(underlyingType, out string? underlyingAlias))
		{
			alias = $"{underlyingAlias}?";
			return true;
		}

		alias = null;
		return false;
	}
}
