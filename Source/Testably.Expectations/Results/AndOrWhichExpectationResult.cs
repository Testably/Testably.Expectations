using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrExpectationResult{TResult,TValue}" />, allows accessing
///     underlying
///     properties with <see cref="AndOrWhichExpectationResult{TResult,TValue,TSelf}.Which{TProperty}" />.
/// </summary>
public class AndOrWhichExpectationResult<TResult, TValue>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue)
	: AndOrWhichExpectationResult<TResult, TValue, AndOrWhichExpectationResult<TResult, TValue>>(
		expectationBuilder, returnValue);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrExpectationResult{TResult,TValue}" />, allows accessing
///     underlying
///     properties with <see cref="Which{TProperty}" />.
/// </summary>
public class AndOrWhichExpectationResult<TResult, TValue, TSelf>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue)
	: AndOrExpectationResult<TResult, TValue, TSelf>(expectationBuilder, returnValue)
	where TSelf : AndOrWhichExpectationResult<TResult, TValue, TSelf>
{
	private readonly IExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Allows specifying expectations on a property of the current value.
	/// </summary>
	public AndOrWhichExpectationResult<TResult, TValue, TSelf> Which<TProperty>(
		Expression<Func<TResult, TProperty?>> selector,
		Action<That<TProperty?>> expectations,
		[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "",
		[CallerArgumentExpression("expectations")]
		string doNotPopulateThisValue2 = "")
	{
		_expectationBuilder.Which<TResult, TProperty?>(
			PropertyAccessor<TResult, TProperty?>.FromExpression(selector),
			expectations,
			b => b.AppendMethod(nameof(Which), doNotPopulateThisValue1, doNotPopulateThisValue2));
		return this;
	}
}
