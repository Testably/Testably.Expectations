using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class EndsWithConstraint : SimpleConstraint<string?>
{
	public override string ExpectationText => $"to end with '{_expected}'";
	private readonly string _expected;

	public EndsWithConstraint(string expected)
	{
		_expected = expected;
	}

	protected override bool Satisfies(string? actual)
		=> actual?.EndsWith(_expected) == true;
}
