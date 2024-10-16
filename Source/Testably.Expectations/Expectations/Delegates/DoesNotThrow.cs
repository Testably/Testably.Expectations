using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Strings;

internal class DoesNotThrow<TActual> : IDelegateExpectation<TActual>
{
	/// <inheritdoc />
	public ExpectationResult IsMetBy(TActual? actual, Exception? exception)
	{
		if (exception is not null)
		{
			return new ExpectationResult.Failure<TActual?>(actual, ToString(),
				$"it did throw {Formatter.PrependAOrAn(exception.GetType().Name)}:{Environment.NewLine}\t{exception.Message}");
		}

		return new ExpectationResult.Success<TActual?>(actual, ToString());
	}

	/// <inheritdoc />
	public override string ToString()
		=> "does not throw";
}
