using Testably.Expectations.Core;

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
			return new ExpectationResult.Success();
		}

		return new ExpectationResult.Failure(ToString(), $"found {actual}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to be greater than {_expected}";
}
