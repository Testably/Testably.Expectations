﻿#if !NETSTANDARD2_0
using System;
using System.Net.Sockets;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableTimeOnlyShould
{
	/// <summary>
	///     Verifies that the subject is on or after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceResult<TimeOnly?, IThat<TimeOnly?>> BeOnOrAfter(
		this IThat<TimeOnly?> source,
		TimeOnly? expected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<TimeOnly?, IThat<TimeOnly?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraintWithTolerance(
					expected,
					(e, t) => $"be on or after {Formatter.Format(e)}{t}",
					(a, e, t) => a?.Add(t) >= e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not on or after the <paramref name="unexpected" /> value.
	/// </summary>
	public static TimeToleranceResult<TimeOnly?, IThat<TimeOnly?>> NotBeOnOrAfter(
		this IThat<TimeOnly?> source,
		TimeOnly? unexpected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<TimeOnly?, IThat<TimeOnly?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraintWithTolerance(
					unexpected,
					(u, t) => $"not be on or after {Formatter.Format(u)}{t}",
					(a, e, t) => a?.Add(t) < e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}
}
#endif
