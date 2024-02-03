using System;
using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.Action;
internal class ThrowsConstraint<TException> : IConstraint<System.Action, TException>
		where TException : Exception
{
	public ConstraintResult<TException> ApplyTo(System.Action actual)
	{
		Exception? caughtException = null;
		try
		{
			actual();
		}
		catch (Exception ex)
		{
			caughtException = ex;
		}

		return new ConstraintResult<TException>(this, caughtException is TException);
	}
	public string ExpectationText => $"to throw {typeof(TException).Name}";
}
