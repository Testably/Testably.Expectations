namespace Testably.Expectations.Core;

internal class WithoutConstraints : IConstraintBuilder
{
	private IConstraint? _constraint;

	#region IConstraintBuilder Members

	public IConstraintBuilder Add(IConstraint constraint)
	{
		_constraint = constraint;
		return this;
	}

	public ExpectationResult<TExpectation> ApplyTo<TExpectation>(TExpectation actual)
	{
		ConstraintResult? result = _constraint?.Satisfies(actual);
		if (result?.IsSuccess == false)
		{
			return new ExpectationResult<TExpectation>(_constraint!.ExpectationText, false);
		}

		return new ExpectationResult<TExpectation>(ToString(), true);
	}

	#endregion

	public override string ToString()
		=> _constraint?.ExpectationText ?? "no constraint yet";
}

internal class AndConstraintBuilder : IConstraintBuilder
{
	private readonly IConstraintBuilder _left;
	private readonly IConstraintBuilder _right;

	public AndConstraintBuilder(IConstraintBuilder left)
	{
		_left = left;
		_right = new WithoutConstraints();
	}

	#region IConstraintBuilder Members

	public IConstraintBuilder Add(IConstraint constraint)
	{
		_right.Add(constraint);
		return this;
	}

	public ExpectationResult<TExpectation> ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult<TExpectation> leftResult = _left.ApplyTo(actual);
		if (leftResult.IsSuccess())
		{
			ExpectationResult<TExpectation> rightResult = _right.ApplyTo(actual);
			if (rightResult.IsSuccess())
			{
				return new ExpectationResult<TExpectation>(ToString(), true);
			}

			return rightResult;
		}

		return leftResult;
	}

	#endregion

	public override string ToString()
		=> $"{_left} AND {_right}";
}

internal class OrConstraintBuilder : IConstraintBuilder
{
	private readonly IConstraintBuilder _left;
	private readonly IConstraintBuilder _right;

	public OrConstraintBuilder(IConstraintBuilder left)
	{
		_left = left;
		_right = new WithoutConstraints();
	}

	#region IConstraintBuilder Members

	public IConstraintBuilder Add(IConstraint constraint)
	{
		_right.Add(constraint);
		return this;
	}

	public ExpectationResult<TExpectation> ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult<TExpectation> leftResult = _left.ApplyTo(actual);
		if (!leftResult.IsSuccess())
		{
			ExpectationResult<TExpectation> rightResult = _right.ApplyTo(actual);
			if (!rightResult.IsSuccess())
			{
				// TODO: Check Expectation Text
				return new ExpectationResult<TExpectation>(ToString(), false);
			}
		}

		return new ExpectationResult<TExpectation>(ToString(), true);
	}

	#endregion

	public override string ToString()
		=> $"{_left} AND {_right}";
}

internal interface IConstraintBuilder
{
	IConstraintBuilder Add(IConstraint constraint);
	ExpectationResult<TExpectation> ApplyTo<TExpectation>(TExpectation actual);
}
