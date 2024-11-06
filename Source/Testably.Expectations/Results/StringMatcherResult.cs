using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TType" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TType,TThat}" />, allows specifying
///     options on the <see cref="StringMatcher" />.
/// </summary>
public class StringMatcherResult<TType, TThat>(
	ExpectationBuilder expectationBuilder,
	TThat returnValue,
	StringMatcher expected)
	: AndOrResult<TType, TThat>(expectationBuilder, returnValue)
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Interprets the expected <see langword="string" /> as <see cref="Regex" /> pattern.
	/// </summary>
	public StringMatcherResult<TType, TThat> AsRegex()
	{
		expected.AsRegex();
		_expectationBuilder.AppendMethodStatement(nameof(AsRegex));
		return this;
	}

	/// <summary>
	///     Interprets the expected <see langword="string" /> as wildcard pattern.<br />
	///     Supports * to match zero or more characters and ? to match exactly one character.
	/// </summary>
	public StringMatcherResult<TType, TThat> AsWildcard()
	{
		expected.AsWildcard();
		_expectationBuilder.AppendMethodStatement(nameof(AsWildcard));
		return this;
	}

	/// <summary>
	///     Interprets the expected <see langword="string" /> to be exactly equal.
	/// </summary>
	public StringMatcherResult<TType, TThat> Exactly()
	{
		expected.Exactly();
		_expectationBuilder.AppendMethodStatement(nameof(Exactly));
		return this;
	}

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public StringMatcherResult<TType, TThat> IgnoringCase()
	{
		expected.IgnoringCase();
		_expectationBuilder.AppendMethodStatement(nameof(IgnoringCase));
		return this;
	}

	/// <summary>
	///     Uses the provided <paramref name="comparer" /> for comparing <see langword="string" />s.
	/// </summary>
	public StringMatcherResult<TType, TThat> Using(
		IEqualityComparer<string> comparer,
		[CallerArgumentExpression("comparer")] string doNotPopulateThisValue = "")
	{
		expected.UsingComparer(comparer);
		_expectationBuilder.AppendMethodStatement(nameof(Using), doNotPopulateThisValue);
		return this;
	}
}
