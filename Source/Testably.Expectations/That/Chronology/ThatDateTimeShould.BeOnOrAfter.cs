using System;
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
	///     Verifies that the subject is on or after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, That<DateTime>> BeOnOrAfter(
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
					$"be on or after {Formatter.Format(expected)}",
					tolerance),
				b => b.AppendMethod(nameof(BeOnOrAfter), doNotPopulateThisValue)),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not on or after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, That<DateTime>> NotBeOnOrAfter(
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
					$"not be on or after {Formatter.Format(expected)}",
					tolerance),
				b => b.AppendMethod(nameof(NotBeOnOrAfter), doNotPopulateThisValue)),
			source,
			tolerance);
	}
}
