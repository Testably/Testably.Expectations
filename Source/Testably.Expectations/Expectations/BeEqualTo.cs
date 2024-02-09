using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations;

internal class BeEqualTo<T> : IExpectation<T>
{
	private readonly T _expected;

	public BeEqualTo(T expected)
	{
		_expected = expected;
	}

	/// <inheritdoc />
	public ExpectationResult IsMetBy(T actual)
	{
		if (_expected?.Equals(actual) == true)
		{
			return new ExpectationResult.Success();
		}

		return new ExpectationResult.Failure(ToString(), $"found {actual}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"to be equal to {_expected}";
}
