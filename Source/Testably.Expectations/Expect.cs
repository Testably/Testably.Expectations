using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

[StackTraceHidden]
[DebuggerNonUserCode]
public static class Expect
{
	public static void That<TActual>([NotNull] TActual actual,
		AndConstraint constraint,
		[CallerArgumentExpression(nameof(actual))]
		string actualExpression = "")
	{
		ExpectationResult<TActual> result = constraint.ApplyTo(actual);

		if (!result.IsSuccess())
		{
			ReportFailure(result, actual, null, actualExpression);
		}
		else
		{
			Debug.Assert(actual != null);
		}
	}

	public static void That<TActual, TTarget>([NotNull] TActual actual,
		AndConstraint<TActual, TTarget> constraint,
		[CallerArgumentExpression(nameof(actual))]
		string actualExpression = "")
	{
		ExpectationResult<TActual> result = constraint.ApplyTo(actual);

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
		NullableAndConstraint constraint,
		[CallerArgumentExpression(nameof(actual))]
		string actualExpression = "")
	{
		ExpectationResult<TActual> result = constraint.ApplyTo(actual);

		if (!result.IsSuccess())
		{
			ReportFailure(result, actual, null, actualExpression);
		}
	}

	public static void That<TActual, TTarget>(TActual actual,
		NullableAndConstraint<TActual, TTarget> constraint,
		[CallerArgumentExpression(nameof(actual))]
		string actualExpression = "")
	{
		ExpectationResult<TActual> result = constraint.ApplyTo(actual);

		if (!result.IsSuccess())
		{
			ReportFailure(result, actual, null, actualExpression);
		}
	}

	[DoesNotReturn]
	private static void ReportFailure<TActual>(ExpectationResult<TActual> result, TActual? actual,
		string? message, string actualExpression)
	{
		Initialization.State.Value.Throw(result.CreateMessage(actualExpression, actual));
	}
}
