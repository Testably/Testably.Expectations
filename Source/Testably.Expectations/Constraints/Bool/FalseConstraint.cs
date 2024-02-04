using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.Bool;

public class FalseConstraint : SimpleConstraint<bool>
{
	public override string ExpectationText => "to be False";

	protected override bool Satisfies(bool actual)
		=> false.Equals(actual);
}
