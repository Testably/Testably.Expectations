using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrExpectationResult{TResult,TValue}" />, allows specifying a
///     tolerance.
/// </summary>
public class TimeToleranceExpectationResult<TResult, TValue>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	TimeTolerance options)
	: TimeToleranceExpectationResult<TResult, TValue,
		TimeToleranceExpectationResult<TResult, TValue>>(
		expectationBuilder,
		returnValue,
		options);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrExpectationResult{TResult,TValue}" />, allows specifying a
///     tolerance.
/// </summary>
public class TimeToleranceExpectationResult<TResult, TValue, TSelf>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	TimeTolerance options)
	: AndOrExpectationResult<TResult, TValue, TSelf>(expectationBuilder, returnValue)
	where TSelf : TimeToleranceExpectationResult<TResult, TValue, TSelf>
{
	private readonly ExpectationBuilder _expectationBuilder1 = expectationBuilder;

	/// <summary>
	///     Specifies a tolerance to apply on the time comparison.
	/// </summary>
	public TimeToleranceExpectationResult<TResult, TValue, TSelf> Within(TimeSpan tolerance,
		[CallerArgumentExpression("tolerance")]
		string doNotPopulateThisValue = "")
	{
		if (tolerance < TimeSpan.Zero)
		{
			throw new ArgumentOutOfRangeException(nameof(tolerance), "Tolerance must be non-negative");
		}

		options.SetTolerance(tolerance);
		_expectationBuilder1.AppendMethodStatement(nameof(Within), doNotPopulateThisValue);
		return this;
	}
}
