using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatTimeSpanShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<TimeSpan, IThat<TimeSpan>> Be(this IThat<TimeSpan> source,
		TimeSpan expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					(a, e) => a.Equals(e),
					$"be {Formatter.Format(expected)}"))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrResult<TimeSpan, IThat<TimeSpan>> NotBe(
		this IThat<TimeSpan> source,
		TimeSpan unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					unexpected,
					(a, e) => !a.Equals(e),
					$"not be {Formatter.Format(unexpected)}"))
				.AppendMethodStatement(nameof(NotBe), doNotPopulateThisValue),
			source);
}
