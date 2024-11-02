using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.Results;

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TResult,TValue}" />, allows specifying
///     options on the <see cref="ObjectEqualityOptions" />.
/// </summary>
public class ObjectEqualityResult<TResult, TValue>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	ObjectEqualityOptions options)
	: ObjectEqualityResult<TResult, TValue,
		ObjectEqualityResult<TResult, TValue>>(
		expectationBuilder,
		returnValue,
		options);

/// <summary>
///     The result of an expectation with an underlying value of type <typeparamref name="TResult" />.
///     <para />
///     In addition to the combinations from <see cref="AndOrResult{TResult,TValue}" />, allows specifying
///     options on the <see cref="ObjectEqualityOptions" />.
/// </summary>
public class ObjectEqualityResult<TResult, TValue, TSelf>(
	ExpectationBuilder expectationBuilder,
	TValue returnValue,
	ObjectEqualityOptions options)
	: AndOrResult<TResult, TValue, TSelf>(expectationBuilder, returnValue)
	where TSelf : ObjectEqualityResult<TResult, TValue, TSelf>
{
	private readonly ExpectationBuilder _expectationBuilder = expectationBuilder;

	/// <summary>
	///     Use equivalency to compare objects.
	/// </summary>
	public ObjectEqualityResult<TResult, TValue, TSelf> Equivalent(
		Func<EquivalencyOptions, EquivalencyOptions>? optionsCallback = null,
		[CallerArgumentExpression("optionsCallback")]
		string doNotPopulateThisValue = "")
	{
		EquivalencyOptions? equivalencyOptions =
			optionsCallback?.Invoke(new EquivalencyOptions()) ?? new EquivalencyOptions();
		options.Equivalent(equivalencyOptions);
		_expectationBuilder.AppendMethodStatement(nameof(Equivalent), doNotPopulateThisValue);
		return this;
	}

	/// <summary>
	///     Uses the provided <paramref name="comparer" /> for comparing <see langword="object" />s.
	/// </summary>
	public ObjectEqualityResult<TResult, TValue, TSelf> Using(
		IEqualityComparer<object> comparer,
		[CallerArgumentExpression("comparer")] string doNotPopulateThisValue = "")
	{
		options.Using(comparer);
		_expectationBuilder.AppendMethodStatement(nameof(Using), doNotPopulateThisValue);
		return this;
	}
}
