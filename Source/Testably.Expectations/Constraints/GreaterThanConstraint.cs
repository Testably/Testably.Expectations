using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class GreaterThanConstraint : SimpleConstraint<int>
{
	public override string ExpectationText => $"to be greater than {_expected}";
	private readonly int _expected;

	public GreaterThanConstraint(int expected)
	{
		_expected = expected;
	}

	protected override bool Satisfies(int actual)
		=> actual > _expected;
}
