using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrExpectationResult{TResult,TValue}" />, allows specifying
///     options on the <see cref="StringMatcher" />.
/// </summary>
public class StringMatcherExpectationResult<TResult, TValue>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	StringMatcher expected)
	: AndOrExpectationResult<TResult, TValue>(expectationBuilder, returnValue)
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Interprets the expected <see langword="string" /> as <see cref="Regex" /> pattern.
	/// </summary>
	public StringMatcherExpectationResult<TResult, TValue> AsRegex()
	{
		expected.AsRegex();
		_expectationBuilder.AppendMethodStatement(nameof(AsRegex));
		return this;
	}

	/// <summary>
	///     Interprets the expected <see langword="string" /> as wildcard pattern.<br />
	///     Supports * to match zero or more characters and ? to match exactly one character.
	/// </summary>
	public StringMatcherExpectationResult<TResult, TValue> AsWildcard()
	{
		expected.AsWildcard();
		_expectationBuilder.AppendMethodStatement(nameof(AsWildcard));
		return this;
	}

	/// <summary>
	///     Interprets the expected <see langword="string" /> to be exactly equal.
	/// </summary>
	public StringMatcherExpectationResult<TResult, TValue> Exactly()
	{
		expected.Exactly();
		_expectationBuilder.AppendMethodStatement(nameof(Exactly));
		return this;
	}

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public StringMatcherExpectationResult<TResult, TValue> IgnoringCase()
	{
		expected.IgnoringCase();
		_expectationBuilder.AppendMethodStatement(nameof(IgnoringCase));
		return this;
	}

	/// <summary>
	///     Uses the provided <paramref name="comparer" /> for comparing <see langword="string" />s.
	/// </summary>
	public StringMatcherExpectationResult<TResult, TValue> Using(
		IEqualityComparer<string> comparer,
		[CallerArgumentExpression("comparer")] string doNotPopulateThisValue = "")
	{
		expected.UsingComparer(comparer);
		_expectationBuilder.AppendMethodStatement(nameof(Using), doNotPopulateThisValue);
		return this;
	}
}
