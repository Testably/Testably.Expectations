using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.Bool;

public class TrueConstraint : IConstraint<bool>
{
	public string ExpectationText => "to be True";

	public ConstraintResult<bool> ApplyTo(bool actual)
	{
		return new ConstraintResult<bool>(this, true.Equals(actual));
	}
}
