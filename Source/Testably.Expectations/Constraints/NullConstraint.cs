using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints;

public class NullConstraint<TActual> : INullableConstraint<TActual>
{
	public string ExpectationText => "to be null";

	public ConstraintResult<TActual> ApplyTo(TActual actual)
	{
		return new ConstraintResult<TActual>(this, actual == null);
	}
}
