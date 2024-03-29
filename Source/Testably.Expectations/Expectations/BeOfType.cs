﻿using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations;

internal class BeOfType<TType> : IExpectation<object?, TType>
{
	#region IExpectation<object?,TType> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(object? actual)
	{
		if (actual is null)
		{
			return new ExpectationResult.Failure(ToString(),
				$"found {Formatter.Format<object?>(null)}");
		}

		if (actual is TType value)
		{
			return new ExpectationResult.Success<TType>(value, ToString());
		}

		return new ExpectationResult.Failure(ToString(), $"it was of type {actual.GetType().Name}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to be of type {typeof(TType).Name}";
}
