using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumShould
{
	/// <summary>
	///     Verifies that the subject has the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum, IThat<TEnum>> HaveValue<TEnum>(
		this IThat<TEnum> source,
		long expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new ValueConstraint<TEnum>(
					$"have value {expected}",
					actual => Convert.ToInt64(actual, CultureInfo.InvariantCulture) == expected),
				b => b.AppendMethod(nameof(HaveValue), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject does not have the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum, IThat<TEnum>> NotHaveValue<TEnum>(
		this IThat<TEnum> source,
		long unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new ValueConstraint<TEnum>(
					$"not have value {unexpected}",
					actual => Convert.ToInt64(actual, CultureInfo.InvariantCulture) != unexpected),
				b => b.AppendMethod(nameof(NotHaveValue), doNotPopulateThisValue)),
			source);
}
