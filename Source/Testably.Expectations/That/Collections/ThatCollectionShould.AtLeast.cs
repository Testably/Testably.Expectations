using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Options;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatCollectionShould
{
	/// <summary>
	///     Verifies that at least <paramref name="minimum" /> items...
	/// </summary>
	public static QuantifiableCollection<TItem, ICollection<TItem>> AtLeast<TItem>(
		this IThat<ICollection<TItem>> source,
		int minimum, [CallerArgumentExpression("minimum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendMethodStatement(nameof(AtLeast), doNotPopulateThisValue);
		return new QuantifiableCollection<TItem, ICollection<TItem>>(source,
			CollectionQuantifier.AtLeast(minimum));
	}
}
