using System.Collections.Generic;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

namespace Testably.Expectations.That.Collections;

/// <summary>
///     A quantifiable collection matching items against the expected <paramref name="quantity" />.
/// </summary>
public class QuantifiableCollection<TItem, TCollection>(
	IThat<TCollection> collection,
	CollectionQuantifier quantity)
	where TCollection : IEnumerable<TItem>
{
	/// <summary>
	///     The collection.
	/// </summary>
	public IThat<TCollection> Collection => collection;

	/// <summary>
	///     The quantifier.
	/// </summary>
	public CollectionQuantifier Quantity => quantity;
}
