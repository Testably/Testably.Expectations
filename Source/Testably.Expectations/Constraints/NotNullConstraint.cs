using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints;

public class NotNullConstraint<TActual> : INullableConstraint<TActual>
{
	public string ExpectationText => "not to be null";

	public ConstraintResult<TActual> ApplyTo(TActual actual)
	{
		return new ConstraintResult<TActual>(this, actual != null);
	}
}
