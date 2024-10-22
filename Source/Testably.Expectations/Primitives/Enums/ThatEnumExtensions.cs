﻿using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see langword="enum" /> values.
/// </summary>
public static partial class ThatEnumExtensions
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum, That<TEnum>> Is<TEnum>(this That<TEnum> source,
		TEnum expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					$"is {Formatter.Format(expected)}",
					actual => expected.Equals(actual)),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum, That<TEnum>> IsNot<TEnum>(this That<TEnum> source,
		TEnum unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					$"is not {Formatter.Format(unexpected)}",
					actual => !unexpected.Equals(actual)),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is defined inside the <typeparamref name="TEnum"/>.
	/// </summary>
	public static AndOrExpectationResult<TEnum, That<TEnum>> IsDefined<TEnum>(this That<TEnum> source)
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					"is defined",
					actual => Enum.IsDefined(typeof(TEnum), actual)),
				b => b.AppendMethod(nameof(IsDefined))),
			source);

	/// <summary>
	///     Verifies that the subject is not defined inside the <typeparamref name="TEnum"/>.
	/// </summary>
	public static AndOrExpectationResult<TEnum, That<TEnum>> IsNotDefined<TEnum>(this That<TEnum> source)
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					"is not defined",
					actual => !Enum.IsDefined(typeof(TEnum), actual)),
				b => b.AppendMethod(nameof(IsNotDefined))),
			source);

	/// <summary>
	///     Verifies that the subject has the <paramref name="expectedFlag" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum, That<TEnum>> HasFlag<TEnum>(this That<TEnum> source,
		TEnum expectedFlag,
		[CallerArgumentExpression("expectedFlag")] string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					$"has flag {Formatter.Format(expectedFlag)}",
					actual => actual.HasFlag(expectedFlag)),
				b => b.AppendMethod(nameof(HasFlag), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject has the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum, That<TEnum>> HasValue<TEnum>(this That<TEnum> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					$"has value {expected}",
					actual => Convert.ToInt64(actual, CultureInfo.InvariantCulture) == expected),
				b => b.AppendMethod(nameof(HasValue), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject does not have the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum, That<TEnum>> DoesNotHaveValue<TEnum>(this That<TEnum> source,
		long unexpected,
		[CallerArgumentExpression("unexpected")] string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					$"does not have value {unexpected}",
					actual => Convert.ToInt64(actual, CultureInfo.InvariantCulture) != unexpected),
				b => b.AppendMethod(nameof(DoesNotHaveValue), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject does not have the <paramref name="unexpectedFlag" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum, That<TEnum>> DoesNotHaveFlag<TEnum>(this That<TEnum> source,
		TEnum unexpectedFlag,
		[CallerArgumentExpression("unexpectedFlag")]
		string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					$"does not have flag {Formatter.Format(unexpectedFlag)}",
					actual => !actual.HasFlag(unexpectedFlag)),
				b => b.AppendMethod(nameof(DoesNotHaveFlag), doNotPopulateThisValue)),
			source);
}
