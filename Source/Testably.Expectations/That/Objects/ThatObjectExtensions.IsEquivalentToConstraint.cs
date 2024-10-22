using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Testably.Expectations.Core.Constraints;
using Testably.Expectations.Core.Equivalency;
using Testably.Expectations.Formatting;
using Testably.Expectations.Options;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatObjectExtensions
{
	private readonly struct IsEquivalentToConstraint(
		object? expected,
		string expectedExpression,
		EquivalencyOptions options) : IConstraint<object?>
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
			=> $"is equivalent to {expectedExpression}";
	}
}
