using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
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
		return property is not null;
	}

	public static PropertyAccessor<TActual, TProperty> Create(Func<TActual, TProperty> accessor, string name)
		=> new(accessor, name);

	public static PropertyAccessor<TActual, TProperty> FromExpression(Expression<Func<TActual, TProperty>> expression)
	{
		var accessor = expression.Compile();
		return Create(accessor, ExpressionHelpers.ExtractExpressionName(expression));
	}
}
