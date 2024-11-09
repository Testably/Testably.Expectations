using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Formatting;
using Testably.Expectations.Results;

namespace Testably.Expectations;

public static partial class ThatGenericShould
{
	/// <summary>
	///     Expect the actual value to be the same as the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrResult<T, IThat<T>> BeSameAs<T>(this IThat<T> source,
		object? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint<object?>(
					expected,
					$"refer to {doNotPopulateThisValue} {Formatter.Format(expected, FormattingOptions.MultipleLines)}",
					(a, e) => ReferenceEquals(e, a),
					(a, _) => $"found {Formatter.Format(a, FormattingOptions.MultipleLines)}")),
			source);

	/// <summary>
	///     Expect the actual value to not be the same as the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrResult<T, IThat<T>> NotBeSameAs<T>(this IThat<T> source,
		object? unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder
				.AddConstraint(new ConditionConstraint<object?>(
					unexpected,
					$"not refer to {doNotPopulateThisValue} {Formatter.Format(unexpected, FormattingOptions.MultipleLines)}",
					(a, e) => !ReferenceEquals(e, a),
					(_, _) => "it did")),
			source);
}
