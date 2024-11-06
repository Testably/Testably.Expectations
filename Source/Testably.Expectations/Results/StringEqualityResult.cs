using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TType" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TType,TThat}" />, allows specifying
///     options on the <see cref="StringEqualityOptions" />.
/// </summary>
public class StringEqualityResult<TType, TThat>(
	ExpectationBuilder expectationBuilder,
	TThat returnValue,
	StringEqualityOptions options)
	: StringEqualityResult<TType, TThat,
		StringEqualityResult<TType, TThat>>(
		expectationBuilder,
		returnValue,
		options);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TType" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TType,TThat}" />, allows specifying
///     options on the <see cref="StringMatcher" />.
/// </summary>
public class StringEqualityResult<TType, TThat, TSelf>(
	ExpectationBuilder expectationBuilder,
	TThat returnValue,
	StringEqualityOptions options)
	: AndOrResult<TType, TThat, TSelf>(expectationBuilder, returnValue)
	where TSelf : StringEqualityResult<TType, TThat, TSelf>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public StringEqualityResult<TType, TThat, TSelf> IgnoringCase()
	{
		options.IgnoringCase();
		_expectationBuilder.AppendMethodStatement(nameof(IgnoringCase));
		return this;
	}

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s, according to the <paramref name="ignoreCase" />
	///     parameter.
	/// </summary>
	public StringEqualityResult<TType, TThat, TSelf> IgnoringCase(
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
	public StringEqualityResult<TType, TThat, TSelf> Using(
		IEqualityComparer<string> comparer,
		[CallerArgumentExpression("comparer")] string doNotPopulateThisValue = "")
	{
		options.UsingComparer(comparer);
		_expectationBuilder.AppendMethodStatement(nameof(Using), doNotPopulateThisValue);
		return this;
	}
}
