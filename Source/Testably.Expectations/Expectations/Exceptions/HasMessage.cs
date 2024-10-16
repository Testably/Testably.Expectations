using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Expectations.Exceptions;

internal class HasMessage<TException> : INullableExpectation<TException>,
	IDelegateExpectation<object>
	where TException : Exception
{
	private readonly string _expected;

	public HasMessage(string expected)
	{
		_expected = expected;
	}

	#region IDelegateExpectation<object> Members

	public ExpectationResult IsMetBy(SourceValue<object> value)
	{
		return IsMetBy(value.Exception as TException);
	}

	#endregion

	#region INullableExpectation<TException> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(TException? actual)
	{
		if (_expected.Equals(actual?.Message))
		{
			return new ExpectationResult.Success<TException?>(actual, ToString());
		}

		return new ExpectationResult.Failure(ToString(),
			$"found {Formatter.Format(actual?.Message)} which {new StringDifference(actual?.Message, _expected)}");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"has Message equal to {Formatter.Format(_expected)}";
}
