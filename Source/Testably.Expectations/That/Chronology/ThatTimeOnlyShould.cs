#if !NETSTANDARD2_0
using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="TimeOnly" /> values.
/// </summary>
public static partial class ThatTimeOnlyShould
{
	/// <summary>
	///     Start expectations for current <see cref="TimeOnly" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<TimeOnly> Should(this IExpectSubject<TimeOnly> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="TimeOnly" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<TimeOnly?> Should(this IExpectSubject<TimeOnly?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));

	private readonly struct ConditionConstraint(
		TimeOnly expected,
		Func<TimeOnly, TimeOnly, bool> condition,
		string expectation) : IValueConstraint<TimeOnly>
	{
		public ConstraintResult IsMetBy(TimeOnly actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<TimeOnly>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}
}
#endif
