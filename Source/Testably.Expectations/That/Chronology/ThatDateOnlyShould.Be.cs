#if !NETSTANDARD2_0
using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatDateOnlyShould
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<DateOnly, IThat<DateOnly>> Be(this IThat<DateOnly> source,
		DateOnly expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
	{
		return new AndOrResult<DateOnly, IThat<DateOnly>>(source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint(
					expected,
					(a, e) => a.Equals(e),
					$"be {Formatter.Format(expected)}"))
				.AppendMethodStatement(nameof(Be), doNotPopulateThisValue),
			source);
	}

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrResult<DateOnly, IThat<DateOnly>> NotBe(
		this IThat<DateOnly> source,
		DateOnly unexpected,
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
#endif
