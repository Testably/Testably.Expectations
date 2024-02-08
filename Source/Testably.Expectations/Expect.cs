using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Internal;
using Testably.Expectations.Internal;

namespace Testably.Expectations;

[StackTraceHidden]
[DebuggerNonUserCode]
public static class Expect
{
	public static void That<TActual>([NotNull] TActual actual,
		Expectation expectation,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		ExpectationResult result = expectation.ApplyTo(actual);

		if (!result.IsSuccess)
		{
			ReportFailure(result, actual, null, actualExpression);
		}
		else
		{
			Debug.Assert(actual != null);
		}
	}

	public static void That<TActual, TTarget>([NotNull] TActual actual,
		Expectation<TActual, TTarget> expectation,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		ExpectationResult result = expectation.ApplyTo(actual);

		if (!result.IsSuccess)
		{
			ReportFailure(result, actual, null, actualExpression);
		}
		else
		{
			Debug.Assert(actual != null);
		}
	}

	public static void That<TActual>(TActual actual,
		NullableExpectation nullableExpectation,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		ExpectationResult result = nullableExpectation.ApplyTo(actual);

		if (!result.IsSuccess)
		{
			ReportFailure(result, actual, null, actualExpression);
		}
	}

	public static void That<TActual, TTarget>(TActual actual,
		NullableExpectation<TActual, TTarget> constraint,
		[CallerArgumentExpression(nameof(actual))] string actualExpression = "")
	{
		ExpectationResult result = constraint.ApplyTo(actual);

		if (!result.IsSuccess)
		{
			ReportFailure(result, actual, null, actualExpression);
		}
	}

	[DoesNotReturn]
	private static void ReportFailure<TActual>(
		ExpectationResult result,
		TActual? actual,
		string? because,
		string actualExpression)
	{
		because ??= "";
		var failureMessage = $"Expected {actualExpression} {result.ExpectationText}{because}, but found {actual}.";
		Initialization.State.Value.Throw(failureMessage);
	}
}
