using System;

namespace Testably.Expectations.Common;

public abstract class SimpleNullableConstraint<TActual> : INullableConstraint<TActual>
{
	public abstract string ExpectationText { get; }

	public ConstraintResult Satisfies(object? actual)
	{
		if (actual is null)
		{
			return new ConstraintResult(Satisfies(default), actual);
		}
		if (actual is TActual typedActual)
		{
			return new ConstraintResult(Satisfies(typedActual), actual);
		}
		throw new InvalidOperationException($"Expected actual value of {typeof(TActual)} but got {actual?.GetType()}");
	}
	protected abstract bool Satisfies(TActual? actual);
}
