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
	public static TimeToleranceExpectationResult<DateTime, IThat<DateTime>> BeOnOrAfter(
		this IThat<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, IThat<DateTime>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					(a, e, t) => a + t >= e,
					$"be on or after {Formatter.Format(expected)}",
					tolerance))
				.AppendMethodStatement(nameof(BeOnOrAfter), doNotPopulateThisValue),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not on or after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, IThat<DateTime>> NotBeOnOrAfter(
		this IThat<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, IThat<DateTime>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					(a, e, t) => a - t < e,
					$"not be on or after {Formatter.Format(expected)}",
					tolerance))
				.AppendMethodStatement(nameof(NotBeOnOrAfter), doNotPopulateThisValue),
			source,
			tolerance);
	}
}
