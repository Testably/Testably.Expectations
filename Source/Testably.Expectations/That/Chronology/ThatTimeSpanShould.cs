using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="TimeSpan" /> values.
/// </summary>
public static partial class ThatTimeSpanShould
{
	/// <summary>
	///     Start expectations for current <see cref="TimeSpan" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<TimeSpan> Should(this IExpectSubject<TimeSpan> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="TimeSpan" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<TimeSpan?> Should(this IExpectSubject<TimeSpan?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

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
