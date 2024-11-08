using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="DateTimeOffset" /> values.
/// </summary>
public static partial class ThatDateTimeOffsetShould
{
	/// <summary>
	///     Start expectations for current <see cref="DateTimeOffset" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<DateTimeOffset> Should(this IExpectSubject<DateTimeOffset> subject)
		=> subject.Should(_ => { });

	/// <summary>
	///     Start expectations for the current <see cref="DateTimeOffset" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<DateTimeOffset?> Should(this IExpectSubject<DateTimeOffset?> subject)
		=> subject.Should(_ => { });

	private readonly struct ConditionConstraint(
		DateTimeOffset expected,
		Func<DateTimeOffset, DateTimeOffset, bool> condition,
		string expectation) : IValueConstraint<DateTimeOffset>
	{
		public ConstraintResult IsMetBy(DateTimeOffset actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<DateTimeOffset>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}
}
