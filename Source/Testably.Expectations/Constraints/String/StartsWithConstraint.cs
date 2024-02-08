using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints.String;

internal class StartsWithConstraint : IConstraint<string?>
{
	private readonly string _expected;

	public StartsWithConstraint(string expected)
	{
		_expected = expected;
	}

	#region IConstraint<string?> Members

	public string ExpectationText => $"to start with '{_expected}'";

	public ConstraintResult Satisfies(string? actual)
		=> new ConstraintResult<string?>(actual?.StartsWith(_expected) == true, actual);

	#endregion
}
