using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TResult,TValue}" />, allows specifying a
///     tolerance.
/// </summary>
public class TimeToleranceResult<TResult, TValue>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	TimeTolerance options)
	: TimeToleranceResult<TResult, TValue,
		TimeToleranceResult<TResult, TValue>>(
		expectationBuilder,
		returnValue,
		options);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TResult,TValue}" />, allows specifying a
///     tolerance.
/// </summary>
public class TimeToleranceResult<TResult, TValue, TSelf>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	TimeTolerance options)
	: AndOrResult<TResult, TValue, TSelf>(expectationBuilder, returnValue)
	where TSelf : TimeToleranceResult<TResult, TValue, TSelf>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Specifies a tolerance to apply on the time comparison.
	/// </summary>
	public TimeToleranceResult<TResult, TValue, TSelf> Within(TimeSpan tolerance,
		[CallerArgumentExpression("tolerance")]
		string doNotPopulateThisValue = "")
	{
		options.SetTolerance(tolerance);
		_expectationBuilder.AppendMethodStatement(nameof(Within), doNotPopulateThisValue);
		return this;
	}
}
