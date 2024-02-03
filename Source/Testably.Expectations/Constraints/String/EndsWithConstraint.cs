using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.String;

internal class EndsWithConstraint : IConstraint<string?>
{
	private string expected;

	public EndsWithConstraint(string expected)
	{
		this.expected = expected;
	}

	public string ExpectationText => $"to end with '{expected}'";

	public ConstraintResult<string?> ApplyTo(string? actual)
	{
		return new ConstraintResult<string?>(this, actual?.EndsWith(expected) == true);
	}
}
