﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

/// <summary>
/// The property accessor.
/// </summary>
public abstract class PropertyAccessor
{
	private readonly string _name;

	/// <summary>
	/// Creates a new property accessor.
	/// </summary>
	/// <param name="name"></param>
	protected PropertyAccessor(string name)
	{
		_name = name;
	}

	/// <inheritdoc />
	public override string ToString()
		=> _name;
}

/// <summary>
/// The property accessor from <typeparamref name="TSource"/> to <typeparamref name="TTarget"/>.
/// </summary>
public class PropertyAccessor<TSource, TTarget> : PropertyAccessor
{
	private readonly Func<SourceValue<TSource>, TTarget> _accessor;

	private PropertyAccessor(Func<SourceValue<TSource>, TTarget> accessor, string name) :
		base(name)
	{
		_accessor = accessor;
	}

	/// <summary>
	/// Creates a property accessor from the given <paramref name="func"/>.
	/// </summary>
	internal static PropertyAccessor<TSource, TTarget?> FromFunc(
		Func<SourceValue<TSource>, TTarget> func, string name)
		=> new(func, name);

	/// <summary>
	/// Creates a property accessor from the given <paramref name="expression"/>.
	/// </summary>
	public static PropertyAccessor<TSource, TTarget?> FromExpression(
		Expression<Func<TSource, TTarget?>> expression)
	{
		var compiled = expression.Compile();
		return new(v => v.Value == null ? default : compiled(v.Value), $"{ExpressionHelpers.GetPropertyPath(expression)} ");
	}

	internal bool TryAccessProperty(SourceValue<TSource> value,
		[NotNullWhen(true)] out TTarget? property)
	{
		property = _accessor.Invoke(value);
		return property is not null;
	}
}
