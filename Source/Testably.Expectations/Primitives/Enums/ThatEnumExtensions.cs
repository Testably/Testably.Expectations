using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
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
		=> new(source.ExpectationBuilder.Add(new IsConstraint<TEnum>(expected),
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
		=> new(source.ExpectationBuilder.Add(new IsNotConstraint<TEnum>(unexpected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject has the <paramref name="expectedFlag" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum, That<TEnum>> HasFlag<TEnum>(this That<TEnum> source,
		TEnum expectedFlag,
		[CallerArgumentExpression("expectedFlag")] string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new HasFlagConstraint<TEnum>(expectedFlag),
				b => b.AppendMethod(nameof(HasFlag), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject does not have the <paramref name="unexpectedFlag" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum, That<TEnum>> DoesNotHaveFlag<TEnum>(this That<TEnum> source,
		TEnum unexpectedFlag,
		[CallerArgumentExpression("unexpectedFlag")]
		string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new DoesNotHaveFlagConstraint<TEnum>(unexpectedFlag),
				b => b.AppendMethod(nameof(DoesNotHaveFlag), doNotPopulateThisValue)),
			source);
}
