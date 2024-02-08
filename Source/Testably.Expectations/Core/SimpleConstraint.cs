using System;

namespace Testably.Expectations.Core;

public abstract class SimpleConstraint<TActual> : IConstraint<TActual>
{
	#region IConstraint<TActual> Members

	public abstract string ExpectationText { get; }

	public ConstraintResult Satisfies(object? actual)
	{
		if (actual is TActual typedActual)
		{
			return new ConstraintResult(Satisfies(typedActual), actual);
		}

		throw new InvalidOperationException(
			$"Expected actual value of {typeof(TActual)} but got {actual?.GetType()}");
	}

	#endregion

	protected abstract bool Satisfies(TActual actual);
}
