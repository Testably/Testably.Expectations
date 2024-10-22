using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see langword="enum" />? values.
/// </summary>
public static partial class ThatNullableEnumExtensions
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum?, That<TEnum?>> Is<TEnum>(this That<TEnum?> source,
		TEnum? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(
				new Constraint<TEnum>(
					$"is {Formatter.Format(expected)}",
					actual => expected.Equals(actual)),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum?, That<TEnum?>> IsNot<TEnum>(this That<TEnum?> source,
		TEnum? unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(
				new Constraint<TEnum>(
					$"is not {Formatter.Format(unexpected)}",
					actual => !unexpected.Equals(actual)),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);
}
