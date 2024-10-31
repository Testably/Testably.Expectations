using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatEnumerableShould
{
	/// <summary>
	///     Verifies that at most <paramref name="maximum" /> items...
	/// </summary>
	public static QuantifiedCollectionResult<IThat<IEnumerable<TItem>>> AtMost<TItem>(
		this IThat<IEnumerable<TItem>> source,
		int maximum, [CallerArgumentExpression("maximum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendMethodStatement(nameof(AtMost), doNotPopulateThisValue);
		return new QuantifiedCollectionResult<IThat<IEnumerable<TItem>>>(
			source,
			source.ExpectationBuilder,
			CollectionQuantifier.AtMost(maximum));
	}
}
