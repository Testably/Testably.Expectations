using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="DateTime" /> values.
/// </summary>
public static partial class ThatDateTimeExtensions
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateTime, That<DateTime>> Is(this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new IsConstraint(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is after the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateTime, That<DateTime>> IsAfter(this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e) => a > e,
					$"is after {Formatter.Format(expected)}"),
				b => b.AppendMethod(nameof(IsAfter), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is on or after the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateTime, That<DateTime>> IsOnOrAfter(this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e) => a >= e,
					$"is on or after {Formatter.Format(expected)}"),
				b => b.AppendMethod(nameof(IsOnOrAfter), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is before the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateTime, That<DateTime>> IsBefore(this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e) => a < e,
					$"is before {Formatter.Format(expected)}"),
				b => b.AppendMethod(nameof(IsBefore), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is on or before the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateTime, That<DateTime>> IsOnOrBefore(this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e) => a <= e,
					$"is on or before {Formatter.Format(expected)}"),
				b => b.AppendMethod(nameof(IsOnOrBefore), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not after the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateTime, That<DateTime>> IsNotAfter(this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e) => a <= e,
					$"is not after {Formatter.Format(expected)}"),
				b => b.AppendMethod(nameof(IsNotAfter), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not on or after the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateTime, That<DateTime>> IsNotOnOrAfter(this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e) => a < e,
					$"is not on or after {Formatter.Format(expected)}"),
				b => b.AppendMethod(nameof(IsNotOnOrAfter), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not before the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateTime, That<DateTime>> IsNotBefore(this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e) => a >= e,
					$"is not before {Formatter.Format(expected)}"),
				b => b.AppendMethod(nameof(IsNotBefore), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not on or before the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateTime, That<DateTime>> IsNotOnOrBefore(this That<DateTime> source,
		DateTime expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new ConditionConstraint(
					expected,
					(a, e) => a > e,
					$"is not on or before {Formatter.Format(expected)}"),
				b => b.AppendMethod(nameof(IsNotOnOrBefore), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<DateTime, That<DateTime>> IsNot(this That<DateTime> source,
		DateTime unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new IsNotConstraint(unexpected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);
}
