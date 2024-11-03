using System.Collections.Generic;
using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Verifies that no items in the enumerable...
	/// </summary>
	public static
		QuantifiedCollectionResult.Sync<IThat<IEnumerable<TItem>>, TItem, IEnumerable<TItem>>
		None<TItem>(
			this IThat<IEnumerable<TItem>> source)
	{
		source.ExpectationBuilder.AppendMethodStatement(nameof(None));
		return new QuantifiedCollectionResult.Sync<IThat<IEnumerable<TItem>>, TItem,
			IEnumerable<TItem>>(
			source,
			source.ExpectationBuilder,
			CollectionQuantifier.None);
	}
}
