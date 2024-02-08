using System;
using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal abstract class SimpleNullableConstraint<TActual> : INullableConstraint<TActual>
{
	#region INullableConstraint<TActual> Members

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

		throw new InvalidOperationException(
			$"Expected actual value of {typeof(TActual)} but got {actual?.GetType()}");
	}

	#endregion

	protected abstract bool Satisfies(TActual? actual);
}
