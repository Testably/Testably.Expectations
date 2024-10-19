using System.Text.RegularExpressions;
using Testably.Expectations.Core.Helpers;

namespace Testably.Expectations.Core;

/// <summary>
///     The result of an assertion with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AssertionResult{TResult, TValue}" />, allows specifying options on
///     the <see cref="StringMatcher" />.
/// </summary>
public class MatcherAssertionResult<TResult, TValue>(
	IExpectationBuilder expectationBuilder,
	TValue assertion,
	StringMatcher expected) : AssertionResult<TResult, TValue>(expectationBuilder, assertion)
{
	private readonly IExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Interprets the expected <see langword="string" /> as <see cref="Regex"/> pattern.
	/// </summary>
	public MatcherAssertionResult<TResult, TValue> AsRegex()
	{
		expected.AsRegex();
		_expectationBuilder.AppendExpression(b => b.AppendMethod(nameof(AsRegex)));
		return this;
	}

	/// <summary>
	///     Interprets the expected <see langword="string" /> as wildcard pattern.<br />
	///     Supports * to match zero or more characters and ? to match exactly one character.
	/// </summary>
	public MatcherAssertionResult<TResult, TValue> AsWildcard()
	{
		expected.AsWildcard();
		_expectationBuilder.AppendExpression(b => b.AppendMethod(nameof(AsWildcard)));
		return this;
	}

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public MatcherAssertionResult<TResult, TValue> IgnoringCase()
	{
		expected.IgnoringCase();
		_expectationBuilder.AppendExpression(b => b.AppendMethod(nameof(IgnoringCase)));
		return this;
	}
}
