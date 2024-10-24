using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.Results;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatCollectionShould
{
	/// <summary>
	///     Verifies that between <paramref name="minimum" />...
	/// </summary>
	public static BetweenResult<QuantifiableCollection<TItem, ICollection<TItem>>> Between<TItem>(
		this That<ICollection<TItem>> source,
		int minimum,
		[CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendExpression(b
			=> b.AppendMethod(nameof(Between), doNotPopulateThisValue));
		return new BetweenResult<QuantifiableCollection<TItem, ICollection<TItem>>>(
			maximum => new QuantifiableCollection<TItem, ICollection<TItem>>(source,
				CollectionQuantifier.Between(minimum, maximum)),
			callback => source.ExpectationBuilder.AppendExpression(callback));
	}
}
