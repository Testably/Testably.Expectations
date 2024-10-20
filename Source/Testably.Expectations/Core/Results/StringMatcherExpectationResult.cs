using System.Text.RegularExpressions;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrExpectationResult{TResult,TValue}" />, allows specifying options
///     on
///     the <see cref="StringMatcher" />.
/// </summary>
public class StringMatcherExpectationResult<TResult, TValue>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue,
	StringMatcher expected) : AndOrExpectationResult<TResult, TValue>(expectationBuilder, returnValue)
{
	private readonly IExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Interprets the expected <see langword="string" /> as <see cref="Regex" /> pattern.
	/// </summary>
	public StringMatcherExpectationResult<TResult, TValue> AsRegex()
	{
		expected.AsRegex();
		_expectationBuilder.AppendExpression(b => b.AppendMethod(nameof(AsRegex)));
		return this;
	}

	/// <summary>
	///     Interprets the expected <see langword="string" /> as wildcard pattern.<br />
	///     Supports * to match zero or more characters and ? to match exactly one character.
	/// </summary>
	public StringMatcherExpectationResult<TResult, TValue> AsWildcard()
	{
		expected.AsWildcard();
		_expectationBuilder.AppendExpression(b => b.AppendMethod(nameof(AsWildcard)));
		return this;
	}

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public StringMatcherExpectationResult<TResult, TValue> IgnoringCase()
	{
		expected.IgnoringCase();
		_expectationBuilder.AppendExpression(b => b.AppendMethod(nameof(IgnoringCase)));
		return this;
	}
}
