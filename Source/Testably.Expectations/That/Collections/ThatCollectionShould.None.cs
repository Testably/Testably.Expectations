using System.Collections.Generic;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatCollectionShould
{
	/// <summary>
	///     Verifies that no items in the collection...
	/// </summary>
	public static QuantifiableCollection<TItem, ICollection<TItem>> None<TItem>(
		this IThat<ICollection<TItem>> source)
	{
		source.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(None)));
		return new QuantifiableCollection<TItem, ICollection<TItem>>(source,
			CollectionQuantifier.None);
	}
}
