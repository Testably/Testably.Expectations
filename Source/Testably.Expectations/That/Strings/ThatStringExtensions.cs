﻿using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="string" /> values.
/// </summary>
public static partial class ThatStringExtensions
{
	/// <summary>
	///     Verifies that the subject is equal to <paramref name="expected" />.
	/// </summary>
	public static StringMatcherExpectationResult<string?, That<string?>> Is(
		this That<string?> source,
		StringMatcher expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsConstraint(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source,
			expected);

	/// <summary>
	///     Verifies that the subject contains the <paramref name="expected" /> <see langword="string" />.
	/// </summary>
	public static StringCountExpectationResult<string?, That<string?>> Contains(
		this That<string?> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		var quantifier = new Quantifier();
		var options = new StringOptions();
		return new StringCountExpectationResult<string?, That<string?>>(source.ExpectationBuilder.Add(
				new ContainsConstraint(expected, quantifier, options),
				b => b.AppendMethod(nameof(Contains), doNotPopulateThisValue)),
			source,
			quantifier,
			options);
	}

	/// <summary>
	///     Verifies that the subject contains the <paramref name="unexpected" /> <see langword="string" />.
	/// </summary>
	public static StringExpectationResult<string?, That<string?>> DoesNotContain(
		this That<string?> source,
		string unexpected,
		[CallerArgumentExpression("unexpected")] string doNotPopulateThisValue = "")
	{
		var quantifier = new Quantifier();
		quantifier.Exactly(0);
		var options = new StringOptions();
		return new StringExpectationResult<string?, That<string?>>(source.ExpectationBuilder.Add(
				new ContainsConstraint(unexpected, quantifier, options),
				b => b.AppendMethod(nameof(DoesNotContain), doNotPopulateThisValue)),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject starts with the <paramref name="expected" /> <see langword="string" />.
	/// </summary>
	public static StringExpectationResult<string?, That<string?>> StartsWith(
		this That<string?> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		var options = new StringOptions();
		return new StringExpectationResult<string?, That<string?>>(source.ExpectationBuilder.Add(
				new StartsWithConstraint(expected, options),
				b => b.AppendMethod(nameof(StartsWith), doNotPopulateThisValue)),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject does not start with the <paramref name="unexpected" /> <see langword="string" />.
	/// </summary>
	public static StringExpectationResult<string?, That<string?>> DoesNotStartWith(
		this That<string?> source,
		string unexpected,
		[CallerArgumentExpression("unexpected")] string doNotPopulateThisValue = "")
	{
		var options = new StringOptions();
		return new StringExpectationResult<string?, That<string?>>(source.ExpectationBuilder.Add(
				new DoesNotStartWithConstraint(unexpected, options),
				b => b.AppendMethod(nameof(DoesNotStartWith), doNotPopulateThisValue)),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject ends with the <paramref name="expected" /> <see langword="string" />.
	/// </summary>
	public static StringExpectationResult<string?, That<string?>> EndsWith(
		this That<string?> source,
		string expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		var options = new StringOptions();
		return new StringExpectationResult<string?, That<string?>>(source.ExpectationBuilder.Add(
				new EndsWithConstraint(expected, options),
				b => b.AppendMethod(nameof(EndsWith), doNotPopulateThisValue)),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject does not end with the <paramref name="unexpected" /> <see langword="string" />.
	/// </summary>
	public static StringExpectationResult<string?, That<string?>> DoesNotEndWith(
		this That<string?> source,
		string unexpected,
		[CallerArgumentExpression("unexpected")] string doNotPopulateThisValue = "")
	{
		var options = new StringOptions();
		return new StringExpectationResult<string?, That<string?>>(source.ExpectationBuilder.Add(
				new DoesNotEndWithConstraint(unexpected, options),
				b => b.AppendMethod(nameof(DoesNotEndWith), doNotPopulateThisValue)),
			source,
			options);
	}

	/// <summary>
	///     Verifies that the subject is <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<string?, That<string?>> IsNull(
		this That<string?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNullConstraint(),
				b => b.AppendMethod(nameof(IsNull))),
			source);

	/// <summary>
	///     Verifies that the subject is not <see langword="null" />.
	/// </summary>
	public static AndOrExpectationResult<string, That<string?>> IsNotNull(
		this That<string?> source)
		=> new(source.ExpectationBuilder.Add(
				new IsNotNullConstraint(),
				b => b.AppendMethod(nameof(IsNotNull))),
			source);
}
