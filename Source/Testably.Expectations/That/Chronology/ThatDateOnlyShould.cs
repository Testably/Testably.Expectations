﻿#if !NETSTANDARD2_0
using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Formatting;

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="DateOnly" /> values.
/// </summary>
public static partial class ThatDateOnlyShould
{
	/// <summary>
	///     Start expectations for current <see cref="DateOnly" /> <paramref name="subject" />.
	/// </summary>
	public static IThat<DateOnly> Should(this IExpectSubject<DateOnly> subject)
		=> subject.Should(_ => { });

	/// <summary>
	///     Start expectations for the current <see cref="DateOnly" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<DateOnly?> Should(this IExpectSubject<DateOnly?> subject)
		=> subject.Should(_ => { });

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
