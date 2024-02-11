using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Ambient;

namespace Testably.Expectations;

/// <summary>
///     The starting point for checking expectations.
/// </summary>
[StackTraceHidden]
public static class Expect
{
	/// <summary>
	///     Checks that the <paramref name="actual" /> value meets the <paramref name="expectation" />.
	/// </summary>
	/// <remarks>
	///     Throws when the <paramref name="actual" /> value is <see langword="null" />.
	/// </remarks>
	public static void That<TActual, TTarget>([NotNull] TActual actual,
		Expectation<TActual, TTarget> expectation,
		[CallerArgumentExpression(nameof(actual))]
		string actualExpression = "")
	{
		ExpectationResult result = expectation.IsMetBy(actual);

		if (result is ExpectationResult.Failure failure)
		{
			ReportFailure(failure, null, actualExpression);
		}
		else
		{
			Debug.Assert(actual != null);
		}
	}

	/// <summary>
	///     Checks that the <paramref name="actual" /> value meets the <paramref name="expectation" />.
	/// </summary>
	/// <remarks>
	///     The <paramref name="actual" /> value can be <see langword="null" />.
	/// </remarks>
	public static void That<TActual, TTarget>(TActual? actual,
		NullableExpectation<TActual, TTarget> expectation,
		[CallerArgumentExpression(nameof(actual))]
		string actualExpression = "")
	{
		ExpectationResult result = expectation.IsMetBy(actual);

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
