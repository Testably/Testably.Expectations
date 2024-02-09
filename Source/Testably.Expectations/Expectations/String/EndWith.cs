using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations.String;

internal class EndWith : IExpectation<string?>
{
	private readonly string _expected;

	public EndWith(string expected)
	{
		_expected = expected;
	}

	#region IExpectation<string?> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(string? actual)
	{
		if (actual?.EndsWith(_expected) == true)
		{
			return new ExpectationResult.Success();
		}

		return new ExpectationResult.Failure(ToString(), $"found '{actual}'");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to end with '{_expected}'";
}
