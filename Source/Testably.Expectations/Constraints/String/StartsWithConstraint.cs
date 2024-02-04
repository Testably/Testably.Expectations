using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.String;
internal class StartsWithConstraint : SimpleConstraint<string?>
{
	private string expected;

	public StartsWithConstraint(string expected)
	{
		this.expected = expected;
	}

	public override string ExpectationText => $"to start with '{expected}'";

	protected override bool Satisfies(string? actual)
		=> actual?.StartsWith(expected) == true;
}
