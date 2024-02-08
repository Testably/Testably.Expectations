namespace Testably.Expectations.Constraints;

internal class TrueConstraint : SimpleConstraint<bool>
{
	public override string ExpectationText => "to be True";

	protected override bool Satisfies(bool actual)
		=> true.Equals(actual);
}
