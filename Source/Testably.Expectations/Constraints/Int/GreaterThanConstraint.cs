using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.Int;
internal class GreaterThanConstraint : SimpleConstraint<int>
{
	private int expected;

	public GreaterThanConstraint(int expected)
	{
		this.expected = expected;
	}

	public override string ExpectationText => $"to be greater than {expected}";

	protected override bool Satisfies(int actual)
		=> actual > expected;
}
