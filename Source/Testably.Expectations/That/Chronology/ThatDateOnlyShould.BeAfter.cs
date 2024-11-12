﻿#if !NETSTANDARD2_0
using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatDateOnlyShould
{
	/// <summary>
	///     Verifies that the subject is after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceResult<DateOnly, IThat<DateOnly>> BeAfter(
		this IThat<DateOnly> source,
		DateOnly? expected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<DateOnly, IThat<DateOnly>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraintWithTolerance(
					expected,
					(e, t) => $"be after {Formatter.Format(e)}{t.ToDayString()}",
					(a, e, t) => a.AddDays((int)t.TotalDays) > e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not after the <paramref name="unexpected" /> value.
	/// </summary>
	public static TimeToleranceResult<DateOnly, IThat<DateOnly>> NotBeAfter(
		this IThat<DateOnly> source,
		DateOnly? unexpected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<DateOnly, IThat<DateOnly>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraintWithTolerance(
					unexpected,
					(u, t) => $"not be after {Formatter.Format(u)}{t.ToDayString()}",
					(a, e, t) => a.AddDays((int)t.TotalDays) <= e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}
}
#endif