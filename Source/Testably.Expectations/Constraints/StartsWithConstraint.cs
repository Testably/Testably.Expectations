using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class StartsWithConstraint : SimpleConstraint<string?>
{
	public override string ExpectationText => $"to start with '{_expected}'";
	private readonly string _expected;

	public StartsWithConstraint(string expected)
	{
		_expected = expected;
	}

	protected override bool Satisfies(string? actual)
		=> actual?.StartsWith(_expected) == true;
}
