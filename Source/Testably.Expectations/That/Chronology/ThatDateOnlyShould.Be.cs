﻿#if !NETSTANDARD2_0
using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDateOnlyShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateOnly, That<DateOnly>> Be(this That<DateOnly> source,
		DateOnly expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		return new AndOrExpectationResult<DateOnly, That<DateOnly>>(source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e) => a.Equals(e),
					$"be {Formatter.Format(expected)}"),
				b => b.AppendMethod(nameof(Be), doNotPopulateThisValue)),
			source);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateOnly, That<DateOnly>> NotBe(this That<DateOnly> source,
		DateOnly unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new ConditionConstraint(
					unexpected,
					(a, e) => !a.Equals(e),
					$"not be {Formatter.Format(unexpected)}"),
				b => b.AppendMethod(nameof(NotBe), doNotPopulateThisValue)),
			source);
}
#endif