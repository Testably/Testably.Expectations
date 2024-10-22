using System;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on <see cref="TimeSpan" /> values.
/// </summary>
public static partial class ThatTimeSpanExtensions
{
	/// <summary>
	///     Verifies that the subject is equal to the <paramref name="expected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TimeSpan, That<TimeSpan>> Is(this That<TimeSpan> source,
		TimeSpan expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new IsConstraint(expected),
				b => b.AppendMethod(nameof(Is), doNotPopulateThisValue)),
			source);

	/// <summary>
	///     Verifies that the subject is not equal to the <paramref name="unexpected" /> value.
	/// </summary>
	public static AndOrExpectationResult<TimeSpan, That<TimeSpan>> IsNot(this That<TimeSpan> source,
		TimeSpan unexpected,
		[CallerArgumentExpression("unexpected")]
		string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(new IsNotConstraint(unexpected),
				b => b.AppendMethod(nameof(IsNot), doNotPopulateThisValue)),
			source);
}
