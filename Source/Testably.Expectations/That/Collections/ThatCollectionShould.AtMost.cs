using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
using Testably.Expectations.Options;
using Testably.Expectations.That.Collections;

// ReSharper disable once CheckNamespace
namespace Testably.Expectations;

public static partial class ThatCollectionShould
{
	/// <summary>
	///     Verifies that at most <paramref name="maximum" /> items...
	/// </summary>
	public static QuantifiableCollection<TItem, ICollection<TItem>> AtMost<TItem>(
		this IThat<ICollection<TItem>> source,
		int maximum, [CallerArgumentExpression("maximum")] string doNotPopulateThisValue = "")
	{
		source.ExpectationBuilder.AppendMethodStatement(nameof(AtMost), doNotPopulateThisValue);
		return new QuantifiableCollection<TItem, ICollection<TItem>>(source,
			CollectionQuantifier.AtMost(maximum));
	}
}
