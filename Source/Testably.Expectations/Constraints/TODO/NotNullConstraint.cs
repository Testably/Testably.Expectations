namespace Testably.Expectations.Constraints;

internal class NotNullConstraint<TActual> : SimpleConstraint<TActual>
{
	public override string ExpectationText => "not to be null";

	protected override bool Satisfies(TActual actual)
		=> actual != null;
}
