using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableTimeSpanShould
{
	/// <summary>
	///     Verifies that the subject is negative.
	/// </summary>
	public static AndOrResult<TimeSpan?, IThat<TimeSpan?>> BeNegative(this IThat<TimeSpan?> source)
		=> new(
			source.ExpectationBuilder
				.AddConstraint(new SimpleConstraint(
					"be negative",
					a => a < TimeSpan.Zero,
					a => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is not negative.
	/// </summary>
	public static AndOrResult<TimeSpan?, IThat<TimeSpan?>> NotBeNegative(
		this IThat<TimeSpan?> source)
		=> new(
			source.ExpectationBuilder
				.AddConstraint(new SimpleConstraint(
					"not be negative",
					a => a >= TimeSpan.Zero,
					a => $"found {Formatter.Format(a)}")),
			source);
}
