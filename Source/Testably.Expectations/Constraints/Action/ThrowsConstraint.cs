using System;
using Testably.Expectations.Common;

namespace Testably.Expectations.Constraints.Action;
internal class ThrowsConstraint<TException> : ComplexConstraint<System.Action, TException?>
		where TException : Exception
{
	protected override ConstraintResult<TException?> Satisfies(System.Action actual)
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

		return new ConstraintResult<TException?>(caughtException is TException, caughtException as TException);
	}
	public override string ExpectationText => $"to throw {typeof(TException).Name}";
}
