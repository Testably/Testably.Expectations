using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.Results;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Verifies that between <paramref name="minimum" />...
	/// </summary>
	public static BetweenResult<QuantifiableCollection<TItem, IEnumerable<TItem>>> Between<TItem>(
		this IThat<IEnumerable<TItem>> source,
		int minimum,
		[CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendMethodStatement(nameof(Between), doNotPopulateThisValue);
		return new BetweenResult<QuantifiableCollection<TItem, IEnumerable<TItem>>>(
			source.ExpectationBuilder,
			maximum => new QuantifiableCollection<TItem, IEnumerable<TItem>>(source,
				CollectionQuantifier.Between(minimum, maximum)));
	}
}
