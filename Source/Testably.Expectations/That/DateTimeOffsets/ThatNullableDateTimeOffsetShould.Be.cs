using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableDateTimeOffsetShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<DateTimeOffset?, IThat<DateTimeOffset?>> Be(
		this IThat<DateTimeOffset?> source,
		DateTimeOffset? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					(a, e) => a.Equals(e),
					$"be {Formatter.Format(expected)}")),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrResult<DateTimeOffset?, IThat<DateTimeOffset?>> NotBe(
		this IThat<DateTimeOffset?> source,
		DateTimeOffset? unexpected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					unexpected,
					(a, e) => !a.Equals(e),
					$"not be {Formatter.Format(unexpected)}")),
			source);
}
