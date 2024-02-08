using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class GreaterThanConstraint : IConstraint<int>
{
	public string ExpectationText => $"to be greater than {_expected}";
	private readonly int _expected;

	public GreaterThanConstraint(int expected)
	{
		_expected = expected;
	}

	public ConstraintResult Satisfies(int actual)
		=> new ConstraintResult<int>(actual > _expected, actual);
}
