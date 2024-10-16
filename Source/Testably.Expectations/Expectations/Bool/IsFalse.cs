using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Bool;

internal class IsFalse : IExpectation<bool>
{
	#region IExpectation<bool> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(bool actual)
	{
		if (false.Equals(actual))
		{
			return new ExpectationResult.Success(ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to be {Formatter.Format(false)}";
}
