﻿using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableDateTimeOffsetShould
{
	/// <summary>
	///     Verifies that the subject is after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceResult<DateTimeOffset?, IThat<DateTimeOffset?>> BeAfter(
		this IThat<DateTimeOffset?> source,
		DateTimeOffset? expected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<DateTimeOffset?, IThat<DateTimeOffset?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					$"be after {Formatter.Format(expected)}",
					(a, e, t) => a + t > e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not after the <paramref name="unexpected" /> value.
	/// </summary>
	public static TimeToleranceResult<DateTimeOffset?, IThat<DateTimeOffset?>> NotBeAfter(
		this IThat<DateTimeOffset?> source,
		DateTimeOffset? unexpected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<DateTimeOffset?, IThat<DateTimeOffset?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					unexpected,
					$"not be after {Formatter.Format(unexpected)}",
					(a, e, t) => a - t <= e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}
}
