using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableDateTimeShould
{
	/// <summary>
	///     Verifies that the subject is after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceResult<DateTime?, IThat<DateTime?>> BeAfter(
		this IThat<DateTime?> source,
		DateTime? expected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<DateTime?, IThat<DateTime?>>(
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
	///     Verifies that the subject is not after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceResult<DateTime?, IThat<DateTime?>> NotBeAfter(
		this IThat<DateTime?> source,
		DateTime? expected)
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceResult<DateTime?, IThat<DateTime?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					$"not be after {Formatter.Format(expected)}",
					(a, e, t) => a - t <= e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance)),
			source,
			tolerance);
	}
}
