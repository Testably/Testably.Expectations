using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Booleans;

internal readonly struct Implies(bool consequent) : IExpectation<bool>
{
	public ExpectationResult IsMetBy(bool actual)
	{
		if (!actual || consequent)
		{
			return new ExpectationResult.Success<bool>(actual, ToString());
		}

		return new ExpectationResult.Failure(ToString(), "it did not");
	}

	public override string ToString()
		=> $"implies {Formatter.Format(consequent)}";
}
