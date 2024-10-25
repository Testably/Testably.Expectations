﻿using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatStringShould
{
	/// <summary>
	///     Verifies that the subject is equal to <paramref name="expected" />.
	/// </summary>
	public static StringMatcherExpectationResult<string?, That<string?>> Be(
		this That<string?> source,
		StringMatcher expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsConstraint(expected),
				b => b.AppendMethod(nameof(Be), doNotPopulateThisValue)),
			source,
			expected);

	private readonly struct IsConstraint(StringMatcher expected) : IConstraint<string?>
	{
		/// <inheritdoc />
		public ConstraintResult IsMetBy(string? actual)
		{
			if (expected.Matches(actual))
			{
				return new ConstraintResult.Success<string?>(actual, ToString());
			}

			return new ConstraintResult.Failure<string?>(actual, ToString(),
				expected.GetExtendedFailure(actual));
		}

		/// <inheritdoc />
		public override string ToString()
			=> expected.GetExpectation(GrammaticVoice.ActiveVoice);
	}
}