using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Testably.Expectations.Common;

namespace Testably.Expectations;

[StackTraceHidden]
[DebuggerNonUserCode]
public static class Expect
{
	public static void That<TActual>([NotNull] TActual actual,
		Func<IConstraint<TActual>, IConstraint<TActual>> constraintBuilder,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		var constraint = constraintBuilder.Invoke(new Constraint<TActual>());
		var result = constraint.ApplyTo(actual);

		if (!result.IsSuccess())
		{
			ReportFailure(result, actual, null, actualExpression);
		}
		else
		{
			Debug.Assert(actual != null);
		}

	}

	public static void That<TActual>([NotNull] TActual actual,
		IConstraint<TActual> constraint,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		var result = constraint.ApplyTo(actual);

		if (!result.IsSuccess())
		{
			ReportFailure(result, actual, null, actualExpression);
		}
		else
		{
			Debug.Assert(actual != null);
		}

	}

	public static void That<TActual>(TActual actual,
		Func<IConstraint<TActual>, INullableConstraint<TActual>> constraintBuilder,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		var constraint = constraintBuilder.Invoke(new Constraint<TActual>());
		var result = constraint.ApplyTo(actual);

		if (!result.IsSuccess())
		{
			ReportFailure(result, actual, null, actualExpression);
		}
	}

	[DoesNotReturn]
	private static void ReportFailure<TActual>(ConstraintResult<TActual> result, TActual? actual, string? message, string actualExpression)
	{
		Initialization.State.Value.Throw(result.CreateMessage(actualExpression, actual));
	}
}
