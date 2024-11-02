﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Testably.Expectations.Core.Equivalency;
using Testably.Expectations.Formatting;

namespace Testably.Expectations.Options;

/// <summary>
///     Checks equality of objects.
/// </summary>
public class ObjectEqualityOptions
{
	private static readonly IMatchType ExactMatch = new ExactMatchType();
	private IMatchType _type = ExactMatch;

	/// <summary>
	///     Compares the objects via <see cref="object.Equals(object, object)" />.
	/// </summary>
	public ObjectEqualityOptions Equals()
	{
		_type = ExactMatch;
		return this;
	}

	/// <summary>
	///     Use equivalency to compare objects.
	/// </summary>
	public ObjectEqualityOptions Equivalent(EquivalencyOptions equivalencyOptions)
	{
		_type = new EquivalencyMatch(equivalencyOptions);
		return this;
	}

	/// <summary>
	///     Specifies a specific <see cref="IEqualityComparer{T}" /> to use for comparing <see cref="object" />s.
	/// </summary>
	/// <remarks>
	///     If set to <see langword="null" /> (default), uses the <see cref="StringComparer.Ordinal" /> or
	///     <see cref="StringComparer.OrdinalIgnoreCase" /> depending on whether the casing is ignored.
	/// </remarks>
	public ObjectEqualityOptions UsingComparer(IEqualityComparer<object> comparer)
	{
		_type = new ComparerMatch(comparer);
		return this;
	}

	internal Result AreConsideredEqual(object? a, object? b)
		=> _type.AreConsideredEqual(a, b);

	internal string GetExpectation(string expectedExpression)
		=> _type.GetExpectation(expectedExpression);

	/// <summary>
	///     The result of an equality check.
	/// </summary>
	public readonly struct Result(bool areConsideredEqual, string failure = "")
	{
		/// <summary>
		///     Flag indicating if the two values were considered equal.
		/// </summary>
		public bool AreConsideredEqual { get; } = areConsideredEqual;

		/// <summary>
		///     The failure message, when the two values were not equal.
		/// </summary>
		public string Failure { get; } = failure;
	}

	private interface IMatchType
	{
		Result AreConsideredEqual(object? a, object? b);
		string GetExpectation(string expectedExpression);
	}

	private sealed class EquivalencyMatch(EquivalencyOptions equivalencyOptions) : IMatchType
	{
		#region IMatchType Members

		/// <inheritdoc />
		public Result AreConsideredEqual(object? a, object? b)
		{
			if (HandleSpecialCases(a, b, out bool? specialCaseResult))
			{
				return new Result(specialCaseResult.Value, $"found {Formatter.Format(a)}");
			}

			List<ComparisonFailure> failures = Compare.CheckEquivalent(a, b,
				new CompareOptions
				{
					MembersToIgnore = [.. equivalencyOptions.MembersToIgnore],
				}).ToList();

			if (failures.FirstOrDefault() is { } firstFailure)
			{
				if (firstFailure.Type == MemberType.Value)
				{
					return new Result(false,
						$"found {Formatter.Format(firstFailure.Actual, FormattingOptions.SingleLine)}");
				}

				return new Result(false, $"""
				                          {firstFailure.Type} {string.Join(".", firstFailure.NestedMemberNames)} did not match:
				                            Expected: {Formatter.Format(firstFailure.Expected)}
				                            Received: {Formatter.Format(firstFailure.Actual)}
				                          """);
			}

			return new Result(true);
		}

		/// <inheritdoc />
		public string GetExpectation(string expectedExpression)
			=> $"be equivalent to {expectedExpression}";

		#endregion

		private bool HandleSpecialCases(object? a, object? b,
			[NotNullWhen(true)] out bool? isConsideredEqual)
		{
			if (a is IEqualityComparer basicEqualityComparer)
			{
				isConsideredEqual = basicEqualityComparer.Equals(a, b);
				return true;
			}

			if (b is IEqualityComparer expectedBasicEqualityComparer)
			{
				isConsideredEqual = expectedBasicEqualityComparer.Equals(a, b);
				return true;
			}

			if (a is IEnumerable enumerable && b is IEnumerable enumerable2)
			{
				isConsideredEqual =
					enumerable.Cast<object>().SequenceEqual(enumerable2.Cast<object>());
				return true;
			}

			isConsideredEqual = null;
			return false;
		}
	}

	private sealed class ExactMatchType : IMatchType
	{
		#region IMatchType Members

		/// <inheritdoc />
		public Result AreConsideredEqual(object? a, object? b)
			=> new(Equals(a, b), $"found {Formatter.Format(a)}");

		/// <inheritdoc />
		public string GetExpectation(string expectedExpression)
			=> $"be equal to {expectedExpression}";

		#endregion
	}

	private sealed class ComparerMatch(IEqualityComparer<object> comparer) : IMatchType
	{
		#region IMatchType Members

		/// <inheritdoc />
		public Result AreConsideredEqual(object? a, object? b)
			=> new(comparer.Equals(a, b), $"found {Formatter.Format(a)}");

		/// <inheritdoc />
		public string GetExpectation(string expectedExpression)
			=> $"be equal to {expectedExpression} using {Formatter.Format(comparer.GetType())}";

		#endregion
	}
}
