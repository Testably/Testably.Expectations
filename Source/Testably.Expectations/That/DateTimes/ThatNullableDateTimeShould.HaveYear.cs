using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatNullableDateTimeShould
{
	/// <summary>
	///     Verifies that the year of the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<DateTime?, IThat<DateTime?>> HaveYear(this IThat<DateTime?> source,
		int? expected)
	{
		return new AndOrResult<DateTime?, IThat<DateTime?>>(source.ExpectationBuilder
				.AddConstraint(new PropertyConstraint<int?>(
					expected,
					(a, e) => a.HasValue && a.Value.Year == e,
					$"have year of {Formatter.Format(expected)}")),
			source);
	}

	/// <summary>
	///     Verifies that the year of the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrResult<DateTime?, IThat<DateTime?>> NotHaveYear(
		this IThat<DateTime?> source,
		int? unexpected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new PropertyConstraint<int?>(
					unexpected,
					(a, e) => !a.HasValue || a.Value.Year != e,
					$"not have year of {Formatter.Format(unexpected)}")),
			source);
}
