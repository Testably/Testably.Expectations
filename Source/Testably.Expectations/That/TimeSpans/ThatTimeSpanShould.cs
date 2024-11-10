using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="TimeSpan" /> values.
/// </summary>
public static partial class ThatTimeSpanShould
{
	/// <summary>
	///     Start expectations for current <see cref="TimeSpan" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<TimeSpan> Should(this IExpectSubject<TimeSpan> subject)
		=> subject.Should(_ => { });

	/// <summary>
	///     Start expectations for the current <see cref="TimeSpan" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<TimeSpan?> Should(this IExpectSubject<TimeSpan?> subject)
		=> subject.Should(_ => { });

	private readonly struct ConditionConstraint(
		TimeSpan expected,
		Func<TimeSpan, TimeSpan, bool> condition,
		string expectation) : IValueConstraint<TimeSpan>
	{
		public ConstraintResult IsMetBy(TimeSpan actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<TimeSpan>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}
}
