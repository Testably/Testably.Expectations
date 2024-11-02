using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TResult,TValue}" />, allows specifying
///     options
///     on
///     the <see cref="StringMatcher" />.
/// </summary>
public class CountResult<TResult, TValue>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	Quantifier quantifier)
	: CountResult<TResult, TValue,
		CountResult<TResult, TValue>>(
		expectationBuilder,
		returnValue,
		quantifier);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TResult,TValue}" />, allows specifying
///     options
///     on
///     the <see cref="StringMatcher" />.
/// </summary>
public class CountResult<TResult, TValue, TSelf>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	Quantifier quantifier)
	: AndOrResult<TResult, TValue, TSelf>(expectationBuilder, returnValue)
	where TSelf : CountResult<TResult, TValue, TSelf>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Verifies, that it occurs at least <paramref name="minimum" /> times.
	/// </summary>
	public TSelf AtLeast(
		int minimum,
		[CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		quantifier.AtLeast(minimum);
		_expectationBuilder.AppendMethodStatement(nameof(AtLeast), doNotPopulateThisValue);
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
		_expectationBuilder.AppendMethodStatement(nameof(AtMost), doNotPopulateThisValue);
		return (TSelf)this;
	}

	/// <summary>
	///     Verifies, that it occurs between <paramref name="minimum" />...
	/// </summary>
	public BetweenResult<TSelf> Between(
		int minimum,
		[CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
		=> new(_expectationBuilder.AppendMethodStatement(nameof(Between), doNotPopulateThisValue),
			maximum =>
			{
				quantifier.Between(minimum, maximum);
				return (TSelf)this;
			});

	/// <summary>
	///     Verifies, that it occurs exactly <paramref name="expected" /> times.
	/// </summary>
	public TSelf Exactly(
		int expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		quantifier.Exactly(expected);
		_expectationBuilder.AppendMethodStatement(nameof(Exactly), doNotPopulateThisValue);
		return (TSelf)this;
	}

	/// <summary>
	///     Verifies, that it occurs never.
	/// </summary>
	public TSelf Never()
	{
		quantifier.Exactly(0);
		_expectationBuilder.AppendMethodStatement(nameof(Never));
		return (TSelf)this;
	}

	/// <summary>
	///     Verifies, that it occurs exactly once.
	/// </summary>
	public TSelf Once()
	{
		quantifier.Exactly(1);
		_expectationBuilder.AppendMethodStatement(nameof(Once));
		return (TSelf)this;
	}
}
