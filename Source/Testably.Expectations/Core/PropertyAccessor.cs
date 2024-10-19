using System;
using System.Diagnostics.CodeAnalysis;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

public abstract class PropertyAccessor
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

public class PropertyAccessor<TValue, TProperty> : PropertyAccessor
{
	private readonly Func<SourceValue<TValue>, TProperty> _accessor;

	private PropertyAccessor(Func<SourceValue<TValue>, TProperty> accessor, string name) :
		base(name)
	{
		_accessor = accessor;
	}

	public static PropertyAccessor<TValue, TProperty?> FromFunc(
		Func<SourceValue<TValue>, TProperty> propertyAccessor, string name)
		=> new(propertyAccessor, name);

	public static PropertyAccessor<TValue, TProperty?> FromString(string propertyAccessor)
		=> new(value => ExpressionHelpers.GetPropertyValue<TProperty>(value, propertyAccessor),
			propertyAccessor);

	public bool TryAccessProperty(SourceValue<TValue> value,
		[NotNullWhen(true)] out TProperty? property)
	{
		property = _accessor.Invoke(value);
		return property is not null;
	}
}
