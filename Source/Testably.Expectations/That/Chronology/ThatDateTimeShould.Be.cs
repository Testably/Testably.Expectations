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
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime, IThat<DateTime>> Be(
		this IThat<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime, IThat<DateTime>>(
			source.ExpectationBuilder.Add(new ConditionConstraint(
					expected,
					(a, e, t) => IsWithinTolerance(t, a - e),
					$"be {Formatter.Format(expected)}{tolerance}",
					tolerance),
				b => b.AppendMethod(nameof(Be), doNotPopulateThisValue)),
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
			source.ExpectationBuilder.Add(new ConditionConstraint(
					unexpected,
					(a, e, t) => !IsWithinTolerance(t, a - e),
					$"not be {Formatter.Format(unexpected)}{tolerance}",
					tolerance),
				b => b.AppendMethod(nameof(NotBe), doNotPopulateThisValue)),
			source,
			tolerance);
	}
}
