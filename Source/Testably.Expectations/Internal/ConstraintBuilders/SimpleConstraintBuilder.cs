using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Internal;

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
		ConstraintResult? result = _constraint?.Satisfies(actual);
		if (result?.IsSuccess == false)
		{
			return new ExpectationResult(_constraint!.ExpectationText, false);
		}

		return new ExpectationResult(ToString(), true);
	}

	#endregion

	public override string ToString()
		=> _constraint?.ExpectationText ?? "no constraint yet";
}
