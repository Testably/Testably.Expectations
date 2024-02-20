using System;
using System.Diagnostics.CodeAnalysis;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

internal abstract class PropertyAccessor
{
	private readonly string _name;

	protected PropertyAccessor(string name)
	{
		_name = name;
	}

	/// <inheritdoc />
	public override string ToString()
		=> _name;
}

internal class PropertyAccessor<TActual, TProperty> : PropertyAccessor
{
	private readonly Func<TActual, TProperty> _accessor;

	private PropertyAccessor(Func<TActual, TProperty> accessor, string name) : base(name)
	{
		_accessor = accessor;
	}

	public bool TryAccessProperty(TActual value, [NotNullWhen(true)] out TProperty? property)
	{
		property = _accessor.Invoke(value);
		return property != null;
	}

	public static PropertyAccessor<TActual, TProperty?> FromString(string propertyAccessor)
		=> new(value => ExpressionHelpers.GetPropertyValue<TProperty>(value, propertyAccessor),
			propertyAccessor);
}
