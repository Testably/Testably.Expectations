#if NET6_0_OR_GREATER
using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatDateOnlyShould
{
	/// <summary>
	///     Verifies that the month of the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<DateOnly, IThat<DateOnly>> HaveMonth(this IThat<DateOnly> source,
		int? expected)
	{
		return new AndOrResult<DateOnly, IThat<DateOnly>>(source.ExpectationBuilder
				.AddConstraint(new PropertyConstraint<int?>(
					expected,
					(a, e) => a.Month == e,
					$"have month of {Formatter.Format(expected)}")),
			source);
	}

	/// <summary>
	///     Verifies that the month of the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrResult<DateOnly, IThat<DateOnly>> NotHaveMonth(
		this IThat<DateOnly> source,
		int? unexpected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new PropertyConstraint<int?>(
					unexpected,
					(a, e) => a.Month != e,
					$"not have month of {Formatter.Format(unexpected)}")),
			source);
}
#endif
