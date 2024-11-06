using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

namespace Testably.Expectations;

public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Verifies that at least <paramref name="minimum" /> items...
	/// </summary>
	public static QuantifiedCollectionResult.Sync
		<IThat<IEnumerable<TItem>>, TItem, IEnumerable<TItem>> AtLeast<TItem>(
			this IThat<IEnumerable<TItem>> source,
			int minimum, [CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendMethodStatement(nameof(AtLeast), doNotPopulateThisValue);
		return new QuantifiedCollectionResult.Sync<IThat<IEnumerable<TItem>>, TItem,
			IEnumerable<TItem>>(
			source,
			source.ExpectationBuilder,
			CollectionQuantifier.AtLeast(minimum));
	}
}
