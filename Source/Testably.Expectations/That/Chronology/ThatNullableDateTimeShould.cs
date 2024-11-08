using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Options;

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="DateTime" /> values.
/// </summary>
public static partial class ThatNullableDateTimeShould
{
	/// <summary>
	///     Start expectations for the current <see cref="DateTime" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<DateTime?> Should(this IExpectSubject<DateTime?> subject)
		=> subject.Should(_ => { });

	private static bool IsWithinTolerance(TimeSpan? tolerance, TimeSpan? difference)
	{
		if (difference == null)
		{
			return false;
		}

		if (tolerance == null)
		{
			return difference.Value == TimeSpan.Zero;
		}

		return difference.Value <= tolerance.Value &&
		       difference.Value >= tolerance.Value.Negate();
	}

	private readonly struct ConditionConstraint(
		DateTime? expected,
		string expectation,
		Func<DateTime?, DateTime?, TimeSpan, bool> condition,
		Func<DateTime?, DateTime?, string> failureMessageFactory,
		TimeTolerance tolerance) : IValueConstraint<DateTime?>
	{
		public ConstraintResult IsMetBy(DateTime? actual)
		{
			if (condition(actual, expected, tolerance.Tolerance ?? TimeSpan.Zero))
			{
				return new ConstraintResult.Success<DateTime?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				failureMessageFactory(actual, expected));
		}

		public override string ToString()
			=> expectation + tolerance;
	}
}
