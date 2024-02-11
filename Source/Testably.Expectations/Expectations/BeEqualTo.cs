using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations;

internal class BeEqualTo<T> : INullableExpectation<T>
{
	private readonly T _expected;

	public BeEqualTo(T expected)
	{
		_expected = expected;
	}

	#region INullableExpectation<T> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(T actual)
	{
		if (actual is null && _expected is null)
		{
			return new ExpectationResult.Success(ToString());
		}

		if (_expected?.Equals(actual) == true)
		{
			return new ExpectationResult.Success<T>(actual, ToString());
		}

		return new ExpectationResult.Failure(ToString(),
			$"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to be equal to {Formatter.Format(_expected)}";
}
