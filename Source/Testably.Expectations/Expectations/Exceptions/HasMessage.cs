using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;

namespace Testably.Expectations.Expectations.Exceptions;

internal class HasMessage<TException> : INullableExpectation<TException>, IDelegateExpectation<object>
	  where TException : Exception
{
	private readonly string _expected;

	public HasMessage(string expected)
	{
		_expected = expected;
	}

	#region INullableExpectation<T> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(TException? actual)
	{
		if (_expected.Equals(actual?.Message) == true)
		{
			return new ExpectationResult.Success<TException?>(actual, ToString());
		}

		return new ExpectationResult.Failure(ToString(),
			$"found {Formatter.Format(actual?.Message)}");
	}

	public ExpectationResult IsMetBy(object? actual, Exception? exception)
		=> IsMetBy(exception as TException);

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"has Message equal to {Formatter.Format(_expected)}";
}
