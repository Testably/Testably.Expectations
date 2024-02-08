using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class TrueConstraint : IConstraint<bool>
{
	public string ExpectationText => "to be True";

	public ConstraintResult Satisfies(bool actual)
		=> new ConstraintResult<bool>(true.Equals(actual), actual);
}
