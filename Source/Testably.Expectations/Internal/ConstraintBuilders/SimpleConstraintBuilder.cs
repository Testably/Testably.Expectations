using System;
using Testably.Expectations.Constraints;
using Testably.Expectations.Core;

namespace Testably.Expectations.Internal.ConstraintBuilders;

internal class SimpleConstraintBuilder : IConstraintBuilder
{
	private IConstraint? _constraint;

	#region IConstraintBuilder Members

	public IConstraintBuilder Add(IConstraint constraint)
	{
		if (_constraint != null)
		{
			throw new InvalidOperationException(
				$"Cannot add multiple constraints to a {nameof(SimpleConstraintBuilder)}");
		}
		_constraint = constraint;
		return this;
	}

	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		if (_constraint is IConstraint<TExpectation> typedConstraint)
		{
			var result = typedConstraint.Satisfies(actual);
			if (result is ConstraintResult<TExpectation> resultWithValue)
			{
				return new ExpectationResult<TExpectation>(resultWithValue.Value, result.IsSuccess ? ToString() : typedConstraint.ExpectationText, result.IsSuccess);
			}
			if (result is ConstraintResult<Exception> resultWithException)
			{
				return new ExpectationResult<Exception>(resultWithException.Value, result.IsSuccess ? ToString() : typedConstraint.ExpectationText, result.IsSuccess);
			}

			return new ExpectationResult(result.IsSuccess ? ToString() : typedConstraint.ExpectationText, result.IsSuccess);
		}

		return new ExpectationResult(ToString(), true);
	}

	#endregion

	public override string ToString()
		=> _constraint?.ExpectationText ?? "no constraint yet";
}
