using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints;

public class NotNullConstraint<TActual> : SimpleConstraint<TActual>
{
	public override string ExpectationText => "not to be null";

	protected override bool Satisfies(TActual actual)
		=> actual != null;
}
