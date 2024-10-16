using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Strings;

internal class Throws<TException> : IDelegateExpectation
	  where TException : Exception
{
	/// <inheritdoc />
	public ExpectationResult IsMetBy(Exception? exception)
	{
		if (exception is TException typedException)
		{
			return new ExpectationResult.Success<TException?>(typedException, ToString());
		}

		if (exception is null)
		{
			return new ExpectationResult.Failure<TException?>(null, ToString(), $"it did not");
		}

		return new ExpectationResult.Failure<TException?>(null, ToString(), $"it did throw {Formatter.PrependAOrAn(exception.GetType().Name)}:{Environment.NewLine}\t{exception.Message}");
	}

	/// <inheritdoc />
	public override string ToString()
		=> $"throws {Formatter.PrependAOrAn(typeof(TException).Name)}";
}
