using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations;

internal class BeNull<TActual> : INullableExpectation<TActual?>
{
	#region INullableExpectation<TActual?> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(TActual? actual)
	{
		if (actual == null)
		{
			return new ExpectationResult.Success<TActual?>(default, ToString());
		}

		return new ExpectationResult.Failure<TActual>(actual, ToString(),
			$"found {Formatter.Format(actual)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to be {Formatter.Format<TActual>(default)}";
}
