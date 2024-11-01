using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
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
	public static TimeToleranceExpectationResult<DateTime, IThat<DateTime>> BeAfter(
		this IThat<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, IThat<DateTime>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint<DateTime>(
					expected,
					$"be after {Formatter.Format(expected)}",
					(a, e, t) => a + t > e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance))
				.AppendMethodStatement(nameof(BeAfter), doNotPopulateThisValue),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not after the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, IThat<DateTime>> NotBeAfter(
		this IThat<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, IThat<DateTime>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint<DateTime>(
					expected,
					$"not be after {Formatter.Format(expected)}",
					(a, e, t) => a - t <= e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance))
				.AppendMethodStatement(nameof(NotBeAfter), doNotPopulateThisValue),
			source,
			tolerance);
	}
}
