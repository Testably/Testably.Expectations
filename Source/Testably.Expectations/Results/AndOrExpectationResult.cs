using System.Diagnostics;
using Testably.Expectations.Core;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     Allows combining multiple expectations with <see cref="AndOrExpectationResult{TResult,TValue,TSelf}.And" /> and
///     <see cref="AndOrExpectationResult{TResult,TValue,TSelf}.Or" />.
/// </summary>
public class AndOrExpectationResult<TResult, TValue>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue)
	: AndOrExpectationResult<TResult, TValue, AndOrExpectationResult<TResult, TValue>>(
		expectationBuilder,
		returnValue);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     Allows combining multiple expectations with <see cref="And" /> and <see cref="Or" />.
/// </summary>
public class AndOrExpectationResult<TResult, TValue, TSelf>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue)
	: ExpectationResult<TResult, TSelf>(expectationBuilder)
	where TSelf : AndOrExpectationResult<TResult, TValue, TSelf>
{
	/// <summary>
	///     Combine multiple expectations with AND
	/// </summary>
	public TValue And
	{
		get
		{
			_expectationBuilder.And(b => b.Append(".").Append(nameof(And)));
			return returnValue;
		}
	}

	/// <summary>
	///     Combine multiple expectations with OR
	/// </summary>
	public TValue Or
	{
		get
		{
			_expectationBuilder.Or(b => b.Append(".").Append(nameof(Or)));
			return returnValue;
		}
	}

	private readonly IExpectationBuilder _expectationBuilder = expectationBuilder;
}
