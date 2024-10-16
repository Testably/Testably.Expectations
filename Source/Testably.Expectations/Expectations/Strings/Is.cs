using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Strings;

internal class Is : INullableExpectation<string?>
{
	private readonly string? _expected;

	public Is(string? expected)
	{
		_expected = expected;
	}

	#region INullableExpectation<string?> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(string? actual)
	{
		if (actual is null && _expected is null)
		{
			return new ExpectationResult.Success(ToString());
		}

		if (_expected?.Equals(actual) == true)
		{
			return new ExpectationResult.Success<string?>(actual, ToString());
		}

		return new ExpectationResult.Failure(ToString(),
			$"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"is equal to {Formatter.Format(_expected)}";
}
