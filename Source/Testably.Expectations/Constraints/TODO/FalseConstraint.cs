namespace Testably.Expectations.Constraints;

internal class FalseConstraint : SimpleConstraint<bool>
{
	public override string ExpectationText => "to be False";

	protected override bool Satisfies(bool actual)
		=> false.Equals(actual);
}
