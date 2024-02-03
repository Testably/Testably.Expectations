using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.Bool;

public class FalseConstraint : IConstraint<bool>
{
	public string ExpectationText => "to be False";

	public ConstraintResult<bool> ApplyTo(bool actual)
	{
		return new ConstraintResult<bool>(this, false.Equals(actual));
	}
}
