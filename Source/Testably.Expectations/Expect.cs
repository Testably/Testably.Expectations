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
		Func<IConstraintBuilder<TActual>, IConstraint<TActual>> constraintBuilder,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		var builder = ExpectationContext.Current.GetEmptyConstraintBuilder<TActual>();
		constraintBuilder.Invoke(builder);
		var result = builder.ApplyTo(actual);

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
		Func<IConstraintBuilder<TActual>, IConstraint> constraintBuilder,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		var builder = ExpectationContext.Current.GetEmptyConstraintBuilder<TActual>();
		constraintBuilder.Invoke(builder);
		var result = builder.ApplyTo(actual);

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
		IConstraint _,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		var builder = ExpectationContext.Current.GetRegisteredConstraintBuilder<TActual>();
		var result = builder.ApplyTo(actual);

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
		Func<IConstraintBuilder<TActual>, INullableConstraint<TActual>> constraintBuilder,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		var builder = ExpectationContext.Current.GetEmptyConstraintBuilder<TActual>();
		constraintBuilder.Invoke(builder);
		var result = builder.ApplyTo(actual);

		if (!result.IsSuccess())
		{
			ReportFailure(result, actual, null, actualExpression);
		}
	}

	[DoesNotReturn]
	private static void ReportFailure<TActual>(ExpectationResult<TActual> result, TActual? actual, string? message, string actualExpression)
	{
		Initialization.State.Value.Throw(result.CreateMessage(actualExpression, actual));
	}
}
