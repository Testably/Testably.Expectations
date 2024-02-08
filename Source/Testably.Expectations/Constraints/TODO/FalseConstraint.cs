using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class FalseConstraint : IConstraint<bool>
{
	public string ExpectationText => "to be False";

	public ConstraintResult Satisfies(bool actual)
		=> new ConstraintResult<bool>(false.Equals(actual), actual);
}
