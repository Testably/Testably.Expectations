using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TResult,TValue}" />, allows specifying
///     options on the <see cref="StringEqualityOptions" />.
/// </summary>
public class StringEqualityResult<TResult, TValue>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	StringEqualityOptions options)
	: StringEqualityResult<TResult, TValue,
		StringEqualityResult<TResult, TValue>>(
		expectationBuilder,
		returnValue,
		options);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TResult,TValue}" />, allows specifying
///     options on the <see cref="StringMatcher" />.
/// </summary>
public class StringEqualityResult<TResult, TValue, TSelf>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	StringEqualityOptions options)
	: AndOrResult<TResult, TValue, TSelf>(expectationBuilder, returnValue)
	where TSelf : StringEqualityResult<TResult, TValue, TSelf>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public StringEqualityResult<TResult, TValue, TSelf> IgnoringCase()
	{
		options.IgnoringCase();
		_expectationBuilder.AppendMethodStatement(nameof(IgnoringCase));
		return this;
	}

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s, according to the <paramref name="ignoreCase" />
	///     parameter.
	/// </summary>
	public StringEqualityResult<TResult, TValue, TSelf> IgnoringCase(
		bool ignoreCase,
		[CallerArgumentExpression("ignoreCase")]
		string doNotPopulateThisValue = "")
	{
		options.IgnoringCase(ignoreCase);
		_expectationBuilder.AppendMethodStatement(nameof(IgnoringCase), doNotPopulateThisValue);
		return this;
	}

	/// <summary>
	///     Uses the provided <paramref name="comparer" /> for comparing <see langword="string" />s.
	/// </summary>
	public StringEqualityResult<TResult, TValue, TSelf> Using(
		IEqualityComparer<string> comparer,
		[CallerArgumentExpression("comparer")] string doNotPopulateThisValue = "")
	{
		options.UsingComparer(comparer);
		_expectationBuilder.AppendMethodStatement(nameof(Using), doNotPopulateThisValue);
		return this;
	}
}
