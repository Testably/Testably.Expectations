#if !NETSTANDARD2_0
using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="DateOnly" /> values.
/// </summary>
public static partial class ThatDateOnlyShould
{
	/// <summary>
	///     Start expectations for current <see cref="DateOnly" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<DateOnly> Should(this IExpectSubject<DateOnly> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<DateOnly>(subject.ExpectationBuilder.AppendMethodStatement(nameof(Should)));

	/// <summary>
	///     Start expectations for the current <see cref="DateOnly" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<DateOnly?> Should(this IExpectSubject<DateOnly?> subject,
		[CallerArgumentExpression("subject")] string doNotPopulateThisValue = "")
		=> new That<DateOnly?>(subject.ExpectationBuilder.AppendMethodStatement(nameof(Should)));

	private readonly struct ConditionConstraint(
		DateOnly expected,
		Func<DateOnly, DateOnly, bool> condition,
		string expectation) : IValueConstraint<DateOnly>
	{
		public ConstraintResult IsMetBy(DateOnly actual)
		{
			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<DateOnly>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(), $"found {Formatter.Format(actual)}");
		}

		public override string ToString()
			=> expectation;
	}
}
#endif
