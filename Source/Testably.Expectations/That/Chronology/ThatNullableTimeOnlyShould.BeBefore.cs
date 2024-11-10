#if NET6_0_OR_GREATER
using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableTimeOnlyShould
{
	/// <summary>
	///     Verifies that the subject is before the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceResult<TimeOnly?, IThat<TimeOnly?>> BeBefore(
		this IThat<TimeOnly?> source,
		TimeOnly? expected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<TimeOnly?, IThat<TimeOnly?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraintWithTolerance(
					expected,
					(e, t) => $"be before {Formatter.Format(e)}{t}",
					(a, e, t) => a?.Add(t.Negate()) < e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not before the <paramref name="unexpected" /> value.
	/// </summary>
	public static TimeToleranceResult<TimeOnly?, IThat<TimeOnly?>> NotBeBefore(
		this IThat<TimeOnly?> source,
		TimeOnly? unexpected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<TimeOnly?, IThat<TimeOnly?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraintWithTolerance(
					unexpected,
					(u, t) => $"not be before {Formatter.Format(u)}{t}",
					(a, e, t) => a?.Add(t.Negate()) >= e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}
}
#endif
