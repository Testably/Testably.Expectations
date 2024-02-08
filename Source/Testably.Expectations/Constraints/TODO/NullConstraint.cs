using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class NullConstraint<TActual> : SimpleNullableConstraint<TActual>
{
	public override string ExpectationText => "to be null";

	protected override bool Satisfies(TActual? actual)
		=> actual == null;
}

internal class NullConstraint : INullableConstraint
{
	#region INullableConstraint Members

	public string ExpectationText => "to be null";

	public ConstraintResult Satisfies(object? actual)
		=> new(actual == null, actual);

	#endregion
}
