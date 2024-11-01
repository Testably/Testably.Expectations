using System.Collections.Generic;
using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Verifies that all items in the enumerable...
	/// </summary>
	public static SyncQuantifiedCollectionResult
		<IThat<IEnumerable<TItem>>, TItem, IEnumerable<TItem>> All<TItem>(
			this IThat<IEnumerable<TItem>> source)
	{
		source.ExpectationBuilder.AppendMethodStatement(nameof(All));
		return new SyncQuantifiedCollectionResult<
			IThat<IEnumerable<TItem>>, TItem, IEnumerable<TItem>>(
			source,
			source.ExpectationBuilder,
			CollectionQuantifier.All);
	}
}
