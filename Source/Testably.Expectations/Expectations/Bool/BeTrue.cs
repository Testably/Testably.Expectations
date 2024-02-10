using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations.Bool;

internal class BeTrue : IExpectation<bool>
{
	#region IExpectation<bool> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(bool actual)
	{
		if (true.Equals(actual))
		{
			return new ExpectationResult.Success(ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"found {actual}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> "to be True";
}
