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
		=> _name == "" ? "" : $".{_name} ";
}

internal class PropertyAccessor<TActual, TProperty> : PropertyAccessor
{
	private readonly Func<SourceValue<TActual>, TProperty> _accessor;

	private PropertyAccessor(Func<SourceValue<TActual>, TProperty> accessor, string name) :
		base(name)
	{
		_accessor = accessor;
	}

	public static PropertyAccessor<TActual, TProperty?> FromFunc(
		Func<SourceValue<TActual>, TProperty> propertyAccessor, string name)
		=> new(propertyAccessor, name);

	public static PropertyAccessor<TActual, TProperty?> FromString(string propertyAccessor)
		=> new(value => ExpressionHelpers.GetPropertyValue<TProperty>(value, propertyAccessor),
			propertyAccessor);

	public bool TryAccessProperty(SourceValue<TActual> value,
		[NotNullWhen(true)] out TProperty? property)
	{
		property = _accessor.Invoke(value);
		return property is not null;
	}
}
