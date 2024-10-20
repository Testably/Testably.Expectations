using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Formatting;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Core.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

/// <summary>
///     Expectations on generic values.
/// </summary>
public static partial class ThatGenericExtensions
{
	/// <summary>
	///     Expect the actual value to be the same as the <paramref name="expected" /> value.
	/// </summary>
	public static AssertionResultAndOr<T, That<T>> IsSameAs<T>(this That<T> source,
		object? expected,
		[CallerArgumentExpression("expected")] string doNotPopulateThisValue = "")
		=> new(source.ExpectationBuilder.Add(
				new IsSameAsConstraint<T>(expected, doNotPopulateThisValue),
				b => b.AppendMethod(nameof(IsSameAs), doNotPopulateThisValue)),
			source);
}
