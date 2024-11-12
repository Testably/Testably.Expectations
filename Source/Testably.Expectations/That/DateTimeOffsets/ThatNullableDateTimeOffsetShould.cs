using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Options;

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="DateTimeOffset" />? values.
/// </summary>
public static partial class ThatNullableDateTimeOffsetShould
{
	/// <summary>
	///     Start expectations for the current <see cref="DateTimeOffset" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<DateTimeOffset?> Should(this IExpectSubject<DateTimeOffset?> subject)
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
		DateTimeOffset? expected,
		string expectation,
		Func<DateTimeOffset?, DateTimeOffset?, TimeSpan, bool> condition,
		Func<DateTimeOffset?, DateTimeOffset?, string> failureMessageFactory,
		TimeTolerance tolerance) : IValueConstraint<DateTimeOffset?>
	{
		public ConstraintResult IsMetBy(DateTimeOffset? actual)
		{
			if (condition(actual, expected, tolerance.Tolerance ?? TimeSpan.Zero))
			{
				return new ConstraintResult.Success<DateTimeOffset?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				failureMessageFactory(actual, expected));
		}

		public override string ToString()
			=> expectation + tolerance;
	}
}
