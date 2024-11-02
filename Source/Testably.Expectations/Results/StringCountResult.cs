using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="CountResult{TResult,TValue}" />, allows specifying
///     options on the <see cref="StringEqualityOptions" />.
/// </summary>
public class StringCountResult<TResult, TValue>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	Quantifier quantifier,
	StringEqualityOptions options)
	: StringCountResult<TResult, TValue,
		StringCountResult<TResult, TValue>>(
		expectationBuilder,
		returnValue,
		quantifier,
		options);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="CountResult{TResult,TValue}" />, allows specifying
///     options on the <see cref="StringEqualityOptions" />.
/// </summary>
public class StringCountResult<TResult, TValue, TSelf>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	Quantifier quantifier,
	StringEqualityOptions options)
	: CountResult<TResult, TValue, TSelf>(expectationBuilder, returnValue, quantifier)
	where TSelf : StringCountResult<TResult, TValue, TSelf>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public StringCountResult<TResult, TValue, TSelf> IgnoringCase()
	{
		options.IgnoringCase();
		_expectationBuilder.AppendMethodStatement(nameof(IgnoringCase));
		return this;
	}

	/// <summary>
	///     Uses the provided <paramref name="comparer" /> for comparing <see langword="string" />s.
	/// </summary>
	public StringCountResult<TResult, TValue, TSelf> Using(
		IEqualityComparer<string> comparer,
		[CallerArgumentExpression("comparer")] string doNotPopulateThisValue = "")
	{
		options.UsingComparer(comparer);
		_expectationBuilder.AppendMethodStatement(nameof(Using), doNotPopulateThisValue);
		return this;
	}
}
