using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.Bool;

public class TrueConstraint : SimpleConstraint<bool>
{
	public override string ExpectationText => "to be True";

	protected override bool Satisfies(bool actual)
		=> true.Equals(actual);
}
