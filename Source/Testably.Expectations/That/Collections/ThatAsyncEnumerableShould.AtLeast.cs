#if NET6_0_OR_GREATER
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatAsyncEnumerableShould
{
	/// <summary>
	///     Verifies that at least <paramref name="minimum" /> items...
	/// </summary>
	public static QuantifiedCollectionResult<IThat<IAsyncEnumerable<TItem>>> AtLeast<TItem>(
		this IThat<IAsyncEnumerable<TItem>> source,
		int minimum, [CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
		=> new(source,
			source.ExpectationBuilder.AppendMethodStatement(nameof(AtLeast),
				doNotPopulateThisValue),
			CollectionQuantifier.AtLeast(minimum));
}
#endif
