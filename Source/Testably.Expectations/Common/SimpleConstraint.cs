using System;

namespace Testably.Expectations.Common;

public abstract class SimpleConstraint<TActual> : IConstraint<TActual>
{
	public abstract string ExpectationText { get; }

	public ConstraintResult Satisfies(object? actual)
	{
		if (actual is TActual typedActual)
		{
			return new ConstraintResult(Satisfies(typedActual), actual);
		}
		throw new InvalidOperationException($"Expected actual value of {typeof(TActual)} but got {actual?.GetType()}");
	}
	protected abstract bool Satisfies(TActual actual);
}
