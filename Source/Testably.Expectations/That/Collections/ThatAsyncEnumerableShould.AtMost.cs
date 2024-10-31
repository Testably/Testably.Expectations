#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatAsyncEnumerableShould
{
	/// <summary>
	///     Verifies that at most <paramref name="maximum" /> items...
	/// </summary>
	public static QuantifiedCollectionResult<IThat<IAsyncEnumerable<TItem>>> AtMost<TItem>(
		this IThat<IAsyncEnumerable<TItem>> source,
		int maximum, [CallerArgumentExpression("maximum")] string doNotPopulateThisValue = "")
		=> new(source,
			source.ExpectationBuilder.AppendMethodStatement(nameof(AtMost), doNotPopulateThisValue),
			CollectionQuantifier.AtMost(maximum));
}
#endif
