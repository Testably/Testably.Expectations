using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints.String;

internal class EndsWithConstraint : IConstraint<string?>
{
	private readonly string _expected;

	public EndsWithConstraint(string expected)
	{
		_expected = expected;
	}

	#region IConstraint<string?> Members

	public string ExpectationText => $"to end with '{_expected}'";

	public ConstraintResult Satisfies(string? actual)
		=> new ConstraintResult<string?>(actual?.EndsWith(_expected) == true, actual);

	#endregion
}
