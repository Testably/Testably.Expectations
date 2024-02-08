using System;

namespace Testably.Expectations.Core;

public abstract class ComplexConstraint<TActual, TTarget> : IConstraint<TActual, TTarget>
{
	#region IConstraint<TActual,TTarget> Members

	public abstract string ExpectationText { get; }

	public ConstraintResult Satisfies(object? actual)
	{
		if (actual is TActual typedActual)
		{
			ConstraintResult<TTarget> result = Satisfies(typedActual);
			return new ConstraintResult(result.IsSuccess, result.Value);
		}

		throw new InvalidOperationException(
			$"Expected actual value of {typeof(TActual)} but got {actual?.GetType()}");
	}

	#endregion

	protected abstract ConstraintResult<TTarget> Satisfies(TActual actual);
}
