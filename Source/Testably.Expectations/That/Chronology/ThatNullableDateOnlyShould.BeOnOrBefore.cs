#if !NETSTANDARD2_0
using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableDateOnlyShould
{
	/// <summary>
	///     Verifies that the subject is on or before the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceResult<DateOnly?, IThat<DateOnly?>> BeOnOrBefore(
		this IThat<DateOnly?> source,
		DateOnly? expected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<DateOnly?, IThat<DateOnly?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraintWithTolerance(
					expected,
					(e, t) => $"be on or before {Formatter.Format(e)}{t.ToDayString()}",
					(a, e, t) => a?.AddDays(-1 * (int)t.TotalDays) <= e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not on or before the <paramref name="unexpected" /> value.
	/// </summary>
	public static TimeToleranceResult<DateOnly?, IThat<DateOnly?>> NotBeOnOrBefore(
		this IThat<DateOnly?> source,
		DateOnly? unexpected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<DateOnly?, IThat<DateOnly?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraintWithTolerance(
					unexpected,
					(u, t) => $"not be on or before {Formatter.Format(u)}{t.ToDayString()}",
					(a, e, t) => a?.AddDays(-1 * (int)t.TotalDays) > e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}
}
#endif
