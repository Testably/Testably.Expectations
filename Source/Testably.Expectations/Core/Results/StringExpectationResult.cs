using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrExpectationResult{TResult,TValue}" />, allows specifying
///     options on the <see cref="StringOptions" />.
/// </summary>
public class StringExpectationResult<TResult, TValue>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue,
	StringOptions options)
	: StringExpectationResult<TResult, TValue,
		StringExpectationResult<TResult, TValue>>(
		expectationBuilder,
		returnValue,
		options);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrExpectationResult{TResult,TValue}" />, allows specifying
///     options
///     on
///     the <see cref="StringMatcher" />.
/// </summary>
public class StringExpectationResult<TResult, TValue, TSelf>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue,
	StringOptions options)
	: AndOrExpectationResult<TResult, TValue, TSelf>(expectationBuilder, returnValue)
	where TSelf : StringExpectationResult<TResult, TValue, TSelf>
{
	private readonly IExpectationBuilder _expectationBuilder1 = expectationBuilder;

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public StringExpectationResult<TResult, TValue, TSelf> IgnoringCase()
	{
		options.IgnoringCase();
		_expectationBuilder1.AppendExpression(b => b.AppendMethod(nameof(IgnoringCase)));
		return this;
	}

	/// <summary>
	///     Uses the provided <paramref name="comparer" /> for comparing <see langword="string" />s.
	/// </summary>
	public StringExpectationResult<TResult, TValue, TSelf> Using(
		IEqualityComparer<string> comparer,
		[CallerArgumentExpression("comparer")] string doNotPopulateThisValue = "")
	{
		options.UsingComparer(comparer);
		_expectationBuilder1.AppendExpression(b
			=> b.AppendMethod(nameof(Using), doNotPopulateThisValue));
		return this;
	}
}
