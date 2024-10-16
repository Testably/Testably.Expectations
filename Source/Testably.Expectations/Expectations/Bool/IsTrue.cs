using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Bool;

internal class IsTrue : IExpectation<bool>
{
	#region IExpectation<bool> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(bool actual)
	{
		if (true.Equals(actual))
		{
			return new ExpectationResult.Success(ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to be {Formatter.Format(true)}";
}
