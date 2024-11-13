using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableTimeSpanShould
{
	/// <summary>
	///     Verifies that the subject is positive.
	/// </summary>
	public static AndOrResult<TimeSpan?, IThat<TimeSpan?>> BePositive(this IThat<TimeSpan?> source)
		=> new(
			source.ExpectationBuilder
				.AddConstraint(new SimpleConstraint(
					"be positive",
					a => a > TimeSpan.Zero,
					a => $"found {Formatter.Format(a)}")),
			source);

	/// <summary>
	///     Verifies that the subject is not positive.
	/// </summary>
	public static AndOrResult<TimeSpan?, IThat<TimeSpan?>> NotBePositive(
		this IThat<TimeSpan?> source)
		=> new(
			source.ExpectationBuilder
				.AddConstraint(new SimpleConstraint(
					"not be positive",
					a => a <= TimeSpan.Zero,
					a => $"found {Formatter.Format(a)}")),
			source);
}
