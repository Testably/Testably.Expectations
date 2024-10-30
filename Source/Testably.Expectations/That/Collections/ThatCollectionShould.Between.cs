using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;
using Testably.Expectations.Results;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatCollectionShould
{
	/// <summary>
	///     Verifies that between <paramref name="minimum" />...
	/// </summary>
	public static BetweenResult<QuantifiableCollection<TItem, ICollection<TItem>>> Between<TItem>(
		this IThat<ICollection<TItem>> source,
		int minimum,
		[CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendMethodStatement(nameof(Between), doNotPopulateThisValue);
		return new BetweenResult<QuantifiableCollection<TItem, ICollection<TItem>>>(
			source.ExpectationBuilder,
			maximum => new QuantifiableCollection<TItem, ICollection<TItem>>(source,
				CollectionQuantifier.Between(minimum, maximum)));
	}
}
