﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatDateTimeShould
{
	/// <summary>
	///     Verifies that the subject is before the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, That<DateTime>> BeBefore(
		this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, That<DateTime>>(
			source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e, t) => a - t < e,
					$"be before {Formatter.Format(expected)}",
					tolerance),
				b => b.AppendMethod(nameof(BeBefore), doNotPopulateThisValue)),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not before the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, That<DateTime>> NotBeBefore(
		this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, That<DateTime>>(
			source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e, t) => a + t >= e,
					$"not be before {Formatter.Format(expected)}",
					tolerance),
				b => b.AppendMethod(nameof(NotBeBefore), doNotPopulateThisValue)),
			source,
			tolerance);
	}
}