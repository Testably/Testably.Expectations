using System.Collections.Generic;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Verifies that no items in the enumerable...
	/// </summary>
	public static QuantifiableCollection<TItem, IEnumerable<TItem>> None<TItem>(
		this That<IEnumerable<TItem>> source)
	{
		source.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(None)));
		return new QuantifiableCollection<TItem, IEnumerable<TItem>>(source,
			CollectionQuantifier.None);
	}
}
