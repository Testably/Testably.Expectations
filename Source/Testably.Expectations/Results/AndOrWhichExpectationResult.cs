using System;
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
	private readonly TValue _returnValue = returnValue;

	/// <summary>
	///     Allows specifying expectations on a property of the current value.
	/// </summary>
	public WhichResult<TProperty, AndOrWhichExpectationResult<TResult, TValue, TSelf>>
		Which<TProperty>(
			Expression<Func<TResult, TProperty?>> selector,
			[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "")
	{
		return new WhichResult<TProperty, AndOrWhichExpectationResult<TResult, TValue, TSelf>>(
			(expectations, doNotPopulateThisValue2) =>
			{
				return new AndOrWhichExpectationResult<TResult, TValue, TSelf>(
					_expectationBuilder.Which<TResult, TProperty?, That<TProperty?>>(
						PropertyAccessor<TResult, TProperty?>.FromExpression(selector),
						expectations,
						e => new ThatImpl<TProperty?>(e),
						b => b.AppendMethod(nameof(Which), doNotPopulateThisValue1)
							.AppendMethod(nameof(WhichResult<TProperty, TResult>.Should),
								doNotPopulateThisValue2),
						whichPropertyTextSeparator: "should "),
					_returnValue);
			});
	}

	/// <summary>
	///     Intermediate result for chaining Which and Should methods.
	/// </summary>
	public class WhichResult<TProperty, TReturn>(
		Func<Action<That<TProperty?>>, string, TReturn> resultCallback)
	{
		/// <summary>
		///     Specifies the expectations on the selected property.
		/// </summary>
		public TReturn Should(
			Action<That<TProperty?>> expectations,
			[CallerArgumentExpression("expectations")]
			string doNotPopulateThisValue = "")
		{
			return resultCallback(expectations, doNotPopulateThisValue);
		}
	}
}
