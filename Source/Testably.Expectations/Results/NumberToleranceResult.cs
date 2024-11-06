﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TType" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TNumber,TThat}" />, allows specifying a
///     tolerance.
/// </summary>
public class NumberToleranceResult<TType, TThat>(
	ExpectationBuilder expectationBuilder,
	TThat returnValue,
	NumberTolerance<TType> options)
	: NumberToleranceResult<TType, TThat,
		NumberToleranceResult<TType, TThat>>(
		expectationBuilder,
		returnValue,
		options)
	where TType : struct, IComparable<TType>;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TType" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TNumber,TThat}" />, allows specifying a
///     tolerance.
/// </summary>
public class NumberToleranceResult<TType, TThat, TSelf>(
	ExpectationBuilder expectationBuilder,
	TThat returnValue,
	NumberTolerance<TType> options)
	: AndOrResult<TType, TThat, TSelf>(expectationBuilder, returnValue)
	where TSelf : NumberToleranceResult<TType, TThat, TSelf>
	where TType : struct, IComparable<TType>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Specifies a tolerance to apply on the number comparison.
	/// </summary>
	public NumberToleranceResult<TType, TThat, TSelf> Within(TType tolerance,
		[CallerArgumentExpression("tolerance")]
		string doNotPopulateThisValue = "")
	{
		options.SetTolerance(tolerance);
		_expectationBuilder.AppendMethodStatement(nameof(Within), doNotPopulateThisValue);
		return this;
	}
}
