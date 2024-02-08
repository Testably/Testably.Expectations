using System;
using Testably.Expectations.Core;

namespace Testably.Expectations.Constraints;

internal class ThrowsConstraint<TException> : ComplexConstraint<Action, TException?>
	where TException : Exception
{
	public override string ExpectationText => $"to throw {typeof(TException).Name}";

	protected override ConstraintResult<TException?> Satisfies(Action actual)
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

		return new ConstraintResult<TException?>(caughtException is TException,
			caughtException as TException);
	}
}
