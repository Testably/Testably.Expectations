using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
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
