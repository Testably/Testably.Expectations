using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatEnumShould
{
	/// <summary>
	///     Verifies that the subject has the <paramref name="expectedFlag" /> value.
	/// </summary>
	public static AndOrResult<TEnum, IThat<TEnum>> HaveFlag<TEnum>(
		this IThat<TEnum> source,
		TEnum? expectedFlag,
		[CallerArgumentExpression("expectedFlag")]
		string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint<TEnum>(
					$"have flag {Formatter.Format(expectedFlag)}",
					actual => expectedFlag != null && actual.HasFlag(expectedFlag)))
				.AppendMethodStatement(nameof(HaveFlag), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject does not have the <paramref name="unexpectedFlag" /> value.
	/// </summary>
	public static AndOrResult<TEnum, IThat<TEnum>> NotHaveFlag<TEnum>(
		this IThat<TEnum> source,
		TEnum? unexpectedFlag,
		[CallerArgumentExpression("unexpectedFlag")]
		string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint<TEnum>(
					$"not have flag {Formatter.Format(unexpectedFlag)}",
					actual => unexpectedFlag == null || !actual.HasFlag(unexpectedFlag)))
				.AppendMethodStatement(nameof(NotHaveFlag), doNotPopulateThisValue),
			source);
}
