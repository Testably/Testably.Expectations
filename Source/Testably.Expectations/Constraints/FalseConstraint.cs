using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

public class FalseConstraint : SimpleConstraint<bool>
{
	public override string ExpectationText => "to be False";

	protected override bool Satisfies(bool actual)
		=> false.Equals(actual);
}
