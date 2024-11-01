using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Verifies that between <paramref name="minimum" />...
	/// </summary>
	public static BetweenResult<SyncQuantifiedCollectionResult
			<IThat<IEnumerable<TItem>>, TItem, IEnumerable<TItem>>>
		Between<TItem>(
			this IThat<IEnumerable<TItem>> source,
			int minimum,
			[CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendMethodStatement(nameof(Between), doNotPopulateThisValue);
		return new BetweenResult<SyncQuantifiedCollectionResult<IThat<IEnumerable<TItem>>, TItem, IEnumerable<TItem>>>(
			source.ExpectationBuilder,
			maximum => new SyncQuantifiedCollectionResult<IThat<IEnumerable<TItem>>, TItem, IEnumerable<TItem>>(
				source,
				source.ExpectationBuilder,
				CollectionQuantifier.Between(minimum, maximum)));
	}
}
