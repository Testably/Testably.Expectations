using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="CountExpectationResult{TResult,TValue}" />, allows specifying
///     options on the <see cref="StringOptions" />.
/// </summary>
public class StringCountExpectationResult<TResult, TValue>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue,
	Quantifier quantifier,
	StringOptions options)
	: StringCountExpectationResult<TResult, TValue,
		StringCountExpectationResult<TResult, TValue>>(
		expectationBuilder,
		returnValue,
		quantifier,
		options);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="CountExpectationResult{TResult,TValue}" />, allows specifying
///     options on the <see cref="StringOptions" />.
/// </summary>
public class StringCountExpectationResult<TResult, TValue, TSelf>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue,
	Quantifier quantifier,
	StringOptions options)
	: CountExpectationResult<TResult, TValue, TSelf>(expectationBuilder, returnValue, quantifier)
	where TSelf : StringCountExpectationResult<TResult, TValue, TSelf>
{
	private readonly IExpectationBuilder _expectationBuilder1 = expectationBuilder;

	/// <summary>
	///     Ignores casing when comparing the <see langword="string" />s.
	/// </summary>
	public StringCountExpectationResult<TResult, TValue, TSelf> IgnoringCase()
	{
		options.IgnoringCase();
		_expectationBuilder1.AppendExpression(b => b.AppendMethod(nameof(IgnoringCase)));
		return this;
	}

	/// <summary>
	///     Uses the provided <paramref name="comparer" /> for comparing <see langword="string" />s.
	/// </summary>
	public StringCountExpectationResult<TResult, TValue, TSelf> Using(
		IEqualityComparer<string> comparer,
		[CallerArgumentExpression("comparer")] string doNotPopulateThisValue = "")
	{
		options.UsingComparer(comparer);
		_expectationBuilder1.AppendExpression(b
			=> b.AppendMethod(nameof(Using), doNotPopulateThisValue));
		return this;
	}
}
