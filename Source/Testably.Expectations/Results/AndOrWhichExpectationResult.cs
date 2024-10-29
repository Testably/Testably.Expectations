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
	ExpectationBuilder expectationBuilder,
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
	ExpectationBuilder expectationBuilder,
	TValue returnValue)
	: AndOrExpectationResult<TResult, TValue, TSelf>(expectationBuilder, returnValue)
	where TSelf : AndOrWhichExpectationResult<TResult, TValue, TSelf>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;
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
					_expectationBuilder
						.ForProperty(PropertyAccessor<TResult, TProperty?>.FromExpression(selector),
							(property, expectation) => $" which {property}should {expectation}")
						.AddExpectations(e => expectations(new Expect.ThatSubject<TProperty?>(e)))
						.AppendMethodStatement(nameof(Which), doNotPopulateThisValue1)
						.AppendMethodStatement(nameof(WhichResult<TProperty, TResult>.Should),
							doNotPopulateThisValue2),
					_returnValue);
			});
	}

	/// <summary>
	///     Intermediate result for chaining Which and Should methods.
	/// </summary>
	public class WhichResult<TProperty, TReturn>(
		Func<Action<IThat<TProperty?>>, string, TReturn> resultCallback)
	{
		/// <summary>
		///     Specifies the expectations on the selected property.
		/// </summary>
		public TReturn Should(
			Action<IThat<TProperty?>> expectations,
			[CallerArgumentExpression("expectations")]
			string doNotPopulateThisValue = "")
		{
			return resultCallback(expectations, doNotPopulateThisValue);
		}
	}
}
