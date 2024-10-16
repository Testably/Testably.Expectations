using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Int;

internal class BeGreaterThan : IExpectation<int>
{
	private readonly int _expected;

	public BeGreaterThan(int expected)
	{
		_expected = expected;
	}

	#region IExpectation<int> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(int actual)
	{
		if (actual > _expected)
		{
			return new ExpectationResult.Success(ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to be greater than {Formatter.Format(_expected)}";
}
