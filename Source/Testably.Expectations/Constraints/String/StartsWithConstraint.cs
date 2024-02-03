using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.String;
internal class StartsWithConstraint : IConstraint<string?>
{
	private string expected;

	public StartsWithConstraint(string expected)
	{
		this.expected = expected;
	}

	public string ExpectationText => $"to start with '{expected}'";

	public ConstraintResult<string?> ApplyTo(string? actual)
	{
		return new ConstraintResult<string?>(this, actual?.StartsWith(expected) == true);
	}
}
