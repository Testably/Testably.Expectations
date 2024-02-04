using System;

namespace Testably.Expectations.Common;

public abstract class ComplexConstraint<TActual, TTarget> : IConstraint<TActual, TTarget>
{
	public abstract string ExpectationText { get; }

	public ConstraintResult Satisfies(object? actual)
	{
		if (actual is TActual typedActual)
		{
			var result = Satisfies(typedActual);
			return new ConstraintResult(result.IsSuccess, result.Value);
		}
		throw new InvalidOperationException($"Expected actual value of {typeof(TActual)} but got {actual?.GetType()}");
	}
	protected abstract ConstraintResult<TTarget> Satisfies(TActual actual);
}
