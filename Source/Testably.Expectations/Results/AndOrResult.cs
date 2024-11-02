using Testably.Expectations.Core;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     Allows combining multiple expectations with <see cref="AndOrResult{TResult,TValue,TSelf}.And" /> and
///     <see cref="AndOrResult{TResult,TValue,TSelf}.Or" />.
/// </summary>
public class AndOrResult<TResult, TValue>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue)
	: AndOrResult<TResult, TValue, AndOrResult<TResult, TValue>>(
		expectationBuilder,
		returnValue);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     Allows combining multiple expectations with <see cref="And" /> and <see cref="Or" />.
/// </summary>
public class AndOrResult<TResult, TValue, TSelf>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue)
	: ExpectationResult<TResult, TSelf>(expectationBuilder)
	where TSelf : AndOrResult<TResult, TValue, TSelf>
{
	/// <summary>
	///     Combine multiple expectations with AND
	/// </summary>
	public TValue And
	{
		get
		{
			_expectationBuilder.And(b => b.Append('.').Append(nameof(And)));
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
			_expectationBuilder.Or(b => b.Append('.').Append(nameof(Or)));
			return returnValue;
		}
	}

	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;
}
