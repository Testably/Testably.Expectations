using System;
using System.Threading;

namespace Testably.Expectations.Common;
internal class ExpectationContext
{
	private static readonly AsyncLocal<ExpectationContext> currentScope = new();
	private object? _constraintBuilder;

	public static ExpectationContext Current
	{
		get
		{
			var context = currentScope.Value;
			if (context == null)
			{
				context = new ExpectationContext();
				currentScope.Value = context;
			}
			return context;
		}
	}

	public ConstraintBuilder<TActual> GetEmptyConstraintBuilder<TActual>()
	{
		var builder = new ConstraintBuilder<TActual>();
		_constraintBuilder = builder;
		return builder;
	}

	public ConstraintBuilder<TActual> GetRegisteredConstraintBuilder<TActual>()
	{
		if (_constraintBuilder is ConstraintBuilder<TActual> builder)
		{
			return builder;
		}

		throw new InvalidOperationException("Invalid or no builder type was registered!");
	}
}
