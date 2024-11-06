﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TType" />?.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TType,TThat}" />, allows specifying a
///     tolerance.
/// </summary>
public class NullableNumberToleranceResult<TType, TThat>(
	ExpectationBuilder expectationBuilder,
	TThat returnValue,
	NumberTolerance<TType> options)
	: NullableNumberToleranceResult<TType, TThat,
		NullableNumberToleranceResult<TType, TThat>>(
		expectationBuilder,
		returnValue,
		options)
	where TType : struct, IComparable<TType>;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TType" />?.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TType,TThat}" />, allows specifying a
///     tolerance.
/// </summary>
public class NullableNumberToleranceResult<TType, TThat, TSelf>(
	ExpectationBuilder expectationBuilder,
	TThat returnValue,
	NumberTolerance<TType> options)
	: AndOrResult<TType?, TThat, TSelf>(expectationBuilder, returnValue)
	where TSelf : NullableNumberToleranceResult<TType, TThat, TSelf>
	where TType : struct, IComparable<TType>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Specifies a tolerance to apply on the number comparison.
	/// </summary>
	public NullableNumberToleranceResult<TType, TThat, TSelf> Within(TType tolerance,
		[CallerArgumentExpression("tolerance")]
		string doNotPopulateThisValue = "")
	{
		options.SetTolerance(tolerance);
		_expectationBuilder.AppendMethodStatement(nameof(Within), doNotPopulateThisValue);
		return this;
	}
}
