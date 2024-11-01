﻿#if NET6_0_OR_GREATER
using System.Collections.Generic;
using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatAsyncEnumerableShould
{
	/// <summary>
	///     Verifies that no items in the enumerable...
	/// </summary>
	public static QuantifiedCollectionResult.Async
		<IThat<IAsyncEnumerable<TItem>>, TItem, IAsyncEnumerable<TItem>> None<TItem>(
		this IThat<IAsyncEnumerable<TItem>> source)
		=> new(source,
			source.ExpectationBuilder.AppendMethodStatement(nameof(None)),
			CollectionQuantifier.None);
}
#endif
