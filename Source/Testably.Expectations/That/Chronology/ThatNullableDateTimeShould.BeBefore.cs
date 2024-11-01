using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatNullableDateTimeShould
{
	/// <summary>
	///     Verifies that the subject is before the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime?, IThat<DateTime?>> BeBefore(
		this IThat<DateTime?> source,
		DateTime? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime?, IThat<DateTime?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					$"be before {Formatter.Format(expected)}",
					(a, e, t) => a - t < e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance))
				.AppendMethodStatement(nameof(BeBefore), doNotPopulateThisValue),
			source,
			tolerance);
	}

	/// <summary>
	///     Verifies that the subject is not before the <paramref name="expected" /> value.
	/// </summary>
	public static TimeToleranceExpectationResult<DateTime?, IThat<DateTime?>> NotBeBefore(
		this IThat<DateTime?> source,
		DateTime? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		TimeTolerance tolerance = new();
		return new TimeToleranceExpectationResult<DateTime?, IThat<DateTime?>>(
			source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					$"not be before {Formatter.Format(expected)}",
					(a, e, t) => a + t >= e,
					(a, _) => $"found {Formatter.Format(a)}",
					tolerance))
				.AppendMethodStatement(nameof(NotBeBefore), doNotPopulateThisValue),
			source,
			tolerance);
	}
}
