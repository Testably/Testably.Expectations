using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrExpectationResult{TResult,TValue}" />, allows specifying
///     options
///     on
///     the <see cref="StringMatcher" />.
/// </summary>
public class CountExpectationResult<TResult, TValue>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue,
	Quantifier quantifier)
	: CountExpectationResult<TResult, TValue,
		CountExpectationResult<TResult, TValue>>(
		expectationBuilder,
		returnValue,
		quantifier);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrExpectationResult{TResult,TValue}" />, allows specifying
///     options
///     on
///     the <see cref="StringMatcher" />.
/// </summary>
public class CountExpectationResult<TResult, TValue, TSelf>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue,
	Quantifier quantifier)
	: AndOrExpectationResult<TResult, TValue, TSelf>(expectationBuilder, returnValue)
	where TSelf : CountExpectationResult<TResult, TValue, TSelf>
{
	private readonly IExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Verifies, that it occurs at least <paramref name="minimum" /> times.
	/// </summary>
	public TSelf AtLeast(
		int minimum,
		[CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		quantifier.AtLeast(minimum);
		_expectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(AtLeast), doNotPopulateThisValue));
		return (TSelf)this;
	}

	/// <summary>
	///     Verifies, that it occurs at most <paramref name="maximum" /> times.
	/// </summary>
	public TSelf AtMost(
		int maximum,
		[CallerArgumentExpression("maximum")] string doNotPopulateThisValue = "")
	{
		quantifier.AtMost(maximum);
		_expectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(AtMost), doNotPopulateThisValue));
		return (TSelf)this;
	}

	/// <summary>
	///     Verifies, that it occurs between <paramref name="minimum" />...
	/// </summary>
	public BetweenResult<TSelf> Between(
		int minimum,
		[CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		_expectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(Between), doNotPopulateThisValue));
		return new BetweenResult<TSelf>(
			maximum =>
			{
				quantifier.Between(minimum, maximum);
				return (TSelf)this;
			},
			callback => _expectationBuilder.AppendExpression(callback));
	}

	/// <summary>
	///     Verifies, that it occurs exactly <paramref name="expected" /> times.
	/// </summary>
	public TSelf Exactly(
		int expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		quantifier.Exactly(expected);
		_expectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(Exactly), doNotPopulateThisValue));
		return (TSelf)this;
	}

	/// <summary>
	///     Verifies, that it occurs never.
	/// </summary>
	public TSelf Never()
	{
		quantifier.Exactly(0);
		_expectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Never)));
		return (TSelf)this;
	}

	/// <summary>
	///     Verifies, that it occurs exactly once.
	/// </summary>
	public TSelf Once()
	{
		quantifier.Exactly(1);
		_expectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Once)));
		return (TSelf)this;
	}
}
