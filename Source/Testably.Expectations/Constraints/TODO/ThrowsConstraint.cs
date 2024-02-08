using System;
using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class ThrowsConstraint<TException> : IConstraint<Action, TException?>
	where TException : Exception
{
	public string ExpectationText => $"to throw {typeof(TException).Name}";

	public ConstraintResult Satisfies(Action? actual)
	{
		try
		{
			actual?.Invoke();
		}
		catch (TException ex)
		{
			return new ConstraintResult<TException>(true, ex);
		}
		catch (Exception)
		{
			return new ConstraintResult<TException>(false, null);
		}
		return new ConstraintResult<TException>(false, null);
	}
}
