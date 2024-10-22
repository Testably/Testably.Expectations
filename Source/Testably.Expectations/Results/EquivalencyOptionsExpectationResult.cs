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
public class EquivalencyOptionsExpectationResult<TResult, TValue>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue,
	EquivalencyOptions options)
	: EquivalencyOptionsExpectationResult<TResult, TValue,
		EquivalencyOptionsExpectationResult<TResult, TValue>>(
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
public class EquivalencyOptionsExpectationResult<TResult, TValue, TSelf>(
	IExpectationBuilder expectationBuilder,
	TValue returnValue,
	EquivalencyOptions options)
	: AndOrExpectationResult<TResult, TValue, TSelf>(expectationBuilder, returnValue)
	where TSelf : EquivalencyOptionsExpectationResult<TResult, TValue, TSelf>
{
	private readonly IExpectationBuilder _expectationBuilder1 = expectationBuilder;

	/// <summary>
	///     Ignores the <paramref name="memberToIgnore" /> when checking for equivalency.
	/// </summary>
	public EquivalencyOptionsExpectationResult<TResult, TValue, TSelf> IgnoringMember(
		string memberToIgnore,
		[CallerArgumentExpression("memberToIgnore")] string doNotPopulateThisValue = "")
	{
		options.IgnoringMember(memberToIgnore);
		_expectationBuilder1.AppendExpression(b => b.AppendMethod(nameof(IgnoringMember), doNotPopulateThisValue));
		return this;
	}
}
