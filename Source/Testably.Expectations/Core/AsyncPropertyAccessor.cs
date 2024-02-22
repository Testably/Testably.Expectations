using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

internal abstract class AsyncPropertyAccessor
{
	private readonly string _name;

	protected AsyncPropertyAccessor(string name)
	{
		_name = name;
	}

	/// <inheritdoc />
	public override string ToString()
		=> _name;
}

internal class AsyncPropertyAccessor<TActual, TProperty> : AsyncPropertyAccessor
{
	private readonly Func<TActual, Task<TProperty>> _accessor;

	private AsyncPropertyAccessor(Func<TActual, Task<TProperty>> accessor, string name) : base(name)
	{
		_accessor = accessor;
	}

	public Task<TProperty> TryAccessProperty(TActual value)
	{
		if (_accessor == null)
		{
			throw new InvalidOperationException("Missing");
		}
		return _accessor.Invoke(value);
	}

	public static AsyncPropertyAccessor<TActual, TProperty> Create(Func<TActual, Task<TProperty>> accessor, string name)
		=> new(accessor, name);

	public static AsyncPropertyAccessor<TActual, TProperty> FromExpression(Expression<Func<TActual, Task<TProperty>>> expression)
	{ 
		var accessor = expression.Compile();
		return Create(accessor, ExpressionHelpers.ExtractExpressionName(expression));
	}
}
