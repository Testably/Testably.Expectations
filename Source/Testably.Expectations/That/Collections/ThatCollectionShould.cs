using System.Collections.Generic;
using Testably.Expectations.Core;
using Testably.Expectations.Core.Helpers;
// ReSharper disable once CheckNamespace

namespace Testably.Expectations;

/// <summary>
///     Expectations on collections.
/// </summary>
public static partial class ThatCollectionShould
{
	/// <summary>
	///     Start delegate expectations on the current collection of <typeparamref name="TItem" /> values.
	/// </summary>
	public static IThat<ICollection<TItem>> Should<TItem>(
		this IExpectThat<ICollection<TItem>> subject)
		=> new That<ICollection<TItem>>(subject.ExpectationBuilder.AppendMethodStatement(nameof(Should)));
}
