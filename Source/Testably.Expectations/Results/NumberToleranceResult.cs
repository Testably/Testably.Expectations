using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TNumber" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TResult,TValue}" />, allows specifying a
///     tolerance.
/// </summary>
public class NumberToleranceResult<TNumber, TResult>(
	ExpectationBuilder expectationBuilder,
	TResult returnValue,
	NumberTolerance<TNumber> options)
	: NumberToleranceResult<TNumber, TResult,
		NumberToleranceResult<TNumber, TResult>>(
		expectationBuilder,
		returnValue,
		options)
	where TNumber : struct, IComparable<TNumber>;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TResult,TValue}" />, allows specifying a
///     tolerance.
/// </summary>
public class NumberToleranceResult<TNumber, TResult, TSelf>(
	ExpectationBuilder expectationBuilder,
	TResult returnValue,
	NumberTolerance<TNumber> options)
	: AndOrResult<TNumber, TResult, TSelf>(expectationBuilder, returnValue)
	where TSelf : NumberToleranceResult<TNumber, TResult, TSelf>
	where TNumber : struct, IComparable<TNumber>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Specifies a tolerance to apply on the number comparison.
	/// </summary>
	public NumberToleranceResult<TNumber, TResult, TSelf> Within(TNumber tolerance,
		[CallerArgumentExpression("tolerance")]
		string doNotPopulateThisValue = "")
	{
		options.SetTolerance(tolerance);
		_expectationBuilder.AppendMethodStatement(nameof(Within), doNotPopulateThisValue);
		return this;
	}
}
