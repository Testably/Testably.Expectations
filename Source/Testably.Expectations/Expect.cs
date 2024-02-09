using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Ambient;

namespace Testably.Expectations;

[StackTraceHidden]
public static class Expect
{
	public static void That<TActual, TTarget>([NotNull] TActual actual,
		Expectation<TActual, TTarget> expectation,
		[CallerArgumentExpression(nameof(actual))]
		string actualExpression = "")
	{
		ExpectationResult result = expectation.ApplyTo(actual);

		if (result is ExpectationResult.Failure failure)
		{
			ReportFailure(failure, null, actualExpression);
		}
		else
		{
			Debug.Assert(actual != null);
		}
	}

	public static void That<TActual, TTarget>(TActual? actual,
		NullableExpectation<TActual, TTarget> nullableExpectation,
		[CallerArgumentExpression(nameof(actual))]
		string actualExpression = "")
	{
		ExpectationResult result = nullableExpectation.ApplyTo(actual);

		if (result is ExpectationResult.Failure failure)
		{
			ReportFailure(failure, null, actualExpression);
		}
	}

	[DoesNotReturn]
	private static void ReportFailure(
		ExpectationResult.Failure result,
		string? because,
		string actualExpression)
	{
		because ??= "";
		string failureMessage =
			$"Expected {actualExpression} {result.ExpectationText}{because}, but {result.ResultText}.";
		Initialization.State.Value.Throw(failureMessage);
	}
}
