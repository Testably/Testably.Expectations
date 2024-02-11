using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.String;

internal class StartWith : IExpectation<string?>
{
	private readonly string _expected;

	public StartWith(string expected)
	{
		_expected = expected;
	}

	#region IExpectation<string?> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(string? actual)
	{
		if (actual?.StartsWith(_expected) == true)
		{
			return new ExpectationResult.Success(ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to start with {Formatter.Format(_expected)}";
}
