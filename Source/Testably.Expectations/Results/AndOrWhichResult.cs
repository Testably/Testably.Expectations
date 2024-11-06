using System;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TType" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TType,TThat}" />, allows accessing
///     underlying
///     properties with <see cref="AndOrWhichResult{TResult,TValue,TSelf}.Which{TProperty}" />.
/// </summary>
public class AndOrWhichResult<TType, TThat>(
	ExpectationBuilder expectationBuilder,
	TThat returnValue)
	: AndOrWhichResult<TType, TThat, AndOrWhichResult<TType, TThat>>(
		expectationBuilder, returnValue);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TType" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TType,TThat}" />, allows accessing
///     underlying
///     properties with <see cref="Which{TProperty}" />.
/// </summary>
public class AndOrWhichResult<TType, TThat, TSelf>(
	ExpectationBuilder expectationBuilder,
	TThat returnValue)
	: AndOrResult<TType, TThat, TSelf>(expectationBuilder, returnValue)
	where TSelf : AndOrWhichResult<TType, TThat, TSelf>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;
	private readonly TThat _returnValue = returnValue;

	/// <summary>
	///     Allows specifying expectations on a property of the current value.
	/// </summary>
	public WhichResult<TProperty, AndOrWhichResult<TType, TThat, TSelf>>
		Which<TProperty>(
			Expression<Func<TType, TProperty?>> selector,
			[CallerArgumentExpression("selector")] string doNotPopulateThisValue1 = "")
	{
		return new WhichResult<TProperty, AndOrWhichResult<TType, TThat, TSelf>>(
			(expectations, doNotPopulateThisValue2) =>
			{
				return new AndOrWhichResult<TType, TThat, TSelf>(
					_expectationBuilder
						.ForProperty(PropertyAccessor<TType, TProperty?>.FromExpression(selector),
							(property, expectation) => $" which {property}should {expectation}")
						.AddExpectations(e => expectations(new Expect.ThatSubject<TProperty?>(e)))
						.AppendMethodStatement(nameof(Which), doNotPopulateThisValue1)
						.AppendMethodStatement(nameof(WhichResult<TProperty, TType>.Should),
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
			[CallerArgumentExpression("expectations")] string doNotPopulateThisValue = "")
		{
			return resultCallback(expectations, doNotPopulateThisValue);
		}
	}
}
