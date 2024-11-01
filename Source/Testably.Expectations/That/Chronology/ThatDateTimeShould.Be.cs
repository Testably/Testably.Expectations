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
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, IThat<DateTime>> Be(
		this IThat<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, IThat<DateTime>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint<DateTime>(
					expected,
					$"be {Formatter.Format(expected)}{tolerance}",
					(a, e, t) => a.Kind == e.Kind && IsWithinTolerance(t, a - e),
					(a, e) => a.Kind == e.Kind
						? $"found {Formatter.Format(a)}"
						: "it differed in the Kind property",
					tolerance))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime?, IThat<DateTime?>> Be(
		this IThat<DateTime?> source,
		DateTime? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime?, IThat<DateTime?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint<DateTime?>(
					expected,
					$"be {Formatter.Format(expected)}{tolerance}",
					(a, e, t) => a?.Kind == e?.Kind && IsWithinTolerance(t, a - e),
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, IThat<DateTime>> NotBe(
		this IThat<DateTime> source,
		DateTime unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, IThat<DateTime>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint<DateTime>(
					unexpected,
					$"not be {Formatter.Format(unexpected)}{tolerance}",
					(a, e, t) => a.Kind != e.Kind || !IsWithinTolerance(t, a - e),
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance))
				.AppendMethodStatement(nameof(NotBe), doNotPopulateThisValue),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime?, IThat<DateTime?>> NotBe(
		this IThat<DateTime?> source,
		DateTime? unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime?, IThat<DateTime?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint<DateTime?>(
					unexpected,
					$"not be {Formatter.Format(unexpected)}{tolerance}",
					(a, e, t) => a?.Kind != e?.Kind || !IsWithinTolerance(t, a - e),
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance))
				.AppendMethodStatement(nameof(NotBe), doNotPopulateThisValue),
			source,
			tolerance);
	}
}
