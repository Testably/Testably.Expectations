﻿using System;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatDateTimeShould
{
	/// <summary>
	///     Verifies that the kind of the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<DateTime, IThat<DateTime>> HaveKind(this IThat<DateTime> source,
		DateTimeKind expected)
	{
		return new AndOrResult<DateTime, IThat<DateTime>>(source.ExpectationBuilder
				.AddConstraint(new PropertyConstraint<DateTimeKind>(
					expected,
					(a, e) => a.Kind == e,
					$"have kind of {Formatter.Format(expected)}")),
			source);
	}

	/// <summary>
	///     Verifies that the kind of the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrResult<DateTime, IThat<DateTime>> NotHaveKind(
		this IThat<DateTime> source,
		DateTimeKind unexpected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new PropertyConstraint<DateTimeKind>(
					unexpected,
					(a, e) => a.Kind != e,
					$"not have kind of {Formatter.Format(unexpected)}")),
			source);
}
