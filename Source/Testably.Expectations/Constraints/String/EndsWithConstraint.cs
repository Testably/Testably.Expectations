using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.String;

internal class EndsWithConstraint : SimpleConstraint<string?>
{
	private string expected;

	public EndsWithConstraint(string expected)
	{
		this.expected = expected;
	}

	public override string ExpectationText => $"to end with '{expected}'";

	protected override bool Satisfies(string? actual)
		=> actual?.EndsWith(expected) == true;
}
