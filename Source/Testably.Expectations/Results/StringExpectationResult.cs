using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

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
	private readonly IExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public StringExpectationResult<TResult, TValue, TSelf> IgnoringCase()
	{
		options.IgnoringCase();
		_expectationBuilder.AppendExpression(b => b.AppendMethod(nameof(IgnoringCase)));
		return this;
	}

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s, according to the <paramref name="ignoreCase" /> parameter.
	/// </summary>
	public StringExpectationResult<TResult, TValue, TSelf> IgnoringCase(
		bool ignoreCase,
		[CallerArgumentExpression("ignoreCase")] string doNotPopulateThisValue = "")
	{
		options.IgnoringCase(ignoreCase);
		_expectationBuilder.AppendExpression(b => b.AppendMethod(nameof(IgnoringCase), doNotPopulateThisValue));
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
		_expectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(Using), doNotPopulateThisValue));
		return this;
	}
}
