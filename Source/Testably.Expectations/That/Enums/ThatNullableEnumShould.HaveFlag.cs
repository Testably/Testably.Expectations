﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableEnumShould
{
	/// <summary>
	///     Verifies that the subject has the <paramref name="expectedFlag" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum?, That<TEnum?>> HaveFlag<TEnum>(
		this That<TEnum?> source,
		TEnum expectedFlag,
		[CallerArgumentExpression("expectedFlag")]
		string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					$"have flag {Formatter.Format(expectedFlag)}",
					actual => actual != null && actual.Value.HasFlag(expectedFlag)),
				b => b.AppendMethod(nameof(HaveFlag), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject does not have the <paramref name="unexpectedFlag" /> value.
	/// </summary>
	public static AndOrExpectationResult<TEnum?, That<TEnum?>> NotHaveFlag<TEnum>(
		this That<TEnum?> source,
		TEnum unexpectedFlag,
		[CallerArgumentExpression("unexpectedFlag")]
		string doNotPopulateThisValue = "")
		where TEnum : struct, Enum
		=> new(source.ExpectationBuilder.Add(new Constraint<TEnum>(
					$"not have flag {Formatter.Format(unexpectedFlag)}",
					actual => actual != null && !actual.Value.HasFlag(unexpectedFlag)),
				b => b.AppendMethod(nameof(NotHaveFlag), doNotPopulateThisValue)),
			source);
}
