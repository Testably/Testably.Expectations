using System;
using Testably.Expectations.Core;

namespace Testably.Expectations.Expectations.Action;

internal class ThrowException<TException> : IExpectation<System.Action, TException>
	where TException : Exception
{
	#region IExpectation<Action,TException?> Members

	/// <inheritdoc />
	public ExpectationResult IsMetBy(System.Action actual)
	{
		try
		{
			actual?.Invoke();
		}
		catch (TException ex)
		{
			return new ExpectationResult.Success<TException>(ex);
		}
		catch (Exception ex)
		{
			return new ExpectationResult.Failure<Exception>(ex, ToString(),
				$"the thrown exception was {ex.GetType().Name}");
		}

		return new ExpectationResult.Failure(ToString(), "no exception was thrown");
	}

	#endregion

	/// <inheritdoc />
	public override string ToString()
		=> $"to throw {typeof(TException).Name}";
}
