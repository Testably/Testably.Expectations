﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatDateTimeShould
{
	/// <summary>
	///     Verifies that the subject is on or before the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceResult<DateTime, IThat<DateTime>> BeOnOrBefore(
		this IThat<DateTime> source,
		DateTime? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<DateTime, IThat<DateTime>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					$"be on or before {Formatter.Format(expected)}",
					(a, e, t) => a - t <= e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance))
				.AppendMethodStatement(nameof(BeOnOrBefore), doNotPopulateThisValue),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not on or before the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceResult<DateTime, IThat<DateTime>> NotBeOnOrBefore(
		this IThat<DateTime> source,
		DateTime? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<DateTime, IThat<DateTime>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					$"not be on or before {Formatter.Format(expected)}",
					(a, e, t) => a + t > e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance))
				.AppendMethodStatement(nameof(NotBeOnOrBefore), doNotPopulateThisValue),
			source,
			tolerance);
	}
}
