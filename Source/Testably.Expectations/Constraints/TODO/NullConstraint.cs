using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class NullConstraint<TActual> : INullableConstraint<TActual>
{
	public string ExpectationText => "to be null";

	public ConstraintResult Satisfies(TActual? actual)
		=> new ConstraintResult<TActual?>(actual == null, actual);
}

internal class NullConstraint : INullableConstraint<object?>
{
	#region INullableConstraint Members

	public string ExpectationText => "to be null";

	public ConstraintResult Satisfies(object? actual)
		=> new ConstraintResult<object?>(actual == null, actual);

	#endregion
}
