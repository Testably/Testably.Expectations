﻿#if NET6_0_OR_GREATER
using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="DateOnly" /> values.
/// </summary>
public static partial class ThatNullableDateOnlyShould
{
	/// <summary>
	///     Start expectations for current <see cref="DateOnly" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<DateOnly?> Should(this IExpectSubject<DateOnly?> subject)
		=> subject.Should(ExpectationBuilder.NoAction);

	private readonly struct PropertyConstraint<T>(
		T expected,
		Func<DateOnly?, T, bool> condition,
		string expectation) : IValueConstraint<DateOnly?>
	{
		public ConstraintResult IsMetBy(DateOnly? actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<DateOnly?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}

	private readonly struct ConditionConstraint(
		DateOnly? expected,
		Func<DateOnly?, DateOnly?, bool> condition,
		string expectation) : IValueConstraint<DateOnly?>
	{
		public ConstraintResult IsMetBy(DateOnly? actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<DateOnly?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}

	private readonly struct ConditionConstraintWithTolerance(
		DateOnly? expected,
		Func<DateOnly?, TimeTolerance, string> expectation,
		Func<DateOnly?, DateOnly?, TimeSpan, bool> condition,
		Func<DateOnly?, DateOnly?, string> failureMessageFactory,
		TimeTolerance tolerance)
		: IValueConstraint<DateOnly?>
	{
		public ConstraintResult IsMetBy(DateOnly? actual)
		{
			if (expected is null)
			{
				return new ConstraintResult.Failure(ToString(),
					failureMessageFactory(actual, expected));
			}

			if (condition(actual, expected.Value, tolerance.Tolerance ?? TimeSpan.Zero))
			{
				return new ConstraintResult.Success<DateOnly?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				failureMessageFactory(actual, expected.Value));
		}

		public override string ToString()
			=> expectation(expected, tolerance);
	}
}
#endif
