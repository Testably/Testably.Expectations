#if !NETSTANDARD2_0
using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="TimeOnly" /> values.
/// </summary>
public static partial class ThatNullableTimeOnlyShould
{
	/// <summary>
	///     Start expectations for current <see cref="TimeOnly" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<TimeOnly?> Should(this IExpectSubject<TimeOnly?> subject)
		=> subject.Should(_ => { });

	private readonly struct ConditionConstraint(
		TimeOnly? expected,
		Func<TimeOnly?, TimeOnly?, bool> condition,
		string expectation) : IValueConstraint<TimeOnly?>
	{
		public ConstraintResult IsMetBy(TimeOnly? actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<TimeOnly?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}

	private readonly struct ConditionConstraintWithTolerance(
		TimeOnly? expected,
		Func<TimeOnly?, TimeTolerance, string> expectation,
		Func<TimeOnly?, TimeOnly?, TimeSpan, bool> condition,
		Func<TimeOnly?, TimeOnly?, string> failureMessageFactory,
		TimeTolerance tolerance)
		: IValueConstraint<TimeOnly?>
	{
		public ConstraintResult IsMetBy(TimeOnly? actual)
		{
			if (expected is null)
			{
				return new ConstraintResult.Failure(ToString(),
					failureMessageFactory(actual, expected));
			}

			if (condition(actual, expected.Value, tolerance.Tolerance ?? TimeSpan.Zero))
			{
				return new ConstraintResult.Success<TimeOnly?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				failureMessageFactory(actual, expected.Value));
		}

		public override string ToString()
			=> expectation(expected, tolerance);
	}
}
#endif
