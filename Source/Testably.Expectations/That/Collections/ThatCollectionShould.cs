using System.Collections.Generic;
using Testably.Expectations.Core;
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
		this IExpectSubject<ICollection<TItem>> subject)
		=> subject.Should(expectationBuilder => expectationBuilder
			.AppendMethodStatement(nameof(Should)));
}
