﻿using System;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;

namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="string" /> values.
/// </summary>
public static partial class ThatStringShould
{
	/// <summary>
	///     Start expectations for the current <see cref="string" />? <paramref name="subject" />.
	/// </summary>
	public static IThat<string?> Should(this IExpectSubject<string?> subject)
		=> subject.Should(_ => { });

	private readonly struct GenericConstraint(
		string? expected,
		Func<string?, string> expectation,
		Func<string?, string?, bool> condition,
		Func<string?, string?, string> failureMessageFactory) : IValueConstraint<string?>
	{
		public ConstraintResult IsMetBy(string? actual)
		{
			if (expected is null)
			{
				return new ConstraintResult.Failure(ToString(),
					failureMessageFactory(actual, expected));
			}

			if (condition(actual, expected))
			{
				return new ConstraintResult.Success<string?>(actual, ToString());
			}

			return new ConstraintResult.Failure(ToString(),
				failureMessageFactory(actual, expected));
		}

		public override string ToString()
			=> expectation(expected);
	}
}
