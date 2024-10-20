using System.Diagnostics;

namespace Testably.Expectations.Core.Results;

/// <summary>
///     The result of an assertion with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     Allows combining multiple assertions with <see cref="AssertionResultAndOr{TResult, TValue, TSelf}.And" /> and
///     <see cref="AssertionResultAndOr{TResult, TValue, TSelf}.Or" />.
/// </summary>
[StackTraceHidden]
public class AssertionResultAndOr<TResult, TValue>(
	IExpectationBuilder expectationBuilder,
	TValue assertion)
	: AssertionResultAndOr<TResult, TValue, AssertionResultAndOr<TResult, TValue>>(
		expectationBuilder, assertion);

/// <summary>
///     The result of an assertion with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     Allows combining multiple assertions with <see cref="And" /> and <see cref="Or" />.
/// </summary>
[StackTraceHidden]
public class AssertionResultAndOr<TResult, TValue, TSelf>(
	IExpectationBuilder expectationBuilder,
	TValue assertion)
	: AssertionResult<TResult, TSelf>(expectationBuilder)
	where TSelf : AssertionResultAndOr<TResult, TValue, TSelf>
{
	/// <summary>
	///     Combine multiple expectations with AND
	/// </summary>
	public TValue And
	{
		get
		{
			_expectationBuilder.And(b => b.Append(".").Append(nameof(And)));
			return assertion;
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
			return assertion;
		}
	}

	private readonly IExpectationBuilder _expectationBuilder = expectationBuilder;
}
