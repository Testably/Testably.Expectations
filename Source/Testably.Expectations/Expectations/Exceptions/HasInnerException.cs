using System;
using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations.Exceptions;

internal class HasInnerException<TException> : INullableExpectation<Exception>,
	IDelegateExpectation<object>
	where TException : Exception
{
	#region IDelegateExpectation<object> Members

	public ExpectationResult IsMetBy(SourceValue<object> value)
	{
		return IsMetBy(value.Exception as TException);
	}

	#endregion

	#region INullableExpectation<Exception> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(Exception? actual)
	{
		if (actual?.InnerException is TException exception)
		{
			return new ExpectationResult.Success<TException?>(exception, ToString());
		}

		return new ExpectationResult.Failure(ToString(),
			"found none");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> "has InnerException";
}
