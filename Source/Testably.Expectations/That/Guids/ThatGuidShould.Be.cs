﻿using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatGuidShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<Guid, IThat<Guid>> Be(this IThat<Guid> source,
		Guid? expected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					$"be {Formatter.Format(expected)}",
					actual => actual.Equals(expected))),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrResult<Guid, IThat<Guid>> NotBe(this IThat<Guid> source,
		Guid? unexpected)
		=> new(source.ExpectationBuilder
				.AddConstraint(new ValueConstraint(
					$"not be {Formatter.Format(unexpected)}",
					actual => !actual.Equals(unexpected))),
			source);
}
