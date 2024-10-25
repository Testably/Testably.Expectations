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
	public static That<ICollection<TItem>> Should<TItem>(
		this IExpectThat<ICollection<TItem>> subject)
	{
		subject.ExpectationBuilder.AppendExpression(b => b.AppendMethod(nameof(Should)));
		return new ThatImpl<ICollection<TItem>>(subject.ExpectationBuilder);
	}
}
