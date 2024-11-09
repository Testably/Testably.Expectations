using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that the subject has the <paramref name="expected" /> length.
	/// </summary>
	public static AndOrResult<string?, IThat<string?>> HaveLength(
		this IThat<string?> source,
		int expected)
	{
		if (expected < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(expected), expected,
				"The expected length must be greater than or equal to zero.");
		}

		return new AndOrResult<string?, IThat<string?>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<int>(
					expected,
					e => $"have length {e}",
					(a, e) => a?.Length == e,
					(a, _) => a == null
						? "found <null>"
						: $"it did have a length of {a.Length}:{Environment.NewLine}{Formatter.Format(a).Indent()}")),
			source);
	}

	/// <summary>
	///     Verifies that the subject does not have the <paramref name="unexpected" /> length.
	/// </summary>
	public static AndOrResult<string, IThat<string?>> NotHaveLength(
		this IThat<string?> source,
		int unexpected)
	{
		if (unexpected < 0)
		{
			throw new ArgumentOutOfRangeException(nameof(unexpected), unexpected,
				"The unexpected length must be greater than or equal to zero.");
		}

		return new AndOrResult<string, IThat<string?>>(source.ExpectationBuilder
				.AddConstraint(new GenericConstraint<int>(
					unexpected,
					e => $"not have length {e}",
					(a, e) => a?.Length != e,
					(a, _) => $"it did:{Environment.NewLine}{Formatter.Format(a).Indent()}")),
			source);
	}
}
