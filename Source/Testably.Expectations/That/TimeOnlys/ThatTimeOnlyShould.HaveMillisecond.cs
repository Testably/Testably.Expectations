﻿#if NET6_0_OR_GREATER
using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatTimeOnlyShould
{
	/// <summary>
	///     Verifies that the millisecond of the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<TimeOnly, IThat<TimeOnly>> HaveMillisecond(this IThat<TimeOnly> source,
		int? expected)
	{
		return new AndOrResult<TimeOnly, IThat<TimeOnly>>(source.ExpectationBuilder
				.AddConstraint(new PropertyConstraint<int?>(
					expected,
					(a, e) => a.Millisecond == e,
					$"have millisecond of {Formatter.Format(expected)}")),
			source);
	}

	/// <summary>
	///     Verifies that the millisecond of the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrResult<TimeOnly, IThat<TimeOnly>> NotHaveMillisecond(
		this IThat<TimeOnly> source,
		int? unexpected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new PropertyConstraint<int?>(
					unexpected,
					(a, e) => a.Millisecond != e,
					$"not have millisecond of {Formatter.Format(unexpected)}")),
			source);
}
#endif
