using Testably.Expectations.Core;
using Testably.Expectations.Core.Internal;

namespace Testably.Expectations.Internal.ConstraintBuilders;

internal class AndConstraintBuilder : IConstraintBuilder
{
	private readonly IConstraintBuilder _left;
	private readonly IConstraintBuilder _right = new SimpleConstraintBuilder();

	public AndConstraintBuilder(IConstraintBuilder left)
	{
		_left = left;
	}

	#region IConstraintBuilder Members

	public IConstraintBuilder Add(IConstraint constraint)
	{
		_right.Add(constraint);
		return this;
	}

	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult leftResult = _left.ApplyTo(actual);
		if (leftResult.IsSuccess)
		{
			ExpectationResult rightResult = _right.ApplyTo(actual);
			if (rightResult.IsSuccess)
			{
				return ExpectationResult.Success(ToString());
			}

			return rightResult;
		}

		return leftResult;
	}

	#endregion

	public override string ToString()
		=> $"{_left} AND {_right}";
}
