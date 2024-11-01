using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
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
	public static IThat<DateTime> Should(this IExpectSubject<DateTime> subject)
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="DateTime" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<DateTime?> Should(this IExpectSubject<DateTime?> subject)
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

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

	private readonly struct ConditionConstraint<T>(
		T expected,
		string expectation,
		Func<T, T, TimeSpan, bool> condition,
		Func<T, T, string> failureMessageFactory,
		TimeTolerance tolerance) : IValueConstraint<T>
	{
		private readonly string _expectation = expectation;

		public ConstraintResult IsMetBy(T actual)
		{
			if (condition(actual, expected, tolerance.Tolerance ?? TimeSpan.Zero))
			{
				return new ConstraintResult.Success<T>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), failureMessageFactory(actual, expected));
		}

		public override string ToString()
			=> _expectation + tolerance;
	}
}
