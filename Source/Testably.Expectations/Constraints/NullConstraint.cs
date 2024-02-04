using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints;

public class NullConstraint<TActual> : SimpleNullableConstraint<TActual>
{
	public override string ExpectationText => "to be null";

	protected override bool Satisfies(TActual? actual)
		=> actual == null;
}
