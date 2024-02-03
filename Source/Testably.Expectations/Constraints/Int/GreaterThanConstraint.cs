using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.Int;
internal class GreaterThanConstraint : IConstraint<int>
{
	private int expected;

	public GreaterThanConstraint(int expected)
	{
		this.expected = expected;
	}

	public string ExpectationText => $"to be greater than {expected}";
	public ConstraintResult<int> ApplyTo(int actual)
	{
		return new ConstraintResult<int>(this, actual > expected);
	}
}
