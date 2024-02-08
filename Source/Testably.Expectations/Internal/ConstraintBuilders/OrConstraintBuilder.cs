using Testably.Expectations.Core;

namespace Testably.Expectations.Internal.ConstraintBuilders;

internal class OrConstraintBuilder(IConstraintBuilder left) : IConstraintBuilder
{
	private readonly IConstraintBuilder _right = new SimpleConstraintBuilder();

	#region IConstraintBuilder Members

	public IConstraintBuilder Add(IConstraint constraint)
	{
		_right.Add(constraint);
		return this;
	}

	public ExpectationResult ApplyTo<TExpectation>(TExpectation actual)
	{
		ExpectationResult leftResult = left.ApplyTo(actual);
		if (!leftResult.IsSuccess)
		{
			ExpectationResult rightResult = _right.ApplyTo(actual);
			if (!rightResult.IsSuccess)
			{
				// TODO: Check Expectation Text
				return new ExpectationResult(ToString(), false);
			}
		}

		return new ExpectationResult(ToString(), true);
	}

	#endregion

	public override string ToString()
		=> $"{left} OR {_right}";
}
