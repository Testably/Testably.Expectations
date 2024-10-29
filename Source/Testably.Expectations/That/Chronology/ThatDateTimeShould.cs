using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="DateTime" /> values.
/// </summary>
public static partial class ThatDateTimeShould
{
	/// <summary>
	///     Start expectations for current <see cref="DateTime" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<DateTime> Should(this IExpectThat<DateTime> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<DateTime>(subject.ExpectationBuilder.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="DateTime" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<DateTime?> Should(this IExpectThat<DateTime?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<DateTime?>(subject.ExpectationBuilder.AppendMethodStatement(nameof(Should)));

	private static bool IsWithinTolerance(TimeSpan? tolerance, TimeSpan difference)
	{
		if (tolerance == null)
		{
			return difference == TimeSpan.Zero;
		}

		return difference <= tolerance.Value && difference >= tolerance.Value.Negate();
	}

	private readonly struct ConditionConstraint(
		DateTime expected,
		Func<DateTime, DateTime, TimeSpan, bool> condition,
		string expectation,
		TimeTolerance tolerance) : IValueConstraint<DateTime>
	{
		private readonly string _expectation = expectation;

		public ConstraintResult IsMetBy(DateTime actual)
		{
			if (condition(actual, expected, tolerance.Tolerance ?? TimeSpan.Zero))
			{
				return new ConstraintResult.Success<DateTime>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> _expectation + tolerance;
	}
}
