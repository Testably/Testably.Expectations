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
	///     Verifies that the subject is after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, That<DateTime>> BeAfter(
		this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, That<DateTime>>(
			source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e, t) =>
					{
						return a + t > e;
					},
					$"be after {Formatter.Format(expected)}",
					tolerance),
				b => b.AppendMethod(nameof(BeAfter), doNotPopulateThisValue)),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, That<DateTime>> NotBeAfter(
		this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, That<DateTime>>(
			source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e, t) => a - t <= e,
					$"not be after {Formatter.Format(expected)}",
					tolerance),
				b => b.AppendMethod(nameof(NotBeAfter), doNotPopulateThisValue)),
			source,
			tolerance);
	}
}
