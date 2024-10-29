using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Equivalency;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatObjectShould
{
	/// <summary>
	///     Verifies that the subject is equivalent to the <paramref name="expected" /> value.
	/// </summary>
	public static EquivalencyOptionsExpectationResult<T, IThat<T>> BeEquivalentTo<T>(
		this IThat<T> source,
		object expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		EquivalencyOptions options = new();
		return new EquivalencyOptionsExpectationResult<T, IThat<T>>(
			source.ExpectationBuilder
				.AddConstraint(new IsEquivalentToValueConstraint(
					expected, doNotPopulateThisValue, options))
				.AppendMethodStatement(nameof(BeEquivalentTo), doNotPopulateThisValue),
			source,
			options);
	}

	private readonly struct IsEquivalentToValueConstraint(
		object? expected,
		string expectedExpression,
		EquivalencyOptions options) : IValueConstraint<object?>
	{
		public ConstraintResult IsMetBy(object? actual)
		{
			if (HandleSpecialCases(actual, out ConstraintResult? specialCaseResult))
			{
				return specialCaseResult;
			}

			List<ComparisonFailure> failures = Compare.CheckEquivalent(actual, expected,
				new CompareOptions
				{
					MembersToIgnore = [.. options.MembersToIgnore],
				}).ToList();

			if (failures.FirstOrDefault() is { } firstFailure)
			{
				if (firstFailure.Type == MemberType.Value)
				{
					return new ConstraintResult.Failure(ToString(),
						$"found {Formatter.Format(firstFailure.Actual)}");
				}

				return new ConstraintResult.Failure(ToString(),
					$"""
					 {firstFailure.Type} {string.Join(".", firstFailure.NestedMemberNames)} did not match:
					   Expected: {Formatter.Format(firstFailure.Expected)}
					   Received: {Formatter.Format(firstFailure.Actual)}
					 """);
			}

			return new ConstraintResult.Success<object?>(actual, ToString());
		}

		private bool HandleSpecialCases(object? actual,
			[NotNullWhen(true)] out ConstraintResult? constraintResult)
		{
			bool? isEqual = null;
			if (actual is IEqualityComparer basicEqualityComparer)
			{
				isEqual = basicEqualityComparer.Equals(actual, expected);
			}
			else if (expected is IEqualityComparer expectedBasicEqualityComparer)
			{
				isEqual = expectedBasicEqualityComparer.Equals(actual, expected);
			}
			else if (actual is IEnumerable enumerable && expected is IEnumerable enumerable2)
			{
				isEqual = enumerable.Cast<object>().SequenceEqual(enumerable2.Cast<object>());
			}

			if (isEqual == true)
			{
				constraintResult = new ConstraintResult.Success<object?>(actual, ToString());
				return true;
			}

			if (isEqual == false)
			{
				constraintResult = new ConstraintResult.Failure(ToString(),
					$"found {Formatter.Format(actual)}");
				return true;
			}

			constraintResult = null;
			return false;
		}

		public override string ToString()
			=> $"be equivalent to {expectedExpression}";
	}
}
